using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp1
{
    internal class DialogHelper
    {
        public static void ShowDialogOnTarget(Window window, Button target)
        {
            // Get absolute location on screen of upper left corner of the UserControl
            Point locationFromScreen = target.PointToScreen(new Point(0, 0));
            // Transform screen point to WPF device independent point
            PresentationSource source = PresentationSource.FromVisual(window);
            Point targetPoints = source.CompositionTarget.TransformFromDevice.Transform(locationFromScreen);
            // Get Focus
            Point focus = new Point();
            focus.X = targetPoints.X;
            focus.Y = targetPoints.Y;
            // Set coordinates
            Window subWindow = new SubWindow
            {
                Owner = window,
                WindowStartupLocation = WindowStartupLocation.Manual,
            };
            subWindow.Top = focus.Y;
            subWindow.Left = focus.X;
            subWindow.ShowDialog();
        }
    }
}
