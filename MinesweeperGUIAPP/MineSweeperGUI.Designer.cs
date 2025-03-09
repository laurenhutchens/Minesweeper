namespace MinesweeperGUIAPP
{
    partial class MineSweeperGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
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
            SuspendLayout();
            // 
            // btnStartGame
            // 
            btnStartGame.Location = new Point(668, 23);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(94, 29);
            btnStartGame.TabIndex = 5;
            btnStartGame.Text = "Start Game";
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Click += BtnStartGame_Click;
            // 
            // tmrGameTime
            // 
            tmrGameTime.Interval = 1000;
            tmrGameTime.Tick += TmrGameTime_Tick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(644, 240);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 10;
            label3.Text = "Time:";
            // 
            // lblGameTime
            // 
            lblGameTime.AutoSize = true;
            lblGameTime.Location = new Point(713, 240);
            lblGameTime.Name = "lblGameTime";
            lblGameTime.Size = new Size(25, 20);
            lblGameTime.TabIndex = 11;
            lblGameTime.Text = "00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(644, 281);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 12;
            label4.Text = "Score:";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(713, 281);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(25, 20);
            lblScore.TabIndex = 13;
            lblScore.Text = "00";
            // 
            // MineSweeperGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblScore);
            Controls.Add(label4);
            Controls.Add(lblGameTime);
            Controls.Add(label3);
            Controls.Add(btnStartGame);
            Name = "MineSweeperGUI";
            Text = "Minesweeper";
            Load += Form1_Load;
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
    }
}
