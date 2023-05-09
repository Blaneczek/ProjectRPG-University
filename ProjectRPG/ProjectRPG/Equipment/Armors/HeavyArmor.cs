using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Equipment.Armors
{
    public class HeavyArmor : Armor
    {
        public HeavyArmor(string name, string rarity, string description, double defence, double dodgeRate) : base(name, rarity, description, defence, dodgeRate)
        {
        }
    }
}
