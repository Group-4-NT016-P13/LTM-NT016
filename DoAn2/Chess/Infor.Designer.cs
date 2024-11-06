namespace Chess
{
    partial class Infor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Infor));
            this.Email_lb = new System.Windows.Forms.Label();
            this.Email_txt = new System.Windows.Forms.TextBox();
            this.Nickname_lb = new System.Windows.Forms.Label();
            this.Nickname_txt = new System.Windows.Forms.TextBox();
            this.Return_btn = new System.Windows.Forms.Button();
            this.Fix_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Email_lb
            // 
            this.Email_lb.AutoSize = true;
            this.Email_lb.BackColor = System.Drawing.Color.Transparent;
            this.Email_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_lb.ForeColor = System.Drawing.Color.White;
            this.Email_lb.Location = new System.Drawing.Point(25, 251);
            this.Email_lb.Name = "Email_lb";
            this.Email_lb.Size = new System.Drawing.Size(65, 21);
            this.Email_lb.TabIndex = 14;
            this.Email_lb.Text = "Email";
            // 
            // Email_txt
            // 
            this.Email_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_txt.Location = new System.Drawing.Point(24, 275);
            this.Email_txt.Name = "Email_txt";
            this.Email_txt.Size = new System.Drawing.Size(338, 39);
            this.Email_txt.TabIndex = 13;
            // 
            // Nickname_lb
            // 
            this.Nickname_lb.AutoSize = true;
            this.Nickname_lb.BackColor = System.Drawing.Color.Transparent;
            this.Nickname_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nickname_lb.ForeColor = System.Drawing.Color.White;
            this.Nickname_lb.Location = new System.Drawing.Point(25, 175);
            this.Nickname_lb.Name = "Nickname_lb";
            this.Nickname_lb.Size = new System.Drawing.Size(175, 21);
            this.Nickname_lb.TabIndex = 12;
            this.Nickname_lb.Text = "Tên Người Dùng ";
            // 
            // Nickname_txt
            // 
            this.Nickname_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nickname_txt.Location = new System.Drawing.Point(24, 199);
            this.Nickname_txt.Name = "Nickname_txt";
            this.Nickname_txt.Size = new System.Drawing.Size(338, 39);
            this.Nickname_txt.TabIndex = 11;
            // 
            // Return_btn
            // 
            this.Return_btn.BackColor = System.Drawing.Color.White;
            this.Return_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Return_btn.Location = new System.Drawing.Point(119, 399);
            this.Return_btn.Name = "Return_btn";
            this.Return_btn.Size = new System.Drawing.Size(161, 39);
            this.Return_btn.TabIndex = 30;
            this.Return_btn.Text = "Quay Lại";
            this.Return_btn.UseVisualStyleBackColor = false;
            this.Return_btn.Click += new System.EventHandler(this.Return_btn_Click);
            // 
            // Fix_btn
            // 
            this.Fix_btn.BackColor = System.Drawing.Color.White;
            this.Fix_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fix_btn.Location = new System.Drawing.Point(119, 343);
            this.Fix_btn.Name = "Fix_btn";
            this.Fix_btn.Size = new System.Drawing.Size(161, 39);
            this.Fix_btn.TabIndex = 29;
            this.Fix_btn.Text = "Chỉnh Sửa";
            this.Fix_btn.UseVisualStyleBackColor = false;
            this.Fix_btn.Click += new System.EventHandler(this.Fix_btn_Click);
            // 
            // Infor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(735, 494);
            this.Controls.Add(this.Return_btn);
            this.Controls.Add(this.Fix_btn);
            this.Controls.Add(this.Email_lb);
            this.Controls.Add(this.Email_txt);
            this.Controls.Add(this.Nickname_lb);
            this.Controls.Add(this.Nickname_txt);
            this.Name = "Infor";
            this.Text = "Infor";
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Email_lb;
        private System.Windows.Forms.TextBox Email_txt;
        private System.Windows.Forms.Label Nickname_lb;
        private System.Windows.Forms.TextBox Nickname_txt;
        private System.Windows.Forms.Button Return_btn;
        private System.Windows.Forms.Button Fix_btn;
    }
}