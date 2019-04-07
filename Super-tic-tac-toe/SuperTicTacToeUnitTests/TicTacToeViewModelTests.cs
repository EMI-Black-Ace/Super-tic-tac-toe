using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Super_tic_tac_toe.ViewModels;
using Super_tic_tac_toe;
using Moq;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            TicTacToeCellStatus status = TicTacToeCellStatus.Unclaimed;
            ttcsg.Setup(m => m.CheckCellStatus(gridX, gridY, X, Y)).Returns(() => status);
            ttcsg.Setup(m => m.ClaimCell(gridX, gridY, X, Y)).Raises(m => m.MoveMade += null, new TicTacToeTurnEventArgs(whoseturn, X, Y, gridX, gridY, X, Y));
            ttcsg.Setup(m => m.ClaimCell(gridX, gridY, X, Y)).Callback(() =>
            {
                status = TicTacToeCellStatus.X;
                whoseturn = TicTacToePlayerTurn.O;
            });
            vm = new TicTacToeSuperGridViewModel(ttcsg.Object);

            vm.ButtonClick.Execute(new int[] { gridX, gridY, X, Y });

            string propertyName = "ImgSrc" + gridX.ToString()
                + gridY.ToString()
                + X.ToString()
                + Y.ToString();

            ImageSource source = (ImageSource)vm.GetType().GetProperty(propertyName).GetValue(vm);
            ImageSource forComparison = new BitmapImage(new Uri(@"/././Super-tic-tac-toe/Resources/"
                                + (whoseturn == TicTacToePlayerTurn.X ? "X_img.bmp" : "O_img.bmp")));

            Assert.AreEqual(forComparison, source);
        }
    }
}
