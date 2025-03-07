namespace MineSweeperGUI
{
    partial class MineSweeperGame
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
            btnReset = new Button();
            label1 = new Label();
            lblScoreAmount = new Label();
            lblStartTime = new Label();
            lblTimer = new Label();
            hsbDifficulty = new HScrollBar();
            hsbSize = new HScrollBar();
            label2 = new Label();
            label3 = new Label();
            tmr = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnStartGame
            // 
            btnStartGame.Location = new Point(627, 103);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(94, 29);
            btnStartGame.TabIndex = 0;
            btnStartGame.Text = "Start Game";
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Click += btnStartGame_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(627, 158);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 1;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(627, 63);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 2;
            label1.Text = "Score: ";
            // 
            // lblScoreAmount
            // 
            lblScoreAmount.AutoSize = true;
            lblScoreAmount.Location = new Point(723, 63);
            lblScoreAmount.Name = "lblScoreAmount";
            lblScoreAmount.Size = new Size(25, 20);
            lblScoreAmount.TabIndex = 3;
            lblScoreAmount.Text = "00";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(627, 16);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(80, 20);
            lblStartTime.TabIndex = 4;
            lblStartTime.Text = "Start Time:";
            lblStartTime.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(723, 16);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(25, 20);
            lblTimer.TabIndex = 5;
            lblTimer.Text = "00";
            // 
            // hsbDifficulty
            // 
            hsbDifficulty.LargeChange = 3;
            hsbDifficulty.Location = new Point(627, 230);
            hsbDifficulty.Maximum = 3;
            hsbDifficulty.Minimum = 1;
            hsbDifficulty.Name = "hsbDifficulty";
            hsbDifficulty.Size = new Size(164, 26);
            hsbDifficulty.TabIndex = 7;
            hsbDifficulty.Value = 1;
            // 
            // hsbSize
            // 
            hsbSize.Location = new Point(621, 327);
            hsbSize.Maximum = 20;
            hsbSize.Minimum = 5;
            hsbSize.Name = "hsbSize";
            hsbSize.Size = new Size(170, 26);
            hsbSize.TabIndex = 8;
            hsbSize.Value = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(686, 210);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 9;
            label2.Text = "Difficulty";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(686, 307);
            label3.Name = "label3";
            label3.Size = new Size(36, 20);
            label3.TabIndex = 10;
            label3.Text = "Size";
            // 
            // MineSweeperGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(hsbSize);
            Controls.Add(hsbDifficulty);
            Controls.Add(lblTimer);
            Controls.Add(lblStartTime);
            Controls.Add(lblScoreAmount);
            Controls.Add(label1);
            Controls.Add(btnReset);
            Controls.Add(btnStartGame);
            Name = "MineSweeperGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MineSweeper";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartGame;
        private Button btnReset;
        private Label label1;
        private Label lblScoreAmount;
        private Label lblStartTime;
        private Label lblTimer;
        private HScrollBar hsbDifficulty;
        private HScrollBar hsbSize;
        private Label label2;
        private Label label3;
        private System.Windows.Forms.Timer tmr;
    }
}
