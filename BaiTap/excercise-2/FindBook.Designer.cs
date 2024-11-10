namespace excercise_2
{
    partial class FindBook
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
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.Search_btn = new System.Windows.Forms.Button();
            this.Search_txt = new System.Windows.Forms.TextBox();
            this.Userinfor_grp = new System.Windows.Forms.GroupBox();
            this.Email_txt = new System.Windows.Forms.TextBox();
            this.Username_txt = new System.Windows.Forms.TextBox();
            this.AddBook_btn = new System.Windows.Forms.Button();
            this.Addbookshelves_btn = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Authors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublishedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvShelves = new System.Windows.Forms.DataGridView();
            this.ShelvesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookNumbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Shelfname_txt = new System.Windows.Forms.TextBox();
            this.Description_txt = new System.Windows.Forms.TextBox();
            this.Shelfname_lb = new System.Windows.Forms.Label();
            this.Description_lb = new System.Windows.Forms.Label();
            this.Addbookshelf_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.Userinfor_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShelves)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBooks
            // 
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Authors,
            this.PublishedDate});
            this.dgvBooks.Location = new System.Drawing.Point(-2, 165);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(549, 232);
            this.dgvBooks.TabIndex = 0;
            this.dgvBooks.SelectionChanged += new System.EventHandler(this.DgvBooks_SelectionChanged);
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(435, 121);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(97, 34);
            this.Search_btn.TabIndex = 2;
            this.Search_btn.Text = "Tìm Kiếm";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // Search_txt
            // 
            this.Search_txt.Location = new System.Drawing.Point(-2, 135);
            this.Search_txt.Name = "Search_txt";
            this.Search_txt.Size = new System.Drawing.Size(431, 20);
            this.Search_txt.TabIndex = 3;
            // 
            // Userinfor_grp
            // 
            this.Userinfor_grp.Controls.Add(this.Email_txt);
            this.Userinfor_grp.Controls.Add(this.Username_txt);
            this.Userinfor_grp.Location = new System.Drawing.Point(12, 3);
            this.Userinfor_grp.Name = "Userinfor_grp";
            this.Userinfor_grp.Size = new System.Drawing.Size(175, 72);
            this.Userinfor_grp.TabIndex = 4;
            this.Userinfor_grp.TabStop = false;
            this.Userinfor_grp.Text = "Thông Tin";
            // 
            // Email_txt
            // 
            this.Email_txt.Location = new System.Drawing.Point(7, 46);
            this.Email_txt.Name = "Email_txt";
            this.Email_txt.ReadOnly = true;
            this.Email_txt.Size = new System.Drawing.Size(140, 20);
            this.Email_txt.TabIndex = 1;
            // 
            // Username_txt
            // 
            this.Username_txt.Location = new System.Drawing.Point(7, 20);
            this.Username_txt.Name = "Username_txt";
            this.Username_txt.ReadOnly = true;
            this.Username_txt.Size = new System.Drawing.Size(140, 20);
            this.Username_txt.TabIndex = 0;
            // 
            // AddBook_btn
            // 
            this.AddBook_btn.Location = new System.Drawing.Point(140, 431);
            this.AddBook_btn.Name = "AddBook_btn";
            this.AddBook_btn.Size = new System.Drawing.Size(117, 43);
            this.AddBook_btn.TabIndex = 5;
            this.AddBook_btn.Text = "Thêm Sách";
            this.AddBook_btn.UseVisualStyleBackColor = true;
            // 
            // Addbookshelves_btn
            // 
            this.Addbookshelves_btn.Location = new System.Drawing.Point(695, 431);
            this.Addbookshelves_btn.Name = "Addbookshelves_btn";
            this.Addbookshelves_btn.Size = new System.Drawing.Size(117, 43);
            this.Addbookshelves_btn.TabIndex = 6;
            this.Addbookshelves_btn.Text = "Thêm Kệ Sách";
            this.Addbookshelves_btn.UseVisualStyleBackColor = true;
            // 
            // Title
            // 
            this.Title.HeaderText = "Tựa đề";
            this.Title.Name = "Title";
            this.Title.Width = 165;
            // 
            // Authors
            // 
            this.Authors.HeaderText = "Tác giả";
            this.Authors.Name = "Authors";
            this.Authors.Width = 150;
            // 
            // PublishedDate
            // 
            this.PublishedDate.HeaderText = "Ngày phát hành";
            this.PublishedDate.Name = "PublishedDate";
            this.PublishedDate.Width = 190;
            // 
            // dgvShelves
            // 
            this.dgvShelves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShelves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ShelvesName,
            this.Description,
            this.BookNumbers});
            this.dgvShelves.Location = new System.Drawing.Point(553, 165);
            this.dgvShelves.Name = "dgvShelves";
            this.dgvShelves.Size = new System.Drawing.Size(427, 232);
            this.dgvShelves.TabIndex = 7;
            // 
            // ShelvesName
            // 
            this.ShelvesName.HeaderText = "Tên Kệ Sách";
            this.ShelvesName.Name = "ShelvesName";
            this.ShelvesName.Width = 150;
            // 
            // Description
            // 
            this.Description.HeaderText = "Mô Tả";
            this.Description.Name = "Description";
            this.Description.Width = 150;
            // 
            // BookNumbers
            // 
            this.BookNumbers.HeaderText = "Số Lượng Sách";
            this.BookNumbers.Name = "BookNumbers";
            this.BookNumbers.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Addbookshelf_btn);
            this.groupBox1.Controls.Add(this.Description_lb);
            this.groupBox1.Controls.Add(this.Shelfname_lb);
            this.groupBox1.Controls.Add(this.Description_txt);
            this.groupBox1.Controls.Add(this.Shelfname_txt);
            this.groupBox1.Location = new System.Drawing.Point(780, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 152);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Kệ Sách";
            // 
            // Shelfname_txt
            // 
            this.Shelfname_txt.Location = new System.Drawing.Point(6, 34);
            this.Shelfname_txt.Name = "Shelfname_txt";
            this.Shelfname_txt.Size = new System.Drawing.Size(171, 20);
            this.Shelfname_txt.TabIndex = 0;
            // 
            // Description_txt
            // 
            this.Description_txt.Location = new System.Drawing.Point(6, 83);
            this.Description_txt.Name = "Description_txt";
            this.Description_txt.Size = new System.Drawing.Size(171, 20);
            this.Description_txt.TabIndex = 1;
            // 
            // Shelfname_lb
            // 
            this.Shelfname_lb.AutoSize = true;
            this.Shelfname_lb.Location = new System.Drawing.Point(6, 15);
            this.Shelfname_lb.Name = "Shelfname_lb";
            this.Shelfname_lb.Size = new System.Drawing.Size(70, 13);
            this.Shelfname_lb.TabIndex = 2;
            this.Shelfname_lb.Text = "Tên Kệ Sách";
            // 
            // Description_lb
            // 
            this.Description_lb.AutoSize = true;
            this.Description_lb.Location = new System.Drawing.Point(6, 67);
            this.Description_lb.Name = "Description_lb";
            this.Description_lb.Size = new System.Drawing.Size(38, 13);
            this.Description_lb.TabIndex = 3;
            this.Description_lb.Text = "Mô Tả";
            // 
            // Addbookshelf_btn
            // 
            this.Addbookshelf_btn.Location = new System.Drawing.Point(46, 118);
            this.Addbookshelf_btn.Name = "Addbookshelf_btn";
            this.Addbookshelf_btn.Size = new System.Drawing.Size(97, 23);
            this.Addbookshelf_btn.TabIndex = 4;
            this.Addbookshelf_btn.Text = "Thêm Kệ Sách";
            this.Addbookshelf_btn.UseVisualStyleBackColor = true;
            this.Addbookshelf_btn.Click += new System.EventHandler(this.Addbookshelf_btn_Click);
            // 
            // FindBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 506);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvShelves);
            this.Controls.Add(this.Addbookshelves_btn);
            this.Controls.Add(this.AddBook_btn);
            this.Controls.Add(this.Userinfor_grp);
            this.Controls.Add(this.Search_txt);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.dgvBooks);
            this.Name = "FindBook";
            this.Text = "FindBook";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.Userinfor_grp.ResumeLayout(false);
            this.Userinfor_grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShelves)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.TextBox Search_txt;
        private System.Windows.Forms.GroupBox Userinfor_grp;
        private System.Windows.Forms.TextBox Username_txt;
        private System.Windows.Forms.TextBox Email_txt;
        private System.Windows.Forms.Button AddBook_btn;
        private System.Windows.Forms.Button Addbookshelves_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Authors;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublishedDate;
        private System.Windows.Forms.DataGridView dgvShelves;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShelvesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookNumbers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Description_lb;
        private System.Windows.Forms.Label Shelfname_lb;
        private System.Windows.Forms.TextBox Description_txt;
        private System.Windows.Forms.TextBox Shelfname_txt;
        private System.Windows.Forms.Button Addbookshelf_btn;
    }
}