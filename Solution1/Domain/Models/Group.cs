using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Group
    {
        public Game Game1 { get; private set; }
        public Game Game2 { get; private set; }
        public Player WinnerGame1 { get; private set; }
        public Player WinnerGame2 { get; private set; }

        public Group(Game g1, Game g2)
        {
            this.Game1 = g1;
            this.Game1 = g2;
            this.WinnerGame1 = null;
            this.WinnerGame2 = null;
        }
        public Group()
        {
            this.Game1 = null;
            this.Game2 = null;
            this.WinnerGame1 = null;
            this.WinnerGame2 = null;
        }

        public bool CheckFull()
        {
            return Game1 != null && Game2 != null;
        }

        public void Add(Game g)
        {
            if (Game1 == null)
                this.Game1 = g;
            else
                if (Game2 == null)
                this.Game2 = g;
        }

        public bool CheckEmpty()
        {
            return Game1 == null && Game2 == null;
        }

        #region Setters
        public void SetGame1(Game g1)
        {
            this.Game1 = g1;
        }
        public void SetGame2(Game g2)
        {
            this.Game2 = g2;
        }
        public void SetWinnerGame1(Player win1)
        {
            this.WinnerGame1 = win1;
        }
        public void SetWinnerGame2(Player win2)
        {
            this.WinnerGame2 = win2;
        }

        #endregion
    }
}
