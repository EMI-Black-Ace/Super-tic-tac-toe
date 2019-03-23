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
        private readonly TicTacToeCell[][] grid;
        public TicTacToeGridStatus GridWinner { get; private set; } = TicTacToeGridStatus.Contested;

        public class TicTacToeGridEventArgs : EventArgs
        {
            public TicTacToeGridStatus Winner { get; private set; }

            public TicTacToeGridEventArgs(TicTacToeGridStatus vWinner)
            {
                Winner = vWinner;
            }
        }
        public delegate void GridWinHandler(object sender, TicTacToeGridEventArgs e);
        public event GridWinHandler GridWon;

        private void OnGridWin()
        {
            GridWon?.Invoke(this, new TicTacToeGridEventArgs(GridWinner));
        }
        
        public TicTacToeGrid()
        {
            grid = new TicTacToeCell[][]{
                                            new TicTacToeCell[]{ new TicTacToeCell(), new TicTacToeCell(), new TicTacToeCell() },
                                            new TicTacToeCell[]{ new TicTacToeCell(), new TicTacToeCell(), new TicTacToeCell() },
                                            new TicTacToeCell[]{ new TicTacToeCell(), new TicTacToeCell(), new TicTacToeCell() }
                                         };
        }

        public void ClaimCell(int X, int Y, TicTacToeCellStatus player)
        {
            if (GridWinner != TicTacToeGridStatus.Contested)
                throw new TicTacToeException("Grid is already filled in");

            if (X < 0 || X > 2 || Y < 0 || Y > 2)
                throw new ArgumentException("column or row selection invalid: " + X + ", " + Y);

            grid[X][Y].ClaimCell(player);
            CheckWinner(X, Y, player);
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
            if(grid[0][row].Status == grid[1][row].Status &&
                grid[1][row].Status == grid[2][row].Status)
            {
                DeclareWinner(player);
                return;
            }

            //check for vertical winner
            if (grid[column][0].Status == grid[column][1].Status &&
                grid[column][1].Status == grid[column][2].Status)
            {
                DeclareWinner(player);
                return;
            }

            //check for diagonal winner
            if((grid[0][0].Status == grid[1][1].Status && grid[1][1].Status == grid[2][2].Status && grid[1][1].Status != TicTacToeCellStatus.Unclaimed) ||
                (grid[0][2].Status == grid[1][1].Status && grid[1][1].Status == grid[2][0].Status && grid[1][1].Status != TicTacToeCellStatus.Unclaimed))
            {
                DeclareWinner(player);
                return;
            }

            for(int i = 0; i < 3; ++i)
            {
                for(int j = 0; j < 3; ++j)
                {
                    if (grid[i][j].Status == TicTacToeCellStatus.Unclaimed)
                    {
                        return;
                    }
                }
            }
            DeclareWinner(TicTacToeCellStatus.Unclaimed);
        }

        public void Reset()
        {
            foreach(TicTacToeCell[] row in grid)
            {
                foreach(TicTacToeCell cell in row)
                {
                    cell.Reset();
                }
            }
            GridWinner = TicTacToeGridStatus.Contested;
        }

        private void DeclareWinner(TicTacToeCellStatus player)
        {
            if (player == TicTacToeCellStatus.X)
                GridWinner = TicTacToeGridStatus.X;
            else if (player == TicTacToeCellStatus.O)
                GridWinner = TicTacToeGridStatus.O;
            else
                GridWinner = TicTacToeGridStatus.Stalemate;
            OnGridWin();
            return;
        }
    }
}
