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
            Task itemLoaderTask = itemLoader.LoadItemsFromFile(filePathWeapons, filePathArmors, filePathHelmets, filePathNecklaces, filePathBoots);

            //MONSTERS
            string filePathMonsters = "MONSTERS.TXT";
            Task monsterLoaderTask = monsterLoader.LoadMonsters(filePathMonsters);

            await Task.WhenAll(itemLoaderTask, monsterLoaderTask);
            //EVENTS
            string filePathEvents = "EVENTS.TXT";
            string filePathScript = "SCRIPT.TXT";
            Task gameEventLoaderTask = gameEventLoader.LoadGameEventData(filePathEvents, filePathScript, itemLoader.Weapons, itemLoader.Armors, itemLoader.Helmets, itemLoader.Boots, itemLoader.Necklaces, monsterLoader.Monsters, player);

            Task playStartTask = PlayStart(player);

            await Task.WhenAll(gameEventLoaderTask, playStartTask);

            if (player != null && player.PlayerClassName != null && gameEventLoader != null)
            {
                await PlayEvents(player, player.PlayerClassName, gameEventLoader);
            }
            else
            {
                Console.WriteLine("Something is not yes.. Reset game");
            }
        }

        public async Task PlayStart(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("                   TO DENY THE DARKNESS       ");
            Console.WriteLine("                  Morgorath's  Awakening");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...       ");
            Console.ReadKey(true);
            Console.Clear();
            await player.ChooseHero();
            Console.Clear();
        }

        public async Task PlayEvents(Player player, string heroType, GameEventLoader gameEventLoader)
        {

            if (heroType == "WARRIOR")
            {
                player.ShowHero();
                await PrintProlog(player);
                if(!await gameEventLoader.WarriorEvents.Event01.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.WarriorEvents.Event02.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.WarriorEvents.Event03.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.WarriorEvents.Event04.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.WarriorEvents.Event05.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.WarriorEvents.Event06.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.WarriorEvents.Event07.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.WarriorEvents.Event08.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.WarriorEvents.Event09.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                else
                {
                    await PrintEpilog(player, true);
                    return;
                }
            }
            else if (heroType == "SORCERER")
            {
                player.ShowHero();
                await PrintProlog(player);
                if (!await gameEventLoader.SorcererEvents.Event01.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.SorcererEvents.Event02.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.SorcererEvents.Event03.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.SorcererEvents.Event04.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.SorcererEvents.Event05.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.SorcererEvents.Event06.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.SorcererEvents.Event07.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.SorcererEvents.Event08.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.SorcererEvents.Event09.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                else
                {
                    await PrintEpilog(player, true);
                    return;
                }
            }
            else if (heroType == "ROGUE")
            {
                player.ShowHero();
                await PrintProlog(player);
                if (!await gameEventLoader.RogueEvents.Event01.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.RogueEvents.Event02.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.RogueEvents.Event03.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.RogueEvents.Event04.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.RogueEvents.Event05.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.RogueEvents.Event06.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.RogueEvents.Event07.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.RogueEvents.Event08.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                if (!await gameEventLoader.RogueEvents.Event09.PlayEvent(player))
                {
                    await PrintEpilog(player, false);
                    return;
                }
                else
                {
                    await PrintEpilog(player, true);
                    return;
                }
            }
        }

        public async Task PrintProlog(Player player)
        {
            string prolog = $"In a land plagued by darkness and despair, our valiant hero {player.PlayerHero.Name} sets forth on a perilous journey to vanquish the Demon King, Morgorath." +
                $"\nDetermined to restore light and peace to the realm, {player.PlayerHero.Name} braves treacherous landscapes, battles formidable creatures, and uncovers the secrets of Morgorath's malevolent reign.";
            foreach (char c in prolog)
            {
                Console.Write(c);
                await Task.Delay(10);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        public async Task PrintEpilog(Player player, bool result)
        {
            string epilog = string.Empty;

            if (result)
            {
                epilog = $"{player.PlayerHero.Name} returns to the capital as a hero, greeted by cheering crowds and grateful citizens." +
                                $"\nThe news of his victory spreads far and wide, inspiring hope in the hearts of people everywhere." +
                                $"\nHe is hailed as the savior of the realm, the one who vanquished the darkness and brought peace." +
                                $"\n\nIn recognition of his bravery and valor, {player.PlayerHero.Name} is honored by the King. He is bestowed with the title of \"Champion of Light\" and given a place of honor among the kingdom's most esteemed warriors." +
                                $"\nThe people sing songs of his triumph and tell tales of his heroic deeds for generations to come." +
                                $"\nAnd so, the tale of {player.PlayerHero.Name}, the Hero of Light, is etched into the annals of history, a testament to the power of courage, determination, and the indomitable spirit of a true hero.";
            }
            else
            {
                epilog = $"In a heart-wrenching turn of events, {player.PlayerHero.Name}, valiant and determined, fell before the overwhelming might of Morgorath and his demonic forces. " +
                            $"\nThe enemy's victory cast a shadow of despair and sorrow upon the land, plunging it into an era of darkness and subjugation." +
                            $"\n\nWith {player.PlayerHero.Name}'s defeat, hope dwindled, and the people's spirits were crushed under the weight of tyranny. Morgorath, emboldened by his triumph, unleashed his wicked reign upon the kingdom, enslaving its inhabitants and subjecting them to his cruel rule." +
                            $"\n\nThe land, once vibrant and full of life, now languished under the oppressive rule of the enemy. {player.PlayerHero.Name}'s memory became a whisper, a bittersweet reminder of the valor and sacrifice that had been in vain. The people lived in fear, their dreams of freedom and peace shattered.";
            }


            foreach (char c in epilog)
            {
                Console.Write(c);
                await Task.Delay(10);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("                         THE END                   ");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
