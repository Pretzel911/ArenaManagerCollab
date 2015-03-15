using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaManager.PlayerNamespace;

namespace ArenaManager.ItemNamespace
{
    public interface IEquippable
    {
        void Equip(Player myPlayer);
        void UnEquip(Player myPlayer);
    }
}
