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
            // Get absolute location on screen of upper left corner of the UserControl
            Point locationFromScreen = button1.PointToScreen(new Point(0, 0));
            // Transform screen point to WPF device independent point
            PresentationSource source = PresentationSource.FromVisual(this);
            Point targetPoints = source.CompositionTarget.TransformFromDevice.Transform(locationFromScreen);
            // Get Focus
            Point focus = new Point();
            focus.X = targetPoints.X;
            focus.Y = targetPoints.Y;
            // Set coordinates
            Window window = new SubWindow
            {
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.Manual,
            };
            window.Top = focus.Y;
            window.Left = focus.X;
            window.ShowDialog();
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
    }
}