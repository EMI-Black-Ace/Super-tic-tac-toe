using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_tic_tac_toe.ViewModels
{
    public static class FilePaths
    {
        public const string RESOURCE_FOLDER = @"/./Resources/";
        public const string X_IMG = "X_img.bmp";
        public const string O_IMG = "O_img.bmp";
        public static string GetFilePath(TicTacToePlayerTurn whoseturn)
        {
            return RESOURCE_FOLDER + (whoseturn == TicTacToePlayerTurn.X ? X_IMG : O_IMG);
        }
    }
}
