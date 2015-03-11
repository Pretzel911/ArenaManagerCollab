using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ArenaManager.ItemNamespace;
using System.Xml.Serialization;
using System.Xml;
using ArenaManager.MapNamespace;
using ArenaManager.PlayerNamespace;

namespace ArenaManager.GameStateNamespace
{
    class MapManager
    {
        /****Properties****/
        public List<Maps> MapLocations;
        /****Initialize****/
        public MapManager()
        {
            MapLocations = new List<Maps>();
            LoadMapLocations();
        }
        private void LoadMapLocations()
        {
            MapLocations.AddRange(((MapItemList)LoadXML(@"Data\MapData\Maps.xml", typeof(MapItemList))).MapList);
        }
        private object LoadXML(string path, Type type)
        {
            XmlSerializer XSer = new XmlSerializer(type);
            XmlReader reader = XmlReader.Create(path);
            return XSer.Deserialize(reader);
        }
        public void SetPlayerMap(Player myPlayer, int x, int y)
        {
            var FilteredList = MapLocations.Where(m => m.MapLocationX == x
                && m.MapLocationY == y);
            if (FilteredList.ToList().Count != 0)
            {
                myPlayer.myMap = FilteredList.ToList()[0];
            }
            else
            {
                Console.WriteLine("Teleportation Failed!");
            }
        }
        public void MovePlayerMap(Player myPlayer,int ChangeX, int ChangeY)
        {
            var FilteredList = MapLocations.Where(x => x.MapLocationX == myPlayer.myMap.MapLocationX+ChangeX 
                && x.MapLocationY == myPlayer.myMap.MapLocationY+ChangeY);
            if (FilteredList.ToList().Count != 0)
            {
                myPlayer.myMap = FilteredList.ToList()[0];
            }
            else
            {
                Console.WriteLine("You are held back by an invisible force!");
            }
        }
    }
}