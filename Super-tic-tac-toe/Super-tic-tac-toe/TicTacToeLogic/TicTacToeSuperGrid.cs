using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_tic_tac_toe
{
    public enum TicTacToePlayerTurn
    {
        X, O
    }
    public enum TicTacToeWinner { X, O, Stalemate, Contested }

    public class TicTacToeSuperGrid : ITicTacToeSuperGrid
    {
        public TicTacToePlayerTurn WhoseTurn { get; private set; } = TicTacToePlayerTurn.X;
        public TicTacToeWinner Winner { get; private set; } = TicTacToeWinner.Contested;

        private readonly TicTacToeGrid[,] subGrids;

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

        #region Subgrid win event handling
        
        /// <summary>
        /// Event raised when a subgrid is won
        /// </summary>
        public event SubGridWinHandler GridWon;
        private void OnSubgridGridWin(int X, int Y, TicTacToeGridStatus Winner)
        {
            GridWon?.Invoke(this, new TicTacToeSubgridWinEventArgs(X, Y, Winner));
        }
        #endregion

        #region Supergrid win event handling
        /// <summary>
        /// The event raised when the game is won
        /// </summary>
        public event OverallWinHandler GameWon;
        private void DeclareStalemate()
        {
            Winner = TicTacToeWinner.Stalemate;
            GameWon?.Invoke(this, new TicTacToeWinEventArgs(TicTacToeWinner.Stalemate));
        }

        private void DeclareWinner(TicTacToePlayerTurn whoWon)
        {
            Winner = whoWon == TicTacToePlayerTurn.X ? TicTacToeWinner.X : TicTacToeWinner.O;
            GameWon?.Invoke(this, new TicTacToeWinEventArgs(Winner));
        }
        #endregion

        #region Turn event handling
        
        public event MoveHandler MoveMade;

        private void OnMove(int gridX, int gridY, int X, int Y)
        {
            MoveMade?.Invoke(this, new TicTacToeTurnEventArgs(WhoseTurn, NextMoveX, NextMoveY, gridX, gridY, X, Y));
        }
        #endregion

        public TicTacToeSuperGrid()
        {
            subGrids = new TicTacToeGrid[,]{
                                                { new TicTacToeGrid(), new TicTacToeGrid(), new TicTacToeGrid() },
                                                { new TicTacToeGrid(), new TicTacToeGrid(), new TicTacToeGrid() },
                                                { new TicTacToeGrid(), new TicTacToeGrid(), new TicTacToeGrid() }
                                         };
        }

        public TicTacToeGridStatus CheckGridStatus(int gridX, int gridY)
        {
            return subGrids[gridX,gridY].GridWinner;
        }

        public TicTacToeCellStatus CheckCellStatus(int gridX, int gridY, int X, int Y)
        {
            return subGrids[gridX,gridY].CellStatus(X, Y);
        }

        public void ClaimCell(int gridX, int gridY, int X, int Y)
        {
            if(Winner != TicTacToeWinner.Contested)
            {
                throw new TicTacToeException("Cannot claim cell after a winner has been declared");
            }

            if(gridX < 0 || gridX > 2 || gridY < 0 || gridY > 2)
                throw new ArgumentException("column or row selection invalid: " + gridX + ", " + gridY);

            TicTacToeCellStatus player = WhoseTurn == TicTacToePlayerTurn.X ? TicTacToeCellStatus.X : TicTacToeCellStatus.O;
            if(NextMoveX == -1 || (gridX == NextMoveX && gridY == NextMoveY))
            {
                subGrids[gridX,gridY].ClaimCell(X, Y, player);

                //check for subgrid win, raise event and check for win conditions
                if(subGrids[gridX,gridY].GridWinner != TicTacToeGridStatus.Contested)
                {
                    OnSubgridGridWin(gridX, gridY, subGrids[gridX,gridY].GridWinner);
                    CheckWinConditions(gridX, gridY);
                }

                //set the subgrid for the next move
                if(subGrids[X,Y].GridWinner == TicTacToeGridStatus.Contested)
                {
                    NextMoveX = X;
                    NextMoveY = Y;
                }
                else
                {
                    NextMoveX = -1;
                    NextMoveY = -1;
                }

                OnMove(gridX, gridY, X, Y);
                WhoseTurn = WhoseTurn == TicTacToePlayerTurn.X ? TicTacToePlayerTurn.O : TicTacToePlayerTurn.X;
            }
            else
            {
                throw new TicTacToeException("player must make a move in subgrid " + NextMoveX.ToString() + ", " + NextMoveY.ToString() + "!");
            }
        }

        public void Reset()
        {
            foreach(TicTacToeGrid grid in subGrids)
            {
                grid.Reset();
            }
            Winner = TicTacToeWinner.Contested;
            NextMoveX = -1;
            NextMoveY = -1;
            WhoseTurn = TicTacToePlayerTurn.X;
        }

        private bool CheckWinConditions(int gridX, int gridY)
        {
            //check for horizontal winner
            if (subGrids[gridX,0].GridWinner == subGrids[gridX,1].GridWinner &&
                subGrids[gridX,1].GridWinner == subGrids[gridX,2].GridWinner &&
                subGrids[gridX,gridY].GridWinner != TicTacToeGridStatus.Stalemate)
            {
                DeclareWinner(WhoseTurn);
                return true;
            }

            //check for vertical winner
            if (subGrids[0,gridY].GridWinner == subGrids[1,gridY].GridWinner &&
                subGrids[1,gridY].GridWinner == subGrids[2,gridY].GridWinner &&
                subGrids[gridX,gridY].GridWinner != TicTacToeGridStatus.Stalemate)
            {
                DeclareWinner(WhoseTurn);
                return true;
            }

            //check for diagonal winner
            if ((subGrids[0,0].GridWinner == subGrids[1,1].GridWinner && subGrids[1,1].GridWinner == subGrids[2,2].GridWinner && 
                (subGrids[1,1].GridWinner != TicTacToeGridStatus.Stalemate && subGrids[1,1].GridWinner != TicTacToeGridStatus.Contested)) ||
                (subGrids[0,2].GridWinner == subGrids[1,1].GridWinner && subGrids[1,1].GridWinner == subGrids[2,0].GridWinner && 
                (subGrids[1,1].GridWinner != TicTacToeGridStatus.Stalemate && subGrids[1,1].GridWinner != TicTacToeGridStatus.Contested)))
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
                    if (subGrids[i,j].GridWinner == TicTacToeGridStatus.Contested)
                        return false;
                    else
                    {
                        if (subGrids[i,j].GridWinner == TicTacToeGridStatus.X)
                            ++Xclaims;
                        else if (subGrids[i,j].GridWinner == TicTacToeGridStatus.O)
                            ++Oclaims;
                    }
                }
            }
            if (Xclaims > Oclaims)
            {
                DeclareWinner(TicTacToePlayerTurn.X);
                return true;
            }
            else if (Oclaims > Xclaims)
            {
                DeclareWinner(TicTacToePlayerTurn.O);
                return true;
            }
            else
                DeclareStalemate();
            return false;
        }
    }
}
