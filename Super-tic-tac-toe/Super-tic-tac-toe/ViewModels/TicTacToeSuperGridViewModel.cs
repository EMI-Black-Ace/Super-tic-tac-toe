using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Super_tic_tac_toe.ViewModels
{
    public class TicTacToeSuperGridViewModel : ObservableObject
    {
        private ITicTacToeSuperGrid superGrid;

        public string[,,,] imageGrid = new string[3, 3, 3, 3];
        public Brush[,] backgroundGrid = new Brush[3, 3];

        public TicTacToeSuperGridViewModel(ITicTacToeSuperGrid superGrid)
        {
            InitViewModel(superGrid);
        }

        public TicTacToeSuperGridViewModel()
        {
            InitViewModel(new TicTacToeSuperGrid());
        }

        private void InitViewModel(ITicTacToeSuperGrid superGrid)
        {
            this.superGrid = superGrid;
            ButtonClick = new RelayCommand((x) => OnButtonClick(x));

            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    backgroundGrid[i, j] = Brushes.Blue;
        }

        #region Image Grid Properties

        public string ImgSrc0000 { get => imageGrid[0, 0, 0, 0]; set { imageGrid[0, 0, 0, 0] = value; OnPropertyChanged("ImgSrc0000"); } }
        public string ImgSrc1000 { get => imageGrid[0, 0, 1, 0]; set { imageGrid[0, 0, 1, 0] = value; OnPropertyChanged("ImgSrc1000"); } }
        public string ImgSrc2000 { get => imageGrid[0, 0, 2, 0]; set { imageGrid[0, 0, 2, 0] = value; OnPropertyChanged("ImgSrc2000"); } }
        public string ImgSrc0100 { get => imageGrid[0, 0, 0, 1]; set { imageGrid[0, 0, 0, 1] = value; OnPropertyChanged("ImgSrc0100"); } }
        public string ImgSrc1100 { get => imageGrid[0, 0, 1, 1]; set { imageGrid[0, 0, 1, 1] = value; OnPropertyChanged("ImgSrc1100"); } }
        public string ImgSrc2100 { get => imageGrid[0, 0, 2, 1]; set { imageGrid[0, 0, 2, 1] = value; OnPropertyChanged("ImgSrc2100"); } }
        public string ImgSrc0200 { get => imageGrid[0, 0, 0, 2]; set { imageGrid[0, 0, 0, 2] = value; OnPropertyChanged("ImgSrc0200"); } }
        public string ImgSrc1200 { get => imageGrid[0, 0, 1, 2]; set { imageGrid[0, 0, 1, 2] = value; OnPropertyChanged("ImgSrc1200"); } }
        public string ImgSrc2200 { get => imageGrid[0, 0, 2, 2]; set { imageGrid[0, 0, 2, 2] = value; OnPropertyChanged("ImgSrc2200"); } }

        public string ImgSrc0001 { get => imageGrid[0, 1, 0, 0]; set { imageGrid[0, 1, 0, 0] = value; OnPropertyChanged("ImgSrc0001"); } }
        public string ImgSrc1001 { get => imageGrid[0, 1, 1, 0]; set { imageGrid[0, 1, 1, 0] = value; OnPropertyChanged("ImgSrc1001"); } }
        public string ImgSrc2001 { get => imageGrid[0, 1, 2, 0]; set { imageGrid[0, 1, 2, 0] = value; OnPropertyChanged("ImgSrc2001"); } }
        public string ImgSrc0101 { get => imageGrid[0, 1, 0, 1]; set { imageGrid[0, 1, 0, 1] = value; OnPropertyChanged("ImgSrc0101"); } }
        public string ImgSrc1101 { get => imageGrid[0, 1, 1, 1]; set { imageGrid[0, 1, 1, 1] = value; OnPropertyChanged("ImgSrc1101"); } }
        public string ImgSrc2101 { get => imageGrid[0, 1, 2, 1]; set { imageGrid[0, 1, 2, 1] = value; OnPropertyChanged("ImgSrc2101"); } }
        public string ImgSrc0201 { get => imageGrid[0, 1, 0, 2]; set { imageGrid[0, 1, 0, 2] = value; OnPropertyChanged("ImgSrc0201"); } }
        public string ImgSrc1201 { get => imageGrid[0, 1, 1, 2]; set { imageGrid[0, 1, 1, 2] = value; OnPropertyChanged("ImgSrc1201"); } }
        public string ImgSrc2201 { get => imageGrid[0, 1, 2, 2]; set { imageGrid[0, 1, 2, 2] = value; OnPropertyChanged("ImgSrc2201"); } }

        public string ImgSrc0002 { get => imageGrid[0, 2, 0, 0]; set { imageGrid[0, 2, 0, 0] = value; OnPropertyChanged("ImgSrc0002"); } }
        public string ImgSrc1002 { get => imageGrid[0, 2, 1, 0]; set { imageGrid[0, 2, 1, 0] = value; OnPropertyChanged("ImgSrc1002"); } }
        public string ImgSrc2002 { get => imageGrid[0, 2, 2, 0]; set { imageGrid[0, 2, 2, 0] = value; OnPropertyChanged("ImgSrc2002"); } }
        public string ImgSrc0102 { get => imageGrid[0, 2, 0, 1]; set { imageGrid[0, 2, 0, 1] = value; OnPropertyChanged("ImgSrc0102"); } }
        public string ImgSrc1102 { get => imageGrid[0, 2, 1, 1]; set { imageGrid[0, 2, 1, 1] = value; OnPropertyChanged("ImgSrc1102"); } }
        public string ImgSrc2102 { get => imageGrid[0, 2, 2, 1]; set { imageGrid[0, 2, 2, 1] = value; OnPropertyChanged("ImgSrc2102"); } }
        public string ImgSrc0202 { get => imageGrid[0, 2, 0, 2]; set { imageGrid[0, 2, 0, 2] = value; OnPropertyChanged("ImgSrc0202"); } }
        public string ImgSrc1202 { get => imageGrid[0, 2, 1, 2]; set { imageGrid[0, 2, 1, 2] = value; OnPropertyChanged("ImgSrc1202"); } }
        public string ImgSrc2202 { get => imageGrid[0, 2, 2, 2]; set { imageGrid[0, 2, 2, 2] = value; OnPropertyChanged("ImgSrc2202"); } }

        public string ImgSrc0010 { get => imageGrid[1, 0, 0, 0]; set { imageGrid[1, 0, 0, 0] = value; OnPropertyChanged("ImgSrc0010"); } }
        public string ImgSrc1010 { get => imageGrid[1, 0, 1, 0]; set { imageGrid[1, 0, 1, 0] = value; OnPropertyChanged("ImgSrc1010"); } }
        public string ImgSrc2010 { get => imageGrid[1, 0, 2, 0]; set { imageGrid[1, 0, 2, 0] = value; OnPropertyChanged("ImgSrc2010"); } }
        public string ImgSrc0110 { get => imageGrid[1, 0, 0, 1]; set { imageGrid[1, 0, 0, 1] = value; OnPropertyChanged("ImgSrc0110"); } }
        public string ImgSrc1110 { get => imageGrid[1, 0, 1, 1]; set { imageGrid[1, 0, 1, 1] = value; OnPropertyChanged("ImgSrc1110"); } }
        public string ImgSrc2110 { get => imageGrid[1, 0, 2, 1]; set { imageGrid[1, 0, 2, 1] = value; OnPropertyChanged("ImgSrc2110"); } }
        public string ImgSrc0210 { get => imageGrid[1, 0, 0, 2]; set { imageGrid[1, 0, 0, 2] = value; OnPropertyChanged("ImgSrc0210"); } }
        public string ImgSrc1210 { get => imageGrid[1, 0, 1, 2]; set { imageGrid[1, 0, 1, 2] = value; OnPropertyChanged("ImgSrc1210"); } }
        public string ImgSrc2210 { get => imageGrid[1, 0, 2, 2]; set { imageGrid[1, 0, 2, 2] = value; OnPropertyChanged("ImgSrc2210"); } }

        public string ImgSrc0011 { get => imageGrid[1, 1, 0, 0]; set { imageGrid[1, 1, 0, 0] = value; OnPropertyChanged("ImgSrc0011"); } }
        public string ImgSrc1011 { get => imageGrid[1, 1, 1, 0]; set { imageGrid[1, 1, 1, 0] = value; OnPropertyChanged("ImgSrc1011"); } }
        public string ImgSrc2011 { get => imageGrid[1, 1, 2, 0]; set { imageGrid[1, 1, 2, 0] = value; OnPropertyChanged("ImgSrc2011"); } }
        public string ImgSrc0111 { get => imageGrid[1, 1, 0, 1]; set { imageGrid[1, 1, 0, 1] = value; OnPropertyChanged("ImgSrc0111"); } }
        public string ImgSrc1111 { get => imageGrid[1, 1, 1, 1]; set { imageGrid[1, 1, 1, 1] = value; OnPropertyChanged("ImgSrc1111"); } }
        public string ImgSrc2111 { get => imageGrid[1, 1, 2, 1]; set { imageGrid[1, 1, 2, 1] = value; OnPropertyChanged("ImgSrc2111"); } }
        public string ImgSrc0211 { get => imageGrid[1, 1, 0, 2]; set { imageGrid[1, 1, 0, 2] = value; OnPropertyChanged("ImgSrc0211"); } }
        public string ImgSrc1211 { get => imageGrid[1, 1, 1, 2]; set { imageGrid[1, 1, 1, 2] = value; OnPropertyChanged("ImgSrc1211"); } }
        public string ImgSrc2211 { get => imageGrid[1, 1, 2, 2]; set { imageGrid[1, 1, 2, 2] = value; OnPropertyChanged("ImgSrc2211"); } }

        public string ImgSrc0012 { get => imageGrid[1, 2, 0, 0]; set { imageGrid[1, 2, 0, 0] = value; OnPropertyChanged("ImgSrc0012"); } }
        public string ImgSrc1012 { get => imageGrid[1, 2, 1, 0]; set { imageGrid[1, 2, 1, 0] = value; OnPropertyChanged("ImgSrc1012"); } }
        public string ImgSrc2012 { get => imageGrid[1, 2, 2, 0]; set { imageGrid[1, 2, 2, 0] = value; OnPropertyChanged("ImgSrc2012"); } }
        public string ImgSrc0112 { get => imageGrid[1, 2, 0, 1]; set { imageGrid[1, 2, 0, 1] = value; OnPropertyChanged("ImgSrc0112"); } }
        public string ImgSrc1112 { get => imageGrid[1, 2, 1, 1]; set { imageGrid[1, 2, 1, 1] = value; OnPropertyChanged("ImgSrc1112"); } }
        public string ImgSrc2112 { get => imageGrid[1, 2, 2, 1]; set { imageGrid[1, 2, 2, 1] = value; OnPropertyChanged("ImgSrc2112"); } }
        public string ImgSrc0212 { get => imageGrid[1, 2, 0, 2]; set { imageGrid[1, 2, 0, 2] = value; OnPropertyChanged("ImgSrc0212"); } }
        public string ImgSrc1212 { get => imageGrid[1, 2, 1, 2]; set { imageGrid[1, 2, 1, 2] = value; OnPropertyChanged("ImgSrc1212"); } }
        public string ImgSrc2212 { get => imageGrid[1, 2, 2, 2]; set { imageGrid[1, 2, 2, 2] = value; OnPropertyChanged("ImgSrc2212"); } }

        public string ImgSrc0020 { get => imageGrid[2, 0, 0, 0]; set { imageGrid[2, 0, 0, 0] = value; OnPropertyChanged("ImgSrc0020"); } }
        public string ImgSrc1020 { get => imageGrid[2, 0, 1, 0]; set { imageGrid[2, 0, 1, 0] = value; OnPropertyChanged("ImgSrc1020"); } }
        public string ImgSrc2020 { get => imageGrid[2, 0, 2, 0]; set { imageGrid[2, 0, 2, 0] = value; OnPropertyChanged("ImgSrc2020"); } }
        public string ImgSrc0120 { get => imageGrid[2, 0, 0, 1]; set { imageGrid[2, 0, 0, 1] = value; OnPropertyChanged("ImgSrc0120"); } }
        public string ImgSrc1120 { get => imageGrid[2, 0, 1, 1]; set { imageGrid[2, 0, 1, 1] = value; OnPropertyChanged("ImgSrc1120"); } }
        public string ImgSrc2120 { get => imageGrid[2, 0, 2, 1]; set { imageGrid[2, 0, 2, 1] = value; OnPropertyChanged("ImgSrc2120"); } }
        public string ImgSrc0220 { get => imageGrid[2, 0, 0, 2]; set { imageGrid[2, 0, 0, 2] = value; OnPropertyChanged("ImgSrc0220"); } }
        public string ImgSrc1220 { get => imageGrid[2, 0, 1, 2]; set { imageGrid[2, 0, 1, 2] = value; OnPropertyChanged("ImgSrc1220"); } }
        public string ImgSrc2220 { get => imageGrid[2, 0, 2, 2]; set { imageGrid[2, 0, 2, 2] = value; OnPropertyChanged("ImgSrc2220"); } }

        public string ImgSrc0021 { get => imageGrid[2, 1, 0, 0]; set { imageGrid[2, 1, 0, 0] = value; OnPropertyChanged("ImgSrc0021"); } }
        public string ImgSrc1021 { get => imageGrid[2, 1, 1, 0]; set { imageGrid[2, 1, 1, 0] = value; OnPropertyChanged("ImgSrc1021"); } }
        public string ImgSrc2021 { get => imageGrid[2, 1, 2, 0]; set { imageGrid[2, 1, 2, 0] = value; OnPropertyChanged("ImgSrc2021"); } }
        public string ImgSrc0121 { get => imageGrid[2, 1, 0, 1]; set { imageGrid[2, 1, 0, 1] = value; OnPropertyChanged("ImgSrc0121"); } }
        public string ImgSrc1121 { get => imageGrid[2, 1, 1, 1]; set { imageGrid[2, 1, 1, 1] = value; OnPropertyChanged("ImgSrc1121"); } }
        public string ImgSrc2121 { get => imageGrid[2, 1, 2, 1]; set { imageGrid[2, 1, 2, 1] = value; OnPropertyChanged("ImgSrc2121"); } }
        public string ImgSrc0221 { get => imageGrid[2, 1, 0, 2]; set { imageGrid[2, 1, 0, 2] = value; OnPropertyChanged("ImgSrc0221"); } }
        public string ImgSrc1221 { get => imageGrid[2, 1, 1, 2]; set { imageGrid[2, 1, 1, 2] = value; OnPropertyChanged("ImgSrc1221"); } }
        public string ImgSrc2221 { get => imageGrid[2, 1, 2, 2]; set { imageGrid[2, 1, 2, 2] = value; OnPropertyChanged("ImgSrc2221"); } }

        public string ImgSrc0022 { get => imageGrid[2, 2, 0, 0]; set { imageGrid[2, 2, 0, 0] = value; OnPropertyChanged("ImgSrc0022"); } }
        public string ImgSrc1022 { get => imageGrid[2, 2, 1, 0]; set { imageGrid[2, 2, 1, 0] = value; OnPropertyChanged("ImgSrc1022"); } }
        public string ImgSrc2022 { get => imageGrid[2, 2, 2, 0]; set { imageGrid[2, 2, 2, 0] = value; OnPropertyChanged("ImgSrc2022"); } }
        public string ImgSrc0122 { get => imageGrid[2, 2, 0, 1]; set { imageGrid[2, 2, 0, 1] = value; OnPropertyChanged("ImgSrc0122"); } }
        public string ImgSrc1122 { get => imageGrid[2, 2, 1, 1]; set { imageGrid[2, 2, 1, 1] = value; OnPropertyChanged("ImgSrc1122"); } }
        public string ImgSrc2122 { get => imageGrid[2, 2, 2, 1]; set { imageGrid[2, 2, 2, 1] = value; OnPropertyChanged("ImgSrc2122"); } }
        public string ImgSrc0222 { get => imageGrid[2, 2, 0, 2]; set { imageGrid[2, 2, 0, 2] = value; OnPropertyChanged("ImgSrc0222"); } }
        public string ImgSrc1222 { get => imageGrid[2, 2, 1, 2]; set { imageGrid[2, 2, 1, 2] = value; OnPropertyChanged("ImgSrc1222"); } }
        public string ImgSrc2222 { get => imageGrid[2, 2, 2, 2]; set { imageGrid[2, 2, 2, 2] = value; OnPropertyChanged("ImgSrc2222"); } }

        #endregion

        #region Subgrid background color properties
        public Brush BrushSource00 { get { return backgroundGrid[0, 0]; } set { backgroundGrid[0, 0] = value; OnPropertyChanged("BrushSource00"); } }
        public Brush BrushSource01 { get { return backgroundGrid[0, 1]; } set { backgroundGrid[0, 1] = value; OnPropertyChanged("BrushSource01"); } }
        public Brush BrushSource02 { get { return backgroundGrid[0, 2]; } set { backgroundGrid[0, 2] = value; OnPropertyChanged("BrushSource02"); } }
        public Brush BrushSource10 { get { return backgroundGrid[1, 0]; } set { backgroundGrid[1, 0] = value; OnPropertyChanged("BrushSource10"); } }
        public Brush BrushSource11 { get { return backgroundGrid[1, 1]; } set { backgroundGrid[1, 1] = value; OnPropertyChanged("BrushSource11"); } }
        public Brush BrushSource12 { get { return backgroundGrid[1, 2]; } set { backgroundGrid[1, 2] = value; OnPropertyChanged("BrushSource12"); } }
        public Brush BrushSource20 { get { return backgroundGrid[2, 0]; } set { backgroundGrid[2, 0] = value; OnPropertyChanged("BrushSource20"); } }
        public Brush BrushSource21 { get { return backgroundGrid[2, 1]; } set { backgroundGrid[2, 1] = value; OnPropertyChanged("BrushSource21"); } }
        public Brush BrushSource22 { get { return backgroundGrid[2, 1]; } set { backgroundGrid[2, 1] = value; OnPropertyChanged("BrushSource22"); } }
        #endregion

        /// <summary>
        /// Command bound to button clicks.  Must pass in int[] parameter.
        /// </summary>
        public ICommand ButtonClick { get; private set; }

        private void OnButtonClick(object sender)
        {
            string name = sender.GetType().GetProperty("Name").GetValue(sender) as string;
            int MoveX = name[4] - '0';
            int MoveY = name[3] - '0';
            int MoveXGrid = name[6] - '0';
            int MoveYGrid = name[5] - '0';

            try
            {
                string imageFilePath = FilePaths.GetFilePath(superGrid.WhoseTurn);

                superGrid.ClaimCell(MoveXGrid, MoveYGrid, MoveX, MoveY);

                string cellPropertyName = string.Format("ImgSrc{0}{1}{2}{3}", MoveX, MoveY, MoveYGrid, MoveXGrid);
                
                PropertyInfo cellProperty = this.GetType().GetProperty(cellPropertyName);
                cellProperty.SetValue(this, imageFilePath);

                Brush colorAll = superGrid.NextMoveX < 0 ? Brushes.Green : Brushes.Red;
                for(int i = 0; i < 3; ++i)
                {
                    for(int j = 0; j < 3; ++j)
                    {
                        string gridPropertyName = string.Format("BrushSource{0}{1}", j, i);

                        if (superGrid.CheckGridStatus(i, j) != TicTacToeGridStatus.Contested)
                            GetType().GetProperty(gridPropertyName).SetValue(this, Brushes.Gold);
                        else if(i == superGrid.NextMoveX && j == superGrid.NextMoveY)
                            GetType().GetProperty(gridPropertyName).SetValue(this, Brushes.Green);
                        else
                            GetType().GetProperty(gridPropertyName).SetValue(this, colorAll);
                    }
                }
            }
            catch (TicTacToeException)
            {
                //do nothing
            }
        }

        
    }
}
