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
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Numerics;

namespace ProjectRPG.Game
{
    public class Game
    {
        public async Task StartGame()
        {
            Player player = new();
            ItemLoader itemLoader = new();
            MonsterLoader monsterLoader = new();
            GameEventLoader gameEventLoader = new();

            //Items
            string filePathWeapons = "WEAPONS.TXT"; 
            string filePathArmors = "ARMORS.TXT"; 
            string filePathHelmets = "HELMETS.TXT"; 
            string filePathNecklaces = "NECKLACES.TXT"; 
            string filePathBoots = "BOOTS.TXT";           
            await itemLoader.LoadItemsFromFile(filePathWeapons, filePathArmors, filePathHelmets, filePathNecklaces, filePathBoots);

            //MONSTERS
            string filePathMonsters = "MONSTERS.TXT";          
            await monsterLoader.LoadMonsters(filePathMonsters);


            //EVENTS
            string filePathEvents = "EVENTS.TXT";
            string filePathScript = "SCRIPT.TXT";            
            await gameEventLoader.LoadWarriorGameEventData(filePathEvents, filePathScript, itemLoader.Weapons, itemLoader.Armors, itemLoader.Helmets, itemLoader.Boots, itemLoader.Necklaces, monsterLoader.Monsters, player);

            Console.WriteLine("            GAME NAME        ");
            Console.WriteLine();
            Console.WriteLine("    Press any key to continue...       ");
            Console.ReadKey(true);
            Console.Clear();
           
            await player.ChooseHero();           
            Console.Clear();
            if (player != null && player.PlayerClassName != null && gameEventLoader != null)
            {
                await PlayEvents(player, player.PlayerClassName, gameEventLoader);              
            }
            else
            {
                Console.WriteLine("Something is not right.... Reset game");
            }
            
        }

        public async Task PlayEvents(Player player, string heroType, GameEventLoader gameEventLoader)
        {
            
            if (heroType == "WARRIOR")
            { 
                player.ShowHero();
                await PrintProlog(player);
                await gameEventLoader.WarriorEvents.Event01.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event02.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event03.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event04.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event05.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event06.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event07.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event08.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event09.PlayEvent(player);
                await PrintEpilog(player);

            }
            else if (heroType == "SORCERER")
            {
                player.ShowHero();
                await PrintProlog(player);
                await gameEventLoader.SorcererEvents.Event01.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event02.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event03.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event04.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event05.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event06.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event07.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event08.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event09.PlayEvent(player);
                await PrintEpilog(player);
            }
            else if (heroType == "ROGUE")
            {
                player.ShowHero();
                await PrintProlog(player);
                await gameEventLoader.RogueEvents.Event01.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event02.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event03.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event04.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event05.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event06.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event07.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event08.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event09.PlayEvent(player);
                await PrintEpilog(player);
            }
        }

        public async Task PrintProlog(Player player)
        {
            string prolog = $"In a land plagued by darkness and despair, our valiant hero {player.PlayerHero.Name} sets forth on a perilous journey to vanquish the Demon King, Morgorath." +
                $"\nDetermined to restore light and peace to the realm, {player.PlayerHero.Name} braves treacherous landscapes, battles formidable creatures, and uncovers the secrets of Morgorath's malevolent reign."; 
            foreach (char c in prolog)
            {
                Console.Write(c);
                await Task.Delay(20);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        public async Task PrintEpilog(Player player)
        {
            string epilog = $"{player.PlayerHero.Name} returns to the capital as a hero, greeted by cheering crowds and grateful citizens." +
                $"\nThe news of his victory spreads far and wide, inspiring hope in the hearts of people everywhere." +
                $"\nHe is hailed as the savior of the realm, the one who vanquished the darkness and brought peace." +
                $"\n\nIn recognition of his bravery and valor, {player.PlayerHero.Name} is honored by the King. He is bestowed with the title of \"Champion of Light\" and given a place of honor among the kingdom's most esteemed warriors." +
                $"\nThe people sing songs of his triumph and tell tales of his heroic deeds for generations to come." +
                $"\nAnd so, the tale of {player.PlayerHero.Name}, the Hero of Light, is etched into the annals of history, a testament to the power of courage, determination, and the indomitable spirit of a true hero.";
            foreach (char c in epilog)
            {
                Console.Write(c);
                await Task.Delay(20);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("                         THE END                   ");
        }
    }
}
