namespace Chess
{
    partial class Chess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chess));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RestartButton = new System.Windows.Forms.Button();
            this.Undo = new System.Windows.Forms.PictureBox();
            this.Redo = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.GroupBox();
            this.TimeButton = new System.Windows.Forms.Button();
            this.WhiteTimer = new System.Windows.Forms.Label();
            this.BlackTimer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.State = new System.Windows.Forms.GroupBox();
            this.GameState = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Undo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Redo)).BeginInit();
            this.Timer.SuspendLayout();
            this.State.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RestartButton);
            this.groupBox1.Controls.Add(this.Undo);
            this.groupBox1.Controls.Add(this.Redo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(643, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // RestartButton
            // 
            this.RestartButton.Location = new System.Drawing.Point(20, 79);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(108, 36);
            this.RestartButton.TabIndex = 1;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = true;
            // 
            // Undo
            // 
            this.Undo.Image = global::Chess.Properties.Resources.Undo;
            this.Undo.Location = new System.Drawing.Point(16, 23);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(53, 50);
            this.Undo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Undo.TabIndex = 1;
            this.Undo.TabStop = false;
            // 
            // Redo
            // 
            this.Redo.Image = global::Chess.Properties.Resources.Redo;
            this.Redo.Location = new System.Drawing.Point(75, 23);
            this.Redo.Name = "Redo";
            this.Redo.Size = new System.Drawing.Size(53, 50);
            this.Redo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Redo.TabIndex = 2;
            this.Redo.TabStop = false;
            // 
            // Timer
            // 
            this.Timer.Controls.Add(this.TimeButton);
            this.Timer.Controls.Add(this.WhiteTimer);
            this.Timer.Controls.Add(this.BlackTimer);
            this.Timer.Controls.Add(this.label2);
            this.Timer.Controls.Add(this.label1);
            this.Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timer.Location = new System.Drawing.Point(642, 138);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(146, 132);
            this.Timer.TabIndex = 1;
            this.Timer.TabStop = false;
            this.Timer.Text = "Timer";
            // 
            // TimeButton
            // 
            this.TimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeButton.Location = new System.Drawing.Point(33, 99);
            this.TimeButton.Name = "TimeButton";
            this.TimeButton.Size = new System.Drawing.Size(75, 27);
            this.TimeButton.TabIndex = 2;
            this.TimeButton.Text = "Start";
            this.TimeButton.UseVisualStyleBackColor = true;
            // 
            // WhiteTimer
            // 
            this.WhiteTimer.AutoSize = true;
            this.WhiteTimer.BackColor = System.Drawing.Color.Orange;
            this.WhiteTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteTimer.Location = new System.Drawing.Point(72, 69);
            this.WhiteTimer.Name = "WhiteTimer";
            this.WhiteTimer.Size = new System.Drawing.Size(44, 18);
            this.WhiteTimer.TabIndex = 3;
            this.WhiteTimer.Text = "00:00";
            // 
            // BlackTimer
            // 
            this.BlackTimer.AutoSize = true;
            this.BlackTimer.BackColor = System.Drawing.Color.Orange;
            this.BlackTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackTimer.Location = new System.Drawing.Point(72, 34);
            this.BlackTimer.Name = "BlackTimer";
            this.BlackTimer.Size = new System.Drawing.Size(44, 18);
            this.BlackTimer.TabIndex = 2;
            this.BlackTimer.Text = "00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "White";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Black";
            // 
            // State
            // 
            this.State.Controls.Add(this.GameState);
            this.State.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.State.Location = new System.Drawing.Point(642, 276);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(146, 78);
            this.State.TabIndex = 2;
            this.State.TabStop = false;
            this.State.Text = "State";
            // 
            // GameState
            // 
            this.GameState.AutoSize = true;
            this.GameState.BackColor = System.Drawing.Color.Transparent;
            this.GameState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameState.ForeColor = System.Drawing.Color.LimeGreen;
            this.GameState.Location = new System.Drawing.Point(31, 31);
            this.GameState.Name = "GameState";
            this.GameState.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GameState.Size = new System.Drawing.Size(73, 22);
            this.GameState.TabIndex = 2;
            this.GameState.Text = "Normal";
            this.GameState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GameState.Click += new System.EventHandler(this.GameState_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(642, 360);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(146, 89);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Score";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(102, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 29);
            this.label9.TabIndex = 5;
            this.label9.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 29);
            this.label8.TabIndex = 4;
            this.label8.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(89, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 18);
            this.label7.TabIndex = 4;
            this.label7.Text = "White";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Black";
            // 
            // Chess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.State);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chess";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Chess_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Undo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Redo)).EndInit();
            this.Timer.ResumeLayout(false);
            this.Timer.PerformLayout();
            this.State.ResumeLayout(false);
            this.State.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.PictureBox Undo;
        private System.Windows.Forms.PictureBox Redo;

        private System.Windows.Forms.GroupBox Timer;
        private System.Windows.Forms.Button TimeButton;
        private System.Windows.Forms.Label WhiteTimer;
        private System.Windows.Forms.Label BlackTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.GroupBox State;
        public System.Windows.Forms.Label GameState;
            
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}

