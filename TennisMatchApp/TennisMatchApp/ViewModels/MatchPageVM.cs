using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TennisMatchApp.ViewModels;
using TennisMatchApp.Models;
using Xamarin.Forms;

namespace TennisMatchApp.ViewModels
{
    class MatchPageVM : BaseVM
    {
        Match match, previousPoint;
        bool _isPlaying = false;
        bool _p1FirstFault = false;
        bool _p2FirstFault = false;
        string _p1_FaultButtonText = "Fault";
        string _p2_FaultButtonText = "Fault";

        #region commands
        public Command Restore_Point_Command { get; set; }
        public Command Pause_Command { get; set; }
        public Command Play_Command { get; set; }
        public Command P1_Point_Command { get; set; }
        public Command P2_Point_Command { get; set; }
        public Command P1_Ace_Command { get; set; }
        public Command P2_Ace_Command { get; set; }
        public Command P1_Fault_Command { get; set; }
        public Command P2_Fault_Command { get; set; }
        public Command P1_ForehandWinner_Command { get; set; }
        public Command P2_ForehandWinner_Command { get; set; }
        public Command P1_BackhandWinner_Command { get; set; }
        public Command P2_BackhandWinner_Command { get; set; }
        public Command P1_ForehandUnforcedError_Command { get; set; }
        public Command P2_ForehandUnforcedError_Command { get; set; }
        public Command P1_BackhandUnforcedError_Command { get; set; }
        public Command P2_BackhandUnforcedError_Command { get; set; }
        public Command P1_ForcedError_Command { get; set; }
        public Command P2_ForcedError_Command { get; set; }
        public Command Refresh_Command { get; set; }
        #endregion
        
        #region scores
        public string MatchName
        {
            get
            {
                return match.P1_Name + " vs " + match.P2_Name;
            }
        }
        public string MatchTime
        {
            get
            {
                int h = match.TimeElapsed / 3600;
                int m = (match.TimeElapsed - (h * 3600)) / 60;
                int s = (match.TimeElapsed - (h * 3600) - (m * 60));
                return "TIME: " + h.ToString() + ":" + m.ToString("00") + ":" + s.ToString("00");
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
        #endregion

        #region basic stats
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
                OnPropertyChanged(nameof(PointsWon));
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
                OnPropertyChanged(nameof(PointsWon));
            }
        }
        public double PointsWon
        {
            get
            {
                if (match.P1_PointsWon != 0 || match.P2_PointsWon != 0)
                    return (double)match.P1_PointsWon / (double)(match.P1_PointsWon + match.P2_PointsWon);
                return 0.5;
            }
        }
        public string P1_BreakPoints
        {
            get
            {
                return match.P1_BreakPoints.ToString();
            }
        }
        public string P2_BreakPoints
        {
            get
            {
                return match.P2_BreakPoints.ToString();
            }
        }
        public double BreakPoints
        {
            get
            {
                if (match.P1_BreakPoints != 0 || match.P2_BreakPoints != 0)
                    return (double)match.P1_BreakPoints / (double)(match.P1_BreakPoints + match.P2_BreakPoints);
                return 0.5;
            }
        }
        public string P1_BreakPointsWon
        {
            get
            {
                return match.P1_BreakPointsWon.ToString();
            }
        }
        public string P2_BreakPointsWon
        {
            get
            {
                return match.P2_BreakPointsWon.ToString();
            }
        }
        public double BreakPointsWon
        {
            get
            {
                if (match.P1_BreakPointsWon != 0 || match.P2_BreakPointsWon != 0)
                    return (double)match.P1_BreakPointsWon / (double)(match.P1_BreakPointsWon + match.P2_BreakPointsWon);
                return 0.5;
            }
        }
        #endregion

        #region advanced stats
        public int P1_Aces { get { return match.P1_Aces; } }
        public int P1_ForcedErrors { get { return match.P1_ForcedErrors; } }
        public int P1_UnforcedErrors { get { return match.P1_UnforcedErrors; } }
        public int P1_FirstServeIn { get { return match.P1_FirstServeIn; } }
        public int P1_DoubleFaults { get { return match.P1_DoubleFaults; } }
        public int P1_ServePointsPlayed { get { return match.P1_ServePointsPlayed; } }
        public int P1_Winners { get { return match.P1_Winners; } }
        public int P1_ForehandWinners { get { return match.P1_ForehandWinners; } }
        public int P1_BackhandWinners { get { return match.P1_BackhandWinners; } }
        public int P1_ForehandUnforcedErrors { get { return match.P1_ForehandUnforcedErrors; } }
        public int P1_BackhandUnforcedErrors { get { return match.P1_BackhandUnforcedErrors; } }
        public int P2_Aces { get { return match.P2_Aces; } }
        public int P2_ForcedErrors { get { return match.P2_ForcedErrors; } }
        public int P2_UnforcedErrors { get { return match.P2_UnforcedErrors; } }
        public int P2_FirstServeIn { get { return match.P2_FirstServeIn; } }
        public int P2_DoubleFaults { get { return match.P2_DoubleFaults; } }
        public int P2_ServePointsPlayed { get { return match.P2_ServePointsPlayed; } }
        public int P2_Winners { get { return match.P2_Winners; } }
        public int P2_ForehandWinners { get { return match.P2_ForehandWinners; } }
        public int P2_BackhandWinners { get { return match.P2_BackhandWinners; } }
        public int P2_ForehandUnforcedErrors { get { return match.P2_ForehandUnforcedErrors; } }
        public int P2_BackhandUnforcedErrors { get { return match.P2_BackhandUnforcedErrors; } }
        public double Aces
        {
            get
            {
                if (match.P1_Aces != 0 || match.P2_Aces != 0)
                    return (double)match.P1_Aces / (double)(match.P1_Aces + match.P2_Aces);
                return 0.5;
            }
        }
        public double DoubleFaults
        {
            get
            {
                if (match.P1_DoubleFaults != 0 || match.P2_DoubleFaults != 0)
                    return (double)match.P1_DoubleFaults / (double)(match.P1_DoubleFaults + match.P2_DoubleFaults);
                return 0.5;
            }
        }
        public double Winners
        {
            get
            {
                if (match.P1_Winners != 0 || match.P2_Winners != 0)
                    return (double)match.P1_Winners / (double)(match.P1_Winners + match.P2_Winners);
                return 0.5;
            }
        }
        public double ForehandWinners
        {
            get
            {
                if (match.P1_ForehandWinners != 0 || match.P2_ForehandWinners != 0)
                    return (double)match.P1_ForehandWinners / (double)(match.P1_ForehandWinners + match.P2_ForehandWinners);
                return 0.5;
            }
        }
        public double BackhandWinners
        {
            get
            {
                if (match.P1_BackhandWinners != 0 || match.P2_BackhandWinners != 0)
                    return (double)match.P1_BackhandWinners / (double)(match.P1_BackhandWinners + match.P2_BackhandWinners);
                return 0.5;
            }
        }
        public double UnforcedErrors
        {
            get
            {
                if (match.P1_UnforcedErrors != 0 || match.P2_UnforcedErrors != 0)
                    return (double)match.P1_UnforcedErrors / (double)(match.P1_UnforcedErrors + match.P2_UnforcedErrors);
                return 0.5;
            }
        }
        public double ForehandUnforcedErrors
        {
            get
            {
                if (match.P1_ForehandUnforcedErrors != 0 || match.P2_ForehandUnforcedErrors != 0)
                    return (double)match.P1_ForehandUnforcedErrors / (double)(match.P1_ForehandUnforcedErrors + match.P2_ForehandUnforcedErrors);
                return 0.5;
            }
        }
        public double BackhandUnforcedErrors
        {
            get
            {
                if (match.P1_BackhandUnforcedErrors != 0 || match.P2_BackhandUnforcedErrors != 0)
                    return (double)match.P1_BackhandUnforcedErrors / (double)(match.P1_BackhandUnforcedErrors + match.P2_BackhandUnforcedErrors);
                return 0.5;
            }
        }
        public double ForcedErrors
        {
            get
            {
                if (match.P1_ForcedErrors != 0 || match.P2_ForcedErrors != 0)
                    return (double)match.P1_ForcedErrors / (double)(match.P1_ForcedErrors + match.P2_ForcedErrors);
                return 0.5;
            }
        }
        #endregion

        #region settings
        public string P1_FaultButtonText
        {
            get
            {
                return _p1_FaultButtonText;
            }
            set
            {
                _p1_FaultButtonText = value;
                OnPropertyChanged(nameof(P1_FaultButtonText));
            }
        }
        public string P2_FaultButtonText
        {
            get
            {
                return _p2_FaultButtonText;
            }
            set
            {
                _p2_FaultButtonText = value;
                OnPropertyChanged(nameof(P2_FaultButtonText));
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
        public bool AdvancedStats
        {
            get
            {
                return match.AdvancedStats;
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
                if (!MatchEnded)
                    return match.FirstPlayerToServe;
                return false;
            }
            set
            {
                match.FirstPlayerToServe = value;
                OnPropertyChanged(nameof(FirstPlayerToServe));
                OnPropertyChanged(nameof(SecondPlayerToServe));
                P1_Ace_Command.ChangeCanExecute();
                P2_Ace_Command.ChangeCanExecute();
                P1_Fault_Command.ChangeCanExecute();
                P2_Fault_Command.ChangeCanExecute();
            }
        }
        public bool SecondPlayerToServe
        {
            get
            {
                if (!MatchEnded)
                    return !match.FirstPlayerToServe;
                return false;
            }
        }
        public bool IsPlaying
        {
            get
            {
                return _isPlaying;
            }
            set
            {
                _isPlaying = value;
                OnPropertyChanged(nameof(IsPlaying));
            }
        }
        public bool IsPaused
        {
            get
            {
                if (!MatchEnded && !IsPlaying)
                    return true;
                return false;
            }
        }
        #endregion
        public MatchPageVM()
        {
            match = App.currentMatch;
            Device.StartTimer(TimeSpan.FromSeconds(1.0), Tick);

            Pause_Command = new Command(Pause);
            Play_Command = new Command(Play);
            Restore_Point_Command = new Command(Restore);
            Refresh_Command = new Command(Refresh);

            P1_Point_Command = new Command(P1_Point_Click, ButtonsEnable);
            P2_Point_Command = new Command(P2_Point_Click, ButtonsEnable);

            P1_Ace_Command = new Command(P1_Ace, P1_ServeButtonsEnable);
            P2_Ace_Command = new Command(P2_Ace, P2_ServeButtonsEnable);
            P1_Fault_Command = new Command(P1_Fault, P1_ServeButtonsEnable);
            P2_Fault_Command = new Command(P2_Fault, P2_ServeButtonsEnable);

            P1_ForehandWinner_Command = new Command(P1_ForehandWinner, ButtonsEnable);
            P2_ForehandWinner_Command = new Command(P2_ForehandWinner, ButtonsEnable);

            P1_BackhandWinner_Command = new Command(P1_BackhandWinner, ButtonsEnable);
            P2_BackhandWinner_Command = new Command(P2_BackhandWinner, ButtonsEnable);

            P1_ForehandUnforcedError_Command = new Command(P1_ForehandUnforcedError, ButtonsEnable);
            P2_ForehandUnforcedError_Command = new Command(P2_ForehandUnforcedError, ButtonsEnable);

            P1_BackhandUnforcedError_Command = new Command(P1_BackhandUnforcedError, ButtonsEnable);
            P2_BackhandUnforcedError_Command = new Command(P2_BackhandUnforcedError, ButtonsEnable);

            P1_ForcedError_Command = new Command(P1_ForcedError, ButtonsEnable);
            P2_ForcedError_Command = new Command(P2_ForcedError, ButtonsEnable);
        }
        #region methods
        void P1_Point_Click(object obj)
        {
            P1_Point();
        }
        void P2_Point_Click(object obj)
        {
            P2_Point();
        }
        bool ButtonsEnable(object obj)
        {
            return IsPlaying;
        }
        bool P1_ServeButtonsEnable(object obj)
        {
            if (IsPlaying && FirstPlayerToServe)
                return true;
            return false;
        }
        bool P2_ServeButtonsEnable(object obj)
        {
            if (IsPlaying && SecondPlayerToServe)
                return true;
            return false;
        }
        void Restore(object obj)
        {
            if (_p1FirstFault)
            {
                _p1FirstFault = false;
                P1_FaultButtonText = "Fault";
                OnPropertyChanged(nameof(P1_FaultButtonText));
            }
            else if (_p2FirstFault)
            {
                _p2FirstFault = false;
                P2_FaultButtonText = "Fault";
                OnPropertyChanged(nameof(P2_FaultButtonText));
            }
            else
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

                    OnPropertyChanged(nameof(PointsWon));
                    OnPropertyChanged(nameof(BreakPoints));
                    OnPropertyChanged(nameof(BreakPointsWon));

                    OnPropertyChanged(nameof(ActualSet));

                    OnPropertyChanged(nameof(MatchTime));
                }
            }
        }
        void Pause(object obj)
        {
            _isPlaying = false;

            OnPropertyChanged(nameof(IsPaused));
            P1_Point_Command.ChangeCanExecute();
            P2_Point_Command.ChangeCanExecute();
            P1_Ace_Command.ChangeCanExecute();
            P2_Ace_Command.ChangeCanExecute();
            P1_Fault_Command.ChangeCanExecute();
            P2_Fault_Command.ChangeCanExecute();
            P1_ForehandWinner_Command.ChangeCanExecute();
            P2_ForehandWinner_Command.ChangeCanExecute();
            P1_BackhandWinner_Command.ChangeCanExecute();
            P2_BackhandWinner_Command.ChangeCanExecute();
            P1_ForehandUnforcedError_Command.ChangeCanExecute();
            P2_ForehandUnforcedError_Command.ChangeCanExecute();
            P1_BackhandUnforcedError_Command.ChangeCanExecute();
            P2_BackhandUnforcedError_Command.ChangeCanExecute();
            P1_ForcedError_Command.ChangeCanExecute();
            P2_ForcedError_Command.ChangeCanExecute();
        }
        void Play(object obj)
        {
            if (!MatchEnded)
            {
                _isPlaying = true;

                OnPropertyChanged(nameof(IsPaused));
                P1_Point_Command.ChangeCanExecute();
                P2_Point_Command.ChangeCanExecute();
                P1_Ace_Command.ChangeCanExecute();
                P2_Ace_Command.ChangeCanExecute();
                P1_Fault_Command.ChangeCanExecute();
                P2_Fault_Command.ChangeCanExecute();
                P1_ForehandWinner_Command.ChangeCanExecute();
                P2_ForehandWinner_Command.ChangeCanExecute();
                P1_BackhandWinner_Command.ChangeCanExecute();
                P2_BackhandWinner_Command.ChangeCanExecute();
                P1_ForehandUnforcedError_Command.ChangeCanExecute();
                P2_ForehandUnforcedError_Command.ChangeCanExecute();
                P1_BackhandUnforcedError_Command.ChangeCanExecute();
                P2_BackhandUnforcedError_Command.ChangeCanExecute();
                P1_ForcedError_Command.ChangeCanExecute();
                P2_ForcedError_Command.ChangeCanExecute();
            }
        }
        void P1_Ace(object obj)
        {
            P1_Point();

            match.P1_Aces++;
            match.P1_Winners++;

            if (!_p1FirstFault)
                match.P1_FirstServeIn++;
        }
        void P2_Ace(object obj)
        {
            P2_Point();

            match.P2_Aces++;
            match.P2_Winners++;

            if (!_p2FirstFault)
                match.P2_FirstServeIn++;
        }
        void P1_Fault(object obj)
        {
            if (!_p1FirstFault)
            {
                _p1FirstFault = true;
                P1_FaultButtonText = "D. Fault";
            }
            else
            {
                _p1FirstFault = false;
                P1_FaultButtonText = "Fault";
                match.P1_DoubleFaults++;
                P2_Point();
            }
        }
        void P2_Fault(object obj)
        {
            if (!_p2FirstFault)
            {
                _p2FirstFault = true;
                P2_FaultButtonText = "D. Fault";
            }
            else
            {
                _p2FirstFault = false;
                P2_FaultButtonText = "Fault";
                match.P2_DoubleFaults++;
                P1_Point();
            }
        }
        void P1_ForehandWinner(object obj)
        {
            match.P1_ForehandWinners++;
            match.P1_Winners++;

            P1_Point();
        }
        void P2_ForehandWinner(object obj)
        {
            match.P2_ForehandWinners++;
            match.P2_Winners++;

            P2_Point();
        }
        void P1_BackhandWinner(object obj)
        {
            match.P1_BackhandWinners++;
            match.P1_Winners++;

            P1_Point();
        }
        void P2_BackhandWinner(object obj)
        {
            match.P2_BackhandWinners++;
            match.P2_Winners++;

            P2_Point();
        }
        void P1_ForehandUnforcedError(object obj)
        {
            match.P1_ForehandUnforcedErrors++;
            match.P1_UnforcedErrors++;

            P2_Point();
        }
        void P2_ForehandUnforcedError(object obj)
        {
            match.P2_ForehandUnforcedErrors++;
            match.P2_UnforcedErrors++;

            P1_Point();
        }
        void P1_BackhandUnforcedError(object obj)
        {
            match.P1_BackhandUnforcedErrors++;
            match.P1_UnforcedErrors++;

            P2_Point();
        }
        void P2_BackhandUnforcedError(object obj)
        {
            match.P2_BackhandUnforcedErrors++;
            match.P2_UnforcedErrors++;

            P1_Point();
        }
        void P1_ForcedError(object obj)
        {
            match.P1_ForcedErrors++;

            P2_Point();
        }
        void P2_ForcedError(object obj)
        {
            match.P2_ForcedErrors++;

            P1_Point();
        }
        void Refresh(object obj)
        {
            OnPropertyChanged(nameof(P1_Aces));
            OnPropertyChanged(nameof(P1_DoubleFaults));
            OnPropertyChanged(nameof(P1_Winners));
            OnPropertyChanged(nameof(P1_ForehandWinners));
            OnPropertyChanged(nameof(P1_BackhandWinners));
            OnPropertyChanged(nameof(P1_UnforcedErrors));
            OnPropertyChanged(nameof(P1_ForehandUnforcedErrors));
            OnPropertyChanged(nameof(P1_BackhandUnforcedErrors));
            OnPropertyChanged(nameof(P1_ForcedErrors));

            OnPropertyChanged(nameof(P2_Aces));
            OnPropertyChanged(nameof(P2_DoubleFaults));
            OnPropertyChanged(nameof(P2_Winners));
            OnPropertyChanged(nameof(P2_ForehandWinners));
            OnPropertyChanged(nameof(P2_BackhandWinners));
            OnPropertyChanged(nameof(P2_UnforcedErrors));
            OnPropertyChanged(nameof(P2_ForehandUnforcedErrors));
            OnPropertyChanged(nameof(P2_BackhandUnforcedErrors));
            OnPropertyChanged(nameof(P2_ForcedErrors));

            OnPropertyChanged(nameof(Aces));
            OnPropertyChanged(nameof(DoubleFaults));
            OnPropertyChanged(nameof(Winners));
            OnPropertyChanged(nameof(ForehandWinners));
            OnPropertyChanged(nameof(BackhandWinners));
            OnPropertyChanged(nameof(UnforcedErrors));
            OnPropertyChanged(nameof(ForehandUnforcedErrors));
            OnPropertyChanged(nameof(BackhandUnforcedErrors));
            OnPropertyChanged(nameof(ForcedErrors));
        }
        void P1_Point()
        {
            previousPoint = new Match(match);
            P1_PointsWon = (match.P1_PointsWon + 1).ToString();
            _p1FirstFault = false;
            _p2FirstFault = false;

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
        void P2_Point()
        {
            previousPoint = new Match(match);
            P2_PointsWon = (match.P2_PointsWon + 1).ToString();
            _p1FirstFault = false;
            _p2FirstFault = false;

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
                OnPropertyChanged(nameof(BreakPointsWon));
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
                    _isPlaying = false;

                    OnPropertyChanged(nameof(FirstPlayerToServe));
                    OnPropertyChanged(nameof(SecondPlayerToServe));

                    P1_Point_Command.ChangeCanExecute();
                    P2_Point_Command.ChangeCanExecute();
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
                OnPropertyChanged(nameof(BreakPointsWon));
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
                    IsPlaying = false;

                    OnPropertyChanged(nameof(FirstPlayerToServe));
                    OnPropertyChanged(nameof(SecondPlayerToServe));

                    P1_Point_Command.ChangeCanExecute();
                    P2_Point_Command.ChangeCanExecute();
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
            if ((((match.P1_ActualScore == 40 && match.P2_ActualScore < 40) || P1_ActualScore == "Ad") && !match.FirstPlayerToServe) || (match.P1_ActualScore == 40 && match.P2_ActualScore == 40 && !match.FirstPlayerToServe && !match.AdvantagePlay))
            {
                match.P1_BreakPoints++;
                OnPropertyChanged(nameof(P1_BreakPoints));
            }
            if ((((match.P2_ActualScore == 40 && match.P1_ActualScore < 40) || P2_ActualScore == "Ad") && match.FirstPlayerToServe) || (match.P1_ActualScore == 40 && match.P2_ActualScore == 40 && match.FirstPlayerToServe && !match.AdvantagePlay))
            {
                match.P2_BreakPoints++;
                OnPropertyChanged(nameof(P2_BreakPoints));
            }

            OnPropertyChanged(nameof(BreakPoints));
        }
        bool Tick()
        {
            if (IsPlaying)
            {
                match.TimeElapsed++;
                OnPropertyChanged(nameof(MatchTime));
            }
            return true;
        }
        #endregion
    }
}