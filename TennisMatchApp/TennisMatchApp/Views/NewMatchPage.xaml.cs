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
            BindingContext = new NewMatchViewModel();
            InitializeComponent();
        }
    }
}