using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Super_tic_tac_toe.ViewModels
{
    public class TicTacToeSuperGridViewModel : ObservableObject
    {
        private ITicTacToeSuperGrid superGrid;

        public ImageSource[,,,] imageGrid;

        public TicTacToeSuperGridViewModel(ITicTacToeSuperGrid SuperGrid)
        {
            superGrid = SuperGrid;
            superGrid.MoveMade += SuperGrid_MoveMade;
            ButtonClick = new RelayCommand((x) => OnButtonClick(x as int[]));
        }

        private void SuperGrid_MoveMade(object sender, TicTacToeTurnEventArgs e)
        {
            string propertyName = "ImgSrc" + e.MoveXGrid.ToString()
                + e.MoveYGrid.ToString()
                + e.MoveX.ToString()
                + e.MoveY.ToString();
            string imageFilePath = @"/./Resources/" + (e.WhoseTurn == TicTacToePlayerTurn.X ? "O_img.bmp" : "X_img.bmp");
            BitmapImage targetImage = new BitmapImage(new Uri(imageFilePath));
            PropertyInfo property = GetType().GetProperty(propertyName);
            property.SetValue(this, targetImage);
        }

        #region Image Grid Properties

        public ImageSource ImgSrc0000 { get => imageGrid[0, 0, 0, 0]; set { imageGrid[0, 0, 0, 0] = value; OnPropertyChanged("ImgSrc0000"); } }
        public ImageSource ImgSrc1000 { get => imageGrid[0, 0, 1, 0]; set { imageGrid[0, 0, 1, 0] = value; OnPropertyChanged("ImgSrc1000"); } }
        public ImageSource ImgSrc2000 { get => imageGrid[0, 0, 2, 0]; set { imageGrid[0, 0, 2, 0] = value; OnPropertyChanged("ImgSrc2000"); } }
        public ImageSource ImgSrc0100 { get => imageGrid[0, 0, 0, 1]; set { imageGrid[0, 0, 0, 1] = value; OnPropertyChanged("ImgSrc0100"); } }
        public ImageSource ImgSrc1100 { get => imageGrid[0, 0, 1, 1]; set { imageGrid[0, 0, 1, 1] = value; OnPropertyChanged("ImgSrc1100"); } }
        public ImageSource ImgSrc2100 { get => imageGrid[0, 0, 2, 1]; set { imageGrid[0, 0, 2, 1] = value; OnPropertyChanged("ImgSrc2100"); } }
        public ImageSource ImgSrc0200 { get => imageGrid[0, 0, 0, 2]; set { imageGrid[0, 0, 0, 2] = value; OnPropertyChanged("ImgSrc0200"); } }
        public ImageSource ImgSrc1200 { get => imageGrid[0, 0, 1, 2]; set { imageGrid[0, 0, 1, 2] = value; OnPropertyChanged("ImgSrc1200"); } }
        public ImageSource ImgSrc2200 { get => imageGrid[0, 0, 2, 2]; set { imageGrid[0, 0, 2, 2] = value; OnPropertyChanged("ImgSrc2200"); } }

        public ImageSource ImgSrc0001 { get => imageGrid[0, 1, 0, 0]; set { imageGrid[0, 1, 0, 0] = value; OnPropertyChanged("ImgSrc0001"); } }
        public ImageSource ImgSrc1001 { get => imageGrid[0, 1, 1, 0]; set { imageGrid[0, 1, 1, 0] = value; OnPropertyChanged("ImgSrc1001"); } }
        public ImageSource ImgSrc2001 { get => imageGrid[0, 1, 2, 0]; set { imageGrid[0, 1, 2, 0] = value; OnPropertyChanged("ImgSrc2001"); } }
        public ImageSource ImgSrc0101 { get => imageGrid[0, 1, 0, 1]; set { imageGrid[0, 1, 0, 1] = value; OnPropertyChanged("ImgSrc0101"); } }
        public ImageSource ImgSrc1101 { get => imageGrid[0, 1, 1, 1]; set { imageGrid[0, 1, 1, 1] = value; OnPropertyChanged("ImgSrc1101"); } }
        public ImageSource ImgSrc2101 { get => imageGrid[0, 1, 2, 1]; set { imageGrid[0, 1, 2, 1] = value; OnPropertyChanged("ImgSrc2101"); } }
        public ImageSource ImgSrc0201 { get => imageGrid[0, 1, 0, 2]; set { imageGrid[0, 1, 0, 2] = value; OnPropertyChanged("ImgSrc0201"); } }
        public ImageSource ImgSrc1201 { get => imageGrid[0, 1, 1, 2]; set { imageGrid[0, 1, 1, 2] = value; OnPropertyChanged("ImgSrc1201"); } }
        public ImageSource ImgSrc2201 { get => imageGrid[0, 1, 2, 2]; set { imageGrid[0, 1, 2, 2] = value; OnPropertyChanged("ImgSrc2201"); } }

        public ImageSource ImgSrc0002 { get => imageGrid[0, 2, 0, 0]; set { imageGrid[0, 2, 0, 0] = value; OnPropertyChanged("ImgSrc0002"); } }
        public ImageSource ImgSrc1002 { get => imageGrid[0, 2, 1, 0]; set { imageGrid[0, 2, 1, 0] = value; OnPropertyChanged("ImgSrc1002"); } }
        public ImageSource ImgSrc2002 { get => imageGrid[0, 2, 2, 0]; set { imageGrid[0, 2, 2, 0] = value; OnPropertyChanged("ImgSrc2002"); } }
        public ImageSource ImgSrc0102 { get => imageGrid[0, 2, 0, 1]; set { imageGrid[0, 2, 0, 1] = value; OnPropertyChanged("ImgSrc0102"); } }
        public ImageSource ImgSrc1102 { get => imageGrid[0, 2, 1, 1]; set { imageGrid[0, 2, 1, 1] = value; OnPropertyChanged("ImgSrc1102"); } }
        public ImageSource ImgSrc2102 { get => imageGrid[0, 2, 2, 1]; set { imageGrid[0, 2, 2, 1] = value; OnPropertyChanged("ImgSrc2102"); } }
        public ImageSource ImgSrc0202 { get => imageGrid[0, 2, 0, 2]; set { imageGrid[0, 2, 0, 2] = value; OnPropertyChanged("ImgSrc0202"); } }
        public ImageSource ImgSrc1202 { get => imageGrid[0, 2, 1, 2]; set { imageGrid[0, 2, 1, 2] = value; OnPropertyChanged("ImgSrc1202"); } }
        public ImageSource ImgSrc2202 { get => imageGrid[0, 2, 2, 2]; set { imageGrid[0, 2, 2, 2] = value; OnPropertyChanged("ImgSrc2202"); } }

        public ImageSource ImgSrc0010 { get => imageGrid[1, 0, 0, 0]; set { imageGrid[1, 0, 0, 0] = value; OnPropertyChanged("ImgSrc0010"); } }
        public ImageSource ImgSrc1010 { get => imageGrid[1, 0, 1, 0]; set { imageGrid[1, 0, 1, 0] = value; OnPropertyChanged("ImgSrc1010"); } }
        public ImageSource ImgSrc2010 { get => imageGrid[1, 0, 2, 0]; set { imageGrid[1, 0, 2, 0] = value; OnPropertyChanged("ImgSrc2010"); } }
        public ImageSource ImgSrc0110 { get => imageGrid[1, 0, 0, 1]; set { imageGrid[1, 0, 0, 1] = value; OnPropertyChanged("ImgSrc0110"); } }
        public ImageSource ImgSrc1110 { get => imageGrid[1, 0, 1, 1]; set { imageGrid[1, 0, 1, 1] = value; OnPropertyChanged("ImgSrc1110"); } }
        public ImageSource ImgSrc2110 { get => imageGrid[1, 0, 2, 1]; set { imageGrid[1, 0, 2, 1] = value; OnPropertyChanged("ImgSrc2110"); } }
        public ImageSource ImgSrc0210 { get => imageGrid[1, 0, 0, 2]; set { imageGrid[1, 0, 0, 2] = value; OnPropertyChanged("ImgSrc0210"); } }
        public ImageSource ImgSrc1210 { get => imageGrid[1, 0, 1, 2]; set { imageGrid[1, 0, 1, 2] = value; OnPropertyChanged("ImgSrc1210"); } }
        public ImageSource ImgSrc2210 { get => imageGrid[1, 0, 2, 2]; set { imageGrid[1, 0, 2, 2] = value; OnPropertyChanged("ImgSrc2210"); } }

        public ImageSource ImgSrc0011 { get => imageGrid[1, 1, 0, 0]; set { imageGrid[1, 1, 0, 0] = value; OnPropertyChanged("ImgSrc0011"); } }
        public ImageSource ImgSrc1011 { get => imageGrid[1, 1, 1, 0]; set { imageGrid[1, 1, 1, 0] = value; OnPropertyChanged("ImgSrc1011"); } }
        public ImageSource ImgSrc2011 { get => imageGrid[1, 1, 2, 0]; set { imageGrid[1, 1, 2, 0] = value; OnPropertyChanged("ImgSrc2011"); } }
        public ImageSource ImgSrc0111 { get => imageGrid[1, 1, 0, 1]; set { imageGrid[1, 1, 0, 1] = value; OnPropertyChanged("ImgSrc0111"); } }
        public ImageSource ImgSrc1111 { get => imageGrid[1, 1, 1, 1]; set { imageGrid[1, 1, 1, 1] = value; OnPropertyChanged("ImgSrc1111"); } }
        public ImageSource ImgSrc2111 { get => imageGrid[1, 1, 2, 1]; set { imageGrid[1, 1, 2, 1] = value; OnPropertyChanged("ImgSrc2111"); } }
        public ImageSource ImgSrc0211 { get => imageGrid[1, 1, 0, 2]; set { imageGrid[1, 1, 0, 2] = value; OnPropertyChanged("ImgSrc0211"); } }
        public ImageSource ImgSrc1211 { get => imageGrid[1, 1, 1, 2]; set { imageGrid[1, 1, 1, 2] = value; OnPropertyChanged("ImgSrc1211"); } }
        public ImageSource ImgSrc2211 { get => imageGrid[1, 1, 2, 2]; set { imageGrid[1, 1, 2, 2] = value; OnPropertyChanged("ImgSrc2211"); } }

        public ImageSource ImgSrc0012 { get => imageGrid[1, 2, 0, 0]; set { imageGrid[1, 2, 0, 0] = value; OnPropertyChanged("ImgSrc0012"); } }
        public ImageSource ImgSrc1012 { get => imageGrid[1, 2, 1, 0]; set { imageGrid[1, 2, 1, 0] = value; OnPropertyChanged("ImgSrc1012"); } }
        public ImageSource ImgSrc2012 { get => imageGrid[1, 2, 2, 0]; set { imageGrid[1, 2, 2, 0] = value; OnPropertyChanged("ImgSrc2012"); } }
        public ImageSource ImgSrc0112 { get => imageGrid[1, 2, 0, 1]; set { imageGrid[1, 2, 0, 1] = value; OnPropertyChanged("ImgSrc0112"); } }
        public ImageSource ImgSrc1112 { get => imageGrid[1, 2, 1, 1]; set { imageGrid[1, 2, 1, 1] = value; OnPropertyChanged("ImgSrc1112"); } }
        public ImageSource ImgSrc2112 { get => imageGrid[1, 2, 2, 1]; set { imageGrid[1, 2, 2, 1] = value; OnPropertyChanged("ImgSrc2112"); } }
        public ImageSource ImgSrc0212 { get => imageGrid[1, 2, 0, 2]; set { imageGrid[1, 2, 0, 2] = value; OnPropertyChanged("ImgSrc0212"); } }
        public ImageSource ImgSrc1212 { get => imageGrid[1, 2, 1, 2]; set { imageGrid[1, 2, 1, 2] = value; OnPropertyChanged("ImgSrc1212"); } }
        public ImageSource ImgSrc2212 { get => imageGrid[1, 2, 2, 2]; set { imageGrid[1, 2, 2, 2] = value; OnPropertyChanged("ImgSrc2212"); } }

        public ImageSource ImgSrc0020 { get => imageGrid[2, 0, 0, 0]; set { imageGrid[2, 0, 0, 0] = value; OnPropertyChanged("ImgSrc0020"); } }
        public ImageSource ImgSrc1020 { get => imageGrid[2, 0, 1, 0]; set { imageGrid[2, 0, 1, 0] = value; OnPropertyChanged("ImgSrc1020"); } }
        public ImageSource ImgSrc2020 { get => imageGrid[2, 0, 2, 0]; set { imageGrid[2, 0, 2, 0] = value; OnPropertyChanged("ImgSrc2020"); } }
        public ImageSource ImgSrc0120 { get => imageGrid[2, 0, 0, 1]; set { imageGrid[2, 0, 0, 1] = value; OnPropertyChanged("ImgSrc0120"); } }
        public ImageSource ImgSrc1120 { get => imageGrid[2, 0, 1, 1]; set { imageGrid[2, 0, 1, 1] = value; OnPropertyChanged("ImgSrc1120"); } }
        public ImageSource ImgSrc2120 { get => imageGrid[2, 0, 2, 1]; set { imageGrid[2, 0, 2, 1] = value; OnPropertyChanged("ImgSrc2120"); } }
        public ImageSource ImgSrc0220 { get => imageGrid[2, 0, 0, 2]; set { imageGrid[2, 0, 0, 2] = value; OnPropertyChanged("ImgSrc0220"); } }
        public ImageSource ImgSrc1220 { get => imageGrid[2, 0, 1, 2]; set { imageGrid[2, 0, 1, 2] = value; OnPropertyChanged("ImgSrc1220"); } }
        public ImageSource ImgSrc2220 { get => imageGrid[2, 0, 2, 2]; set { imageGrid[2, 0, 2, 2] = value; OnPropertyChanged("ImgSrc2220"); } }

        public ImageSource ImgSrc0021 { get => imageGrid[2, 1, 0, 0]; set { imageGrid[2, 1, 0, 0] = value; OnPropertyChanged("ImgSrc0021"); } }
        public ImageSource ImgSrc1021 { get => imageGrid[2, 1, 1, 0]; set { imageGrid[2, 1, 1, 0] = value; OnPropertyChanged("ImgSrc1021"); } }
        public ImageSource ImgSrc2021 { get => imageGrid[2, 1, 2, 0]; set { imageGrid[2, 1, 2, 0] = value; OnPropertyChanged("ImgSrc2021"); } }
        public ImageSource ImgSrc0121 { get => imageGrid[2, 1, 0, 1]; set { imageGrid[2, 1, 0, 1] = value; OnPropertyChanged("ImgSrc0121"); } }
        public ImageSource ImgSrc1121 { get => imageGrid[2, 1, 1, 1]; set { imageGrid[2, 1, 1, 1] = value; OnPropertyChanged("ImgSrc1121"); } }
        public ImageSource ImgSrc2121 { get => imageGrid[2, 1, 2, 1]; set { imageGrid[2, 1, 2, 1] = value; OnPropertyChanged("ImgSrc2121"); } }
        public ImageSource ImgSrc0221 { get => imageGrid[2, 1, 0, 2]; set { imageGrid[2, 1, 0, 2] = value; OnPropertyChanged("ImgSrc0221"); } }
        public ImageSource ImgSrc1221 { get => imageGrid[2, 1, 1, 2]; set { imageGrid[2, 1, 1, 2] = value; OnPropertyChanged("ImgSrc1221"); } }
        public ImageSource ImgSrc2221 { get => imageGrid[2, 1, 2, 2]; set { imageGrid[2, 1, 2, 2] = value; OnPropertyChanged("ImgSrc2221"); } }

        public ImageSource ImgSrc0022 { get => imageGrid[2, 2, 0, 0]; set { imageGrid[2, 2, 0, 0] = value; OnPropertyChanged("ImgSrc0022"); } }
        public ImageSource ImgSrc1022 { get => imageGrid[2, 2, 1, 0]; set { imageGrid[2, 2, 1, 0] = value; OnPropertyChanged("ImgSrc1022"); } }
        public ImageSource ImgSrc2022 { get => imageGrid[2, 2, 2, 0]; set { imageGrid[2, 2, 2, 0] = value; OnPropertyChanged("ImgSrc2022"); } }
        public ImageSource ImgSrc0122 { get => imageGrid[2, 2, 0, 1]; set { imageGrid[2, 2, 0, 1] = value; OnPropertyChanged("ImgSrc0122"); } }
        public ImageSource ImgSrc1122 { get => imageGrid[2, 2, 1, 1]; set { imageGrid[2, 2, 1, 1] = value; OnPropertyChanged("ImgSrc1122"); } }
        public ImageSource ImgSrc2122 { get => imageGrid[2, 2, 2, 1]; set { imageGrid[2, 2, 2, 1] = value; OnPropertyChanged("ImgSrc2122"); } }
        public ImageSource ImgSrc0222 { get => imageGrid[2, 2, 0, 2]; set { imageGrid[2, 2, 0, 2] = value; OnPropertyChanged("ImgSrc0222"); } }
        public ImageSource ImgSrc1222 { get => imageGrid[2, 2, 1, 2]; set { imageGrid[2, 2, 1, 2] = value; OnPropertyChanged("ImgSrc1222"); } }
        public ImageSource ImgSrc2222 { get => imageGrid[2, 2, 2, 2]; set { imageGrid[2, 2, 2, 2] = value; OnPropertyChanged("ImgSrc2222"); } }

        #endregion

        /// <summary>
        /// Command bound to button clicks.  Must pass in int[] parameter.
        /// </summary>
        public ICommand ButtonClick { get; set; }

        private void OnButtonClick(int[] GridLocation)
        {
            try
            {
                superGrid.ClaimCell(GridLocation[0], GridLocation[1], GridLocation[2], GridLocation[3]);
            }
            catch (TicTacToeException)
            {
                //do nothing
            }
        }

        
    }
}
