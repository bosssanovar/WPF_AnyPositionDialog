using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfLibrary1;

namespace WpfApp1
{
    public class Detail : INotifyPropertyChanged
    {

        /// <summary>Description
        /// 通知イベント
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// プロパティの変更通知を起動する
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _Name = string.Empty;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _Description = string.Empty;
        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _Text = string.Empty;
        public string Text
        {
            get { return _Text; }
            set
            {
                if (_Text != value)
                {
                    _Text = value;
                    NotifyPropertyChanged();
                }
            }
        }

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
                        var content = new PopupEditBox(Name);
                        content.Applied += Content_Applied;
                        content.Open();

                        void Content_Applied(string obj)
                        {
                            Name = obj;
                            content.Applied -= Content_Applied;
                        }
                    }));
            }
        }

        private RelayCommand? _myCommand2;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand MyCommand2
        {
            get
            {
                return _myCommand2
                    ?? (_myCommand2 = new RelayCommand(
                    () =>
                    {
                        var content = new PopupEditBox(Description);
                        content.Applied += Content_Applied;
                        content.Open();

                        void Content_Applied(string obj)
                        {
                            Description = obj;
                            content.Applied -= Content_Applied;
                        }
                    }));
            }
        }

        private RelayCommand? _myCommand3;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand MyCommand3
        {
            get
            {
                return _myCommand3
                    ?? (_myCommand3 = new RelayCommand(
                    () =>
                    {
                        var content = new PopupEditBox(Text);
                        content.Applied += Content_Applied;
                        content.Open();

                        void Content_Applied(string obj)
                        {
                            Text = obj;
                            content.Applied -= Content_Applied;
                        }
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
