using DavalaAdmin.데이터베이쓰;
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
    public partial class BrandEditor : Form
    {
        BrandManagement bm;
        public BrandEditor()
        {
            InitializeComponent();
            bm = new BrandManagement("Server=hjknas.asuscomm.com;Port=3333;Database=davala;Uid=davalaAdmin;Pwd=admin2$%");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxBrandName.Text != "")
            {
                if (bm.AddBrand(textBoxBrandName.Text))
                {
                    textBoxBrandName.Text = "";
                    dataGridView1.Rows.Clear();
                    string[] brands = bm.LoadBrand();
                    foreach (string brandName in brands)
                    {
                        string[] row = { brandName.Substring(0, 3), brandName.Substring(4, brandName.Length - 4) };
                        dataGridView1.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("등록에 실패했습니다.");
                }
            }
            else
            {
                MessageBox.Show("이름을 입력해주세요");
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (bm.RemoveBrand(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value)))
                {
                    dataGridView1.Rows.Clear();
                    string[] brands = bm.LoadBrand();
                    foreach (string brandName in brands)
                    {
                        string[] row = { brandName.Substring(0, 3), brandName.Substring(4, brandName.Length - 4) };
                        dataGridView1.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("삭제에 실패했습니다.");
                }
            }
            else
            {
                MessageBox.Show("삭제할 브랜드를 선택 해 주세요");
            }
        }

        private void BrandEditor_Load(object sender, EventArgs e)
        {
            //브랜드 목록을 불러온다
            string[] brands = bm.LoadBrand();
            foreach (string brandName in brands)
            {
                string[] row = { brandName.Substring(0, 3), brandName.Substring(4, brandName.Length - 4) };
                dataGridView1.Rows.Add(row);
            }
        }

        private void BrandEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }
    }
}
