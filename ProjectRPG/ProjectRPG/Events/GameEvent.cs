using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Monsters;
using ProjectRPG.Game;

namespace ProjectRPG.Events
{
    public class GameEvent<ItemType>
    {
        public int IdEvent { get; set; }
        public string Name { get; set; }
        public List<string> Script { get; set; }
        public ItemType Reward { get; set; }
        public Fight Fight { get; set; }
        public GameEvent(int idEvent, string name, List<string> script, ItemType reward, Fight fight)
        {
            IdEvent = idEvent;
            Name = name;
            Script = script;
            Reward = reward;
            Fight = fight;
        }

        public GameEvent() { }
    }
}
