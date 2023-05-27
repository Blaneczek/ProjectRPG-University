using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ProjectRPG.Heroes;
using ProjectRPG.Monsters;

namespace ProjectRPG.Game
{
    public class Fight
    {
        public Player Player { get; set; }
        public Monster Monster { get; set; }
        public double AmountOfAdditionalDamage { get; set; }
        public double DamageDealt { get; set; }
        public double AdditionalDamageTurns { get; set; }
        public bool RepeatFunction { get; set; }

        public Fight(Player player, Monster monster) 
        {
            Player = player;
            Monster = monster;
        }
        public void PrintBattleMenu()
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("                            COMBAT ENCOUNTER                               ");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("                                ROUND X                                    ");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("                                  VS                                       ");
            Console.WriteLine($"  {Player.PlayerHero.Name} lvl {Player.PlayerHero.Level}                           {Monster.Name} lvl {Monster.Level}");
            Console.WriteLine($"  HP: {Player.PlayerHero.CurrentHP}/{Player.PlayerHero.MaxHP}                        HP: {Monster.CurrentHP}/{Monster.MaxHP}");
            Console.WriteLine($"  MP: {Player.PlayerHero.CurrentMP}/{Player.PlayerHero.MaxMP}");
            Console.WriteLine("---------------------------------------------------------------------------");
        }

        public void PrintHeroTurn()
        {
            PrintBattleMenu();
            Console.WriteLine("            YOUR TURN            ");
            Console.WriteLine("========== Battle Menu ==========");
            Console.WriteLine("| 1. Normal Attack              |");
            Console.WriteLine("| 2. Special Attack [Costs 60MP]|");
            Console.WriteLine("| 3. Defensive Ability          |");
            Console.WriteLine($"| 4. Use Health Potion [{Player.PlayerHero.AmountOfHPPotions}/5]    |");
            Console.WriteLine($"| 5. Use Mana Potion   [{Player.PlayerHero.AmountOfMPPotions}/5]    |");
            Console.WriteLine("=================================");

            if (!RepeatFunction && AdditionalDamageTurns > 0)
            {
                Player.PlayerHero.CurrentHP -= AmountOfAdditionalDamage;
            }

            ConsoleKeyInfo choice = Console.ReadKey();
            if (choice.Key.ToString() == "D1" || choice.Key.ToString() == "NumPad1")
            {
                DamageDealt = Player.PlayerHero.NormalAttack(Monster);
                Console.Clear();
                PrintBattleMenu();
                Console.WriteLine($"Normal attack dealt: {DamageDealt} damage");
            }
            else if (choice.Key.ToString() == "D2" || choice.Key.ToString() == "NumPad2")
            {
                if (Player.PlayerHero.CurrentMP >= 60)
                {
                    DamageDealt = Player.PlayerHero.SpecialAttack(Monster);
                    Console.Clear();
                    PrintBattleMenu();
                    Console.WriteLine($"Special attack dealt: {DamageDealt} damage");
                }
                else
                {
                    RepeatFunction = true;
                    Console.WriteLine("Not enough MP! Press any key...");
                    Console.ReadKey();
                    Console.Clear();
                    PrintHeroTurn();

                }
            }
            else if (choice.Key.ToString() == "D3" || choice.Key.ToString() == "NumPad3")
            {
                Player.PlayerHero.AvoidAttack();
                Console.Clear();
                PrintBattleMenu();
                Console.WriteLine("You decided to protect yourself");
            }
            else if (choice.Key.ToString() == "D4" || choice.Key.ToString() == "NumPad4")
            {
                if (Player.PlayerHero.AmountOfHPPotions > 0)
                {
                    Player.PlayerHero.UseHPPotion();
                    Console.Clear();
                    PrintBattleMenu();
                    Console.WriteLine("You have used a HP potion");
                    Console.WriteLine(Player.PlayerHero.CurrentHP);
                }
                else
                {
                    RepeatFunction = true;
                    Console.WriteLine("You have run out of HP potions! Press any key...");
                    Console.ReadKey();
                    Console.Clear();
                    PrintHeroTurn();
                }
            }
            else if (choice.Key.ToString() == "D5" || choice.Key.ToString() == "NumPad5")
            {
                if (Player.PlayerHero.AmountOfMPPotions > 0)
                {
                    Player.PlayerHero.UseMPPotion();
                    Console.Clear();
                    PrintBattleMenu();
                    Console.WriteLine("You have used a MP potion");
                    Console.WriteLine(Player.PlayerHero.CurrentMP);
                }
                else
                {
                    RepeatFunction = true;
                    Console.WriteLine("You have run out of MP potions! Press any key...");
                    Console.ReadKey();
                    Console.Clear();
                    PrintHeroTurn();
                }
            }
            else
            {
                RepeatFunction = true;
                Console.Clear();
                PrintHeroTurn();
            }

            if (!RepeatFunction && AdditionalDamageTurns > 0)
            {
                Console.WriteLine($"Poison dealt: {AmountOfAdditionalDamage} damage");
                AdditionalDamageTurns--;
            }
            RepeatFunction = false;
        }

        public void PrintMonsterTurn()
        {
            PrintBattleMenu();
            Console.WriteLine("            ENEMY TURN            ");
            double DamageDealt = 0;

            Random rnd = new();
            int losuj = rnd.Next(1, 11);

            if (losuj >= 1 && losuj <= 7) //Normal attack
            {
                DamageDealt = Monster.NormalAttack(Player.PlayerHero);
                Console.Clear();
                PrintBattleMenu();
                if (Player.PlayerHero.Dodged)
                {
                    Console.WriteLine("You have dodged the opponent's attack and received 0 damage!");
                    Player.PlayerHero.Dodged = false;
                }
                else if (Player.PlayerHero.AbsoluteDefence)
                {
                    Console.WriteLine(Player.PlayerHero.AbsoluteDefenceDesc);
                }
                else
                {
                    Console.WriteLine($"{Monster.Name} dealt {DamageDealt} damage");
                }
            }
            else if (losuj >= 8) //SpecialAttack
            {
                DamageDealt = Monster.SpecialAttack(Player.PlayerHero);
                Console.Clear();
                PrintBattleMenu();
                if (Player.PlayerHero.Dodged)
                {
                    Console.WriteLine("You have dodged the opponent's attack and received 0 damage!");
                    Player.PlayerHero.Dodged = false;
                }
                else if (Player.PlayerHero.AbsoluteDefence)
                {
                    Console.WriteLine(Player.PlayerHero.AbsoluteDefenceDesc);
                }
                else
                {
                    Console.WriteLine($"{Monster.Name} dealt {DamageDealt} damage");
                    Console.WriteLine(Monster.SpecialAttackDesc);
                    if (Monster.GetType() == typeof(Spider))
                    {
                        AmountOfAdditionalDamage = DamageDealt / 10;
                        if (Player.PlayerHero.AbsoluteDefence == false)
                        {
                            AdditionalDamageTurns = 2;
                        }
                    }
                    else if (Monster.GetType() == typeof(Golem))
                    {
                        Console.WriteLine($"{Monster.Name} performs another turn!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        PrintMonsterTurn();
                    }
                }   
            }
        }

        public bool StartFight()
        {
            DamageDealt = 0;
            AmountOfAdditionalDamage = 0;
            AdditionalDamageTurns = 0;
            
            while (true)
            {
                PrintHeroTurn();
                if (Monster.CurrentHP <= 0) 
                {
                    Console.WriteLine();
                    Console.WriteLine($"{Monster.Name} DEFEATED!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return true;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                PrintMonsterTurn();
                if (Player.PlayerHero.AbsoluteDefence == true)
                {
                    Player.PlayerHero.AbsoluteDefence = false;
                }
                if (Player.PlayerHero.CurrentHP <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("YOU HAVE LOST!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return false;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
