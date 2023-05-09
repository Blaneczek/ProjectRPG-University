using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Equipment.Armors
{
    public class Armor
    {
        #region FieldsAndProperties
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }
        public double Defence { get; set; }
        public double DodgeRate { get; set; }
        #endregion

        #region Constructors
        public Armor() { }
        public Armor(string name, string rarity, string description, double defence, double dodgeRate)
        {
            Name = name;
            Rarity = rarity;
            Description = description;
            Defence = defence;
            DodgeRate = dodgeRate;
        }
        #endregion

        #region Methods

        #endregion
    }
}
