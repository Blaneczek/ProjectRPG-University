using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Heroes;
using System;

namespace ProjectRPG.Monsters
{
    public class Golem : Monster
    {
        public Golem(string name, double level, double maxHP, double attack, double defence, string specialAttackDesc)
            : base(name, level, maxHP, attack, defence)
        {
            SpecialAttackDesc = specialAttackDesc;
            OnSpecialHit += SpecialHitHero;
        }

        public override double SpecialHitHero(Hero<Weapon, Armor> hero)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (hero.Defence * 0.01))));

            Random rnd = new Random();
            int losuj = rnd.Next(1, 101);
            if (losuj >= 1 && losuj <= hero.DodgeRate)
            {
                DamageDealt = 0;
                hero.Dodged = true;
                return DamageDealt;
            }
            else if (losuj > hero.DodgeRate)
            {
                hero.CurrentHP -= DamageDealt;
                if (hero.CurrentHP < 0)
                {
                    hero.CurrentHP = 0;
                }
            }
            // Stunowanie bohatera
            hero.Stunned = true;
            Console.WriteLine("You have been stunned by the Golem!");
            return 0; 
        }
    }
}