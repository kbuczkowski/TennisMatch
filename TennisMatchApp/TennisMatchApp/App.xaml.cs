using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Sharpnado.MaterialFrame;
using SQLite;

namespace TennisMatchApp
{
    public partial class App : Application
    {
        public static string file_path = string.Empty;
        public static List<Match> matches = new List<Match>();
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
