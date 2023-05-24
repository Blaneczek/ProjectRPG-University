using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Events
{
    public class Event<ItemType>
    {
        public int IdEvent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Reward { get; set; }

        public Event(int idEvent, string name, string description, ItemType reward)
        {
            IdEvent = idEvent;
            Name = name;
            Description = description;
            Reward = reward;
        }
    }
}
