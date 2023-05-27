using ProjectRPG.Monsters;
using ProjectRPG.Events;
using ProjectRPG.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


            player.ChooseHero();           
            Console.Clear();
            if (player != null && player.PlayerClassName != null && gameEventLoader != null)
            {
                PlayEvents(player, player.PlayerClassName, gameEventLoader);
            }
            else
            {
                Console.WriteLine("Something is not right.... Reset game");
            }
            
        }

        public void PlayEvents(Player player, string heroType, GameEventLoader gameEventLoader)
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
