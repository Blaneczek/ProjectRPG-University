using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Monsters;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Equipment.Armors;
using ProjectRPG.Game;
using System.Numerics;

namespace ProjectRPG.Events
{
    public class GameEvent<ItemType>
    {
        #region Fields and properties
        public int IdEvent { get; set; }
        public string Name { get; set; }
        public List<string> Script { get; set; }
        public ItemType Reward { get; set; }
        public Fight Fight { get; set; }
        #endregion

        #region Constructors
        public GameEvent(int idEvent, string name, List<string> script, ItemType reward, Fight fight)
        {
            IdEvent = idEvent;
            Name = name;
            Script = script;
            Reward = reward;
            Fight = fight;
        }
        
        public GameEvent() { }
        #endregion

        #region Methods
        public void EquipItem(Player player) 
        {
            if (Reward is Weapon)
            {
                player.PlayerHero.Inventory.AddWeapon(player.PlayerHero.Weapon);
                player.PlayerHero.Weapon = Reward as Weapon;
            }
            else if (Reward is Armor) 
            {
                player.PlayerHero.Inventory.AddArmor(player.PlayerHero.Armor);
                player.PlayerHero.Armor = Reward as Armor;
            }
            else if (Reward is Helmet)
            {
                player.PlayerHero.Inventory.AddHelmet(player.PlayerHero.Helmet);
                player.PlayerHero.Helmet = Reward as Helmet;
            }
            else if (Reward is Necklace)
            {
                player.PlayerHero.Inventory.AddNecklace(player.PlayerHero.Necklace);
                player.PlayerHero.Necklace = Reward as Necklace;
            }
            else if (Reward is Boot)
            {
                player.PlayerHero.Inventory.AddBoots(player.PlayerHero.Boots);
                player.PlayerHero.Boots = Reward as Boot;
            }
        }

        public async Task PrintScriptProlog(Player player)
        {
            Console.WriteLine($"||||  {Name}  ||||");
            for (int i = 0; i < Script.Count - 1; i++)
            {
                Script[i] = Script[i].Replace("{Name}", player.PlayerHero.Name);
                foreach (char c in Script[i])
                {
                    Console.Write(c);
                    await Task.Delay(20);
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.WriteLine();
            }
            Console.Clear();
        }

        public async Task PrintScriptEnding(Player player)
        {
            Console.WriteLine($"||||  {Name}  ||||");
            foreach (char c in Script.LastOrDefault())
            {
                Console.Write(c);
                await Task.Delay(20);
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }
        public async Task PlayEvent(Player player)
        {
            await PrintScriptProlog(player);
            bool fightResult = Fight.StartFight();

            if (fightResult) 
            {
                EquipItem(player);
                player.PlayerHero.UpdateHero();
                Console.WriteLine($"You have captured {Reward.GetType().Name}, you can check it in the hero panel");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
                await PrintScriptEnding(player);
                player.ShowHero();
            }
            else
            {
                player.PlayerHero.UpdateHeroDeath();
                Console.WriteLine("SMIERC");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        #endregion
    }
}
