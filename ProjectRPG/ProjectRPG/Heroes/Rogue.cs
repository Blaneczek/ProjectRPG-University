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
            Weapon = new Dagger("Swift Stiletto", "Common", "A small and unassuming dagger, ideal for swift and precise strikes.", 20, 1);
            Armor = new MediumArmor("Shadowcloth Tunic", "Common", "A mediumweight and stealthy tunic that provides basic protection.", 10, 0, 1);
            AbsoluteDefenceDesc = "Using your nimble agility, you effortlessly sidestep the attack, avoiding any harm.";
            SpecialAttackDesc = $"{Name} dissolves into the shadows and strikes swiftly with deadly precision,";
            BaseStrength = 6; 
            BaseAgility = 10; 
            BaseIntelligence = 4;
            Strength = BaseStrength;
            Agility = BaseAgility + Weapon.AdditionalBonus + Armor.AdditionalBonus + Helmet.AdditionalBonus + Necklace.AdditionalBonus + Boots.AdditionalBonus;
            Intelligence = BaseIntelligence;
            MaxHP = Math.Round((100 + Strength * 10) + Helmet.HPBonus);
            CurrentHP = MaxHP;
            MaxMP = Math.Round((80 + Intelligence * 8) + Necklace.MPBonus);
            CurrentMP = MaxMP;
            BaseAttack = Math.Round(9 * (Agility * 0.2)); 
            Attack = BaseAttack + Weapon.Damage;
            Defence = BaseDefence + Armor.Defence;
            BaseDodgeRate = 10;
            DodgeRate = BaseDodgeRate + Agility + Armor.DodgeRate + Boots.DodgeRateBonus;
            OnNormalHit += NormalHitMonster; 
            OnSpecialHit += SpecialHitMonster;  
        }

        public override double NormalHitMonster(Monster monster)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (monster.Defence * 0.01))) * (1 + Agility * 0.01));

            monster.CurrentHP = (monster.CurrentHP - DamageDealt) < 0 ? monster.CurrentHP = 0 : monster.CurrentHP - DamageDealt;

            return DamageDealt;
        }

        public override double SpecialHitMonster(Monster monster)
        {
            double DamageDealt = Math.Round(((Attack - (Attack * (monster.Defence * 0.01))) * (1 + Agility * 0.01)) * 2.5);
            CurrentMP -= 100;

            monster.CurrentHP = (monster.CurrentHP - DamageDealt) < 0 ? monster.CurrentHP = 0 : monster.CurrentHP - DamageDealt;

            return DamageDealt;
        }

        public override void UpdateHero()
        {
            base.UpdateHero();
            Strength = BaseStrength;
            Agility = BaseAgility + Weapon.AdditionalBonus + Armor.AdditionalBonus + Helmet.AdditionalBonus + Necklace.AdditionalBonus + Boots.AdditionalBonus;
            Intelligence = BaseIntelligence;
            MaxHP = Math.Round((100 + Strength * 10) * (Level * 0.5) + Helmet.HPBonus);
            CurrentHP = MaxHP;
            MaxMP = Math.Round((80 + Intelligence * 8) * (Level * 0.5) + Necklace.MPBonus);
            CurrentMP = MaxMP;
            BaseAttack = Math.Round(9 * (Agility * 0.2));
            Attack = BaseAttack + Weapon.Damage;
            Defence = BaseDefence + Armor.Defence;
            BaseDodgeRate = 10;
            DodgeRate = BaseDodgeRate + Agility + Armor.DodgeRate + Boots.DodgeRateBonus;
        }
    }
}