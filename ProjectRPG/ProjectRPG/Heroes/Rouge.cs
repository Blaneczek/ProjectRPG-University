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
    public class Rogue : Hero<Weapon, Armor>
    {
        public Rogue(string name) : base(name)
        {
            Weapon = new Dagger("Dagger", "Common", "Taki se miecz", 20, 1);
            Armor = new MediumArmor("Medium", "Common", "Taki se armor", 40, 0, 1);
            AbsoluteDefenceDesc = "You assume a defensive stance, effectively blocking the incoming attack.";
            Strength = 6; 
            Agility = 10; 
            Intelligence = 4;
            MaxHP = 90 + Strength * 9;
            CurrentHP = MaxHP;
            MaxMP = 80 + Intelligence * 8;
            CurrentMP = MaxMP;
            BaseAttack = 9 * (Agility * 0.2); 
            Attack = BaseAttack + Weapon.Damage;
            DodgeRate = 15 + Agility + Armor.DodgeRate;
            OnNormalHit += NormalHitMonster; 
            OnSpecialHit += SpecialHitMonster;  
        }

        public override double NormalHitMonster(Monster monster)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (monster.Defence * 0.01))) * (1 + Agility * 0.01));
            monster.CurrentHP -= DamageDealt;

            if (monster.CurrentHP < 0)
            {
                monster.CurrentHP = 0;
            }

            return DamageDealt;
        }

        public override double SpecialHitMonster(Monster monster)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (Defence * 0.01))) * (1 + Agility * 0.01) * 1.5);
            monster.CurrentHP -= DamageDealt;
            CurrentMP -= 40;

            if (monster.CurrentHP < 0)
            {
                monster.CurrentHP = 0;
            }

            return DamageDealt;
        }

    }
}