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
        public string Description { get; set; }
        public ItemType Reward { get; set; }
        public Monster Monster { get; set; }
        public Fight Fight { get; set; }
        public GameEvent(int idEvent, string name, string description, ItemType reward)
        {
            IdEvent = idEvent;
            Name = name;
            Description = description;
            Reward = reward;
        }

    }
}
