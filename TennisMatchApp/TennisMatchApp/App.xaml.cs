using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TennisMatchApp
{
    public partial class App : Application
    {
        public string file_path = string.Empty;
        public static ObservableCollection<Match> matches = new ObservableCollection<Match>();
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            //do testow
            MainPage = new NavigationPage(new MatchPage());
        }
        public App(string p_file_path)
        {
            InitializeComponent();

            file_path = p_file_path;

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
