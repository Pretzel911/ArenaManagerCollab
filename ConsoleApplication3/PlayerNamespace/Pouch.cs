using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaManager.ItemNamespace;

namespace ArenaManager.PlayerNamespace
{
    public class Pouch
    {
        Player myPlayer;
        public List<Item> myItems;

        public Pouch(Player myPlayer)
        {
            this.myPlayer = myPlayer;
            myItems = new List<Item>();
        }
        public void DisplayPouch()
        {
            if(myItems.Count!=0)
            { 
                for(int i=0;i<myItems.Count;i++)
                {
                    Console.WriteLine((i+1).ToString()+": "+myItems[i].PrintableDescription() + Environment.NewLine);
                }
            }
            else
            {
                Console.WriteLine("**Pouch Empty***" + Environment.NewLine);
            }

        }
        public void UseItem(int Slot)
        {
            IConsumable item = myItems[Slot - 1] as IConsumable;
            if(item!=null)
            {
                item.Consume(myPlayer);
                myItems.RemoveAt(Slot - 1);
            }
            else
            {
                Console.WriteLine("Item is not consumable");
            }
            
        }
    }
}
