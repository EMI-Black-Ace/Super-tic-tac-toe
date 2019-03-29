using Microsoft.VisualStudio.TestTools.UnitTesting;
using Super_tic_tac_toe;
using System;
using System.Diagnostics;

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
            // X O X
            // X O O
            // O X X

            supergrid.ClaimCell(0, 0, 0, 0);//X
            //X--
            //---
            //---
            supergrid.ClaimCell(0, 0, 1, 0);//O
            //XO-
            //---
            //---
            supergrid.ClaimCell(1, 0, 0, 0);//X         //Can't use 1,0 to return anymore
            supergrid.ClaimCell(0, 0, 1, 1);//O
            //XO-
            //-O-
            //---
            supergrid.ClaimCell(1, 1, 0, 0);//X         //can't use 1,1 to return anymore
            supergrid.ClaimCell(0, 0, 2, 1);//O
            //XO-
            //-OO
            //---
            supergrid.ClaimCell(2, 1, 0, 0);//X         //can't use 2,1 to return anymore
            supergrid.ClaimCell(0, 0, 0, 2);//O
            //XO-
            //-OO
            //O--
            supergrid.ClaimCell(0, 2, 0, 2);//X
            supergrid.ClaimCell(0, 2, 0, 0);//O         //can't use 0,2 to return anymore
            supergrid.ClaimCell(0, 0, 0, 1);//X
            //XO-
            //XOO
            //O--
            supergrid.ClaimCell(0, 1, 0, 0);//O         //can't use 0,1 to return anymore
            supergrid.ClaimCell(0, 0, 1, 2);//X
            //XO-
            //XOO
            //OX-
            supergrid.ClaimCell(1, 2, 0, 0);//O         //can't use 1,2 to return anymore
            supergrid.ClaimCell(0, 0, 2, 2);//X
            //XO-
            //XOO
            //OXX
            supergrid.ClaimCell(2, 2, 0, 0);//O
            supergrid.ClaimCell(0, 0, 2, 0);//X

            Assert.AreEqual(TicTacToeGridStatus.Stalemate, supergrid.CheckGridStatus(0, 0));
        }

        [TestMethod]
        public void SubgridCantClaimClaimedCellTest()
        {
            supergrid.Reset();

            supergrid.ClaimCell(0, 0, 0, 0);

            TicTacToeException ex = Assert.ThrowsException<TicTacToeException>(() =>
            {
                supergrid.ClaimCell(0, 0, 0, 0);
            });

            Assert.AreEqual("Cell is already claimed", ex.Message);
        }

        [TestMethod]
        public void AssertValidClaimCellInputs()
        {
            supergrid.Reset();

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                supergrid.ClaimCell(-1, 0, 0, 0);
            });
            StringAssert.Contains(ex.Message, "column or row selection invalid:");

            ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                supergrid.ClaimCell(3, 0, 0, 0);
            });
            StringAssert.Contains(ex.Message, "column or row selection invalid:");

            ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                supergrid.ClaimCell(0, -1, 0, 0);
            });
            StringAssert.Contains(ex.Message, "column or row selection invalid:");

            ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                supergrid.ClaimCell(0, 3, 0, 0);
            });
            StringAssert.Contains(ex.Message, "column or row selection invalid:");

            ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                supergrid.ClaimCell(0, 0, -1, 0);
            });
            StringAssert.Contains(ex.Message, "column or row selection invalid:");

            ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                supergrid.ClaimCell(0, 0, 3, 0);
            });
            StringAssert.Contains(ex.Message, "column or row selection invalid:");

            ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                supergrid.ClaimCell(0, 0, 0, -1);
            });
            StringAssert.Contains(ex.Message, "column or row selection invalid:");

            ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                supergrid.ClaimCell(0, 0, 0, 3);
            });
            StringAssert.Contains(ex.Message, "column or row selection invalid:");
        }

        [TestMethod]
        public void AssertCantPlayInWonGrid()
        {
            SubgridWinVerticalTest();

            Debug.Assert(supergrid.CheckGridStatus(0,0) != TicTacToeGridStatus.Contested, "recheck SubgridWinVerticalTest -- subgrid 0,0 should have been won");
            Debug.Assert(supergrid.WhoseTurn == TicTacToePlayerTurn.X, "recheck SubgridWinVerticalTest -- should be X's turn");

            //make sure that nobody can claim any cells in the 'won' subgrid
            TicTacToeException ex = Assert.ThrowsException<TicTacToeException>(() =>
            {
                supergrid.ClaimCell(0, 0, 0, 0);
            });
            StringAssert.Contains("Grid is already filled in", ex.Message);

            //Assert that it's still X's turn -- i.e. that the exception didn't forfeit X's turn
            Assert.AreEqual(TicTacToePlayerTurn.X, supergrid.WhoseTurn);
        }
    }
}
