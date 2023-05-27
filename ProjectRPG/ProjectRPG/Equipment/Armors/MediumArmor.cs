using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Equipment.Armors
{
    public class MediumArmor : Armor
    {
        public double AgilityBonus { get; set; }

        public MediumArmor(string name, string rarity, string description, double defence, double dodgeRate, double agilityBonus) : base(name, rarity, description, defence, dodgeRate)
        {
            AgilityBonus = agilityBonus;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($" AG BONUS  :  {AgilityBonus}                              ");
            Console.WriteLine("===========================================================");
            Console.WriteLine();
        }
    }
}
