using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TennisMatchApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMatchPage : ContentPage
    {
        public NewMatchPage()
        {
            InitializeComponent();
        }
        //methods just to handle proper appearance of buttons
        private void P1_To_Serve_Clicked(object sender, EventArgs e)
        {
            b_p1_to_serve.Text = "SERVE";
            b_p1_to_serve.BackgroundColor = Color.GreenYellow;
            b_p2_to_serve.Text = "";
            b_p2_to_serve.BackgroundColor = Color.LightGray;
        }
        private void P2_To_Serve_Clicked(object sender, EventArgs e)
        {
            b_p2_to_serve.Text = "SERVE";
            b_p2_to_serve.BackgroundColor = Color.GreenYellow;
            b_p1_to_serve.Text = "";
            b_p1_to_serve.BackgroundColor = Color.LightGray;
        }
    }
}