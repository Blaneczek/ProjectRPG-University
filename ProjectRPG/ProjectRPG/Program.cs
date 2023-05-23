using ProjectRPG;
using ProjectRPG.Game;
using System.Xml;

ItemLoader itemLoader = new ItemLoader();
string filePath = "ITEMS.TXT"; // Ścieżka do pliku ITEMS.TXT
itemLoader.LoadItemsFromFile(filePath);
itemLoader.PrintItems();
//Game game = new Game();

//game.StartGame();



