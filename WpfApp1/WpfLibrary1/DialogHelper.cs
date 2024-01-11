using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp1
{
    public class DialogHelper
    {
        public static void ShowDialogOnTarget(Window window, Button target, Window subWindow)
        {
            Point locationFromScreen = target.PointToScreen(new Point(0, 0));
            PresentationSource source = PresentationSource.FromVisual(window);
            Point targetPoints = source.CompositionTarget.TransformFromDevice.Transform(locationFromScreen);

            subWindow.Owner = window;
            subWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            subWindow.Top = targetPoints.Y;
            subWindow.Left = targetPoints.X;

            subWindow.ShowDialog();
        }
    }
}
