using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Equipment.Armors;
using ProjectRPG.Monsters;
using static System.Reflection.Metadata.BlobBuilder;
using System.Diagnostics.Tracing;
using System.Threading;
using ProjectRPG.Game;

namespace ProjectRPG.Heroes
{
    public abstract class Hero<WeaponType, ArmorType> where WeaponType : Weapon where ArmorType : Armor
    {
        #region FieldsAndProperties
        public delegate double AttackDelegate(Monster monster);
        public event AttackDelegate OnNormalHit;
        public event AttackDelegate OnSpecialHit;
        public string Name { get; set; }
        public double Level { get; set; }
        public double MaxHP { get; set; }
        public double CurrentHP { get; set; }
        public double MaxMP { get; set; }
        public double CurrentMP { get; set; }
        public double BaseAttack { get; set; }
        public double Attack { get; set; }
        public double BaseDefence { get; set; }
        public double Defence { get; set; }
        public double DodgeRate { get; set; }
        public double Strength { get; set; }
        public double Agility { get; set; }
        public double Intelligence { get; set; }
        public bool AbsoluteDefence { get; set; }
        public string? AbsoluteDefenceDesc { get; set; }
        public int AmountOfHPPotions { get; set; }
        public int AmountOfMPPotions { get; set; }
        public bool Dodged { get; set; }
        public WeaponType? Weapon { get; set; }
        public ArmorType? Armor { get; set; }
        public Inventory<WeaponType, ArmorType> Inventory { get; set; }
        public HPPotion PotionHP { get; set; }
        public MPPotion PotionMP { get; set; }
        public Boot Boots { get; set; }
        public Helmet Helmet { get; set; }
        public Necklace Necklace { get; set; }
        public struct HPPotion
        {
            public string Name { get; set; }
            public double HealPower { get; set; }
            public int Amount { get; set; }
            public HPPotion(string name, double healPower, int amount)
            {
                Name = name;
                HealPower = healPower;
                Amount = amount;
            }
        }
        public struct MPPotion
        {
            public string Name { get; set; }
            public double ManaPower { get; set; }
            public int Amount { get; set; }
            public MPPotion(string name, double manaPower, int amount)
            {
                Name = name;
                ManaPower = manaPower;
                Amount = amount;
            }
        }
        #endregion

        #region Constructors
        public Hero(string name)
        {
            Name = name;
            Level = 1;
            BaseDefence = 20;
            Helmet = new Helmet("Helmet", "Common", "Taki se helm", 20, 2);
            Necklace = new Necklace("Necklace", "Common", "Taki se naszyjnik", 20, 2);
            Boots = new Boot("Boots", "Common", "Takie se buty", 2, 5);
            PotionHP = new("Lesser HP potion", 20, 5);
            PotionMP = new("Lesser MP potion", 20, 5);
            AmountOfHPPotions = PotionHP.Amount;
            AmountOfMPPotions = PotionMP.Amount;
            AbsoluteDefence = false;
            Dodged = false;
            Inventory = new Inventory<WeaponType, ArmorType>();
        }
        #endregion

        #region Methods
        public double NormalAttack(Monster monster)
        {
            return OnNormalHit.Invoke(monster);
        }
        public double SpecialAttack(Monster monster)
        {
            return OnSpecialHit.Invoke(monster);
        }
        public void AvoidAttack()
        {
            AbsoluteDefence = true;
        }
        public void UseHPPotion()
        {
            double addedHP = MaxHP * (PotionHP.HealPower * 0.01);

            CurrentHP = (CurrentHP + addedHP) > MaxHP ? CurrentHP = MaxHP : Math.Round(CurrentHP + addedHP);

            AmountOfHPPotions--;        
        }

        public void UseMPPotion()
        {
            double addedMP = MaxMP * (PotionMP.ManaPower * 0.01);

            CurrentMP = (CurrentMP + addedMP) > MaxHP ? CurrentMP = MaxMP : Math.Round(CurrentMP + addedMP);

            AmountOfMPPotions--;
        }
        public abstract double NormalHitMonster(Monster monster);
        public abstract double SpecialHitMonster(Monster monster);

        #endregion
    }


}
