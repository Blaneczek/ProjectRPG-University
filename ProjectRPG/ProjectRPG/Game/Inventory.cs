using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ProjectRPG.Game
{
    public class Inventory<WeaponType, ArmorType> where WeaponType : Weapon where ArmorType : Armor
    {
        public List<WeaponType> Weapons {  get; set; }
        public List<ArmorType> Armors { get; set; }
        public List<Helmet> Helmets { get; set; }
        public List<Necklace> Necklaces { get; set; }
        public List<Boot> Boots { get; set; }

        public Inventory() 
        {       
            Weapons = new List<WeaponType>();
            Armors = new List<ArmorType>();
            Helmets = new List<Helmet>();
            Necklaces = new List<Necklace>();
            Boots = new List<Boot>();
        }

        public void AddWeapon(WeaponType weapon) => Weapons.Add(weapon);
        public void RemoveWeapon(WeaponType weapon) => Weapons.Remove(weapon);
        public void PrintAllWeapons()
        {
            if (Weapons.Count > 0) 
            {
                Weapons.ForEach(item => item.PrintInfo());
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
                Console.Clear();
                OpenInventory();
            }
            else
            {
                Console.WriteLine("You don't have any weapons in inventory");
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
                Console.Clear();
                OpenInventory();
            }
        }

        public void AddArmor(ArmorType armor) => Armors.Add(armor);
        public void RemoveArmor(ArmorType armor) => Armors.Remove(armor);
        public void PrintAllArmors()
        {
            if (Armors.Count > 0)
            {
                Armors.ForEach(item => item.PrintInfo());
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
                Console.Clear();
                OpenInventory();
            }
            else
            {
                Console.WriteLine("You don't have any armors in inventory");
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
                Console.Clear();
                OpenInventory();
            }
        }

        public void AddHelmet(Helmet helmet) => Helmets.Add(helmet);
        public void RemoveHelmet(Helmet helmet) => Helmets.Remove(helmet);
        public void PrintAllHelmets()
        {
            if (Helmets.Count > 0)
            {
                Helmets.ForEach(item => item.PrintInfo());
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
                Console.Clear();
                OpenInventory();
            }
            else
            {
                Console.WriteLine("You don't have any helmets in inventory");
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
                Console.Clear();
                OpenInventory();
            }
        }

        public void AddNecklace(Necklace necklace) => Necklaces.Add(necklace);
        public void RemoveNecklace(Necklace necklace) => Necklaces.Remove(necklace);
        public void PrintAllNecklaces()
        {
            if (Necklaces.Count > 0)
            {
                Necklaces.ForEach(item => item.PrintInfo());
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
                Console.Clear();
                OpenInventory();
            }
            else
            {
                Console.WriteLine("You don't have any necklaces in inventory");
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
                Console.Clear();
                OpenInventory();
            }
        }

        public void AddBoots(Boot boots) => Boots.Add(boots);
        public void RemoveBoots(Boot boots) => Boots.Remove(boots);
        public void PrintAllBoots()
        {
            if (Boots.Count > 0)
            {
                Boots.ForEach(item => item.PrintInfo());
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
                Console.Clear();
                OpenInventory(); ;
            }
            else
            {
                Console.WriteLine("You don't have any boots in inventory");
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
                Console.Clear();
                OpenInventory();
            }
        }
        public void OpenInventory()
        {
            Console.WriteLine("========= INVENTORY =============");
            Console.WriteLine("| 1.Weapons                     |");
            Console.WriteLine("| 2.Helmets                     |");
            Console.WriteLine("| 3.Neklace                     |");
            Console.WriteLine("| 4.Armor                       |");
            Console.WriteLine("| 5.Boots                       |");
            Console.WriteLine("=================================");
            Console.WriteLine("Choose category: ");
            Console.WriteLine("Press \"X\" to exit");
            ConsoleKeyInfo chosen = Console.ReadKey();

            if (chosen.Key.ToString() == "X")
            {
                Console.Clear();
                return;
            }
            else if (chosen.Key.ToString() == "D1" || chosen.Key.ToString() == "NumPad1") 
            {
                Console.Clear();
                PrintAllWeapons();
            }
            else if (chosen.Key.ToString() == "D2" || chosen.Key.ToString() == "NumPad2") 
            {
                Console.Clear();
                PrintAllHelmets();
            }
            else if (chosen.Key.ToString() == "D3" || chosen.Key.ToString() == "NumPad3")
            {
                Console.Clear();
                PrintAllNecklaces();
            }
            else if (chosen.Key.ToString() == "D4" || chosen.Key.ToString() == "NumPad4")
            {
                Console.Clear();
                PrintAllArmors();
            }
            else if (chosen.Key.ToString() == "D5" || chosen.Key.ToString() == "NumPad5")
            {
                Console.Clear();
                PrintAllBoots();
            }
            else
            {
                Console.Clear();
                OpenInventory();
            }
        }
    }
}
