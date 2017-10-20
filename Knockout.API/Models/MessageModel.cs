using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout.API.Models
{
    public class MessageModel
    {
        public Guid ID { get; set; }
        public EnumMessageType Type { get; set; }
        public int Size { get; set; }

        //public string Data { get; set; }
        public byte[] Data { get; set; }
    }
}