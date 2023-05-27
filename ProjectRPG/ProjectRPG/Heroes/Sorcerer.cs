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
            Weapon = new Staff("Staff", "Common", "Taki se miecz", 20, 1);
            Armor = new LightArmor("Light", "Common", "Taki se armor", 40, 0, 1);
            AbsoluteDefenceDesc = "You assume a defensive stance, effectively blocking the incoming attack.";
            BaseStrength = 4;
            BaseAgility = 6;
            BaseIntelligence = 10;
            Strength = BaseStrength;
            Agility = BaseAgility;
            Intelligence = BaseIntelligence + Weapon.AdditionalBonus + Armor.AdditionalBonus + Helmet.AdditionalBonus + Necklace.AdditionalBonus;
            MaxHP = 80 + Strength * 8 + Helmet.HPBonus;
            CurrentHP = MaxHP;
            MaxMP = 120 + Intelligence * 12 + Necklace.MPBonus;
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

            monster.CurrentHP = (monster.CurrentHP - DamageDealt) < 0 ? monster.CurrentHP = 0 : monster.CurrentHP - DamageDealt;

            return DamageDealt;
        }

        public override double SpecialHitMonster(Monster monster)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (monster.Defence * 0.01))) * (1 + Intelligence * 0.01) * 2);
            CurrentMP -= 80;

            monster.CurrentHP = (monster.CurrentHP - DamageDealt) < 0 ? monster.CurrentHP = 0 : monster.CurrentHP - DamageDealt;

            return DamageDealt;
        }

        public override void UpdateHero()
        {
            base.UpdateHero();
            Strength = BaseStrength;
            Agility = BaseAgility;
            Intelligence = BaseIntelligence + Weapon.AdditionalBonus + Armor.AdditionalBonus + Helmet.AdditionalBonus + Necklace.AdditionalBonus;
            MaxHP = 80 + Strength * 8 + Helmet.HPBonus;
            CurrentHP = MaxHP;
            MaxMP = 120 + Intelligence * 12 + Necklace.MPBonus;
            CurrentMP = MaxMP;
            BaseAttack = 8 * (Intelligence * 0.2);
            Attack = BaseAttack + Weapon.Damage;
            DodgeRate = 10 + Agility + Armor.DodgeRate;
        }

    }
}