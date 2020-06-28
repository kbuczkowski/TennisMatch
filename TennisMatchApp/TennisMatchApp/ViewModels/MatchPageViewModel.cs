using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TennisMatchApp.ViewModels;
using Xamarin.Forms;

namespace TennisMatchApp
{
    class MatchPageViewModel : BaseViewModel
    {
        Match match, previousPoint;
        public Command P1_Point_Clicked { get; set; }
        public Command P2_Point_Clicked { get; set; }
        public Command Restore_Point_Clicked { get; set; }
        public Command Navigation_Back { get; set; }
        public MatchPageViewModel()
        {
            match = App.currentMatch;

            P1_Point_Clicked = new Command(P1_Point, ButtonsEnable);
            P2_Point_Clicked = new Command(P2_Point, ButtonsEnable);
            Restore_Point_Clicked = new Command(Restore);
            Navigation_Back = new Command(Nav_Back);
        }
        public string MatchName
        {
            get
            {
                return match.P1_Name + " vs " + match.P2_Name;
            }
        }
        public string P1_Name
        {
            get
            {
                return match.P1_Name;
            }
        }
        public string P2_Name
        {
            get
            {
                return match.P2_Name;
            }
        }
        public string P1_FirstSet
        {
            get
            {
                return match.P1_GamesWon[0].ToString();
            }
            set
            {
                List<int> temp = match.P1_GamesWon;
                temp[0] = Int32.Parse(value);
                match.P1_GamesWon = temp;
                OnPropertyChanged(nameof(P1_FirstSet));
            }
        }
        public string P2_FirstSet
        {
            get
            {
                return match.P2_GamesWon[0].ToString();
            }
            set
            {
                List<int> temp = match.P2_GamesWon;
                temp[0] = Int32.Parse(value);
                match.P2_GamesWon = temp;
                OnPropertyChanged(nameof(P2_FirstSet));
            }
        }
        public string P1_SecondSet
        {
            get
            {
                return match.P1_GamesWon[1].ToString();
            }
            set
            {
                List<int> temp = match.P1_GamesWon;
                temp[1] = Int32.Parse(value);
                match.P1_GamesWon = temp;
                OnPropertyChanged(nameof(P1_SecondSet));
            }
        }
        public string P2_SecondSet
        {
            get
            {
                return match.P2_GamesWon[1].ToString();
            }
            set
            {
                List<int> temp = match.P2_GamesWon;
                temp[1] = Int32.Parse(value);
                match.P2_GamesWon = temp;
                OnPropertyChanged(nameof(P2_SecondSet));
            }
        }
        public string P1_ThirdSet
        {
            get
            {
                return match.P1_GamesWon[2].ToString();
            }
            set
            {
                List<int> temp = match.P1_GamesWon;
                temp[2] = Int32.Parse(value);
                match.P1_GamesWon = temp;
                OnPropertyChanged(nameof(P1_ThirdSet));
            }
        }
        public string P2_ThirdSet
        {
            get
            {
                return match.P2_GamesWon[2].ToString();
            }
            set
            {
                List<int> temp = match.P2_GamesWon;
                temp[2] = Int32.Parse(value);
                match.P2_GamesWon = temp;
                OnPropertyChanged(nameof(P2_ThirdSet));
            }
        }
        public string P1_FourthSet
        {
            get
            {
                return match.P1_GamesWon[3].ToString();
            }
            set
            {
                List<int> temp = match.P1_GamesWon;
                temp[3] = Int32.Parse(value);
                match.P1_GamesWon = temp;
                OnPropertyChanged(nameof(P1_FourthSet));
            }
        }
        public string P2_FourthSet
        {
            get
            {
                return match.P2_GamesWon[3].ToString();
            }
            set
            {
                List<int> temp = match.P2_GamesWon;
                temp[3] = Int32.Parse(value);
                match.P2_GamesWon = temp;
                OnPropertyChanged(nameof(P2_FourthSet));
            }
        }
        public string P1_FifthSet
        {
            get
            {
                return match.P1_GamesWon[4].ToString();
            }
            set
            {
                List<int> temp = match.P1_GamesWon;
                temp[4] = Int32.Parse(value);
                match.P1_GamesWon = temp;
                OnPropertyChanged(nameof(P1_FifthSet));
            }
        }
        public string P2_FifthSet
        {
            get
            {
                return match.P2_GamesWon[4].ToString();
            }
            set
            {
                List<int> temp = match.P2_GamesWon;
                temp[4] = Int32.Parse(value);
                match.P2_GamesWon = temp;
                OnPropertyChanged(nameof(P2_FifthSet));
            }
        }
        public string P1_ActualScore
        {
            get
            {
                if (match.P1_ActualScore == 40 && match.P2_ActualScore == 40)
                {
                    if (match.P1_Advantage)
                        return "Ad";
                    else if (!match.P1_Advantage && !match.P2_Advantage)
                        return match.P1_ActualScore.ToString();
                    else
                        return String.Empty;
                }
                else
                    return match.P1_ActualScore.ToString();
            }
            set
            {
                if (value != "Ad")
                    match.P1_ActualScore = Int32.Parse(value);
                else
                {
                    match.P1_Advantage = true;
                    OnPropertyChanged(nameof(P2_ActualScore));
                }
                OnPropertyChanged(nameof(P1_ActualScore));
            }
        }
        public string P2_ActualScore
        {
            get
            {
                if (match.P2_ActualScore == 40 && match.P1_ActualScore == 40)
                {
                    if (match.P2_Advantage)
                        return "Ad";
                    else if (!match.P2_Advantage && !match.P1_Advantage)
                        return match.P2_ActualScore.ToString();
                    else
                        return String.Empty;
                }
                else
                    return match.P2_ActualScore.ToString();
            }
            set
            {
                if (value != "Ad")
                    match.P2_ActualScore = Int32.Parse(value);
                else
                {
                    match.P2_Advantage = true;
                    OnPropertyChanged(nameof(P1_ActualScore));
                }
                OnPropertyChanged(nameof(P2_ActualScore));
            }
        }
        public string P1_PointsWon
        {
            get
            {
                return match.P1_PointsWon.ToString();
            }
            set
            {
                match.P1_PointsWon = Int32.Parse(value);
                OnPropertyChanged(nameof(P1_PointsWon));
            }
        }
        public string P2_PointsWon
        {
            get
            {
                return match.P2_PointsWon.ToString();
            }
            set
            {
                match.P2_PointsWon = Int32.Parse(value);
                OnPropertyChanged(nameof(P2_PointsWon));
            }
        }
        public string P1_BreakPointsWon
        {
            get
            {
                return match.P1_BreakPointsWon.ToString() + "/" + match.P1_BreakPoints.ToString();
            }
        }
        public string P2_BreakPointsWon
        {
            get
            {
                return match.P2_BreakPointsWon.ToString() + "/" + match.P2_BreakPoints.ToString();
            }
        }
        public int ActualSet
        {
            get
            {
                return match.ActualSet;
            }
            set
            {
                match.ActualSet = value;
                OnPropertyChanged(nameof(ActualSet));
            }
        }
        public bool MatchEnded
        {
            get
            {
                return match.MatchEnded;
            }
            set
            {
                match.MatchEnded = value;
                OnPropertyChanged(nameof(MatchEnded));
            }
        }
        public bool FirstPlayerToServe
        {
            get
            {
                return match.FirstPlayerToServe;
            }
            set
            {
                match.FirstPlayerToServe = value;
                OnPropertyChanged(nameof(FirstPlayerToServe));
                OnPropertyChanged(nameof(SecondPlayerToServe));
            }
        }
        public bool SecondPlayerToServe
        {
            get
            {
                return !match.FirstPlayerToServe;
            }
        }
        bool ButtonsEnable(object obj)
        {
            return !MatchEnded;
        }
        void P1_Point(object obj)
        {
            previousPoint = new Match(match);
            P1_PointsWon = (match.P1_PointsWon + 1).ToString();

            if (!match.TiebreakEnabled)
            {
                if (match.P1_ActualScore == 0)
                {
                    P1_ActualScore = "15";
                    SetBreakPoints();
                }
                else if (match.P1_ActualScore == 15)
                {
                    P1_ActualScore = "30";
                    SetBreakPoints();
                }
                else if (match.P1_ActualScore == 30)
                {
                    P1_ActualScore = "40";
                    SetBreakPoints();
                }
                else if (match.P1_ActualScore == 40 && match.P2_ActualScore < 40) // if game won
                {
                    P1_Won_Game();
                }
                else if (match.P1_ActualScore == 40 && match.P2_ActualScore == 40)
                {
                    if (!match.AdvantagePlay)
                        P1_Won_Game();
                    else
                    {
                        if (match.P1_Advantage)
                            P1_Won_Game();
                        else
                        {
                            if (match.P2_Advantage)
                            {
                                match.P2_Advantage = false;
                                OnPropertyChanged(nameof(P1_ActualScore));
                                OnPropertyChanged(nameof(P2_ActualScore));
                                SetBreakPoints();
                            }
                            else
                            {
                                P1_ActualScore = "Ad";
                                SetBreakPoints();
                            }
                        }
                    }
                }
            }
            else
            {
                P1_ActualScore = (match.P1_ActualScore + 1).ToString();

                if ((match.P1_ActualScore + match.P2_ActualScore) % 2 == 1)
                    FirstPlayerToServe = !FirstPlayerToServe;

                if (match.P1_ActualScore >= match.PointsToWinTieBreak && match.P1_ActualScore >= match.P2_ActualScore + 2)
                {
                    P1_Won_Game();
                }
            }

            using (var conn = new SQLite.SQLiteConnection(App.file_path))
            {
                conn.Update(match);
            }
        }
        void P2_Point(object obj)
        {
            previousPoint = new Match(match);
            P2_PointsWon = (match.P2_PointsWon + 1).ToString();

            if (!match.TiebreakEnabled)
            {
                if (match.P2_ActualScore == 0)
                {
                    P2_ActualScore = "15";
                    SetBreakPoints();
                }
                else if (match.P2_ActualScore == 15)
                {
                    P2_ActualScore = "30";
                    SetBreakPoints();
                }
                else if (match.P2_ActualScore == 30)
                {
                    P2_ActualScore = "40";
                    SetBreakPoints();
                }
                else if (match.P2_ActualScore == 40 && match.P1_ActualScore < 40) // if game won
                {
                    P2_Won_Game();
                }
                else if (match.P2_ActualScore == 40 && match.P1_ActualScore == 40)
                {
                    if (!match.AdvantagePlay)
                        P2_Won_Game();
                    else
                    {
                        {
                            if (match.P2_Advantage)
                                P2_Won_Game();
                            else
                            {
                                if (match.P1_Advantage)
                                {
                                    match.P1_Advantage = false;
                                    OnPropertyChanged(nameof(P2_ActualScore));
                                    OnPropertyChanged(nameof(P1_ActualScore));
                                    SetBreakPoints();
                                }
                                else
                                {
                                    P2_ActualScore = "Ad";
                                    SetBreakPoints();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                P2_ActualScore = (match.P2_ActualScore + 1).ToString();

                if ((match.P1_ActualScore + match.P2_ActualScore) % 2 == 1)
                    FirstPlayerToServe = !FirstPlayerToServe;

                if (match.P2_ActualScore >= match.PointsToWinTieBreak && match.P2_ActualScore >= match.P1_ActualScore + 2)
                {
                    P2_Won_Game();
                }
            }

            using (var conn = new SQLite.SQLiteConnection(App.file_path))
            {
                conn.Update(match);
            }
        }
        void P1_Won_Game()
        {
            if (!match.FirstPlayerToServe)
            {
                match.P1_BreakPointsWon++;
                OnPropertyChanged(nameof(P1_BreakPointsWon));
            }

            P1_ActualScore = "0";
            P2_ActualScore = "0";
            match.P1_Advantage = false;
            match.P2_Advantage = false;
            match.TiebreakEnabled = false;
            FirstPlayerToServe = match.DidFirstPlayerServeLastGame;
            match.DidFirstPlayerServeLastGame = !match.DidFirstPlayerServeLastGame;

            switch (ActualSet)
            {
                case 0:
                    P1_FirstSet = (match.P1_GamesWon[0] + 1).ToString();
                    break;
                case 1:
                    P1_SecondSet = (match.P1_GamesWon[1] + 1).ToString();
                    break;
                case 2:
                    P1_ThirdSet = (match.P1_GamesWon[2] + 1).ToString();
                    break;
                case 3:
                    P1_FourthSet = (match.P1_GamesWon[3] + 1).ToString();
                    break;
                case 4:
                    P1_FifthSet = (match.P1_GamesWon[4] + 1).ToString();
                    break;
            }

            if ((match.P1_GamesWon[ActualSet] >= match.GamesToWin && match.P1_GamesWon[ActualSet] >= match.P2_GamesWon[ActualSet] + 2) || (match.P1_GamesWon[ActualSet] > match.GamesToWin && match.P2_GamesWon[ActualSet] == match.GamesToWin)) // if set won
            {
                match.P1_SetsWon++;
                if (match.P1_SetsWon >= match.SetsToWin) // if match won
                {
                    MatchEnded = true;
                    P1_Point_Clicked.ChangeCanExecute();
                    P2_Point_Clicked.ChangeCanExecute();
                }
                else
                {
                    ActualSet++;
                }
            }

            if (match.P1_GamesWon[ActualSet] == match.GamesToWin && match.P2_GamesWon[ActualSet] == match.GamesToWin)
            {
                match.TiebreakEnabled = true;
            }
        }
        void P2_Won_Game()
        {
            if (match.FirstPlayerToServe)
            {
                match.P2_BreakPointsWon++;
                OnPropertyChanged(nameof(P2_BreakPointsWon));
            }

            P1_ActualScore = "0";
            P2_ActualScore = "0";
            match.P1_Advantage = false;
            match.P2_Advantage = false;
            match.TiebreakEnabled = false;
            FirstPlayerToServe = match.DidFirstPlayerServeLastGame;
            match.DidFirstPlayerServeLastGame = !match.DidFirstPlayerServeLastGame;

            switch (ActualSet)
            {
                case 0:
                    P2_FirstSet = (match.P2_GamesWon[0] + 1).ToString();
                    break;
                case 1:
                    P2_SecondSet = (match.P2_GamesWon[1] + 1).ToString();
                    break;
                case 2:
                    P2_ThirdSet = (match.P2_GamesWon[2] + 1).ToString();
                    break;
                case 3:
                    P2_FourthSet = (match.P2_GamesWon[3] + 1).ToString();
                    break;
                case 4:
                    P2_FifthSet = (match.P2_GamesWon[4] + 1).ToString();
                    break;
            }

            if ((match.P2_GamesWon[ActualSet] >= match.GamesToWin && match.P2_GamesWon[ActualSet] >= match.P1_GamesWon[ActualSet] + 2) || (match.P2_GamesWon[ActualSet] > match.GamesToWin && match.P1_GamesWon[ActualSet] == match.GamesToWin)) // if set won
            {
                match.P2_SetsWon++;
                if (match.P2_SetsWon >= match.SetsToWin) // if match won
                {
                    MatchEnded = true;
                    P1_Point_Clicked.ChangeCanExecute();
                    P2_Point_Clicked.ChangeCanExecute();
                }
                else
                {
                    ActualSet++;
                }
            }

            if (match.P2_GamesWon[(int)ActualSet] == match.GamesToWin && match.P1_GamesWon[(int)ActualSet] == match.GamesToWin)
            {
                match.TiebreakEnabled = true;
            }
        }
        void SetBreakPoints()
        {
            if (((match.P1_ActualScore == 40 && match.P2_ActualScore < 40) || P1_ActualScore == "Ad") && !match.FirstPlayerToServe)
            {
                match.P1_BreakPoints++;
                OnPropertyChanged(nameof(P1_BreakPointsWon));
            }
            if (((match.P2_ActualScore == 40 && match.P1_ActualScore < 40) || P2_ActualScore == "Ad") && match.FirstPlayerToServe)
            {
                match.P2_BreakPoints++;
                OnPropertyChanged(nameof(P2_BreakPointsWon));
            }
        }
        void Restore(object obj)
        {
            if (previousPoint != null || previousPoint == match)
            {
                match = previousPoint;

                using (var conn = new SQLite.SQLiteConnection(App.file_path))
                {
                    conn.Update(match);
                }

                OnPropertyChanged(nameof(FirstPlayerToServe));
                OnPropertyChanged(nameof(SecondPlayerToServe));
                OnPropertyChanged(nameof(P1_ActualScore));
                OnPropertyChanged(nameof(P1_FirstSet));
                OnPropertyChanged(nameof(P1_SecondSet));
                OnPropertyChanged(nameof(P1_ThirdSet));
                OnPropertyChanged(nameof(P1_FourthSet));
                OnPropertyChanged(nameof(P1_FifthSet));

                OnPropertyChanged(nameof(P2_ActualScore));
                OnPropertyChanged(nameof(P2_FirstSet));
                OnPropertyChanged(nameof(P2_SecondSet));
                OnPropertyChanged(nameof(P2_ThirdSet));
                OnPropertyChanged(nameof(P2_FourthSet));
                OnPropertyChanged(nameof(P2_FifthSet));

                OnPropertyChanged(nameof(P1_PointsWon));
                OnPropertyChanged(nameof(P1_BreakPointsWon));
                OnPropertyChanged(nameof(P2_PointsWon));
                OnPropertyChanged(nameof(P2_BreakPointsWon));

                OnPropertyChanged(nameof(ActualSet));
            }
        }
        void Nav_Back(object obj)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
