using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Heroes
{
    public class Sorcerer : Hero<Weapon, Armor>
    {
        public Sorcerer(string name) : base(name)
        {
            Weapon = new Sword("Sword", "Common", "Taki se miecz", 20);
            Armor = new HeavyArmor("Heavy", "Common", "Taki se armor", 40, 0);
            AbsoluteDefenceDesc = "You assume a defensive stance, effectively blocking the incoming attack.";
            Strength = 4;
            Agility = 6;
            Intelligence = 10;
            MaxHP = 80 + Strength * 8;
            CurrentHP = MaxHP;
            MaxMP = 120 + Intelligence * 12;
            CurrentMP = MaxMP;
            BaseAttack = 8 * (Intelligence * 0.2);
            Attack = BaseAttack + Weapon.Damage;
            DodgeRate = 10 + Agility + Armor.DodgeRate;
            OnNormalHit += NormalHitMonster;
            OnSpecialHit += SpecialHitMonster;
        }

        public override double NormalHitMonster(Monster monster)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (monster.Defence * 0.01))) * (1 + Intelligence * 0.01));
            monster.CurrentHP -= DamageDealt;

            if (monster.CurrentHP < 0)
            {
                monster.CurrentHP = 0;
            }

            return DamageDealt;
        }

        public override double SpecialHitMonster(Monster monster)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (Defence * 0.01))) * (1 + Intelligence * 0.01) * 2);
            monster.CurrentHP -= DamageDealt;
            CurrentMP -= 80;

            if (monster.CurrentHP < 0)
            {
                monster.CurrentHP = 0;
            }

            return DamageDealt;
        }

    }
}