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
        private TicTacToeGridStatus mostrecentsubgridwinner = TicTacToeGridStatus.Contested;
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
        public void SubgridWinVerticalTest()
        {
            supergrid.Reset();

            //X's turn
            supergrid.ClaimCell(0, 0, 0, 1);
            //O's turn
            supergrid.ClaimCell(0, 1, 0, 0);
            //X
            supergrid.ClaimCell(0, 0, 1, 1);
            //O
            supergrid.ClaimCell(1, 1, 0, 0);
            //X
            supergrid.ClaimCell(0, 0, 2, 1);
            //O, to verify that attempting to force the other player to play in a "won" subgrid lets them pick whatever they want next.
            supergrid.ClaimCell(2, 1, 0, 0);

            //mostrecentgridwonx and y are set by the SubGridWon event; these two lines assert that the event was raised.
            Assert.AreEqual(0, mostrecentgridwonx);
            Assert.AreEqual(0, mostrecentgridwony);

            //assert that the grid was won by X
            Assert.AreEqual(TicTacToeGridStatus.X, supergrid.CheckGridStatus(0, 0));

            //assert that attempting to force the other player into a "won" subgrid lets them pick whatever they want next.
            Assert.AreEqual(-1, supergrid.NextMoveX);
            Assert.AreEqual(-1, supergrid.NextMoveY);

            //make sure that nobody can claim any cells in the 'won' subgrid
            TicTacToeException ex = Assert.ThrowsException<TicTacToeException>(() =>
            {
                supergrid.ClaimCell(0, 0, 0, 0);
            });

            //Assert that it's still X's turn -- i.e. that the exception didn't forfeit X's turn
            Assert.AreEqual(TicTacToePlayerTurn.X, supergrid.WhoseTurn);
        }

        [TestMethod]
        public void SubgridWinHorizontalTest()
        {
            supergrid.Reset();

            //X's turn
            supergrid.ClaimCell(0, 0, 1, 0);
            //O's turn
            supergrid.ClaimCell(1, 0, 0, 0);
            //X
            supergrid.ClaimCell(0, 0, 1, 1);
            //O
            supergrid.ClaimCell(1, 1, 0, 0);
            //X
            supergrid.ClaimCell(0, 0, 1, 2);
            //O, to verify that attempting to force the other player to play in a "won" subgrid lets them pick whatever they want next.
            supergrid.ClaimCell(1, 2, 0, 0);

            //mostrecentgridwonx and y are set by the SubGridWon event; these two lines assert that the event was raised.
            Assert.AreEqual(0, mostrecentgridwonx);
            Assert.AreEqual(0, mostrecentgridwony);

            //assert that the grid was won by X
            Assert.AreEqual(TicTacToeGridStatus.X, supergrid.CheckGridStatus(0, 0));

            //assert that attempting to force the other player into a "won" subgrid lets them pick whatever they want next.
            Assert.AreEqual(-1, supergrid.NextMoveX);
            Assert.AreEqual(-1, supergrid.NextMoveY);

            //make sure that nobody can claim any cells in the 'won' subgrid
            TicTacToeException ex = Assert.ThrowsException<TicTacToeException>(() =>
            {
                supergrid.ClaimCell(0, 0, 0, 0);
            });

            //Assert that it's still X's turn -- i.e. that the exception didn't forfeit X's turn
            Assert.AreEqual(TicTacToePlayerTurn.X, supergrid.WhoseTurn);
        }

        [TestMethod]
        public void SubgridWinDiagonalTest()
        {
            supergrid.Reset();

            supergrid.ClaimCell(0, 0, 1, 1);
            supergrid.ClaimCell(1, 1, 0, 0);
            supergrid.ClaimCell(0, 0, 2, 2);
            supergrid.ClaimCell(2, 2, 0, 0);
            supergrid.ClaimCell(0, 0, 0, 0);

            //assert that the grid was won by X
            Assert.AreEqual(TicTacToeGridStatus.X, supergrid.CheckGridStatus(0, 0));

            supergrid.Reset();

            supergrid.ClaimCell(0, 1, 0, 0);
            supergrid.ClaimCell(0, 0, 2, 0);
            supergrid.ClaimCell(2, 0, 0, 0);
            supergrid.ClaimCell(0, 0, 1, 1);
            supergrid.ClaimCell(1, 1, 0, 0);
            supergrid.ClaimCell(0, 0, 0, 2);

            Assert.AreEqual(TicTacToeGridStatus.O, supergrid.CheckGridStatus(0, 0));
        }

        [TestMethod]
        public void SubgridStalemateTest()
        {
            supergrid.Reset();

            //Claim pattern for subgrid 0,0
            // X O O
            // X O O
            // O X X

            supergrid.ClaimCell(0, 0, 0, 0);//X
            supergrid.ClaimCell(0, 0, 0, 1);//O
            supergrid.ClaimCell(0, 1, 0, 0);//X
            supergrid.ClaimCell(0, 0, 0, 2);//O
            supergrid.ClaimCell(0, 2, 0, 0);//X
            supergrid.ClaimCell(0, 0, 1, 1);//O
            supergrid.ClaimCell(1, 1, 0, 0);//X
            supergrid.ClaimCell(0, 0, 1, 2);//O
            supergrid.ClaimCell(1, 2, 0, 0);//X
            supergrid.ClaimCell(0, 0, 2, 0);//O
            supergrid.ClaimCell(2, 0, 2, 2);//X
            supergrid.ClaimCell(2, 2, 0, 0);//O
            supergrid.ClaimCell(0, 0, 1, 0);//X
            supergrid.ClaimCell(1, 0, 0, 0);//O
            supergrid.ClaimCell(0, 0, 2, 1);//X
            supergrid.ClaimCell(2, 1, 0, 0);//O
            supergrid.ClaimCell(0, 0, 2, 2);//X

            Assert.AreEqual(TicTacToeGridStatus.Stalemate, supergrid.CheckGridStatus(0, 0));
        }
    }
}
