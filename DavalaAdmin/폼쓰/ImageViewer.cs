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
    public partial class ImageViewer : Form
    {
        public ImageViewer(Image img)
        {
            InitializeComponent();
            int width = (img.Width / GCD(img.Width, img.Height)) * 50;
            int height = (img.Height / GCD(img.Width, img.Height)) * 50;
            this.Width = width;
            this.Height = height;
            this.pictureBox1.Image = img;
        }

        private int GCD(int a, int b)
        {
            int Remainder;

            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }

        private void ImageViewer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ImageViewer_Leave(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImageViewer_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImageViewer_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}