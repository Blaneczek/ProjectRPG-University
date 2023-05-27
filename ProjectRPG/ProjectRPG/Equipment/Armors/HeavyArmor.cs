using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Equipment.Armors
{
    public class HeavyArmor : Armor
    {
        public double StrengthBonus { get; set; }
        public HeavyArmor(string name, string rarity, string description, double defence, double dodgeRate, double strengthBonus) : base(name, rarity, description, defence, dodgeRate)
        {
            StrengthBonus = strengthBonus;  
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($" ST BONUS  :  {StrengthBonus}                             ");
            Console.WriteLine("===========================================================");
            Console.WriteLine();
        }
    }
}
