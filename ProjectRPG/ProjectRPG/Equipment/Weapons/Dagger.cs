using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Equipment.Weapons
{
    public class Dagger : Weapon
    {
        public double AgilityBonus { get; set; }
        public Dagger(string name, string rarity, string description, double damage, double agilityBonus) : base(name, rarity, description, damage)
        {
            AgilityBonus = agilityBonus;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"| AG BONUS    :  {AgilityBonus}                           |");
            Console.WriteLine("============================================================");
            Console.WriteLine();
        }
    }
}
