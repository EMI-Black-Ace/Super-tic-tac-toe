using Microsoft.VisualStudio.TestTools.UnitTesting;
using Super_tic_tac_toe;

namespace SuperTicTacToeTests
{
    [TestClass]
    public class TicTacToeTests
    {
        private TicTacToeSuperGrid supergrid = new TicTacToeSuperGrid();

        [TestMethod]
        public void SuperGridResetTest()
        {
            supergrid.Reset();
            Assert.AreEqual(TicTacToePlayerTurn.X, supergrid.WhoseTurn);
            Assert.AreEqual(-1, supergrid.NextMoveX);
            Assert.AreEqual(-1, supergrid.NextMoveY);
            
            for(int i = 0; i < 3; ++i)
            {
                for(int j = 0; j < 3; ++j)
                {
                    Assert.AreEqual(TicTacToeGridStatus.Contested, supergrid.CheckGridStatus(i, j));
                    for(int k = 0; k < 3; ++k)
                    {
                        for(int l = 0; l < 3; ++l)
                        {
                            Assert.AreEqual(TicTacToeCellStatus.Unclaimed, supergrid.CheckCellStatus(i, j, k, l));
                        }
                    }
                }
            }
        }


    }
}
