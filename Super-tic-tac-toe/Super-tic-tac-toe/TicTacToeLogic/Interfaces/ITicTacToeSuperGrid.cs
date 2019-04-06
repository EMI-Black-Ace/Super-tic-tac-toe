using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_tic_tac_toe
{
    public interface ITicTacToeSuperGrid
    {
        event OverallWinHandler GameWon;
        event SubGridWinHandler GridWon;
        event MoveHandler MoveMade;
        TicTacToeGridStatus CheckGridStatus(int gridX, int gridY);
        TicTacToeCellStatus CheckCellStatus(int gridX, int gridY, int X, int Y);
        void ClaimCell(int gridX, int gridY, int X, int Y);
        void Reset();
    }
}
