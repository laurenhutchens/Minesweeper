/* Arie Gerard and Lauren Hutchens 
 * CST-250
 * Minesweeper 
 * Bill Hughes
 * 04/13/2025
 */

using MineSweeperClasses.Models;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace MinesweeperGUIAPP

{
    public partial class FrmStart : Form
    {
        //class level variables 
        private int secondsElapsed;
        private MinesweeperGameLogic gameLogic;
        private BoardModel boardModel;
        private Button[,] btnBoard;
        private int score;
        public string finalScore;




        //Getter and setters for the lbl to transfer data from the secondary form to the main form 
        public String DifficultyText
        {
            get { return lblDifficulty.Text; }
            set { lblDifficulty.Text = value; }
        }
        //Getter and setters for the lbl to transfer data from the secondary form to the main form 
        public String SizeText
        {
            get { return lblSize.Text; }
            set { lblSize.Text = value; }
        }
        
        public FrmStart()
        {
            InitializeComponent();
        }

        string basePath = Path.Combine(Application.StartupPath, "Images");

        /// <summary>
        /// Method to initalize the board buttons 
        /// </summary>
        /// <param name="size"></param>
        private void InitializeBoardButtons(int size)
        {
            btnBoard = new Button[size, size];

            // Reset all cells' IsVisited flag to false before starting a new game
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    boardModel.Cells[row, col].IsVisited = false; // Reset the visited status
                }
            }
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Button btn = new Button
                    {
                        Width = 30, // Adjust size as needed
                        Height = 30, // Adjust size as needed
                        Tag = new Point(row, col) // Store the cell coordinates in the button's Tag property
                    };

                    // Attach the click event handler
                    btn.MouseUp += CellButton_MouseUp;

                    // Position the buttons on the form
                    btn.Location = new Point(col * 30, row * 30);
                    btnBoard[row, col] = btn;
                    this.Controls.Add(btn); // Add the button to the form
                }
            }
        }

        /// <summary>
        /// Method to check if there was a right click 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void CellButton_MouseUp(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;
            int row = location.X;
            int col = location.Y;

            if (e.Button == MouseButtons.Right) // Check for right-click
            {
                // Toggle flag state
                // Toggle the flag state for the cell in your data model
                boardModel.Cells[row, col].IsFlagged = !boardModel.Cells[row, col].IsFlagged;

                // Update the UI based on the new flag state
                if (boardModel.Cells[row, col].IsFlagged)
                {
                    clickedButton.BackgroundImage = Image.FromFile(Path.Combine(basePath, "Gold.png"));
                    clickedButton.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    clickedButton.BackgroundImage = null;
                }
                clickedButton.Invalidate(); // Force a visual update
                // Update the GUI after making changes
                UpdateBoardGUI();
            }
            else if (e.Button == MouseButtons.Left) // Check for left-click
            {
                // Make the move in the game logic
                gameLogic.MakeMove(row, col);

                // Get the clicked cell from the game logic to check its status
                var clickedCell = boardModel.Cells[row, col];

                if (!clickedCell.IsVisited)
                {
                    score += 200;
                    lblScore.Text = score.ToString();
                }

                // If the clicked cell has no bomb neighbors, trigger flood fill
                if (clickedCell.NumberOfBombNeighbors == 0)
                {
                    FloodFill(boardModel, row, col, this);
                    Debug.WriteLine("Called");
                    UpdateBoardGUI();
                }
                else
                {
                    boardModel.Cells[row, col].IsVisited = true;
                    UpdateBoardGUI();
                }

                // Check if the game is won or lost
                CheckGameStatus();
            }

        }
        /// <summary>
        /// Method to update the board GUI
        /// </summary>
        private void UpdateBoardGUI()
        {
            for (int row = 0; row < boardModel.Size; row++)
            {
                for (int col = 0; col < boardModel.Size; col++)
                {
                    var cell = boardModel.Cells[row, col];
                    Button cellButton = btnBoard[row, col];

                    if (cell.IsVisited)
                    {
                        if (cell.IsBomb)
                        {
                            cellButton.Text = "B";
                            cellButton.BackgroundImage = Image.FromFile(Path.Combine(basePath, "Skull.png"));
                        }
                        else if (cell.NumberOfBombNeighbors == 0)
                        {
                            cellButton.Text = ".";
                            cellButton.BackgroundImage = Image.FromFile(Path.Combine(basePath, "Tile Flat.png"));
                        }
                        else
                        {
                            cellButton.Text = cell.NumberOfBombNeighbors.ToString();
                            cellButton.BackgroundImage = Image.FromFile(Path.Combine(basePath, $"Number {cell.NumberOfBombNeighbors}.png"));
                        }

                        cellButton.BackgroundImageLayout = ImageLayout.Stretch;
                        cellButton.Enabled = false;
                    }
                    else
                    {
                        cellButton.Text = "";
                        cellButton.Enabled = true;
                        cellButton.BackgroundImage = Image.FromFile(Path.Combine(basePath, "Tile Flat.png"));
                        cellButton.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
            Refresh();
        }
        private void CheckGameStatus()
        {
            var gameStatus = boardModel.DetermineGameStatus();

            if (gameStatus == BoardModel.GameStatus.Won)
            {
                MessageBox.Show("Congratulations, You Won!");

                int score = int.Parse(lblScore.Text);
                TimeSpan gameTime;

                if (TimeSpan.TryParse(lblGameTime.Text, out gameTime))
                {
                    string playerName = "Player"; // <-- Add this line
                    FrmLeaderBoard frmLeaderBoard = new FrmLeaderBoard(playerName, score, gameTime); // <-- Now 3 parameters
                    frmLeaderBoard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid game time format. Cannot display results.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ResetGame();
            }
            else if (gameStatus == BoardModel.GameStatus.Lost)
            {
                MessageBox.Show("Game Over! You hit a bomb.");

                int score = int.Parse(lblScore.Text);
                TimeSpan gameTime;

                if (TimeSpan.TryParse(lblGameTime.Text, out gameTime))
                {
                    tmrGameTime.Stop();
                    string playerName = "Player"; // <-- Add this line
                    FrmLeaderBoard frmLeaderBoard = new FrmLeaderBoard(playerName, score, gameTime); // <-- Now 3 parameters
                    frmLeaderBoard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid game time format. Cannot display results.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ResetGame();
            }
        }


        /// <summary>
        /// Button for showing a bomb location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHintClickEH(object sender, EventArgs e)
        {
            // Implement hint game logic.
            var bombCoordinates = gameLogic.GetRandomBombCoordinates();

            //Checks if the bomb coordinates has a value to check if there is a bomb on the board. 
            if (bombCoordinates.HasValue)
            {
                // Show the bomb's coordinates in a message box.
                MessageBox.Show($"Bomb found at: Row {bombCoordinates.Value.Item1}, Column {bombCoordinates.Value.Item2}");
            }
            else
            {
                // If no bombs are found (unexpected scenario), show an appropriate message.
                MessageBox.Show("No bombs found on the board.");
            }

        }

        /// <summary>
        /// Reset game event. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResetGameClickEH(object sender, EventArgs e)
        {
            secondsElapsed = 0;
            lblGameTime.Text = "00:00:00";

            foreach (var button in btnBoard)
            {
                this.Controls.Remove(button); // Remove buttons from the form
            }
            score = 0;
            lblScore.Text = score.ToString();
        }
        //Put floodfill into the GameLogic
        /// <summary>
        /// Floofiill to update the gui starting from where an empty cell is clicked to fill in other empty cells. 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="gui"></param>
        public static void FloodFill(BoardModel board, int x, int y, FrmStart gui)
        {
            Debug.WriteLine("x: " + x + " y: " + y);
            // Boundary check
            if (x < 0 || x >= board.Size || y < 0 || y >= board.Size)
            {
                Debug.WriteLine("Boundary Check Fail: ", x, y);
                return;
            }

            // Stop if the cell is already visited, is a bomb, or has already been revealed
            if (board.Cells[x, y].IsVisited || board.Cells[x, y].IsBomb || board.Cells[x, y].NumberOfBombNeighbors > 0)
            {
                Debug.WriteLine("Is Visited: " + board.Cells[x, y].IsVisited + " is Bomb: " + board.Cells[x, y].IsBomb);
                return;
            }

            Debug.WriteLine("Setting visited to true");
            // Mark the cell as visited
            board.Cells[x, y].IsVisited = true;


            // Update the board UI after visiting the cell
            gui.UpdateBoardGUI();


            // Recursively reveal adjacent empty cells
            FloodFill(board, x + 1, y, gui);  // Right
            Debug.WriteLine("RIght");
            FloodFill(board, x - 1, y, gui);
            Debug.WriteLine("left");// Left
            FloodFill(board, x, y + 1, gui);
            Debug.WriteLine("down");// Down
            FloodFill(board, x, y - 1, gui);
            Debug.WriteLine("up");// Up

        }
        /// <summary>
        /// Tine for game timer 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TmrGameTime_Tick(object sender, EventArgs e)
        {
            {
                secondsElapsed++;
                lblGameTime.Text = TimeSpan.FromSeconds(secondsElapsed).ToString();
                score -= 1;
                lblScore.Text = score.ToString();
            }
        }

        /// <summary>
        /// Button for resetting the game 
        /// </summary>
        private void ResetGame()
        {
            secondsElapsed = 0;
            lblGameTime.Text = "00:00:00";
            tmrGameTime.Stop();

            foreach (var button in btnBoard)
            {
                this.Controls.Remove(button); // Remove buttons from the form
            }
            score = 0;
            lblScore.Text = score.ToString();
        }
        /// <summary>
        /// form load to grab the difficulty and size from the secondary form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStartLoadEH(object sender, EventArgs e)
        {
            MessageBox.Show($"Size: {SizeText}, Difficulty: {DifficultyText}");

            // Convert values to integers
            int size = int.TryParse(SizeText, out int s) ? s : 5;  // Default to 5 if conversion fails
            int difficulty = int.TryParse(DifficultyText, out int d) ? d : 3;  // Default to 3 if conversion fails

            // Initialize game logic
            gameLogic = new MinesweeperGameLogic(size, difficulty);
            boardModel = gameLogic.GetBoardModel();

            // Initialize the board buttons
            InitializeBoardButtons(size);
            UpdateBoardGUI();
        }

        /// <summary>
        /// STart game to initialize and update the board as the game is played 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartGameClickEH(object sender, EventArgs e)
        {
            tmrGameTime.Tick += new EventHandler(TmrGameTime_Tick);
            score = 0;
            secondsElapsed = 0;
            tmrGameTime.Start();

            try
            {
                // Safely convert values and handle invalid input
                int size = Convert.ToInt32(SizeText);
                int difficulty = Convert.ToInt32(DifficultyText);

                gameLogic = new MinesweeperGameLogic(size, difficulty);
                boardModel = gameLogic.GetBoardModel();
                InitializeBoardButtons(size);
                UpdateBoardGUI();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please Select Difficulty first.", "Input Error");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Please Select Difficulty first.", "Input Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error");
            }
        }


        /// <summary>
        /// Evnent handler to choose the difficulty of the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChooseDifficultyClickEH(object sender, EventArgs e)
        {
            // New Form to choose the difficulty
            FrmPlay frmPlay = new FrmPlay();
            
            frmPlay.Show();
            frmPlay.FormClosed += (s, args) => this.Show();
        }
    }
}
