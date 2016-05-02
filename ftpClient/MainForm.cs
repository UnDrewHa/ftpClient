using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace ftpClient {
    public partial class MainForm : Form {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        ftper ftpSet = new ftper();
        public MainForm() {
            InitializeComponent();

            ftpSet.ftpObject.statusChange += new EventHandler<statusChangeEventArgs>(ftpobject_statusChange);
            ftpSet.ftpObject.downloadProgress += new EventHandler<downloadProgressEventArgs>(ftpobject_downloadProgress);
            ftpSet.ftpObject.downloadComplete += new EventHandler<downloadCompleteEventArgs>(ftpobject_downloadComplete);
            ftpSet.ftpObject.uploadComplete += new EventHandler<uploadCompleteEventArgs>(ftpobject_uploadComplete);
            ftpSet.ftpObject.deleteComplete += new EventHandler<deleteCompleteEventArgs>(ftpobject_deleteComplete);
            ftpSet.ftpObject.mkDirRemoteComplete += new EventHandler<mkDirRemoteCompleteEventArgs>(ftpobject_mkDirRemoteComplete);
            ftpSet.ftpObject.uploadProgress += new EventHandler<uploadProgressEventArgs>(ftpobject_uploadProgress);
            FileSystemWatcher fsWatcher = new FileSystemWatcher();
            fsWatcher.Path = lblLocalPath.Text;
            fsWatcher.NotifyFilter = NotifyFilters.FileName;
            fsWatcher.Changed += new FileSystemEventHandler(fsOnChanged);
            fsWatcher.Created += new FileSystemEventHandler(fsOnCreated);
            fsWatcher.Deleted += new FileSystemEventHandler(fsOnDeleted);
            fsWatcher.Renamed += new RenamedEventHandler(fsOnRenamed);
            fsWatcher.EnableRaisingEvents = true;
        }

        void fsOnChanged(object source, FileSystemEventArgs e)
        {
            statusBar.Invoke(new Action(() => { statusBar.Text = "File: " + e.FullPath + " " + e.ChangeType; }));
            lvLocal.Invoke(new Action(() => { refreshLocal();  }));


        }
        void fsOnCreated(object source, FileSystemEventArgs e)
        {
            statusBar.Invoke(new Action(() => { statusBar.Text = "File: " + e.FullPath + " " + e.ChangeType; }));
            lvLocal.Invoke(new Action(() => { refreshLocal(); }));

        }
        void fsOnDeleted(object source, FileSystemEventArgs e)
        {
            statusBar.Invoke(new Action(() => { statusBar.Text = "File: " + e.FullPath + " " + e.ChangeType; }));
            lvLocal.Invoke(new Action(() => { refreshLocal(); }));

        }
        void fsOnRenamed(object source, FileSystemEventArgs e)
        {
            statusBar.Invoke(new Action(() => { statusBar.Text = "File: " + e.FullPath + " " + e.ChangeType; }));
            lvLocal.Invoke(new Action(() => { refreshLocal(); }));

        }

        void ftpobject_downloadProgress(object sender, downloadProgressEventArgs e)
        {
            progressBar.Style = ProgressBarStyle.Marquee;

        }
        void ftpobject_uploadProgress(object sender, uploadProgressEventArgs e)
                {
                    progressBar.Style = ProgressBarStyle.Marquee;

                }

        void ftpobject_mkDirRemoteComplete(object sender, mkDirRemoteCompleteEventArgs e) {
            statusBar.Text = "Папка создана: " + e.filename + Environment.NewLine + statusBar.Text;
            refreshRemote();
        }

        void ftpobject_uploadComplete(object sender, uploadCompleteEventArgs e) {
            progressBar.Style = ProgressBarStyle.Blocks;
            statusBar.Text = "Загрузка завершена: " + e.filename + Environment.NewLine + statusBar.Text + statusBar.Text;
            refreshRemote();
        }
        
        void ftpobject_deleteComplete(object sender, deleteCompleteEventArgs e) {
            statusBar.Text = e.filename + Environment.NewLine + statusBar.Text;
            refreshRemote();
        }

        void ftpobject_downloadComplete(object sender, downloadCompleteEventArgs e) {
            progressBar.Style = ProgressBarStyle.Blocks;
            statusBar.Text = "Скачка завершена: " + e.filename + Environment.NewLine + statusBar.Text;
            refreshLocal();
            
        }

        void ftpobject_statusChange(object sender, statusChangeEventArgs e) {
            statusBar.Text = e.message + System.Environment.NewLine + statusBar.Text;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            mainTab.Visible = true;
            works.Visible = false;
            about.Visible = false;
            header.BackColor = Color.FromArgb(59,70,74);
            panel1.BackColor = Color.FromArgb(63, 74, 78);
            panel2.BackColor = Color.FromArgb(59, 70, 74);
            panel3.BackColor = Color.FromArgb(59, 70, 74);
            label4.BackColor = Color.FromArgb(63, 74, 78);
            label5.BackColor = Color.FromArgb(59, 70, 74);
            label6.BackColor = Color.FromArgb(59, 70, 74);
            if (!System.IO.Directory.Exists(@"C:\ftptest")) {
                System.IO.Directory.CreateDirectory(@"C:\ftptest");
            }
            if (tboxServerUrl.Text.Substring(tboxServerUrl.Text.Length - 1, 1) == "/") {
                tboxServerUrl.Text = tboxServerUrl.Text.Substring(0, tboxServerUrl.Text.Length - 1);
            }
            refreshLocal();
        }

        private void refreshLocal() {
            lvLocal.Items.Clear();

            DirectoryInfo di = new DirectoryInfo(lblLocalPath.Text);
            try
            {
                foreach (DirectoryInfo dri in di.GetDirectories())
                {
                    string date = di.CreationTime.ToString();
                    string size = "";
                    string[] sub = new string[] { size, date };
                    lvLocal.Items.Add(dri.Name, (int)directionEntryTypes.directory).SubItems.AddRange(sub);
                }
                foreach (FileInfo fi in di.GetFiles())
                {
                    string size = GetFileSize(fi.Length);
                    string date = fi.LastWriteTime.ToString();
                    string[] sub = new string[] { size, date };
                    lvLocal.Items.Add(fi.Name, (int)directionEntryTypes.file).SubItems.AddRange(sub);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка отображения");
            }
            }


        void refreshRemote() {
            List<ftpinfo> files = ftpSet.browse(tboxServerUrl.Text + lblRemotePath.Text);
            listRemoteFiles(files);
        }

        private void lvLocal_DoubleClick(object sender, EventArgs e) {
            if (lvLocal.SelectedItems.Count == 1) {
                if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file) {

                } else {
                    lblLocalPath.Text += (lblLocalPath.Text.EndsWith(@"\") ? "" : @"\") + lvLocal.SelectedItems[0].Text;
                    refreshLocal();
                }
            }
        }

        private void btnUpLocal_Click(object sender, EventArgs e) {
            if (lblLocalPath.Text.Length <= 3) {
                MessageBox.Show("Вы находитесь в корне каталога!");
                return;
            }
                
            string back = StringUtils.ExtractFolderFromPath(lblLocalPath.Text, @"\", false);
            if (back.Length > 2) {
                lblLocalPath.Text = back;
            } else {
                lblLocalPath.Text = back + @"\";
            }
            refreshLocal();
        }

        private void btnConnect_Click(object sender, EventArgs e) {
            List<ftpinfo> files = ftpSet.connect(tboxServerUrl.Text, tboxUserName.Text, tboxUserPass.Text);
            listRemoteFiles(files);
            lblRemotePath.Text = new Uri(tboxServerUrl.Text).AbsolutePath;
        }

        private void listRemoteFiles(List<ftpinfo> files) {
            lvRemote.Items.Clear();
            if (files == null)
                return;
            string blah = "";
            foreach (ftpinfo file in files) {
                ListViewItem it = new ListViewItem(file.filename, file.fileType == directionEntryTypes.directory ? (int)directionEntryTypes.directory : (int)directionEntryTypes.file);
                string size = GetFileSize(file.size).ToString();
                string date = file.fileDateTime.ToString();
                string[] sub = { size, date };
                lvRemote.Items.Add(it).SubItems.AddRange(sub);
            }
        }
        public static string GetFileSize(long numBytes)
        {
            string fileSize = "";

            if (numBytes > 1073741824)
                fileSize = String.Format("{0:0.00} Gb", (double)numBytes / 1073741824);
            else if (numBytes > 1048576)
                fileSize = String.Format("{0:0.00} Mb", (double)numBytes / 1048576);
            else
                fileSize = String.Format("{0:0} Kb", (double)numBytes / 1024);

            if (fileSize == "0 Kb")
                fileSize = "";						
            return fileSize;
        }

        private void btnUpRemote_Click(object sender, EventArgs e) {
            if (lblRemotePath.Text == "/") {
                MessageBox.Show("Вы находитесь в корне каталога!");
            } else if (lblRemotePath.Text == "Нет соединения") {
                MessageBox.Show("Необходимо подключиться к FTP-серверу, используя форму подключения, расположенную вверху приложения.");
            } else {
                lblRemotePath.Text = StringUtils.ExtractFolderFromPath(lblRemotePath.Text, "/", false);
                if (lblRemotePath.Text.Length == 0)
                    lblRemotePath.Text = "/";
                refreshRemote();
            }
        }

        private void lvRemote_DoubleClick(object sender, EventArgs e) {
            if (lvRemote.SelectedItems.Count == 1) {
                if (lvRemote.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file) {

                }
                else {
                    if (lblRemotePath.Text == "/") {
                        lblRemotePath.Text += lvRemote.SelectedItems[0].Text;
                    } else {
                        lblRemotePath.Text += "/" + lvRemote.SelectedItems[0].Text;
                    }
                }
                refreshRemote();
            }
        }

        private void cmsRemoteDownload_Click(object sender, EventArgs e) {
            if (lvRemote.SelectedItems.Count == 0)
                return;
            string localPath = "";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                localPath = folderBrowser.SelectedPath;
                if (lvRemote.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file)
                {
                    string filename = lvRemote.SelectedItems[0].Text;
                    if (lblRemotePath.Text == "/")
                        ftpSet.addFileToDownloadQueue(tboxServerUrl.Text + lblRemotePath.Text + filename, localPath + @"\" + filename);
                    else
                        ftpSet.addFileToDownloadQueue(tboxServerUrl.Text + lblRemotePath.Text + "/" + filename, localPath + @"\" + filename);
                    ftpSet.startProcessing();
                }
                else if (lvRemote.SelectedItems[0].ImageIndex == (int)directionEntryTypes.directory)
                {
                    string filename = lvRemote.SelectedItems[0].Text;
                    ftpSet.addFolderToDownloadQueue(tboxServerUrl.Text + lblRemotePath.Text + "/" + filename, localPath + @"\" + filename);
                    ftpSet.startProcessing();
                }
            }
                
        }

        private void cmsRemoteDelete_Click(object sender, EventArgs e) {
            if (lvRemote.SelectedItems.Count == 0)
                return;
            if (lvRemote.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file) {
                string filename = lvRemote.SelectedItems[0].Text;
                if (lblRemotePath.Text == "/")
                    ftpSet.deleteFile(tboxServerUrl.Text + lblRemotePath.Text + filename);
                else
                    ftpSet.deleteFile(tboxServerUrl.Text + lblRemotePath.Text + "/" + filename);
            } else if (lvRemote.SelectedItems[0].ImageIndex == (int)directionEntryTypes.directory) {
                string filename = lvRemote.SelectedItems[0].Text;
                ftpSet.deleteFolder(tboxServerUrl.Text + lblRemotePath.Text + "/" + filename);
            }
        }

        private void cmsRemoteCreateFolder_Click(object sender, EventArgs e) {
            dialogBox mkDir = new dialogBox();
            mkDir._formName = "Создать папку";
            mkDir._tboxName = "Новая папка";
            mkDir._btnName = "Создать";
            mkDir.ShowDialog();

            if (mkDir.DialogResult == DialogResult.OK)
            {
                if (mkDir.prop == "")
                    MessageBox.Show("Имя папки не может быть пустым!");
                string nameOfFolder = mkDir.prop;
                if (lblRemotePath.Text == "/")
                    ftpSet.mkRemoteFolder(tboxServerUrl.Text + lblRemotePath.Text + nameOfFolder);
                else
                    ftpSet.mkRemoteFolder(tboxServerUrl.Text + lblRemotePath.Text + "/" + nameOfFolder);
            }
        }

        private void cmsRemoteRename_Click(object sender, EventArgs e)
        {
            if (lvRemote.SelectedItems.Count == 0)
                return;
            string filename = lvRemote.SelectedItems[0].Text;
            string oldName = "";
            if (lblRemotePath.Text == "/")
                oldName = tboxServerUrl.Text + lblRemotePath.Text + filename;
            else
                oldName = tboxServerUrl.Text + lblRemotePath.Text + "/" + filename;

            dialogBox renameSome = new dialogBox();
            renameSome._formName = "Переименовать файл/папку";
            renameSome._tboxName = lvRemote.SelectedItems[0].Text;
            renameSome._btnName = "Переименовать";

            renameSome.ShowDialog();

            if (renameSome.DialogResult == DialogResult.OK)
            {
                if (renameSome.prop == "")
                    MessageBox.Show("Имя не может быть пустым!");
                string nameOfFolder = renameSome.prop;

                ftpSet.renameFile(oldName, nameOfFolder);
            }
        }

        private void cmsRemoteMove_Click(object sender, EventArgs e)
        {
            if (lvRemote.SelectedItems.Count == 0)
                return;
            string filename = lvRemote.SelectedItems[0].Text;
            string oldName = "";
            if (lblRemotePath.Text == "/")
                oldName = tboxServerUrl.Text + lblRemotePath.Text + filename;
            else
                oldName = tboxServerUrl.Text + lblRemotePath.Text + "/" + filename;

            folderExplorer moveFile = new folderExplorer();
            moveFile._formName = "Переместить файл";
            moveFile._btnName = "Переместить";
            moveFile._lblText = "Выберите папку:";
            moveFile._server = tboxServerUrl.Text;
            moveFile._path = lblRemotePath.Text;
            moveFile._username = tboxUserName.Text;
            moveFile._password = tboxUserPass.Text;
            moveFile._selectedFile = lvRemote.SelectedItems[0].Text;
            moveFile._selectedFilePath = tboxServerUrl.Text + lblRemotePath;
            moveFile.ShowDialog();

            if (moveFile.DialogResult == DialogResult.OK)
            {
                string newName = moveFile.prop + "/" + lvRemote.SelectedItems[0].Text;
                ftpSet.renameFile(oldName, newName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowser.ShowDialog();
            string blah = folderBrowser.SelectedPath;
            MessageBox.Show(blah);


        }

        private void cmsLocalDelete_Click(object sender, EventArgs e)
        {
            if (lvLocal.SelectedItems.Count == 0)
                return;
            try
            {
                if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file)
                {
                    File.Delete(lblLocalPath.Text + @"\" + lvLocal.SelectedItems[0].Text);
                }
                else if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.directory)
                {
                    Directory.Delete(lblLocalPath.Text + @"\" + lvLocal.SelectedItems[0].Text, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка удаления");
            }


        }

        private void cmsLocalCreateFolder_Click(object sender, EventArgs e)
        {
            dialogBox mkLocalDir = new dialogBox();
            mkLocalDir._formName = "Создать папку";
            mkLocalDir._tboxName = "Новая папка";
            mkLocalDir._btnName = "Создать";
            mkLocalDir.ShowDialog();

            if (mkLocalDir.DialogResult == DialogResult.OK)
            {
                if (mkLocalDir.prop == "")
                    MessageBox.Show("Имя папки не может быть пустым!");
                string nameOfFolder = mkLocalDir.prop;
                if (Directory.Exists(lblLocalPath.Text + @"\" + nameOfFolder))
                {
                    MessageBox.Show("Папка с данным именем уже существует. Введите другое имя папки.");
                    return;
                }
                else
                    try
                    {
                        Directory.CreateDirectory(lblLocalPath.Text + @"\" + nameOfFolder);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка при создании папки");
                    }
            }
        }

        private void cmsLocalRename_Click(object sender, EventArgs e)
        {
            if (lvLocal.SelectedItems.Count == 0)
                return;
            string oldName = lblLocalPath.Text + @"\" + lvLocal.SelectedItems[0].Text;

            dialogBox renamelocal = new dialogBox();
            renamelocal._formName = "Переименовать файл/папку";
            renamelocal._tboxName = lvLocal.SelectedItems[0].Text;
            renamelocal._btnName = "Переименовать";

            renamelocal.ShowDialog();

            if (renamelocal.DialogResult == DialogResult.OK)
            {
                if (renamelocal.prop == "")
                    MessageBox.Show("Имя не может быть пустым!");
                string nameOfFolder = renamelocal.prop;

                if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file)
                {
                    if (!File.Exists(lblLocalPath.Text + @"\" + nameOfFolder))
                        File.Move(oldName, lblLocalPath.Text + @"\" + nameOfFolder);
                    else
                    {
                        File.Delete(lblLocalPath.Text + @"\" + nameOfFolder);
                        File.Move(oldName, lblLocalPath.Text + @"\" + nameOfFolder);
                    }
                        
                }
                else if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.directory)
                {
                    if (!Directory.Exists(lblLocalPath.Text + @"\" + nameOfFolder))
                        try
                        {
                            Directory.Move(oldName, lblLocalPath.Text + @"\" + nameOfFolder);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка переименовывания");
                        }
                    else
                        MessageBox.Show("Папка с данным именем уже существует. Выберите другое.");
                }
                
            }
        }

        private void cmsLocalMove_Click(object sender, EventArgs e)
        {
            if (lvLocal.SelectedItems.Count == 0)
                return;

            string localPath = "";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                localPath = folderBrowser.SelectedPath + @"\" + lvLocal.SelectedItems[0].Text;

                string oldName = lblLocalPath.Text + @"\" + lvLocal.SelectedItems[0].Text;

                if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file)
                {
                    try
                    {
                        if (!File.Exists(localPath))
                            File.Move(oldName, localPath);
                        else
                        {
                            File.Delete(localPath);
                            File.Move(oldName, localPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка перемещения");
                    }
                    
                }
                else if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.directory)
                {
                    try
                    {
                        if (!Directory.Exists(localPath))
                            Directory.Move(oldName, localPath);
                        else
                            MessageBox.Show("Папка с данным именем уже существует. Выберите другое.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка перемещения");
                    }
                }
            }
            }

        private void cmsLocalUpload_Click(object sender, EventArgs e)
        {
            if (lblRemotePath.Text == "Нет подключения")
            {
                MessageBox.Show("Необходимо подключиться к ftp-серверу.");
                return;
            }
                
            if (this.lvLocal.SelectedItems.Count == 0)
                return;
            folderExplorer upload = new folderExplorer();
            upload._formName = "Зугрузить файл на сервер";
            upload._btnName = "Загрузить";
            upload._lblText = "Выберите папку:";
            upload._server = tboxServerUrl.Text;
            upload._path = lblRemotePath.Text;
            upload._username = tboxUserName.Text;
            upload._password = tboxUserPass.Text;
            upload._selectedFile = lvLocal.SelectedItems[0].Text;
            upload._selectedFilePath = tboxServerUrl.Text + lblRemotePath;
            upload.ShowDialog();

            string path = "";
            if (upload.DialogResult == DialogResult.OK)
            {
                if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file)
                {
                    string filename = lvLocal.SelectedItems[0].Text;
                    if (lblRemotePath.Text == "/")
                    {
                        path = tboxServerUrl.Text + upload.prop;
                        ftpSet.addFileToUploadQueue(lblLocalPath.Text + @"\" + filename, path);
                    }
                        
                    else
                    {
                        path = tboxServerUrl.Text + upload.prop;
                        ftpSet.addFileToUploadQueue(lblLocalPath.Text + @"\" + filename, tboxServerUrl.Text + lblRemotePath.Text + "/" + filename);
                    }
                        
                    ftpSet.startProcessing();
                }
                else if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.directory)
                {
                    string filename = lvLocal.SelectedItems[0].Text;
                    if (lblRemotePath.Text == "/")
                    {
                        path = tboxServerUrl.Text + upload.prop;
                        ftpSet.addFolderToUploadQueue(lblLocalPath.Text + @"\" + filename, tboxServerUrl.Text + lblRemotePath.Text + filename);
                    }
                    else
                    {
                        path = tboxServerUrl.Text + upload.prop;
                        ftpSet.addFolderToUploadQueue(lblLocalPath.Text + @"\" + filename, tboxServerUrl.Text + lblRemotePath.Text + "/" + filename);
                    }
                        
                    ftpSet.startProcessing();
                }
            }

            



        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(63, 74, 78);
            label4.BackColor = Color.FromArgb(63, 74, 78);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(59, 70, 74);
            label4.BackColor = Color.FromArgb(59, 70, 74);
        }

        private void panel2_MouseHover(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(63, 74, 78);
            label5.BackColor = Color.FromArgb(63, 74, 78);
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(59, 70, 74);
            label5.BackColor = Color.FromArgb(59, 70, 74);
        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(63, 74, 78);
            label6.BackColor = Color.FromArgb(63, 74, 78);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(59, 70, 74);
            label6.BackColor = Color.FromArgb(59, 70, 74);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
                this.Hide();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {

        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void lblServerUrl_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            mainTab.Visible = false;
            works.Visible = true;
            about.Visible = false;

            panel1.BackColor = Color.FromArgb(59, 70, 74);
            panel2.BackColor = Color.FromArgb(63, 74, 78);
            panel3.BackColor = Color.FromArgb(59, 70, 74);
            label4.BackColor = Color.FromArgb(59, 70, 74);
            label4.ForeColor = Color.DarkGray;
            label5.BackColor = Color.FromArgb(63, 74, 78);
            label5.ForeColor = Color.FromArgb(255,255,255);
            label6.BackColor = Color.FromArgb(59, 70, 74);
            label6.ForeColor = Color.DarkGray;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            mainTab.Visible = false;
            works.Visible = false;
            about.Visible = true;

            panel1.BackColor = Color.FromArgb(59, 70, 74);
            panel2.BackColor = Color.FromArgb(59, 70, 74);
            panel3.BackColor = Color.FromArgb(63, 74, 78);
            label4.BackColor = Color.FromArgb(59, 70, 74);
            label4.ForeColor = Color.DarkGray;
            label5.BackColor = Color.FromArgb(59, 70, 74);
            label5.ForeColor = Color.DarkGray;
            label6.BackColor = Color.FromArgb(63, 74, 78);
            label6.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            mainTab.Visible = true;
            works.Visible = false;
            about.Visible = false;

            panel1.BackColor = Color.FromArgb(63, 74, 78);
            panel2.BackColor = Color.FromArgb(59, 70, 74);
            panel3.BackColor = Color.FromArgb(59, 70, 74);
            label4.BackColor = Color.FromArgb(63, 74, 78);
            label4.ForeColor = Color.FromArgb(255, 255, 255);
            label5.BackColor = Color.FromArgb(59, 70, 74);
            label5.ForeColor = Color.DarkGray;
            label6.BackColor = Color.FromArgb(59, 70, 74);
            label6.ForeColor = Color.DarkGray;
        }

        private void mainTab_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void about_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void works_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            ftpSet.stopProcessing();
        }
    }
}
