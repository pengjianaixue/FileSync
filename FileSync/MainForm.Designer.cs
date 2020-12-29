namespace FileSync
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realTimeSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitChangedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon_background = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_backgroud = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip_infoBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.FileChangeGridView = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpLoad = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Downlaod = new System.Windows.Forms.DataGridViewButtonColumn();
            this.igroneThisTime = new System.Windows.Forms.DataGridViewButtonColumn();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip_backgroud.SuspendLayout();
            this.statusStrip_infoBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileChangeGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.syncFolderToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.gitChangedToolStripMenuItem,
            this.realTimeSyncToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            resources.ApplyResources(this.configToolStripMenuItem, "configToolStripMenuItem");
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // syncFolderToolStripMenuItem
            // 
            this.syncFolderToolStripMenuItem.Name = "syncFolderToolStripMenuItem";
            resources.ApplyResources(this.syncFolderToolStripMenuItem, "syncFolderToolStripMenuItem");
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resources.ApplyResources(this.resetToolStripMenuItem, "resetToolStripMenuItem");
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            resources.ApplyResources(this.pauseToolStripMenuItem, "pauseToolStripMenuItem");
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // realTimeSyncToolStripMenuItem
            // 
            this.realTimeSyncToolStripMenuItem.Name = "realTimeSyncToolStripMenuItem";
            resources.ApplyResources(this.realTimeSyncToolStripMenuItem, "realTimeSyncToolStripMenuItem");
            this.realTimeSyncToolStripMenuItem.Click += new System.EventHandler(this.UplaodAllToolStripMenuItem_Click);
            // 
            // gitChangedToolStripMenuItem
            // 
            this.gitChangedToolStripMenuItem.Name = "gitChangedToolStripMenuItem";
            resources.ApplyResources(this.gitChangedToolStripMenuItem, "gitChangedToolStripMenuItem");
            this.gitChangedToolStripMenuItem.Click += new System.EventHandler(this.gitChangedToolStripMenuItem_Click);
            // 
            // notifyIcon_background
            // 
            this.notifyIcon_background.ContextMenuStrip = this.contextMenuStrip_backgroud;
            resources.ApplyResources(this.notifyIcon_background, "notifyIcon_background");
            this.notifyIcon_background.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_background_MouseClick);
            // 
            // contextMenuStrip_backgroud
            // 
            this.contextMenuStrip_backgroud.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip_backgroud.Name = "contextMenuStrip_backgroud";
            resources.ApplyResources(this.contextMenuStrip_backgroud, "contextMenuStrip_backgroud");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip_infoBar
            // 
            this.statusStrip_infoBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_status});
            resources.ApplyResources(this.statusStrip_infoBar, "statusStrip_infoBar");
            this.statusStrip_infoBar.Name = "statusStrip_infoBar";
            // 
            // toolStripStatusLabel_status
            // 
            this.toolStripStatusLabel_status.Name = "toolStripStatusLabel_status";
            resources.ApplyResources(this.toolStripStatusLabel_status, "toolStripStatusLabel_status");
            // 
            // FileChangeGridView
            // 
            this.FileChangeGridView.AllowUserToAddRows = false;
            this.FileChangeGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FileChangeGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FileChangeGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FileChangeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileChangeGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.ChangeTime,
            this.ChangeType,
            this.UpLoad,
            this.Downlaod,
            this.igroneThisTime});
            resources.ApplyResources(this.FileChangeGridView, "FileChangeGridView");
            this.FileChangeGridView.Name = "FileChangeGridView";
            this.FileChangeGridView.RowTemplate.Height = 35;
            this.FileChangeGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FileChangeGridView_CellContentClick);
            // 
            // FileName
            // 
            this.FileName.FillWeight = 21.16487F;
            resources.ApplyResources(this.FileName, "FileName");
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // ChangeTime
            // 
            this.ChangeTime.FillWeight = 21.16487F;
            resources.ApplyResources(this.ChangeTime, "ChangeTime");
            this.ChangeTime.Name = "ChangeTime";
            this.ChangeTime.ReadOnly = true;
            // 
            // ChangeType
            // 
            this.ChangeType.FillWeight = 21.16487F;
            resources.ApplyResources(this.ChangeType, "ChangeType");
            this.ChangeType.Name = "ChangeType";
            this.ChangeType.ReadOnly = true;
            // 
            // UpLoad
            // 
            this.UpLoad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            resources.ApplyResources(this.UpLoad, "UpLoad");
            this.UpLoad.Name = "UpLoad";
            this.UpLoad.Text = "UpLoad";
            this.UpLoad.UseColumnTextForButtonValue = true;
            // 
            // Downlaod
            // 
            this.Downlaod.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            resources.ApplyResources(this.Downlaod, "Downlaod");
            this.Downlaod.Name = "Downlaod";
            this.Downlaod.Text = "Downlaod";
            this.Downlaod.UseColumnTextForButtonValue = true;
            // 
            // igroneThisTime
            // 
            this.igroneThisTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            resources.ApplyResources(this.igroneThisTime, "igroneThisTime");
            this.igroneThisTime.Name = "igroneThisTime";
            this.igroneThisTime.Text = "Ignore";
            this.igroneThisTime.UseColumnTextForButtonValue = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.FileChangeGridView);
            this.Controls.Add(this.statusStrip_infoBar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip_backgroud.ResumeLayout(false);
            this.statusStrip_infoBar.ResumeLayout(false);
            this.statusStrip_infoBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileChangeGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncFolderToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon_background;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_backgroud;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip_infoBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_status;
        private System.Windows.Forms.DataGridView FileChangeGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangeType;
        private System.Windows.Forms.DataGridViewButtonColumn UpLoad;
        private System.Windows.Forms.DataGridViewButtonColumn Downlaod;
        private System.Windows.Forms.DataGridViewButtonColumn igroneThisTime;
        private System.Windows.Forms.ToolStripMenuItem realTimeSyncToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitChangedToolStripMenuItem;
    }
}

