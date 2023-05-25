using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectRPG
{
    public class ItemLoader
    {
        public List<Armor> Armors { get; private set; }
        public List<Weapon> Weapons { get; private set; }
        public List<Helmet> Helmets { get; private set; }
        public List<Necklace> Necklaces { get; private set; }
        public List<Boot> Boots { get; private set; }

        public ItemLoader()
        {
            Armors = new List<Armor>();
            Weapons = new List<Weapon>();
            Helmets = new List<Helmet>();
            Necklaces = new List<Necklace>();
            Boots = new List<Boot>();
        }

        public void LoadItemsFromFile(string filePathWeaons, string filePathArmors, string filePathHelmets, string filePathNecklaces, string filePathBoots)
        {
            LoadWeapons(filePathWeaons);
            LoadArmors(filePathArmors);
            LoadHelmets(filePathHelmets);
            LoadNecklaces(filePathNecklaces);
            LoadBoots(filePathBoots);
        }

        public void LoadWeapons(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
            
                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    if (values[0] == "SWORD")
                    {
                        Weapon weapon = new Sword(values[1], values[2], values[3], double.Parse(values[4]), double.Parse(values[5]));
                        Weapons.Add(weapon);
                    }
                    else if (values[0] == "STAFF")
                    {
                        Weapon weapon = new Staff(values[1], values[2], values[3], double.Parse(values[4]), double.Parse(values[5]));
                        Weapons.Add(weapon);
                    }
                    else if (values[0] == "DAGGER")
                    {
                        Weapon weapon = new Dagger(values[1], values[2], values[3], double.Parse(values[4]), double.Parse(values[5]));
                        Weapons.Add(weapon);
                    }

                }
            }           
        }

        public void LoadArmors(string filePathArmor)
        {
            if (File.Exists(filePathArmor))
            {
                string[] lines = File.ReadAllLines(filePathArmor);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    if (values[0] == "HEAVY")
                    {
                        Armor armor= new HeavyArmor(values[1], values[2], values[3], double.Parse(values[4]), double.Parse(values[5]), double.Parse(values[6]));
                        Armors.Add(armor);
                    }
                    else if (values[0] == "MEDIUM")
                    {
                        Armor armor = new MediumArmor(values[1], values[2], values[3], double.Parse(values[4]), double.Parse(values[5]), double.Parse(values[6]));
                        Armors.Add(armor);
                    }
                    else if (values[0] == "LIGHT")
                    {
                        Armor armor = new LightArmor(values[1], values[2], values[3], double.Parse(values[4]), double.Parse(values[5]), double.Parse(values[6]));
                        Armors.Add(armor);
                    }

                }
            }
        }

        public void LoadHelmets(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    Helmet helmet = new Helmet(values[0], values[1], values[2], double.Parse(values[3]), double.Parse(values[4]));
                    Helmets.Add(helmet);
                }
            }
             
        }

        public void LoadNecklaces(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    Necklace necklace = new Necklace(values[0], values[1], values[2], double.Parse(values[3]), double.Parse(values[4]));
                    Necklaces.Add(necklace);
                }
            }
               
        }

        public void LoadBoots(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    Boot boot = new Boot(values[0], values[1], values[2], double.Parse(values[3]), double.Parse(values[4]));
                    Boots.Add(boot);
                }
            }
                
        }
    }
}
