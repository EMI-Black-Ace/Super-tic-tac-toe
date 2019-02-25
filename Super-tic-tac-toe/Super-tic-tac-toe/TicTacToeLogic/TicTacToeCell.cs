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
        private TicTacToeCellStatus status = TicTacToeCellStatus.Unclaimed;
        public TicTacToeCellStatus Status { get { return status; } }

        public TicTacToeCell()
        {

        }

        public void ClaimCell(TicTacToeCellStatus player)
        {
            if (status != TicTacToeCellStatus.Unclaimed)
                throw new TicTacToeException("Cell is already claimed");

            if (player == TicTacToeCellStatus.Unclaimed)
                throw new TicTacToeException("\'Unclaimed\' cannot claim a cell");

            status = player;
        }
    }
}
