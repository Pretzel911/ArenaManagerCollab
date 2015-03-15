using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaManager.ItemNamespace;

namespace ArenaManager.PlayerNamespace
{
    public class Equipment
    {
        Player myPlayer;
        public Weapon myWeapon { get; set; }
        public Armor myHeadArmor { get; set; }
        public Armor myBodyArmor { get; set; }
        public Armor myArmArmor { get; set; }
        public Armor myLegArmor { get; set; }
        public Armor myFootArmor { get; set; }

        public Equipment(Player myPlayer)
        {
            this.myPlayer = myPlayer;
        }
        public void DisplayEquipment()
        {
            Console.WriteLine("Equipment:");
            if(myWeapon!=null)
            {
                Console.Write("Weapon: " + myWeapon.Name + " " + myWeapon.Description);
            }
            if(myHeadArmor!=null)
            {
                Console.Write("Head: " + myHeadArmor.Name + " " + myHeadArmor.Description);
            }
            if(myBodyArmor!=null)
            {
                Console.Write("Body: " + myBodyArmor.Name + " " + myBodyArmor.Description);
            }
            if (myArmArmor != null)
            {
                Console.Write("Arms: " + myArmArmor.Name + " " + myArmArmor.Description);
            }
            if (myLegArmor != null)
            {
                Console.Write("Legs: " + myLegArmor.Name + " " + myLegArmor.Description);
            }
            if (myFootArmor != null)
            {
                Console.Write("Feet: " + myFootArmor.Name + " " + myFootArmor.Description);
            }
            Console.ReadKey();
        }
        public void EquipItem(IEquippable item)
        {
            CheckWeapon(item);
            CheckArmor(item);
        }
        private void CheckWeapon(IEquippable item)
        {
            Weapon weapon = item as Weapon;
            if(weapon!=null)
            {
                ChangeWeapon(weapon);
            }
        }

        private void ChangeWeapon(Weapon weapon)
        {
            if (myWeapon != null)
            {
                myWeapon.UnEquip(myPlayer);
            }
            myWeapon = weapon;
            myWeapon.Equip(myPlayer);
        }
        private void CheckArmor(IEquippable item)
        {
            Armor armor = item as Armor;
            if (armor != null)
            {
                switch(armor.ArmorType)
                {
                    case ArmorEnum.Head:
                        ChangeHeadArmor(armor);
                        break;
                    case ArmorEnum.Body:
                        ChangeBodyArmor(armor);
                        break;
                    case ArmorEnum.Arms:
                        ChangeArmArmor(armor);
                        break;
                    case ArmorEnum.Legs:
                        ChangeLegArmor(armor);
                        break;
                    case ArmorEnum.Feet:
                        ChangeFootArmor(armor);
                        break;
                }
            }
        }

        private void ChangeFootArmor(Armor armor)
        {
            if (myFootArmor != null)
            {
                myFootArmor.UnEquip(myPlayer);
            }
            myFootArmor = armor;
            myFootArmor.Equip(myPlayer);
        }

        private void ChangeLegArmor(Armor armor)
        {
            if (myLegArmor != null)
            {
                myLegArmor.UnEquip(myPlayer);
            }
            myLegArmor = armor;
            myLegArmor.Equip(myPlayer);
        }

        private void ChangeArmArmor(Armor armor)
        {
            if (myArmArmor != null)
            {
                myArmArmor.UnEquip(myPlayer);
            }
            myArmArmor = armor;
            myArmArmor.Equip(myPlayer);
        }

        private void ChangeBodyArmor(Armor armor)
        {
            if (myBodyArmor != null)
            {
                myBodyArmor.UnEquip(myPlayer);
            }
            myBodyArmor = armor;
            myBodyArmor.Equip(myPlayer);
        }

        private void ChangeHeadArmor(Armor armor)
        {
            if (myHeadArmor != null)
            {
                myHeadArmor.UnEquip(myPlayer);
            }
            myHeadArmor = armor;
            myHeadArmor.Equip(myPlayer);
        }
    }
}
