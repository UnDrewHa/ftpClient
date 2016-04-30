using System;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;


namespace ftpClient {
    public class ftp {
        public event EventHandler<downloadCompleteEventArgs> downloadComplete;
        public event EventHandler<deleteCompleteEventArgs> deleteComplete;
        public event EventHandler<uploadCompleteEventArgs> uploadComplete;
        public event EventHandler<downloadProgressEventArgs> downloadProgress;
        public event EventHandler<uploadProgressEventArgs> uploadProgress;
        public event EventHandler<statusChangeEventArgs> statusChange;
        public event EventHandler<mkDirRemoteCompleteEventArgs> mkDirRemoteComplete;

        public System.Threading.SynchronizationContext context;

        internal bool isConnected = false;

        private string _username = "";
        private string _password = "";

        #region События
        void OnDownloadComplete(string filename) {
            //save delegate field in a temporary field for thread-safety
            EventHandler<downloadCompleteEventArgs> temp = downloadComplete;

            if (temp != null) {
                //if there is a listener who as asked for notification, then give away!
                downloadCompleteEventArgs e = new downloadCompleteEventArgs();
                e.filename = filename;
                //temp(this, e);
                context.Post(delegate (object state) { downloadComplete(this, e); }, null);
            }
        }

        void onmkDirRemoteComplete(string filename) {
            //save delegate field in a temporary field for thread-safety
            EventHandler<mkDirRemoteCompleteEventArgs> temp = mkDirRemoteComplete;

            if (temp != null) {
                //if there is a listener who as asked for notification, then give away!
                mkDirRemoteCompleteEventArgs e = new mkDirRemoteCompleteEventArgs();
                e.filename = filename;
                //temp(this, e);
                context.Post(delegate (object state) { mkDirRemoteComplete(this, e); }, null);
            }
        }

        void OnDeleteComplete(string filename) {
            EventHandler<deleteCompleteEventArgs> temp = deleteComplete;

            if (temp != null) {
                //if there is a listener who as asked for notification, then give away!
                deleteCompleteEventArgs e = new deleteCompleteEventArgs();
                e.filename = filename;
                //uploadComplete(this, e);
                context.Post(delegate (object state) { deleteComplete(this, e); }, null);
            }
        }

        void OnUploadComplete(string filename) {
            //save delegate field in a temporary field for thread-safety
            EventHandler<uploadCompleteEventArgs> temp = uploadComplete;

            if (temp != null) {
                //if there is a listener who as asked for notification, then give away!
                uploadCompleteEventArgs e = new uploadCompleteEventArgs();
                e.filename = filename;
                //uploadComplete(this, e);
                context.Post(delegate (object state) { uploadComplete(this, e); }, null);
            }
        }

        void OnDownloadProgress(string filename, int bytesTransferred, int totalBytes) {
            EventHandler<downloadProgressEventArgs> temp = downloadProgress;
            if (temp != null) {
                downloadProgressEventArgs e = new downloadProgressEventArgs();
                e.filename = filename;
                e.bytesTransferred = bytesTransferred;
                e.totalBytes = totalBytes;
                //downloadProgress(this, e);
                //temp(this, e);
                context.Post(delegate (object state) { downloadProgress(this, e); }, null);
            }
        }

        void OnUploadProgress(string filename, long bytesTransferred) {
            EventHandler<uploadProgressEventArgs> temp = uploadProgress;
            if (temp != null) {
                uploadProgressEventArgs e = new uploadProgressEventArgs();
                e.filename = filename;
                e.bytesTransferred = bytesTransferred;
                //uploadProgress(this, e);
                context.Post(delegate (object state) { uploadProgress(this, e); }, null);
            }
        }

        internal void OnStatusChange(string message, long uploaded, long downloaded) {
            //save delegate field in a temporary field for thread-safety
            EventHandler<statusChangeEventArgs> temp = statusChange;

            if (temp != null) {
                //if there is a listener who as asked for notification, then give away!
                statusChangeEventArgs e = new statusChangeEventArgs();
                e.message = message;
                e.bytesUploaded = uploaded;
                e.bytesDownloaded = downloaded;
                //statusChange(this, e);
                context.Post(delegate (object state) { statusChange(this, e); }, null);
            }
        }
        #endregion

        internal ftp() {
            context = SynchronizationContext.Current;
        } //hide constructor from the outside world.

        //tests connection and browse to home-directory
        public List<ftpinfo> connect(string host, string username, string password) {
            this._username = username;
            this._password = password;

            //FtpWebRequest.Create(host); //test connect;
            context = SynchronizationContext.Current;

            return browse(host);
        }

        public string deleteFile(string path) {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential(_username, _password);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) {
                OnDeleteComplete(response.StatusDescription);
                return response.StatusDescription;
            }
        }

        public string renameFile(string path, string newName)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
                request.Method = WebRequestMethods.Ftp.Rename;
                request.Credentials = new NetworkCredential(_username, _password);
                request.RenameTo = newName;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    OnDeleteComplete(response.StatusDescription);
                    return response.StatusDescription;
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return "Ошибка при создании: " + ex.Message;
            }
        }

        public string deleteFolder(string path) {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
            request.Method = WebRequestMethods.Ftp.RemoveDirectory;
            request.Credentials = new NetworkCredential(_username, _password);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) {
                OnDeleteComplete(response.StatusDescription);
                return response.StatusDescription;
            }
        }

        public string makeRemoteDirectory(string path) {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(_username, _password);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    onmkDirRemoteComplete(response.StatusDescription);
                    return response.StatusDescription;
                }
            }
                
            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return "Ошибка при создании: " + ex.Message;
            }
        }


        public List<ftpinfo> browse(string path) //eg: "ftp.xyz.org", "ftp.xyz.org/ftproot/etc"
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(path);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            List<ftpinfo> files = new List<ftpinfo>();

            //request.Proxy = System.Net.WebProxy.GetDefaultProxy();
            //request.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            request.Credentials = new NetworkCredential(_username, _password);
            Stream rs = (Stream)request.GetResponse().GetResponseStream();

            OnStatusChange("CONNECTED: " + path, 0, 0);

            StreamReader sr = new StreamReader(rs);
            string strList = sr.ReadToEnd();
            string[] lines = null;

            if (strList.Contains("\r\n")) {
                lines = strList.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            } else if (strList.Contains("\n")) {
                lines = strList.Split(new string[] { "\n" }, StringSplitOptions.None);
            }

            //now decode this string array

            if (lines == null || lines.Length == 0)
                return null;

            foreach (string line in lines) {
                if (line.Length == 0)
                    continue;
                //parse line
                Match m = GetMatchingRegex(line);
                if (m == null) {
                    //failed
                    throw new ApplicationException("Unable to parse line: " + line);
                }

                ftpinfo item = new ftpinfo();
                item.filename = m.Groups["name"].Value.Trim('\r');
                item.path = path;
                item.size = Convert.ToInt64(m.Groups["size"].Value);
                item.permission = m.Groups["permission"].Value;
                string _dir = m.Groups["dir"].Value;
                if (_dir.Length > 0 && _dir != "-") {
                    item.fileType = directionEntryTypes.directory;
                } else {
                    item.fileType = directionEntryTypes.file;
                }

                try {
                    item.fileDateTime = DateTime.Parse(m.Groups["timestamp"].Value);
                }
                catch {
                    item.fileDateTime = DateTime.MinValue; //null;
                }

                files.Add(item);
            }

            return files;
        }

        public string createRemoteDirectory(fileinfo file) {
            //System.IO.FileInfo info = new FileInfo(file.completeFileName);
            //This is actually a directory:
            string filename = file.completeFileName;//.Substring(file.completeFileName.LastIndexOf(@"\") + 1);
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(file.destination);
            request.Credentials = new NetworkCredential(_username, _password);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.UseBinary = true;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            return response.StatusDescription;
            //request.UseBinary = true;
            //request.ContentLength = info.Length;
        }

        public void download(fileinfo file) {
            Console.WriteLine("...::: BEFORE DOWNLOAD :::...");
                System.IO.FileInfo info = new FileInfo(file.destination);
                if (info.Exists)
                    info.Delete();
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(file.completeFileName);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.UseBinary = true;
            request.UsePassive = true;
            request.KeepAlive = true;
            request.Timeout = 600000;
            request.Credentials = new NetworkCredential(_username, _password);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream rs = response.GetResponseStream();
            rs.ReadTimeout = 600000;
            rs.WriteTimeout = 600000;
            FileStream fs = info.Create();
            int fileSize = Convert.ToInt32(response.ContentLength);
            try
            {
                /*
                int bufferSize=4096;
                byte[] bytes=new byte[bufferSize];
                int totBytes=0;
                int read=0;
                do
                {
                    read = rs.Read(bytes,0,bufferSize);
                    fs.Write(bytes,0,read);
                    totBytes+=read;
                    OnDownloadProgress(file.completeFileName, totBytes, fileSize);
                    Console.WriteLine(file.completeFileName + " Скачано: " + totBytes);
                } while (read == bufferSize);
                */
                long length = response.ContentLength;
                int bufferSize = 4096;
                int readCount;
                byte[] buffer = new byte[4096];

                readCount = rs.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    fs.Write(buffer, 0, readCount);
                    readCount = rs.Read(buffer, 0, bufferSize);
                    OnDownloadProgress(file.completeFileName, 66, fileSize);
                    Console.WriteLine(file.completeFileName + " Скачано: " + buffer);
                }


                OnDownloadComplete(file.completeFileName);
            }
            catch (Exception ex)
            {
                OnStatusChange("Error occured: " + ex.Data,0,0);
            }
            finally{
                Console.WriteLine("...::: CLOSE STREAMS :::...");
                fs.Close();
                rs.Close();
            }

                /*using (WebClient request = new WebClient())
                {
                    request.Credentials = new NetworkCredential(_username, _password);
                    byte[] fileData = request.DownloadData(file.completeFileName);

                    using (FileStream fs = File.Create(file.destination))
                    {
                        fs.Write(fileData, 0, fileData.Length);
                        fs.Close();
                    }
                    
                } */
        }

        public void upload(fileinfo file) {
            System.IO.FileInfo info = new FileInfo(file.completeFileName);
            string filename = file.completeFileName.Substring(file.completeFileName.LastIndexOf(@"\") + 1);
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(file.destination + "/" + filename);
            request.Credentials = new NetworkCredential(_username, _password);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UseBinary = true;
            request.ContentLength = info.Length;

            int bufferSize = 2048;
            byte[] bytes = new byte[bufferSize];
            int read = 0;
            long totBytes = 0;
            Stream rs = request.GetRequestStream();
            using (FileStream fs = info.OpenRead()) {
                try {
                    do {
                        read = fs.Read(bytes, 0, bufferSize);
                        rs.Write(bytes, 0, read);
                        totBytes += read;
                        //TODO: Raise status event to notify the bytes transferred
                        OnUploadProgress(file.completeFileName, totBytes);
                    } while (read == bufferSize);
                    OnUploadComplete(file.completeFileName);
                }
                catch { }
                finally {
                    fs.Close();
                }
            }
            rs.Close();
            request = null;
            return;
        }

        private Match GetMatchingRegex(string line) {
            string[] formats = {
                        @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\w+\s+\w+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{4})\s+(?<name>.+)" ,
                        @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\d+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{4})\s+(?<name>.+)" ,
                        @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\d+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{1,2}:\d{2})\s+(?<name>.+)" ,
                        @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})\s+\d+\s+\w+\s+\w+\s+(?<size>\d+)\s+(?<timestamp>\w+\s+\d+\s+\d{1,2}:\d{2})\s+(?<name>.+)" ,
                        @"(?<dir>[\-d])(?<permission>([\-r][\-w][\-xs]){3})(\s+)(?<size>(\d+))(\s+)(?<ctbit>(\w+\s\w+))(\s+)(?<size2>(\d+))\s+(?<timestamp>\w+\s+\d+\s+\d{2}:\d{2})\s+(?<name>.+)" ,
                        @"(?<timestamp>\d{2}\-\d{2}\-\d{2}\s+\d{2}:\d{2}[Aa|Pp][mM])\s+(?<dir>\<\w+\>){0,1}(?<size>\d+){0,1}\s+(?<name>.+)"};
            Regex rx;
            Match m;
            for (int i = 0; i < formats.Length; i++)  //As Integer = 0 To formats.Length - 1
            {
                rx = new Regex(formats[i]);
                m = rx.Match(line);
                if (m.Success) {
                    return m;
                }
            }
            return null;
        }
    }
}
