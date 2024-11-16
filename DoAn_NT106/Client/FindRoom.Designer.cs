namespace Program
{
    partial class FindRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindRoom));
            this.RoomID_txt = new System.Windows.Forms.TextBox();
            this.RoomID_lb = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.IDRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RoomName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Numbers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Join_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RoomID_txt
            // 
            this.RoomID_txt.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomID_txt.Location = new System.Drawing.Point(137, 103);
            this.RoomID_txt.Multiline = true;
            this.RoomID_txt.Name = "RoomID_txt";
            this.RoomID_txt.Size = new System.Drawing.Size(209, 20);
            this.RoomID_txt.TabIndex = 10;
            // 
            // RoomID_lb
            // 
            this.RoomID_lb.AutoSize = true;
            this.RoomID_lb.BackColor = System.Drawing.Color.Transparent;
            this.RoomID_lb.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomID_lb.ForeColor = System.Drawing.Color.White;
            this.RoomID_lb.Location = new System.Drawing.Point(12, 102);
            this.RoomID_lb.Name = "RoomID_lb";
            this.RoomID_lb.Size = new System.Drawing.Size(98, 21);
            this.RoomID_lb.TabIndex = 11;
            this.RoomID_lb.Text = "Mã Phòng";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDRoom,
            this.RoomName,
            this.Numbers,
            this.Status});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 138);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(732, 280);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // IDRoom
            // 
            this.IDRoom.Text = "ID Phòng";
            this.IDRoom.Width = 93;
            // 
            // RoomName
            // 
            this.RoomName.Text = "Tên Phòng";
            this.RoomName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RoomName.Width = 272;
            // 
            // Numbers
            // 
            this.Numbers.Text = "Số Lượng Người";
            this.Numbers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Numbers.Width = 118;
            // 
            // Status
            // 
            this.Status.Text = "Tình trạng";
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Status.Width = 233;
            // 
            // Join_btn
            // 
            this.Join_btn.BackColor = System.Drawing.Color.White;
            this.Join_btn.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Join_btn.Location = new System.Drawing.Point(227, 442);
            this.Join_btn.Name = "Join_btn";
            this.Join_btn.Size = new System.Drawing.Size(273, 39);
            this.Join_btn.TabIndex = 13;
            this.Join_btn.Text = "Tham Gia";
            this.Join_btn.UseVisualStyleBackColor = false;
            // 
            // FindRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(736, 493);
            this.Controls.Add(this.Join_btn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.RoomID_lb);
            this.Controls.Add(this.RoomID_txt);
            this.Name = "FindRoom";
            this.Text = "FindRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RoomID_txt;
        private System.Windows.Forms.Label RoomID_lb;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader IDRoom;
        private System.Windows.Forms.ColumnHeader RoomName;
        private System.Windows.Forms.ColumnHeader Numbers;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Button Join_btn;
    }
}