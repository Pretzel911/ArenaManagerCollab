using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaManager.PlayerNamespace
{
    public class PlayerBuff
    {
        public StatsEnum StatBuffed { get; set; }
        public int AmountBuffed { get; set; }
        public int BattlesRemaining { get; set; }

        public String DescriptionMain()
        {
            return "+" + AmountBuffed.ToString() + " " + StatBuffed.ToString() + " for " + BattlesRemaining.ToString() + " more turns.";
        }
        public String DescriptionBattle()
        {
            return "+" + AmountBuffed.ToString() + " " + StatBuffed.ToString() + ".";
        }
    }
}
