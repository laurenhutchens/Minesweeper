
namespace MinesweeperGUIAPP
{
    partial class FrmStart
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
            components = new System.ComponentModel.Container();
            btnStartGame = new Button();
            tmrGameTime = new System.Windows.Forms.Timer(components);
            label3 = new Label();
            lblGameTime = new Label();
            label4 = new Label();
            lblScore = new Label();
            btnChooseDifficulty = new Button();
            hsbSize = new TrackBar();
            hsbDifficulty = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)hsbSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hsbDifficulty).BeginInit();
            SuspendLayout();
            // 
            // btnStartGame
            // 
            btnStartGame.Location = new Point(656, 125);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(94, 29);
            btnStartGame.TabIndex = 5;
            btnStartGame.Text = "Start Game";
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Click += BtnStartGameClickEH;
            // 
            // tmrGameTime
            // 
            tmrGameTime.Interval = 1000;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(626, 28);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 10;
            label3.Text = "Time:";
            // 
            // lblGameTime
            // 
            lblGameTime.AutoSize = true;
            lblGameTime.Location = new Point(695, 28);
            lblGameTime.Name = "lblGameTime";
            lblGameTime.Size = new Size(25, 20);
            lblGameTime.TabIndex = 11;
            lblGameTime.Text = "00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(626, 69);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 12;
            label4.Text = "Score:";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(695, 69);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(25, 20);
            lblScore.TabIndex = 13;
            lblScore.Text = "00";
            // 
            // btnChooseDifficulty
            // 
            btnChooseDifficulty.Location = new Point(656, 188);
            btnChooseDifficulty.Name = "btnChooseDifficulty";
            btnChooseDifficulty.Size = new Size(94, 29);
            btnChooseDifficulty.TabIndex = 14;
            btnChooseDifficulty.Text = "Choose Difficulty";
            btnChooseDifficulty.UseVisualStyleBackColor = true;
            // 
            // hsbSize
            // 
            hsbSize.Location = new Point(626, 251);
            hsbSize.Maximum = 20;
            hsbSize.Minimum = 5;
            hsbSize.Name = "hsbSize";
            hsbSize.Size = new Size(130, 56);
            hsbSize.SmallChange = 5;
            hsbSize.TabIndex = 15;
            hsbSize.Value = 5;
            // 
            // hsbDifficulty
            // 
            hsbDifficulty.Location = new Point(626, 313);
            hsbDifficulty.Maximum = 3;
            hsbDifficulty.Minimum = 1;
            hsbDifficulty.Name = "hsbDifficulty";
            hsbDifficulty.Size = new Size(130, 56);
            hsbDifficulty.TabIndex = 16;
            hsbDifficulty.Value = 1;
            // 
            // FrmStart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(hsbDifficulty);
            Controls.Add(hsbSize);
            Controls.Add(btnChooseDifficulty);
            Controls.Add(lblScore);
            Controls.Add(label4);
            Controls.Add(lblGameTime);
            Controls.Add(label3);
            Controls.Add(btnStartGame);
            Name = "FrmStart";
            Text = "Minesweeper";
            Load += FrmStart_Load;
            ((System.ComponentModel.ISupportInitialize)hsbSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)hsbDifficulty).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }








        #endregion

        private Button btnStartGame;
        private System.Windows.Forms.Timer tmrGameTime;
        private Label label3;
        private Label lblGameTime;
        private Label label4;
        private Label lblScore;
        private Button btnChooseDifficulty;
        private TrackBar hsbSize;
        private TrackBar hsbDifficulty;
    }
}