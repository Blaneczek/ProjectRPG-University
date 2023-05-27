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
        public Warrior(string name) : base(name)
        {
            Weapon = new Sword("Sword", "Common", "Taki se miecz", 100, 1);
            Armor = new HeavyArmor("Heavy", "Common", "Taki se armor", 40, 0, 1);
            AbsoluteDefenceDesc = "You assume a defensive stance, effectively blocking the incoming attack.";
            BaseStrength = 10;
            BaseAgility = 6;
            BaseIntelligence = 4;
            Strength = BaseStrength + Weapon.AdditionalBonus + Armor.AdditionalBonus + Helmet.AdditionalBonus + Necklace.AdditionalBonus + Boots.AdditionalBonus;
            Agility = BaseAgility;
            Intelligence = BaseIntelligence;
            MaxHP = Math.Round(100 + Strength * 10 + Helmet.HPBonus);
            CurrentHP = MaxHP;
            MaxMP = Math.Round(100 + Intelligence * 8 + Necklace.MPBonus);
            CurrentMP = MaxMP;
            BaseAttack = Math.Round(10 * (Strength * 0.2));
            Attack = BaseAttack + Weapon.Damage;
            Defence = BaseDefence + Armor.Defence;
            DodgeRate = 10 + Agility + Armor.DodgeRate + Boots.DodgeRateBonus;
            OnNormalHit += NormalHitMonster;
            OnSpecialHit += SpecialHitMonster;
        }

        public override double NormalHitMonster(Monster monster)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (monster.Defence * 0.01))) * (1 + Strength * 0.01));

            monster.CurrentHP = (monster.CurrentHP - DamageDealt) < 0 ? monster.CurrentHP = 0 : monster.CurrentHP - DamageDealt;

            return DamageDealt;
        }

        public override double SpecialHitMonster(Monster monster)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (monster.Defence * 0.01))) * (1 + Strength * 0.01) * 2);
            CurrentMP -= 40;

            monster.CurrentHP = (monster.CurrentHP - DamageDealt) < 0 ? monster.CurrentHP = 0 : monster.CurrentHP - DamageDealt;

            return DamageDealt;
        }

        public override void UpdateHero()
        {
            base.UpdateHero();
            Strength = BaseStrength + Weapon.AdditionalBonus + Armor.AdditionalBonus + Helmet.AdditionalBonus + Necklace.AdditionalBonus + Boots.AdditionalBonus;
            Agility = BaseAgility;
            Intelligence = BaseIntelligence;
            MaxHP = Math.Round(100 + Strength * 10 + Helmet.HPBonus);
            CurrentHP = MaxHP;
            MaxMP = Math.Round(100 + Intelligence * 8 + Necklace.MPBonus);
            CurrentMP = MaxMP;
            BaseAttack = Math.Round(10 * (Strength * 0.2));
            Attack = BaseAttack + Weapon.Damage;
            Defence = BaseDefence + Armor.Defence;
            DodgeRate = 10 + Agility + Armor.DodgeRate + Boots.DodgeRateBonus;
        }

    }
}
