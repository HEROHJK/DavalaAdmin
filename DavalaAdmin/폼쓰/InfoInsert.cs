using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DavalaAdmin.폼쓰
{
    public partial class InfoInsert : Form
    {
        public InfoInsert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dbAddress = textBoxAddress.Text;
            Properties.Settings.Default.dbPort = textBoxPort.Text;
            Properties.Settings.Default.dbID = textBoxID.Text;
            Properties.Settings.Default.dbPW = textBoxPassword.Text;

            Properties.Settings.Default.ftpAddress = textBoxAddressFTP.Text;
            Properties.Settings.Default.ftpPort = textBoxPortFTP.Text;
            Properties.Settings.Default.ftpID = textBoxIDFTP.Text;
            Properties.Settings.Default.ftpPW = textBoxPasswordFTP.Text;

            Properties.Settings.Default.Save();

            this.Close();
        }
    }
}
