using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Monsters
{
    public class Monster
    {
        
        #region FieldsAndProperties
        public string Name { get; set; }
        public double MaxHP { get; set; }
        public double CurrentHP { get; set; }
        public double Attack { get; set; }
        #endregion

        #region Constructors
        public Monster(string name, double maxHP, double attack)
        {
            Name = name;
            MaxHP = maxHP;
            CurrentHP = maxHP;
            Attack = attack;
        }
        #endregion

        #region Methods

        #endregion
    }
}
