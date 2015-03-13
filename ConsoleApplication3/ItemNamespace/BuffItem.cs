using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaManager.PlayerNamespace;
using System.Xml.Serialization;

namespace ArenaManager.ItemNamespace
{
    [XmlRoot("BuffItems")]
    public class BuffItemsList
    {
        [XmlElement("BuffItem")]
        public List<BuffItem> BuffItems { get; set; }
    }
    public class BuffItem : Item, IConsumable
    {
        public Stats BuffStat { get; set; }
        public int BuffAmount { get; set; }
        public int Turns { get; set; }

        public void Consume(Player myPlayer)
        {
            if(myPlayer.myBuffs.Count==0)
            {
                PlayerBuff tempBuff = new PlayerBuff();
                tempBuff.StatBuffed = BuffStat;
                tempBuff.AmountBuffed = BuffAmount;
                tempBuff.BattlesRemaining = Turns;
                myPlayer.myBuffs.Add(tempBuff);

                Console.WriteLine("Tasty, player "+BuffStat.ToString()+ " has been increased by " + BuffAmount.ToString() + " for "+ Turns.ToString() +" turns by " + Name + ".");
            }
            else
            {
                Console.WriteLine(myPlayer.PlayerName + " can only have one buff at a time.");
            }
            //if (myPlayer.PlayerCurrentHealth + RestoreAmount >= myPlayer.PlayerMaxHealth)
            //{
            //    myPlayer.PlayerCurrentHealth = myPlayer.PlayerMaxHealth;
            //}
            //else
            //{
            //    myPlayer.PlayerCurrentHealth = myPlayer.PlayerCurrentHealth + RestoreAmount;
            //}
            //Console.WriteLine("Tasty, player img " + RestoreAmount.ToString() + " health with " + Name + ".");
        }
    }
    
}
