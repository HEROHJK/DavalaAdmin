using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DavalaAdmin.데이터베이쓰;
using DavalaAdmin.로직쓰;

namespace DavalaAdmin.폼쓰
{
    public partial class WebCrawler : Form
    {
        string url;
        mainForm main;
        public WebCrawler(mainForm main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch
            {

            }
            this.Close();
        }

        private void LoadData()
        {
            url = textBox1.Text;
            Crawler cr = new Crawler();
            cr.LoadData(url);
            List<string> paths = cr.paths;
            main.textBoxProductName.Text = cr.title;
            main.pictureBoxBaseImage.Image = Bitmap.FromFile(paths[0]);
            main.linkLabel1.Text = paths[0];//등록후 패쓰에서는 뺀다
            main.textBoxPrice.Text = cr.price;
            main.textBoxDiscount.Text = cr.discount;
            main.textBoxDiscountAmount.Text = cr.discountPrice;
            paths.RemoveAt(0);
            main.dataGridView1.Rows.Clear();
            foreach (string path in paths)
            {
                main.dataGridView1.Rows.Add(path);
            }
            //브랜드를 찾아보고 없으면 등록.
            BrandManagement bm = new BrandManagement(mainForm.dbLoginInfo);
            string brandName = cr.title.Substring(cr.title.IndexOf('[') + 1, cr.title.IndexOf(']') - cr.title.IndexOf('[') - 1);
            int index = bm.FindBrandIndex(brandName);
            if (index < 1)
            {
                //브랜드를 등록한다
                bm.AddBrand(brandName);
                //브랜드 리로드
                main.comboBoxBrand.Items.Clear();
                string[] brands = bm.LoadBrand();
                foreach (string name in brands)
                {
                    main.comboBoxBrand.Items.Add(name);
                }
                index = bm.FindBrandIndex(brandName);
            }
            var test = string.Format("{0:000}|{1}", index, brandName);
            main.comboBoxBrand.SelectedItem = string.Format("{0:000}|{1}", index, brandName);

            //카테고리는 선택만(없으면 생략)
            CategoryManagement cm = new CategoryManagement(mainForm.dbLoginInfo);
            index = cm.FindCategory(cr.category);
            if (index > 0)
            {
                string text = string.Format("{0:000} | {1} | {2:000}", index, cr.category, cm.FindParentIndex(index));
                main.buttonCategory.Text = text;
            }
        }

        private void WebCrawler_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                try
                {
                    LoadData();
                }
                catch
                {

                }
                this.Close();
            }
            else if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if(e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    LoadData();
                }
                catch
                {

                }
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
