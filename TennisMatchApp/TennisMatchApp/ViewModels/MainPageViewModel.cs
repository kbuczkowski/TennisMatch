using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace TennisMatchApp.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        Match _selectedItem;
        List<Match> _matches;
        public Command New_Match_Clicked { get; set; }
        public Command Delete_Match_Clicked { get; set; }
        public MainPageViewModel()
        {
            New_Match_Clicked = new Command(NewMatch);
            Delete_Match_Clicked = new Command<Match>(DeleteMatch);
            //_matches.Add(new Match("ETtdg", "gdfg", 3, 6, 7, true, true, true));//nie dziala sqlite / dodac jakis mecz zobaczyc jak bedzie
            RefreshMatches();
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

                OpenMatch(m);
            }
        }
        public List<Match> Matches
        {
            get
            {
                return _matches;
            }
        }
        public string X
        {
            get;
            set;
        }
        void OpenMatch(Match m)
        {
            App.Current.MainPage.Navigation.PushAsync(new MatchPage(m));
        }
        void NewMatch(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new NewMatchPage());
        }
        async void DeleteMatch(Match obj)
        {
            bool decision = await App.Current.MainPage.DisplayAlert("Delete this match?", "This cannot be undone.", "Yes", "No");
            if (decision)
                App.matches.Remove((Match)obj);
        }
        void RefreshMatches()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.file_path))
            {
                conn.CreateTable<Match>();

                _matches = conn.Table<Match>().ToList();
                OnPropertyChanged(nameof(Matches));

                X = Matches[3].P1_Name;
                OnPropertyChanged(nameof(X));
            }
        }
    }
}
