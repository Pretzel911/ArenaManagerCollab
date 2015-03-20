using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaManager.PlayerNamespace;
using System.Xml.Serialization;

namespace ArenaManager.ItemNamespace
{
    [XmlRoot("Armors")]
    public class ArmorsList
    {
        [XmlElement("Armor")]
        public List<Armor> Armors { get; set; }
    }
    public class Armor : Item, IEquippable
    {
        public ArmorEnum ArmorType { get; set; }
        public int DefenseModifier { get; set; }

        public void Equip(Player myPlayer)
        {
            myPlayer.PlayerDefense += DefenseModifier;
            Console.WriteLine("Player equipped " + Name + ".");
        }
        public void UnEquip(Player myPlayer)
        {
            myPlayer.PlayerDefense -= DefenseModifier;
        }
    }
}
