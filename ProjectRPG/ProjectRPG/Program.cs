using ProjectRPG;
using ProjectRPG.Game;
using System.Xml;


ItemLoader itemLoader = new ItemLoader();
string filePathWeapons = "WEAPONS.TXT"; 
string filePathArmors = "ARMORS.TXT"; 
string filePathHelmets = "HELMETS.TXT"; 
string filePathNecklaces = "NECKLACES.TXT"; 
string filePathBoots = "BOOTS.TXT"; 
itemLoader.LoadItemsFromFile(filePathWeapons, filePathArmors, filePathHelmets, filePathNecklaces, filePathBoots);

Game game = new Game();

game.StartGame();


