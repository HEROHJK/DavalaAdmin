using DavalaAdmin.데이터베이쓰;
using DavalaAdmin.데이터포맷들;
using DavalaAdmin.폼쓰;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DavalaAdmin
{
    public partial class mainForm : Form
    {
        static string imageExetensions = "그림 파일(*.jpg, *.gif, *.bmp, *.png) | *.jpg; *.gif; *.bmp; *.png;";
        static string dbLoginInfo = "";
        public mainForm()
        {
            InitializeComponent();
        }

        private void pictureBoxBaseImage_Click(object sender, EventArgs e)
        {
            try
            {
                string path = GetFileRoute(imageExetensions);
                pictureBoxBaseImage.Image = Bitmap.FromFile(path);
                linkLabel1.Text = path;
            }
            catch
            {
               
            }
        }

        private string GetFileRoute(string exetension)
        {
            //파일을 열어서 경로를 가져오는 함수
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "파일을 선택 하세요";
            openDialog.Filter = exetension;

            DialogResult result = openDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                return openDialog.FileName;
            }
            else
            {
                return "";
            }
        }
        private string[] GetFileRoutes(string extension)
        {
            //파일을 열어서 경로를 가져오는 함수
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "파일을 선택 하세요";
            openDialog.Filter = extension;
            openDialog.Multiselect = true;

            DialogResult result = openDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                return openDialog.FileNames;
            }
            else
            {
                return new string[0];
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string[] routes = GetFileRoutes(imageExetensions);

            if (routes.Length < 1) return;

            foreach (string route in routes)
            {
                dataGridView1.Rows.Add(route);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;
            foreach(DataGridViewRow row in selectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void InsertButtonClick(object sender, EventArgs e)
        {
            //등록 프로세서
            ProductManagement pm = new ProductManagement(dbLoginInfo);
            FTPManager fm = new FTPManager(Properties.Settings.Default.ftpAddress, Properties.Settings.Default.ftpID, Properties.Settings.Default.ftpPW, Properties.Settings.Default.ftpPort);
            int index;

            //1. DB에 제품정보를 등록한다.
            index = pm.InsertProductData(textBoxProductName.Text,GetIndex("브랜드"),GetIndex("카테고리"),Convert.ToDecimal(textBoxPrice.Text));
            if (index == -1)
            {
                MessageBox.Show("제품 등록에 실패하였습니다.");
                return;
            }
            //2. FTP에 올릴파일이름을 추출한다.
            ImageInfo info = GetImageInfo(index);
            //3. FTP에 파일을 업로드한다.
            if(!fm.UploadFiles(info.paths, info.names))
            {
                MessageBox.Show("이미지파일 업로드에 실패하였습니다.");
                pm.DeleteProductData(index);
                return;
            }
            //4. DB에 URL을 등록한다.
            if(!pm.InsertProductImages(info.urls, index))
            {
                MessageBox.Show("이미지정보 등록에 실패하였습니다.");
                pm.DeleteProductData(index);
                fm.DeleteFiles(info.names);
                return;
            }
            MessageBox.Show("등록 완료");

            ClearInsertInfo();
        }

        private void ClearInsertInfo()
        {
            //항목 초기화
            textBoxProductName.Text = "";
            textBoxPrice.Text = "";
            comboBoxBrand.SelectedIndex = 0;
            buttonCategory.Text = "";
            linkLabel1.Text = "";
            dataGridView1.Rows.Clear();
            pictureBoxBaseImage.Image = Properties.Resources.defaultImage;
        }

        private int GetIndex(string category)
        {
            if (category == "브랜드")
            {
                string tmp = comboBoxBrand.Text.Substring(0,3);
                return Convert.ToInt32(tmp);
            }
            else if (category == "카테고리")
            {
                string tmp = buttonCategory.Text.Substring(0, 3);
                return Convert.ToInt32(tmp);
            }
            else return -1;
        }
        private ImageInfo GetImageInfo(int index)
        {
            //갯수를 구한다.
            ImageInfo info = new ImageInfo(dataGridView1.Rows.Count);
            //첫 이미지를 넣는다.
            info.paths[0] = linkLabel1.Text;
            info.names[0] = string.Format("{0}_main.{1}",index, GetExtension(linkLabel1.Text));
            info.urls[0] = string.Format("http://hjknas.asuscomm.com:2323/image/{0}",info.names[0]);
            //서브이미지들을 넣는다
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                info.paths[i] = row.Cells[0].Value.ToString();
                info.names[i] = string.Format("{0}_{1}.{2}", index, i, GetExtension(row.Cells[0].Value.ToString()));
                info.urls[i] = string.Format("http://hjknas.asuscomm.com:2323/image/{0}", info.names[i]);
                i++;
            }

            return info;
            //..
        }

        private string GetExtension(string path)
        {
            try
            {
                return path.Substring(path.Length - 3, 3);
            }
            catch
            {
                return "error";
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Process.Start(dataGridView1.Rows[dataGridView1.CurrentCellAddress.Y].Cells[0].Value.ToString());
            }
            catch { }
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.dbAddress == "")
            {
                InfoInsert ii = new InfoInsert();
                ii.ShowDialog();
            }

            SetServerInfo();

            //브랜드 불러오기
            BrandManagement bm = new BrandManagement(dbLoginInfo);
            string[] brands = bm.LoadBrand();
            foreach(string brandName in brands)
            {
                comboBoxBrand.Items.Add(brandName);
            }
        }

        private void SetServerInfo()
        {
            dbLoginInfo = string.Format("Server={0};Port={1};Database=davala;Uid={2};Pwd={3}", Properties.Settings.Default.dbAddress, Properties.Settings.Default.dbPort, Properties.Settings.Default.dbID, Properties.Settings.Default.dbPW);

        }

        private void ButtonEditClick(object sender, EventArgs e)
        {
            BrandEditor be = new BrandEditor();
            be.ShowDialog();

            //브랜드 리로드
            comboBoxBrand.Items.Clear();
            BrandManagement bm = new BrandManagement(dbLoginInfo);
            string[] brands = bm.LoadBrand();
            foreach (string brandName in brands)
            {
                comboBoxBrand.Items.Add(brandName);
            }
        }

        private void buttonCategory_Click(object sender, EventArgs e)
        {
            CategoryEditor ce = new CategoryEditor(this);
            ce.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel1.Text);
        }

        private string GetDirectory(string path)
        {
            return path.Substring(0,path.LastIndexOf('\\'));
        }

        private string GetFileName(string path)
        {
            return path.Substring(path.LastIndexOf('\\')+1, path.Length - path.LastIndexOf('\\')-1);
        }
    }
}
