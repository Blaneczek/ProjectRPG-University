namespace ProjectRPG.Equipment.Armors
{
    public class Helmet
    {
        #region FieldsAndProperties
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }
        public double HPBonus { get; set; }
        public double AdditionalBonus { get; set; }
        #endregion

        #region Constructors
        public Helmet(string name, string rarity, string description, double hpBonus, double additionalBonus)
        {
            Name = name;
            Rarity = rarity;
            Description = description;
            HPBonus = hpBonus;
            AdditionalBonus = additionalBonus;
        }
        #endregion

        #region Methods
        public void PrintInfo()
        {
            Console.WriteLine("======================= HELMET ===========================");
            Console.WriteLine($"| NAME        :  {Name}                                  |");
            Console.WriteLine($"| TYPE        :  {GetType().Name}                        |");
            Console.WriteLine($"| RARITY      :  {Rarity}                                |");
            Console.WriteLine($"| DESCRIPTION :  {Description}                           |");
            Console.WriteLine($"| HP Bonus    :  {HPBonus}                               |");
            Console.WriteLine($"| CORE BONUS  :  {AdditionalBonus}                       |");
            Console.WriteLine("===========================================================");
            Console.WriteLine();
        }
        #endregion
    }
}