using ProjectRPG.Monsters;
using ProjectRPG.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Events;
using ProjectRPG.Equipment.Weapons;
using System.Threading.Channels;
using ProjectRPG.Heroes;

namespace ProjectRPG.Game
{
    public class Game
    {
        public void StartGame()
        {
            Player player = new();

            ///ITEMS
            string filePathWeapons = "WEAPONS.TXT"; // Ścieżka do pliku ITEMS.TXT
            string filePathArmors = "ARMORS.TXT"; // Ścieżka do pliku ITEMS.TXT
            string filePathHelmets = "HELMETS.TXT"; // Ścieżka do pliku ITEMS.TXT
            string filePathNecklaces = "NECKLACES.TXT"; // Ścieżka do pliku ITEMS.TXT
            string filePathBoots = "BOOTS.TXT"; // Ścieżka do pliku ITEMS.TXT
            ItemLoader itemLoader = new();
            itemLoader.LoadItemsFromFile(filePathWeapons, filePathArmors, filePathHelmets, filePathNecklaces, filePathBoots);

            //MONSTERS
            string filePathMonsters = "MONSTERS.TXT";
            MonsterLoader monsterLoader = new();
            monsterLoader.LoadMonsters(filePathMonsters);


            //EVENTS
            string filePathWarriorEvents = "WARRIOREVENTS.TXT";
            string filePathScript = "SCRIPT.TXT";
            Events.GameEventLoader gameEventLoader = new();
            gameEventLoader.LoadWarriorGameEventData(filePathWarriorEvents, filePathScript, itemLoader.Weapons, itemLoader.Armors, itemLoader.Helmets, itemLoader.Boots, itemLoader.Necklaces, monsterLoader.Monsters, player);

            //test
            //gameEventLoader.GameEventsScript[0].ForEach(item => Console.WriteLine(item));

            //test
            //Console.WriteLine(eventHandler.WarriorEvents.Event01.Reward.Name);


            Spider spider = new Spider("Spider", 1, 500, 50, 30, "Poison bite");
            Goblin goblin = new Goblin("Goblin", 1, 100, 20, 10, "Cut");
            Fight fight = new(player, spider);
            player.ChooseHero();           
            Console.Clear();
            //fight.StartFight();

            PlayEvent(player, player.PlayerClassName, gameEventLoader);
        }

        public void PlayEvent(Player player, string heroType, GameEventLoader gameEventLoader)
        {
            if (heroType == "WARRIOR")
            { 
                player.ShowHero();
                gameEventLoader.WarriorEvents.Event01.Script.ForEach(item => Console.WriteLine(item));
                Console.ReadKey();
                Console.Clear();
                gameEventLoader.WarriorEvents.Event01.Fight.StartFight();
            }
            else if (heroType == "SORCERER")
            {

            }
            else if (heroType == "ROGUE")
            {

            }

        }
    }
}
