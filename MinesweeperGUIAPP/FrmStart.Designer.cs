
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
            lblTime = new Label();
            lblGameTime = new Label();
            lblScore = new Label();
            btnChooseDifficulty = new Button();
            hsbSize = new TrackBar();
            hsbDifficulty = new TrackBar();
            labelScore = new Label();
            labelGameScore = new Label();
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
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(626, 28);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(45, 20);
            lblTime.TabIndex = 10;
            lblTime.Text = "Time:";
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
            // lblScore
            // 
            lblScore.Location = new Point(0, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(100, 23);
            lblScore.TabIndex = 18;
            // 
            // btnChooseDifficulty
            // 
            btnChooseDifficulty.Location = new Point(656, 188);
            btnChooseDifficulty.Name = "btnChooseDifficulty";
            btnChooseDifficulty.Size = new Size(94, 29);
            btnChooseDifficulty.TabIndex = 14;
            btnChooseDifficulty.Text = "Choose Difficulty";
            btnChooseDifficulty.UseVisualStyleBackColor = true;
            btnChooseDifficulty.Click += BtnChooseDifficultyClickEH;
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
            // labelScore
            // 
            labelScore.Location = new Point(626, 76);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(51, 23);
            labelScore.TabIndex = 0;
            labelScore.Text = "Score: ";
            // 
            // labelGameScore
            // 
            labelGameScore.AutoSize = true;
            labelGameScore.Location = new Point(695, 76);
            labelGameScore.Name = "labelGameScore";
            labelGameScore.Size = new Size(25, 20);
            labelGameScore.TabIndex = 19;
            labelGameScore.Text = "00";
            // 
            // FrmStart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelGameScore);
            Controls.Add(labelScore);
            Controls.Add(hsbDifficulty);
            Controls.Add(hsbSize);
            Controls.Add(btnChooseDifficulty);
            Controls.Add(lblScore);
            Controls.Add(lblGameTime);
            Controls.Add(lblTime);
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
        private Label lblTime;
        private Label lblGameTime;
        private Label lblFrmStartScore;
        private Label lblScore;
        private Button btnChooseDifficulty;
        private TrackBar hsbSize;
        private TrackBar hsbDifficulty;
        private Label labelScore;
        private Label labelGameScore;
    }
}