﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Super_tic_tac_toe.ViewModels;
using Super_tic_tac_toe;
using Moq;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

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
            Button button = new Button();
            button.Name = "btn" + gridY.ToString() + gridX.ToString() + X.ToString() + Y.ToString();
            TicTacToeCellStatus status = TicTacToeCellStatus.Unclaimed;
            ttcsg.Setup(m => m.CheckCellStatus(gridX, gridY, X, Y)).Returns(() => status);
            ttcsg.Setup(m => m.ClaimCell(gridX, gridY, X, Y)).Raises(m => m.MoveMade += null, new TicTacToeTurnEventArgs(whoseturn, X, Y, gridX, gridY, X, Y));
            ttcsg.Setup(m => m.ClaimCell(gridX, gridY, X, Y)).Callback(() =>
            {
                status = TicTacToeCellStatus.X;
                whoseturn = TicTacToePlayerTurn.O;
                ttcsg.Raise(m => m.MoveMade += null, new TicTacToeTurnEventArgs(whoseturn, X, Y, gridX, gridY, X, Y));
            });
            vm = new TicTacToeSuperGridViewModel(ttcsg.Object);

            string propertyName = "ImgSrc" + gridX.ToString()
                + gridY.ToString()
                + X.ToString()
                + Y.ToString();

            Assert.IsNull((ImageSource)vm.GetType().GetProperty(propertyName).GetValue(vm));

            vm.ButtonClick.Execute(button);

            Assert.IsNotNull((ImageSource)vm.GetType().GetProperty(propertyName).GetValue(vm));
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
            TicTacToeCellStatus status = whoseturn == TicTacToePlayerTurn.X ? TicTacToeCellStatus.X : TicTacToeCellStatus.O;
            ttcsg.Setup(m => m.CheckCellStatus(gridX, gridY, X, Y)).Returns(() => status);
            ttcsg.Setup(m => m.ClaimCell(gridX, gridY, X, Y)).Throws(new TicTacToeException("dummy"));
            vm = new TicTacToeSuperGridViewModel(ttcsg.Object);

            string propertyName = "ImgSrc" + gridX.ToString()
                + gridY.ToString()
                + X.ToString()
                + Y.ToString();

            vm.GetType().GetProperty(propertyName).SetValue(vm, new BitmapImage(new Uri(@"/../Super-tic-tac-toe/Resources/"
                                                                                       + (whoseturn == TicTacToePlayerTurn.X? "X_img.bmp" : "O_img.bmp"),
                                                                                       UriKind.Relative)));

            ImageSource prebutton = (ImageSource)vm.GetType().GetProperty(propertyName).GetValue(vm);

            vm.ButtonClick.Execute(new int[] { gridX, gridY, X, Y });

            Assert.AreEqual(prebutton, (ImageSource)vm.GetType().GetProperty(propertyName).GetValue(vm));
        }
    }
}
