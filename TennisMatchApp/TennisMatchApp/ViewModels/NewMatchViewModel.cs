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
        private int _setsToWin = 2, _gamesToWin = 6, _pointsToWinTieBreak = 7;
        private bool _firstPlayerToServe = true, _advantagePlay = true, _advancedStats = false;
        private string _p1_Name, _p2_Name;

        public event PropertyChangedEventHandler PropertyChanged;
        INavigation Navigation;
        Page page;
        public ICommand Sets_Plus_Clicked { get; set; }
        public ICommand Sets_Minus_Clicked { get; set; }
        public ICommand Games_Plus_Clicked { get; set; }
        public ICommand Games_Minus_Clicked { get; set; }
        public ICommand TieBreak_Plus_Clicked { get; set; }
        public ICommand TieBreak_Minus_Clicked { get; set; }
        public ICommand P1_To_Serve_Clicked { get; set; }
        public ICommand P2_To_Serve_Clicked { get; set; }
        public ICommand Create_Match_Clicked { get; set; }

        public NewMatchViewModel(INavigation p_Navigation, Page p_page)
        {
            this.Navigation = p_Navigation;
            this.page = p_page;

            Sets_Plus_Clicked = new Command(Sets_Plus);
            Sets_Minus_Clicked = new Command(Sets_Minus);
            Games_Plus_Clicked = new Command(Games_Plus);
            Games_Minus_Clicked = new Command(Games_Minus);
            TieBreak_Plus_Clicked = new Command(TieBreak_Plus);
            TieBreak_Minus_Clicked = new Command(TieBreak_Minus);
            P1_To_Serve_Clicked = new Command(P1_To_Serve);
            P2_To_Serve_Clicked = new Command(P2_To_Serve);
            Create_Match_Clicked = new Command(Create_Match);
        }

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public string P1_Name
        {
            get
            {
                return _p1_Name;
            }
            set
            {
                _p1_Name = value;
                OnPropertyChanged(nameof(P1_Name));
            }
        }
        public string P2_Name
        {
            get
            {
                return _p2_Name;
            }
            set
            {
                _p2_Name = value;
                OnPropertyChanged(nameof(P2_Name));
            }
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
        public string PointsToWinTieBreak
        {
            get
            {
                return _pointsToWinTieBreak.ToString();
            }
            set
            {
                _pointsToWinTieBreak = Int32.Parse(value);
                OnPropertyChanged(nameof(PointsToWinTieBreak));
            }
        }
        public bool AdvantagePlay
        {
            get
            {
                return _advantagePlay;
            }
            set
            {
                _advantagePlay = value;
                OnPropertyChanged(nameof(AdvantagePlay));
            }
        }
        public bool AdvancedStats
        {
            get
            {
                return _advancedStats;
            }
            set
            {
                _advancedStats = value;
                OnPropertyChanged(nameof(AdvancedStats));
            }
        }
        void Sets_Plus(object obj)
        {
            if (_setsToWin < 3)
            {
                SetsToWin = (_setsToWin + 1).ToString();
            }
        }
        void Sets_Minus(object obj)
        {
            if(_setsToWin > 1)
            {
                SetsToWin = (_setsToWin - 1).ToString();
            }
        }
        void Games_Plus(object obj)
        {
            if(_gamesToWin < 16)
            {
                GamesToWin = (_gamesToWin + 1).ToString();
            }
        }
        void Games_Minus(object obj)
        {
            if(_gamesToWin > 2)
            {
                GamesToWin = (_gamesToWin - 1).ToString();
            }
        }
        void TieBreak_Plus(object obj)
        {
            if (_pointsToWinTieBreak < 16)
            {
                PointsToWinTieBreak = (_pointsToWinTieBreak + 1).ToString();
            }
        }
        void TieBreak_Minus(object obj)
        {
            if (_pointsToWinTieBreak > 7)
            {
                PointsToWinTieBreak = (_pointsToWinTieBreak - 1).ToString();
            }
        }
        void P1_To_Serve(object obj)
        {
            _firstPlayerToServe = true;
        }
        void P2_To_Serve(object obj)
        {
            _firstPlayerToServe = false;
        }
        void Create_Match(object obj)
        {
            if (!String.IsNullOrEmpty(P1_Name) && !String.IsNullOrEmpty(P2_Name))
            {
                App.matches.Add(new Match(_p1_Name, _p2_Name, _setsToWin, _gamesToWin, _pointsToWinTieBreak, _advantagePlay, _firstPlayerToServe, _advancedStats));
                Navigation.PopAsync();
                Navigation.PushAsync(new MatchPage());
            }
            else
            {
                page.DisplayAlert("Error", "Player's names cannot be empty.", "Ok");
            }
        }
    }
}
