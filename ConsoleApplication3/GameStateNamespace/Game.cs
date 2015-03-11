﻿using System;
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

        public Player myPlayer;
        Random Roll;
        public MapManager myMapManager;
        public ItemManager myItemManager;
        public MonsterManager myMonsterManager;
        MapNamespace.Maps myMap;

        public Game()
        {
            InitializeGame();
            StartGame();
        }

        private void InitializeGame()
        {
            myPlayer = new Player();
            Roll = new Random();
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
                    myMap = myMapManager.MoveMap(myPlayer);
                    
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
        public void ClearMenuWithMap()
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
            BattleManager myBattleManager = new BattleManager(this);
            myBattleManager.RunBattle();
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
        public  void HealMetoFull()
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
