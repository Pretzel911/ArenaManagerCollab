using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaManager.PlayerNamespace
{
    public class Player
    {
        public int PlayerLevel { get; set; }
        public string PlayerName { get; set; }
        public int PlayerMaxHealth { get; set; }
        public int PlayerCurrentHealth { get; set; }
        public int PlayerStrength { get; set; }
        public int PlayerDefense { get; set; }
        public int PlayerAgility { get; set; }
        public int PlayerExperience { get; set; }
        public int UnusedStatPoints { get; set; }
        public int PlayerGold { get; set; }
        public Pouch myPouch { get; set; }
        public int PlayerLocationX { get; set; }
        public int PlayerLocationY { get; set; }

        public Player()
        {
            CreatePlayer();
        }
        public void CreatePlayer ()
        {

            int strength;
            int agility;
            int defense;
            int health;
            string name;
            string testNumber;
            int checkOverUse;

            Console.WriteLine("Please Enter Your Character's Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Please Distribute 10 Points between Strength, Agility, and Defense");
            
            Console.WriteLine("Strength: ");
            testNumber = Console.ReadLine();
            if (int.TryParse(testNumber, out strength)) { }

            Console.WriteLine("Agility: ");
            testNumber = Console.ReadLine();
            if (int.TryParse(testNumber, out agility)) { }

            Console.WriteLine("Defense: ");
            testNumber = Console.ReadLine();
            if (int.TryParse(testNumber, out defense)) { }

            health = 10;

            checkOverUse = agility + strength + defense;
            if (checkOverUse > 10)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You have allocated too many points");
                Console.WriteLine("Would you like to try again (yes or no");
                testNumber = Console.ReadLine();
                testNumber = testNumber.ToLower();
                if (testNumber == "yes")
                {
                    CreatePlayer();
                }
                if (testNumber == "no")
                {
                    Environment.Exit(1);
                }
                else { CreatePlayer(); }
            }
            if (checkOverUse == 10)
            {
                PlayerName = name;
                PlayerStrength = strength;
                PlayerAgility = agility;
                PlayerDefense = defense;
                PlayerMaxHealth = health;
                PlayerCurrentHealth = PlayerMaxHealth;
                PlayerExperience = 0;
                PlayerLevel = 1;
                PlayerGold = 0;
                UnusedStatPoints = 0;
                myPouch = new Pouch(this);
                PlayerLocationX = 0;
                PlayerLocationY = 0;
            }
            else
            {
                Console.WriteLine("Looks like you missed some points, try again");
                //TODO: this is recursive and is not desired, change to a loop
                CreatePlayer();
            }
        }
        public void LevelUp()
        {
            int spendStat = 0;
            string spendStatTest;
            UnusedStatPoints = UnusedStatPoints + 3;
            Console.WriteLine("Spend your unused stat points");
            Console.WriteLine("You have {0}", UnusedStatPoints);
            
            Console.WriteLine("Strength: ");
            spendStatTest = Console.ReadLine();

            if (int.TryParse(spendStatTest, out spendStat)) { }
            if (UnusedStatPoints >= spendStat)
            {
                UnusedStatPoints = UnusedStatPoints - spendStat;
                PlayerStrength = PlayerStrength + spendStat;
            }

            Console.WriteLine("Stat points left to allocate: {0}", UnusedStatPoints);
            spendStat = 0;
            Console.WriteLine("Agility: ");
            spendStatTest = Console.ReadLine();

            if (int.TryParse(spendStatTest, out spendStat)) { }
            if (UnusedStatPoints >= spendStat)
            {
                UnusedStatPoints = UnusedStatPoints - spendStat;
                PlayerAgility = PlayerAgility + spendStat;
            }

            Console.WriteLine("Stat points left to allocate: {0}", UnusedStatPoints);
            spendStat = 0;
            Console.WriteLine("Defense: ");
            spendStatTest = Console.ReadLine();

            if (int.TryParse(spendStatTest, out spendStat)) { }
            if (UnusedStatPoints >= spendStat)
            {
                UnusedStatPoints = UnusedStatPoints - spendStat;
                PlayerDefense = PlayerDefense + spendStat;
            }
            PlayerMaxHealth = PlayerMaxHealth + 5;
            PlayerCurrentHealth = PlayerMaxHealth;
            PlayerExperience = PlayerExperience - ((PlayerLevel * 10));
            PlayerLevel = PlayerLevel + 1;
            Console.WriteLine("Unused Stat Points: {0}", UnusedStatPoints);

            
        }
        public void SpendSkills()
        {
            int spendStat;
            string spendStatTest;

            Console.WriteLine("Strength: ");
            spendStatTest = Console.ReadLine();

            if (int.TryParse(spendStatTest, out spendStat)) { }
            if (UnusedStatPoints >= spendStat)
            {
                UnusedStatPoints = UnusedStatPoints - spendStat;
                PlayerStrength = PlayerStrength + spendStat;
            }

            Console.WriteLine("Stat points left to allocate: {0}", UnusedStatPoints);
            spendStat = 0;
            Console.WriteLine("Agility: ");
            spendStatTest = Console.ReadLine();

            if (int.TryParse(spendStatTest, out spendStat)) { }
            if (UnusedStatPoints >= spendStat)
            {
                UnusedStatPoints = UnusedStatPoints - spendStat;
                PlayerAgility = PlayerAgility + spendStat;
            }

            Console.WriteLine("Stat points left to allocate: {0}", UnusedStatPoints);
            spendStat = 0;
            Console.WriteLine("Defense: ");
            spendStatTest = Console.ReadLine();

            if (int.TryParse(spendStatTest, out spendStat)) { }
            if (UnusedStatPoints >= spendStat)
            {
                UnusedStatPoints = UnusedStatPoints - spendStat;
                PlayerDefense = PlayerDefense + spendStat;
            }
        }
    }
}
