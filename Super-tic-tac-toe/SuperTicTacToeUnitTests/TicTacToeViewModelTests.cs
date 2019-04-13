using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Super_tic_tac_toe.ViewModels;
using Super_tic_tac_toe;
using Moq;
using System.Reflection;

namespace SuperTicTacToeTests
{
    [TestClass]
    public class TicTacToeViewModelTests
    {
        TicTacToeSuperGridViewModel vm;
        Mock<ITicTacToeSuperGrid> supergrid_fake;

        [TestInitialize]
        public void InitializeTest()
        {
            supergrid_fake = new Mock<ITicTacToeSuperGrid>();
        }

        #region Data rows
        [DataRow(TicTacToePlayerTurn.X, 0, 0, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 0, 0, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 0, 0, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 0, 0, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 0, 0, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 0, 0, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 0, 0, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 0, 0, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 0, 0, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 0, 1, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 0, 1, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 0, 1, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 0, 1, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 0, 1, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 0, 1, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 0, 1, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 0, 1, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 0, 1, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 0, 2, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 0, 2, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 0, 2, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 0, 2, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 0, 2, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 0, 2, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 0, 2, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 0, 2, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 0, 2, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 1, 0, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 1, 0, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 1, 0, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 1, 0, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 1, 0, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 1, 0, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 1, 0, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 1, 0, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 1, 0, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 1, 1, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 1, 1, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 1, 1, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 1, 1, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 1, 1, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 1, 1, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 1, 1, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 1, 1, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 1, 1, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 1, 2, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 1, 2, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 1, 2, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 1, 2, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 1, 2, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 1, 2, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 1, 2, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 1, 2, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 1, 2, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 2, 0, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 2, 0, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 2, 0, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 2, 0, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 2, 0, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 2, 0, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 2, 0, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 2, 0, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 2, 0, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 2, 1, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 2, 1, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 2, 1, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 2, 1, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 2, 1, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 2, 1, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 2, 1, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 2, 1, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 2, 1, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 2, 2, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 2, 2, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 2, 2, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 2, 2, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 2, 2, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 2, 2, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 2, 2, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 2, 2, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 2, 2, 2, 2)] 
        #endregion
        [DataTestMethod]
        public void ButtonClickTest_success(TicTacToePlayerTurn whoseturn, int gridX, int gridY, int X, int Y)
        {
            supergrid_fake.Setup(m => m.WhoseTurn).Returns(whoseturn);
            vm = new TicTacToeSuperGridViewModel(supergrid_fake.Object);

            var objSender = new { Name = "Btn" + gridX.ToString() + gridY.ToString() + X.ToString() + Y.ToString() };
            string propertyName = "ImgSrc" + gridX.ToString()
                + gridY.ToString()
                + X.ToString()
                + Y.ToString();

            Assert.IsNull(vm.GetType().GetProperty(propertyName).GetValue(vm));

            vm.ButtonClick.Execute(objSender);

            Assert.AreEqual(FilePaths.GetFilePath(whoseturn), vm.GetType().GetProperty(propertyName).GetValue(vm));
        }

        #region Data rows
        [DataRow(TicTacToePlayerTurn.X, 0, 0, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 0, 0, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 0, 0, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 0, 0, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 0, 0, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 0, 0, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 0, 0, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 0, 0, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 0, 0, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 0, 1, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 0, 1, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 0, 1, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 0, 1, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 0, 1, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 0, 1, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 0, 1, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 0, 1, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 0, 1, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 0, 2, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 0, 2, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 0, 2, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 0, 2, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 0, 2, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 0, 2, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 0, 2, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 0, 2, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 0, 2, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 1, 0, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 1, 0, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 1, 0, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 1, 0, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 1, 0, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 1, 0, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 1, 0, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 1, 0, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 1, 0, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 1, 1, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 1, 1, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 1, 1, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 1, 1, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 1, 1, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 1, 1, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 1, 1, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 1, 1, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 1, 1, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 1, 2, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 1, 2, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 1, 2, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 1, 2, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 1, 2, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 1, 2, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 1, 2, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 1, 2, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 1, 2, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 2, 0, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 2, 0, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 2, 0, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 2, 0, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 2, 0, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 2, 0, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 2, 0, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 2, 0, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 2, 0, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 2, 1, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 2, 1, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 2, 1, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 2, 1, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 2, 1, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 2, 1, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 2, 1, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 2, 1, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 2, 1, 2, 2)]

        [DataRow(TicTacToePlayerTurn.X, 2, 2, 0, 0)]
        [DataRow(TicTacToePlayerTurn.O, 2, 2, 0, 1)]
        [DataRow(TicTacToePlayerTurn.X, 2, 2, 0, 2)]
        [DataRow(TicTacToePlayerTurn.O, 2, 2, 1, 0)]
        [DataRow(TicTacToePlayerTurn.X, 2, 2, 1, 1)]
        [DataRow(TicTacToePlayerTurn.O, 2, 2, 1, 2)]
        [DataRow(TicTacToePlayerTurn.X, 2, 2, 2, 0)]
        [DataRow(TicTacToePlayerTurn.O, 2, 2, 2, 1)]
        [DataRow(TicTacToePlayerTurn.X, 2, 2, 2, 2)]
        #endregion
        [DataTestMethod]
        public void ButtonClickTest_fail(TicTacToePlayerTurn whoseturn, int gridX, int gridY, int X, int Y)
        {
            supergrid_fake.Setup(m => m.ClaimCell(gridX, gridY, X, Y)).Throws(new TicTacToeException("dummy"));
            vm = new TicTacToeSuperGridViewModel(supergrid_fake.Object);

            string propertyName = "ImgSrc" + gridX.ToString()
                + gridY.ToString()
                + X.ToString()
                + Y.ToString();

            string prebutton = vm.GetType().GetProperty(propertyName).GetValue(vm) as string;
            var objSender = new { Name = "Btn" + gridX.ToString() + gridY.ToString() + X.ToString() + Y.ToString() };

            vm.ButtonClick.Execute(objSender);

            Assert.AreEqual(prebutton, vm.GetType().GetProperty(propertyName).GetValue(vm));
        }
    }
}
