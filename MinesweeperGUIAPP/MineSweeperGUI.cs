using MineSweeper.BusinessLogicLayer;
using MineSweeperClasses;
using MineSweeperClasses.Models;
namespace MinesweeperGUIAPP
{
    public partial class MineSweeperGUI : Form
    {
        private MinesweeperGameLogic gameLogic;
        private BoardModel boardModel;
        private Button[,] btnBoard;
        public MineSweeperGUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            // Get size and difficulty values from sliders
            int size = hsbSize.Value; // Assuming hsbSize is a HorizontalScrollBar for board size (e.g., 5 - 20)
            int difficulty = hsbDifficulty.Value; // Assuming hsbDifficulty is for difficulty level (1-3)

            // Initialize game logic with the selected size and difficulty
            gameLogic = new MinesweeperGameLogic(size, difficulty);
            boardModel = gameLogic.GetBoardModel();

            // Initialize the board buttons
            InitializeBoardButtons(size);

            // Start the game
            UpdateBoardGUI();
        }

        // Method to initialize the board buttons based on the board size
        private void InitializeBoardButtons(int size)
        {
            btnBoard = new Button[size, size];

            // Remove any existing buttons from the form (if any)
            this.Controls.Clear();
            this.Controls.Add(btnStartGame); // Add the Start Button back to the form

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

        // Cell button click handler
        private void CellButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;
            int row = location.X;
            int col = location.Y;

            // Make the move in the game logic
            gameLogic.MakeMove(row, col);

            // Update the board UI to reflect the current state
            UpdateBoardGUI();

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
                        cellButton.Text = cell.DisplayChar.ToString();
                        cellButton.Enabled = false; // Disable the button once it's visited
                    }
                    else
                    {
                        cellButton.Text = ""; // Hide the button text if not visited
                        cellButton.Enabled = true; // Enable the button for clicking
                    }

                    // Optionally, apply different styles to bombs or safe cells
                    if (cell.IsBomb)
                    {
                        cellButton.BackColor = Color.Red; // For bombs
                    }
                    else
                    {
                        cellButton.BackColor = Color.LightGray; // For safe cells
                    }
                }
            }
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
            BtnStartGame_Click(sender, e); // Re-start the game
        }
    }
}
