namespace Chess
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.ChessOnline_tlt = new System.Windows.Forms.Label();
            this.Createroom_btn = new System.Windows.Forms.Button();
            this.Join_btn = new System.Windows.Forms.Button();
            this.Matchhis_btn = new System.Windows.Forms.Button();
            this.Close_btn = new System.Windows.Forms.Button();
            this.UserInfo = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ChessOnline_tlt
            // 
            this.ChessOnline_tlt.AutoSize = true;
            this.ChessOnline_tlt.BackColor = System.Drawing.Color.Transparent;
            this.ChessOnline_tlt.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChessOnline_tlt.ForeColor = System.Drawing.Color.White;
            this.ChessOnline_tlt.Location = new System.Drawing.Point(97, 59);
            this.ChessOnline_tlt.Name = "ChessOnline_tlt";
            this.ChessOnline_tlt.Size = new System.Drawing.Size(279, 33);
            this.ChessOnline_tlt.TabIndex = 1;
            this.ChessOnline_tlt.Text = "Chess Game Online";
            // 
            // Createroom_btn
            // 
            this.Createroom_btn.BackColor = System.Drawing.Color.White;
            this.Createroom_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Createroom_btn.Location = new System.Drawing.Point(103, 135);
            this.Createroom_btn.Name = "Createroom_btn";
            this.Createroom_btn.Size = new System.Drawing.Size(273, 39);
            this.Createroom_btn.TabIndex = 6;
            this.Createroom_btn.Text = "Tạo Phòng";
            this.Createroom_btn.UseVisualStyleBackColor = false;
            this.Createroom_btn.Click += new System.EventHandler(this.Createroom_btn_Click);
            // 
            // Join_btn
            // 
            this.Join_btn.BackColor = System.Drawing.Color.White;
            this.Join_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Join_btn.Location = new System.Drawing.Point(103, 197);
            this.Join_btn.Name = "Join_btn";
            this.Join_btn.Size = new System.Drawing.Size(273, 39);
            this.Join_btn.TabIndex = 7;
            this.Join_btn.Text = "Tham Gia Phòng";
            this.Join_btn.UseVisualStyleBackColor = false;
            this.Join_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Matchhis_btn
            // 
            this.Matchhis_btn.BackColor = System.Drawing.Color.White;
            this.Matchhis_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Matchhis_btn.Location = new System.Drawing.Point(103, 271);
            this.Matchhis_btn.Name = "Matchhis_btn";
            this.Matchhis_btn.Size = new System.Drawing.Size(273, 39);
            this.Matchhis_btn.TabIndex = 9;
            this.Matchhis_btn.Text = "Lịch Sử Đấu";
            this.Matchhis_btn.UseVisualStyleBackColor = false;
            // 
            // Close_btn
            // 
            this.Close_btn.BackColor = System.Drawing.Color.White;
            this.Close_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_btn.Location = new System.Drawing.Point(103, 351);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(273, 39);
            this.Close_btn.TabIndex = 10;
            this.Close_btn.Text = "Thoát";
            this.Close_btn.UseVisualStyleBackColor = false;
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // UserInfo
            // 
            this.UserInfo.Image = ((System.Drawing.Image)(resources.GetObject("UserInfo.Image")));
            this.UserInfo.Location = new System.Drawing.Point(1, -1);
            this.UserInfo.Name = "UserInfo";
            this.UserInfo.Size = new System.Drawing.Size(41, 41);
            this.UserInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserInfo.TabIndex = 11;
            this.UserInfo.TabStop = false;
            this.UserInfo.Click += new System.EventHandler(this.UserInfo_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(733, 492);
            this.Controls.Add(this.UserInfo);
            this.Controls.Add(this.Close_btn);
            this.Controls.Add(this.Matchhis_btn);
            this.Controls.Add(this.Join_btn);
            this.Controls.Add(this.Createroom_btn);
            this.Controls.Add(this.ChessOnline_tlt);
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.UserInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ChessOnline_tlt;
        private System.Windows.Forms.Button Createroom_btn;
        private System.Windows.Forms.Button Join_btn;
        private System.Windows.Forms.Button Matchhis_btn;
        private System.Windows.Forms.Button Close_btn;
        private System.Windows.Forms.PictureBox UserInfo;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}