using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Heroes;
using System;

namespace ProjectRPG.Monsters
{
    public class Goblin : Monster
    {
        public Goblin(string name, double level, double maxHP, double attack, double defence, string specialAttackDesc)
            : base(name, level, maxHP, attack, defence)
        {
            SpecialAttackDesc = specialAttackDesc;
            OnSpecialHit += SpecialHitHero;
        }

        public override double SpecialHitHero(Hero<Weapon, Armor> hero)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (hero.Defence * 0.01))) + (hero.MaxHP * 0.05)); // + 5% Maxymalnego HP bohatera jako bonus dmg

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
            return 0; 
        }
    }
}