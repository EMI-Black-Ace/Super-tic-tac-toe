using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_tic_tac_toe
{
    public class TicTacToeException : Exception
    {
        public TicTacToeException(string message) : base(message)
        {

        }

        public TicTacToeException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
