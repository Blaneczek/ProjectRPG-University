using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Events
{
    public class GameEventLoader
    {
        public List<string> GameEvents { get; set; }
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
            }

        }

        public WarriorEventsData WarriorEvents { get; set; }
        public GameEventLoader()
        {
            WarriorEvents = new WarriorEventsData();
        }

        public void LoadWarriorGameEventData(string filePathWarrior, List<Weapon> weapon, List<Armor> armor, List<Helmet> helmets, List<Boot> boots, List<Necklace> necklaces)
        {
            if (File.Exists(filePathWarrior))
            {
                string[] lines = File.ReadAllLines(filePathWarrior);

                string[] values1 = lines[0].Split(',');
                string[] values2 = lines[1].Split(',');
                string[] values3 = lines[1].Split(',');
                string[] values4 = lines[1].Split(',');
                string[] values5 = lines[1].Split(',');
                string[] values6 = lines[1].Split(',');
                string[] values7 = lines[1].Split(',');
                string[] values8 = lines[1].Split(',');
                string[] values9 = lines[1].Split(',');
                WarriorEvents = new WarriorEventsData {
                    Event01 = new GameEvent<Sword>(int.Parse(values1[0]), values1[1], values1[2], (Sword)weapon[0]),
                    Event02 = new GameEvent<Helmet>(int.Parse(values2[0]), values2[1], values2[2], helmets[0]),
                    Event03 = new GameEvent<HeavyArmor>(int.Parse(values2[0]), values2[1], values2[2], (HeavyArmor)armor[0]),
                    Event04 = new GameEvent<Sword>(int.Parse(values2[0]), values2[1], values2[2], (Sword)weapon[1]),
                    Event05 = new GameEvent<Boot>(int.Parse(values2[0]), values2[1], values2[2], boots[0]),
                    Event06 = new GameEvent<HeavyArmor>(int.Parse(values2[0]), values2[1], values2[2], (HeavyArmor)armor[1]),
                    Event07 = new GameEvent<Necklace>(int.Parse(values2[0]), values2[1], values2[2], necklaces[0]),
                    Event08 = new GameEvent<Sword>(int.Parse(values2[0]), values2[1], values2[2], (Sword)weapon[2]),
                    Event09 = new GameEvent<HeavyArmor>(int.Parse(values2[0]), values2[1], values2[2], (HeavyArmor)armor[2])
                };
            }
        }


    }
}
