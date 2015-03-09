using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArenaManager.MonsterNamespace
{
    [XmlRoot("HealthRestoreItems")]
    public class MonstersList
    {
        [XmlElement("HealthRestoreItem")]
        public List<Monster> Monsters { get; set; }
    }
    class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Defense { get; set; }
        public int Experience { get; set; }
        public string AttackText { get; set; }
        public string HitText { get; set; }
        public string MissText { get; set; }
        public int Gold { get; set; }
        public string Environment { get; set; }
        public int Level { get; set; }
    }
}
