using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Equipment.Weapons
{
    
    public class Sword : Weapon
    {
        public double StrengthBonus { get; set; }
        public Sword(string name, string rarity, string description, double damage, double strengthBonus) : base(name, rarity, description, damage)
        {
            StrengthBonus = strengthBonus;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($" ST BONUS    :  {StrengthBonus}                           ");
            Console.WriteLine("============================================================");
            Console.WriteLine();
        }
       
    }
}
