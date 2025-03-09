using MineSweeperClasses;
using MineSweeperClasses.Models;
using System.Diagnostics;
namespace MinesweeperGUIAPP
{
    public partial class FrmStart : Form
    {
        private int secondsElapsed;
        private MinesweeperGameLogic gameLogic;
        private BoardModel boardModel;
        private Button[,] btnBoard;
        private int score;

        private TrackBar hsbSize;
        private TrackBar hsbDifficulty;

        public FrmStart()
        {
            InitializeComponent();

            // Create and initialize hsbSize
            hsbSize = new TrackBar();
            hsbSize.Minimum = 5;  // Set minimum value (adjust as needed)
            hsbSize.Maximum = 20; // Set maximum value (adjust as needed)
            hsbSize.Value = 10; // Set default value (adjust as needed)
            hsbSize.Location = new Point(10, 10); // Set location (adjust as needed)
            hsbSize.Size = new Size(200, 45); // Set size (adjust as needed)
            this.Controls.Add(hsbSize); // Add to form

            // Create and initialize hsbDifficulty
            hsbDifficulty = new TrackBar();
            hsbDifficulty.Minimum = 1; // Set the minimum value
            hsbDifficulty.Maximum = 3; // Set the maximum value
            hsbDifficulty.Value = 1;   // Set the initial value
            hsbDifficulty.Location = new Point(10, 10); // Set the location on the form
            hsbDifficulty.Size = new Size(200, 45); // Set the size of the control

            // Add the control to the form's Controls collection
            this.Controls.Add(hsbDifficulty);
        }

        // Method to initialize the board buttons based on the board size
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
                    btn.Click += CellButton_Click;

                    // Position the buttons on the form
                    btn.Location = new Point(col * 30, row * 30);
                    btnBoard[row, col] = btn;
                    this.Controls.Add(btn); // Add the button to the form
                }
            }
        }

        private void CellButton_MouseUp(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;
            int row = location.X;
            int col = location.Y;

            if (e.Button == MouseButtons.Right) // Check for right-click
            {
                // Toggle flag state
                boardModel.Cells[row, col].IsFlagged = !boardModel.Cells[row, col].IsFlagged;
                UpdateBoardGUI();
            }
            else if (e.Button == MouseButtons.Left) // Check for left-click
            {
                CellButton_Click(sender, e); // Call the cell click handler with row and col
                //Commit
                //Commit 
            }
        }

        // Cell button click handler
        private void CellButton_Click(object sender, EventArgs e)
        {

            Button clickedButton = (Button)sender;


            Point location = (Point)clickedButton.Tag;
            int row = location.X;
            int col = location.Y;




            // Mark the clicked cell as visited


            // Make the move in the game logic
            gameLogic.MakeMove(row, col);

            // Get the clicked cell from the game logic to check its status
            var clickedCell = boardModel.Cells[row, col];

            if (!clickedCell.IsVisited)
            {
                score += 200;
                lblScore.Text = $"Score: {score}";
            }



            // If the clicked cell has no bomb neighbors, trigger flood fill

            // Trigger flood fill to reveal all adjacent empty cells
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





        // Method to update the board UI based on the game state
        private void UpdateBoardGUI()
        {
            for (int row = 0; row < boardModel.Size; row++)
            {
                for (int col = 0; col < boardModel.Size; col++)
                {
                    var cell = boardModel.Cells[row, col];
                    Button cellButton = btnBoard[row, col];

                    // Set the button text based on the cell's state
                    if (cell.IsVisited)
                    {
                        if (cell.IsBomb)
                        {
                            cellButton.Text = "B"; // Indicate bomb
                        }
                        else if (cell.NumberOfBombNeighbors == 0)
                        {
                            cellButton.Text = ".";  // Empty for cells with no neighbors
                        }
                        else
                        {
                            cellButton.Text = cell.NumberOfBombNeighbors.ToString();
                        }

                        // Optionally, apply color styling for cells with bomb neighbors

                        cellButton.Enabled = false; // Disable the button once it's visited
                    }
                    else
                    {
                        cellButton.Text = ""; // Hide the button text if not visited
                        cellButton.Enabled = true; // Enable the button for clicking
                    }

                    // Apply different styles to bombs or safe cells

                }
            }
            Refresh(); // Refresh the UI after updates
        }






        // Method to check the current game status (Win or Lose)
        private void CheckGameStatus()
        {
            var gameStatus = boardModel.DetermineGameStatus();
            if (gameStatus == BoardModel.GameStatus.Won)
            {
                MessageBox.Show("Congratulations, You Won!");
                // Optionally, disable further game input here
            }
            else if (gameStatus == BoardModel.GameStatus.Lost)
            {
                MessageBox.Show("Game Over! You hit a bomb.");
                // Optionally, reveal all bombs and disable further game input
                tmrGameTime.Stop();
                ResetGame();
            }
        }

        // Optional: Reward usage or hint functionality
        private void BtnHint_Click(object sender, EventArgs e)
        {
            if (gameLogic.UseSpecialBonus("Hint"))
            {
                MessageBox.Show("Hint: Bomb location revealed.");
            }
            else
            {
                MessageBox.Show("No hints available.");
            }
        }

        // Optional: Reset game button (if needed)
        private void BtnResetGame_Click(object sender, EventArgs e)
        {
            BtnStartGameClickEH(sender, e); // Re-start the game

        }
        //Put floodfill into the GameLogic

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

        private void TmrGameTime_Tick(object sender, EventArgs e)
        {
            {
                secondsElapsed++;
                lblGameTime.Text = TimeSpan.FromSeconds(secondsElapsed).ToString();

                score -= 1;
                lblScore.Text = $"Score: {score}";

            }
        }
        private void ResetGame()
        {
            secondsElapsed = 0;
            lblGameTime.Text = "00:00:00";

            foreach (var button in btnBoard)
            {
                this.Controls.Remove(button); // Remove buttons from the form
            }
            score = 0;
            lblScore.Text = "Score: 0";
        }

        private void FrmStartLoadEH(object sender, EventArgs e)
        {
            //impliment
        }

        private void BtnStartGameClickEH(object sender, EventArgs e)
        {
            tmrGameTime.Tick += new EventHandler(TmrGameTime_Tick);
            score = 0;
            secondsElapsed = 0;
            tmrGameTime.Start();

            // Check if hsbSize is initialized
            if (hsbSize == null)
            {
                MessageBox.Show("hsbSize was not initialized");
                return; // Exit if not initialized
            }

            // Check if hsbDifficulty is initialized
            if (hsbDifficulty == null)
            {
                MessageBox.Show("hsbDifficulty was not initialized");
                return; // Exit if not initialized
            }

            // Get size and difficulty values from sliders
            int size = hsbSize.Value;
            int difficulty = hsbDifficulty.Value;

            // Initialize game logic with the selected size and difficulty
            gameLogic = new MinesweeperGameLogic(size, difficulty);
            boardModel = gameLogic.GetBoardModel();

            // Initialize the board buttons
            InitializeBoardButtons(size);
            Console.WriteLine("Start");
            // Start the game
            UpdateBoardGUI();
        }

        private void BtnChooseDifficultyClickEH(object sender, EventArgs e)
        {

        }
    }
}