using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Equipment.Weapons
{
    public class Staff : Weapon
    {
        public double IntelligenceBonus { get; set; }
        public Staff(string name, string rarity, string description, double damage, double intelligenceBonus) : base(name, rarity, description, damage)
        {
            IntelligenceBonus = intelligenceBonus;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($" INT BONUS    :  {IntelligenceBonus}                       ");
            Console.WriteLine("============================================================");
            Console.WriteLine();
        }
    }
}
