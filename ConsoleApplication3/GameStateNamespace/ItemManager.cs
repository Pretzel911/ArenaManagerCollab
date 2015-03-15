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
            LoadArmors();
            LoadHealthRestore();
            LoadBuff();
        }
        private void LoadWeapons()
        {
            //NOTE: This is a thing of beauty
            GameItems.AddRange(((WeaponsList)LoadXML(@"Data\ItemData\Weapon.xml", typeof(WeaponsList))).Weapons);
        }
        private void LoadArmors()
        {
            //NOTE: This is a thing of beauty
            GameItems.AddRange(((ArmorsList)LoadXML(@"Data\ItemData\Armor.xml", typeof(ArmorsList))).Armors);
        }
        private void LoadHealthRestore()
        {
            GameItems.AddRange(((HealthRestoreItemsList)LoadXML(@"Data\ItemData\HealthRestore.xml", typeof(HealthRestoreItemsList))).HealthRestoreItems);
        }
        private void LoadBuff()
        {
            GameItems.AddRange(((BuffItemsList)LoadXML(@"Data\ItemData\Buff.xml", typeof(BuffItemsList))).BuffItems);
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
        public Item GetItemByID(String ID)
        {
            var FilteredList = GameItems.Where(x => x.ItemID==ID);
            return FilteredList.ToList()[0];
        }
    }
}
