using System;
using System.Collections.Generic;
using System.Text;

namespace TennisMatchApp
{
    public class Match
    {
        public string p1_Name, p2_Name;

        #region settings
        public int setsToWin, gamesToWin, pointsToWinTieBreak;
        public bool advantagePlay, firstPlayerToServe, matchEnded, advancedStats;
        public DateTime date;
        #endregion

        #region scores
        public int p1_SetsWon, p2_SetsWon, actualSet;
        public List<int> p1_GamesWon, p2_GamesWon;
        #endregion

        #region players basic statistics
        public int p1_BreakPoints, p1_BreakPointsWon, p1_PointsWon,
                   p2_BreakPoints, p2_BreakPointsWon, p2_PointsWon;
        #endregion

        #region players advanced statistics
        public int p1_Aces, p1_ForcedErrors, p1_UnforcedErrors, p1_FirstServeIn, p1_DoubleFaults, p1_ServePointsPlayed, p1_Winners, p1_ForehandWinners, p1_BackhandWinners, p1_ForehandUnforcedErrors, p1_BackhandUnforcedErrors,
                   p2_Aces, p2_ForcedErrors, p2_UnforcedErrors, p2_FirstServeIn, p2_DoubleFaults, p2_ServePointsPlayed, p2_Winners, p2_ForehandWinners, p2_BackhandWinners, p2_ForehandUnforcedErrors, p2_BackhandUnforcedErrors;
        #endregion

        public string P1_Name
        {
            get { return p1_Name; }
        }
        public string P2_Name
        {
            get { return p2_Name; }
        }
        public Match(string p_p1, string p_p2, int p_setsToWin, int p_gamesToWin, int p_pointsToWinTieBreak, bool p_advantagePlay, bool p_firstPlayerToServe, bool p_advancedStats)
        {
            p1_Name = p_p1;
            p2_Name = p_p2;
            setsToWin = p_setsToWin;
            gamesToWin = p_gamesToWin;
            pointsToWinTieBreak = p_pointsToWinTieBreak;
            advantagePlay = p_advantagePlay;
            firstPlayerToServe = p_firstPlayerToServe;
            advancedStats = p_advancedStats;
            p1_SetsWon = 0;
            p2_SetsWon = 0;
            p1_GamesWon = new List<int>();
            p2_GamesWon = new List<int>();
            matchEnded = false;
            date = new DateTime();
            actualSet = 0;

            p1_PointsWon = 0;
            p1_BreakPoints = 0;
            p1_BreakPointsWon = 0;

            p2_PointsWon = 0;
            p2_BreakPoints = 0;
            p2_BreakPointsWon = 0;

            if (advancedStats)
            {
                p1_Aces = 0;
                p1_ForcedErrors = 0;
                p1_UnforcedErrors = 0;
                p1_FirstServeIn = 0;
                p1_DoubleFaults = 0;
                p1_ServePointsPlayed = 0;
                p1_Winners = 0;
                p1_ForehandWinners = 0;
                p1_BackhandWinners = 0;
                p1_ForehandUnforcedErrors = 0;
                p1_BackhandUnforcedErrors = 0;

                p2_Aces = 0;
                p2_ForcedErrors = 0;
                p2_UnforcedErrors = 0;
                p2_FirstServeIn = 0;
                p2_DoubleFaults = 0;
                p2_ServePointsPlayed = 0;
                p2_Winners = 0;
                p2_ForehandWinners = 0;
                p2_BackhandWinners = 0;
                p2_ForehandUnforcedErrors = 0;
                p2_BackhandUnforcedErrors = 0;
            }
        }
    }
}
