using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfLibrary1;

namespace WpfApp1
{
    public class Detail
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        private RelayCommand? _myCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand MyCommand
        {
            get
            {
                return _myCommand
                    ?? (_myCommand = new RelayCommand(
                    () =>
                    {
                        var content = new PopupEditBox { Text = "WWWWWWWWW" };
                        var popup = new PopupView(content);

                        content.OkPressed += Content_OkPressed;
                        void Content_OkPressed()
                        {
                            Close();
                        }

                        content.CancelPressed += Content_CancelPressed;
                        void Content_CancelPressed()
                        {
                            Close();
                        }

                        void Close()
                        {
                            popup.Close();

                            content.OkPressed -= Content_OkPressed;
                            content.CancelPressed -= Content_CancelPressed;
                        }

                        popup.Open();

                        content.SelectAll();
                    }));
            }
        }
    }

    public class RelayCommand(Action action) : ICommand
    {

        #region ICommandインターフェースの必須実装

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {//とりあえずActionがあれば実行可能
            return action != null;
        }

        public void Execute(object? parameter)
        {//今回は引数を使わずActionを実行
            action();
        }

        #endregion
    }
}
