using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaManager.MonsterNamespace;
using System.Xml.Serialization;
using System.Xml;

namespace ArenaManager.GameStateNamespace
{
    class MonsterManager
    {
        
        /****PROPERTIES****/
        public List<Monster> GameMonsters;

        /****INITIALIZE****/
        public MonsterManager()
        {
            GameMonsters = new List<Monster>();
            LoadMonsters();
        }
        private void LoadMonsters()
        {
            GameMonsters.AddRange(((MonstersList)LoadXML(@"Data\MonsterData\Monster.xml", typeof(MonstersList))).Monsters);
        }
        private object LoadXML(string path, Type type)
        {
            XmlSerializer XSer = new XmlSerializer(type);
            XmlReader reader = XmlReader.Create(path);
            return XSer.Deserialize(reader);
        }
        /****FUNCTIONS****/
    }
}
