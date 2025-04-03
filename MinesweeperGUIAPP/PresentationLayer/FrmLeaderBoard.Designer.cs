namespace MinesweeperGUIAPP
{
    partial class FrmLeaderBoard
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
            mnuOptions = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            sortToolStripMenuItem = new ToolStripMenuItem();
            byNameToolStripMenuItem = new ToolStripMenuItem();
            byScoreToolStripMenuItem = new ToolStripMenuItem();
            byDateToolStripMenuItem = new ToolStripMenuItem();
            dgvScoreBoard = new DataGridView();
            mnuOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScoreBoard).BeginInit();
            SuspendLayout();
            // 
            // mnuOptions
            // 
            mnuOptions.ImageScalingSize = new Size(20, 20);
            mnuOptions.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, sortToolStripMenuItem });
            mnuOptions.Location = new Point(0, 0);
            mnuOptions.Name = "mnuOptions";
            mnuOptions.Size = new Size(800, 28);
            mnuOptions.TabIndex = 0;
            mnuOptions.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, loadToolStripMenuItem, exitToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(46, 24);
            toolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(224, 26);
            toolStripMenuItem2.Text = "Save";
            toolStripMenuItem2.Click += SaveToolStrp2ClickEH;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(224, 26);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += LoadToolStripMenuItemClickEH;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(224, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += ExitToolStripMenuItemClickEH;
            // 
            // sortToolStripMenuItem
            // 
            sortToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { byNameToolStripMenuItem, byScoreToolStripMenuItem, byDateToolStripMenuItem });
            sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            sortToolStripMenuItem.Size = new Size(50, 24);
            sortToolStripMenuItem.Text = "Sort";
            // 
            // byNameToolStripMenuItem
            // 
            byNameToolStripMenuItem.Name = "byNameToolStripMenuItem";
            byNameToolStripMenuItem.Size = new Size(224, 26);
            byNameToolStripMenuItem.Text = "By Name";
            byNameToolStripMenuItem.Click += ByNameToolStripMenuItemClickEH;
            // 
            // byScoreToolStripMenuItem
            // 
            byScoreToolStripMenuItem.Name = "byScoreToolStripMenuItem";
            byScoreToolStripMenuItem.Size = new Size(224, 26);
            byScoreToolStripMenuItem.Text = "By Score";
            byScoreToolStripMenuItem.Click += ByScoreToolStripMenuItemClickEH;
            // 
            // byDateToolStripMenuItem
            // 
            byDateToolStripMenuItem.Name = "byDateToolStripMenuItem";
            byDateToolStripMenuItem.Size = new Size(224, 26);
            byDateToolStripMenuItem.Text = "By Date";
            byDateToolStripMenuItem.Click += ByDateToolStripMenuItemClickEH;
            // 
            // dgvScoreBoard
            // 
            dgvScoreBoard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScoreBoard.Location = new Point(12, 42);
            dgvScoreBoard.Name = "dgvScoreBoard";
            dgvScoreBoard.RowHeadersWidth = 51;
            dgvScoreBoard.Size = new Size(488, 396);
            dgvScoreBoard.TabIndex = 1;
            // 
            // FrmLeaderBoard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvScoreBoard);
            Controls.Add(mnuOptions);
            Name = "FrmLeaderBoard";
            Text = "Leaderboard";
            Load += FrmLeaderBoardLoad;
            mnuOptions.ResumeLayout(false);
            mnuOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScoreBoard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuOptions;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem sortToolStripMenuItem;
        private ToolStripMenuItem byNameToolStripMenuItem;
        private ToolStripMenuItem byScoreToolStripMenuItem;
        private ToolStripMenuItem byDateToolStripMenuItem;
        private DataGridView dgvScoreBoard;
    }
}