namespace DavalaAdmin.폼쓰
{
    partial class CategoryEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryEditor));
            this.treeViewCategoryList = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.addMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.최상위분류ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.하위분류ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.addMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewCategoryList
            // 
            this.treeViewCategoryList.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.treeViewCategoryList.Location = new System.Drawing.Point(16, 13);
            this.treeViewCategoryList.Name = "treeViewCategoryList";
            this.treeViewCategoryList.Size = new System.Drawing.Size(446, 275);
            this.treeViewCategoryList.TabIndex = 0;
            this.treeViewCategoryList.DoubleClick += new System.EventHandler(this.treeViewCategoryList_DoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(71, 293);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(203, 21);
            this.textBox1.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(306, 291);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "등 록";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(387, 291);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 3;
            this.buttonRemove.Text = "삭 제";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // addMenu
            // 
            this.addMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.최상위분류ToolStripMenuItem,
            this.하위분류ToolStripMenuItem});
            this.addMenu.Name = "contextMenuStrip1";
            this.addMenu.Size = new System.Drawing.Size(139, 48);
            // 
            // 최상위분류ToolStripMenuItem
            // 
            this.최상위분류ToolStripMenuItem.Name = "최상위분류ToolStripMenuItem";
            this.최상위분류ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.최상위분류ToolStripMenuItem.Text = "최상위 분류";
            this.최상위분류ToolStripMenuItem.Click += new System.EventHandler(this.최상위분류ToolStripMenuItem_Click);
            // 
            // 하위분류ToolStripMenuItem
            // 
            this.하위분류ToolStripMenuItem.Name = "하위분류ToolStripMenuItem";
            this.하위분류ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.하위분류ToolStripMenuItem.Text = "하위 분류";
            this.하위분류ToolStripMenuItem.Click += new System.EventHandler(this.하위분류ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(16, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "이름 : ";
            // 
            // CategoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 323);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.treeViewCategoryList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "카테고리 선택";
            this.Load += new System.EventHandler(this.CategoryEditor_Load);
            this.addMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewCategoryList;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ContextMenuStrip addMenu;
        private System.Windows.Forms.ToolStripMenuItem 최상위분류ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 하위분류ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}