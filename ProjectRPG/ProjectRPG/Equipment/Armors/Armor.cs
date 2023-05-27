using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        public virtual void PrintInfo()
        {
            Console.WriteLine("======================== ARMOR ============================");
            Console.WriteLine($" NAME        :  {Name}                                   ");
            Console.WriteLine($" TYPE        :  {GetType().Name}                         ");
            Console.WriteLine($" RARITY      :  {Rarity}                                 ");
            Console.WriteLine($" DESCRIPTION :  {Description}                            ");
            Console.WriteLine($" DEFENCE     :  {Defence}                                ");
            Console.WriteLine($" DODGE RATE  :  {DodgeRate}                              ");
        }
        #endregion
    }
}
