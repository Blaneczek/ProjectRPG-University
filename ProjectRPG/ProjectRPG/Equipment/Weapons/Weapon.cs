using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Equipment.Weapons
{
    public class Weapon
    {
        #region FieldsAndProperties
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }
        public double Damage { get; set; }
        public double AdditionalBonus { get; set; }
        #endregion

        #region Constructors
        public Weapon(string name, string rarity, string description, double damage, double additionalBonus)
        {
            Name = name;
            Rarity = rarity;
            Description = description;
            Damage = damage;
            AdditionalBonus = additionalBonus;
        }
        #endregion

        #region Methods
        public virtual void PrintInfo()
        {
            Console.WriteLine("======================== WEAPON ======================================================");
            Console.WriteLine($" NAME        :  {Name}                                     ");
            Console.WriteLine($" TYPE        :  {GetType().Name}                           ");
            Console.WriteLine($" RARITY      :  {Rarity}                                   ");
            Console.WriteLine($" DESCRIPTION :  {Description}                              ");
            Console.WriteLine($" DAMAGE      :  {Damage}                                   ");
        }
        #endregion
    }
}
