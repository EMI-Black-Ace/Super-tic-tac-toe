using Microsoft.VisualStudio.TestTools.UnitTesting;
using Super_tic_tac_toe;

namespace SuperTicTacToeTests
{
    [TestClass]
    public class TicTacToeTests
    {
        private TicTacToeSuperGrid ttcsg;

        [TestMethod]
        public void SuperGridInitTest()
        {
            ttcsg = new TicTacToeSuperGrid();
            Assert.IsTrue(ttcsg.WhoseTurn == TicTacToePlayerTurn.X);
            Assert.IsTrue(ttcsg.NextMoveX == -1);
            Assert.IsTrue(ttcsg.NextMoveY == -1);


        }
    }
}
