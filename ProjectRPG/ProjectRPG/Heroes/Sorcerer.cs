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
            Weapon = new Staff("Apprentice's Wand", "Common", "A basic wooden wand, the quintessential tool for novice sorcerers.", 20, 1);
            Armor = new LightArmor("Light Vestments", "Common", "A lightweight and simple robe worn by aspiring sorcerers.", 10, 0, 1);
            AbsoluteDefenceDesc = "You conjure a magical barrier, nullifying the incoming attack.";
            SpecialAttackDesc = $"{Name} released a cataclysmic burst of arcane energy";
            BaseStrength = 4;
            BaseAgility = 6;
            BaseIntelligence = 10;
            Strength = BaseStrength;
            Agility = BaseAgility;
            Intelligence = BaseIntelligence + Weapon.AdditionalBonus + Armor.AdditionalBonus + Helmet.AdditionalBonus + Necklace.AdditionalBonus;
            MaxHP = Math.Round((120 + Strength * 8) * Level + Helmet.HPBonus);
            CurrentHP = MaxHP;
            MaxMP = Math.Round((120 + Intelligence * 12) * (Level * 0.5) + Necklace.MPBonus);
            CurrentMP = MaxMP;
            BaseAttack = Math.Round(8 * (Intelligence * 0.2));
            Attack = BaseAttack + Weapon.Damage;
            Defence = BaseDefence + Armor.Defence;
            DodgeRate = 5 + Agility + Armor.DodgeRate;
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
            double DamageDealt = Math.Round(((Attack - (Attack * (monster.Defence * 0.01))) * (1 + Intelligence * 0.01)) * 2);
            CurrentMP -= 40;

            monster.CurrentHP = (monster.CurrentHP - DamageDealt) < 0 ? monster.CurrentHP = 0 : monster.CurrentHP - DamageDealt;

            return DamageDealt;
        }

        public override void UpdateHero()
        {
            base.UpdateHero();
            Strength = BaseStrength;
            Agility = BaseAgility;
            Intelligence = BaseIntelligence + Weapon.AdditionalBonus + Armor.AdditionalBonus + Helmet.AdditionalBonus + Necklace.AdditionalBonus;
            MaxHP = Math.Round((120 + Strength * 8) * Level + Helmet.HPBonus);
            CurrentHP = MaxHP;
            MaxMP = Math.Round((120 + Intelligence * 12) * (Level * 0.5) + Necklace.MPBonus);
            CurrentMP = MaxMP;
            BaseAttack = Math.Round(8 * (Intelligence * 0.2));
            Attack = BaseAttack + Weapon.Damage;
            Defence = BaseDefence + Armor.Defence;
            DodgeRate = 5 + Agility + Armor.DodgeRate;
        }

    }
}