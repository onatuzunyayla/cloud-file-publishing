//C# Program for Client 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    
    public partial class Form1 : Form
    {
        //Class for client path objects 
        class clientpath
        {
            public static string filepath; 
            public static string incmessage;
            public static string username;
            public static string folderpath;
            public static string datapath;
            public static string download_done = "";
            public static bool downloading = false;
            public static string req_filename = "";
            
        }
        bool terminating = false;
        bool connected = false;
        Socket clientSocket;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            InitializeComponent();
        }

        private void button_connect_Click(object sender, EventArgs e) //Function to connect to the server
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //Creating new client socket
            string IP = textBox_ip.Text; //Getting IP address

            int portNum;
            if(Int32.TryParse(textBox_port.Text, out portNum)) //Looks if requirements to connect to the server are met
            {
                try
                {
                    clientSocket.Connect(IP, portNum); //Connecting with IP and port number
                    button_connect.Enabled = false;
                    
                   
                    connected = true;
                    logs.AppendText("Connected to the server!\n"); //Displays message if connected successfully to the server

                    Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();
                    clientpath.username = textBox1.Text;

                    button_disconnect.Enabled = true;
                    button_copy.Enabled = true;
                    button_delete.Enabled = true;
                    button_download.Enabled = true;
                    button_request_list.Enabled = true;
                    button1.Enabled = true;
                    checkBox_public.Enabled = true;
                    checkBox_private.Enabled = true;
                    button_loadpublic.Enabled = true;
                    button_public.Enabled = true;
                    selectpath.Enabled = true;

                }
                catch
                {
                    logs.AppendText("Could not connect to the server!\n"); //Displays warning message if connection isn't successful
                }
                if (clientpath.username != "" && clientpath.username.Length <= 64) //Gets username if it is appropriate
                {
                    Byte[] buffer = new Byte[64];
                    buffer = Encoding.Default.GetBytes(clientpath.username);
                    clientSocket.Send(buffer);
                }
            }
            else //Displays warning if requirements are not met
            {
                logs.AppendText("Check the port\n");
            }

        }

        private void Receive() //Function to receive file
        {
            while(connected)
            {
                try //Receives file
                {
                    if (clientpath.downloading == true && clientpath.req_filename != "")
                    {
                        try
                        {
                            string msg;
                            Byte[] buffer = new Byte[1024];
                            clientSocket.Receive(buffer);
                            clientpath.incmessage = Encoding.Default.GetString(buffer);

                            clientpath.incmessage = clientpath.incmessage.Substring(0, clientpath.incmessage.IndexOf("\0"));
                            // size = Int32.Parse(serverpath.incmessage.Substring(0, 5));
                            msg = clientpath.incmessage;

                            using (StreamWriter writer = File.AppendText(clientpath.req_filename + ".txt"))//writes text file from client to server text file
                            {


                                if (msg == "file_uploaded_code")
                                {
                                   
                                    clientpath.downloading = false;
                                    clientpath.req_filename = "";

                                }
                                else
                                    writer.WriteLine(msg);
                            }

                        }
                        catch
                        {
                            clientpath.downloading = false;
                            clientpath.req_filename = "";
                        }
                        
                        

                    }
                    else
                    {
                        Byte[] buffer = new Byte[1024];
                        clientSocket.Receive(buffer);

                        clientpath.incmessage = Encoding.Default.GetString(buffer);
                        clientpath.incmessage = clientpath.incmessage.Substring(0, clientpath.incmessage.IndexOf("\0"));

                        logs.AppendText("Server: " + clientpath.incmessage + "\n");
                        if (clientpath.incmessage != "" && clientpath.incmessage == "Name already exists")
                        {
                            connected = false;
                        }
                    }
                    
                }
                catch
                {
                    if (!terminating)
                    {
                        logs.AppendText("The server has disconnected\n"); //Gives warning message if disconnected
                        button_connect.Enabled = true;
                        button_disconnect.Enabled = false;
                     
                    }

                    clientSocket.Close();
                    connected = false;
                }

            }
        }

        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e) //Terminates program if disconnected
        {
            connected = false;
            terminating = true;
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e) //Function to prompt dialog
        {
            openFileDialog1.ShowDialog();
            clientpath.filepath= openFileDialog1.FileName;
            button2.Enabled = true;
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
             
            string filename = Path.GetFileName(clientpath.filepath);
            
            Byte[] filen = new Byte[filename.Length];
            filen = Encoding.Default.GetBytes(filename);
            clientSocket.Send(filen);
            Thread.Sleep(1);
            Array.Clear(filen, 0, filen.Length);
            string message;
            System.IO.StreamReader file = new System.IO.StreamReader(@clientpath.filepath);
            Stream fileStream = File.OpenRead(@clientpath.filepath);
            
            Byte[] buffer = new Byte[fileStream.Length];
            string[] lines = File.ReadAllLines(@clientpath.filepath);
            foreach (string line in lines)
            {
                message = line;
                buffer = Encoding.Default.GetBytes(message);
                clientSocket.Send(buffer);
                Thread.Sleep(1);
                Array.Clear(buffer, 0, buffer.Length);

            }

            message = "file_uploaded_code";
            buffer = Encoding.Default.GetBytes(message);
            clientSocket.Send(buffer);
            button2.Enabled = false;
        }

        private void button_request_list_Click(object sender, EventArgs e)
        {
            

            if(checkBox_private.Checked == true)
            {
                string req_msg = "get_file_list";
                Byte[] buffer = new Byte[req_msg.Length];
                buffer = Encoding.Default.GetBytes(req_msg);
                clientSocket.Send(buffer);
                
            }
            else if (checkBox_public.Checked == true)
            {
                string req_msg = "public_get_file_list";
                Byte[] buffer = new Byte[req_msg.Length];
                buffer = Encoding.Default.GetBytes(req_msg);
                clientSocket.Send(buffer);
                
            }

            else if(checkBox_public.Checked == true && checkBox_private.Checked == true)
            {
                logs.AppendText("Specify file type first!\n");
            }
            else
            {
                logs.AppendText("An unknown error occured!\n");
            }
           




        }

        private void button_download_Click(object sender, EventArgs e)
        {
            string req_filename = textBox_getfile.Text;
            logs.AppendText("You request: " + req_filename + "\n");
            // send request code
            string req_msg = "download_file%" + req_filename;
            Byte[] buffer = new Byte[req_msg.Length];
            buffer = Encoding.Default.GetBytes(req_msg);
            clientSocket.Send(buffer);
           

            clientpath.downloading = true;
            clientpath.req_filename = textBox_getfile.Text; 
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string req_filename = textBox_editfile.Text;
            logs.AppendText("You request: " + req_filename + "\n");
            // send request code
            string req_msg = "delete_file%" + req_filename;
            Byte[] buffer = new Byte[req_msg.Length];
            buffer = Encoding.Default.GetBytes(req_msg);
            clientSocket.Send(buffer);
        }

        private void button_copy_Click(object sender, EventArgs e)
        {
            string req_filename = textBox_editfile.Text;
            logs.AppendText("You request: " + req_filename + "\n");
            // send request code
            string req_msg = "copy_file%" + req_filename;
            Byte[] buffer = new Byte[req_msg.Length];
            buffer = Encoding.Default.GetBytes(req_msg);
            clientSocket.Send(buffer);
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            clientSocket.Close();
            connected = false;

        }
        
        private void button_public_Click(object sender, EventArgs e)
        {
            string req_filename = textBox_editfile.Text;
            logs.AppendText("You request: " + req_filename + "\n");
            // send request code
            string req_msg = "pub_file%" + req_filename;
            Byte[] buffer = new Byte[req_msg.Length];
            buffer = Encoding.Default.GetBytes(req_msg);
            clientSocket.Send(buffer);

            
        }

        private void checkBox_public_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox_private.Enabled = !checkBox_public.Checked;
        }

        private void checkBox_private_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox_public.Enabled = !checkBox_private.Checked;
        }

        private void button_loadpublic_Click(object sender, EventArgs e)
        {

            string req_filename = textBox_getfile.Text;
            logs.AppendText("You request: " + req_filename + "\n");
            // send request code
            string req_msg = "public_down_file%" + req_filename;
            Byte[] buffer = new Byte[req_msg.Length];
            buffer = Encoding.Default.GetBytes(req_msg);
            clientSocket.Send(buffer);

            clientpath.downloading = true;
            clientpath.req_filename = textBox_getfile.Text;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            clientpath.folderpath = folderBrowserDialog1.SelectedPath;
            string datpatho = clientpath.folderpath;
            Directory.SetCurrentDirectory(datpatho);
            clientpath.datapath = @datpatho;
        }

        private void button_copypublic_Click(object sender, EventArgs e)
        {
            string req_filename = textBox_editfile.Text;
            logs.AppendText("You request: " + req_filename + "\n");
            // send request code
            string req_msg = "public_copy%" + req_filename;
            Byte[] buffer = new Byte[req_msg.Length];
            buffer = Encoding.Default.GetBytes(req_msg);
            clientSocket.Send(buffer);
        }

        private void button_deletepublic_Click(object sender, EventArgs e)
        {

            string req_filename = textBox_editfile.Text;
            logs.AppendText("You request: " + req_filename + "\n");
            // send request code
            string req_msg = "public_delete%" + req_filename;
            Byte[] buffer = new Byte[req_msg.Length];
            buffer = Encoding.Default.GetBytes(req_msg);
            clientSocket.Send(buffer);

            clientpath.downloading = true;
            clientpath.req_filename = textBox_getfile.Text;

        }
    }
}
