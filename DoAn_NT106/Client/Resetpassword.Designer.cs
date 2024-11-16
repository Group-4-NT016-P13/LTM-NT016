namespace Client
{
    partial class Resetpassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resetpassword));
            this.ShowPassword_btn = new System.Windows.Forms.PictureBox();
            this.Password_lb = new System.Windows.Forms.Label();
            this.Password_txt = new System.Windows.Forms.TextBox();
            this.ShowComfirm_btn = new System.Windows.Forms.PictureBox();
            this.Comfirm_lb = new System.Windows.Forms.Label();
            this.Comfirm_txt = new System.Windows.Forms.TextBox();
            this.ChessOnline_tlt = new System.Windows.Forms.Label();
            this.Message_lb = new System.Windows.Forms.Label();
            this.Return_btn = new System.Windows.Forms.Button();
            this.Comfirm_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassword_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowComfirm_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowPassword_btn
            // 
            this.ShowPassword_btn.Image = ((System.Drawing.Image)(resources.GetObject("ShowPassword_btn.Image")));
            this.ShowPassword_btn.Location = new System.Drawing.Point(310, 196);
            this.ShowPassword_btn.Name = "ShowPassword_btn";
            this.ShowPassword_btn.Size = new System.Drawing.Size(37, 31);
            this.ShowPassword_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPassword_btn.TabIndex = 13;
            this.ShowPassword_btn.TabStop = false;
            this.ShowPassword_btn.Click += new System.EventHandler(this.ShowPassword_btn_Click);
            // 
            // Password_lb
            // 
            this.Password_lb.AutoSize = true;
            this.Password_lb.BackColor = System.Drawing.Color.White;
            this.Password_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_lb.Location = new System.Drawing.Point(21, 202);
            this.Password_lb.Name = "Password_lb";
            this.Password_lb.Size = new System.Drawing.Size(142, 21);
            this.Password_lb.TabIndex = 12;
            this.Password_lb.Text = "Mật Khẩu Mới";
            // 
            // Password_txt
            // 
            this.Password_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_txt.Location = new System.Drawing.Point(12, 193);
            this.Password_txt.Name = "Password_txt";
            this.Password_txt.PasswordChar = '*';
            this.Password_txt.Size = new System.Drawing.Size(338, 39);
            this.Password_txt.TabIndex = 1;
            this.Password_txt.TextChanged += new System.EventHandler(this.Password_TextChanged);
            this.Password_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // ShowComfirm_btn
            // 
            this.ShowComfirm_btn.Image = ((System.Drawing.Image)(resources.GetObject("ShowComfirm_btn.Image")));
            this.ShowComfirm_btn.Location = new System.Drawing.Point(310, 284);
            this.ShowComfirm_btn.Name = "ShowComfirm_btn";
            this.ShowComfirm_btn.Size = new System.Drawing.Size(37, 31);
            this.ShowComfirm_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowComfirm_btn.TabIndex = 16;
            this.ShowComfirm_btn.TabStop = false;
            this.ShowComfirm_btn.Click += new System.EventHandler(this.ShowComfirm_btn_Click_1);
            // 
            // Comfirm_lb
            // 
            this.Comfirm_lb.AutoSize = true;
            this.Comfirm_lb.BackColor = System.Drawing.Color.White;
            this.Comfirm_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comfirm_lb.Location = new System.Drawing.Point(21, 290);
            this.Comfirm_lb.Name = "Comfirm_lb";
            this.Comfirm_lb.Size = new System.Drawing.Size(197, 21);
            this.Comfirm_lb.TabIndex = 15;
            this.Comfirm_lb.Text = "Xác Nhận Mật Khẩu";
            // 
            // Comfirm_txt
            // 
            this.Comfirm_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comfirm_txt.Location = new System.Drawing.Point(12, 281);
            this.Comfirm_txt.Name = "Comfirm_txt";
            this.Comfirm_txt.PasswordChar = '*';
            this.Comfirm_txt.Size = new System.Drawing.Size(338, 39);
            this.Comfirm_txt.TabIndex = 2;
            this.Comfirm_txt.TextChanged += new System.EventHandler(this.Comfirm_TextChanged);
            this.Comfirm_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // ChessOnline_tlt
            // 
            this.ChessOnline_tlt.AutoSize = true;
            this.ChessOnline_tlt.BackColor = System.Drawing.Color.Transparent;
            this.ChessOnline_tlt.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChessOnline_tlt.ForeColor = System.Drawing.Color.White;
            this.ChessOnline_tlt.Location = new System.Drawing.Point(42, 47);
            this.ChessOnline_tlt.Name = "ChessOnline_tlt";
            this.ChessOnline_tlt.Size = new System.Drawing.Size(279, 33);
            this.ChessOnline_tlt.TabIndex = 18;
            this.ChessOnline_tlt.Text = "Chess Game Online";
            // 
            // Message_lb
            // 
            this.Message_lb.AutoSize = true;
            this.Message_lb.BackColor = System.Drawing.Color.Transparent;
            this.Message_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message_lb.ForeColor = System.Drawing.Color.White;
            this.Message_lb.Location = new System.Drawing.Point(61, 114);
            this.Message_lb.MaximumSize = new System.Drawing.Size(0, 200);
            this.Message_lb.Name = "Message_lb";
            this.Message_lb.Size = new System.Drawing.Size(241, 21);
            this.Message_lb.TabIndex = 22;
            this.Message_lb.Text = "Hãy nhập mật khẩu mới\r\n";
            // 
            // Return_btn
            // 
            this.Return_btn.BackColor = System.Drawing.Color.White;
            this.Return_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Return_btn.Location = new System.Drawing.Point(90, 419);
            this.Return_btn.Name = "Return_btn";
            this.Return_btn.Size = new System.Drawing.Size(161, 39);
            this.Return_btn.TabIndex = 24;
            this.Return_btn.Text = "Quay Lại";
            this.Return_btn.UseVisualStyleBackColor = false;
            this.Return_btn.Click += new System.EventHandler(this.Return_btn_Click);
            // 
            // Comfirm_btn
            // 
            this.Comfirm_btn.BackColor = System.Drawing.Color.White;
            this.Comfirm_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comfirm_btn.Location = new System.Drawing.Point(90, 344);
            this.Comfirm_btn.Name = "Comfirm_btn";
            this.Comfirm_btn.Size = new System.Drawing.Size(161, 39);
            this.Comfirm_btn.TabIndex = 23;
            this.Comfirm_btn.Text = "Xác Nhận";
            this.Comfirm_btn.UseVisualStyleBackColor = false;
            this.Comfirm_btn.Click += new System.EventHandler(this.Comfirm_btn_Click);
            // 
            // Resetpassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(735, 490);
            this.Controls.Add(this.Return_btn);
            this.Controls.Add(this.Comfirm_btn);
            this.Controls.Add(this.Message_lb);
            this.Controls.Add(this.ChessOnline_tlt);
            this.Controls.Add(this.ShowComfirm_btn);
            this.Controls.Add(this.Comfirm_lb);
            this.Controls.Add(this.Comfirm_txt);
            this.Controls.Add(this.ShowPassword_btn);
            this.Controls.Add(this.Password_lb);
            this.Controls.Add(this.Password_txt);
            this.Name = "Resetpassword";
            this.Text = "Resetpassword";
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassword_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowComfirm_btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ShowPassword_btn;
        private System.Windows.Forms.Label Password_lb;
        private System.Windows.Forms.TextBox Password_txt;
        private System.Windows.Forms.PictureBox ShowComfirm_btn;
        private System.Windows.Forms.Label Comfirm_lb;
        private System.Windows.Forms.TextBox Comfirm_txt;
        private System.Windows.Forms.Label ChessOnline_tlt;
        private System.Windows.Forms.Label Message_lb;
        private System.Windows.Forms.Button Return_btn;
        private System.Windows.Forms.Button Comfirm_btn;
    }
}