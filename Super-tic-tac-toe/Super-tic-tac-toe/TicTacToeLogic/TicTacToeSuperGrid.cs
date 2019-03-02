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

        public class TicTacToeSuperGridEventArgs : EventArgs
        {
            public TicTacToeGridStatus Winner { get; private set; }
            public int SubGridX { get; private set; }
            public int SubGridY { get; private set; }

            public TicTacToeSuperGridEventArgs(int X, int Y, TicTacToeGridStatus vWinner)
            {
                SubGridX = X;
                SubGridY = Y;
                Winner = vWinner;
            }
        }
        public delegate void SubGridWinHandler(object sender, TicTacToeSuperGridEventArgs e);
        public event SubGridWinHandler GridWon;

        private void OnSubgridGridWin(int X, int Y, TicTacToeGridStatus Winner)
        {
            GridWon?.Invoke(this, new TicTacToeSuperGridEventArgs(X, Y, Winner));
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

                //check for subgrid win, raise event and check for win conditions
                if(subGrids[gridX][gridY].GridWinner != TicTacToeGridStatus.Contested)
                {
                    OnSubgridGridWin(gridX, gridY, subGrids[gridX][gridY].GridWinner);
                    CheckWinConditions(gridX, gridY);
                }

                //set the subgrid for the next move
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
                WhoseTurn = WhoseTurn == PlayerTurn.X ? PlayerTurn.O : PlayerTurn.X;
            }
            else
            {
                throw new TicTacToeException("player must make a move in subgrid " + NextMoveX.ToString() + ", " + NextMoveY.ToString() + "!");
            }
        }

        private bool CheckWinConditions(int gridX, int gridY)
        {
            //check for horizontal winner
            if (subGrids[gridX][0].GridWinner == subGrids[gridX][1].GridWinner &&
                subGrids[gridX][1].GridWinner == subGrids[gridX][2].GridWinner &&
                subGrids[gridX][gridY].GridWinner != TicTacToeGridStatus.Stalemate)
            {
                DeclareWinner(WhoseTurn);
                return true;
            }

            //check for vertical winner
            if (subGrids[0][gridY].GridWinner == subGrids[1][gridY].GridWinner &&
                subGrids[1][gridY].GridWinner == subGrids[2][gridY].GridWinner &&
                subGrids[gridX][gridY].GridWinner != TicTacToeGridStatus.Stalemate)
            {
                DeclareWinner(WhoseTurn);
                return true;
            }

            //check for diagonal winner
            if ((subGrids[0][0].GridWinner == subGrids[1][1].GridWinner && subGrids[1][1].GridWinner == subGrids[2][2].GridWinner) ||
                (subGrids[0][2].GridWinner == subGrids[1][1].GridWinner && subGrids[1][1].GridWinner == subGrids[2][0].GridWinner) &&
                subGrids[1][1].GridWinner != TicTacToeGridStatus.Stalemate)
            {
                DeclareWinner(WhoseTurn);
                return true;
            }

            int Xclaims = 0;
            int Oclaims = 0;
            //TODO: when there's no clear ttc victory, declare by who won the most subgrids
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (subGrids[i][j].GridWinner == TicTacToeGridStatus.Contested)
                        return false;
                    else
                    {
                        if (subGrids[i][j].GridWinner == TicTacToeGridStatus.X)
                            ++Xclaims;
                        else if (subGrids[i][j].GridWinner == TicTacToeGridStatus.O)
                            ++Oclaims;
                    }
                }
            }
            if (Xclaims > Oclaims)
            {
                DeclareWinner(PlayerTurn.X);
                return true;
            }
            else if (Oclaims > Xclaims)
            {
                DeclareWinner(PlayerTurn.O);
                return true;
            }
            else
                DeclareStalemate();
            return false;
        }

        private void DeclareStalemate()
        {
            throw new NotImplementedException();
        }

        private void DeclareWinner(PlayerTurn whoseTurn)
        {
            throw new NotImplementedException();
        }
    }
}
