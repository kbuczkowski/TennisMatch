using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TennisMatchApp
{
    class NewMatchViewModel : INotifyPropertyChanged
    {
        private int _setsToWin = 2, _gamesToWin = 6;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Sets_Plus_Clicked { get; set; }
        public ICommand Sets_Minus_Clicked { get; set; }
        public ICommand Games_Plus_Clicked { get; set; }
        public ICommand Games_Minus_Clicked { get; set; }

        public NewMatchViewModel()
        {
            Sets_Plus_Clicked = new Command(Sets_Plus);
            Sets_Minus_Clicked = new Command(Sets_Minus);
            Games_Plus_Clicked = new Command(Games_Plus);
            Games_Minus_Clicked = new Command(Games_Minus);
        }

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string SetsToWin
        {
            get
            {
                return _setsToWin.ToString();
            }
            set
            {
                _setsToWin = Int32.Parse(value);
                OnPropertyChanged(nameof(SetsToWin));
            }
        }

        public string GamesToWin
        {
            get
            {
                return _gamesToWin.ToString();
            }
            set
            {
                _gamesToWin = Int32.Parse(value);
                OnPropertyChanged(nameof(GamesToWin));
            }
        }

        void Sets_Plus(object obj)
        {
            if (_setsToWin < 3)
            {
                SetsToWin = (Int32.Parse(SetsToWin) + 1).ToString();
            }
        }
        void Sets_Minus(object obj)
        {
            if(_setsToWin > 1)
            {
                SetsToWin = (Int32.Parse(SetsToWin) - 1).ToString();
            }
        }
        void Games_Plus(object obj)
        {
            if(_gamesToWin < 16)
            {
                GamesToWin = (Int32.Parse(GamesToWin) + 1).ToString();
            }
        }
        void Games_Minus(object obj)
        {
            if(_gamesToWin > 2)
            {
                GamesToWin = (Int32.Parse(GamesToWin) - 1).ToString();
            }
        }
    }
}
