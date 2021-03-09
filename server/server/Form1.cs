using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace server
{
   
    public partial class Form1 : Form
    {
        class serverpath
        {
            public static string folderpath;
            public static string datapath;
            public static string incmessage = "";
            public static string upload_done = "";
            public static string publicpath;
        }
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();

        bool terminating = false;
        bool listening = false;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void button_listen_Click(object sender, EventArgs e)
        {
            int serverPort;

            if(Int32.TryParse(textBox_port.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                button_listen.Enabled = false;
                textBox_message.Enabled = true;
                button_send.Enabled = true;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else
            {
                logs.AppendText("Please check port number \n");
            }
        }

        private void Accept()
        {
            while(listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    clientSockets.Add(newClient);
                    logs.AppendText("A client is connected.\n");

                    Thread receiveThread = new Thread(() => Receive(newClient)); // updated
                    receiveThread.Start();
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working.\n");
                    }

                }
            }
        }
       
        private void Receive(Socket thisClient) // updated
        {
            bool connected = true;
            bool req_file = false;

            int size = 0;
            string msg = "";
            string uniquefilename;

            string warning = "Name already exists";
            string username = "null";
            string filename = "null";

            if (username == "null") // first received message is username so it is handled here
            {
                try
                {
                    Byte[] buffer_warn = new Byte[128];
                    Byte[] buffer = new Byte[128];
                    thisClient.Receive(buffer);
                    username = Encoding.Default.GetString(buffer);
                    username = username.Substring(0, username.IndexOf("\0"));
                    string[] lines = File.ReadAllLines("database.txt");
                    foreach (string line in lines)//checks database if user already connected
                    {
                        if (username == line)
                        {
                           
                           
                            buffer_warn = Encoding.Default.GetBytes(warning);
                            thisClient.Send(buffer_warn);
                            thisClient.Close();
                            clientSockets.Remove(thisClient);
                            connected = false;
                            
                           
                        }
                    }
                    using (StreamWriter writer = File.AppendText("database.txt"))//writes username to database
                    {
                        writer.WriteLine(username);

                    }
                }

                catch
                {

                    if (!terminating)
                    {
                        logs.AppendText("username couldn't be received\n");
                        logs.AppendText("A client has disconnected\n");
                        
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    connected = false;
                }
            }

            if(filename == "null") // 2nd first received message is filename so it is handled here
            {
                try
                {
                    Byte[] buffer = new Byte[128];
                    thisClient.Receive(buffer);
                    filename = Encoding.Default.GetString(buffer);
                    filename = filename.Substring(0, filename.IndexOf("\0"));
                   

                    if (username != "null")
                    {
                        
                        using (StreamWriter writer = File.CreateText(username + "_" + filename))//creates file with username and filename combined
                        {
                            
                        }
                        
                    }

                    
                }

                catch
                {

                    if (!terminating)
                    {
                        
                        logs.AppendText("A client has disconnected\n");
                        
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    connected = false;
                    // delete disconnected username

                    if (!string.IsNullOrWhiteSpace(username))
                    {
                        string LinesToDelete = username;
                        var Lines = File.ReadAllLines("database.txt");
                        if (Lines.Contains(username))
                        {
                            var newLines = Lines.Where(line => !line.Contains(LinesToDelete));
                            File.WriteAllLines(@"database.txt", newLines);
                            
                        }

                        else
                        {
                            logs.AppendText("Something wrong happened deleting the username!\n");
                        }
                    }
                }

                
                
            }
            uniquefilename = username + "_" + filename;
            
            while (connected && !terminating && username != "")
            {
                if (filename == "null") // 2nd received message if filename so it is handled here
                {
                    
                    try
                    {
                        Byte[] buffer = new Byte[1024];
                        thisClient.Receive(buffer);
                        filename = Encoding.Default.GetString(buffer);
                        filename = filename.Substring(0, filename.IndexOf("\0"));

                        if (username != "null" &&
                            filename != "get_file_list" &&
                            !filename.Contains("download_file%") &&
                            !filename.Contains("delete_file%") &&
                            !filename.Contains("copy_file%") &&
                            !filename.Contains("pub_file%") &&
                            !filename.Contains("public_get_file_list") &&
                            !filename.Contains("public_down_file%") &&
                            !filename.Contains("public_copy%") &&
                            !filename.Contains("public_delete%"))
                        {
                            

                            using (StreamWriter writer = File.CreateText(username + "_" + filename))//creates file with username and filename combined
                            {
                                logs.AppendText("file created here");
                            }




                        }

                        // request file list handling above. private files of the requester is send back
                        else if (filename == "get_file_list")
                        {

                            string temp_name = username + "_";

                            Byte[] rtr = new Byte[2048];

                            string return_msg = "Here's File list: \n";

                            string[] files = Directory.GetFiles(@serverpath.folderpath);
                            foreach (string file in files)
                            {

                                if (Path.GetFileName(file).Contains(temp_name))
                                {
                                    DateTime creation = File.GetCreationTime(file);
                                    FileInfo f1 = new FileInfo(file);
                                    long filesize = f1.Length;

                                    return_msg = Path.GetFileName(file);
                                    var pieces = return_msg.Split(new[] { '_' }, 2);
                                    logs.AppendText(pieces[1] + " creation: " + creation.ToString());
                                    rtr = Encoding.Default.GetBytes("file name: " + pieces[1] + "\n" + "upload time: " + creation.ToString() + "\n" + "size: " + filesize.ToString() + "\n");
                                    thisClient.Send(rtr);
                                    Thread.Sleep(10);

                                    

                                }

                            }

                            

                            req_file = true;
                        }

                        //request download handling above

                        else if (filename.Contains("download_file%"))
                        {
                            string requested_file;
                            int escape_index;

                            escape_index = filename.IndexOf('%');
                            requested_file = filename.Remove(0, escape_index + 1);
                            logs.AppendText("Requested file: " + requested_file + "\n");

                            // check if the requested file exists

                            string append_path = username + "_" + requested_file + ".txt";
                            string new_path = Path.Combine(serverpath.folderpath, append_path);
                            // logs.AppendText("path: " + new_path + "\n");

                            if (File.Exists(@new_path))
                            {
                                logs.AppendText("Requested file exists\n");


                                Byte[] file_line = new Byte[1024];
                                string[] lines = File.ReadAllLines(@new_path);

                                //string req_name = Path.GetFileName(@new_path);
                                //file_line = Encoding.Default.GetBytes(req_name);
                                //thisClient.Send(file_line);

                                foreach (string line in lines)
                                {
                                    file_line = Encoding.Default.GetBytes(line);
                                    thisClient.Send(file_line);
                                    Thread.Sleep(10);
                                    if (lines[lines.Length - 1] == line)
                                    {
                                        string last_msg = "file_uploaded_code";
                                        file_line = Encoding.Default.GetBytes(last_msg);
                                        thisClient.Send(file_line);

                                    }
                                }


                            }
                            else
                            {
                                logs.AppendText("Requested file not found!\n");
                                Byte[] file_line = new Byte[1024];
                                file_line = Encoding.Default.GetBytes("Requested file not found!\n");
                                thisClient.Send(file_line);
                            }

                            req_file = true;
                        }

                        // request to delete handling above
                        else if (filename.Contains("delete_file%"))
                        {
                            string requested_file;
                            int escape_index;

                            escape_index = filename.IndexOf('%');
                            requested_file = filename.Remove(0, escape_index + 1);

                            string append_path = username + "_" + requested_file + ".txt";
                            string new_path = Path.Combine(serverpath.folderpath, append_path);
                            logs.AppendText("Requested file to delete: " + requested_file + "\n");

                            if (File.Exists(@new_path))
                            {
                                logs.AppendText("Requested file exists\n");
                                File.Delete(@new_path);

                            }
                            else
                            {
                                logs.AppendText("Requested file not found!\n");
                                Byte[] file_line = new Byte[1024];
                                file_line = Encoding.Default.GetBytes("Requested file not found!\n");
                                thisClient.Send(file_line);
                            }

                            req_file = true;
                        }

                        // copy file request handling above
                        else if (filename.Contains("copy_file%"))
                        {

                            string requested_file;
                            int escape_index;

                            escape_index = filename.IndexOf('%');
                            requested_file = filename.Remove(0, escape_index + 1);


                            string append_path = username + "_" + requested_file;
                            logs.AppendText("Requested file to copy: " + append_path + "\n");
                            string new_path = Path.Combine(serverpath.folderpath, append_path);

                            if (File.Exists(new_path + ".txt"))
                            {
                                string reference_path = new_path;
                                int count = 0;
                            Find:
                                if (File.Exists(new_path + ".txt"))
                                {
                                    new_path = reference_path;
                                    count++;
                                    new_path = new_path + "-" + count.ToString().PadLeft(2, '0');
                                    goto Find;
                                }
                                else
                                {

                                    File.Copy(reference_path + ".txt", new_path + ".txt");
                                }



                            }


                            else
                            {
                                logs.AppendText("Requested file not found!\n");
                                Byte[] file_line = new Byte[1024];
                                file_line = Encoding.Default.GetBytes("Requested file not found!\n");
                                thisClient.Send(file_line);
                            }

                            req_file = true;

                        }
                        else if (filename.Contains("pub_file%"))
                        {
                            string requested_file;
                            int escape_index;

                            escape_index = filename.IndexOf('%');
                            requested_file = filename.Remove(0, escape_index + 1);
                            string append_path = username + "_" + requested_file + ".txt";
                            string new_path = Path.Combine(serverpath.folderpath, append_path);

                            if (File.Exists(@new_path))
                            {
                                string public_path = Path.Combine(serverpath.publicpath, append_path);

                                try
                                {
                                    File.Move(new_path, public_path);
                                    logs.AppendText(requested_file + " is now public!\n");
                                }
                                catch (Exception e)
                                {
                                    logs.AppendText("The process failed: " + e.ToString());

                                }




                            }



                            else
                            {
                                logs.AppendText("An error occured!\n");
                                Byte[] error_line = new Byte[1024];
                                error_line = Encoding.Default.GetBytes("An error occured!\n");
                                thisClient.Send(error_line);
                            }


                            req_file = true;
                        }

                        else if (filename.Contains("public_get_file_list"))
                        {

                            Byte[] rtr = new Byte[2048];

                            string return_msg = "Here's File list: \n";

                            string[] files = Directory.GetFiles(@serverpath.publicpath);
                            
                            foreach (string file in files)
                            {
                                DateTime creation = File.GetCreationTime(file);
                                FileInfo f1 = new FileInfo(file);
                                long filesize = f1.Length;

                                return_msg = Path.GetFileName(file);
                                //var pieces = return_msg.Split(new[] { '_' }, 2);
                                rtr = Encoding.Default.GetBytes("file name: " + return_msg + "\n" + "upload time: " + creation.ToString() + "\n" + "size: " + filesize.ToString() + "\n");
                                thisClient.Send(rtr);
                                Thread.Sleep(20);


                            }

                            logs.AppendText("final message: \n" + return_msg);

                            req_file = true;
                        }

                        else if (filename.Contains("public_down_file%"))
                        {
                            string requested_file;
                            int escape_index;

                            escape_index = filename.IndexOf('%');
                            requested_file = filename.Remove(0, escape_index + 1);
                            logs.AppendText("Requested file: " + requested_file + "\n");

                            // check if the requested file exists

                            //var pieces = requested_file.Split(new[] { '_' }, 2);
                            string append_path = requested_file + ".txt";
                            string new_path = Path.Combine(serverpath.publicpath, append_path);

                            if (File.Exists(@new_path))
                            {
                                logs.AppendText("Requested file exists\n");


                                Byte[] file_line = new Byte[1024];
                                string[] lines = File.ReadAllLines(@new_path);
                                foreach (string line in lines)
                                {
                                    file_line = Encoding.Default.GetBytes(line);
                                    thisClient.Send(file_line);
                                    Thread.Sleep(10);

                                    if (lines[lines.Length - 1] == line)
                                    {
                                        string last_msg = "file_uploaded_code";
                                        file_line = Encoding.Default.GetBytes(last_msg);
                                        thisClient.Send(file_line);

                                    }
                                }
                            }
                            else
                            {
                                logs.AppendText("Requested file not found!\n");
                                Byte[] file_line = new Byte[1024];
                                file_line = Encoding.Default.GetBytes("Requested file not found!\n");
                                thisClient.Send(file_line);
                            }

                            req_file = true;

                        }

                        else if (filename.Contains("public_copy%"))
                        {


                            string requested_file;
                            int escape_index;

                            escape_index = filename.IndexOf('%');
                            requested_file = filename.Remove(0, escape_index + 1);

                            var pieces = requested_file.Split(new[] { '_' }, 2);

                            if (username == pieces[0])
                            {
                                string append_path = username + "_" + pieces[1];
                                logs.AppendText("Requested file to copy: " + append_path + "\n");
                                string new_path = Path.Combine(serverpath.publicpath, append_path);

                                if (File.Exists(new_path + ".txt"))
                                {
                                    string reference_path = new_path;
                                    int count = 0;
                                Find:
                                    if (File.Exists(new_path + ".txt"))
                                    {
                                        new_path = reference_path;
                                        count++;
                                        new_path = new_path + "-" + count.ToString().PadLeft(2, '0');
                                        goto Find;
                                    }
                                    else
                                    {

                                        File.Copy(reference_path + ".txt", new_path + ".txt");
                                    }
                                }



                            }

                            req_file = true;
                        }

                        else if (filename.Contains("public_delete%"))
                        {

                            string requested_file;
                            int escape_index;

                            escape_index = filename.IndexOf('%');
                            requested_file = filename.Remove(0, escape_index + 1);
                            var pieces = requested_file.Split(new[] { '_' }, 2);

                            if (username == pieces[0])
                            {
                                string append_path = username + "_" + pieces[1] + ".txt";
                                string new_path = Path.Combine(serverpath.publicpath, append_path);
                                logs.AppendText("Requested file to delete: " + requested_file + "\n");

                                if (File.Exists(@new_path))
                                {
                                    logs.AppendText("Requested file exists\n");
                                    File.Delete(@new_path);

                                }
                                else
                                {
                                    logs.AppendText("Requested file not found!\n");
                                    Byte[] file_line = new Byte[1024];
                                    file_line = Encoding.Default.GetBytes("Requested file not found!\n");
                                    thisClient.Send(file_line);
                                }
                            }
                            

                            req_file = true;
                        }







                        else
                            req_file = false; // this means there is no request code coming from client

                        


                    }

                    catch
                    {

                        if (!terminating)
                        {
                            
                            logs.AppendText("A client has disconnected\n");
                            
                        }
                        thisClient.Close();
                        clientSockets.Remove(thisClient);
                        connected = false;
                        // delete disconnected username
                        if (!string.IsNullOrWhiteSpace(username))
                        {
                            string LinesToDelete = username;
                            var Lines = File.ReadAllLines("database.txt");
                            if (Lines.Contains(username))
                            {
                                var newLines = Lines.Where(line => !line.Contains(LinesToDelete));
                                File.WriteAllLines(@"database.txt", newLines);

                            }

                            else
                            {
                                logs.AppendText("Something wrong happened deleting the username!\n");
                            }
                        }
                    }



                }


                try
                {
                    if (req_file)
                    {
                        filename = "null";
                        req_file = false;
                    }

                    else
                    {
                        Byte[] buffer = new Byte[1024];

                        thisClient.Receive(buffer);

                        serverpath.incmessage = Encoding.Default.GetString(buffer);

                        serverpath.incmessage = serverpath.incmessage.Substring(0, serverpath.incmessage.IndexOf("\0"));
                        // size = Int32.Parse(serverpath.incmessage.Substring(0, 5));
                        msg = serverpath.incmessage;

                        // msg = serverpath.incmessage.Remove(0, 5);

                        using (StreamWriter writer = File.AppendText(username + "_" + filename))//writes text file from client to server text file
                        {
                            
                            
                            if (msg == "file_uploaded_code")
                            {
                                serverpath.upload_done = msg;

                            }
                            else
                                writer.WriteLine(msg);
                        }
                    }
                    

                }
                catch
                {
                    if(!terminating)
                    {
                        logs.AppendText("A client has disconnected\n");
                    }
                    thisClient.Close();
                    clientSockets.Remove(thisClient);
                    connected = false;
                }

                if(serverpath.upload_done == "file_uploaded_code")
                {
                    filename = "null";
                    serverpath.upload_done = "";
                }
                
            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void button_send_Click(object sender, EventArgs e)
        {

            
            string message = textBox_message.Text;
            if(message != "" && message.Length <= 64)
            {
                Byte[] buffer = Encoding.Default.GetBytes(message);
                foreach (Socket client in clientSockets)
                {
                    try
                    {
                        client.Send(buffer);
                    }
                    catch
                    {
                        logs.AppendText("There is a problem! Check the connection...\n");
                        terminating = true;
                        textBox_message.Enabled = false;
                        button_send.Enabled = false;
                        textBox_port.Enabled = true;
                        button_listen.Enabled = true;
                        serverSocket.Close();
                    }

                }
            }
        }
        
        private void file_Click_1(object sender, EventArgs e) //select work folder
        {
            folderBrowserDialog1.ShowDialog();
            serverpath.folderpath = folderBrowserDialog1.SelectedPath;
            string datpatho = serverpath.folderpath;
            Directory.SetCurrentDirectory(datpatho);
            serverpath.datapath = @datpatho;
            //Check if the file exists
            if (!File.Exists(serverpath.datapath))
            {
               
                using (StreamWriter writer = File.CreateText("database.txt"))
                {
                    writer.WriteLine("Users");
                }
            }
            string p_path = Path.Combine(serverpath.folderpath, "Public");
             
            if (!Directory.Exists(p_path))
            {
                Directory.CreateDirectory(p_path);
                serverpath.publicpath = p_path;
            }
            else if (Directory.Exists(p_path))
            {
                serverpath.publicpath = p_path;
                logs.AppendText("Public folder already exists!\n");
            }
            else
            {
                serverpath.publicpath = p_path;
                logs.AppendText("Error occured while setting a public folder!\n");
            }
        }
       
    }
    
}
