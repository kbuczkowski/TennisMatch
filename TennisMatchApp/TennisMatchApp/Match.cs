using System;
using System.Collections.Generic;
using System.ComponentModel;
using SQLite;
using Newtonsoft.Json;

namespace TennisMatchApp
{
    public class Match
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string P1_Name { get; set; }
        public string P2_Name { get; set; }

        #region settings
        public int SetsToWin { get; set; }
        public int GamesToWin { get; set; }
        public int PointsToWinTieBreak { get; set; }
        public bool AdvantagePlay { get; set; }
        public bool FirstPlayerToServe { get; set; }
        public bool DidFirstPlayerServeLastGame { get; set; }
        public bool MatchEnded { get; set; }
        public bool AdvancedStats { get; set; }
        public DateTime Date { get; set; }
        #endregion

        #region Scores
        public int P1_SetsWon { get; set; }
        public int P2_SetsWon { get; set; }
        public int P1_ActualScore { get; set; }
        public int P2_ActualScore { get; set; }
        public bool P1_Advantage { get; set; }
        public bool P2_Advantage { get; set; }
        public bool TiebreakEnabled { get; set; }
        public int ActualSet { get; set; }
        public string P1_GamesWonSerialized { get; set; }
        public string P2_GamesWonSerialized { get; set; }
        [Ignore]
        public List<int> P1_GamesWon
        {
            get
            {
                return JsonConvert.DeserializeObject<List<int>>(P1_GamesWonSerialized);
            }
            set
            {
                P1_GamesWonSerialized = JsonConvert.SerializeObject(value);
            }
        }
        [Ignore]
        public List<int> P2_GamesWon
        {
            get
            {
                return JsonConvert.DeserializeObject<List<int>>(P2_GamesWonSerialized);
            }
            set
            {
                P2_GamesWonSerialized = JsonConvert.SerializeObject(value);
            }
        }
        #endregion

        #region Players basic statistics
        public int P1_BreakPoints { get; set; }
        public int P1_BreakPointsWon { get; set; }
        public int P1_PointsWon { get; set; }
        public int P2_BreakPoints { get; set; }
        public int P2_BreakPointsWon { get; set; }
        public int P2_PointsWon { get; set; }
        #endregion

        #region Players advanced statistics
        public int P1_Aces { get; set; }
        public int P1_ForcedErrors { get; set; }
        public int P1_UnforcedErrors { get; set; }
        public int P1_FirstServeIn { get; set; }
        public int P1_DoubleFaults { get; set; }
        public int P1_ServePointsPlayed { get; set; }
        public int P1_Winners { get; set; }
        public int P1_ForehandWinners { get; set; }
        public int P1_BackhandWinners { get; set; }
        public int P1_ForehandUnforcedErrors { get; set; }
        public int P1_BackhandUnforcedErrors { get; set; }
        public int P2_Aces { get; set; }
        public int P2_ForcedErrors { get; set; }
        public int P2_UnforcedErrors { get; set; }
        public int P2_FirstServeIn { get; set; }
        public int P2_DoubleFaults { get; set; }
        public int P2_ServePointsPlayed { get; set; }
        public int P2_Winners { get; set; }
        public int P2_ForehandWinners { get; set; }
        public int P2_BackhandWinners { get; set; }
        public int P2_ForehandUnforcedErrors { get; set; }
        public int P2_BackhandUnforcedErrors { get; set; }
        #endregion

        #region Viewmodel
        [Ignore]
        public string MatchDate
        {
            get
            {
                return Date.ToString("D");
            }
        }
        [Ignore]
        public string BestOf
        {
            get
            {
                return "Best of " + (SetsToWin * 2 - 1).ToString();
            }
        }
        [Ignore]
        public string P1_Score
        {
            get
            {
                string s = P1_GamesWon[0].ToString();
                for(int i = 1; i <= ActualSet; i++)
                    s += (" " + P1_GamesWon[i].ToString());
                
                return s;
            }
        }
        [Ignore]
        public string P2_Score
        {
            get
            {
                string s = P2_GamesWon[0].ToString();
                for (int i = 1; i <= ActualSet; i++)
                    s += (" " + P2_GamesWon[i].ToString());

                return s;
            }
        }
        #endregion

        public Match() { }
        public Match(string p_p1, string p_p2, int p_setsToWin, int p_gamesToWin, int p_pointsToWinTieBreak, bool p_advantagePlay, bool p_firstPlayerToServe, bool p_advancedStats)
        {
            P1_Name = p_p1;
            P2_Name = p_p2;
            SetsToWin = p_setsToWin;
            GamesToWin = p_gamesToWin;
            PointsToWinTieBreak = p_pointsToWinTieBreak;
            AdvantagePlay = p_advantagePlay;
            FirstPlayerToServe = p_firstPlayerToServe;
            DidFirstPlayerServeLastGame = !p_firstPlayerToServe;
            AdvancedStats = p_advancedStats;
            P1_SetsWon = 0;
            P2_SetsWon = 0;
            P1_ActualScore = 0;
            P2_ActualScore = 0;
            MatchEnded = false;
            Date = DateTime.Now;
            ActualSet = 0;
            List<int> _p1_GamesWon_Temp = new List<int>();
            List<int> _p2_GamesWon_Temp = new List<int>();

            for(int i = 0; i < (SetsToWin * 2) - 1 ; i++)
            {
                _p1_GamesWon_Temp.Add(0);
                _p2_GamesWon_Temp.Add(0);
            }

            P1_GamesWon = _p1_GamesWon_Temp;
            P2_GamesWon = _p2_GamesWon_Temp;

            P1_PointsWon = 0;
            P1_BreakPoints = 0;
            P1_BreakPointsWon = 0;

            P2_PointsWon = 0;
            P2_BreakPoints = 0;
            P2_BreakPointsWon = 0;

            if (AdvancedStats)
            {
                P1_Aces = 0;
                P1_ForcedErrors = 0;
                P1_UnforcedErrors = 0;
                P1_FirstServeIn = 0;
                P1_DoubleFaults = 0;
                P1_ServePointsPlayed = 0;
                P1_Winners = 0;
                P1_ForehandWinners = 0;
                P1_BackhandWinners = 0;
                P1_ForehandUnforcedErrors = 0;
                P1_BackhandUnforcedErrors = 0;

                P2_Aces = 0;
                P2_ForcedErrors = 0;
                P2_UnforcedErrors = 0;
                P2_FirstServeIn = 0;
                P2_DoubleFaults = 0;
                P2_ServePointsPlayed = 0;
                P2_Winners = 0;
                P2_ForehandWinners = 0;
                P2_BackhandWinners = 0;
                P2_ForehandUnforcedErrors = 0;
                P2_BackhandUnforcedErrors = 0;
            }
        }
        public Match(Match p_match)
        {
            Id = p_match.Id;

            P1_Name = p_match.P1_Name;
            P2_Name = p_match.P2_Name;
            SetsToWin = p_match.SetsToWin;
            GamesToWin = p_match.GamesToWin;
            PointsToWinTieBreak = p_match.PointsToWinTieBreak;
            AdvantagePlay = p_match.AdvantagePlay;
            FirstPlayerToServe = p_match.FirstPlayerToServe;
            DidFirstPlayerServeLastGame = p_match.DidFirstPlayerServeLastGame;
            AdvancedStats = p_match.AdvancedStats;
            P1_SetsWon = p_match.P1_SetsWon;
            P2_SetsWon = p_match.P2_SetsWon;
            P1_ActualScore = p_match.P1_ActualScore;
            P2_ActualScore = p_match.P2_ActualScore;
            MatchEnded = p_match.MatchEnded;
            Date = p_match.Date;
            ActualSet = p_match.ActualSet;
            P1_Advantage = p_match.P1_Advantage;
            P2_Advantage = p_match.P2_Advantage;

            TiebreakEnabled = p_match.TiebreakEnabled;

            P1_GamesWon = p_match.P1_GamesWon;
            P2_GamesWon = p_match.P2_GamesWon;

            P1_PointsWon = p_match.P1_PointsWon;
            P1_BreakPoints = p_match.P1_BreakPoints;
            P1_BreakPointsWon = p_match.P1_BreakPointsWon;

            P2_PointsWon = p_match.P2_PointsWon;
            P2_BreakPoints = p_match.P2_BreakPoints;
            P2_BreakPointsWon = p_match.P2_BreakPointsWon;

            if (AdvancedStats)
            {
                P1_Aces = 0;
                P1_ForcedErrors = 0;
                P1_UnforcedErrors = 0;
                P1_FirstServeIn = 0;
                P1_DoubleFaults = 0;
                P1_ServePointsPlayed = 0;
                P1_Winners = 0;
                P1_ForehandWinners = 0;
                P1_BackhandWinners = 0;
                P1_ForehandUnforcedErrors = 0;
                P1_BackhandUnforcedErrors = 0;

                P2_Aces = 0;
                P2_ForcedErrors = 0;
                P2_UnforcedErrors = 0;
                P2_FirstServeIn = 0;
                P2_DoubleFaults = 0;
                P2_ServePointsPlayed = 0;
                P2_Winners = 0;
                P2_ForehandWinners = 0;
                P2_BackhandWinners = 0;
                P2_ForehandUnforcedErrors = 0;
                P2_BackhandUnforcedErrors = 0;
            }
        }
    }
}
