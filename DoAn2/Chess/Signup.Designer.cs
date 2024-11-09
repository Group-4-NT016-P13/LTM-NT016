﻿namespace Chess
{
    partial class Signup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signup));
            this.ShowComfirm_btn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Signup_btn = new System.Windows.Forms.Button();
            this.Comfirm_lb = new System.Windows.Forms.Label();
            this.Comfirm_txt = new System.Windows.Forms.TextBox();
            this.Username_lb = new System.Windows.Forms.Label();
            this.Username_txt = new System.Windows.Forms.TextBox();
            this.ChessOnline_tlt = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Nickname_lb = new System.Windows.Forms.Label();
            this.Nickname_txt = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Email_lb = new System.Windows.Forms.Label();
            this.Email_txt = new System.Windows.Forms.TextBox();
            this.ShowPassword_btn = new System.Windows.Forms.PictureBox();
            this.Password_lb = new System.Windows.Forms.Label();
            this.Password_txt = new System.Windows.Forms.TextBox();
            this.Return_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ShowComfirm_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassword_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowComfirm_btn
            // 
            this.ShowComfirm_btn.Image = ((System.Drawing.Image)(resources.GetObject("ShowComfirm_btn.Image")));
            this.ShowComfirm_btn.Location = new System.Drawing.Point(310, 331);
            this.ShowComfirm_btn.Name = "ShowComfirm_btn";
            this.ShowComfirm_btn.Size = new System.Drawing.Size(37, 31);
            this.ShowComfirm_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowComfirm_btn.TabIndex = 18;
            this.ShowComfirm_btn.TabStop = false;
            this.ShowComfirm_btn.Click += new System.EventHandler(this.ShowComfirm_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(308, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // Signup_btn
            // 
            this.Signup_btn.BackColor = System.Drawing.Color.White;
            this.Signup_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup_btn.Location = new System.Drawing.Point(112, 385);
            this.Signup_btn.Name = "Signup_btn";
            this.Signup_btn.Size = new System.Drawing.Size(161, 39);
            this.Signup_btn.TabIndex = 16;
            this.Signup_btn.Text = "Đăng Ký";
            this.Signup_btn.UseVisualStyleBackColor = false;
            this.Signup_btn.Click += new System.EventHandler(this.Signup_btn_Click);
            // 
            // Comfirm_lb
            // 
            this.Comfirm_lb.AutoSize = true;
            this.Comfirm_lb.BackColor = System.Drawing.Color.White;
            this.Comfirm_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comfirm_lb.Location = new System.Drawing.Point(21, 337);
            this.Comfirm_lb.Name = "Comfirm_lb";
            this.Comfirm_lb.Size = new System.Drawing.Size(98, 21);
            this.Comfirm_lb.TabIndex = 15;
            this.Comfirm_lb.Text = "Xác Nhận";
            // 
            // Comfirm_txt
            // 
            this.Comfirm_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comfirm_txt.Location = new System.Drawing.Point(12, 328);
            this.Comfirm_txt.Name = "Comfirm_txt";
            this.Comfirm_txt.PasswordChar = '*';
            this.Comfirm_txt.Size = new System.Drawing.Size(338, 39);
            this.Comfirm_txt.TabIndex = 5;
            this.Comfirm_txt.TextChanged += new System.EventHandler(this.Comfirm_TextChanged);
            this.Comfirm_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // Username_lb
            // 
            this.Username_lb.AutoSize = true;
            this.Username_lb.BackColor = System.Drawing.Color.White;
            this.Username_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_lb.Location = new System.Drawing.Point(21, 106);
            this.Username_lb.Name = "Username_lb";
            this.Username_lb.Size = new System.Drawing.Size(153, 21);
            this.Username_lb.TabIndex = 13;
            this.Username_lb.Text = "Tên Đăng Nhập";
            // 
            // Username_txt
            // 
            this.Username_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_txt.Location = new System.Drawing.Point(12, 97);
            this.Username_txt.Name = "Username_txt";
            this.Username_txt.Size = new System.Drawing.Size(338, 39);
            this.Username_txt.TabIndex = 1;
            this.Username_txt.TextChanged += new System.EventHandler(this.Username_TextChanged);
            this.Username_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // ChessOnline_tlt
            // 
            this.ChessOnline_tlt.AutoSize = true;
            this.ChessOnline_tlt.BackColor = System.Drawing.Color.Transparent;
            this.ChessOnline_tlt.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChessOnline_tlt.ForeColor = System.Drawing.Color.White;
            this.ChessOnline_tlt.Location = new System.Drawing.Point(44, 46);
            this.ChessOnline_tlt.Name = "ChessOnline_tlt";
            this.ChessOnline_tlt.Size = new System.Drawing.Size(279, 33);
            this.ChessOnline_tlt.TabIndex = 11;
            this.ChessOnline_tlt.Text = "Chess Game Online";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(308, 158);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // Nickname_lb
            // 
            this.Nickname_lb.AutoSize = true;
            this.Nickname_lb.BackColor = System.Drawing.Color.White;
            this.Nickname_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nickname_lb.Location = new System.Drawing.Point(21, 164);
            this.Nickname_lb.Name = "Nickname_lb";
            this.Nickname_lb.Size = new System.Drawing.Size(164, 21);
            this.Nickname_lb.TabIndex = 20;
            this.Nickname_lb.Text = "Tên Người Dùng";
            // 
            // Nickname_txt
            // 
            this.Nickname_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nickname_txt.Location = new System.Drawing.Point(12, 155);
            this.Nickname_txt.Name = "Nickname_txt";
            this.Nickname_txt.Size = new System.Drawing.Size(338, 39);
            this.Nickname_txt.TabIndex = 2;
            this.Nickname_txt.TextChanged += new System.EventHandler(this.Nickname_TextChanged);
            this.Nickname_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(308, 217);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 24;
            this.pictureBox3.TabStop = false;
            // 
            // Email_lb
            // 
            this.Email_lb.AutoSize = true;
            this.Email_lb.BackColor = System.Drawing.Color.White;
            this.Email_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_lb.Location = new System.Drawing.Point(21, 223);
            this.Email_lb.Name = "Email_lb";
            this.Email_lb.Size = new System.Drawing.Size(65, 21);
            this.Email_lb.TabIndex = 23;
            this.Email_lb.Text = "Email";
            // 
            // Email_txt
            // 
            this.Email_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_txt.Location = new System.Drawing.Point(12, 214);
            this.Email_txt.Name = "Email_txt";
            this.Email_txt.Size = new System.Drawing.Size(338, 39);
            this.Email_txt.TabIndex = 3;
            this.Email_txt.TextChanged += new System.EventHandler(this.Email_TextChanged);
            this.Email_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // ShowPassword_btn
            // 
            this.ShowPassword_btn.Image = ((System.Drawing.Image)(resources.GetObject("ShowPassword_btn.Image")));
            this.ShowPassword_btn.Location = new System.Drawing.Point(310, 272);
            this.ShowPassword_btn.Name = "ShowPassword_btn";
            this.ShowPassword_btn.Size = new System.Drawing.Size(37, 31);
            this.ShowPassword_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPassword_btn.TabIndex = 27;
            this.ShowPassword_btn.TabStop = false;
            this.ShowPassword_btn.Click += new System.EventHandler(this.ShowPassword_btn_Click_1);
            // 
            // Password_lb
            // 
            this.Password_lb.AutoSize = true;
            this.Password_lb.BackColor = System.Drawing.Color.White;
            this.Password_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_lb.Location = new System.Drawing.Point(21, 278);
            this.Password_lb.Name = "Password_lb";
            this.Password_lb.Size = new System.Drawing.Size(98, 21);
            this.Password_lb.TabIndex = 26;
            this.Password_lb.Text = "Mật Khẩu";
            // 
            // Password_txt
            // 
            this.Password_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_txt.Location = new System.Drawing.Point(12, 269);
            this.Password_txt.Name = "Password_txt";
            this.Password_txt.PasswordChar = '*';
            this.Password_txt.Size = new System.Drawing.Size(338, 39);
            this.Password_txt.TabIndex = 4;
            this.Password_txt.TextChanged += new System.EventHandler(this.Password_TextChanged);
            this.Password_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // Return_btn
            // 
            this.Return_btn.BackColor = System.Drawing.Color.White;
            this.Return_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Return_btn.Location = new System.Drawing.Point(112, 441);
            this.Return_btn.Name = "Return_btn";
            this.Return_btn.Size = new System.Drawing.Size(161, 39);
            this.Return_btn.TabIndex = 28;
            this.Return_btn.Text = "Quay Lại";
            this.Return_btn.UseVisualStyleBackColor = false;
            this.Return_btn.Click += new System.EventHandler(this.Return_btn_Click);
            // 
            // Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(734, 492);
            this.Controls.Add(this.Return_btn);
            this.Controls.Add(this.ShowPassword_btn);
            this.Controls.Add(this.Password_lb);
            this.Controls.Add(this.Password_txt);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.Email_lb);
            this.Controls.Add(this.Email_txt);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Nickname_lb);
            this.Controls.Add(this.Nickname_txt);
            this.Controls.Add(this.ShowComfirm_btn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Signup_btn);
            this.Controls.Add(this.Comfirm_lb);
            this.Controls.Add(this.Comfirm_txt);
            this.Controls.Add(this.Username_lb);
            this.Controls.Add(this.Username_txt);
            this.Controls.Add(this.ChessOnline_tlt);
            this.Name = "Signup";
            this.Text = "Signup";
            ((System.ComponentModel.ISupportInitialize)(this.ShowComfirm_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassword_btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ShowComfirm_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Signup_btn;
        private System.Windows.Forms.Label Comfirm_lb;
        private System.Windows.Forms.TextBox Comfirm_txt;
        private System.Windows.Forms.Label Username_lb;
        private System.Windows.Forms.TextBox Username_txt;
        private System.Windows.Forms.Label ChessOnline_tlt;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label Nickname_lb;
        private System.Windows.Forms.TextBox Nickname_txt;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label Email_lb;
        private System.Windows.Forms.TextBox Email_txt;
        private System.Windows.Forms.PictureBox ShowPassword_btn;
        private System.Windows.Forms.Label Password_lb;
        private System.Windows.Forms.TextBox Password_txt;
        private System.Windows.Forms.Button Return_btn;
    }
}