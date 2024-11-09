namespace Chess
{
    partial class Recovery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recovery));
            this.Passcode_lb = new System.Windows.Forms.Label();
            this.PassCode_txt = new System.Windows.Forms.TextBox();
            this.Email_lb = new System.Windows.Forms.Label();
            this.Email_txt = new System.Windows.Forms.TextBox();
            this.ChessOnline_tlt = new System.Windows.Forms.Label();
            this.Send_btn = new System.Windows.Forms.Button();
            this.Comfirm_btn = new System.Windows.Forms.Button();
            this.Message_lb = new System.Windows.Forms.Label();
            this.Return_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Passcode_lb
            // 
            this.Passcode_lb.AutoSize = true;
            this.Passcode_lb.BackColor = System.Drawing.Color.White;
            this.Passcode_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Passcode_lb.Location = new System.Drawing.Point(31, 313);
            this.Passcode_lb.Name = "Passcode_lb";
            this.Passcode_lb.Size = new System.Drawing.Size(131, 21);
            this.Passcode_lb.TabIndex = 14;
            this.Passcode_lb.Text = "Mã Xác Nhận";
            this.Passcode_lb.TextChanged += new System.EventHandler(this.Passcode_TextChanged);
            // 
            // PassCode_txt
            // 
            this.PassCode_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassCode_txt.Location = new System.Drawing.Point(22, 304);
            this.PassCode_txt.Name = "PassCode_txt";
            this.PassCode_txt.Size = new System.Drawing.Size(338, 39);
            this.PassCode_txt.TabIndex = 3;
            this.PassCode_txt.TextChanged += new System.EventHandler(this.Passcode_TextChanged);
            this.PassCode_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // Email_lb
            // 
            this.Email_lb.AutoSize = true;
            this.Email_lb.BackColor = System.Drawing.Color.White;
            this.Email_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_lb.Location = new System.Drawing.Point(31, 202);
            this.Email_lb.Name = "Email_lb";
            this.Email_lb.Size = new System.Drawing.Size(65, 21);
            this.Email_lb.TabIndex = 12;
            this.Email_lb.Text = "Email";
            this.Email_lb.TextChanged += new System.EventHandler(this.Email_TextChanged);
            // 
            // Email_txt
            // 
            this.Email_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_txt.Location = new System.Drawing.Point(22, 193);
            this.Email_txt.Name = "Email_txt";
            this.Email_txt.Size = new System.Drawing.Size(338, 39);
            this.Email_txt.TabIndex = 1;
            this.Email_txt.TextChanged += new System.EventHandler(this.Email_TextChanged);
            this.Email_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // ChessOnline_tlt
            // 
            this.ChessOnline_tlt.AutoSize = true;
            this.ChessOnline_tlt.BackColor = System.Drawing.Color.Transparent;
            this.ChessOnline_tlt.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChessOnline_tlt.ForeColor = System.Drawing.Color.White;
            this.ChessOnline_tlt.Location = new System.Drawing.Point(68, 56);
            this.ChessOnline_tlt.Name = "ChessOnline_tlt";
            this.ChessOnline_tlt.Size = new System.Drawing.Size(279, 33);
            this.ChessOnline_tlt.TabIndex = 17;
            this.ChessOnline_tlt.Text = "Chess Game Online";
            // 
            // Send_btn
            // 
            this.Send_btn.BackColor = System.Drawing.Color.White;
            this.Send_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_btn.Location = new System.Drawing.Point(118, 248);
            this.Send_btn.Name = "Send_btn";
            this.Send_btn.Size = new System.Drawing.Size(161, 39);
            this.Send_btn.TabIndex = 2;
            this.Send_btn.Text = "Gửi";
            this.Send_btn.UseVisualStyleBackColor = false;
            this.Send_btn.Click += new System.EventHandler(this.Send_btn_Click);
            // 
            // Comfirm_btn
            // 
            this.Comfirm_btn.BackColor = System.Drawing.Color.White;
            this.Comfirm_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Comfirm_btn.Location = new System.Drawing.Point(118, 361);
            this.Comfirm_btn.Name = "Comfirm_btn";
            this.Comfirm_btn.Size = new System.Drawing.Size(161, 39);
            this.Comfirm_btn.TabIndex = 4;
            this.Comfirm_btn.Text = "Xác Nhận";
            this.Comfirm_btn.UseVisualStyleBackColor = false;
            this.Comfirm_btn.Click += new System.EventHandler(this.Comfirm_btn_Click);
            // 
            // Message_lb
            // 
            this.Message_lb.AutoSize = true;
            this.Message_lb.BackColor = System.Drawing.Color.Transparent;
            this.Message_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message_lb.ForeColor = System.Drawing.Color.White;
            this.Message_lb.Location = new System.Drawing.Point(1, 128);
            this.Message_lb.MaximumSize = new System.Drawing.Size(0, 200);
            this.Message_lb.Name = "Message_lb";
            this.Message_lb.Size = new System.Drawing.Size(450, 21);
            this.Message_lb.TabIndex = 21;
            this.Message_lb.Text = "Nhập Email để nhận mã khôi phục mật khẩu";
            this.Message_lb.Click += new System.EventHandler(this.label1_Click);
            // 
            // Return_btn
            // 
            this.Return_btn.BackColor = System.Drawing.Color.White;
            this.Return_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Return_btn.Location = new System.Drawing.Point(118, 430);
            this.Return_btn.Name = "Return_btn";
            this.Return_btn.Size = new System.Drawing.Size(161, 39);
            this.Return_btn.TabIndex = 22;
            this.Return_btn.Text = "Quay Lại";
            this.Return_btn.UseVisualStyleBackColor = false;
            this.Return_btn.Click += new System.EventHandler(this.Return_btn_Click);
            // 
            // Recovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(734, 491);
            this.Controls.Add(this.Return_btn);
            this.Controls.Add(this.Message_lb);
            this.Controls.Add(this.Comfirm_btn);
            this.Controls.Add(this.Send_btn);
            this.Controls.Add(this.ChessOnline_tlt);
            this.Controls.Add(this.Passcode_lb);
            this.Controls.Add(this.PassCode_txt);
            this.Controls.Add(this.Email_lb);
            this.Controls.Add(this.Email_txt);
            this.Name = "Recovery";
            this.Text = "Recovery";
            this.TextChanged += new System.EventHandler(this.Passcode_TextChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Passcode_lb;
        private System.Windows.Forms.TextBox PassCode_txt;
        private System.Windows.Forms.Label Email_lb;
        private System.Windows.Forms.TextBox Email_txt;
        private System.Windows.Forms.Label ChessOnline_tlt;
        private System.Windows.Forms.Button Send_btn;
        private System.Windows.Forms.Button Comfirm_btn;
        private System.Windows.Forms.Label Message_lb;
        private System.Windows.Forms.Button Return_btn;
    }
}