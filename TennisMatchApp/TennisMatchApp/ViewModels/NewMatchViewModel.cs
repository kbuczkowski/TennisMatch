﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TennisMatchApp.ViewModels;
using Xamarin.Forms;

namespace TennisMatchApp
{
    class NewMatchViewModel : BaseViewModel
    {
        private int _setsToWin = 2, _gamesToWin = 6, _pointsToWinTieBreak = 7;
        private bool _firstPlayerToServe = true, _advantagePlay = true, _advancedStats = false;
        private string _p1_Name, _p2_Name;

        INavigation Navigation;
        Page page;
        public Command Sets_Plus_Clicked { get; set; }
        public Command Sets_Minus_Clicked { get; set; }
        public Command Games_Plus_Clicked { get; set; }
        public Command Games_Minus_Clicked { get; set; }
        public Command TieBreak_Plus_Clicked { get; set; }
        public Command TieBreak_Minus_Clicked { get; set; }
        public Command P1_To_Serve_Clicked { get; set; }
        public Command P2_To_Serve_Clicked { get; set; }
        public Command Create_Match_Clicked { get; set; }

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
            Create_Match_Clicked = new Command(Create_Match, Can_Create_Match);
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
                Create_Match_Clicked.ChangeCanExecute();
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
                Create_Match_Clicked.ChangeCanExecute();
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
            if (_setsToWin > 1)
            {
                SetsToWin = (_setsToWin - 1).ToString();
            }
        }
        void Games_Plus(object obj)
        {
            if (_gamesToWin < 16)
            {
                GamesToWin = (_gamesToWin + 1).ToString();
            }
        }
        void Games_Minus(object obj)
        {
            if (_gamesToWin > 2)
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
            var m = new Match(_p1_Name, _p2_Name, _setsToWin, _gamesToWin, _pointsToWinTieBreak, _advantagePlay, _firstPlayerToServe, _advancedStats);
            App.matches.Add(m);
            Navigation.PopAsync();
            Navigation.PushAsync(new MatchPage(m));
        }
        bool Can_Create_Match(object obj)
        {
            return (!String.IsNullOrEmpty(P1_Name) && !String.IsNullOrEmpty(P2_Name));
        }
    }
}
