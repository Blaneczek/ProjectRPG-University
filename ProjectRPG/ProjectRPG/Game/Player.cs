using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Equipment.Armors;
using ProjectRPG.Heroes;

namespace ProjectRPG.Game
{
    public class Player 
    {
        public string PlayerClassName { get; set; }
        public Hero<Weapon,Armor> PlayerHero { get; set; }
        public Player() { }

        public void ChooseHero()
        {   Console.WriteLine("Enter your Hero's name: ");
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
                Sword sword1 = new Sword("Miecz", "Legendarny", "Kozak majonez", 100);
                HeavyArmor armor1 = new HeavyArmor("Zbroja", "Legendarny", "Kozak majonez", 20, 20);
                PlayerHero = new Warrior(userName, sword1, armor1, "ddddd");
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
            Console.WriteLine("|                      INVENTORY                         |");
            Console.WriteLine("| Choose an item to inspect:                             |");
            Console.WriteLine("| 1.WEAPON   : nazwa                                     |");
            Console.WriteLine("| 2.HELMET   : nazwa                                     |");
            Console.WriteLine("| 3.NECKLACE : nazwa                                     |");
            Console.WriteLine("| 4.ARMOR    : nazwa                                     |");           
            Console.WriteLine("| 5.BOOTS    : nazwa                                     |");
            Console.WriteLine("==========================================================");
            Console.WriteLine();
            Console.WriteLine("PRESS \"X\" TO EXIT");
            string chosenItem = Console.ReadLine();
            if (chosenItem == "x")
            {
                Console.Clear();
                return;
            }
            else if (chosenItem == "1") 
            {
                Console.Clear();
                ShowWeapon();
            }
            else if (chosenItem == "2")
            {
                Console.Clear();
                //ShowHelmet();
            }
            else if (chosenItem == "3")
            {
                Console.Clear();
                //ShowNecklace();
            }
            else if (chosenItem == "4")
            {
                Console.Clear();
                ShowArmor();
            }
            else if (chosenItem == "5")
            {
                Console.Clear();
               // ShowBoots();
            }

        }

        public void ShowWeapon()
        {
            Console.WriteLine("======================== WEAPON ============================");
            Console.WriteLine($"| NAME        :  {PlayerHero.Weapon.Name}                 |");
            Console.WriteLine($"| TYPE        :  {PlayerHero.Weapon.GetType().Name}       |");
            Console.WriteLine($"| RARITY      :  {PlayerHero.Weapon.Rarity}               |");
            Console.WriteLine($"| DESCRIPTION :  {PlayerHero.Weapon.Description}          |");
            Console.WriteLine($"| DAMAGE      :  {PlayerHero.Weapon.Damage}               |");
            Console.WriteLine("==========================================================");
            Console.WriteLine();
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
            Console.WriteLine("======================== WEAPON ============================");
            Console.WriteLine($"| NAME        :  {PlayerHero.Armor.Name}                                             |");
            Console.WriteLine($"| TYPE        :  {PlayerHero.Armor.GetType().Name}                                  |");
            Console.WriteLine($"| RARITY      :  {PlayerHero.Armor.Rarity}                                           |");
            Console.WriteLine($"| DESCRIPTION :  {PlayerHero.Armor.Description}                                               |");
            Console.WriteLine($"| DEFENCE     :  {PlayerHero.Armor.Defence}                                               |");
            Console.WriteLine($"| DODGE RATE  :  {PlayerHero.Armor.DodgeRate}                                               |");
            Console.WriteLine("==========================================================");
            Console.WriteLine();
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
