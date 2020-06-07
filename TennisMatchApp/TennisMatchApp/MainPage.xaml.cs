using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace TennisMatchApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            matches_list_view.ItemsSource = App.matches;
        }
        private void Add_Match_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewMatchPage());
        }
    }
}
