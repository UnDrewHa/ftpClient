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

namespace ftpClient {
    public partial class MainForm : Form {
        ftper ftpSet = new ftper();
        public MainForm() {
            InitializeComponent();

            ftpSet.ftpObject.statusChange += new EventHandler<statusChangeEventArgs>(ftpobject_statusChange);
            ftpSet.ftpObject.downloadProgress += new EventHandler<downloadProgressEventArgs>(ftpobject_downloadProgress);
            ftpSet.ftpObject.downloadComplete += new EventHandler<downloadCompleteEventArgs>(ftpobject_downloadComplete);
            ftpSet.ftpObject.uploadComplete += new EventHandler<uploadCompleteEventArgs>(ftpobject_uploadComplete);
            ftpSet.ftpObject.deleteComplete += new EventHandler<deleteCompleteEventArgs>(ftpobject_deleteComplete);
            ftpSet.ftpObject.mkDirRemoteComplete += new EventHandler<mkDirRemoteCompleteEventArgs>(ftpobject_mkDirRemoteComplete);
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
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            
            
        }
        void fsOnCreated(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            
        }
        void fsOnDeleted(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            
        }
        void fsOnRenamed(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            
        }

        void ftpobject_downloadProgress(object sender, downloadProgressEventArgs e)
        {
            /*
            int step = (e.bytesTransferred / e.totalBytes)/100;
            progressBar.Step = e.bytesTransferred;
            progressBar.Maximum = e.totalBytes;
            */
            
        }
        void ftpobject_mkDirRemoteComplete(object sender, mkDirRemoteCompleteEventArgs e) {
            statusStrip.Text += "Create complete: " + e.filename + Environment.NewLine;
            statusStrip.Text += "Refreshing the remote folder..." + e.filename + Environment.NewLine;
            refreshRemote();
        }

        void ftpobject_uploadComplete(object sender, uploadCompleteEventArgs e) {
            statusStrip.Text += "Upload complete: " + e.filename + Environment.NewLine;
            statusStrip.Text += "Refreshing the remote folder..." + e.filename + Environment.NewLine;
            refreshRemote();
        }
        
        void ftpobject_deleteComplete(object sender, deleteCompleteEventArgs e) {
            statusStrip.Text += "Delete complete: " + e.filename + Environment.NewLine;
            statusStrip.Text += "Refreshing the remote folder..." + e.filename + Environment.NewLine;
            refreshRemote();
        }

        void ftpobject_downloadComplete(object sender, downloadCompleteEventArgs e) {
            statusStrip.Text += "Download complete: " + e.filename + Environment.NewLine;
            statusStrip.Text += "Refreshing the local folder..." + e.filename + Environment.NewLine;
            refreshLocal();
        }

        void ftpobject_statusChange(object sender, statusChangeEventArgs e) {
            statusStrip.Text += "STATUS: " + e.message + " db:" + e.bytesDownloaded + " up:" + e.bytesUploaded + System.Environment.NewLine;
        }

        private void MainForm_Load(object sender, EventArgs e) {
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

            foreach (DirectoryInfo dri in di.GetDirectories()) {
                lvLocal.Items.Add(dri.Name, (int)directionEntryTypes.directory);
            }
            foreach (FileInfo fi in di.GetFiles()) {
                lvLocal.Items.Add(fi.Name, (int)directionEntryTypes.file);
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
            //lvwRemote.Items.Add("..");
            if (files == null)
                return;
            foreach (ftpinfo file in files) {
                ListViewItem it = new ListViewItem(file.filename, file.fileType == directionEntryTypes.directory ? (int)directionEntryTypes.directory : (int)directionEntryTypes.file);
                lvRemote.Items.Add(it);
            }
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
                localPath = folderBrowser.SelectedPath;
            if (lvRemote.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file) {
                string filename = lvRemote.SelectedItems[0].Text;
                if (lblRemotePath.Text == "/")
                    ftpSet.addFileToDownloadQueue(tboxServerUrl.Text + lblRemotePath.Text + filename, localPath + @"\" + filename);
                else
                    ftpSet.addFileToDownloadQueue(tboxServerUrl.Text + lblRemotePath.Text + "/" + filename, localPath + @"\" + filename);
                ftpSet.startProcessing();
            } else if (lvRemote.SelectedItems[0].ImageIndex == (int)directionEntryTypes.directory) {
                string filename = lvRemote.SelectedItems[0].Text;
                ftpSet.addFolderToDownloadQueue(tboxServerUrl.Text + lblRemotePath.Text + "/" + filename, localPath + @"\" + filename);
                ftpSet.startProcessing();
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
            if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file)
            {
                File.Delete(lblLocalPath.Text + @"\" + lvLocal.SelectedItems[0].Text);
            }
            else if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.directory)
            {
                Directory.Delete(lblLocalPath.Text + @"\" + lvLocal.SelectedItems[0].Text, true);
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
                    Directory.CreateDirectory(lblLocalPath.Text + @"\" + nameOfFolder);
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
                        Directory.Move(oldName, lblLocalPath.Text + @"\" + nameOfFolder);
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
                localPath = folderBrowser.SelectedPath + @"\" + lvLocal.SelectedItems[0].Text;

            string oldName = lblLocalPath.Text + @"\" + lvLocal.SelectedItems[0].Text;

                if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file)
                {
                    if (!File.Exists(localPath))
                        File.Move(oldName, localPath);
                    else
                    {
                        File.Delete(localPath);
                        File.Move(oldName, localPath);
                    }
                }
                else if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.directory)
                {
                    if (!Directory.Exists(localPath))
                        Directory.Move(oldName, localPath);
                    else
                        MessageBox.Show("Папка с данным именем уже существует. Выберите другое.");
                }

            }

        private void cmsLocalUpload_Click(object sender, EventArgs e)
        {
            if (lblRemotePath.Text == "Нет подключения")
                return;
            if (this.lvLocal.SelectedItems.Count == 0)
                return;

            if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file)
            {
                string filename = lvLocal.SelectedItems[0].Text;
                if (lblRemotePath.Text == "/")
                    ftpSet.addFileToUploadQueue(lblLocalPath.Text + @"\" + filename, tboxServerUrl.Text + lblRemotePath.Text + filename);
                else
                    ftpSet.addFileToUploadQueue(lblLocalPath.Text + @"\" + filename, tboxServerUrl.Text + lblRemotePath.Text + "/" + filename);
                ftpSet.startProcessing();
            }
            else if (lvLocal.SelectedItems[0].ImageIndex == (int)directionEntryTypes.directory)
            {
                string filename = lvLocal.SelectedItems[0].Text;
                if (lblRemotePath.Text == "/")
                    ftpSet.addFolderToUploadQueue(lblLocalPath.Text + @"\" + filename, tboxServerUrl.Text + lblRemotePath.Text + filename);
                else
                    ftpSet.addFolderToUploadQueue(lblLocalPath.Text + @"\" + filename, tboxServerUrl.Text + lblRemotePath.Text + "/" + filename);
                ftpSet.startProcessing();
            }

        }
    }
}
