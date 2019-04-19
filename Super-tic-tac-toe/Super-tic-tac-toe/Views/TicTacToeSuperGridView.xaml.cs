using Super_tic_tac_toe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Super_tic_tac_toe.Views
{
    /// <summary>
    /// Interaction logic for TicTacToeGridView.xaml
    /// </summary>
    public partial class TicTacToeSuperGridView : UserControl
    {
        public TicTacToeSuperGridView()
        {
            InitializeComponent();
            DataContext = new TicTacToeSuperGridViewModel();
        }
    }
}
