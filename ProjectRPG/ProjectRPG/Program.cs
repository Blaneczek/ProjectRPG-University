using ProjectRPG;
using ProjectRPG.Game;
using System.Xml;


ItemLoader itemLoader = new ItemLoader();
string filePathWeapons = "WEAPONS.TXT"; // Ścieżka do pliku ITEMS.TXT
string filePathArmors = "ARMORS.TXT"; // Ścieżka do pliku ITEMS.TXT
string filePathHelmets = "HELMETS.TXT"; // Ścieżka do pliku ITEMS.TXT
string filePathNecklaces = "NECKLACES.TXT"; // Ścieżka do pliku ITEMS.TXT
string filePathBoots = "BOOTS.TXT"; // Ścieżka do pliku ITEMS.TXT
itemLoader.LoadItemsFromFile(filePathWeapons, filePathArmors, filePathHelmets, filePathNecklaces, filePathBoots);

Game game = new Game();

game.StartGame();


