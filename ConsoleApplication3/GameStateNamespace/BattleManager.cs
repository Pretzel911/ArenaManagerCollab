﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaManager.MonsterNamespace;
using ArenaManager.PlayerNamespace;
using ArenaManager.ItemNamespace;

namespace ArenaManager.GameStateNamespace
{
    class BattleManager
    {
        Game myGame;
        Player myPlayer;
        Random Roll;

        int Damage { get; set; }
        String BattleInput { get; set; }
        int AgilityRoll { get; set; }
        int DamageRoll { get; set; }
        int DefenseRoll { get; set; }
        bool Missed { get; set; }
        Monster myMonster { get; set; }
        int MonsterHealth { get; set; }

        public BattleManager(Game myGame)
        {
            this.myGame = myGame;
            myPlayer = myGame.myPlayer;
            Roll = new Random();
            Missed = false;
        }

        public void RunBattle()
        {
            Console.Clear();

            GetBattleMonster();
            myPlayer.ActivateBuffs();
            while (MonsterHealth > 0)
            {
                PrintBattleOpening();
                GetPlayerBattleInput();
                ExecutePlayerAction();
                CheckMonsterAttack();
                Console.ReadKey();
                CheckBattleOver();
            }
        }

        private void PrintBattleOpening()
        {
            Console.Clear();
            myGame.PlayerStats();
            Console.WriteLine("\n\tName: {0}\n\tHealth: {1}", myMonster.Name, MonsterHealth);
            Console.WriteLine("type: \n\ta to attack\n\tr to run");
        }

        private void GetPlayerBattleInput()
        {
            BattleInput = Console.ReadLine();
            BattleInput.ToLower();
        }
        private void ExecutePlayerAction()
        {

            switch(BattleInput)
            {
                case "a":
                    CheckPlayerAttack();
                    break;
                case "healmetofull":
                    myGame.HealMetoFull();
                    break;
            }
        }
        private void GetBattleMonster()
        {
            myMonster = myGame.myMonsterManager.GetMonster(myPlayer.myMap.MapEnvironment, myPlayer.myMap.AreaMonsterLevel);
            MonsterHealth = myMonster.Health;
        }

        private void CheckPlayerAttack()
        {
            Console.WriteLine("You Lunge Forward and attack!");
            AgilityRoll = Roll.Next(1, (myPlayer.PlayerAgility + 1));
            if (AgilityRoll <= myMonster.Agility)
            {
                AgilityRoll = Roll.Next(0, 2);
                if (AgilityRoll == 1)
                {
                    Missed = true;
                }
            }
            if (Missed != true)
            {
                DamageRoll = Roll.Next(1, myPlayer.PlayerStrength + 1);
                DefenseRoll = Roll.Next(0, myMonster.Defense);
                Damage = DamageRoll - DefenseRoll;
                if (Damage <= 0)
                {
                    Damage = 1;
                }
                MonsterHealth = MonsterHealth - (Damage);
                Console.WriteLine("A solid blow for {0} Damage!", Damage);
            }
            else
            {
                Console.WriteLine("You missed spectacularily");
                Missed = false;
            }
        }

        private void CheckMonsterAttack()
        {
            Console.WriteLine(myMonster.AttackText);
            AgilityRoll = Roll.Next(1, myMonster.Agility + 1);
            if (AgilityRoll <= myPlayer.PlayerAgility)
            {
                AgilityRoll = Roll.Next(0, 2);
                if (AgilityRoll == 1)
                {
                    Missed = true;
                }
            }
            if (Missed != true)
            {
                DamageRoll = Roll.Next(1, myMonster.Strength + 1);
                DefenseRoll = Roll.Next(0, myPlayer.PlayerDefense);
                Damage = DamageRoll - DefenseRoll;
                if (Damage <= 0) { Damage = 1; }
                myPlayer.PlayerCurrentHealth = myPlayer.PlayerCurrentHealth - (Damage);
                Console.WriteLine(myMonster.HitText + " {0} Damage!", Damage);
            }
            else
            {
                Console.WriteLine(myMonster.MissText); Missed = false;
            }
        }

        private void CheckBattleOver()
        {
            if (MonsterHealth <= 0)
            {
                ExecutePlayerWins();
            }
            if (myPlayer.PlayerCurrentHealth <= 0)
            {
                ExecutePlayerLoses();
            }
        }

        private void ExecutePlayerWins()
        {
            myPlayer.PlayerExperience = myPlayer.PlayerExperience + myMonster.Experience;
            myPlayer.PlayerGold = myPlayer.PlayerGold + myMonster.Gold;
            Console.WriteLine("You defeated {1}!\nYou gained {0} Experience", myMonster.Experience, myMonster.Name);
            Console.WriteLine("You received {0} gold", myMonster.Gold);
            PerformLootLogic();
            myPlayer.UpdateBuffs();
            Console.ReadKey();
            myGame.ClearMenuWithMap();
        }
        private void PerformLootLogic()
        {
            Item tempItem;
            foreach(MonsterLoot loot in myMonster.LootList)
            {
                if(Roll.Next(0,1000)<loot.DropChance*1000)
                {
                    tempItem = myGame.myItemManager.GetItemByID(loot.ItemID);
                    Console.WriteLine(myMonster.Name + " dropped a " + tempItem.Name + ".");
                    myPlayer.myPouch.myItems.Add(tempItem);
                }
            }
        }
        private void ExecutePlayerLoses()
        {
            Console.WriteLine("The monster has defeated you!");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
