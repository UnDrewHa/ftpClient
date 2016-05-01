namespace ftpClient {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.главнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПроектеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.какРаботатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblServerUrl = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserPass = new System.Windows.Forms.Label();
            this.tboxServerUrl = new System.Windows.Forms.TextBox();
            this.tboxUserName = new System.Windows.Forms.TextBox();
            this.tboxUserPass = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lvLocal = new System.Windows.Forms.ListView();
            this.cmsLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsLocalUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLocalRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLocalMove = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLocalDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLocalCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.lvRemote = new System.Windows.Forms.ListView();
            this.cmsRemote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsRemoteDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoteRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoteMove = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoteDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoteCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpLocal = new System.Windows.Forms.Button();
            this.btnUpRemote = new System.Windows.Forms.Button();
            this.lblLocalPath = new System.Windows.Forms.Label();
            this.lblRemotePath = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.mainMenu.SuspendLayout();
            this.cmsLocal.SuspendLayout();
            this.cmsRemote.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.главнаяToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(1054, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "Главное меню";
            // 
            // главнаяToolStripMenuItem
            // 
            this.главнаяToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.главнаяToolStripMenuItem.Name = "главнаяToolStripMenuItem";
            this.главнаяToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.главнаяToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПроектеToolStripMenuItem,
            this.какРаботатьToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // оПроектеToolStripMenuItem
            // 
            this.оПроектеToolStripMenuItem.Name = "оПроектеToolStripMenuItem";
            this.оПроектеToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.оПроектеToolStripMenuItem.Text = "О Проекте";
            // 
            // какРаботатьToolStripMenuItem
            // 
            this.какРаботатьToolStripMenuItem.Name = "какРаботатьToolStripMenuItem";
            this.какРаботатьToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.какРаботатьToolStripMenuItem.Text = "Как работать?";
            // 
            // lblServerUrl
            // 
            this.lblServerUrl.AutoSize = true;
            this.lblServerUrl.Location = new System.Drawing.Point(15, 42);
            this.lblServerUrl.Name = "lblServerUrl";
            this.lblServerUrl.Size = new System.Drawing.Size(59, 17);
            this.lblServerUrl.TabIndex = 1;
            this.lblServerUrl.Text = "Сервер:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(321, 42);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(103, 17);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Пользователь:";
            // 
            // lblUserPass
            // 
            this.lblUserPass.AutoSize = true;
            this.lblUserPass.Location = new System.Drawing.Point(623, 42);
            this.lblUserPass.Name = "lblUserPass";
            this.lblUserPass.Size = new System.Drawing.Size(60, 17);
            this.lblUserPass.TabIndex = 3;
            this.lblUserPass.Text = "Пароль:";
            // 
            // tboxServerUrl
            // 
            this.tboxServerUrl.Location = new System.Drawing.Point(80, 39);
            this.tboxServerUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tboxServerUrl.Name = "tboxServerUrl";
            this.tboxServerUrl.Size = new System.Drawing.Size(200, 24);
            this.tboxServerUrl.TabIndex = 4;
            this.tboxServerUrl.Text = "ftp://192.168.1.2";
            // 
            // tboxUserName
            // 
            this.tboxUserName.Location = new System.Drawing.Point(430, 39);
            this.tboxUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tboxUserName.Name = "tboxUserName";
            this.tboxUserName.Size = new System.Drawing.Size(150, 24);
            this.tboxUserName.TabIndex = 5;
            this.tboxUserName.Text = "anonymous";
            // 
            // tboxUserPass
            // 
            this.tboxUserPass.Location = new System.Drawing.Point(689, 39);
            this.tboxUserPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tboxUserPass.Name = "tboxUserPass";
            this.tboxUserPass.PasswordChar = '#';
            this.tboxUserPass.Size = new System.Drawing.Size(150, 24);
            this.tboxUserPass.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnConnect.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Location = new System.Drawing.Point(883, 36);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(154, 28);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Подключиться";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lvLocal
            // 
            this.lvLocal.ContextMenuStrip = this.cmsLocal;
            this.lvLocal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvLocal.Location = new System.Drawing.Point(18, 210);
            this.lvLocal.Name = "lvLocal";
            this.lvLocal.Size = new System.Drawing.Size(500, 450);
            this.lvLocal.TabIndex = 8;
            this.lvLocal.TileSize = new System.Drawing.Size(32, 32);
            this.lvLocal.UseCompatibleStateImageBehavior = false;
            this.lvLocal.View = System.Windows.Forms.View.SmallIcon;
            this.lvLocal.DoubleClick += new System.EventHandler(this.lvLocal_DoubleClick);
            // 
            // cmsLocal
            // 
            this.cmsLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsLocalUpload,
            this.cmsLocalRename,
            this.cmsLocalMove,
            this.cmsLocalDelete,
            this.cmsLocalCreateFolder});
            this.cmsLocal.Name = "cmsLocal";
            this.cmsLocal.Size = new System.Drawing.Size(162, 114);
            // 
            // cmsLocalUpload
            // 
            this.cmsLocalUpload.Name = "cmsLocalUpload";
            this.cmsLocalUpload.Size = new System.Drawing.Size(161, 22);
            this.cmsLocalUpload.Text = "На сервер ->";
            this.cmsLocalUpload.Click += new System.EventHandler(this.cmsLocalUpload_Click);
            // 
            // cmsLocalRename
            // 
            this.cmsLocalRename.Name = "cmsLocalRename";
            this.cmsLocalRename.Size = new System.Drawing.Size(161, 22);
            this.cmsLocalRename.Text = "Переименовать";
            this.cmsLocalRename.Click += new System.EventHandler(this.cmsLocalRename_Click);
            // 
            // cmsLocalMove
            // 
            this.cmsLocalMove.Name = "cmsLocalMove";
            this.cmsLocalMove.Size = new System.Drawing.Size(161, 22);
            this.cmsLocalMove.Text = "Переместить";
            this.cmsLocalMove.Click += new System.EventHandler(this.cmsLocalMove_Click);
            // 
            // cmsLocalDelete
            // 
            this.cmsLocalDelete.Name = "cmsLocalDelete";
            this.cmsLocalDelete.Size = new System.Drawing.Size(161, 22);
            this.cmsLocalDelete.Text = "Удалить";
            this.cmsLocalDelete.Click += new System.EventHandler(this.cmsLocalDelete_Click);
            // 
            // cmsLocalCreateFolder
            // 
            this.cmsLocalCreateFolder.Name = "cmsLocalCreateFolder";
            this.cmsLocalCreateFolder.Size = new System.Drawing.Size(161, 22);
            this.cmsLocalCreateFolder.Text = "Создать папку";
            this.cmsLocalCreateFolder.Click += new System.EventHandler(this.cmsLocalCreateFolder_Click);
            // 
            // lvRemote
            // 
            this.lvRemote.ContextMenuStrip = this.cmsRemote;
            this.lvRemote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvRemote.Location = new System.Drawing.Point(537, 210);
            this.lvRemote.Name = "lvRemote";
            this.lvRemote.Size = new System.Drawing.Size(500, 450);
            this.lvRemote.TabIndex = 9;
            this.lvRemote.TileSize = new System.Drawing.Size(32, 32);
            this.lvRemote.UseCompatibleStateImageBehavior = false;
            this.lvRemote.View = System.Windows.Forms.View.SmallIcon;
            this.lvRemote.DoubleClick += new System.EventHandler(this.lvRemote_DoubleClick);
            // 
            // cmsRemote
            // 
            this.cmsRemote.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRemoteDownload,
            this.cmsRemoteRename,
            this.cmsRemoteMove,
            this.cmsRemoteDelete,
            this.cmsRemoteCreateFolder});
            this.cmsRemote.Name = "cmsRemote";
            this.cmsRemote.Size = new System.Drawing.Size(162, 114);
            // 
            // cmsRemoteDownload
            // 
            this.cmsRemoteDownload.Name = "cmsRemoteDownload";
            this.cmsRemoteDownload.Size = new System.Drawing.Size(161, 22);
            this.cmsRemoteDownload.Text = "Скачать";
            this.cmsRemoteDownload.Click += new System.EventHandler(this.cmsRemoteDownload_Click);
            // 
            // cmsRemoteRename
            // 
            this.cmsRemoteRename.Name = "cmsRemoteRename";
            this.cmsRemoteRename.Size = new System.Drawing.Size(161, 22);
            this.cmsRemoteRename.Text = "Переименовать";
            this.cmsRemoteRename.Click += new System.EventHandler(this.cmsRemoteRename_Click);
            // 
            // cmsRemoteMove
            // 
            this.cmsRemoteMove.Name = "cmsRemoteMove";
            this.cmsRemoteMove.Size = new System.Drawing.Size(161, 22);
            this.cmsRemoteMove.Text = "Переместить";
            this.cmsRemoteMove.Click += new System.EventHandler(this.cmsRemoteMove_Click);
            // 
            // cmsRemoteDelete
            // 
            this.cmsRemoteDelete.Name = "cmsRemoteDelete";
            this.cmsRemoteDelete.Size = new System.Drawing.Size(161, 22);
            this.cmsRemoteDelete.Text = "Удалить";
            this.cmsRemoteDelete.Click += new System.EventHandler(this.cmsRemoteDelete_Click);
            // 
            // cmsRemoteCreateFolder
            // 
            this.cmsRemoteCreateFolder.Name = "cmsRemoteCreateFolder";
            this.cmsRemoteCreateFolder.Size = new System.Drawing.Size(161, 22);
            this.cmsRemoteCreateFolder.Text = "Создать папку";
            this.cmsRemoteCreateFolder.Click += new System.EventHandler(this.cmsRemoteCreateFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(185, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Локальный сервер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(702, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Удаленный сервер";
            // 
            // btnUpLocal
            // 
            this.btnUpLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpLocal.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnUpLocal.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.btnUpLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpLocal.Location = new System.Drawing.Point(18, 170);
            this.btnUpLocal.Name = "btnUpLocal";
            this.btnUpLocal.Size = new System.Drawing.Size(75, 32);
            this.btnUpLocal.TabIndex = 12;
            this.btnUpLocal.Text = "Назад";
            this.btnUpLocal.UseVisualStyleBackColor = true;
            this.btnUpLocal.Click += new System.EventHandler(this.btnUpLocal_Click);
            // 
            // btnUpRemote
            // 
            this.btnUpRemote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpRemote.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnUpRemote.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.btnUpRemote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpRemote.Location = new System.Drawing.Point(537, 170);
            this.btnUpRemote.Name = "btnUpRemote";
            this.btnUpRemote.Size = new System.Drawing.Size(75, 32);
            this.btnUpRemote.TabIndex = 13;
            this.btnUpRemote.Text = "Назад";
            this.btnUpRemote.UseVisualStyleBackColor = true;
            this.btnUpRemote.Click += new System.EventHandler(this.btnUpRemote_Click);
            // 
            // lblLocalPath
            // 
            this.lblLocalPath.AutoSize = true;
            this.lblLocalPath.Location = new System.Drawing.Point(99, 178);
            this.lblLocalPath.Name = "lblLocalPath";
            this.lblLocalPath.Size = new System.Drawing.Size(67, 17);
            this.lblLocalPath.TabIndex = 14;
            this.lblLocalPath.Text = "C:\\ftptest";
            // 
            // lblRemotePath
            // 
            this.lblRemotePath.AutoSize = true;
            this.lblRemotePath.Location = new System.Drawing.Point(618, 178);
            this.lblRemotePath.Name = "lblRemotePath";
            this.lblRemotePath.Size = new System.Drawing.Size(124, 17);
            this.lblRemotePath.TabIndex = 15;
            this.lblRemotePath.Text = "Нет подключения";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 737);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1054, 22);
            this.statusStrip.TabIndex = 18;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(49, 17);
            this.toolStripStatusLabel1.Text = "Статус: ";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(386, 99);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(258, 23);
            this.progressBar.TabIndex = 19;
            // 
            // folderBrowser
            // 
            this.folderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 759);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.lblRemotePath);
            this.Controls.Add(this.lblLocalPath);
            this.Controls.Add(this.btnUpRemote);
            this.Controls.Add(this.btnUpLocal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvRemote);
            this.Controls.Add(this.lvLocal);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tboxUserPass);
            this.Controls.Add(this.tboxUserName);
            this.Controls.Add(this.tboxServerUrl);
            this.Controls.Add(this.lblUserPass);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblServerUrl);
            this.Controls.Add(this.mainMenu);
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple FTP Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.cmsLocal.ResumeLayout(false);
            this.cmsRemote.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem главнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПроектеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem какРаботатьToolStripMenuItem;
        private System.Windows.Forms.Label lblServerUrl;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserPass;
        private System.Windows.Forms.TextBox tboxServerUrl;
        private System.Windows.Forms.TextBox tboxUserName;
        private System.Windows.Forms.TextBox tboxUserPass;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListView lvLocal;
        private System.Windows.Forms.ListView lvRemote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpLocal;
        private System.Windows.Forms.Button btnUpRemote;
        private System.Windows.Forms.Label lblLocalPath;
        private System.Windows.Forms.Label lblRemotePath;
        private System.Windows.Forms.ContextMenuStrip cmsLocal;
        private System.Windows.Forms.ContextMenuStrip cmsRemote;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem cmsLocalUpload;
        private System.Windows.Forms.ToolStripMenuItem cmsLocalRename;
        private System.Windows.Forms.ToolStripMenuItem cmsLocalMove;
        private System.Windows.Forms.ToolStripMenuItem cmsLocalDelete;
        private System.Windows.Forms.ToolStripMenuItem cmsLocalCreateFolder;
        private System.Windows.Forms.ToolStripMenuItem cmsRemoteDownload;
        private System.Windows.Forms.ToolStripMenuItem cmsRemoteRename;
        private System.Windows.Forms.ToolStripMenuItem cmsRemoteMove;
        private System.Windows.Forms.ToolStripMenuItem cmsRemoteDelete;
        private System.Windows.Forms.ToolStripMenuItem cmsRemoteCreateFolder;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
    }
}

