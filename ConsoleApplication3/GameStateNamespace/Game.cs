using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaManager.PlayerNamespace;
using ArenaManager.MonsterNamespace;

namespace ArenaManager.GameStateNamespace
{
    class Game
    {

        Player myPlayer;
        Random roll;
        MapManager myMapManager;
        ItemManager myItemManager;
        MonsterManager myMonsterManager;
        MapNamespace.Maps myMap;

        public Game()
        {
            InitializeGame();
            StartGame();
        }

        private void InitializeGame()
        {
            myPlayer = new Player();
            roll = new Random();
            //string MapStart = "start";
            myMapManager = new MapManager();
            myItemManager = new ItemManager();
            myMonsterManager = new MonsterManager();
            myMap = myMapManager.MoveMap(myPlayer);
            ClearMenuWithMap();
            //TODO: Remove This
            myItemManager.AddItemToPlayerPouch(myPlayer, "HR1");
            myItemManager.AddItemToPlayerPouch(myPlayer, "W1");
        }
        public void StartGame()
        {
            int monsterLevel = 1;
            string input = "";
            string[] inputArray;
            Console.WriteLine("Remember to type help if you are stuck");

                while (input != "exit")
                {
                    #region Menu99
                    if (myMap.WhichMenu == 99)
                    {
                        Console.WriteLine("\n\n");
                        inputArray = Console.ReadLine().ToLower().Split(' ');
                        input = inputArray[0];
                        //input = input.ToLower(); See Above, classy!
                        if (input == "help")
                            HelpMenu();
                        else if (input == "upmonsterlevel")
                            UpMonsterLevelMenu(monsterLevel);
                        else if (input == "spendskill")
                            SpendSkillsMenu();
                        else if (input == "arena")
                            BattleHandlerMenu(monsterLevel);
                        else if (input == "inn")
                            StayAtInn();
                        else if (input == "clear")
                            ClearMenuWithMap();
                        else if (input == "levelup")
                            LevelUpMenu();
                        else if (input == "givemexp")
                            XpCheat();
                        else if (input == "displaypouch")
                            DisplayPouch();
                        else if (input == "useitem")
                            UseItem(inputArray[1]);
                        else if (input == "move")
                            MoveMapRegion();
                    }
                    #region Menu1
                    else if (myMap.WhichMenu == 1)
                    {
                        Console.WriteLine("\n\n");
                        inputArray = Console.ReadLine().ToLower().Split(' ');
                        input = inputArray[0];
                        if (input == "help")
                            HelpMenu();
                        else if (input == "spendskills")
                            SpendSkillsMenu();
                        else if (input == "clear")
                            ClearMenuWithMap();
                        else if (input == "displaypuch")
                            DisplayPouch();
                        else if (input == "useitem")
                            UseItem(inputArray[1]);
                        else if (input == "move")
                            MoveMapRegion();
                    }
                    #endregion
                }
            #endregion
        }


        #region Menu Items
        public void MoveMapRegion()
        {
            string movementInput;
            Console.WriteLine("Which direction? (n/s/e/w");
            movementInput = Console.ReadLine();
            if (movementInput == "n")
            {
                if (myPlayer.PlayerLocationX < 2)
                {
                    myPlayer.PlayerLocationY += 1;
                    myMapManager.MoveMap(myPlayer);
                }
            }
            else if (movementInput == "s")
            {
                if (myPlayer.PlayerLocationY > 0)
                {
                    myPlayer.PlayerLocationY -= 1;
                    myMapManager.MoveMap(myPlayer);
                }
            }
            else if (movementInput == "e")
            {
                if (myPlayer.PlayerLocationX < 2)
                {
                    myPlayer.PlayerLocationX += 1;
                    myMapManager.MoveMap(myPlayer);
                }
            }
            else if (movementInput == "w")
            {
                if (myPlayer.PlayerLocationX > 0)
                {
                    myPlayer.PlayerLocationX -= 1;
                    myMapManager.MoveMap(myPlayer);
                }
            }
        }
        private void ClearMenuWithMap()
        {
            Console.Clear();
            CurrentMap();
            PlayerStats();
        }
        private void ClearMenu()
        {
            Console.Clear();
            PlayerStats();
        }
        private static void HelpMenu()
        {
            Console.WriteLine("Current Commands: ");
            Console.WriteLine("Clear - Clears the screen");
            Console.WriteLine("Arena- Initiates a battle in the Arena");
            Console.WriteLine("Inn - Heal to full at the cost of 1 Experience per missing health");
            Console.WriteLine("LevelUp - If you have enough experience, levels you up!");
            Console.WriteLine("SpendSkill - If you have unused skill points, spend them here.");
            Console.WriteLine("UpMonsterLevel - Raises the Level of monsters you will fight\t ******WARNING DANGEROUS******");
            Console.WriteLine("DisplayPouch - Shows the contents of your pouch");
            Console.WriteLine("UseItem <PouchSlot> - Uses item in pouch slot (Example: \"UseItem 1\")");
        }
        private void UpMonsterLevelMenu(int monsterLevel)
        {
            monsterLevel = monsterLevel + 1;
        }
        private void SpendSkillsMenu()
        {
            ClearMenuWithMap();
            Console.WriteLine("\nUnused Skill Points: {0}", myPlayer.UnusedStatPoints);
            myPlayer.SpendSkills();
        }
        private void RestMenu() //Using XP to heal in the wild
        {
            if (myPlayer.PlayerCurrentHealth < myPlayer.PlayerMaxHealth)
            {
                int restExpCost = myPlayer.PlayerMaxHealth - myPlayer.PlayerCurrentHealth;
                myPlayer.PlayerCurrentHealth = myPlayer.PlayerMaxHealth;
                myPlayer.PlayerExperience = myPlayer.PlayerExperience - restExpCost;
                if (myPlayer.PlayerExperience < 0)
                {
                    myPlayer.PlayerExperience = 0;
                }
                ClearMenuWithMap();
            }
        }
        private void StayAtInn()
        {
            string innPut;
            Console.WriteLine("It will cost 10 gold to stay at the inn (yes/no)");
            innPut = Console.ReadLine();
            if (innPut == "yes")
            {
                if (myPlayer.PlayerGold >= 10)
                {
                    myPlayer.PlayerGold = myPlayer.PlayerGold - 10;
                    myPlayer.PlayerCurrentHealth = myPlayer.PlayerMaxHealth;
                }
                else { Console.WriteLine("You dont have enough money, why don't you go camping!"); }
            }
            else { }
            ClearMenuWithMap();
        }
        private void LevelUpMenu()
        {
            if (myPlayer.PlayerExperience >= ((myPlayer.PlayerLevel * 10)))
            {
                ClearMenu();
                myPlayer.LevelUp();
                ClearMenuWithMap();
            }
            else { Console.WriteLine("\tNot Enough Experience"); }
        }
        private void BattleHandlerMenu(int monsterLevel)
        {
            int damage;
            string battleInput;
            int agilityRoll;
            int damageRoll;
            int defenseRoll;
            int rolled = 1;

            bool missed = false;
            if (monsterLevel == 1)
            {
                rolled = roll.Next(1, 6);
            }
            if (monsterLevel == 2)
            {
                rolled = roll.Next(5, 11);
            }
            Console.Clear();

            Monster myMonster = myMonsterManager.GetMonster("Grass", 1);
            int MonsterHealth = myMonster.Health;//TODO: Make an actual copy of the object
            
            PlayerStats();
            Console.WriteLine("\n\tName: {0}\n\tHealth: {1}", myMonster.Name, MonsterHealth);

            while (MonsterHealth > 0)
            {
                Console.Clear();
                PlayerStats();
                Console.WriteLine("\n\tName: {0}\n\tHealth: {1}", myMonster.Name, MonsterHealth);
                Console.WriteLine("type: \n\ta to attack\n\tr to run");
                battleInput = Console.ReadLine();
                battleInput.ToLower();
                if (battleInput == "healmetofull")
                    HealMetoFull();
                else if (battleInput == "a")
                {
                    Console.WriteLine("You Lunge Forward and attack!");
                    agilityRoll = roll.Next(1, (myPlayer.PlayerAgility + 1));
                    if (agilityRoll <= myMonster.Agility)
                    {
                        agilityRoll = roll.Next(0, 2);
                        if (agilityRoll == 1)
                        {
                            missed = true;
                        }
                    }
                    if (missed != true)
                    {
                        damageRoll = roll.Next(1, myPlayer.PlayerStrength + 1);
                        defenseRoll = roll.Next(0, myMonster.Defense);
                        damage = damageRoll - defenseRoll;
                        if (damage <= 0) { damage = 1; }
                        MonsterHealth = MonsterHealth - (damage);
                        Console.WriteLine("A solid blow for {0} Damage!", damage);
                    }
                    else { Console.WriteLine("You missed spectacularily"); missed = false; }

                    Console.WriteLine(myMonster.AttackText);
                    agilityRoll = roll.Next(1, myMonster.Agility + 1);
                    if (agilityRoll <= myPlayer.PlayerAgility)
                    {
                        agilityRoll = roll.Next(0, 2);
                        if (agilityRoll == 1)
                        {
                            missed = true;
                        }
                    }
                    if (missed != true)
                    {
                        damageRoll = roll.Next(1, myMonster.Strength + 1);
                        defenseRoll = roll.Next(0, myPlayer.PlayerDefense);
                        damage = damageRoll - defenseRoll;
                        if (damage <= 0) { damage = 1; }
                        myPlayer.PlayerCurrentHealth = myPlayer.PlayerCurrentHealth - (damage);
                        Console.WriteLine(myMonster.HitText + " {0} Damage!", damage);
                    }
                    else 
                    { 
                        Console.WriteLine(myMonster.MissText); missed = false; 
                    }
                    Console.ReadKey();
                    if (MonsterHealth <= 0)
                    {
                        myPlayer.PlayerExperience = myPlayer.PlayerExperience + myMonster.Experience;
                        myPlayer.PlayerGold = myPlayer.PlayerGold + myMonster.Gold;
                        Console.WriteLine("You defeated {1}!\nYou gained {0} Experience", myMonster.Experience, myMonster.Name);
                        Console.WriteLine("You recieved {0} gold", myMonster.Gold);
                        Console.ReadKey();
                        ClearMenuWithMap();
                    }
                    if (myPlayer.PlayerCurrentHealth <= 0)
                    {
                        Console.WriteLine("The monster has defeated you!");
                        Console.ReadKey();
                        Environment.Exit(1);

                    }
                }
            }
        }
        private void DisplayPouch()
        {
            myPlayer.myPouch.DisplayPouch();
        }
        private void UseItem(string itemSlot)
        {
            myPlayer.myPouch.UseItem(Convert.ToInt32(itemSlot));
        }


#endregion
        //
        #region Secret Menu
        private void XpCheat()
        {
            myPlayer.PlayerExperience = 100;
            Console.Clear();
            PlayerStats();
            Console.WriteLine("\n!!!God Damn Cheater!!!");
        }
        private void HealMetoFull()
        {
            myPlayer.PlayerCurrentHealth = myPlayer.PlayerMaxHealth;
        }
        #endregion
        //
        #region Useful Game Methods
        public void PlayerStats()
        {
            Console.WriteLine("\n\tLevel: {7}\n\tName: {0}\n\tHealth: {1}/{6}\n\tStrength: {2}\n\tDefense: {3}\n\tAgility: {4}\n\tExperience: {5}\n", myPlayer.PlayerName, myPlayer.PlayerCurrentHealth, myPlayer.PlayerStrength, myPlayer.PlayerDefense, myPlayer.PlayerAgility, myPlayer.PlayerExperience,myPlayer.PlayerMaxHealth,myPlayer.PlayerLevel);
        }
        public void CurrentMap()
        {
            Console.WriteLine("\n\t{0}", myMap.LocationDescription);
        }
        #endregion
    }
}
