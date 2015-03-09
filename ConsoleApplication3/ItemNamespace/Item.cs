using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaManager.PlayerNamespace;

namespace ArenaManager.ItemNamespace
{
    public abstract class Item
    {
        public String ItemID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }

        public virtual String PrintableDescription()
        {
            return Name + " - " + Description;
        }
    }
}
