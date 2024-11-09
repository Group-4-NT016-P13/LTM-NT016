namespace Chess
{
    partial class PieceSelection
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
            this.RightArrow = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LeftArrow = new System.Windows.Forms.Button();
            this.Preview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // RightArrow
            // 
            this.RightArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RightArrow.ForeColor = System.Drawing.Color.Blue;
            this.RightArrow.Location = new System.Drawing.Point(137, 68);
            this.RightArrow.Name = "RightArrow";
            this.RightArrow.Size = new System.Drawing.Size(34, 29);
            this.RightArrow.TabIndex = 1;
            this.RightArrow.Text = ">";
            this.RightArrow.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApplyButton.Location = new System.Drawing.Point(47, 126);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(84, 31);
            this.ApplyButton.TabIndex = 3;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select a Piece";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LeftArrow
            // 
            this.LeftArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftArrow.ForeColor = System.Drawing.Color.Blue;
            this.LeftArrow.Location = new System.Drawing.Point(8, 68);
            this.LeftArrow.Name = "LeftArrow";
            this.LeftArrow.Size = new System.Drawing.Size(33, 29);
            this.LeftArrow.TabIndex = 5;
            this.LeftArrow.Text = "<";
            this.LeftArrow.UseVisualStyleBackColor = true;
            // 
            // Preview
            // 
            this.Preview.Location = new System.Drawing.Point(47, 39);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(84, 70);
            this.Preview.TabIndex = 2;
            this.Preview.TabStop = false;
            // 
            // PieceSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 169);
            this.Controls.Add(this.LeftArrow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.RightArrow);
            this.MaximumSize = new System.Drawing.Size(191, 216);
            this.MinimumSize = new System.Drawing.Size(191, 216);
            this.Name = "PieceSelection";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button RightArrow;
        private System.Windows.Forms.PictureBox Preview;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LeftArrow;
    }
}