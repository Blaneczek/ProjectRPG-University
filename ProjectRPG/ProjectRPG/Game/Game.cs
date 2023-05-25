using ProjectRPG.Monsters;
using ProjectRPG.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Events;
using ProjectRPG.Equipment.Weapons;

namespace ProjectRPG.Game
{
    public class Game
    {
        public void StartGame()
        {           
            string filePathWeapons = "WEAPONS.TXT"; // Ścieżka do pliku ITEMS.TXT
            string filePathArmors = "ARMORS.TXT"; // Ścieżka do pliku ITEMS.TXT
            string filePathHelmets = "HELMETS.TXT"; // Ścieżka do pliku ITEMS.TXT
            string filePathNecklaces = "NECKLACES.TXT"; // Ścieżka do pliku ITEMS.TXT
            string filePathBoots = "BOOTS.TXT"; // Ścieżka do pliku ITEMS.TXT

            ItemLoader itemLoader = new();
            itemLoader.LoadItemsFromFile(filePathWeapons, filePathArmors, filePathHelmets, filePathNecklaces, filePathBoots);

            Events.GameEventLoader eventHandler = new();
            //eventHandler.LoadWarriorGameEventData("WARRIOREVENTS.TXT", itemLoader.Weapons, itemLoader.Armors, itemLoader.Helmets, itemLoader.Boots, itemLoader.Necklaces);
            //test
            //Console.WriteLine(eventHandler.WarriorEvents.Event01.Reward.Name);

            Fight fight = new();
            Player player = new();
            Spider spider = new Spider("Spider", 1, 500, 50, 30, "Poison bite");
            Goblin goblin = new Goblin("Goblin", 1, 100, 20, 10, "Cut");

            player.ChooseHero();
            player.ShowHero();
            Console.Clear();
            fight.StartFight(player, spider);
        }
    }
}
