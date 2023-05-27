namespace ProjectRPG.Equipment.Armors
{
    public class Necklace
    {
        #region FieldsAndProperties
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }
        public double MPBonus { get; set; }
        public double AdditionalBonus { get; set; }
        #endregion

        #region Constructors
        public Necklace(string name, string rarity, string description, double mpBonus, double additionalBonus)
        {
            Name = name;
            Rarity = rarity;
            Description = description;
            MPBonus = mpBonus;
            AdditionalBonus = additionalBonus;
        }
        #endregion

        #region Methods
        public void PrintInfo()
        {
            Console.WriteLine("======================= HELMET ===========================");
            Console.WriteLine($" NAME        :  {Name}                                   ");
            Console.WriteLine($" TYPE        :  {GetType().Name}                         ");
            Console.WriteLine($" RARITY      :  {Rarity}                                 ");
            Console.WriteLine($" DESCRIPTION :  {Description}                            ");
            Console.WriteLine($" MP Bonus    :  {MPBonus}                                ");
            Console.WriteLine($" CORE BONUS  :  {AdditionalBonus}                        ");
            Console.WriteLine("===========================================================");
            Console.WriteLine();
        }
        #endregion
    }
}