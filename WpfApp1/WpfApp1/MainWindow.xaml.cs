using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Detail> DetailList { get; } = new ObservableCollection<Detail>();

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();

            DetailList.Add(new() { Name = "aaaa", Description = "aaaaaaa", Text = "aaaaaaaa" });
            DetailList.Add(new() { Name = "bbbbbbbbbbbbbbbbbbbbb", Description = "b", Text = "bbb" });
            DetailList.Add(new() { Name = "ccc", Description = "ccccccccc", Text = "c" });
            DetailList.Add(new() { Name = "ddd", Description = "dd", Text = "d" });
            DetailList.Add(new() { Name = "eee", Description = "eeee", Text = "e" });
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
            var content = new PopupEditBox("WWWWWWWWW");
            content.Applied += Content_Applied;
            content.Open();

            void Content_Applied(string obj)
            {
                MessageBox.Show(obj);
                content.Applied -= Content_Applied;
            }
        }
    }
}