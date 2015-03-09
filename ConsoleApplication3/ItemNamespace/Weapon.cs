using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaManager.PlayerNamespace;
using System.Xml.Serialization;

namespace ArenaManager.ItemNamespace
{
    [XmlRoot("Weapons")]
    public class WeaponsList
    {
        [XmlElement("Weapon")]
        public List<Weapon> Weapons { get; set; }
    }
    public class Weapon : Item, IEquippable
    {
        public int StrengthModifier { get; set; }

        public void Equip(Player myPlayer)
        {
            myPlayer.PlayerStrength += StrengthModifier;
        }
        public void UnEquip(Player myPlayer)
        {
            myPlayer.PlayerStrength -= StrengthModifier;
        }
    }
}
