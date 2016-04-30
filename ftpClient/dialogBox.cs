using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ftpClient {
    public partial class dialogBox : Form {
        MainForm mainForm;
        public dialogBox() {
            InitializeComponent();
            
        }

        public string _formName
        {
            set
            {
                this.Text = value;
            }
        }
        public string _tboxName
        {
            set
            {
                tboxNameOf.Text = value;
            }
        }
        public string _btnName
        {
            set
            {
                btnCreate.Text = value;
            }
        }

        public string prop
        {
            get
            {
                return tboxNameOf.Text;
            }
        }


    }
}
