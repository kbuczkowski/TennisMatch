using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TennisMatchApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchPage : ContentPage
    {
        public MatchPage()
        {
            Match m = new Match("Kacper", "Angelika", 3, 6, 7, true, true, true);
            BindingContext = new MatchPageViewModel(this, m);
            InitializeComponent();
        }
    }
}