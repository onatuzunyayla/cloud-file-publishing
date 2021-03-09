namespace client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_request_list = new System.Windows.Forms.Button();
            this.button_download = new System.Windows.Forms.Button();
            this.textBox_getfile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_copy = new System.Windows.Forms.Button();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.button_public = new System.Windows.Forms.Button();
            this.checkBox_public = new System.Windows.Forms.CheckBox();
            this.checkBox_private = new System.Windows.Forms.CheckBox();
            this.groupBox_Request = new System.Windows.Forms.GroupBox();
            this.groupBox_selectsend = new System.Windows.Forms.GroupBox();
            this.button_loadpublic = new System.Windows.Forms.Button();
            this.groupBox_download = new System.Windows.Forms.GroupBox();
            this.selectpath = new System.Windows.Forms.Button();
            this.groupBox_edit = new System.Windows.Forms.GroupBox();
            this.button_copypublic = new System.Windows.Forms.Button();
            this.button_deletepublic = new System.Windows.Forms.Button();
            this.textBox_editfile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox_connect = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox_Request.SuspendLayout();
            this.groupBox_selectsend.SuspendLayout();
            this.groupBox_download.SuspendLayout();
            this.groupBox_edit.SuspendLayout();
            this.groupBox_connect.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(87, 30);
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(173, 22);
            this.textBox_ip.TabIndex = 2;
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(87, 60);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(173, 22);
            this.textBox_port.TabIndex = 3;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(36, 121);
            this.button_connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(93, 27);
            this.button_connect.TabIndex = 4;
            this.button_connect.Text = "connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(296, 11);
            this.logs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(284, 175);
            this.logs.TabIndex = 5;
            this.logs.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 86);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 22);
            this.textBox1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(36, 30);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "select file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(36, 65);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 10;
            this.button2.Text = "send file";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button_request_list
            // 
            this.button_request_list.Enabled = false;
            this.button_request_list.Location = new System.Drawing.Point(24, 68);
            this.button_request_list.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_request_list.Name = "button_request_list";
            this.button_request_list.Size = new System.Drawing.Size(133, 23);
            this.button_request_list.TabIndex = 11;
            this.button_request_list.Text = "Request File List";
            this.button_request_list.UseVisualStyleBackColor = true;
            this.button_request_list.Click += new System.EventHandler(this.button_request_list_Click);
            // 
            // button_download
            // 
            this.button_download.Enabled = false;
            this.button_download.Location = new System.Drawing.Point(107, 57);
            this.button_download.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_download.Name = "button_download";
            this.button_download.Size = new System.Drawing.Size(115, 23);
            this.button_download.TabIndex = 12;
            this.button_download.Text = "Download File";
            this.button_download.UseVisualStyleBackColor = true;
            this.button_download.Click += new System.EventHandler(this.button_download_Click);
            // 
            // textBox_getfile
            // 
            this.textBox_getfile.Location = new System.Drawing.Point(107, 28);
            this.textBox_getfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_getfile.Name = "textBox_getfile";
            this.textBox_getfile.Size = new System.Drawing.Size(263, 22);
            this.textBox_getfile.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "File Name:";
            // 
            // button_delete
            // 
            this.button_delete.Enabled = false;
            this.button_delete.Location = new System.Drawing.Point(159, 47);
            this.button_delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(108, 30);
            this.button_delete.TabIndex = 15;
            this.button_delete.Text = "Delete File";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_copy
            // 
            this.button_copy.Enabled = false;
            this.button_copy.Location = new System.Drawing.Point(273, 47);
            this.button_copy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(86, 30);
            this.button_copy.TabIndex = 16;
            this.button_copy.Text = "Copy";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // button_disconnect
            // 
            this.button_disconnect.Enabled = false;
            this.button_disconnect.Location = new System.Drawing.Point(159, 121);
            this.button_disconnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(91, 27);
            this.button_disconnect.TabIndex = 17;
            this.button_disconnect.Text = "disconnect";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // button_public
            // 
            this.button_public.Enabled = false;
            this.button_public.Location = new System.Drawing.Point(30, 47);
            this.button_public.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_public.Name = "button_public";
            this.button_public.Size = new System.Drawing.Size(107, 30);
            this.button_public.TabIndex = 18;
            this.button_public.Text = "Make Public";
            this.button_public.UseVisualStyleBackColor = true;
            this.button_public.Click += new System.EventHandler(this.button_public_Click);
            // 
            // checkBox_public
            // 
            this.checkBox_public.AutoSize = true;
            this.checkBox_public.Enabled = false;
            this.checkBox_public.Location = new System.Drawing.Point(125, 26);
            this.checkBox_public.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_public.Name = "checkBox_public";
            this.checkBox_public.Size = new System.Drawing.Size(68, 21);
            this.checkBox_public.TabIndex = 19;
            this.checkBox_public.Text = "Public";
            this.checkBox_public.UseVisualStyleBackColor = true;
            this.checkBox_public.CheckedChanged += new System.EventHandler(this.checkBox_public_CheckedChanged);
            // 
            // checkBox_private
            // 
            this.checkBox_private.AutoSize = true;
            this.checkBox_private.Enabled = false;
            this.checkBox_private.Location = new System.Drawing.Point(5, 26);
            this.checkBox_private.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_private.Name = "checkBox_private";
            this.checkBox_private.Size = new System.Drawing.Size(74, 21);
            this.checkBox_private.TabIndex = 20;
            this.checkBox_private.Text = "Private";
            this.checkBox_private.UseVisualStyleBackColor = true;
            this.checkBox_private.CheckedChanged += new System.EventHandler(this.checkBox_private_CheckedChanged);
            // 
            // groupBox_Request
            // 
            this.groupBox_Request.Controls.Add(this.button_request_list);
            this.groupBox_Request.Controls.Add(this.checkBox_public);
            this.groupBox_Request.Controls.Add(this.checkBox_private);
            this.groupBox_Request.Location = new System.Drawing.Point(12, 313);
            this.groupBox_Request.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Request.Name = "groupBox_Request";
            this.groupBox_Request.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Request.Size = new System.Drawing.Size(200, 116);
            this.groupBox_Request.TabIndex = 21;
            this.groupBox_Request.TabStop = false;
            this.groupBox_Request.Text = "Request File";
            // 
            // groupBox_selectsend
            // 
            this.groupBox_selectsend.Controls.Add(this.button1);
            this.groupBox_selectsend.Controls.Add(this.button2);
            this.groupBox_selectsend.Location = new System.Drawing.Point(12, 192);
            this.groupBox_selectsend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_selectsend.Name = "groupBox_selectsend";
            this.groupBox_selectsend.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_selectsend.Size = new System.Drawing.Size(200, 114);
            this.groupBox_selectsend.TabIndex = 22;
            this.groupBox_selectsend.TabStop = false;
            this.groupBox_selectsend.Text = "Select / Send File";
            // 
            // button_loadpublic
            // 
            this.button_loadpublic.Enabled = false;
            this.button_loadpublic.Location = new System.Drawing.Point(227, 57);
            this.button_loadpublic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_loadpublic.Name = "button_loadpublic";
            this.button_loadpublic.Size = new System.Drawing.Size(143, 23);
            this.button_loadpublic.TabIndex = 23;
            this.button_loadpublic.Text = "Download (Public)";
            this.button_loadpublic.UseVisualStyleBackColor = true;
            this.button_loadpublic.Click += new System.EventHandler(this.button_loadpublic_Click);
            // 
            // groupBox_download
            // 
            this.groupBox_download.Controls.Add(this.selectpath);
            this.groupBox_download.Controls.Add(this.label4);
            this.groupBox_download.Controls.Add(this.button_loadpublic);
            this.groupBox_download.Controls.Add(this.textBox_getfile);
            this.groupBox_download.Controls.Add(this.button_download);
            this.groupBox_download.Location = new System.Drawing.Point(219, 192);
            this.groupBox_download.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_download.Name = "groupBox_download";
            this.groupBox_download.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_download.Size = new System.Drawing.Size(377, 114);
            this.groupBox_download.TabIndex = 24;
            this.groupBox_download.TabStop = false;
            this.groupBox_download.Text = "Download(All / Public)";
            // 
            // selectpath
            // 
            this.selectpath.Location = new System.Drawing.Point(105, 86);
            this.selectpath.Margin = new System.Windows.Forms.Padding(4);
            this.selectpath.Name = "selectpath";
            this.selectpath.Size = new System.Drawing.Size(115, 22);
            this.selectpath.TabIndex = 24;
            this.selectpath.Text = "Browse";
            this.selectpath.UseVisualStyleBackColor = true;
            this.selectpath.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // groupBox_edit
            // 
            this.groupBox_edit.Controls.Add(this.button_copypublic);
            this.groupBox_edit.Controls.Add(this.button_deletepublic);
            this.groupBox_edit.Controls.Add(this.textBox_editfile);
            this.groupBox_edit.Controls.Add(this.label5);
            this.groupBox_edit.Controls.Add(this.button_delete);
            this.groupBox_edit.Controls.Add(this.button_public);
            this.groupBox_edit.Controls.Add(this.button_copy);
            this.groupBox_edit.Location = new System.Drawing.Point(219, 313);
            this.groupBox_edit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_edit.Name = "groupBox_edit";
            this.groupBox_edit.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_edit.Size = new System.Drawing.Size(377, 116);
            this.groupBox_edit.TabIndex = 25;
            this.groupBox_edit.TabStop = false;
            this.groupBox_edit.Text = "Edit File";
            // 
            // button_copypublic
            // 
            this.button_copypublic.Location = new System.Drawing.Point(274, 88);
            this.button_copypublic.Name = "button_copypublic";
            this.button_copypublic.Size = new System.Drawing.Size(85, 23);
            this.button_copypublic.TabIndex = 23;
            this.button_copypublic.Text = "Copy(P)";
            this.button_copypublic.UseVisualStyleBackColor = true;
            this.button_copypublic.Click += new System.EventHandler(this.button_copypublic_Click);
            // 
            // button_deletepublic
            // 
            this.button_deletepublic.Location = new System.Drawing.Point(159, 88);
            this.button_deletepublic.Name = "button_deletepublic";
            this.button_deletepublic.Size = new System.Drawing.Size(108, 23);
            this.button_deletepublic.TabIndex = 22;
            this.button_deletepublic.Text = "Delete(Public)";
            this.button_deletepublic.UseVisualStyleBackColor = true;
            this.button_deletepublic.Click += new System.EventHandler(this.button_deletepublic_Click);
            // 
            // textBox_editfile
            // 
            this.textBox_editfile.Location = new System.Drawing.Point(107, 21);
            this.textBox_editfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_editfile.Name = "textBox_editfile";
            this.textBox_editfile.Size = new System.Drawing.Size(263, 22);
            this.textBox_editfile.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "File Name:";
            // 
            // groupBox_connect
            // 
            this.groupBox_connect.Controls.Add(this.label1);
            this.groupBox_connect.Controls.Add(this.textBox_ip);
            this.groupBox_connect.Controls.Add(this.label2);
            this.groupBox_connect.Controls.Add(this.textBox_port);
            this.groupBox_connect.Controls.Add(this.label3);
            this.groupBox_connect.Controls.Add(this.button_disconnect);
            this.groupBox_connect.Controls.Add(this.textBox1);
            this.groupBox_connect.Controls.Add(this.button_connect);
            this.groupBox_connect.Location = new System.Drawing.Point(12, 7);
            this.groupBox_connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_connect.Name = "groupBox_connect";
            this.groupBox_connect.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_connect.Size = new System.Drawing.Size(277, 178);
            this.groupBox_connect.TabIndex = 26;
            this.groupBox_connect.TabStop = false;
            this.groupBox_connect.Text = "Connection";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 441);
            this.Controls.Add(this.groupBox_connect);
            this.Controls.Add(this.groupBox_edit);
            this.Controls.Add(this.groupBox_download);
            this.Controls.Add(this.groupBox_selectsend);
            this.Controls.Add(this.groupBox_Request);
            this.Controls.Add(this.logs);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox_Request.ResumeLayout(false);
            this.groupBox_Request.PerformLayout();
            this.groupBox_selectsend.ResumeLayout(false);
            this.groupBox_download.ResumeLayout(false);
            this.groupBox_download.PerformLayout();
            this.groupBox_edit.ResumeLayout(false);
            this.groupBox_edit.PerformLayout();
            this.groupBox_connect.ResumeLayout(false);
            this.groupBox_connect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_request_list;
        private System.Windows.Forms.Button button_download;
        private System.Windows.Forms.TextBox textBox_getfile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Button button_public;
        private System.Windows.Forms.CheckBox checkBox_public;
        private System.Windows.Forms.CheckBox checkBox_private;
        private System.Windows.Forms.GroupBox groupBox_Request;
        private System.Windows.Forms.GroupBox groupBox_selectsend;
        private System.Windows.Forms.Button button_loadpublic;
        private System.Windows.Forms.GroupBox groupBox_download;
        private System.Windows.Forms.GroupBox groupBox_edit;
        private System.Windows.Forms.TextBox textBox_editfile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox_connect;
        private System.Windows.Forms.Button selectpath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button_deletepublic;
        private System.Windows.Forms.Button button_copypublic;
    }
}

