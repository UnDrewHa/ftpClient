using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ftpClient
{
    public partial class folderExplorer : Form
    {

        ftper ftpSet = new ftper();
        public folderExplorer()
        {
            
            InitializeComponent();
    }

        public string _formName
        {
            set
            {
                this.Text = value;
            }
        }
        public string _lblText
        {
            set
            {
                lblText.Text = value;
            }
        }
        public string _btnName
        {
            set
            {
                btnAction.Text = value;
            }
        }

        public string _lblPath
        {
            set
            {
                lblPath.Text = value;
            }
        }

        public string _server
        {
            private get; set;
        }

        public string _username
        {

            private get; set;
        }

        public string _password
        {
            private get; set;
        }

        public string _selectedFile
        {
            private get; set;
        }
        public string _selectedFilePath
        {
            private get; set;
        }
        public string _path
        {
            private get; set;
        }
        public string prop
        {
            get
            {
                if (lvFiles.SelectedItems.Count == 0)
                    return lblPath.Text;
                else
                {
                    if (lblPath.Text == "/")
                        return lblPath.Text + lvFiles.SelectedItems[0].Text;
                    else
                        return lblPath.Text + "/" + lvFiles.SelectedItems[0].Text;
                }

                
            }
        }
        
        
        


        private void folderExplorer_Load(object sender, EventArgs e)
        {
            
            lblPath.Text = _path;
            List<ftpinfo> files = ftpSet.connect(_server + lblPath.Text, _username, _password);
            listRemoteFiles(files);
            
        }

        private void listRemoteFiles(List<ftpinfo> files)
        {
            lvFiles.Items.Clear();
            //lvwRemote.Items.Add("..");
            if (files == null)
                return;
            
            foreach (ftpinfo file in files)
            {
                ListViewItem it = new ListViewItem(file.filename, file.fileType == directionEntryTypes.directory ? (int)directionEntryTypes.directory : (int)directionEntryTypes.file);
                if (file.fileType == directionEntryTypes.directory && file.filename != _selectedFile && file.path != _selectedFilePath)
                    lvFiles.Items.Add(it);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lblPath.Text == "/")
            {
                MessageBox.Show("Вы находитесь в корне каталога!");
            }
            else if (lblPath.Text == "Нет соединения")
            {
                MessageBox.Show("Необходимо подключиться к FTP-серверу, используя форму подключения, расположенную вверху приложения.");
            }
            else {
                lblPath.Text = StringUtils.ExtractFolderFromPath(lblPath.Text, "/", false);
                if (lblPath.Text.Length == 0)
                    lblPath.Text = "/";
                refreshRemote();
            }
        }

        void refreshRemote()
        {
            List<ftpinfo> files = ftpSet.browse(_server + lblPath.Text);
            listRemoteFiles(files);
        }

        private void lvFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lvFiles.SelectedItems.Count == 1)
            {
                if (lvFiles.SelectedItems[0].ImageIndex == (int)directionEntryTypes.file)
                {

                }
                else {
                    if (lblPath.Text == "/")
                    {
                        lblPath.Text += lvFiles.SelectedItems[0].Text;
                    }
                    else {
                        lblPath.Text += "/" + lvFiles.SelectedItems[0].Text;
                    }
                }
                refreshRemote();
            }
        }
    }
}
