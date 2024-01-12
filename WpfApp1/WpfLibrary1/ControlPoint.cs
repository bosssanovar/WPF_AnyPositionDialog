using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace WpfLibrary1
{
    public class ControlPoint
    {
        public static Point GetPoint(DataGrid control)
        {
            var col = control.SelectedCells[0].Column.DisplayIndex;
            var row = control.Items.IndexOf(control.SelectedCells[0].Item);

            var cell = GetCell(control, row, col);
            return cell.PointToScreen(new Point(0.0d, 0.0d));
        }

        private static T GetChildOfType<T>(DependencyObject depObj)
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
        private static DataGridCell GetCell(DataGrid dataGrid, int row, int column)
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
    }
}
