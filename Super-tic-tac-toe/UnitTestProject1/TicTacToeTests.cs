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
            Assert.AreEqual(TicTacToePlayerTurn.X, ttcsg.WhoseTurn);
            Assert.AreEqual(-1, ttcsg.NextMoveX);
            Assert.AreEqual(-1, ttcsg.NextMoveY);
        }

        [TestMethod]
        public void SuperGridTakeTurnTest()
        {

        }
    }
}
