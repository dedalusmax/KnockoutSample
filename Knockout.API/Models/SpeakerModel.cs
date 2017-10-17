using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout.API.Models
{
    public enum EnumSpeakerType
    {
        Main,
        Assistant,
        External
    }

    public class SpeakerModel
    {
        public SpeakerModel(int id, string title, EnumSpeakerType type, string image = "", string description = "")
        {
            ID = id;
            Title = title;
            Type = type;
            Image = image;
            Description = description;
        }

        public int ID { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public EnumSpeakerType Type { get; set; }
    }
}