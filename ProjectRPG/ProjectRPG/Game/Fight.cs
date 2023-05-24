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
        public double AmountOfAdditionalDamage { get; set; }
        public double DamageDealt { get; set; }
        public double AdditionalDamageTurns { get; set; }
        public bool RepeatFunction { get; set; }
        public void PrintBattleMenu(Player player, Monster monster)
        {
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("                            COMBAT ENCOUNTER                               ");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("                                ROUND X                                    ");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("                                  VS                                       ");
            Console.WriteLine($"  {player.PlayerHero.Name} {player.PlayerHero.Level}                                                  {monster.Name} {monster.Level}");
            Console.WriteLine($"  HP: {player.PlayerHero.CurrentHP}/{player.PlayerHero.MaxHP}                                            HP: {monster.CurrentHP}/{monster.MaxHP}");
            Console.WriteLine($"  MP: {player.PlayerHero.CurrentMP}/{player.PlayerHero.MaxMP}");
            Console.WriteLine("---------------------------------------------------------------------------");
        }

        public void PrintHeroTurn(Player player, Monster monster)
        {
            PrintBattleMenu(player, monster);
            Console.WriteLine("            YOUR TURN            ");
            Console.WriteLine("========== Battle Menu ==========");
            Console.WriteLine("| 1. Normal Attack              |");
            Console.WriteLine("| 2. Special Attack [Costs 60MP]|");
            Console.WriteLine("| 3. Defensive Ability          |");
            Console.WriteLine($"| 4. Use Health Potion [{player.PlayerHero.AmountOfHPPotions}/5]    |");
            Console.WriteLine($"| 5. Use Mana Potion   [{player.PlayerHero.AmountOfMPPotions}/5]    |");
            Console.WriteLine("=================================");

            if (!RepeatFunction && AdditionalDamageTurns > 0)
            {
                player.PlayerHero.CurrentHP -= AmountOfAdditionalDamage;
            }

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                DamageDealt = player.PlayerHero.NormalAttack(monster);
                Console.Clear();
                PrintBattleMenu(player, monster);
                Console.WriteLine($"Normal attack dealt: {DamageDealt} damage");
            }
            else if (choice == "2")
            {
                if (player.PlayerHero.CurrentMP >= 60)
                {
                    DamageDealt = player.PlayerHero.SpecialAttack(monster);
                    Console.Clear();
                    PrintBattleMenu(player, monster);
                    Console.WriteLine($"Special attack dealt: {DamageDealt} damage");
                }
                else
                {
                    RepeatFunction = true;
                    Console.WriteLine("Not enough MP! Press ENTER");
                    Console.ReadLine();
                    Console.Clear();
                    PrintHeroTurn(player, monster);

                }
            }
            else if (choice == "3")
            {
                player.PlayerHero.AvoidAttack();
                Console.Clear();
                PrintBattleMenu(player, monster);
                Console.WriteLine("You decided to protect yourself");
            }
            else if (choice == "4")
            {
                if (player.PlayerHero.AmountOfHPPotions > 0)
                {
                    player.PlayerHero.UseHPPotion();
                    Console.Clear();
                    PrintBattleMenu(player, monster);
                    Console.WriteLine("You have used a HP potion");
                    Console.WriteLine(player.PlayerHero.CurrentHP);
                }
                else
                {
                    RepeatFunction = true;
                    Console.WriteLine("You have run out of HP potions! Press ENTER");
                    Console.ReadLine();
                    Console.Clear();
                    PrintHeroTurn(player, monster);
                }
            }
            else if (choice == "5")
            {
                if (player.PlayerHero.AmountOfMPPotions > 0)
                {
                    player.PlayerHero.UseMPPotion();
                    Console.Clear();
                    PrintBattleMenu(player, monster);
                    Console.WriteLine("You have used a MP potion");
                    Console.WriteLine(player.PlayerHero.CurrentMP);
                }
                else
                {
                    RepeatFunction = true;
                    Console.WriteLine("You have run out of MP potions! Press ENTER");
                    Console.ReadLine();
                    Console.Clear();
                    PrintHeroTurn(player, monster);
                }
            }
            else
            {
                RepeatFunction = true;
                Console.WriteLine("WRONG BUTTON! Press ENTER");
                Console.ReadLine();
                Console.Clear();
                PrintHeroTurn(player, monster);
            }

            if (!RepeatFunction && AdditionalDamageTurns > 0)
            {
                Console.WriteLine($"{monster.SpecialAttackDesc} dealt: {AmountOfAdditionalDamage} damage");
                AdditionalDamageTurns--;
            }
            RepeatFunction = false;
        }

        public void PrintMonsterTurn(Player player, Monster monster)
        {
            bool SpecialAttack = false;
            PrintBattleMenu(player, monster);
            Console.WriteLine("            ENEMY TURN            ");
            double DamageDealt = 0;
            Random rnd = new Random();
            int losuj = rnd.Next(1, 11);
            if (losuj >= 1 && losuj <= 7) //Normal attack
            {
                DamageDealt = monster.NormalAttack(player.PlayerHero);
                Console.Clear();
                PrintBattleMenu(player, monster);
                if (player.PlayerHero.Dodged)
                {
                    Console.WriteLine("You have dodged the opponent's attack and received 0 damage!");
                    player.PlayerHero.Dodged = false;
                }
                else if (player.PlayerHero.AbsoluteDefence)
                {
                    Console.WriteLine(player.PlayerHero.AbsoluteDefenceDesc);
                }
                else
                {
                    Console.WriteLine($"{monster.Name} dealt {DamageDealt} damage");
                }
            }
            else if (losuj >= 8) //SpecialAttack
            {
                DamageDealt = monster.SpecialAttack(player.PlayerHero);
                Console.Clear();
                PrintBattleMenu(player, monster);
                if (player.PlayerHero.Dodged)
                {
                    Console.WriteLine("You have dodged the opponent's attack and received 0 damage!");
                    player.PlayerHero.Dodged = false;
                }
                else if (player.PlayerHero.AbsoluteDefence)
                {
                    Console.WriteLine(player.PlayerHero.AbsoluteDefenceDesc);
                }
                else
                {
                    Console.WriteLine($"{monster.Name} dealt {DamageDealt} damage");
                    Console.WriteLine(monster.SpecialAttackDesc);
                    if (monster.GetType() == typeof(Spider))
                    {
                        AmountOfAdditionalDamage = DamageDealt / 10;
                        if (player.PlayerHero.AbsoluteDefence == false)
                        {
                            AdditionalDamageTurns = 2;
                        }
                    }
                    else if (monster.GetType() == typeof(Golem))
                    {
                        Console.WriteLine($"{monster.Name} performs another turn!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        PrintMonsterTurn(player, monster);
                    }
                }   
            }
        }


        public void StartFight(Player player, Monster monster)
        {
            DamageDealt = 0;
            AmountOfAdditionalDamage = 0;
            AdditionalDamageTurns = 0;
            
            while (true)
            {
                PrintHeroTurn(player, monster);
                if (monster.CurrentHP <= 0) 
                {
                    Console.WriteLine($"{monster.Name} defeated");
                    break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                PrintMonsterTurn(player, monster);
                if (player.PlayerHero.AbsoluteDefence == true)
                {
                    player.PlayerHero.AbsoluteDefence = false;
                }
                if (player.PlayerHero.CurrentHP <= 0)
                {
                    Console.WriteLine("YOU DIED");
                    break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
