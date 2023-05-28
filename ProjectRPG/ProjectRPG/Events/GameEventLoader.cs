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
        #region Fields and properties
        public List<List<string>> GameEventsScript { get; set; }
        public struct WarriorEventsData
        {          
            public GameEvent<Sword> Event01 { get; set; }
            public GameEvent<Helmet> Event02 { get; set; }
            public GameEvent<HeavyArmor> Event03 { get; set; }
            public GameEvent<Sword> Event04 { get; set; }
            public GameEvent<Boots> Event05 { get; set; }
            public GameEvent<Necklace> Event06 { get; set; }
            public GameEvent<HeavyArmor> Event07 { get; set; }
            public GameEvent<Sword> Event08 { get; set; }
            public GameEvent<HeavyArmor> Event09 { get; set; }
            
            public WarriorEventsData()
            {
                Event01 = new GameEvent<Sword>();
                Event02 = new GameEvent<Helmet>();
                Event03 = new GameEvent<HeavyArmor>();
                Event04 = new GameEvent<Sword>();
                Event05 = new GameEvent<Boots>();
                Event06 = new GameEvent<Necklace>();
                Event07 = new GameEvent<HeavyArmor>();
                Event08 = new GameEvent<Sword>();
                Event09 = new GameEvent<HeavyArmor>();               
            }
        }

        public struct SorcererEventsData
        {
            public GameEvent<Staff> Event01 { get; set; }
            public GameEvent<Helmet> Event02 { get; set; }
            public GameEvent<LightArmor> Event03 { get; set; }
            public GameEvent<Staff> Event04 { get; set; }
            public GameEvent<Boots> Event05 { get; set; }
            public GameEvent<Necklace> Event06 { get; set; }
            public GameEvent<LightArmor> Event07 { get; set; }
            public GameEvent<Staff> Event08 { get; set; }
            public GameEvent<LightArmor> Event09 { get; set; }

            public SorcererEventsData()
            {
                Event01 = new GameEvent<Staff>();
                Event02 = new GameEvent<Helmet>();
                Event03 = new GameEvent<LightArmor>();
                Event04 = new GameEvent<Staff>();
                Event05 = new GameEvent<Boots>();
                Event06 = new GameEvent<Necklace>();
                Event07 = new GameEvent<LightArmor>();
                Event08 = new GameEvent<Staff>();
                Event09 = new GameEvent<LightArmor>();
            }
        }

        public struct RogueEventsData
        {
            public GameEvent<Dagger> Event01 { get; set; }
            public GameEvent<Helmet> Event02 { get; set; }
            public GameEvent<MediumArmor> Event03 { get; set; }
            public GameEvent<Dagger> Event04 { get; set; }
            public GameEvent<Boots> Event05 { get; set; }
            public GameEvent<Necklace> Event06 { get; set; }
            public GameEvent<MediumArmor> Event07 { get; set; }
            public GameEvent<Dagger> Event08 { get; set; }
            public GameEvent<MediumArmor> Event09 { get; set; }

            public RogueEventsData()
            {
                Event01 = new GameEvent<Dagger>();
                Event02 = new GameEvent<Helmet>();
                Event03 = new GameEvent<MediumArmor>();
                Event04 = new GameEvent<Dagger>();
                Event05 = new GameEvent<Boots>();
                Event06 = new GameEvent<Necklace>();
                Event07 = new GameEvent<MediumArmor>();
                Event08 = new GameEvent<Dagger>();
                Event09 = new GameEvent<MediumArmor>();
            }
        }

        public WarriorEventsData WarriorEvents { get; set; }
        public SorcererEventsData SorcererEvents { get; set; }
        public RogueEventsData RogueEvents { get; set; }
        #endregion

        #region Constructors
        public GameEventLoader()
        {
            GameEventsScript = new()
            {
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>()             
            };

            WarriorEvents = new WarriorEventsData();
            SorcererEvents = new SorcererEventsData();
            RogueEvents = new RogueEventsData();
        }
        #endregion

        #region Methods
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

        public async Task LoadGameEventData(string filePath, string filePathScript, List<Weapon> weapon, List<Armor> armor, List<Helmet> helmets, List<Boots> boots, List<Necklace> necklaces, Dictionary<int, Monster> monsters, Player player)
        {
            LoadGameEventsScript(filePathScript);
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                string[] values1 = lines[0].Split(';');
                string[] values2 = lines[1].Split(';');
                string[] values3 = lines[2].Split(';');
                string[] values4 = lines[3].Split(';');
                string[] values5 = lines[4].Split(';');
                string[] values6 = lines[5].Split(';');
                string[] values7 = lines[6].Split(';');
                string[] values8 = lines[7].Split(';');
                string[] values9 = lines[8].Split(';');

                WarriorEvents = new WarriorEventsData
                {
                    Event01 = new GameEvent<Sword>(int.Parse(values1[0]), values1[1], GameEventsScript[0], (Sword)weapon[0], new Fight(player, monsters[1])),
                    Event02 = new GameEvent<Helmet>(int.Parse(values2[0]), values2[1], GameEventsScript[1], helmets[0], new Fight(player, monsters[2])),
                    Event03 = new GameEvent<HeavyArmor>(int.Parse(values3[0]), values3[1], GameEventsScript[2], (HeavyArmor)armor[0], new Fight(player, monsters[3])),
                    Event04 = new GameEvent<Sword>(int.Parse(values4[0]), values4[1], GameEventsScript[3], (Sword)weapon[1], new Fight(player, monsters[4])),
                    Event05 = new GameEvent<Boots>(int.Parse(values5[0]), values5[1], GameEventsScript[4], boots[0], new Fight(player, monsters[5])),
                    Event06 = new GameEvent<Necklace>(int.Parse(values6[0]), values6[1], GameEventsScript[5], necklaces[0], new Fight(player, monsters[6])),
                    Event07 = new GameEvent<HeavyArmor>(int.Parse(values7[0]), values7[1], GameEventsScript[6], (HeavyArmor)armor[1], new Fight(player, monsters[7])),
                    Event08 = new GameEvent<Sword>(int.Parse(values8[0]), values8[1], GameEventsScript[7], (Sword)weapon[2], new Fight(player, monsters[8])),
                    Event09 = new GameEvent<HeavyArmor>(int.Parse(values9[0]), values9[1], GameEventsScript[8], (HeavyArmor)armor[2], new Fight(player, monsters[9]))                  
                };

                SorcererEvents = new SorcererEventsData
                {
                    Event01 = new GameEvent<Staff>(int.Parse(values1[0]), values1[1], GameEventsScript[0], (Staff)weapon[3], new Fight(player, monsters[1])),
                    Event02 = new GameEvent<Helmet>(int.Parse(values2[0]), values2[1], GameEventsScript[1], helmets[1], new Fight(player, monsters[2])),
                    Event03 = new GameEvent<LightArmor>(int.Parse(values3[0]), values3[1], GameEventsScript[2], (LightArmor)armor[6], new Fight(player, monsters[3])),
                    Event04 = new GameEvent<Staff>(int.Parse(values4[0]), values4[1], GameEventsScript[3], (Staff)weapon[4], new Fight(player, monsters[4])),
                    Event05 = new GameEvent<Boots>(int.Parse(values5[0]), values5[1], GameEventsScript[4], boots[1], new Fight(player, monsters[5])),
                    Event06 = new GameEvent<Necklace>(int.Parse(values6[0]), values6[1], GameEventsScript[5], necklaces[1], new Fight(player, monsters[6])),
                    Event07 = new GameEvent<LightArmor>(int.Parse(values7[0]), values7[1], GameEventsScript[6], (LightArmor)armor[7], new Fight(player, monsters[7])),
                    Event08 = new GameEvent<Staff>(int.Parse(values8[0]), values8[1], GameEventsScript[7], (Staff)weapon[5], new Fight(player, monsters[8])),
                    Event09 = new GameEvent<LightArmor>(int.Parse(values9[0]), values9[1], GameEventsScript[8], (LightArmor)armor[8], new Fight(player, monsters[9]))
                };

                RogueEvents = new RogueEventsData
                {
                    Event01 = new GameEvent<Dagger>(int.Parse(values1[0]), values1[1], GameEventsScript[0], (Dagger)weapon[6], new Fight(player, monsters[1])),
                    Event02 = new GameEvent<Helmet>(int.Parse(values2[0]), values2[1], GameEventsScript[1], helmets[2], new Fight(player, monsters[2])),
                    Event03 = new GameEvent<MediumArmor>(int.Parse(values3[0]), values3[1], GameEventsScript[2], (MediumArmor)armor[3], new Fight(player, monsters[3])),
                    Event04 = new GameEvent<Dagger>(int.Parse(values4[0]), values4[1], GameEventsScript[3], (Dagger)weapon[7], new Fight(player, monsters[4])),
                    Event05 = new GameEvent<Boots>(int.Parse(values5[0]), values5[1], GameEventsScript[4], boots[2], new Fight(player, monsters[5])),
                    Event06 = new GameEvent<Necklace>(int.Parse(values6[0]), values6[1], GameEventsScript[5], necklaces[2], new Fight(player, monsters[6])),
                    Event07 = new GameEvent<MediumArmor>(int.Parse(values7[0]), values7[1], GameEventsScript[6], (MediumArmor)armor[4], new Fight(player, monsters[7])),
                    Event08 = new GameEvent<Dagger>(int.Parse(values8[0]), values8[1], GameEventsScript[7], (Dagger)weapon[8], new Fight(player, monsters[8])),
                    Event09 = new GameEvent<MediumArmor>(int.Parse(values9[0]), values9[1], GameEventsScript[8], (MediumArmor)armor[5], new Fight(player, monsters[9]))
                };
            }
        }
        #endregion
    }
}
