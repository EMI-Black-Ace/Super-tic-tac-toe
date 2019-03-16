using Microsoft.VisualStudio.TestTools.UnitTesting;
using Super_tic_tac_toe;

namespace SuperTicTacToeTests
{
    [TestClass]
    public class TicTacToeTests
    {
        private TicTacToeSuperGrid supergrid = new TicTacToeSuperGrid();
        private int mostrecentgridwonx = -1;
        private int mostrecentgridwony = -1;
        private TicTacToeWinner whowon = TicTacToeWinner.Contested;

        public TicTacToeTests()
        {
            supergrid.GridWon += (u, e) =>
            {
                mostrecentgridwonx = e.SubGridX;
                mostrecentgridwony = e.SubGridY;
            };

            supergrid.GameWon += (u, e) =>
            {
                whowon = e.Winner;
            };
        }

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

        [TestMethod]
        public void SuperGridTakeTurnTest()
        {
            supergrid.Reset();

            supergrid.ClaimCell(0, 0, 0, 0);
            Assert.AreEqual(TicTacToeCellStatus.X, supergrid.CheckCellStatus(0, 0, 0, 0));
            Assert.AreEqual(TicTacToePlayerTurn.O, supergrid.WhoseTurn);
            Assert.AreEqual(0, supergrid.NextMoveX);
            Assert.AreEqual(0, supergrid.NextMoveY);

            supergrid.ClaimCell(0, 0, 0, 1);
            Assert.AreEqual(TicTacToeCellStatus.O, supergrid.CheckCellStatus(0, 0, 0, 1));
            Assert.AreEqual(TicTacToePlayerTurn.X, supergrid.WhoseTurn);
            Assert.AreEqual(0, supergrid.NextMoveX);
            Assert.AreEqual(1, supergrid.NextMoveY);
        }

        [TestMethod]
        public void SuperGridWinSubgridTest()
        {
            supergrid.Reset();

            //X's turn
            supergrid.ClaimCell(0, 0, 0, 1);
            //O's turn
            supergrid.ClaimCell(0, 1, 0, 0);
            //X
            supergrid.ClaimCell(0, 0, 0, 2);
            //O
            supergrid.ClaimCell(0, 2, 0, 0);
            //X
            
        }
    }
}
