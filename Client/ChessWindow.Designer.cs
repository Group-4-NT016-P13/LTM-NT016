namespace Client
{
    partial class Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.RestartButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Undo = new System.Windows.Forms.PictureBox();
            this.GameState = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WhiteTimer = new System.Windows.Forms.Label();
            this.TimeButton = new System.Windows.Forms.Button();
            this.BlackTimer = new System.Windows.Forms.Label();
            this.State = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BlackScoreLabel = new System.Windows.Forms.Label();
            this.WhiteScoreLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.refresh = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Undo)).BeginInit();
            this.Timer.SuspendLayout();
            this.State.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // RestartButton
            // 
            this.RestartButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RestartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestartButton.Location = new System.Drawing.Point(31, 92);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(62, 29);
            this.RestartButton.TabIndex = 0;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.Undo);
            this.groupBox1.Controls.Add(this.RestartButton);
            this.groupBox1.Location = new System.Drawing.Point(709, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 137);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Client.Properties.Resources.redoArrow;
            this.pictureBox2.Location = new System.Drawing.Point(67, 32);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // Undo
            // 
            this.Undo.Image = global::Client.Properties.Resources.undoArrrow;
            this.Undo.Location = new System.Drawing.Point(10, 32);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(48, 38);
            this.Undo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Undo.TabIndex = 3;
            this.Undo.TabStop = false;
            // 
            // GameState
            // 
            this.GameState.AutoSize = true;
            this.GameState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameState.ForeColor = System.Drawing.Color.Lime;
            this.GameState.Location = new System.Drawing.Point(10, 29);
            this.GameState.Name = "GameState";
            this.GameState.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GameState.Size = new System.Drawing.Size(87, 20);
            this.GameState.TabIndex = 2;
            this.GameState.Text = "NORMAL";
            // 
            // Timer
            // 
            this.Timer.BackColor = System.Drawing.Color.Transparent;
            this.Timer.Controls.Add(this.label5);
            this.Timer.Controls.Add(this.label4);
            this.Timer.Controls.Add(this.WhiteTimer);
            this.Timer.Controls.Add(this.TimeButton);
            this.Timer.Controls.Add(this.BlackTimer);
            this.Timer.Location = new System.Drawing.Point(709, 146);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(129, 170);
            this.Timer.TabIndex = 3;
            this.Timer.TabStop = false;
            this.Timer.Text = "Timer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "White";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Black";
            // 
            // WhiteTimer
            // 
            this.WhiteTimer.AutoSize = true;
            this.WhiteTimer.BackColor = System.Drawing.Color.Goldenrod;
            this.WhiteTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteTimer.Location = new System.Drawing.Point(66, 77);
            this.WhiteTimer.Name = "WhiteTimer";
            this.WhiteTimer.Size = new System.Drawing.Size(55, 22);
            this.WhiteTimer.TabIndex = 2;
            this.WhiteTimer.Text = "00:00";
            // 
            // TimeButton
            // 
            this.TimeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeButton.Location = new System.Drawing.Point(24, 123);
            this.TimeButton.Name = "TimeButton";
            this.TimeButton.Size = new System.Drawing.Size(77, 27);
            this.TimeButton.TabIndex = 1;
            this.TimeButton.Text = "Start";
            this.TimeButton.UseVisualStyleBackColor = true;
            // 
            // BlackTimer
            // 
            this.BlackTimer.AutoSize = true;
            this.BlackTimer.BackColor = System.Drawing.Color.Goldenrod;
            this.BlackTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackTimer.Location = new System.Drawing.Point(66, 34);
            this.BlackTimer.Name = "BlackTimer";
            this.BlackTimer.Size = new System.Drawing.Size(55, 22);
            this.BlackTimer.TabIndex = 0;
            this.BlackTimer.Text = "00:00";
            // 
            // State
            // 
            this.State.Controls.Add(this.GameState);
            this.State.Location = new System.Drawing.Point(709, 322);
            this.State.Name = "State";
            this.State.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.State.Size = new System.Drawing.Size(131, 70);
            this.State.TabIndex = 4;
            this.State.TabStop = false;
            this.State.Text = "State";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BlackScoreLabel);
            this.groupBox2.Controls.Add(this.WhiteScoreLabel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(709, 410);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 122);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Score";
            // 
            // BlackScoreLabel
            // 
            this.BlackScoreLabel.AutoSize = true;
            this.BlackScoreLabel.BackColor = System.Drawing.Color.Yellow;
            this.BlackScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackScoreLabel.Location = new System.Drawing.Point(100, 37);
            this.BlackScoreLabel.Name = "BlackScoreLabel";
            this.BlackScoreLabel.Size = new System.Drawing.Size(19, 20);
            this.BlackScoreLabel.TabIndex = 7;
            this.BlackScoreLabel.Text = "0";
            // 
            // WhiteScoreLabel
            // 
            this.WhiteScoreLabel.AutoSize = true;
            this.WhiteScoreLabel.BackColor = System.Drawing.Color.Yellow;
            this.WhiteScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteScoreLabel.Location = new System.Drawing.Point(102, 86);
            this.WhiteScoreLabel.Name = "WhiteScoreLabel";
            this.WhiteScoreLabel.Size = new System.Drawing.Size(19, 20);
            this.WhiteScoreLabel.TabIndex = 6;
            this.WhiteScoreLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Player B:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Player W:";
            // 
            // refresh
            // 
            this.refresh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.refresh.Location = new System.Drawing.Point(709, 548);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(131, 30);
            this.refresh.TabIndex = 6;
            this.refresh.Text = "Ván Mới";
            this.refresh.UseVisualStyleBackColor = false;
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.ForeColor = System.Drawing.Color.Green;
            this.exit.Location = new System.Drawing.Point(733, 584);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(80, 34);
            this.exit.TabIndex = 7;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Chess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(842, 628);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.State);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(860, 675);
            this.MinimumSize = new System.Drawing.Size(575, 562);
            this.Name = "Chess";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Chess_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Undo)).EndInit();
            this.Timer.ResumeLayout(false);
            this.Timer.PerformLayout();
            this.State.ResumeLayout(false);
            this.State.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label GameState;
        private System.Windows.Forms.GroupBox Timer;
        private System.Windows.Forms.Label BlackTimer;
        private System.Windows.Forms.Button TimeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label WhiteTimer;
        private System.Windows.Forms.PictureBox Undo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox State;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label BlackScoreLabel;
        private System.Windows.Forms.Label WhiteScoreLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Button exit;
    }
}


