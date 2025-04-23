
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
            btnReset = new Button();
            lblDifficulty = new Label();
            lblSize = new Label();
            btnHint = new Button();
            tmrLoadIn = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnStartGame
            // 
            btnStartGame.Location = new Point(645, 124);
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
            btnChooseDifficulty.Location = new Point(626, 184);
            btnChooseDifficulty.Name = "btnChooseDifficulty";
            btnChooseDifficulty.Size = new Size(130, 29);
            btnChooseDifficulty.TabIndex = 14;
            btnChooseDifficulty.Text = "Choose Difficulty";
            btnChooseDifficulty.UseVisualStyleBackColor = true;
            btnChooseDifficulty.Click += BtnChooseDifficultyClickEH;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(645, 247);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 17;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += BtnResetGameClickEH;
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.Location = new Point(661, 318);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(50, 20);
            lblDifficulty.TabIndex = 18;
            lblDifficulty.Text = "label1";
            lblDifficulty.Visible = false;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(661, 350);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(50, 20);
            lblSize.TabIndex = 19;
            lblSize.Text = "label1";
            lblSize.Visible = false;
            // 
            // btnHint
            // 
            btnHint.Location = new Point(645, 389);
            btnHint.Name = "btnHint";
            btnHint.Size = new Size(94, 29);
            btnHint.TabIndex = 20;
            btnHint.Text = "Hint";
            btnHint.UseVisualStyleBackColor = true;
            btnHint.Click += BtnHintClickEH;
            // 
            // tmrLoadIn
            // 
            // 
            // FrmStart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnHint);
            Controls.Add(lblSize);
            Controls.Add(lblDifficulty);
            Controls.Add(btnReset);
            Controls.Add(btnChooseDifficulty);
            Controls.Add(lblScore);
            Controls.Add(label4);
            Controls.Add(lblGameTime);
            Controls.Add(label3);
            Controls.Add(btnStartGame);
            Name = "FrmStart";
            Text = "Minesweeper";
            Load += FrmStartLoadEH;
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
        private Button btnReset;
        private Label lblDifficulty;
        private Label lblSize;
        private Button btnHint;
        private System.Windows.Forms.Timer tmrLoadIn;
    }
}