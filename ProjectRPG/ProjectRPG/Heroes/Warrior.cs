using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Game;
using ProjectRPG.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Heroes
{
    public class Warrior : Hero<Weapon, Armor>
    {
        public Inventory<Sword, HeavyArmor> Inventory { get; set; }
        public Warrior(string name) : base(name)
        {
            Weapon = new Sword("Sword", "Common", "Taki se miecz", 100);
            Armor = new HeavyArmor("Heavy", "Common", "Taki se armor", 40, 0);
            AbsoluteDefenceDesc = "You assume a defensive stance, effectively blocking the incoming attack.";
            Strength = 10;
            Agility = 6;
            Intelligence = 4;
            MaxHP = 100 + Strength * 10;
            CurrentHP = MaxHP;
            MaxMP = 100 + Intelligence * 8;
            CurrentMP = MaxMP;
            BaseAttack = 10 * (Strength * 0.2);
            Attack = BaseAttack + Weapon.Damage;
            Defence = BaseDefence + Armor.Defence;
            DodgeRate = 10 + Agility + Armor.DodgeRate;
            OnNormalHit += NormalHitMonster;
            OnSpecialHit += SpecialHitMonster;
        }

        public override double NormalHitMonster(Monster monster)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (monster.Defence * 0.01))) * (1 + Strength * 0.01));
            monster.CurrentHP -= DamageDealt;

            monster.CurrentHP = (monster.CurrentHP - DamageDealt) < 0 ? monster.CurrentHP = 0 : monster.CurrentHP - DamageDealt;

            return DamageDealt;
        }

        public override double SpecialHitMonster(Monster monster)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (Defence * 0.01))) * (1 + Strength * 0.01) * 2);
            monster.CurrentHP -= DamageDealt;
            CurrentMP -= 60;

            monster.CurrentHP = (monster.CurrentHP - DamageDealt) < 0 ? monster.CurrentHP = 0 : monster.CurrentHP - DamageDealt;

            return DamageDealt;
        }
    
    }
}
