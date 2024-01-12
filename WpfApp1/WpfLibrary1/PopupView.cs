using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;

namespace WpfLibrary1
{
    public class PopupView
    {
        private readonly Popup _Popup;

        private readonly UIElement _Content;

        public PopupView(UIElement content)
        {
            _Popup = new Popup
            {
                //IsOpen = false,
                StaysOpen = false,
                AllowsTransparency = true,
                Focusable = true,
                PopupAnimation = PopupAnimation.None,
                Placement = PlacementMode.Mouse,
                VerticalOffset = -35,
                HorizontalOffset = -20,
            };

            var border = new Border
            {
                Background = Brushes.White,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1.0d),
                Padding = new Thickness(5.0d)
            };

            _Content = content;

            _Popup.Child = border;
            border.Child = _Content;

            _Popup.MouseDown += Popup_MouseDown;
        }

        private void Popup_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }

        public void Open()
        {
            _Popup.IsOpen = true;
            _Content.Focus();
        }

        public void Close()
        {
            _Popup.MouseDown -= Popup_MouseDown;
            _Popup.IsOpen = false;
        }
    }
}
