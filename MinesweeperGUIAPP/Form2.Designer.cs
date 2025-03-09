namespace MinesweeperGUIAPP
{
    partial class FrmStartaNewGame
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
            lblPlayMinesweeper = new Label();
            hsbSize = new HScrollBar();
            hsbDifficulty = new HScrollBar();
            lblSize = new Label();
            lblDifficulty = new Label();
            btnPlay = new Button();
            SuspendLayout();
            // 
            // lblPlayMinesweeper
            // 
            lblPlayMinesweeper.AutoSize = true;
            lblPlayMinesweeper.Location = new Point(57, 30);
            lblPlayMinesweeper.Name = "lblPlayMinesweeper";
            lblPlayMinesweeper.Size = new Size(132, 20);
            lblPlayMinesweeper.TabIndex = 0;
            lblPlayMinesweeper.Text = "Play Minesweeper!";
            // 
            // hsbSize
            // 
            hsbSize.Location = new Point(57, 153);
            hsbSize.Name = "hsbSize";
            hsbSize.Size = new Size(236, 26);
            hsbSize.TabIndex = 1;
            // 
            // hsbDifficulty
            // 
            hsbDifficulty.Location = new Point(57, 265);
            hsbDifficulty.Name = "hsbDifficulty";
            hsbDifficulty.Size = new Size(236, 26);
            hsbDifficulty.TabIndex = 2;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(57, 116);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(36, 20);
            lblSize.TabIndex = 3;
            lblSize.Text = "Size";
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.Location = new Point(57, 230);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(69, 20);
            lblDifficulty.TabIndex = 4;
            lblDifficulty.Text = "Difficulty";
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(303, 303);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(94, 29);
            btnPlay.TabIndex = 5;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            // 
            // FrmStartaNewGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPlay);
            Controls.Add(lblDifficulty);
            Controls.Add(lblSize);
            Controls.Add(hsbDifficulty);
            Controls.Add(hsbSize);
            Controls.Add(lblPlayMinesweeper);
            Name = "FrmStartaNewGame";
            Text = "Start a New Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlayMinesweeper;
        private HScrollBar hsbSize;
        private HScrollBar hsbDifficulty;
        private Label lblSize;
        private Label lblDifficulty;
        private Button btnPlay;
    }
}