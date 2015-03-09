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
        public void TestLinq()
        {
            //get all level 1 monsters
            Console.WriteLine("1st Query:");
            List<Monster> FilteredList = (List<Monster>)GameMonsters.Where(x => x.Level == 1);
            foreach(Monster m in FilteredList)
            {
                Console.Clear();
                Console.WriteLine(m.Name);
            }
            Console.ReadKey();
            //get all level 2 monsters
            Console.WriteLine("2nd Query:");
            FilteredList = (List<Monster>)GameMonsters.Where(x => x.Level == 2);
            foreach (Monster m in FilteredList)
            {
                Console.Clear();
                Console.WriteLine(m.Name);
            }
            Console.ReadKey();
            //get all level 1 monsters in Grass
            Console.WriteLine("3rd Query:");
            FilteredList = (List<Monster>)GameMonsters.Where(x => x.Level == 1&&x.Environment.ToLower()=="grass");
            foreach (Monster m in FilteredList)
            {
                Console.Clear();
                Console.WriteLine(m.Name);
            }
            Console.ReadKey();
        }
    }
}
