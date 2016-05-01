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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblServerUrl = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserPass = new System.Windows.Forms.Label();
            this.tboxServerUrl = new System.Windows.Forms.TextBox();
            this.tboxUserName = new System.Windows.Forms.TextBox();
            this.tboxUserPass = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lvLocal = new System.Windows.Forms.ListView();
            this.cmsLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lvRemote = new System.Windows.Forms.ListView();
            this.cmsRemote = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpLocal = new System.Windows.Forms.Button();
            this.btnUpRemote = new System.Windows.Forms.Button();
            this.lblLocalPath = new System.Windows.Forms.Label();
            this.lblRemotePath = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.logo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainTab = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.works = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.about = new System.Windows.Forms.Panel();
            this.statusBar = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmsLocalUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLocalRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLocalMove = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLocalDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLocalCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoteDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoteRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoteMove = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoteDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoteCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLocal.SuspendLayout();
            this.cmsRemote.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.logo.SuspendLayout();
            this.header.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.works.SuspendLayout();
            this.about.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblServerUrl
            // 
            this.lblServerUrl.AutoSize = true;
            this.lblServerUrl.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblServerUrl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblServerUrl.Location = new System.Drawing.Point(43, 77);
            this.lblServerUrl.Name = "lblServerUrl";
            this.lblServerUrl.Size = new System.Drawing.Size(65, 19);
            this.lblServerUrl.TabIndex = 1;
            this.lblServerUrl.Text = "Сервер:";
            this.lblServerUrl.Click += new System.EventHandler(this.lblServerUrl_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUserName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblUserName.Location = new System.Drawing.Point(298, 77);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(108, 19);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Пользователь:";
            // 
            // lblUserPass
            // 
            this.lblUserPass.AutoSize = true;
            this.lblUserPass.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUserPass.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblUserPass.Location = new System.Drawing.Point(543, 77);
            this.lblUserPass.Name = "lblUserPass";
            this.lblUserPass.Size = new System.Drawing.Size(64, 19);
            this.lblUserPass.TabIndex = 3;
            this.lblUserPass.Text = "Пароль:";
            // 
            // tboxServerUrl
            // 
            this.tboxServerUrl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tboxServerUrl.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tboxServerUrl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tboxServerUrl.Location = new System.Drawing.Point(46, 104);
            this.tboxServerUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tboxServerUrl.Name = "tboxServerUrl";
            this.tboxServerUrl.Size = new System.Drawing.Size(170, 25);
            this.tboxServerUrl.TabIndex = 4;
            this.tboxServerUrl.Text = "ftp://192.168.1.2";
            // 
            // tboxUserName
            // 
            this.tboxUserName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tboxUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tboxUserName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tboxUserName.Location = new System.Drawing.Point(301, 104);
            this.tboxUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tboxUserName.Name = "tboxUserName";
            this.tboxUserName.Size = new System.Drawing.Size(175, 25);
            this.tboxUserName.TabIndex = 5;
            this.tboxUserName.Text = "anonymous";
            // 
            // tboxUserPass
            // 
            this.tboxUserPass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tboxUserPass.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tboxUserPass.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tboxUserPass.Location = new System.Drawing.Point(546, 105);
            this.tboxUserPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tboxUserPass.Name = "tboxUserPass";
            this.tboxUserPass.PasswordChar = '*';
            this.tboxUserPass.Size = new System.Drawing.Size(175, 25);
            this.tboxUserPass.TabIndex = 6;
            // 
            // btnConnect
            // 
            this.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnConnect.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnConnect.Location = new System.Drawing.Point(780, 101);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(175, 28);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Подключиться";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lvLocal
            // 
            this.lvLocal.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lvLocal.BackColor = System.Drawing.Color.White;
            this.lvLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvLocal.ContextMenuStrip = this.cmsLocal;
            this.lvLocal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvLocal.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lvLocal.FullRowSelect = true;
            this.lvLocal.LargeImageList = this.imageList1;
            this.lvLocal.Location = new System.Drawing.Point(47, 263);
            this.lvLocal.MultiSelect = false;
            this.lvLocal.Name = "lvLocal";
            this.lvLocal.Size = new System.Drawing.Size(440, 310);
            this.lvLocal.SmallImageList = this.imageList1;
            this.lvLocal.TabIndex = 8;
            this.lvLocal.TileSize = new System.Drawing.Size(64, 64);
            this.lvLocal.UseCompatibleStateImageBehavior = false;
            this.lvLocal.View = System.Windows.Forms.View.Details;
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "File.png");
            this.imageList1.Images.SetKeyName(1, "Folder.png");
            // 
            // lvRemote
            // 
            this.lvRemote.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lvRemote.BackColor = System.Drawing.Color.White;
            this.lvRemote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvRemote.ContextMenuStrip = this.cmsRemote;
            this.lvRemote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lvRemote.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lvRemote.FullRowSelect = true;
            this.lvRemote.LargeImageList = this.imageList1;
            this.lvRemote.Location = new System.Drawing.Point(507, 263);
            this.lvRemote.MultiSelect = false;
            this.lvRemote.Name = "lvRemote";
            this.lvRemote.Size = new System.Drawing.Size(440, 310);
            this.lvRemote.SmallImageList = this.imageList1;
            this.lvRemote.TabIndex = 9;
            this.lvRemote.TileSize = new System.Drawing.Size(64, 64);
            this.lvRemote.UseCompatibleStateImageBehavior = false;
            this.lvRemote.View = System.Windows.Forms.View.Details;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(43, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Локальный сервер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(502, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Удаленный сервер";
            // 
            // btnUpLocal
            // 
            this.btnUpLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpLocal.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnUpLocal.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.btnUpLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpLocal.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpLocal.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnUpLocal.Location = new System.Drawing.Point(46, 223);
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
            this.btnUpRemote.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpRemote.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnUpRemote.Location = new System.Drawing.Point(507, 223);
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
            this.lblLocalPath.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLocalPath.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblLocalPath.Location = new System.Drawing.Point(143, 231);
            this.lblLocalPath.Name = "lblLocalPath";
            this.lblLocalPath.Size = new System.Drawing.Size(62, 19);
            this.lblLocalPath.TabIndex = 14;
            this.lblLocalPath.Text = "C:\\ftptest";
            // 
            // lblRemotePath
            // 
            this.lblRemotePath.AutoSize = true;
            this.lblRemotePath.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRemotePath.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblRemotePath.Location = new System.Drawing.Point(603, 231);
            this.lblRemotePath.Name = "lblRemotePath";
            this.lblRemotePath.Size = new System.Drawing.Size(118, 19);
            this.lblRemotePath.TabIndex = 15;
            this.lblRemotePath.Text = "Нет подключения";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 645);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1000, 25);
            this.statusStrip.TabIndex = 18;
            this.statusStrip.Text = "statusStrip";
            // 
            // progressBar
            // 
            this.progressBar.Margin = new System.Windows.Forms.Padding(47, 5, 5, 5);
            this.progressBar.MarqueeAnimationSpeed = 200;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 15);
            this.progressBar.Step = 1;
            // 
            // folderBrowser
            // 
            this.folderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // logo
            // 
            this.logo.BackColor = System.Drawing.Color.Tomato;
            this.logo.Controls.Add(this.label3);
            this.logo.Location = new System.Drawing.Point(0, 0);
            this.logo.Margin = new System.Windows.Forms.Padding(0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(200, 50);
            this.logo.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(54, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "FTPClient";
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.DarkGray;
            this.header.Controls.Add(this.panel5);
            this.header.Controls.Add(this.panel4);
            this.header.Controls.Add(this.label6);
            this.header.Controls.Add(this.label5);
            this.header.Controls.Add(this.label4);
            this.header.Controls.Add(this.panel3);
            this.header.Controls.Add(this.panel2);
            this.header.Controls.Add(this.panel1);
            this.header.Location = new System.Drawing.Point(200, 0);
            this.header.Margin = new System.Windows.Forms.Padding(0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(800, 50);
            this.header.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.DarkGray;
            this.label6.Location = new System.Drawing.Point(364, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "О ПРОГРАММЕ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(179, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "КАК РАБОТАТЬ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(38, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "ГЛАВНАЯ";
            // 
            // panel3
            // 
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(306, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(199, 50);
            this.panel3.TabIndex = 16;
            this.panel3.Click += new System.EventHandler(this.panel3_Click);
            // 
            // panel2
            // 
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(141, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 50);
            this.panel2.TabIndex = 16;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // panel1
            // 
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 50);
            this.panel1.TabIndex = 16;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // mainTab
            // 
            this.mainTab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainTab.Controls.Add(this.statusBar);
            this.mainTab.Controls.Add(this.lblRemotePath);
            this.mainTab.Controls.Add(this.btnConnect);
            this.mainTab.Controls.Add(this.lblLocalPath);
            this.mainTab.Controls.Add(this.lvLocal);
            this.mainTab.Controls.Add(this.btnUpRemote);
            this.mainTab.Controls.Add(this.lvRemote);
            this.mainTab.Controls.Add(this.btnUpLocal);
            this.mainTab.Controls.Add(this.label1);
            this.mainTab.Controls.Add(this.label2);
            this.mainTab.Controls.Add(this.lblUserName);
            this.mainTab.Controls.Add(this.lblServerUrl);
            this.mainTab.Controls.Add(this.lblUserPass);
            this.mainTab.Controls.Add(this.tboxServerUrl);
            this.mainTab.Controls.Add(this.tboxUserName);
            this.mainTab.Controls.Add(this.tboxUserPass);
            this.mainTab.Location = new System.Drawing.Point(0, 0);
            this.mainTab.Margin = new System.Windows.Forms.Padding(0);
            this.mainTab.Name = "mainTab";
            this.mainTab.Size = new System.Drawing.Size(1000, 700);
            this.mainTab.TabIndex = 21;
            this.mainTab.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainTab_MouseDown);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "FTPClient";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(83, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "WORKS";
            // 
            // works
            // 
            this.works.BackColor = System.Drawing.Color.DarkOrange;
            this.works.Controls.Add(this.label8);
            this.works.Location = new System.Drawing.Point(968, 50);
            this.works.Margin = new System.Windows.Forms.Padding(0);
            this.works.Name = "works";
            this.works.Size = new System.Drawing.Size(1000, 750);
            this.works.TabIndex = 16;
            this.works.MouseDown += new System.Windows.Forms.MouseEventHandler(this.works_MouseDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(173, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "WORKS";
            // 
            // about
            // 
            this.about.BackColor = System.Drawing.Color.GreenYellow;
            this.about.Controls.Add(this.label7);
            this.about.Location = new System.Drawing.Point(918, 50);
            this.about.Margin = new System.Windows.Forms.Padding(0);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(1000, 650);
            this.about.TabIndex = 0;
            this.about.MouseDown += new System.Windows.Forms.MouseEventHandler(this.about_MouseDown);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statusBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statusBar.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusBar.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.statusBar.Location = new System.Drawing.Point(46, 594);
            this.statusBar.Margin = new System.Windows.Forms.Padding(0);
            this.statusBar.Multiline = true;
            this.statusBar.Name = "statusBar";
            this.statusBar.ReadOnly = true;
            this.statusBar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusBar.Size = new System.Drawing.Size(900, 30);
            this.statusBar.TabIndex = 16;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 232;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Размер";
            this.columnHeader2.Width = 97;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Дата изменения";
            this.columnHeader3.Width = 104;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Имя";
            this.columnHeader4.Width = 262;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Размер";
            this.columnHeader5.Width = 62;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Дата изменения";
            this.columnHeader6.Width = 111;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BackgroundImage = global::ftpClient.Properties.Resources.minim1;
            this.panel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel5.Location = new System.Drawing.Point(745, 19);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(15, 15);
            this.panel5.TabIndex = 18;
            this.panel5.Click += new System.EventHandler(this.panel5_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::ftpClient.Properties.Resources.close1;
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(775, 18);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(13, 13);
            this.panel4.TabIndex = 17;
            this.panel4.Click += new System.EventHandler(this.panel4_Click);
            // 
            // cmsLocalUpload
            // 
            this.cmsLocalUpload.Image = global::ftpClient.Properties.Resources.Upload_to_the_Cloud1;
            this.cmsLocalUpload.Name = "cmsLocalUpload";
            this.cmsLocalUpload.Size = new System.Drawing.Size(161, 22);
            this.cmsLocalUpload.Text = "На сервер";
            this.cmsLocalUpload.Click += new System.EventHandler(this.cmsLocalUpload_Click);
            // 
            // cmsLocalRename
            // 
            this.cmsLocalRename.Image = global::ftpClient.Properties.Resources.Edit1;
            this.cmsLocalRename.Name = "cmsLocalRename";
            this.cmsLocalRename.Size = new System.Drawing.Size(161, 22);
            this.cmsLocalRename.Text = "Переименовать";
            this.cmsLocalRename.Click += new System.EventHandler(this.cmsLocalRename_Click);
            // 
            // cmsLocalMove
            // 
            this.cmsLocalMove.Image = global::ftpClient.Properties.Resources.External_Link;
            this.cmsLocalMove.Name = "cmsLocalMove";
            this.cmsLocalMove.Size = new System.Drawing.Size(161, 22);
            this.cmsLocalMove.Text = "Переместить";
            this.cmsLocalMove.Click += new System.EventHandler(this.cmsLocalMove_Click);
            // 
            // cmsLocalDelete
            // 
            this.cmsLocalDelete.Image = global::ftpClient.Properties.Resources.Delete1;
            this.cmsLocalDelete.Name = "cmsLocalDelete";
            this.cmsLocalDelete.Size = new System.Drawing.Size(161, 22);
            this.cmsLocalDelete.Text = "Удалить";
            this.cmsLocalDelete.Click += new System.EventHandler(this.cmsLocalDelete_Click);
            // 
            // cmsLocalCreateFolder
            // 
            this.cmsLocalCreateFolder.Image = global::ftpClient.Properties.Resources.Plus1;
            this.cmsLocalCreateFolder.Name = "cmsLocalCreateFolder";
            this.cmsLocalCreateFolder.Size = new System.Drawing.Size(161, 22);
            this.cmsLocalCreateFolder.Text = "Создать папку";
            this.cmsLocalCreateFolder.Click += new System.EventHandler(this.cmsLocalCreateFolder_Click);
            // 
            // cmsRemoteDownload
            // 
            this.cmsRemoteDownload.Image = global::ftpClient.Properties.Resources.Download_from_the_Cloud1;
            this.cmsRemoteDownload.Name = "cmsRemoteDownload";
            this.cmsRemoteDownload.Size = new System.Drawing.Size(161, 22);
            this.cmsRemoteDownload.Text = "Скачать";
            this.cmsRemoteDownload.Click += new System.EventHandler(this.cmsRemoteDownload_Click);
            // 
            // cmsRemoteRename
            // 
            this.cmsRemoteRename.Image = global::ftpClient.Properties.Resources.Edit1;
            this.cmsRemoteRename.Name = "cmsRemoteRename";
            this.cmsRemoteRename.Size = new System.Drawing.Size(161, 22);
            this.cmsRemoteRename.Text = "Переименовать";
            this.cmsRemoteRename.Click += new System.EventHandler(this.cmsRemoteRename_Click);
            // 
            // cmsRemoteMove
            // 
            this.cmsRemoteMove.Image = global::ftpClient.Properties.Resources.External_Link;
            this.cmsRemoteMove.Name = "cmsRemoteMove";
            this.cmsRemoteMove.Size = new System.Drawing.Size(161, 22);
            this.cmsRemoteMove.Text = "Переместить";
            this.cmsRemoteMove.Click += new System.EventHandler(this.cmsRemoteMove_Click);
            // 
            // cmsRemoteDelete
            // 
            this.cmsRemoteDelete.Image = global::ftpClient.Properties.Resources.Delete1;
            this.cmsRemoteDelete.Name = "cmsRemoteDelete";
            this.cmsRemoteDelete.Size = new System.Drawing.Size(161, 22);
            this.cmsRemoteDelete.Text = "Удалить";
            this.cmsRemoteDelete.Click += new System.EventHandler(this.cmsRemoteDelete_Click);
            // 
            // cmsRemoteCreateFolder
            // 
            this.cmsRemoteCreateFolder.Image = global::ftpClient.Properties.Resources.Plus1;
            this.cmsRemoteCreateFolder.Name = "cmsRemoteCreateFolder";
            this.cmsRemoteCreateFolder.Size = new System.Drawing.Size(161, 22);
            this.cmsRemoteCreateFolder.Text = "Создать папку";
            this.cmsRemoteCreateFolder.Click += new System.EventHandler(this.cmsRemoteCreateFolder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1000, 670);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.header);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.works);
            this.Controls.Add(this.about);
            this.Controls.Add(this.mainTab);
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple FTP Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.cmsLocal.ResumeLayout(false);
            this.cmsRemote.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.logo.ResumeLayout(false);
            this.logo.PerformLayout();
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.mainTab.ResumeLayout(false);
            this.mainTab.PerformLayout();
            this.works.ResumeLayout(false);
            this.works.PerformLayout();
            this.about.ResumeLayout(false);
            this.about.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Panel logo;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Panel mainTab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel works;
        private System.Windows.Forms.Panel about;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.TextBox statusBar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

