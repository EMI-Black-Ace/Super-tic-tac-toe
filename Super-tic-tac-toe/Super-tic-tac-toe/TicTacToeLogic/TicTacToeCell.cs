using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_tic_tac_toe
{
    public enum TicTacToeCellStatus
    {
        X, O, Unclaimed
    }

    public class TicTacToeCell
    {
        public TicTacToeCellStatus Status { get; private set; } = TicTacToeCellStatus.Unclaimed;

        public TicTacToeCell()
        {

        }

        public void ClaimCell(TicTacToeCellStatus player)
        {
            if (Status != TicTacToeCellStatus.Unclaimed)
                throw new TicTacToeException("Cell is already claimed");

            if (player == TicTacToeCellStatus.Unclaimed)
                throw new TicTacToeException("\'Unclaimed\' cannot claim a cell");

            Status = player;
        }

        public void Reset()
        {
            Status = TicTacToeCellStatus.Unclaimed;
        }
    }
}
