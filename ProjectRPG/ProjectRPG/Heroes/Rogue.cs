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
            BaseStrength = 6; 
            BaseAgility = 10; 
            BaseIntelligence = 4;
            Strength = BaseStrength;
            Agility = BaseAgility + Weapon.AdditionalBonus + Armor.AdditionalBonus + Helmet.AdditionalBonus + Necklace.AdditionalBonus + Boots.AdditionalBonus;
            Intelligence = BaseIntelligence;
            MaxHP = 90 + Strength * 9 + Helmet.HPBonus;
            CurrentHP = MaxHP;
            MaxMP = 80 + Intelligence * 8 + Necklace.MPBonus;
            CurrentMP = MaxMP;
            BaseAttack = 9 * (Agility * 0.2); 
            Attack = BaseAttack + Weapon.Damage;
            BaseDodgeRate = 15;
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
            double DamageDealt = Math.Round((Attack - (Attack * (monster.Defence * 0.01))) * (1 + Agility * 0.01) * 1.5);
            CurrentMP -= 40;

            monster.CurrentHP = (monster.CurrentHP - DamageDealt) < 0 ? monster.CurrentHP = 0 : monster.CurrentHP - DamageDealt;

            return DamageDealt;
        }

        public override void UpdateHero()
        {
            base.UpdateHero();
            Strength = BaseStrength;
            Agility = BaseAgility + Weapon.AdditionalBonus + Armor.AdditionalBonus + Helmet.AdditionalBonus + Necklace.AdditionalBonus + Boots.AdditionalBonus;
            Intelligence = BaseIntelligence;
            MaxHP = 90 + Strength * 9 + Helmet.HPBonus;
            CurrentHP = MaxHP;
            MaxMP = 80 + Intelligence * 8 + Necklace.MPBonus;
            CurrentMP = MaxMP;
            BaseAttack = 9 * (Agility * 0.2);
            Attack = BaseAttack + Weapon.Damage;
            BaseDodgeRate = 15;
            DodgeRate = BaseDodgeRate + Agility + Armor.DodgeRate + Boots.DodgeRateBonus;
        }
    }
}