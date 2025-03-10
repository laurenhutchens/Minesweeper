/*Arie Gerard and Lauren Hutches 
 * Cst-250
 * Minesweeper 
 * Bill Hughes
 *03/10/2025
 */

using MineSweeperClasses;
using MineSweeperClasses.Models;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
                    btn.MouseUp += CellButton_MouseUp;

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
                boardModel.Cells[row, col].IsFlagged = boardModel.Cells[row, col].IsFlagged;
                if (boardModel.Cells[row, col].IsFlagged)
                {
                    clickedButton.BackgroundImage = Image.FromFile("C:\\Users\\majes\\Source\\Repos\\MinesweeperFinal\\MineSweeperClasses\\Images\\Gold.png");
                    clickedButton.BackgroundImageLayout = ImageLayout.Stretch;
                    UpdateBoardGUI();
                }
                else
                {
                    return;
                    
                }
                
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
                    lblScore.Text = $"Score: {score}";
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

            // Method to update the board UI based on the game state
            private void UpdateBoardGUI()
        {
            //loop throuhg and update the board values and display pictures
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
                            cellButton.BackgroundImage = Image.FromFile("C:\\Users\\majes\\Source\\Repos\\MinesweeperFinal\\MineSweeperClasses\\Images\\Skull.png");
                            cellButton.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else if (cell.NumberOfBombNeighbors == 0)
                        {
                            cellButton.Text = ".";  // Empty for cells with no neighbors
                            cellButton.BackgroundImage = Image.FromFile("C:\\Users\\majes\\Source\\Repos\\MinesweeperFinal\\MineSweeperClasses\\Images\\Tile Flat.png");
                            cellButton.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        //for any number of bomb neighbors it displays a picture
                        else
                        {
                            cellButton.Text = cell.NumberOfBombNeighbors.ToString();
                            if (cell.NumberOfBombNeighbors == 1)
                            {
                                cellButton.BackgroundImage = Image.FromFile("C:\\Users\\majes\\Source\\Repos\\MinesweeperFinal\\MineSweeperClasses\\Images\\Number 1.png");
                            }
                            if (cell.NumberOfBombNeighbors == 2)
                            {
                                cellButton.BackgroundImage = Image.FromFile("C:\\Users\\majes\\Source\\Repos\\MinesweeperFinal\\MineSweeperClasses\\Images\\Number 2.png");
                            }
                            if (cell.NumberOfBombNeighbors == 3)
                            {
                                cellButton.BackgroundImage = Image.FromFile("C:\\Users\\majes\\Source\\Repos\\MinesweeperFinal\\MineSweeperClasses\\Images\\Number 3.png");
                            }
                            if (cell.NumberOfBombNeighbors == 4)
                            {
                                cellButton.BackgroundImage = Image.FromFile("C:\\Users\\majes\\Source\\Repos\\MinesweeperFinal\\MineSweeperClasses\\Images\\Number 4.png");
                            }
                            if (cell.NumberOfBombNeighbors == 5)
                            {
                                cellButton.BackgroundImage = Image.FromFile("C:\\Users\\majes\\Source\\Repos\\MinesweeperFinal\\MineSweeperClasses\\Images\\Number 5.png");
                            }
                            if (cell.NumberOfBombNeighbors == 6)
                            {
                                cellButton.BackgroundImage = Image.FromFile("C:\\Users\\majes\\Source\\Repos\\MinesweeperFinal\\MineSweeperClasses\\Images\\Number 6.png");
                            }
                            if (cell.NumberOfBombNeighbors == 7)
                            {
                                cellButton.BackgroundImage = Image.FromFile("C:\\Users\\majes\\Source\\Repos\\MinesweeperFinal\\MineSweeperClasses\\Images\\Number 7.png");
                            }
                            if (cell.NumberOfBombNeighbors == 8)
                            {
                                cellButton.BackgroundImage = Image.FromFile("C:\\Users\\majes\\Source\\Repos\\MinesweeperFinal\\MineSweeperClasses\\Images\\Number 8.png");
                            }
                        }

                       

                        cellButton.Enabled = false; 
                    }
                   
                    else
                    {
                        cellButton.Text = ""; // Hide the button text if not visited
                        cellButton.Enabled = true; // Enable the button for clicking
                        cellButton.BackgroundImage = Image.FromFile("C:\\Users\\majes\\Source\\Repos\\MinesweeperFinal\\MineSweeperClasses\\Images\\Tile Flat.png");
                        cellButton.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    

                    // Apply different styles to bombs or safe cells

                }
            }
            Refresh(); //refresh after updates
            
                
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

        //Button hint click.
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

        /// <summary>
        /// Reset game event. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResetGame_Click(object sender, EventArgs e)
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
            tmrGameTime.Stop();

            foreach (var button in btnBoard)
            {
                this.Controls.Remove(button); // Remove buttons from the form
            }
            score = 0;
            lblScore.Text = "Score: 0";
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
            
            // Convert values properly
            int size = Convert.ToInt32(SizeText);
            int difficulty = Convert.ToInt32(DifficultyText);

            gameLogic = new MinesweeperGameLogic(size, difficulty);
            boardModel = gameLogic.GetBoardModel();

            InitializeBoardButtons(size);
            UpdateBoardGUI();
        }

        //SHows the secondary form with the trackbars to select the size and difficully
        private void BtnChooseDifficultyClickEH(object sender, EventArgs e)
        {
            FrmPlay frmPlay = new FrmPlay();



            frmPlay.Show();


            frmPlay.FormClosed += (s, args) => this.Show();
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {

        }

    }
}