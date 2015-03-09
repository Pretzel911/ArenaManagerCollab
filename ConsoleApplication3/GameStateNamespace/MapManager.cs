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
        public Maps MoveMap(int xLocation, int yLocation)
        {
            var FilteredList = MapLocations.Where(x => x.MapLocationX == xLocation && x.MapLocationY == yLocation);
            return FilteredList.ToList()[0];
        }
    }
}