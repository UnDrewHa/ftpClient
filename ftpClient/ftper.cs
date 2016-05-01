using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Net;

namespace ftpClient {
    public class ftper {
        public bool loggingEnabled = false;

        public ftp ftpObject = new ftp();
        private System.Collections.Hashtable queue = new Hashtable();
        private bool _threadRunning = false;

        ~ftper() {
            ftpObject = null;
            queue = null;
        }

        public bool isProcessing() {
            return _threadRunning; 
        }

        public List<ftpinfo> connect(string host, string username, string password, bool all = true) {
            return ftpObject.connect(host, username, password);
        }

        public void disconnect() {
            if (_threadRunning) {
                _threadRunning = false;
            }

            int timeout = 60; 
            DateTime start = DateTime.Now;
            while (queue.Count == 0) 
            {
                if (DateTime.Now.Subtract(start).Seconds > timeout)
                    break;
            }
        }

        public List<ftpinfo> browse(string path) {
            return ftpObject.browse(path);
        }

        public string deleteFile(string path) {
            return ftpObject.deleteFile(path);
        }

        public string renameFile(string path, string newName)
        {
            return ftpObject.renameFile(path, newName);
        }
        public string mkRemoteFolder(string path) {
            return ftpObject.makeRemoteDirectory(path);
        }

        public void deleteFolder(string path) {
                List<ftpinfo> contents = ftpObject.browse(path);
                if (contents == null)
                {
                    string fullPath = path;
                    string subStr = "//";
                    int index = fullPath.LastIndexOf(subStr);
                    if (index > 5)
                        fullPath = fullPath.Remove(index, 1);
                    ftpObject.deleteFolder(fullPath);
                    return;
                }

                for (int i = 0; i < contents.Count; i++)
                {
                    if (contents[i].fileType == directionEntryTypes.file)
                    {
                        string fullPath = path + "/" + contents[i].filename;
                        string subStr = "//";
                        int index = fullPath.LastIndexOf(subStr);
                        if (index > 5)
                            fullPath = fullPath.Remove(index, 1);
                        deleteFile(fullPath);
                    }
                    else {
                        string fullPath = path + "/" + contents[i].filename;
                        string subStr = "//";
                        int index = fullPath.LastIndexOf(subStr);
                        if (index > 5)
                            fullPath = fullPath.Remove(index, 1);
                        deleteFolder(fullPath);
                    }
                }

                string fp = path;
                string ss = "//";
                int ind = fp.LastIndexOf(ss);
                if (ind > 5)
                    fp = fp.Remove(ind, 1);
                ftpObject.deleteFolder(fp);

        }

        public void addFolderToUploadQueue(string path, string remoteDestination) {

            mkRemoteFolder(remoteDestination);

            string[] contents = Directory.GetDirectories(path);
            for (int i = 0; i < contents.Length; i++)
            {
                string filePart = StringUtils.ExtractFileFromPath(contents[i], @"\");
                addFolderToUploadQueue(contents[i], remoteDestination + "/" + filePart);
            }

            contents = Directory.GetFiles(path);
            for (int i = 0; i < contents.Length; i++) {
                addFileToUploadQueue(contents[i], remoteDestination);
            }

            
        }


        public void addFileToUploadQueue(string localFileName, string remoteDestination) {
            if (File.Exists(localFileName)) {
                queue.Add(localFileName, new fileinfo(localFileName, remoteDestination, directionEnum.up));
            } else {
                throw new Exception("Incorrect file path: " + localFileName);
            }
        }

        public void removeFilesFromUploadQueue(string[] localFileName) {
            foreach (string s in localFileName) {
                if (queue.ContainsKey(s)) {
                    queue.Remove(s);
                }
            }
        }

        public void addFolderToDownloadQueue(string path, string localDestination) {
            if (Directory.Exists(localDestination) == false) {
                Directory.CreateDirectory(localDestination);
            }
            List<ftpinfo> contents = ftpObject.browse(path);
            if (contents == null)
                return;
            for (int i = 0; i < contents.Count; i++) {
                if (contents[i].fileType == directionEntryTypes.file) {
                    string fullPath = contents[i].path + "/" + contents[i].filename;
                    string fullLocalPath = localDestination + @"\" + contents[i].filename;
                    string subStr = "//";
                    int index = fullPath.LastIndexOf(subStr);
                    if (index > 5)
                        fullPath = fullPath.Remove(index, 1);
                    addFileToDownloadQueue(fullPath, fullLocalPath);
                } else {
                    addFolderToDownloadQueue(path + "/" + contents[i].filename, localDestination + @"\" + contents[i].filename);
                }
            }
        }

        public void addFileToDownloadQueue(string remotefilename, string localDestination) {
            Console.WriteLine("В очередь: " + remotefilename);
            queue.Add(remotefilename, new fileinfo(remotefilename, localDestination, directionEnum.down));
        }

        public void removeFilesFromDownloadQueue(string[] remotefilename) {
            foreach (string s in remotefilename) {
                if (queue.Contains(s)) {
                    queue.Remove(s);
                } else {
                    throw new Exception("File does not exist: " + s);
                }
            }
        }

        public void startProcessing() {
            _threadRunning = true;
            Console.WriteLine("Started download/upload");
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadForProcessQueue));
        }

        public void stopProcessing() {
            _threadRunning = false;
        }

        private void ThreadForProcessQueue(object stateInfo) {

            try {
                while (_threadRunning && queue.Count > 0) {

                    object[] keys = new object[queue.Keys.Count];
                    queue.Keys.CopyTo(keys, 0);
                    fileinfo nextitem = (fileinfo)queue[keys[0]]; 
                    if (nextitem.mkdirFlag) {
                        ftpObject.createRemoteDirectory(nextitem);
                    } else {
                        if (nextitem.direction == directionEnum.down) {
                            ftpObject.download(nextitem);
                        } else {
                            ftpObject.upload(nextitem);
                        }
                    }

                    queue.Remove(nextitem.completeFileName);
                }
            }
            catch (WebException ex) {
                Console.WriteLine("Error!:" + ex.Data.ToString());
            }
            finally {
                _threadRunning = false;
                queue.Clear();
            }
        }

    }

    public class fileinfo {
        public directionEnum direction = directionEnum.down;
        public string completeFileName = "";
        public string destination = "";
        public bool mkdirFlag = false;
        public long size;

        //to upload
        public fileinfo(string fileName, string destination, directionEnum direction, bool mkdirFlag) {
            this.completeFileName = fileName;
            this.destination = destination;
            this.direction = direction;
            this.mkdirFlag = mkdirFlag;
        }

        public fileinfo(string fileName, string destination, directionEnum direction)
            : this(fileName, destination, direction, false) {
        }
    }

    public enum directionEnum {
        up, down
    }

    public enum directionEntryTypes {
        file = 0,
        directory = 1
    }

    public class ftpinfo {
        public string filename;
        public string path;
        public directionEntryTypes fileType;
        public long size;
        public string permission;
        public DateTime fileDateTime;
    }
}
