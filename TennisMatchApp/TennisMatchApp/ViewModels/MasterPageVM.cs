using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using TennisMatchApp.Views;
using Xamarin.Forms;

namespace TennisMatchApp.ViewModels
{
    class MasterPageVM : BaseVM
    {
        private List<Page> _pages = new List<Page>() { new LeagueTabbedPage(), new MainPage() };
        public List<Page> Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                _pages = value;
                OnPropertyChanged(nameof(Pages));
            }
        }
        private Page _selectedItem;
        public Page SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (value != null)
                {
                    _selectedItem = value;

                    (App.Current.MainPage as MasterDetailPage).Detail = new NavigationPage(SelectedItem) { BarBackgroundColor = Color.FromHex("#007AFF") };
                     
                    SelectedItem = null;

                    if ((App.Current.MainPage as MasterDetailPage).IsPresented)
                        (App.Current.MainPage as MasterDetailPage).SendBackButtonPressed();
                }
                else 
                    _selectedItem = null;

                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public MasterPageVM()
        {

        }
    }
}
