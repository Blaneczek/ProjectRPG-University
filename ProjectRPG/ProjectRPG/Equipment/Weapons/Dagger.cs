using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Equipment.Weapons
{
    public class Dagger : Weapon
    {
        public Dagger(string name, string rarity, string description, double damage, double additionalBonus) : base(name, rarity, description, damage, additionalBonus)
        {
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($" AG BONUS    :  {AdditionalBonus}                           ");
            Console.WriteLine("============================================================");
            Console.WriteLine();
        }
    }
}
