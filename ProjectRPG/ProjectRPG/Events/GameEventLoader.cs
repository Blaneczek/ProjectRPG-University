using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Monsters;
using ProjectRPG.Game;
using System.Numerics;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace ProjectRPG.Events
{
    public class GameEventLoader
    {
        public List<List<string>> GameEventsScript { get; set; }
        public struct WarriorEventsData
        {
            public GameEvent<Sword> Event01 { get; set; }
            public GameEvent<Helmet> Event02 { get; set; }
            public GameEvent<HeavyArmor> Event03 { get; set; }
            public GameEvent<Sword> Event04 { get; set; }
            public GameEvent<Boot> Event05 { get; set; }
            public GameEvent<HeavyArmor> Event06 { get; set; }
            public GameEvent<Necklace> Event07 { get; set; }
            public GameEvent<Sword> Event08 { get; set; }
            public GameEvent<HeavyArmor> Event09 { get; set; }

            public WarriorEventsData()
            {
                Event01 = new GameEvent<Sword>();
                Event02 = new GameEvent<Helmet>();
                Event03 = new GameEvent<HeavyArmor>();
                Event04 = new GameEvent<Sword>();
                Event05 = new GameEvent<Boot>();
                Event06 = new GameEvent<HeavyArmor>();
                Event07 = new GameEvent<Necklace>();
                Event08 = new GameEvent<Sword>();
                Event09 = new GameEvent<HeavyArmor>();
           }
        }

        public WarriorEventsData WarriorEvents { get; set; }
        public GameEventLoader()
        {
            GameEventsScript = new()
            {
                new List<string>(),
                new List<string>(),
                new List<string>()
            };
 
            WarriorEvents = new WarriorEventsData();
        }

        public void LoadGameEventsScript(string filePathScript)
        {
            if (File.Exists(filePathScript))
            {
                string[] lines = File.ReadAllLines(filePathScript);
                foreach (string line in lines)
                {
                    string[] values = line.Split(';');
                    GameEventsScript[int.Parse(values[0])].Add(values[1]);
                }
            }
        }

        public void LoadWarriorGameEventData(string filePathWarrior, string filePathScript, List<Weapon> weapon, List<Armor> armor, List<Helmet> helmets, List<Boot> boots, List<Necklace> necklaces, Dictionary<int, Monster> monsters, Player player)
        {
            LoadGameEventsScript(filePathScript);
            if (File.Exists(filePathWarrior))
            {
                string[] lines = File.ReadAllLines(filePathWarrior);

                string[] values1 = lines[0].Split(';');
                string[] values2 = lines[1].Split(';');
                string[] values3 = lines[2].Split(';');
                string[] values4 = lines[3].Split(';');
                string[] values5 = lines[4].Split(';');
                string[] values6 = lines[5].Split(';');
                string[] values7 = lines[6].Split(';');
                string[] values8 = lines[7].Split(';');
                string[] values9 = lines[8].Split(';');
                WarriorEvents = new WarriorEventsData{
                    Event01 = new GameEvent<Sword>(int.Parse(values1[0]), values1[1], GameEventsScript[0], (Sword)weapon[0], new Fight(player, monsters[1])),
                    Event02 = new GameEvent<Helmet>(int.Parse(values2[0]), values2[1], GameEventsScript[0], helmets[0], new Fight(player, monsters[2])),
                    Event03 = new GameEvent<HeavyArmor>(int.Parse(values3[0]), values3[1], GameEventsScript[0], (HeavyArmor)armor[0], new Fight(player, monsters[3])),
                    Event04 = new GameEvent<Sword>(int.Parse(values4[0]), values4[1], GameEventsScript[0], (Sword)weapon[1], new Fight(player, monsters[4])),
                    Event05 = new GameEvent<Boot>(int.Parse(values5[0]), values5[1], GameEventsScript[0], boots[0], new Fight(player, monsters[5])),
                    Event06 = new GameEvent<HeavyArmor>(int.Parse(values6[0]), values6[1], GameEventsScript[0], (HeavyArmor)armor[1], new Fight(player, monsters[6])),
                    Event07 = new GameEvent<Necklace>(int.Parse(values7[0]), values7[1], GameEventsScript[0], necklaces[0], new Fight(player, monsters[7])),
                    Event08 = new GameEvent<Sword>(int.Parse(values8[0]), values8[1], GameEventsScript[0], (Sword)weapon[2], new Fight(player, monsters[8])),
                    Event09 = new GameEvent<HeavyArmor>(int.Parse(values9[0]), values9[1], GameEventsScript[0], (HeavyArmor)armor[2], new Fight(player, monsters[9]))
                };
            }
        }
    }
}
