using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Heroes;
using ProjectRPG.Monsters;

namespace ProjectRPG.Game
{
    public class Fight
    {
        public void StartFight(Player player, Monster monster)
        {
            double AmountOfAdditionalDamage = 0;
            double AdditionalDamageTurns = 0;
            double DamageDealt = 0;
            while (player.PlayerHero.CurrentHP >= 0 || monster.CurrentHP >= 0)
            {
               
                Console.WriteLine("Twoja tura");
                ///Hero
                Console.WriteLine("1.Atak\n2.Specialny atak\n3.Umiejentnosc obronna\n4.Uzyj HP potki");
                string decyzja = Console.ReadLine();
                if (decyzja == "1")
                {
                    DamageDealt = player.PlayerHero.NormalAttack(monster);
                    Console.WriteLine($"Zadano {DamageDealt} damage");
                }
                if (decyzja == "2")
                {
                    if (player.PlayerHero.CurrentMP >= 60) 
                    {
                        DamageDealt = player.PlayerHero.SpecialAttack(monster);
                        Console.WriteLine($"Zadano {DamageDealt} damage");
                    }
                    else
                    {
                        Console.WriteLine("Za malo many");
                        continue;
                    }
                    
                }
                if (decyzja == "3")
                {                 
                    player.PlayerHero.AvoidAttack();
                    Console.WriteLine("Umiejetnosc obronna odpalona");
                }
                if (decyzja == "4")
                {
                    player.PlayerHero.UseHPPotion();
                    Console.WriteLine("Uzyto potki HP");
                    Console.WriteLine(player.PlayerHero.CurrentHP);
                }
                if (decyzja == "5")
                {
                    player.PlayerHero.UseMPPotion();
                    Console.WriteLine("Uzyto potki MP");
                    Console.WriteLine(player.PlayerHero.CurrentMP);
                }
                
                if (monster.CurrentHP <= 0) 
                {
                    Console.WriteLine("Potwor pokonany");
                    break;
                }
                //////
               
                //////Monster
                if (AdditionalDamageTurns > 0)
                {
                    player.PlayerHero.CurrentHP -= AmountOfAdditionalDamage;
                    Console.WriteLine($"{monster.SpecialAttackDesc} {AmountOfAdditionalDamage} damage");
                    AdditionalDamageTurns--;
                }
                
                Console.WriteLine();
                Console.WriteLine("Tura przeciwnika");

                Random rnd = new Random();
                int losuj = rnd.Next(1, 11);
                if (losuj >= 1 && losuj <= 7)
                {
                    DamageDealt = monster.NormalAttack(player.PlayerHero);
                }
                else if (losuj >= 8)
                {
                    AmountOfAdditionalDamage = monster.SpecialAttack(player.PlayerHero);
                    DamageDealt = AmountOfAdditionalDamage * 10;
                    AdditionalDamageTurns = 2;
                }

                Console.WriteLine($"Potwor zadal {DamageDealt} damage");
                ///////
                Console.WriteLine("Obecny stan HP ");
                Console.WriteLine(player.PlayerHero.CurrentHP);
                Console.WriteLine(monster.CurrentHP);
                Console.WriteLine();
                if (decyzja == "3")
                {
                    player.PlayerHero.Defence = player.PlayerHero.tempDefence;
                }


                ///////
                if (player.PlayerHero.CurrentHP <= 0)
                {
                    Console.WriteLine("Przegrales");
                    break;
                }

                Console.WriteLine("Nacisnij Enter by przejsc dalej");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
