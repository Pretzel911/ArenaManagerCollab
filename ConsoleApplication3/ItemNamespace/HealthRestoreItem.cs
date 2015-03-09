using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaManager.PlayerNamespace;
using System.Xml.Serialization;

namespace ArenaManager.ItemNamespace
{
    [XmlRoot("HealthRestoreItems")]
    public class HealthRestoreItemsList
    {
        [XmlElement("HealthRestoreItem")]
        public List<HealthRestoreItem> HealthRestoreItems { get; set; }
    }
    public class HealthRestoreItem : Item, IConsumable
    {
        public int RestoreAmount { get; set; }

        public void Consume(Player myPlayer)
        {
            if(myPlayer.PlayerCurrentHealth+RestoreAmount>=myPlayer.PlayerMaxHealth)
            {
                myPlayer.PlayerCurrentHealth = myPlayer.PlayerMaxHealth;
            }
            else
            {
                myPlayer.PlayerCurrentHealth = myPlayer.PlayerCurrentHealth + RestoreAmount;
            }
            Console.WriteLine("Tasty, player restored " + RestoreAmount.ToString() + " health with " + Name + ".");
        }
    }
}
