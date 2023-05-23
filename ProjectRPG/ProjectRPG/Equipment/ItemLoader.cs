using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectRPG
{
    public class ItemLoader
    {
        public Dictionary<int, Armor> Armors { get; private set; }
        public Dictionary<int, Weapon> Weapons { get; private set; }
        public Dictionary<int, Helmet> Helmets { get; private set; }
        public Dictionary<int, Necklace> Necklaces { get; private set; }
        public Dictionary<int, Boot> Boots { get; private set; }

        public ItemLoader()
        {
            Armors = new Dictionary<int, Armor>();
            Weapons = new Dictionary<int, Weapon>();
            Helmets = new Dictionary<int, Helmet>();
            Necklaces = new Dictionary<int, Necklace>();
            Boots = new Dictionary<int, Boot>();
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
                    Weapon weapon = new Weapon(values[1], values[2], values[3], double.Parse(values[4]));
                    Weapons.Add(int.Parse(values[0]), weapon);
                }
            }           
        }

        public void LoadArmors(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    Armor armor = new Armor(values[1], values[2], values[3], double.Parse(values[4]), double.Parse(values[5]));
                    Armors.Add(int.Parse(values[0]), armor);
            
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
                    Helmet helmet = new Helmet(values[1], values[2], values[3], double.Parse(values[4]), double.Parse(values[5]));
                    Helmets.Add(int.Parse(values[0]), helmet);
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
                    Necklace necklace = new Necklace(values[1], values[2], values[3], double.Parse(values[4]), double.Parse(values[5]));
                    Necklaces.Add(int.Parse(values[0]), necklace);
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
                    Boot boot = new Boot(values[1], values[2], values[3], double.Parse(values[4]), double.Parse(values[5]));
                    Boots.Add(int.Parse(values[0]), boot);
                }
            }
                
        }
    }
}
