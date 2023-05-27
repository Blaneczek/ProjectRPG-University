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

namespace ProjectRPG.Game
{
    public class Game
    {
        public async Task StartGame()
        {
            Player player = new();

            ///ITEMS
            string filePathWeapons = "WEAPONS.TXT"; 
            string filePathArmors = "ARMORS.TXT"; 
            string filePathHelmets = "HELMETS.TXT"; 
            string filePathNecklaces = "NECKLACES.TXT"; 
            string filePathBoots = "BOOTS.TXT"; 
            ItemLoader itemLoader = new();
            itemLoader.LoadItemsFromFile(filePathWeapons, filePathArmors, filePathHelmets, filePathNecklaces, filePathBoots);

            //MONSTERS
            string filePathMonsters = "MONSTERS.TXT";
            MonsterLoader monsterLoader = new();
            monsterLoader.LoadMonsters(filePathMonsters);


            //EVENTS
            string filePathEvents = "EVENTS.TXT";
            string filePathScript = "SCRIPT.TXT";
            Events.GameEventLoader gameEventLoader = new();
            gameEventLoader.LoadWarriorGameEventData(filePathEvents, filePathScript, itemLoader.Weapons, itemLoader.Armors, itemLoader.Helmets, itemLoader.Boots, itemLoader.Necklaces, monsterLoader.Monsters, player);

            player.ChooseHero();           
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
                await gameEventLoader.WarriorEvents.Event01.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event02.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event03.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event04.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event05.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event06.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event07.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event08.PlayEvent(player);
                await gameEventLoader.WarriorEvents.Event09.PlayEvent(player);

            }
            else if (heroType == "SORCERER")
            {
                player.ShowHero();
                await gameEventLoader.SorcererEvents.Event01.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event02.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event03.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event04.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event05.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event06.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event07.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event08.PlayEvent(player);
                await gameEventLoader.SorcererEvents.Event09.PlayEvent(player);
            }
            else if (heroType == "ROGUE")
            {
                player.ShowHero();
                await gameEventLoader.RogueEvents.Event01.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event02.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event03.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event04.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event05.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event06.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event07.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event08.PlayEvent(player);
                await gameEventLoader.RogueEvents.Event09.PlayEvent(player);
            }
        }      
    }
}
