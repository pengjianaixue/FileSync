namespace FileSync
{
    partial class UserConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserConfig));
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_passWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_localFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_remoteFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_hostNameMode = new System.Windows.Forms.CheckBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_openFolder = new System.Windows.Forms.Button();
            this.button_Apply = new System.Windows.Forms.Button();
            this.textBox_serverAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.localFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox_fileFilter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_userName
            // 
            this.textBox_userName.Location = new System.Drawing.Point(132, 50);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(250, 20);
            this.textBox_userName.TabIndex = 0;
            this.textBox_userName.TextChanged += new System.EventHandler(this.textBox_userName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserName";
            // 
            // textBox_passWord
            // 
            this.textBox_passWord.Location = new System.Drawing.Point(132, 88);
            this.textBox_passWord.Name = "textBox_passWord";
            this.textBox_passWord.Size = new System.Drawing.Size(250, 20);
            this.textBox_passWord.TabIndex = 0;
            this.textBox_passWord.TextChanged += new System.EventHandler(this.textBox_passWord_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // textBox_localFolder
            // 
            this.textBox_localFolder.Location = new System.Drawing.Point(132, 126);
            this.textBox_localFolder.Name = "textBox_localFolder";
            this.textBox_localFolder.Size = new System.Drawing.Size(370, 20);
            this.textBox_localFolder.TabIndex = 0;
            this.textBox_localFolder.TextChanged += new System.EventHandler(this.textBox_localFolder_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Loacl Base Folder";
            // 
            // textBox_remoteFolder
            // 
            this.textBox_remoteFolder.Location = new System.Drawing.Point(132, 199);
            this.textBox_remoteFolder.Name = "textBox_remoteFolder";
            this.textBox_remoteFolder.Size = new System.Drawing.Size(370, 20);
            this.textBox_remoteFolder.TabIndex = 0;
            this.textBox_remoteFolder.TextChanged += new System.EventHandler(this.textBox_remoteFolder_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Remote Base Folder";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox_hostNameMode);
            this.panel1.Controls.Add(this.button_Cancel);
            this.panel1.Controls.Add(this.button_openFolder);
            this.panel1.Controls.Add(this.button_Apply);
            this.panel1.Controls.Add(this.textBox_passWord);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox_serverAddress);
            this.panel1.Controls.Add(this.textBox_userName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox_localFolder);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_fileFilter);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox_remoteFolder);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 296);
            this.panel1.TabIndex = 2;
            // 
            // checkBox_hostNameMode
            // 
            this.checkBox_hostNameMode.AutoSize = true;
            this.checkBox_hostNameMode.Location = new System.Drawing.Point(389, 16);
            this.checkBox_hostNameMode.Name = "checkBox_hostNameMode";
            this.checkBox_hostNameMode.Size = new System.Drawing.Size(117, 17);
            this.checkBox_hostNameMode.TabIndex = 3;
            this.checkBox_hostNameMode.Text = "Is HostName Mode";
            this.checkBox_hostNameMode.UseVisualStyleBackColor = true;
            this.checkBox_hostNameMode.CheckedChanged += new System.EventHandler(this.checkBox_hostNameMode_CheckedChanged);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(533, 268);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 25);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_openFolder
            // 
            this.button_openFolder.Location = new System.Drawing.Point(508, 126);
            this.button_openFolder.Name = "button_openFolder";
            this.button_openFolder.Size = new System.Drawing.Size(100, 25);
            this.button_openFolder.TabIndex = 2;
            this.button_openFolder.Text = "Open Folder";
            this.button_openFolder.UseVisualStyleBackColor = true;
            this.button_openFolder.Click += new System.EventHandler(this.button_openFolder_Click);
            // 
            // button_Apply
            // 
            this.button_Apply.Location = new System.Drawing.Point(452, 268);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(75, 25);
            this.button_Apply.TabIndex = 2;
            this.button_Apply.Text = "Apply";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // textBox_serverAddress
            // 
            this.textBox_serverAddress.Location = new System.Drawing.Point(132, 12);
            this.textBox_serverAddress.Name = "textBox_serverAddress";
            this.textBox_serverAddress.Size = new System.Drawing.Size(250, 20);
            this.textBox_serverAddress.TabIndex = 0;
            this.textBox_serverAddress.TextChanged += new System.EventHandler(this.textBox_serverAddress_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Server Address";
            // 
            // localFolderBrowserDialog
            // 
            this.localFolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // textBox_fileFilter
            // 
            this.textBox_fileFilter.AutoCompleteCustomSource.AddRange(new string[] {
            ".text",
            ".cc",
            ".cpp",
            ".h",
            ".cs",
            ";"});
            this.textBox_fileFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox_fileFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_fileFilter.Location = new System.Drawing.Point(132, 163);
            this.textBox_fileFilter.Name = "textBox_fileFilter";
            this.textBox_fileFilter.Size = new System.Drawing.Size(370, 20);
            this.textBox_fileFilter.TabIndex = 0;
            this.textBox_fileFilter.TextChanged += new System.EventHandler(this.textBox_fileFilter_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "File Filter";
            // 
            // UserConfig
            // 
            this.AcceptButton = this.button_Apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(638, 317);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserConfig";
            this.Text = "UserConfig";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_openFolder;
        public System.Windows.Forms.TextBox textBox_serverAddress;
        public System.Windows.Forms.TextBox textBox_userName;
        public System.Windows.Forms.TextBox textBox_passWord;
        public System.Windows.Forms.TextBox textBox_localFolder;
        public System.Windows.Forms.TextBox textBox_remoteFolder;
        private System.Windows.Forms.FolderBrowserDialog localFolderBrowserDialog;
        private System.Windows.Forms.CheckBox checkBox_hostNameMode;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBox_fileFilter;
    }
}