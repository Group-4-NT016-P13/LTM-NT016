namespace Client
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.ChessOnline_tlt = new System.Windows.Forms.Label();
            this.Username_txt = new System.Windows.Forms.TextBox();
            this.Username_lb = new System.Windows.Forms.Label();
            this.Password_lb = new System.Windows.Forms.Label();
            this.Password_txt = new System.Windows.Forms.TextBox();
            this.Login_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Signup_lb = new System.Windows.Forms.Label();
            this.Forgot_lb = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ShowPassword_btn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassword_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // ChessOnline_tlt
            // 
            this.ChessOnline_tlt.AutoSize = true;
            this.ChessOnline_tlt.BackColor = System.Drawing.Color.Transparent;
            this.ChessOnline_tlt.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChessOnline_tlt.ForeColor = System.Drawing.Color.White;
            this.ChessOnline_tlt.Location = new System.Drawing.Point(47, 86);
            this.ChessOnline_tlt.Name = "ChessOnline_tlt";
            this.ChessOnline_tlt.Size = new System.Drawing.Size(279, 33);
            this.ChessOnline_tlt.TabIndex = 0;
            this.ChessOnline_tlt.Text = "Chess Game Online";
            // 
            // Username_txt
            // 
            this.Username_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_txt.Location = new System.Drawing.Point(22, 167);
            this.Username_txt.Name = "Username_txt";
            this.Username_txt.Size = new System.Drawing.Size(338, 39);
            this.Username_txt.TabIndex = 1;
            this.Username_txt.TextChanged += new System.EventHandler(this.Username_TextChanged);
            this.Username_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // Username_lb
            // 
            this.Username_lb.AutoSize = true;
            this.Username_lb.BackColor = System.Drawing.Color.White;
            this.Username_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_lb.Location = new System.Drawing.Point(31, 176);
            this.Username_lb.Name = "Username_lb";
            this.Username_lb.Size = new System.Drawing.Size(153, 21);
            this.Username_lb.TabIndex = 2;
            this.Username_lb.Text = "Tên Đăng Nhập";
            // 
            // Password_lb
            // 
            this.Password_lb.AutoSize = true;
            this.Password_lb.BackColor = System.Drawing.Color.White;
            this.Password_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_lb.Location = new System.Drawing.Point(31, 252);
            this.Password_lb.Name = "Password_lb";
            this.Password_lb.Size = new System.Drawing.Size(98, 21);
            this.Password_lb.TabIndex = 4;
            this.Password_lb.Text = "Mật Khẩu";
            // 
            // Password_txt
            // 
            this.Password_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_txt.Location = new System.Drawing.Point(22, 243);
            this.Password_txt.Name = "Password_txt";
            this.Password_txt.PasswordChar = '*';
            this.Password_txt.Size = new System.Drawing.Size(338, 39);
            this.Password_txt.TabIndex = 3;
            this.Password_txt.TextChanged += new System.EventHandler(this.Password_TextChanged);
            this.Password_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // Login_btn
            // 
            this.Login_btn.BackColor = System.Drawing.Color.White;
            this.Login_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_btn.Location = new System.Drawing.Point(112, 311);
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.Size = new System.Drawing.Size(161, 39);
            this.Login_btn.TabIndex = 5;
            this.Login_btn.Text = "Đăng Nhập";
            this.Login_btn.UseVisualStyleBackColor = false;
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Người mới?";
            // 
            // Signup_lb
            // 
            this.Signup_lb.AutoSize = true;
            this.Signup_lb.BackColor = System.Drawing.Color.Transparent;
            this.Signup_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup_lb.ForeColor = System.Drawing.Color.White;
            this.Signup_lb.Location = new System.Drawing.Point(169, 379);
            this.Signup_lb.Name = "Signup_lb";
            this.Signup_lb.Size = new System.Drawing.Size(186, 21);
            this.Signup_lb.TabIndex = 7;
            this.Signup_lb.Text = "Đăng Ký Ngay Nào";
            this.Signup_lb.Click += new System.EventHandler(this.Signup_lb_Click);
            this.Signup_lb.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.Signup_lb.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // Forgot_lb
            // 
            this.Forgot_lb.AutoSize = true;
            this.Forgot_lb.BackColor = System.Drawing.Color.Transparent;
            this.Forgot_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Forgot_lb.ForeColor = System.Drawing.Color.White;
            this.Forgot_lb.Location = new System.Drawing.Point(108, 423);
            this.Forgot_lb.Name = "Forgot_lb";
            this.Forgot_lb.Size = new System.Drawing.Size(153, 21);
            this.Forgot_lb.TabIndex = 8;
            this.Forgot_lb.Text = "Quên Mật Khẩu";
            this.Forgot_lb.Click += new System.EventHandler(this.Forgot_lb_Click);
            this.Forgot_lb.MouseEnter += new System.EventHandler(this.Label_MouseEnter);
            this.Forgot_lb.MouseLeave += new System.EventHandler(this.Label_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(318, 170);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // ShowPassword_btn
            // 
            this.ShowPassword_btn.Image = ((System.Drawing.Image)(resources.GetObject("ShowPassword_btn.Image")));
            this.ShowPassword_btn.Location = new System.Drawing.Point(320, 246);
            this.ShowPassword_btn.Name = "ShowPassword_btn";
            this.ShowPassword_btn.Size = new System.Drawing.Size(37, 31);
            this.ShowPassword_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShowPassword_btn.TabIndex = 10;
            this.ShowPassword_btn.TabStop = false;
            this.ShowPassword_btn.Click += new System.EventHandler(this.ShowPassword_btn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(732, 482);
            this.Controls.Add(this.ShowPassword_btn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Forgot_lb);
            this.Controls.Add(this.Signup_lb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Login_btn);
            this.Controls.Add(this.Password_lb);
            this.Controls.Add(this.Password_txt);
            this.Controls.Add(this.Username_lb);
            this.Controls.Add(this.Username_txt);
            this.Controls.Add(this.ChessOnline_tlt);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShowPassword_btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChessOnline_tlt;
        private System.Windows.Forms.TextBox Username_txt;
        private System.Windows.Forms.Label Username_lb;
        private System.Windows.Forms.Label Password_lb;
        private System.Windows.Forms.TextBox Password_txt;
        private System.Windows.Forms.Button Login_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Signup_lb;
        private System.Windows.Forms.Label Forgot_lb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ShowPassword_btn;
    }
}