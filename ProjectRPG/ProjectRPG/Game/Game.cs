using ProjectRPG.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Game
{
    public class Game
    {
        public void StartGame()
        {

            ItemLoader itemLoader = new ItemLoader();
            string filePathWeapons = "WEAPONS.TXT"; // Ścieżka do pliku ITEMS.TXT
            string filePathArmors = "ARMORS.TXT"; // Ścieżka do pliku ITEMS.TXT
            string filePathHelmets = "HELMETS.TXT"; // Ścieżka do pliku ITEMS.TXT
            string filePathNecklaces = "NECKLACES.TXT"; // Ścieżka do pliku ITEMS.TXT
            string filePathBoots = "BOOTS.TXT"; // Ścieżka do pliku ITEMS.TXT
            itemLoader.LoadItemsFromFile(filePathWeapons, filePathArmors, filePathHelmets, filePathNecklaces, filePathBoots);

            Fight fight = new Fight();

            Player player = new Player();

            Spider spider = new Spider("Spider", 1, 500, 50, 30, "Poison bite");

            Goblin goblin = new Goblin("Goblin", 1, 100, 20, 10, "Cut");
            player.ChooseHero();
            player.ShowHero();
            Console.Clear();
            fight.StartFight(player, spider);
        }
    }
}
