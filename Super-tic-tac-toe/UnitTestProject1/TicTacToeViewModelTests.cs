using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Super_tic_tac_toe.ViewModels;
using Super_tic_tac_toe;
using Moq;

namespace SuperTicTacToeTests
{
    [TestClass]
    public class TicTacToeViewModelTests
    {
        TicTacToeSuperGridViewModel vm;
        Mock<ITicTacToeSuperGrid> ttcsg;

        [TestInitialize]
        public void InitializeTest()
        {
            ttcsg = new Mock<ITicTacToeSuperGrid>();
        }

        [TestMethod]
        public void ButtonClickTest_success()
        {
            TicTacToeCellStatus status = TicTacToeCellStatus.Unclaimed;
            TicTacToePlayerTurn whoseturn = TicTacToePlayerTurn.X;
            ttcsg.Setup(m => m.CheckCellStatus(0, 0, 0, 0)).Returns(() => status);
            ttcsg.Setup(m => m.ClaimCell(0, 0, 0, 0)).Raises(m => m.MoveMade += null, new TicTacToeTurnEventArgs(whoseturn, 0,0,0,0,0,0));
            ttcsg.Setup(m => m.ClaimCell(0, 0, 0, 0)).Callback(() =>
            {
                status = TicTacToeCellStatus.X;
                whoseturn = TicTacToePlayerTurn.O;
            });
        }
    }
}
