using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_tic_tac_toe
{
    /// <summary>
    /// Event arguments indicating a subgrid winner and the won subgrid
    /// </summary>
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

    /// <summary>
    /// Event arguments indicating whose turn is next and which subgrid they must play in, as well as the position of the last move made
    /// </summary>
    public class TicTacToeTurnEventArgs : EventArgs
    {
        public TicTacToePlayerTurn WhoseTurn { get; private set; }
        public int NextMoveX { get; private set; }
        public int NextMoveY { get; private set; }
        public int MoveXGrid { get; private set; }
        public int MoveYGrid { get; private set; }
        public int MoveX { get; private set; }
        public int MoveY { get; private set; }
        public TicTacToeTurnEventArgs(TicTacToePlayerTurn whoseTurn, int nextMoveX, int nextMoveY, int moveXGrid, int moveYGrid, int moveX, int moveY)
        {
            WhoseTurn = whoseTurn;
            NextMoveX = nextMoveX;
            NextMoveY = nextMoveY;
            MoveXGrid = moveXGrid;
            MoveYGrid = moveYGrid;
            MoveX = moveX;
            MoveY = moveY;
        }
    }
    public delegate void MoveHandler(object sender, TicTacToeTurnEventArgs e);

    /// <summary>
    /// EventArgs indicating the game winner
    /// </summary>
    public class TicTacToeWinEventArgs : EventArgs
    {
        public TicTacToeWinner Winner { get; private set; }
        public TicTacToeWinEventArgs(TicTacToeWinner vWinner) => Winner = vWinner;
    }
    public delegate void OverallWinHandler(object sender, TicTacToeWinEventArgs e);

    /// <summary>
    /// Event arguments indicating a subgrid winner and the won subgrid
    /// </summary>
    public class TicTacToeSubgridWinEventArgs : EventArgs
    {
        public TicTacToeGridStatus Winner { get; private set; }
        public int SubGridX { get; private set; }
        public int SubGridY { get; private set; }

        public TicTacToeSubgridWinEventArgs(int X, int Y, TicTacToeGridStatus vWinner)
        {
            SubGridX = X;
            SubGridY = Y;
            Winner = vWinner;
        }
    }
    public delegate void SubGridWinHandler(object sender, TicTacToeSubgridWinEventArgs e);
}
