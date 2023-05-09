using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Equipment.Armors;
using static System.Reflection.Metadata.BlobBuilder;

namespace ProjectRPG.Heroes
{
    public class Hero<WeaponType, ArmorType> where WeaponType : Weapon where ArmorType : Armor
    {
        #region FieldsAndProperties
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
        public double Strength { get; set; }
        public double Agility { get; set; }
        public double Intelligence { get; set; }
        public WeaponType Weapon { get; set; }
        public ArmorType Armor { get; set; }
        //public Boots Boots { get; set; }
        //public Helmet Helmet { get; set; }
        //public Necklace Necklace { get; set; }
        public struct HPPotion
        {
            public string Name { get; set; }
            public double HealPower {get; set;}
            public double Amount { get; set;}
            public HPPotion(string name, double healPower, double amount)
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
            public double Amount { get; set; }
            public MPPotion(string name, double manaPower, double amount)
            {
                Name = name;
                ManaPower = manaPower;
                Amount = amount;
            }
        }
        #endregion

        #region Constructors
        public Hero()
        {

        }

        public Hero(string name, WeaponType weapon, ArmorType armor)
        {
            Name = name;
            Level = 1;
            BaseDefence = 20;
            Weapon = weapon;
            Armor = armor;
            Defence = BaseDefence + Armor.Defence;
            //Boots = boots;
            //Helmet = helmet;
            //Necklace = necklace;
        }
        #endregion

        #region Methods


        #endregion
    }


}
