namespace DavalaAdmin.폼쓰
{
    partial class InfoInsert
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
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxPasswordFTP = new System.Windows.Forms.TextBox();
            this.textBoxIDFTP = new System.Windows.Forms.TextBox();
            this.textBoxPortFTP = new System.Windows.Forms.TextBox();
            this.textBoxAddressFTP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(12, 43);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(204, 21);
            this.textBoxAddress.TabIndex = 0;
            this.textBoxAddress.Text = "Address";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(222, 43);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(70, 21);
            this.textBoxPort.TabIndex = 1;
            this.textBoxPort.Text = "PORT";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(298, 43);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(70, 21);
            this.textBoxID.TabIndex = 2;
            this.textBoxID.Text = "ID";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(374, 43);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(114, 21);
            this.textBoxPassword.TabIndex = 3;
            this.textBoxPassword.Text = "Password";
            // 
            // textBoxPasswordFTP
            // 
            this.textBoxPasswordFTP.Location = new System.Drawing.Point(374, 109);
            this.textBoxPasswordFTP.Name = "textBoxPasswordFTP";
            this.textBoxPasswordFTP.Size = new System.Drawing.Size(114, 21);
            this.textBoxPasswordFTP.TabIndex = 7;
            this.textBoxPasswordFTP.Text = "Password";
            // 
            // textBoxIDFTP
            // 
            this.textBoxIDFTP.Location = new System.Drawing.Point(298, 109);
            this.textBoxIDFTP.Name = "textBoxIDFTP";
            this.textBoxIDFTP.Size = new System.Drawing.Size(70, 21);
            this.textBoxIDFTP.TabIndex = 6;
            this.textBoxIDFTP.Text = "ID";
            // 
            // textBoxPortFTP
            // 
            this.textBoxPortFTP.Location = new System.Drawing.Point(222, 109);
            this.textBoxPortFTP.Name = "textBoxPortFTP";
            this.textBoxPortFTP.Size = new System.Drawing.Size(70, 21);
            this.textBoxPortFTP.TabIndex = 5;
            this.textBoxPortFTP.Text = "PORT";
            // 
            // textBoxAddressFTP
            // 
            this.textBoxAddressFTP.Location = new System.Drawing.Point(12, 109);
            this.textBoxAddressFTP.Name = "textBoxAddressFTP";
            this.textBoxAddressFTP.Size = new System.Drawing.Size(204, 21);
            this.textBoxAddressFTP.TabIndex = 4;
            this.textBoxAddressFTP.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "DataBase INFO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "SFTP INFO";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(495, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "등 록";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InfoInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 181);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPasswordFTP);
            this.Controls.Add(this.textBoxIDFTP);
            this.Controls.Add(this.textBoxPortFTP);
            this.Controls.Add(this.textBoxAddressFTP);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxAddress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoInsert";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InfoInsert";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxPasswordFTP;
        private System.Windows.Forms.TextBox textBoxIDFTP;
        private System.Windows.Forms.TextBox textBoxPortFTP;
        private System.Windows.Forms.TextBox textBoxAddressFTP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}