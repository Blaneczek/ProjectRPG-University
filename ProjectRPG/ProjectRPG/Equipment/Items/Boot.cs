namespace ProjectRPG.Equipment.Armors
{
    public class Boot
    {
        #region FieldsAndProperties
        public string Name { get; set; }
        public string Rarity { get; set; }
        public string Description { get; set; }
        public double AgilityBonus { get; set; }
        public double DodgeRateBonus { get; set; }
        #endregion

        #region Constructors
        public Boot(string name, string rarity, string description, double agilityBonus, double dodgeRateBonus)
        {
            Name = name;
            Rarity = rarity;
            Description = description;
            AgilityBonus = agilityBonus;
            DodgeRateBonus = dodgeRateBonus;
        }
        #endregion
    }
}