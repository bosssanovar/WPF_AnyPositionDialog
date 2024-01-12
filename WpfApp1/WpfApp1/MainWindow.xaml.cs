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

            DetailList.Add(new(GetSelectedCellPoint) { Name = "aaaa", Description = "aaaaaaa", Text = "aaaaaaaa" });
            DetailList.Add(new(GetSelectedCellPoint) { Name = "bbbbbbbbbbbbbbbbbbbbb", Description = "b", Text = "bbb" });
            DetailList.Add(new(GetSelectedCellPoint) { Name = "ccc", Description = "ccccccccc", Text = "c" });
            DetailList.Add(new(GetSelectedCellPoint) { Name = "ddd", Description = "dd", Text = "d" });
            DetailList.Add(new(GetSelectedCellPoint) { Name = "eee", Description = "eeee", Text = "e" });
        }

        private Point GetSelectedCellPoint()
        {
            var col = grid.SelectedCells[0].Column.DisplayIndex;
            var row = grid.Items.IndexOf(grid.SelectedCells[0].Item);

            var cell = GetCell(grid, row, col);
            return cell.PointToScreen(new Point(0.0d, 0.0d)); ;
        }
        private T GetChildOfType<T>(DependencyObject depObj)
                    where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }
        private DataGridCell GetCell(DataGrid dataGrid, int row, int column)
        {
            DataGridRow rowContainer = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(row);
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = GetChildOfType<DataGridCellsPresenter>(rowContainer);
                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                if (cell == null)
                {
                    dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
                    cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                }
                return cell;
            }
            return null;
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