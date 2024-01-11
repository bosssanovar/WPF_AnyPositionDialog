using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfLibrary1;

namespace WpfApp1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogHelper.ShowDialogOnTarget(this, button1, new SubWindow());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window window = new SubWindow
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            window.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            var content = new PopupEditBox { Text = "WWWWWWWWW" };
            var popup = new PopupView(content);

            content.OkPressed += Content_OkPressed;
            void Content_OkPressed()
            {
                Close();
            }

            content.CancelPressed += Content_CancelPressed;
            void Content_CancelPressed()
            {
                Close();
            }

            void Close()
            {
                popup.Close();

                content.OkPressed -= Content_OkPressed;
                content.CancelPressed -= Content_CancelPressed;
            }

            popup.Open();

            content.SelectAll();
        }
    }
}