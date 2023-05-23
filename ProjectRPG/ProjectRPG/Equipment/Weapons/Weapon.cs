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
        #endregion

        #region Constructors
        public Weapon(string name, string rarity, string description, double damage)
        {
            Name = name;
            Rarity = rarity;
            Description = description;
            Damage = damage;
        }
        #endregion

        #region Methods
        public void PrintInfo()
        {
            Console.WriteLine("======================== WEAPON ============================");
            Console.WriteLine($"| NAME        :  {Name}                                   |");
            Console.WriteLine($"| TYPE        :  {GetType().Name}                         |");
            Console.WriteLine($"| RARITY      :  {Rarity}                                 |");
            Console.WriteLine($"| DESCRIPTION :  {Description}                            |");
            Console.WriteLine($"| DAMAGE      :  {Damage}                                 |");
            Console.WriteLine("==========================================================");
            Console.WriteLine();
        }
        #endregion
    }
}
