using Lab02Tyshchenko.Model;
using Lab02Tyshchenko.ViewModel;
using System.Windows.Controls;


namespace Lab02Tyshchenko.Views
{
    /// <summary>
    /// Логика взаимодействия для WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : UserControl
    {
        public WelcomeView(Storage storage)
        {
            InitializeComponent();
            WelcomeViewModel viewModel = new WelcomeViewModel(storage);
            DataContext = viewModel;
        }
    }
}
