﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TennisMatchApp.ViewModels
{
    class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
