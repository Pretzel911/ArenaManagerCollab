using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaManager
{
    class Monsters
    {
        public string MonsterName { get; set; }
        public int MonsterHealth { get; set; }
        public int MonsterStrength { get; set; }
        public int MonsterAgility { get; set; }
        public int MonsterDefense { get; set; }
        public int MonsterExperience { get; set; }
        public string AttackText { get; set; }
        public string HitText { get; set; }
        public string MissText { get; set; }
        public int MonsterGold { get; set; }
        public string MonsterEnvironment { get; set; }
        public int MonsterLevel { get; set; }

        public Monsters(int roll)
        {
            #region //MONSTERLEVEL 1
            if (roll == 1)
            { 
                //Slime
                Slime();
            }
            if (roll == 2)
            {
                //RatHorde
                RatHorde();
            }
            if (roll == 3)
            {
                //Gray Wolf
                GrayWolf();
            }
            if (roll == 4)
            {
                //ArmoredBeetle
                ArmoredBeetle();
            }
            if (roll == 5)
            {
                //KingSlime
                KingSlime();
            }
            #endregion 
            #region            //MONSTERLEVEL 2
            if (roll == 6)
            {
                //HobbGoblin
                PlaceHolderMonster();
            }
            if (roll == 7)
            {
                //Hippogriff
                PlaceHolderMonster();
            }
            if (roll == 8)
            {
                //Harpy
                PlaceHolderMonster();
            }
            if (roll == 9)
            {
                //Iron Kobra
                PlaceHolderMonster();
            }
            if (roll == 10)
            {
                //HobbGoblinWarchief
                PlaceHolderMonster();
            }
            #endregion
        }
        public void Slime()
        {
            MonsterName = "Slime";
            MonsterHealth = 5;
            MonsterStrength = 1;
            MonsterDefense = 1;
            MonsterAgility = 1;
            MonsterExperience = 1;
            AttackText = "The Slime rolls towards you!";
            MissText = "...and keeps on rolling right by you...";
            HitText = "Slams squishily in to your kneecaps!";
            MonsterEnvironment = "Grass";
            MonsterLevel = 1;
            MonsterGold = 1;
        }
        public void RatHorde()
        {
            MonsterName = "Horde Of Rats";
            MonsterHealth = 7;
            MonsterStrength = 2;
            MonsterDefense = 1;
            MonsterAgility = 5;
            MonsterExperience = 4;
            AttackText = "The rat hordes climbs on you and begins gnawing.";
            MissText = "They just can't seem to sink their teeth into you.";
            HitText = "They went for your eyes!!!!";
            MonsterEnvironment = "Sewer";
            MonsterLevel = 1;
            MonsterGold = 3;
        }
        public void GrayWolf()
        {
            MonsterName = "Gray Wolf";
            MonsterHealth = 9;
            MonsterStrength = 3;
            MonsterDefense = 2;
            MonsterAgility = 4;
            MonsterExperience = 5;
            AttackText = "The Gray Wolf lunges at you";
            MissText = "You move nimbly out of the way";
            HitText = "It's teeth sink in to your flesh and it prepares another attack";
            MonsterEnvironment = "Forest";
            MonsterLevel = 1;
            MonsterGold = 5;
        }
        public void ArmoredBeetle()
        {
            MonsterName = "Armored Beetle";
            MonsterHealth = 10;
            MonsterStrength = 2;
            MonsterDefense = 8;
            MonsterAgility = 1;
            MonsterExperience = 6;
            AttackText = "The beetle tries to get its pincers around you.";
            MissText = "but it can't quite achieve it's goal";
            HitText = "The pincers start to crush you!";
            MonsterEnvironment = "Desert";
            MonsterLevel = 1;
            MonsterGold = 5;
        }
        public void KingSlime()
        {
            MonsterName = "King Slime";
            MonsterHealth = 15;
            MonsterStrength = 3;
            MonsterDefense = 3;
            MonsterAgility = 2;
            MonsterExperience = 6;
            AttackText = "The king slime rolls at you";
            MissText = "...and rolls on by...";
            HitText = "Its body burns like acid as he bounces off you,";
            MonsterEnvironment = "Grass";
            MonsterLevel = 1;
            MonsterGold = 8;
        }
        public void PlaceHolderMonster()
        {
            MonsterName = "Super King Slime";
            MonsterHealth = 15;
            MonsterStrength = 8;
            MonsterDefense = 6;
            MonsterAgility = 6;
            MonsterExperience = 15;
            AttackText = "The king slime rolls at you";
            MissText = "...and rolls on by...";
            HitText = "Its body burns like acid as he bounces off you,";
        }
    }
}
