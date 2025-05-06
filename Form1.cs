using System.Data.SqlTypes;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Minesweeper
{
    public partial class mainForm : Form
    { 
        private int[,] hasMine; // Array to indicate if a button has a mine  
        private int rows = 8; // Number of rows
        private int cols = 8; // Number of columns
        private int clearCells; // Number of cells cleared
        private int checkedCells = 0; // Number of cells checked

        public mainForm()
        {
            InitializeComponent();
            
        }

        private void InitializeGameBoard()
        {
            hasMine = new int[rows, cols];
            this.MaximumSize = new Size(cols * 30 + 100, rows * 30 + 150); // Adjust the maximum size of the form
            this.MinimumSize = new Size(cols * 30 + 100, rows * 30 + 150); // Adjust the minimum size of the form

            // Create a panel to hold the buttons
            Panel gamePanel = new Panel();
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(cols * 30, rows * 30 + 40); // Adjusted to include space for the restart button
            gamePanel.Location = new Point(50, 50);
            this.Controls.Add(gamePanel);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button button = new Button();
                    button.Name = $"button_{i}_{j}";
                    button.Size = new Size(30, 30);
                    button.Location = new Point(j * 30, i * 30); // Adjusted for panel
                    button.Click += Button_Click;
                    gamePanel.Controls.Add(button);
                    button.BackColor = Color.White;

                    hasMine[i, j] = 0; // Initialize all to 0  
                }
            }

            // Restart button
            Button restartButton = new Button();
            restartButton.Text = "Restart";
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(80, 30);
            restartButton.Location = new Point((cols * 30 - 80) / 2, rows * 30 + 5); // Centered below the grid
            restartButton.Click += RestartButton_Click;
            gamePanel.Controls.Add(restartButton); // Add restart button to the panel

            mineInitialization();
        }
        private void RestartButton_Click(object sender, EventArgs e)
        {

            startPnl.Visible = true;
            clearCells = 0;
            checkedCells = 0;
            infoLable.Text = "Please enter the number of rows and columns.";
            this.MaximumSize = new Size(435, 432);
            this.MinimumSize = new Size(435, 432);
            Panel gamePanel = this.Controls.Find("gamePanel", true).FirstOrDefault() as Panel;
            if (gamePanel != null)
            {
                this.Controls.Remove(gamePanel);
            }

        }

        private void mineClicked()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (hasMine[i, j] == 1)
                    {
                        Button button = this.Controls.Find($"button_{i}_{j}", true).FirstOrDefault() as Button;
                        if (button != null)
                        {
                            button.BackgroundImage = Properties.Resources.mine;
                            button.BackColor = Color.Red;
                            button.Text = "*";
                        }
                    }
                }
            }
            loseGame();
        }
        private void loseGame()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button button = this.Controls.Find($"button_{i}_{j}", true).FirstOrDefault() as Button;
                    if (button != null)
                    {
                        button.Enabled = false;
                    }
                }
            }
            MessageBox.Show("You lost! Game Over.");
        }

        private void winGame()
        {
            if (checkedCells == clearCells)
            {
                MessageBox.Show("You won! Congratulations!");
            }
        }

        private int fieldScaner(int row, int column) {
            int mineCount = 0;
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = column - 1; j <= column + 1; j++)
                {
                    if (i >= 0 && i < rows && j >= 0 && j < cols)
                    {
                        if (hasMine[i, j] == 1)
                        {
                            mineCount++;
                        }
                    }
                }
            }
            return mineCount;
        }
        private void clickNearbyCells(int row, int column)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = column - 1; j <= column + 1; j++)
                {
                    if (i >= 0 && i < rows && j >= 0 && j < cols)
                    {
                        Button button = this.Controls.Find($"button_{i}_{j}", true).FirstOrDefault() as Button;
                        if (button != null && button.Enabled)
                        {
                            button.PerformClick();
                        }
                    }
                }
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {   
                clickedButton.BackgroundImage = null; // Clear any existing background image
                if (Control.ModifierKeys == Keys.Control) 
                {
                    if (clickedButton.BackgroundImage == null)
                    {
                        clickedButton.BackgroundImage = Properties.Resources.flag; // Set flag image
                        clickedButton.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        clickedButton.BackgroundImage = null; // Remove flag image
                    }
                    return;
                }

                clickedButton.Enabled = false;
                checkedCells++;

                string[] indices = clickedButton.Name.Split('_');
                int row = int.Parse(indices[1]);
                int col = int.Parse(indices[2]);
                if (hasMine[row, col] == 1)
                {
                    mineClicked();
                }
                else
                {
                    int nearbyMines = fieldScaner(row, col);
                    if (nearbyMines == 0)
                    {
                        clickedButton.BackColor = Color.LightGray;
                        clickNearbyCells(row, col);
                    }
                    else if (nearbyMines < 3)
                    {
                        clickedButton.BackColor = Color.Green;
                        clickedButton.Text = nearbyMines.ToString();
                        winGame();
                    }
                    else if (nearbyMines < 5)
                    {
                        clickedButton.BackColor = Color.Yellow;
                        clickedButton.Text = nearbyMines.ToString();
                        winGame();
                    }
                    else if (nearbyMines < 9)
                    {
                        clickedButton.BackColor = Color.Red;
                        clickedButton.Text = nearbyMines.ToString();
                        winGame();
                    }
                }
                
            }
        }

        private void mineInitialization()
        {
            Random random = new Random();
            int totalCells = rows * cols;
            int minesToPlace = totalCells / 5; // 20% of the cells

            while (minesToPlace > 0)
            {
                int randomRow = random.Next(rows);
                int randomCol = random.Next(cols);

                if (hasMine[randomRow, randomCol] == 0) // Place mine only if cell is empty
                {
                    hasMine[randomRow, randomCol] = 1;
                    minesToPlace--;
                }
            }
            clearCells = totalCells - minesToPlace-1; // Update the number of clear cells
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            

            if (!int.TryParse(xTxtF.Text, out cols) || !int.TryParse(yTxtF.Text, out rows))
            {
                infoLable.Text = "Please enter valid numbers only.";
                return;
            }
            else if (cols < 1 || rows < 1)
            {
                infoLable.Text = "Please enter numbers greater than 0.";
                return;
            }else if (cols > 31 || rows > 31)
            {
                infoLable.Text = "Please enter numbers less than or equal to 31.";
                return;
            }
            else if (cols == 1 && rows == 1)
            {
                infoLable.Text = "Please enter numbers greater than 1.";
                return;
            }
            else if (cols == 1 || rows == 1)
            {
                infoLable.Text = "Please enter numbers greater than 1 for both dimensions.";
                return;
            }
            else
            {
                startPnl.Visible = false;
                infoLable.Text = "Wellcome";
                InitializeGameBoard();
            }

           
        }
    }
}
