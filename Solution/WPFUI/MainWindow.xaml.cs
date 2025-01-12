using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFUI.ViewModels;


namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddItem().Show();
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            new EditItem().Show();
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EquipViewModel();
        }

        private void CompButton_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CompViewModel();
        }
    }
}