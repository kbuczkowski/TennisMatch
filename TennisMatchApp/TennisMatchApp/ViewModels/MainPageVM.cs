using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using TennisMatchApp.Views;
using TennisMatchApp.Models;

namespace TennisMatchApp.ViewModels
{
    class MainPageVM : BaseVM
    {
        bool _isRefreshing;
        Match _selectedItem;
        List<Match> _matches;
        public Command New_Match_Clicked { get; set; }
        public Command Delete_Match_Clicked { get; set; }
        public Command Refresh { get; set; }
        public MainPageVM()
        {
            New_Match_Clicked = new Command(NewMatch);
            Delete_Match_Clicked = new Command<Match>(DeleteMatch);
            Refresh = new Command(RefreshMatches);
        }
        public Match SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;

                if (_selectedItem == null)
                    return;

                Match m = _selectedItem;

                SelectedItem = null;

                OnPropertyChanged(nameof(SelectedItem));

                App.currentMatch = m;
                try
                {
                    if(m.AdvancedStats)
                        App.Current.MainPage.Navigation.PushAsync(new AdvancedMatchPageTabbed());
                    else
                        App.Current.MainPage.Navigation.PushAsync(new BasicMatchPage());
                }
                catch
                {
                    App.Current.MainPage.DisplayAlert("FAILED", "That match looks not compatible :(", "OK");
                }
            }
        }
        public List<Match> Matches
        {
            get
            {
                return _matches;
            }
        }
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }
        void NewMatch(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new NewMatchPage());
        }
        async void DeleteMatch(Match obj)
        {
            bool decision = await App.Current.MainPage.DisplayAlert("Delete this match?", "This cannot be undone.", "Yes", "No");
            if (decision) {
                using (var conn = new SQLite.SQLiteConnection(App.file_path))
                {
                    conn.Delete((Match)obj);

                    RefreshMatches();
                }
            }
        }
        void RefreshMatches()
        {
            IsRefreshing = true;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.file_path))
            {
                conn.CreateTable<Match>();

                _matches = conn.Table<Match>().ToList();
                OnPropertyChanged(nameof(Matches));
            }

            IsRefreshing = false;
        }
    }
}
