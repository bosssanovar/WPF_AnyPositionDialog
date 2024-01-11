using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
using WpfLibrary1;

namespace WpfApp1
{
    /// <summary>
    /// PopupEditBox.xaml の相互作用ロジック
    /// </summary>
    public partial class PopupEditBox : UserControl
    {
        private PopupView? _PopupView;

        public event Action<string>? Applied;

        public PopupEditBox(string initVal)
        {
            InitializeComponent();

            textBox.Text = initVal;
        }

        private void SelectAll()
        {
            textBox.Focus();
            textBox.SelectAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();

            Applied?.Invoke(textBox.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Open()
        {
            _PopupView = new PopupView(this);
            _PopupView?.Open();

            SelectAll();
        }

        private void Close()
        {
            _PopupView?.Close();

            _PopupView = null;
        }
    }
}
