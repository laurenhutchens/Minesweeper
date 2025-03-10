namespace MinesweeperGUIAPP
{
    partial class FrmPlay
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
            trbSize = new TrackBar();
            trbDifficulty = new TrackBar();
            lblSize = new Label();
            lblDifficulty = new Label();
            lblPlayMinesweeper = new Label();
            btnPlay = new Button();
            ((System.ComponentModel.ISupportInitialize)trbSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trbDifficulty).BeginInit();
            SuspendLayout();
            // 
            // trbSize
            // 
            trbSize.Location = new Point(63, 131);
            trbSize.Maximum = 25;
            trbSize.Minimum = 5;
            trbSize.Name = "trbSize";
            trbSize.Size = new Size(130, 56);
            trbSize.SmallChange = 5;
            trbSize.TabIndex = 0;
            trbSize.Value = 5;
            // 
            // trbDifficulty
            // 
            trbDifficulty.Location = new Point(63, 273);
            trbDifficulty.Maximum = 3;
            trbDifficulty.Minimum = 1;
            trbDifficulty.Name = "trbDifficulty";
            trbDifficulty.Size = new Size(130, 56);
            trbDifficulty.TabIndex = 1;
            trbDifficulty.Value = 1;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(106, 96);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(36, 20);
            lblSize.TabIndex = 2;
            lblSize.Text = "Size";
            // 
            // lblDifficulty
            // 
            lblDifficulty.AutoSize = true;
            lblDifficulty.Location = new Point(92, 229);
            lblDifficulty.Name = "lblDifficulty";
            lblDifficulty.Size = new Size(69, 20);
            lblDifficulty.TabIndex = 3;
            lblDifficulty.Text = "Difficulty";
            // 
            // lblPlayMinesweeper
            // 
            lblPlayMinesweeper.AutoSize = true;
            lblPlayMinesweeper.Location = new Point(38, 29);
            lblPlayMinesweeper.Name = "lblPlayMinesweeper";
            lblPlayMinesweeper.Size = new Size(184, 20);
            lblPlayMinesweeper.TabIndex = 5;
            lblPlayMinesweeper.Text = "Choose Difficulty And Size";
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(99, 354);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(94, 29);
            btnPlay.TabIndex = 6;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += BtnPlayClickEH;
            // 
            // FrmPlay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPlay);
            Controls.Add(lblPlayMinesweeper);
            Controls.Add(lblDifficulty);
            Controls.Add(lblSize);
            Controls.Add(trbDifficulty);
            Controls.Add(trbSize);
            Name = "FrmPlay";
            Text = "FrmPlay";
            Load += FrmPlayLoadEH;
            ((System.ComponentModel.ISupportInitialize)trbSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)trbDifficulty).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trbSize;
        private TrackBar trbDifficulty;
        public Label lblSize;
        public Label lblDifficulty;
        private Label lblPlayMinesweeper;
        private Button btnPlay;
    }
}