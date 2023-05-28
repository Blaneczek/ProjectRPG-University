namespace ProjectRPG.Equipment.Armors
{
    public class Boots
    {
        #region FieldsAndProperties
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }
        public double AdditionalBonus { get; set; }
        public double DodgeRateBonus { get; set; }
        #endregion

        #region Constructors
        public Boots(string name, string rarity, string description, double additionalBonus, double dodgeRateBonus)
        {
            Name = name;
            Rarity = rarity;
            Description = description;
            AdditionalBonus = additionalBonus;
            DodgeRateBonus = dodgeRateBonus;
        }
        #endregion

        #region Methods
        public void PrintInfo()
        {
            Console.WriteLine("======================== BOOTS =======================================================");
            Console.WriteLine($" NAME        :  {Name}                                    ");
            Console.WriteLine($" TYPE        :  {GetType().Name}                          ");
            Console.WriteLine($" RARITY      :  {Rarity}                                  ");
            Console.WriteLine($" DESCRIPTION :  {Description}                             ");
            Console.WriteLine($" CORE BONUS  :  {AdditionalBonus}                         ");
            Console.WriteLine($" DODGE BONUS :  {DodgeRateBonus}                          ");
            Console.WriteLine("======================================================================================");
            Console.WriteLine();
        }
        #endregion
    }
}