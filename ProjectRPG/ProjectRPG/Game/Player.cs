using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Equipment.Armors;
using ProjectRPG.Heroes;
using System.Numerics;

namespace ProjectRPG.Game
{
    public class Player
    {
        public string PlayerClassName { get; set; }
        public Hero<Weapon, Armor> PlayerHero { get; set; }
        public Player() { }

        public void ChooseHero()
        {   
            Console.WriteLine("Enter your Hero's name: ");
            string userName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Choose your Hero's class:");
            Console.WriteLine();
            Console.WriteLine(" |=======  1  =======|        \"Mighty Brawler\"");
            Console.WriteLine(" |      WARRIOR      | The Warrior class is a powerful");
            Console.WriteLine(" |-------------------| melee combatant known for their");
            Console.WriteLine(" | Strength:     10  | strength, resilience, and heavy");
            Console.WriteLine(" | Agility:      6   | armor.                         ");
            Console.WriteLine(" | Intelligence: 4   |                                ");
            Console.WriteLine(" |-------------------|                                ");
            Console.WriteLine();
            Console.WriteLine(" |=======  2  =======|        \"Arcane Sorcerer\"");
            Console.WriteLine(" |      Sorcerer     | The Sorcerer class is a master of");
            Console.WriteLine(" |-------------------| arcane arts, wielding powerful ");
            Console.WriteLine(" | Strength:     4   | spells to manipulate elements  ");
            Console.WriteLine(" | Agility:      6   | and unleash destruction upon   ");
            Console.WriteLine(" | Intelligence: 10  | enemies.                       ");
            Console.WriteLine(" |-------------------|                                ");
            Console.WriteLine();
            Console.WriteLine(" |=======  3  =======|        \"Nimble Hunter\"");
            Console.WriteLine(" |       ROUGE       | The Rogue class is a cunning   ");
            Console.WriteLine(" |-------------------| and agile fighter who specializes ");
            Console.WriteLine(" | Strength:     6   | in stealth, precision strikes, ");
            Console.WriteLine(" | Agility:      10  | and evasive maneuvers.         ");
            Console.WriteLine(" | Intelligence: 4   |                                ");
            Console.WriteLine(" |-------------------|                                ");

            string heroClass = Console.ReadLine();
            if (heroClass == "1")
            {
                PlayerClassName = "WARRIOR";                
                PlayerHero = new Warrior(userName);
            } 
            Console.Clear();
        }
        public void ShowHero()
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine($"| {PlayerHero.Name}  Lvl: {PlayerHero.Level}                      {PlayerClassName}      |");
            Console.WriteLine("|--------------------------------------------------------|");
            Console.WriteLine("|                      STATISTICS                        |");
            Console.WriteLine($"| HEALTH    :  {PlayerHero.MaxHP}                   Strength:     {PlayerHero.Strength} |");
            Console.WriteLine($"| MANA      :  {PlayerHero.MaxMP}                     Agility:     {PlayerHero.Agility}  |");
            Console.WriteLine($"| ATTACK    :  {PlayerHero.Attack}                   Intelligence: {PlayerHero.Intelligence}  |");
            Console.WriteLine($"| DEFENCE   :  {PlayerHero.Defence}                                   |");
            Console.WriteLine($"| DODGE RATE:  {PlayerHero.DodgeRate}                                  |");
            Console.WriteLine("|--------------------------------------------------------|");
            Console.WriteLine("|                         EQ                             |");
            Console.WriteLine("| Choose an item to inspect:                             |");
            Console.WriteLine($"| 1.WEAPON   : {PlayerHero.Weapon.Name}                                     |");
            Console.WriteLine($"| 2.HELMET   : {PlayerHero.Helmet.Name}                                     |");
            Console.WriteLine($"| 3.NECKLACE : {PlayerHero.Necklace.Name}                                     |");
            Console.WriteLine($"| 4.ARMOR    : {PlayerHero.Armor.Name}                                     |");           
            Console.WriteLine($"| 5.BOOTS    : {PlayerHero.Boots.Name}                                     |");
            Console.WriteLine("==========================================================");
            Console.WriteLine("Open inventory: \"I\"                                    |");
            Console.WriteLine("PRESS \"X\" TO EXIT");
            string chosen = Console.ReadLine();
            if (chosen == "x")
            {
                Console.Clear();
                return;
            }
            else if (chosen == "i")
            {
                Console.Clear();
                PlayerHero.Inventory.OpenInventory();
            }
            else if (chosen == "1") 
            {
                Console.Clear();
                ShowWeapon();
            }
            else if (chosen == "2")
            {
                Console.Clear();
                ShowHelmet();
            }
            else if (chosen == "3")
            {
                Console.Clear();
                ShowNecklace();
            }
            else if (chosen == "4")
            {
                Console.Clear();
                ShowArmor();
            }
            else if (chosen == "5")
            {
                Console.Clear();
                ShowBoots();
            }

        }

        public void ShowWeapon()
        {
            PlayerHero.Weapon.PrintInfo();
            Console.WriteLine("PRESS \"C\" TO GO BACK OR \"X\" TO EXIT");
            string a = Console.ReadLine();
            if (a == "c")
            {
                Console.Clear();
                ShowHero();
            }
            else if (a == "x")
            {
                Console.Clear();
                return;
            }
        }

        public void ShowArmor()
        {
            PlayerHero.Armor.PrintInfo();
            Console.WriteLine("PRESS \"C\" TO GO BACK OR \"X\" TO EXIT");
            string a = Console.ReadLine();
            if (a == "c")
            {
                Console.Clear();
                ShowHero();
            }
            else if (a == "x")
            {
                Console.Clear();
                return;
            }
        }

        public void ShowHelmet()
        {
            PlayerHero.Helmet.PrintInfo();
            Console.WriteLine("PRESS \"C\" TO GO BACK OR \"X\" TO EXIT");
            string a = Console.ReadLine();
            if (a == "c")
            {
                Console.Clear();
                ShowHero();
            }
            else if (a == "x")
            {
                Console.Clear();
                return;
            }
        }

        public void ShowNecklace()
        {
            PlayerHero.Necklace.PrintInfo();
            Console.WriteLine("PRESS \"C\" TO GO BACK OR \"X\" TO EXIT");
            string a = Console.ReadLine();
            if (a == "c")
            {
                Console.Clear();
                ShowHero();
            }
            else if (a == "x")
            {
                Console.Clear();
                return;
            }
        }

        public void ShowBoots()
        {
            PlayerHero.Boots.PrintInfo();
            Console.WriteLine("PRESS \"C\" TO GO BACK OR \"X\" TO EXIT");
            string a = Console.ReadLine();
            if (a == "c")
            {
                Console.Clear();
                ShowHero();
            }
            else if (a == "x")
            {
                Console.Clear();
                return;
            }
        }
    }
}
