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
            label2 = new Label();
            label1 = new Label();
            hsbSize = new HScrollBar();
            hsbDifficulty = new HScrollBar();
            btnStartGame = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(678, 67);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 9;
            label2.Text = "Difficulty";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(690, 146);
            label1.Name = "label1";
            label1.Size = new Size(36, 20);
            label1.TabIndex = 8;
            label1.Text = "Size";
            // 
            // hsbSize
            // 
            hsbSize.LargeChange = 5;
            hsbSize.Location = new Point(662, 185);
            hsbSize.Maximum = 20;
            hsbSize.Minimum = 5;
            hsbSize.Name = "hsbSize";
            hsbSize.Size = new Size(100, 26);
            hsbSize.TabIndex = 7;
            hsbSize.Value = 5;
            // 
            // hsbDifficulty
            // 
            hsbDifficulty.LargeChange = 1;
            hsbDifficulty.Location = new Point(662, 100);
            hsbDifficulty.Maximum = 3;
            hsbDifficulty.Minimum = 1;
            hsbDifficulty.Name = "hsbDifficulty";
            hsbDifficulty.Size = new Size(100, 26);
            hsbDifficulty.TabIndex = 6;
            hsbDifficulty.Value = 1;
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
            // MineSweeperGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(hsbSize);
            Controls.Add(hsbDifficulty);
            Controls.Add(btnStartGame);
            Name = "MineSweeperGUI";
            Text = "Minesweeper";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private HScrollBar hsbSize;
        private HScrollBar hsbDifficulty;
        private Button btnStartGame;
    }
}
