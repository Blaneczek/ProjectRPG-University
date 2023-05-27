using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Equipment.Armors
{
    internal class LightArmor : Armor
    {
        public double IntelligenceBonus { get; set; }

        public LightArmor(string name, string rarity, string description, double defence, double dodgeRate, double intelligenceBonus) : base(name, rarity, description, defence, dodgeRate)
        {
            IntelligenceBonus = intelligenceBonus;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($" INT BONUS  :  {IntelligenceBonus}                        ");
            Console.WriteLine("===========================================================");
            Console.WriteLine();
        }

    }
}
