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
using ProjectRPG.Events;

namespace ProjectRPG.Game
{
    public class Player
    {
        public string PlayerClassName { get; set; }
        public Hero<Weapon, Armor> PlayerHero { get; set; }
        public bool Death { get; set; }
        public Player() { }
        
        public async Task ChooseHero()
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
            else if (heroClass == "2")
            {
                PlayerClassName = "SORCERER";
                PlayerHero = new Sorcerer(userName);
            }
            else if (heroClass == "3")
            {
                PlayerClassName = "ROGUE";
                PlayerHero = new Rogue(userName);
            }
            else
            {           
                Console.Clear();
                Console.WriteLine("Wrong button, try again...");
                await ChooseHero();
            }
            Console.Clear();
        }
        public void ShowHero()
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine($" {PlayerHero.Name}  Lvl: {PlayerHero.Level}                 {PlayerClassName}       ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("                      STATISTICS                          ");
            Console.WriteLine($" HEALTH    :  {PlayerHero.MaxHP}                  Strength   : {PlayerHero.Strength}    ");
            Console.WriteLine($" MANA      :  {PlayerHero.MaxMP}                  Agility    : {PlayerHero.Agility}     ");
            Console.WriteLine($" ATTACK    :  {PlayerHero.Attack}                  Intelligence: {PlayerHero.Intelligence}");
            Console.WriteLine($" DEFENCE   :  {PlayerHero.Defence}                       ");
            Console.WriteLine($" DODGE RATE:  {PlayerHero.DodgeRate}                     ");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("                         EQ                               ");
            Console.WriteLine(" Choose an item to inspect:                               ");
            Console.WriteLine($" 1.WEAPON   : {PlayerHero.Weapon?.Name}                  ");
            Console.WriteLine($" 2.HELMET   : {PlayerHero.Helmet.Name}                   ");
            Console.WriteLine($" 3.NECKLACE : {PlayerHero.Necklace.Name}                 ");
            Console.WriteLine($" 4.ARMOR    : {PlayerHero.Armor?.Name}                   ");           
            Console.WriteLine($" 5.BOOTS    : {PlayerHero.Boots.Name}                    ");
            Console.WriteLine("==========================================================");
            Console.WriteLine("Inspect items: 1-5                                        ");
            Console.WriteLine("Open inventory: \"I\"                                     ");
            Console.WriteLine("PRESS \"X\" TO CONTINUE");
            ConsoleKeyInfo chosen = Console.ReadKey();
            if (chosen.Key.ToString() == "X")
            {
                Console.Clear();
                return;
            }
            else if (chosen.Key.ToString() == "I")
            {
                Console.Clear();
                PlayerHero.Inventory.OpenInventory();
                ShowHero();
            }
            else if (chosen.Key.ToString() == "D1" || chosen.Key.ToString() == "NumPad1") 
            {
                Console.Clear();
                ShowWeapon();
            }
            else if (chosen.Key.ToString() == "D2" || chosen.Key.ToString() == "NumPad2")
            {
                Console.Clear();
                ShowHelmet();
            }
            else if (chosen.Key.ToString() == "D3" || chosen.Key.ToString() == "NumPad3")
            {
                Console.Clear();
                ShowNecklace();
            }
            else if (chosen.Key.ToString() == "D4" || chosen.Key.ToString() == "NumPad4")
            {
                Console.Clear();
                ShowArmor();
            }
            else if (chosen.Key.ToString() == "D5" || chosen.Key.ToString() == "NumPad5")
            {
                Console.Clear();
                ShowBoots();
            }
            else
            {
                Console.Clear();
                ShowHero();
            }

        }

        public void ShowWeapon()
        {
            PlayerHero.Weapon?.PrintInfo();
            Console.WriteLine("Press \"C\" to go back or \"X\" to exit");
            ConsoleKeyInfo chosen = Console.ReadKey();
            if (chosen.Key.ToString() == "C")
            {
                Console.Clear();
                ShowHero();
            }
            else if (chosen.Key.ToString() == "X")
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                ShowWeapon();
            }
        }

        public void ShowArmor()
        {
            PlayerHero.Armor?.PrintInfo();
            Console.WriteLine("Press \"C\" to go back or \"X\" to exit");
            ConsoleKeyInfo chosen = Console.ReadKey();
            if (chosen.Key.ToString() == "C")
            {
                Console.Clear();
                ShowHero();
            }
            else if (chosen.Key.ToString() == "X")
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                ShowArmor();
            }
        }

        public void ShowHelmet()
        {
            PlayerHero.Helmet.PrintInfo();
            Console.WriteLine("Press \"C\" to go back or \"X\" to exit");
            ConsoleKeyInfo chosen = Console.ReadKey();
            if (chosen.Key.ToString() == "C")
            {
                Console.Clear();
                ShowHero();
            }
            else if (chosen.Key.ToString() == "X")
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                ShowHelmet();
            }
        }

        public void ShowNecklace()
        {
            PlayerHero.Necklace.PrintInfo();
            Console.WriteLine("Press \"C\" to go back or \"X\" to exit");
            ConsoleKeyInfo chosen = Console.ReadKey();
            if (chosen.Key.ToString() == "C")
            {
                Console.Clear();
                ShowHero();
            }
            else if (chosen.Key.ToString() == "X")
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                ShowNecklace();
            }
        }

        public void ShowBoots()
        {
            PlayerHero.Boots.PrintInfo();
            Console.WriteLine("Press \"C\" to go back or \"X\" to exit");
            ConsoleKeyInfo chosen = Console.ReadKey();
            if (chosen.Key.ToString() == "C")
            {
                Console.Clear();
                ShowHero();
            }
            else if (chosen.Key.ToString() == "X")
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                ShowBoots();
            }
        }
    }
}
