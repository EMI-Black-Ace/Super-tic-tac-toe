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

        public TicTacToeSuperGrid()
        {
            subGrids = new TicTacToeGrid[][]{
                                            new TicTacToeGrid[]{ new TicTacToeGrid(), new TicTacToeGrid(), new TicTacToeGrid() },
                                            new TicTacToeGrid[]{ new TicTacToeGrid(), new TicTacToeGrid(), new TicTacToeGrid() },
                                            new TicTacToeGrid[]{ new TicTacToeGrid(), new TicTacToeGrid(), new TicTacToeGrid() }
                                         };
            foreach(TicTacToeGrid[] gLines in subGrids)
            {
                foreach(TicTacToeGrid grid in gLines)
                {
                    grid.GridWon += SubGridWon;
                }
            }
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

        private void SubGridWon(object sender, TicTacToeGrid.TicTacToeGridEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
