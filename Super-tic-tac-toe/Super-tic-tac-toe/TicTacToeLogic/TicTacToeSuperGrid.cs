using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_tic_tac_toe
{
    public enum PlayerTurn
    {
        X, O
    }

    class TicTacToeSuperGrid
    {
        public PlayerTurn WhoseTurn { get; private set; } = PlayerTurn.X;

        private TicTacToeGrid[][] subGrids;

        /// <summary>
        /// The X coordinate of the subgrid the player is forced to play in.
        /// -1 indicates the player can select any subgrid.
        /// </summary>
        public int NextMoveX { get; private set; } = -1;
        /// <summary>
        /// The X coordinate of the subgrid the player is forced to play in.
        /// -1 indicates the player can select any subgrid.
        /// </summary>
        public int NextMoveY { get; private set; } = -1;

        public class TicTacToeGridEventArgs : EventArgs
        {
            public TicTacToeGridStatus Winner { get; private set; }
            public int SubGridX { get; private set; }
            public int SubGridY { get; private set; }

            public TicTacToeGridEventArgs(int X, int Y, TicTacToeGridStatus vWinner)
            {
                SubGridX = X;
                SubGridY = Y;
                Winner = vWinner;
            }
        }
        public delegate void GridWinHandler(object sender, TicTacToeGridEventArgs e);
        public event GridWinHandler GridWon;

        private void OnGridWin(int X, int Y, TicTacToeGridStatus Winner)
        {
            GridWon?.Invoke(this, new TicTacToeGridEventArgs(X, Y, Winner));
        }

        public TicTacToeSuperGrid()
        {
            subGrids = new TicTacToeGrid[][]{
                                            new TicTacToeGrid[]{ new TicTacToeGrid(), new TicTacToeGrid(), new TicTacToeGrid() },
                                            new TicTacToeGrid[]{ new TicTacToeGrid(), new TicTacToeGrid(), new TicTacToeGrid() },
                                            new TicTacToeGrid[]{ new TicTacToeGrid(), new TicTacToeGrid(), new TicTacToeGrid() }
                                         };
        }

        public void ClaimCell(int gridX, int gridY, int X, int Y)
        {
            TicTacToeCellStatus player = WhoseTurn == PlayerTurn.X ? TicTacToeCellStatus.X : TicTacToeCellStatus.O;
            if(NextMoveX == -1 || (gridX == NextMoveX && gridY == NextMoveY))
            {
                subGrids[gridX][gridY].ClaimCell(X, Y, player);
                if(subGrids[X][Y].GridWinner == TicTacToeGridStatus.Contested)
                {
                    NextMoveX = X;
                    NextMoveY = Y;
                }
                else
                {
                    NextMoveX = -1;
                    NextMoveY = -1;
                }
            }
            else
            {
                throw new TicTacToeException("player must make a move in subgrid " + NextMoveX.ToString() + ", " + NextMoveY.ToString() + "!");
            }
        }
    }
}
