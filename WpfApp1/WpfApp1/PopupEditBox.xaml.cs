using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// PopupEditBox.xaml の相互作用ロジック
    /// </summary>
    public partial class PopupEditBox : UserControl
    {
        public event Action? OkPressed;
        public event Action? CancelPressed;

        public string Text
        {
            get
            {
                return textBox.Text;
            }
            set
            {
                textBox.Text = value;
            }
        }

        public PopupEditBox()
        {
            InitializeComponent();
        }

        public void SelectAll()
        {
            textBox.Focus();
            textBox.SelectAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OkPressed?.Invoke();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CancelPressed?.Invoke();
        }
    }
}
