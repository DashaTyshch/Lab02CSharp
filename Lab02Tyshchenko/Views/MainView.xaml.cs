using Lab02Tyshchenko.Model;
using Lab02Tyshchenko.ViewModel;
using System.Windows.Controls;

namespace Lab02Tyshchenko.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView(Storage storage)
        {
            InitializeComponent();
            MainViewModel viewModel = new MainViewModel(storage);
            DataContext = viewModel;
        }
    }
}
