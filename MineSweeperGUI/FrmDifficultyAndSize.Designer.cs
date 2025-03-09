namespace MineSweeperGUI
{
    partial class FrmDifficultyAndSize
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
            hsbSize = new HScrollBar();
            hsbDifficulty = new HScrollBar();
            lblPlayMineSweeper = new Label();
            lblSize = new Label();
            lblDifficulty = new Label();
            btnPlay = new Button();
            SuspendLayout();
            // 
            // hsbSize
            // 
            hsbSize.Location = new Point(12, 100);
            hsbSize.Name = "hsbSize";
            hsbSize.Size = new Size(301, 26);
            hsbSize.TabIndex = 0;
            // 
            // hsbDifficulty
            // 
            hsbDifficulty.Location = new Point(12, 199);
            hsbDifficulty.Name = "hsbDifficulty";
            hsbDifficulty.Size = new Size(301, 26);
            hsbDifficulty.TabIndex = 1;
            // 
            // lblPlayMineSweeper
            // 
            lblPlayMineSweeper.AutoSize = true;
            lblPlayMineSweeper.Location = new Point(12, 20);
            lblPlayMineSweeper.Name = "lblPlayMineSweeper";
            lblPlayMineSweeper.Size = new Size(134, 20);
            lblPlayMineSweeper.TabIndex = 2;
            lblPlayMineSweeper.Text = "Play MineSweeper!";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(12, 71);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(36, 20);
            lblSize.TabIndex = 3;
            lblSize.Text = "Size";
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.Location = new Point(12, 179);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(69, 20);
            lblDifficulty.TabIndex = 4;
            lblDifficulty.Text = "Difficulty";
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(74, 228);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(94, 29);
            btnPlay.TabIndex = 5;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += BtnPlayClickEH;
            // 
            // FrmDifficultyAndSize
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPlay);
            Controls.Add(lblDifficulty);
            Controls.Add(lblSize);
            Controls.Add(lblPlayMineSweeper);
            Controls.Add(hsbDifficulty);
            Controls.Add(hsbSize);
            Name = "FrmDifficultyAndSize";
            Text = "FrmDifficultyAndSize";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private HScrollBar hsbSize;
        private HScrollBar hsbDifficulty;
        private Label lblPlayMineSweeper;
        private Label lblSize;
        private Label lblDifficulty;
        private Button btnPlay;
    }
}