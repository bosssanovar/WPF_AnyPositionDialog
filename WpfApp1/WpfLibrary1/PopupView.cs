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
        private Popup Popup { get; }

        private UIElement Content { get; }

        private Border Border { get; }

        public PopupView(UIElement content)
        {
            Popup = new Popup
            {
                //IsOpen = false,
                StaysOpen = false,
                AllowsTransparency = true,
                Focusable = true,
                PopupAnimation = PopupAnimation.None,
                Placement = PlacementMode.Mouse,
                VerticalOffset = -20,
                HorizontalOffset = -20,
            };

            Border = new Border
            {
                Background = Brushes.White,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1.0d),
                Padding = new Thickness(5.0d)
            };

            Content = content;

            Popup.Child = Border;
            Border.Child = Content;

            Popup.MouseDown += (sender, args) => Popup.IsOpen = false;
        }

        public void Open()
        {
            Popup.IsOpen = true;

            Content.Focus();
        }
    }
}
