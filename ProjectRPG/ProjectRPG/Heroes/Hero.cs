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
        public double BaseDodgeRate { get; set; }
        public double DodgeRate { get; set; }
        public double BaseStrength { get; set; }
        public double Strength { get; set; }
        public double BaseAgility { get; set; }
        public double Agility { get; set; }
        public double BaseIntelligence { get; set; }  
        public double Intelligence { get; set; }
        public bool AbsoluteDefence { get; set; }
        public string AbsoluteDefenceDesc { get; set; }
        public string SpecialAttackDesc { get; set; }
        public int AmountOfHPPotions { get; set; }
        public int AmountOfMPPotions { get; set; }
        public bool Dodged { get; set; }
        public WeaponType? Weapon { get; set; }
        public ArmorType? Armor { get; set; }
        public Inventory<WeaponType, ArmorType> Inventory { get; set; }
        public HPPotion PotionHP { get; set; }
        public MPPotion PotionMP { get; set; }
        public Boots Boots { get; set; }
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
            Helmet = new Helmet("Novice Cap", "Common", "A basic headgear that provides minimal protection", 50, 1);
            Necklace = new Necklace("Beginner's Luck Pendant", "Common", "A simple pendant imbued with novice-level enchantments.", 20, 1);
            Boots = new Boots("Adventurer's Boots", "Common", "Sturdy yet unremarkable boots that provide basic foot protection.", 1, 2);
            PotionHP = new("HP potion", 30, 5);
            PotionMP = new("MP potion", 30, 5);
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
            double addedMP = Math.Round(MaxMP * (PotionMP.ManaPower * 0.01));

            CurrentMP = (CurrentMP + addedMP) > MaxMP ? CurrentMP = MaxMP : Math.Round(CurrentMP + addedMP);

            AmountOfMPPotions--;
        }

        public virtual void UpdateHero()
        {
            Level++;
            AmountOfHPPotions = 5;
            AmountOfMPPotions = 5;
        
            Console.WriteLine("         LEVEL UP!              ");
            Console.WriteLine("Increase one of the statistics: ");
            Console.WriteLine($"1. Strength     {Strength}     ");
            Console.WriteLine($"2. Agility      {Agility}      ");
            Console.WriteLine($"3. Intelligence {Intelligence} ");
            ConsoleKeyInfo choice = Console.ReadKey(true);
            if (choice.Key.ToString() == "D1" || choice.Key.ToString() == "NumPad1")
            {
                BaseStrength++;
                Console.Clear();
            }
            else if (choice.Key.ToString() == "D2" || choice.Key.ToString() == "NumPad2")
            {
                BaseAgility++;
                Console.Clear();
            }
            else if (choice.Key.ToString() == "D3" || choice.Key.ToString() == "NumPad3")
            {
                BaseIntelligence++;
                Console.Clear();
            }
            else
            {
                Console.Clear();
                UpdateHero();
            }
        }

        public abstract double NormalHitMonster(Monster monster);
        public abstract double SpecialHitMonster(Monster monster);
        #endregion
    }


}
