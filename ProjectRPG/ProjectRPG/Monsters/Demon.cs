using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Heroes;
using System;

namespace ProjectRPG.Monsters
{
    public class Demon : Monster
    {
        public Demon(string name, double level, double maxHP, double attack, double defence, string specialAttackDesc)
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

            double AdditionalDamage = DamageDealt * 0.2; // Dodatkowe obrażenia od ognia (20% zadanych obrażeń)

            return AdditionalDamage;
        }
    }
}