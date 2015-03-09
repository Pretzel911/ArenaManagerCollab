using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaManager.PlayerNamespace;

namespace ArenaManager.ItemNamespace
{
    interface IConsumable
    {
        void Consume(Player myPlayer);
    }
}
