using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavalaAdmin.데이터베이쓰
{
    class FTPManager
    {
        string url = "";
        string id = "";
        string pw = "";
        int port;
        string ftpDirectory = "/var/www/html/image/";

        public FTPManager(string url, string id, string pw, string port)
        {
            this.url = url;
            this.id = id;
            this.pw = pw;
            this.port = Convert.ToInt32(port);
        }

        public bool Upload(string filePath, string name)
        {
            try
            {
                SftpClient client = new SftpClient(url, port, id, pw);

                client.Connect();
                if (client.IsConnected)
                {
                    FileStream fs = new FileStream(filePath, FileMode.Open);
                    client.UploadFile(fs, ftpDirectory + name, null);
                    client.Disconnect();
                }
                client.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UploadFiles(string[] filePath, string[] names)
        {
            try
            {
                SftpClient client = new SftpClient(url, port, id, pw);

                client.Connect();
                if (client.IsConnected)
                {
                    for (int i = 0; i < filePath.Length; i++)
                    {
                        FileStream fs = new FileStream(filePath[i], FileMode.Open,FileAccess.Read,FileShare.ReadWrite);
                        client.UploadFile(fs, ftpDirectory + names[i], null);
                    }
                    client.Disconnect();
                }
                client.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteFiles(string[] names)
        {
            try
            {
                //파일을 삭제한다
                SftpClient client = new SftpClient(url, port, id, pw);

                client.Connect();
                if (client.IsConnected)
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        client.DeleteFile(ftpDirectory + names[i]);
                    }
                    client.Disconnect();
                }
                client.Dispose();
            }
            catch
            {

            }
        }
    }
}