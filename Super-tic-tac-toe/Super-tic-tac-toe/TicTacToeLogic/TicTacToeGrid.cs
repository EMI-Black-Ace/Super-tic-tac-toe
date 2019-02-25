using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_tic_tac_toe
{
    public enum TicTacToeGridStatus
    {
        Contested,
        Stalemate,
        X,
        O
    }

    public class TicTacToeGrid
    {
        private TicTacToeCell[][] grid;
        private TicTacToeGridStatus gridWinner = TicTacToeGridStatus.Contested;
        public TicTacToeGridStatus GridWinner { get { return gridWinner; } }

        public class TicTacToeGridEventArgs : EventArgs
        {
            private TicTacToeGridStatus winner;
            public TicTacToeGridStatus Winner { get { return winner; } }

            public TicTacToeGridEventArgs(TicTacToeGridStatus vWinner)
            {
                winner = vWinner;
            }
        }
        public delegate void GridWinHandler(object sender, TicTacToeGridEventArgs e);
        public event GridWinHandler GridWon;

        private void OnGridWin()
        {
            GridWon?.Invoke(this, new TicTacToeGridEventArgs(gridWinner));
        }
        
        public TicTacToeGrid()
        {
            grid = new TicTacToeCell[][]{
                                            new TicTacToeCell[]{ new TicTacToeCell(), new TicTacToeCell(), new TicTacToeCell() },
                                            new TicTacToeCell[]{ new TicTacToeCell(), new TicTacToeCell(), new TicTacToeCell() },
                                            new TicTacToeCell[]{ new TicTacToeCell(), new TicTacToeCell(), new TicTacToeCell() }
                                         };
        }

        public void ClaimCell(int column, int row, TicTacToeCellStatus player)
        {
            if (gridWinner != TicTacToeGridStatus.Contested)
                throw new TicTacToeException("Grid is already filled in");

            if (column < 0 || column > 2 || row < 0 || row > 2)
                throw new ArgumentException("column or row selection invalid: " + column + ", " + row);

            grid[column][row].ClaimCell(player);
            CheckWinner(column, row);
        }

        public TicTacToeCellStatus CellStatus(int column, int row)
        {
            if (column < 0 || column > 2 || row < 0 || row > 2)
                throw new ArgumentException("column or row selection invalid: " + column + ", " + row);

            return grid[column][row].Status;
        }

        private void CheckWinner(int column, int row, TicTacToeCellStatus player)
        {
            //check for horizontal winner
            if(grid[0][row] == grid[1][row] &&
                grid[1][row] == grid[2][row])
            {
                DeclareWinner(player);
            }

            //check for vertical winner
            if (grid[column][0] == grid[column][1] &&
                grid[column][1] == grid[column][2])
            {
                DeclareWinner(player);
            }

            //check for diagonal winner
            if((grid[0][0] == grid[1][1] && grid[1][1] == grid[2][2]) ||
                (grid[0][2] == grid[1][1] && grid[1][1] == grid[2][0]))
            {
                DeclareWinner(player);
            }

            //TODO:  Check for stalemate condition
            stalemate;
        }

        private void DeclareWinner(TicTacToeCellStatus player)
        {
            if (player == TicTacToeCellStatus.X)
                gridWinner = TicTacToeGridStatus.X;
            else
                gridWinner = TicTacToeGridStatus.O;
            OnGridWin();
            return;
        }
    }
}
