using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Heroes
{
    public class Warrior : Hero<Weapon, Armor>
    {
        public Warrior(string name, Weapon weapon, Armor armor) : base(name, weapon, armor)
        {
            Strength = 10;
            Agility = 6;
            Intelligence = 4;
            MaxHP = 100 + Strength * 10;
            CurrentHP = MaxHP;
            MaxMP = 100 + Intelligence * 10;
            BaseAttack = 10 * (Strength * 0.2);
            Attack = BaseAttack + Weapon.Damage;
            BaseDodgeRate = 10 * Agility * 2;
        }
    }
}
