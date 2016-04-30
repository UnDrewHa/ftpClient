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
        }

        void ftpobject_downloadProgress(object sender, downloadProgressEventArgs e)
        {
            int step = (e.bytesTransferred / e.totalBytes)/100;
            progressBar.Step = e.bytesTransferred;
            progressBar.Maximum = e.totalBytes;
            
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
            if (lvRemote.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file) {
                string filename = lvRemote.SelectedItems[0].Text;
                if (lblRemotePath.Text == "/")
                    ftpSet.addFileToDownloadQueue(tboxServerUrl.Text + lblRemotePath.Text + filename, lblLocalPath.Text + @"\" + filename);
                else
                    ftpSet.addFileToDownloadQueue(tboxServerUrl.Text + lblRemotePath.Text + "/" + filename, lblLocalPath.Text + @"\" + filename);
                ftpSet.startProcessing();
            } else if (lvRemote.SelectedItems[0].ImageIndex == (int)directionEntryTypes.directory) {
                string filename = lvRemote.SelectedItems[0].Text;
                ftpSet.addFolderToDownloadQueue(tboxServerUrl.Text + lblRemotePath.Text + "/" + filename, lblLocalPath.Text + @"\" + filename);
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
            string oldName = "", newName = "";
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
    }
}
