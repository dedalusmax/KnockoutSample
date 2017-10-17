using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout.API.Models
{
    public class SessionModel
    {
        public SessionModel(int id, string title, RoomModel room, List<SpeakerModel> speakers, int slot, string description = "", int level = 100, bool interactive = false)
        {
            ID = id;
            Title = title;
            Description = description;
            Room = room;
            Speakers = speakers;
            Slot = slot;
            Level = level;
            Interactive = interactive;
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public bool Interactive { get; set; }
        public RoomModel Room { get; set; }
        public int Slot { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public List<SpeakerModel> Speakers { get; set; }
    }
}