﻿using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectRPG.Monsters
{
    public class Spider : Monster
    {
        public Spider(string name, double level, double maxHP, double attack, double defence, string specialAttackDesc) : base(name, level, maxHP, attack, defence)
        {
            SpecialAttackDesc = specialAttackDesc;  
            OnSpecialHit += SpecialHitHero;
        }

        public override double SpecialHitHero(Hero<Weapon, Armor> hero)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (hero.Defence * 0.01))) * 2);
            if (hero.AbsoluteDefence)
            {
                DamageDealt = 0;
                Console.WriteLine(hero.AbsoluteDefenceDesc);
                return DamageDealt;
            }
            double AdditionalDamage = DamageDealt / 10;
            hero.CurrentHP -= DamageDealt;

            if (hero.CurrentHP < 0)
            {
                hero.CurrentHP = 0;
            }
            return AdditionalDamage;
        }
    }
}