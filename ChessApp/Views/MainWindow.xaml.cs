using System.Windows;
using ChessApp.ViewModels;

namespace ChessApp.Views
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private void MoveButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.MoveSelectedPiece();
        }
    }
}