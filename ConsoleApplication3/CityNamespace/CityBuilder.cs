using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaManager.CityNamespace
{
    class CityBuilder
    {
        public bool ItemShop { get; set; }
        public bool WeaponShop { get; set; }
        public bool Arena { get; set; }
        public bool Inn { get; set; }
        public bool RecruitmentCenter { get; set; }
        public bool Armory { get; set; }
        public bool Castle { get; set; }
        public bool TownHall { get; set; }
        public bool MonsterPens { get; set; }
        public int Army { get; set; }
        public int CityReputation { get; set; }
        public bool ResourceDepot { get; set; }

        public CityBuilder()
        {
 
        }
    }
}
