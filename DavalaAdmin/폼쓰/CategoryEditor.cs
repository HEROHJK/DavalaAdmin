using DavalaAdmin.데이터베이쓰;
using DavalaAdmin.데이터포맷들;
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

namespace DavalaAdmin.폼쓰
{
    public partial class CategoryEditor : Form
    {
        CategoryManagement cm;
        mainForm main;
        public CategoryEditor(mainForm form)
        {
            InitializeComponent();
            cm = new CategoryManagement("Server=hjknas.asuscomm.com;Port=3333;Database=davala;Uid=davalaAdmin;Pwd=admin2$%");
            main = form;
        }

        private void CategoryEditor_Load(object sender, EventArgs e)
        {
            CategoryLoad();
        }

        private TreeNode SetTreeView(CategoryFormat df)
        {
            TreeNode tmpNode = new TreeNode(string.Format("{0:000} | {1} | {2:000}", df.index, df.name, df.parentIndex));
            for (int i = 0; i < df.childList.Count; i++)
            {
                tmpNode.Nodes.Add(SetTreeView(df.childList[i]));
            }

            return tmpNode;
        }

        private void treeViewCategoryList_DoubleClick(object sender, EventArgs e)
        {
            main.buttonCategory.Text = treeViewCategoryList.SelectedNode.Text;
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            addMenu.Show(new Point(x, y));
        }

        private void 하위분류ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int parentIndex = Convert.ToInt32(Convert.ToInt32(treeViewCategoryList.SelectedNode.Text.Substring(0, 3)));
            if (cm.AddCategory(parentIndex, textBox1.Text))
            {
                textBox1.Text = "";
                CategoryLoad();
            }
            else
            {
                MessageBox.Show("등록에 실패했습니다");
            }
        }

        private void 최상위분류ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cm.AddCategory(0, textBox1.Text))
            {
                textBox1.Text = "";
                CategoryLoad();
            }
            else
            {
                MessageBox.Show("등록에 실패했습니다");
            }
        }

        private void CategoryLoad()
        {
            //트리뷰 초기화
            treeViewCategoryList.Nodes.Clear();

            //카테고리 목록을 불러온다.
            List<CategoryFormat> cfList = cm.GetCategories();

            //적재
            foreach (CategoryFormat cf in cfList)
            {
                treeViewCategoryList.Nodes.Add(SetTreeView(cf));
            }
            //다 펼친다
            treeViewCategoryList.ExpandAll();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (cm.RemoveCategory(Convert.ToInt32(treeViewCategoryList.SelectedNode.Text.Substring(0, 3)))){
                CategoryLoad();
            }
            else
            {
                MessageBox.Show("삭제에 실패했습니다");
            }
        }
    }
}