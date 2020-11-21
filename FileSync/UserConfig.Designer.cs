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
            this.components = new System.ComponentModel.Container();
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
            this.comboBox_Configuration = new System.Windows.Forms.ComboBox();
            this.checkBox_hostNameMode = new System.Windows.Forms.CheckBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_openFolder = new System.Windows.Forms.Button();
            this.button_Apply = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_serverAddress = new System.Windows.Forms.TextBox();
            this.textBox_fileFilter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.localFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_userName
            // 
            this.textBox_userName.Location = new System.Drawing.Point(140, 91);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(250, 21);
            this.textBox_userName.TabIndex = 0;
            this.textBox_userName.TextChanged += new System.EventHandler(this.textBox_userName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "UserName";
            // 
            // textBox_passWord
            // 
            this.textBox_passWord.Location = new System.Drawing.Point(140, 126);
            this.textBox_passWord.Name = "textBox_passWord";
            this.textBox_passWord.PasswordChar = '*';
            this.textBox_passWord.Size = new System.Drawing.Size(250, 21);
            this.textBox_passWord.TabIndex = 0;
            this.textBox_passWord.TextChanged += new System.EventHandler(this.textBox_passWord_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // textBox_localFolder
            // 
            this.textBox_localFolder.Location = new System.Drawing.Point(140, 161);
            this.textBox_localFolder.Name = "textBox_localFolder";
            this.textBox_localFolder.Size = new System.Drawing.Size(370, 21);
            this.textBox_localFolder.TabIndex = 0;
            this.textBox_localFolder.TextChanged += new System.EventHandler(this.textBox_localFolder_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Loacl Base Folder";
            // 
            // textBox_remoteFolder
            // 
            this.textBox_remoteFolder.Location = new System.Drawing.Point(140, 229);
            this.textBox_remoteFolder.Name = "textBox_remoteFolder";
            this.textBox_remoteFolder.Size = new System.Drawing.Size(370, 21);
            this.textBox_remoteFolder.TabIndex = 0;
            this.textBox_remoteFolder.TextChanged += new System.EventHandler(this.textBox_remoteFolder_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Remote Base Folder";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox_Configuration);
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
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox_remoteFolder);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 351);
            this.panel1.TabIndex = 2;
            // 
            // comboBox_Configuration
            // 
            this.comboBox_Configuration.FormattingEnabled = true;
            this.comboBox_Configuration.Location = new System.Drawing.Point(140, 30);
            this.comboBox_Configuration.Name = "comboBox_Configuration";
            this.comboBox_Configuration.Size = new System.Drawing.Size(250, 20);
            this.comboBox_Configuration.TabIndex = 4;
            this.comboBox_Configuration.SelectedIndexChanged += new System.EventHandler(this.comboBox_Configuration_SelectedIndexChanged);
            // 
            // checkBox_hostNameMode
            // 
            this.checkBox_hostNameMode.AutoSize = true;
            this.checkBox_hostNameMode.Location = new System.Drawing.Point(397, 60);
            this.checkBox_hostNameMode.Name = "checkBox_hostNameMode";
            this.checkBox_hostNameMode.Size = new System.Drawing.Size(120, 16);
            this.checkBox_hostNameMode.TabIndex = 3;
            this.checkBox_hostNameMode.Text = "Is HostName Mode";
            this.checkBox_hostNameMode.UseVisualStyleBackColor = true;
            this.checkBox_hostNameMode.CheckedChanged += new System.EventHandler(this.checkBox_hostNameMode_CheckedChanged);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(680, 316);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_openFolder
            // 
            this.button_openFolder.Location = new System.Drawing.Point(516, 161);
            this.button_openFolder.Name = "button_openFolder";
            this.button_openFolder.Size = new System.Drawing.Size(100, 23);
            this.button_openFolder.TabIndex = 2;
            this.button_openFolder.Text = "Open Folder";
            this.button_openFolder.UseVisualStyleBackColor = true;
            this.button_openFolder.Click += new System.EventHandler(this.button_openFolder_Click);
            // 
            // button_Apply
            // 
            this.button_Apply.Location = new System.Drawing.Point(580, 316);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(75, 23);
            this.button_Apply.TabIndex = 2;
            this.button_Apply.Text = "Apply";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "File Filter";
            // 
            // textBox_serverAddress
            // 
            this.textBox_serverAddress.Location = new System.Drawing.Point(140, 56);
            this.textBox_serverAddress.Name = "textBox_serverAddress";
            this.textBox_serverAddress.Size = new System.Drawing.Size(250, 21);
            this.textBox_serverAddress.TabIndex = 0;
            this.textBox_serverAddress.TextChanged += new System.EventHandler(this.textBox_serverAddress_TextChanged);
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
            this.textBox_fileFilter.Location = new System.Drawing.Point(140, 195);
            this.textBox_fileFilter.Name = "textBox_fileFilter";
            this.textBox_fileFilter.Size = new System.Drawing.Size(370, 21);
            this.textBox_fileFilter.TabIndex = 0;
            this.textBox_fileFilter.TextChanged += new System.EventHandler(this.textBox_fileFilter_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "Configuration";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "Server Address";
            // 
            // localFolderBrowserDialog
            // 
            this.localFolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // mainFormBindingSource
            // 
            this.mainFormBindingSource.DataSource = typeof(FileSync.MainForm);
            // 
            // UserConfig
            // 
            this.AcceptButton = this.button_Apply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(767, 351);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserConfig";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_Configuration;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
    }
}