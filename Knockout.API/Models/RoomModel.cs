using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout.API.Models
{
    public class RoomModel
    {
        public RoomModel(int id, string title, string description = "")
        {
            ID = id;
            Title = title;
            Description = description;
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}