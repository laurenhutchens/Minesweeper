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
<<<<<<< HEAD
            btnRestartGame = new Button();
=======
            components = new System.ComponentModel.Container();
            btnStartGame = new Button();
            btnReset = new Button();
>>>>>>> mdevarie
            label1 = new Label();
            lblScoreAmount = new Label();
            lblStartTime = new Label();
            lblTimer = new Label();
<<<<<<< HEAD
=======
            hsbDifficulty = new HScrollBar();
            hsbSize = new HScrollBar();
            label2 = new Label();
            label3 = new Label();
            tmr = new System.Windows.Forms.Timer(components);
>>>>>>> mdevarie
            SuspendLayout();
            // 
            // btnRestartGame
            // 
            btnRestartGame.Location = new Point(627, 158);
            btnRestartGame.Name = "btnRestartGame";
            btnRestartGame.Size = new Size(94, 29);
            btnRestartGame.TabIndex = 1;
            btnRestartGame.Text = "Restart Gane";
            btnRestartGame.UseVisualStyleBackColor = true;
            btnRestartGame.Click += BtnRestartClickEH;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(627, 95);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 2;
            label1.Text = "Score: ";
            // 
            // lblScoreAmount
            // 
            lblScoreAmount.AutoSize = true;
            lblScoreAmount.Location = new Point(723, 95);
            lblScoreAmount.Name = "lblScoreAmount";
            lblScoreAmount.Size = new Size(25, 20);
            lblScoreAmount.TabIndex = 3;
            lblScoreAmount.Text = "00";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(627, 48);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(80, 20);
            lblStartTime.TabIndex = 4;
            lblStartTime.Text = "Start Time:";
            lblStartTime.TextAlign = ContentAlignment.TopRight;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Location = new Point(723, 48);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(25, 20);
            lblTimer.TabIndex = 5;
            lblTimer.Text = "00";
            // 
            // MineSweeperGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTimer);
            Controls.Add(lblStartTime);
            Controls.Add(lblScoreAmount);
            Controls.Add(label1);
            Controls.Add(btnRestartGame);
            Name = "MineSweeperGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MineSweeper";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartGame;
        private Button btnRestartGame;
        private Label label1;
        private Label lblScoreAmount;
        private Label lblStartTime;
        private Label lblTimer;
<<<<<<< HEAD
=======
        private HScrollBar hsbDifficulty;
        private HScrollBar hsbSize;
        private Label label2;
        private Label label3;
        private System.Windows.Forms.Timer tmr;
>>>>>>> mdevarie
    }
}
