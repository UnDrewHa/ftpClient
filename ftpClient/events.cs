using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftpClient {
    public class downloadCompleteEventArgs : EventArgs {
        public string filename;
    }

    public class deleteCompleteEventArgs : EventArgs {
        public string filename;
    }

    public class mkDirRemoteCompleteEventArgs : EventArgs {
        public string filename;
    }

    public class uploadCompleteEventArgs : EventArgs {
        public string filename;
    }
    public class downloadProgressEventArgs : EventArgs {
        public string filename;
        public int bytesTransferred;
        public int totalBytes;
    }

    public class uploadProgressEventArgs : EventArgs {
        public string filename;
        public long bytesTransferred;
    }

    public class statusChangeEventArgs : EventArgs {
        public string message;
        public long bytesUploaded = 0;
        public long bytesDownloaded = 0;
    }
}
