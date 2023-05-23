namespace ProjectRPG.Equipment.Armors
{
    public class Helmet
    {
        #region FieldsAndProperties
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }
        public double HPBonus { get; set; }
        public double StrengthBonus { get; set; }
        #endregion

        #region Constructors
        public Helmet(string name, string rarity, string description, double hpBonus, double strengthBonus)
        {
            Name = name;
            Rarity = rarity;
            Description = description;
            HPBonus = hpBonus;
            StrengthBonus = strengthBonus;
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
            Console.WriteLine($"| ST BONUS    :  {StrengthBonus}                         |");
            Console.WriteLine("===========================================================");
            Console.WriteLine();
        }
        #endregion
    }
}