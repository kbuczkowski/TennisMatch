using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TennisMatchApp
{
    class MatchPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Match match;
        Page page;
        public ICommand P1_Point_Clicked { get; set; }
        public ICommand P2_Point_Clicked { get; set; }

        public MatchPageViewModel(Page p_page, Match p_match)
        {
            this.match = p_match;
            this.page = p_page;

            P1_Point_Clicked = new Command(P1_Point, ButtonsEnable);
            
            P2_Point_Clicked = new Command(P2_Point, ButtonsEnable);
        }

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public string P1_Name
        {
            get
            {
                return match.p1_Name;
            }
        }
        public string P2_Name
        {
            get
            {
                return match.p2_Name;
            }
        }
        public string P1_FirstSet
        {
            get
            {
                return match.p1_GamesWon[0].ToString();
            }
            set
            {
                match.p1_GamesWon[0] = Int32.Parse(value);
                OnPropertyChanged(nameof(P1_FirstSet));
            }
        }
        public string P2_FirstSet
        {
            get
            {
                return match.p2_GamesWon[0].ToString();
            }
            set
            {
                match.p2_GamesWon[0] = Int32.Parse(value);
                OnPropertyChanged(nameof(P2_FirstSet));
            }
        }
        public string P1_SecondSet
        {
            get
            {
                return match.p1_GamesWon[1].ToString();
            }
            set
            {
                match.p1_GamesWon[1] = Int32.Parse(value);
                OnPropertyChanged(nameof(P1_SecondSet));
            }
        }
        public string P2_SecondSet
        {
            get
            {
                return match.p2_GamesWon[1].ToString();
            }
            set
            {
                match.p2_GamesWon[1] = Int32.Parse(value);
                OnPropertyChanged(nameof(P2_SecondSet));
            }
        }
        public string P1_ThirdSet
        {
            get
            {
                return match.p1_GamesWon[2].ToString();
            }
            set
            {
                match.p1_GamesWon[2] = Int32.Parse(value);
                OnPropertyChanged(nameof(P1_ThirdSet));
            }
        }
        public string P2_ThirdSet
        {
            get
            {
                return match.p2_GamesWon[2].ToString();
            }
            set
            {
                match.p2_GamesWon[2] = Int32.Parse(value);
                OnPropertyChanged(nameof(P2_ThirdSet));
            }
        }
        public string P1_FourthSet
        {
            get
            {
                return match.p1_GamesWon[3].ToString();
            }
            set
            {
                match.p1_GamesWon[3] = Int32.Parse(value);
                OnPropertyChanged(nameof(P1_FourthSet));
            }
        }
        public string P2_FourthSet
        {
            get
            {
                return match.p2_GamesWon[3].ToString();
            }
            set
            {
                match.p2_GamesWon[3] = Int32.Parse(value);
                OnPropertyChanged(nameof(P2_FourthSet));
            }
        }
        public string P1_FifthSet
        {
            get
            {
                return match.p1_GamesWon[4].ToString();
            }
            set
            {
                match.p1_GamesWon[4] = Int32.Parse(value);
                OnPropertyChanged(nameof(P1_FifthSet));
            }
        }
        public string P2_FifthSet
        {
            get
            {
                return match.p2_GamesWon[4].ToString();
            }
            set
            {
                match.p2_GamesWon[4] = Int32.Parse(value);
                OnPropertyChanged(nameof(P2_FifthSet));
            }
        }
        public string P1_ActualScore
        {
            get
            {
                return match.p1_actualScore.ToString();
            }
            set
            {
                match.p1_actualScore = Int32.Parse(value);
                OnPropertyChanged(nameof(P1_ActualScore));
            }
        }
        public string P2_ActualScore
        {
            get
            {
                return match.p2_actualScore.ToString();
            }
            set
            {
                match.p2_actualScore = Int32.Parse(value);
                OnPropertyChanged(nameof(P2_ActualScore));
            }
        }
        public Set ActualSet
        {
            get
            {
                return match._actualSet;
            }
            set
            {
                match._actualSet = value;
                OnPropertyChanged(nameof(ActualSet));
            }
        }
        public bool MatchEnded
        {
            get 
            {
                return match.matchEnded; 
            }
            set
            {
                match.matchEnded = value;
                OnPropertyChanged(nameof(MatchEnded));
            }
        }
        bool ButtonsEnable(object parameter)
        {
            return !MatchEnded;
        }
        void P1_Point(object obj)
        {
            if (match.p1_actualScore == 0)
                P1_ActualScore = "15";
            else if (match.p1_actualScore == 15)
                P1_ActualScore = "30";
            else if (match.p1_actualScore == 30)
                P1_ActualScore = "40";
            else if (match.p1_actualScore == 40 && match.p2_actualScore < 40)
            {
                P1_ActualScore = "0";
                P2_ActualScore = "0";

                switch (ActualSet)
                {
                    case Set.First:
                        P1_FirstSet = (match.p1_GamesWon[0] + 1).ToString();
                        break;
                    case Set.Second:
                        P1_SecondSet = (match.p1_GamesWon[1] + 1).ToString();
                        break;
                    case Set.Third:
                        P1_ThirdSet = (match.p1_GamesWon[2] + 1).ToString();
                        break;
                    case Set.Fourth:
                        P1_FourthSet = (match.p1_GamesWon[3] + 1).ToString();
                        break;
                    case Set.Fifth:
                        P1_FifthSet = (match.p1_GamesWon[4] + 1).ToString();
                        break;
                }

                if (match.p1_GamesWon[(int)ActualSet] >= 6 && match.p1_GamesWon[(int)ActualSet] >= match.p2_GamesWon[(int)ActualSet] + 2)
                {
                    match.p1_SetsWon++;
                    if(match.p1_SetsWon >= match.setsToWin)
                    {
                        MatchEnded = true;
                    }
                    else
                    {
                        ActualSet = (Set)((int)ActualSet + 1);
                    }
                }
            }
        }
        void P2_Point(object obj)
        {
            if (match.p2_actualScore == 0)
                P2_ActualScore = "15";
            else if (match.p2_actualScore == 15)
                P2_ActualScore = "30";
            else if (match.p2_actualScore == 30)
                P2_ActualScore = "40";
            else if (match.p2_actualScore == 40 && match.p1_actualScore < 40)
            {
                P1_ActualScore = "0";
                P2_ActualScore = "0";

                switch (ActualSet)
                {
                    case Set.First:
                        P2_FirstSet = (match.p2_GamesWon[0] + 1).ToString();
                        break;
                    case Set.Second:
                        P2_SecondSet = (match.p2_GamesWon[1] + 1).ToString();
                        break;
                    case Set.Third:
                        P2_ThirdSet = (match.p2_GamesWon[2] + 1).ToString();
                        break;
                    case Set.Fourth:
                        P2_FourthSet = (match.p2_GamesWon[3] + 1).ToString();
                        break;
                    case Set.Fifth:
                        P2_FifthSet = (match.p2_GamesWon[4] + 1).ToString();
                        break;
                }
                if (match.p2_GamesWon[(int)ActualSet] >= 6 && match.p2_GamesWon[(int)ActualSet] >= match.p1_GamesWon[(int) ActualSet] + 2){
                    match.p2_SetsWon++;
                    if (match.p2_SetsWon >= match.setsToWin)
                    {
                        MatchEnded = true;
                    }
                    else
                    {
                        ActualSet = (Set)((int)ActualSet + 1);
                    }
                }
            }
        }
    }
}
