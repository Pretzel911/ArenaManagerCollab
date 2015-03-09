using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ArenaManager.ItemNamespace;
using System.Xml.Serialization;
using System.Xml;
using ArenaManager.PlayerNamespace;

namespace ArenaManager.GameStateNamespace
{
    class ItemManager
    {
        /****PROPERTIES****/
        public List<Item> GameItems;

        /****INITIALIZE****/
        public ItemManager()
        {
            GameItems = new List<Item>();
            LoadWeapons();
            LoadHealthRestore();
        }
        private void LoadWeapons()
        {
            //NOTE: This is a thing of beauty
            GameItems.AddRange(((WeaponsList)LoadXML(@"Data\ItemData\Weapon.xml", typeof(WeaponsList))).Weapons);
        }
        private void LoadHealthRestore()
        {
            GameItems.AddRange(((HealthRestoreItemsList)LoadXML(@"Data\ItemData\HealthRestore.xml", typeof(HealthRestoreItemsList))).HealthRestoreItems);
        }
        private object LoadXML(string path, Type type)
        {
            XmlSerializer XSer = new XmlSerializer(type);
            XmlReader reader = XmlReader.Create(path);
            return XSer.Deserialize(reader);
        }
        /****FUNCTIONS****/
        public void AddItemToPlayerPouch(Player myPlayer, string ItemID)
        {
            foreach (Item item in GameItems)
            {
                if(item.ItemID==ItemID)
                {
                    myPlayer.myPouch.myItems.Add(item);
                }
            }
        }
    }
}
