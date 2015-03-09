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
    class MapManager
    {
        /****Properties****/
        public List<Map> MapLocations;
        /****Initialize****/
        public MapManager()
        {
            MapLocations = new List<Map>;
            LoadMapLocations();
        }
        private void LoadMapLocations()
        {
            MapLocations.AddRange((()))
        }
    }
}