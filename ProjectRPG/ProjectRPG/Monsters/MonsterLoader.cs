using ProjectRPG.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Monsters
{
    public class MonsterLoader
    {
        public Dictionary<int, Monster> Monsters;

        public MonsterLoader()
        {
            Monsters = new Dictionary<int, Monster>();
        }

        public async Task LoadMonsters(string filePathMonsters)
        {
            if (File.Exists(filePathMonsters))
            {
                string[] lines = File.ReadAllLines(filePathMonsters);

                foreach (string line in lines)
                {
                    string[] values = line.Split(';');
                    if (values[0] == "SPIDER")
                    {
                        Monster monster = new Spider(values[2], double.Parse(values[3]), double.Parse(values[4]), double.Parse(values[5]), double.Parse(values[6]), values[7]);
                        Monsters.Add(int.Parse(values[1]), monster);
                    }
                    else if (values[0] == "GOLEM")
                    {
                        Monster monster = new Golem(values[2], double.Parse(values[3]), double.Parse(values[4]), double.Parse(values[5]), double.Parse(values[6]), values[7]);
                        Monsters.Add(int.Parse(values[1]), monster);
                    }
                    else if (values[0] == "GOBLIN")
                    {
                        Monster monster = new Goblin(values[2], double.Parse(values[3]), double.Parse(values[4]), double.Parse(values[5]), double.Parse(values[6]), values[7]);
                        Monsters.Add(int.Parse(values[1]), monster);
                    }
                    else if (values[0] == "DEMON")
                    {
                        Monster monster = new Demon(values[2], double.Parse(values[3]), double.Parse(values[4]), double.Parse(values[5]), double.Parse(values[6]), values[7]);
                        Monsters.Add(int.Parse(values[1]), monster);
                    }
                }
            }
        }
    }
}
