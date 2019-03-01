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
        private PlayerTurn whoseTurn = PlayerTurn.X;
        public PlayerTurn WhoseTurn => WhoseTurn;

        private TicTacToeGrid[][] subGrids;

        private int nextMoveX = -1;
        public int NextMoveX => nextMoveX;
        private int nextMoveY = -1;
        public int NextMoveY => nextMoveY;

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
            if(NextMoveX == -1)
            {
                subGrids[gridX][gridY].ClaimCell(X, Y, player);
            }
            incomplete;
        }

        private void SubGridWon(object sender, TicTacToeGrid.TicTacToeGridEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
