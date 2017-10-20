using Knockout.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Hosting;
using System.IO;

namespace Knockout.API.Controllers
{
    public class DataController : BaseController
    {
        private static List<KeyValuePair<Guid, List<byte[]>>> _messages;

        public static List<KeyValuePair<Guid, List<byte[]>>> Messages
        {
            get
            {
                if (_messages == null)
                    _messages = new List<KeyValuePair<Guid, List<byte[]>>>();

                return _messages;
            }
        }


        public DataController() { }

        public IHttpActionResult Post(MessageModel message)
        {
            try
            {
                if (message.Type == EnumMessageType.START)
                {
                    // Clears previous message if exists and starts new one
                    Messages.Remove(Messages.FirstOrDefault(m => m.Key == message.ID));
                    // Adds new message with id and empty data
                    Messages.Add(new KeyValuePair<Guid, List<byte[]>>(message.ID, new List<byte[]>()));
                }
                else if (message.Type == EnumMessageType.DATA)
                {
                    var msg = Messages.FirstOrDefault(m => m.Key == message.ID);
                    msg.Value.Add(message.Data);
                }
                else if (message.Type == EnumMessageType.END)
                {
                    var msg = Messages.FirstOrDefault(m => m.Key == message.ID);
                    var fileName = Path.Combine(HostingEnvironment.MapPath("~/Data"), String.Format("{0}.bin", msg.Key));

                    FileInfo f = new FileInfo(fileName);

                    using (FileStream fs = f.OpenWrite())
                    {
                        foreach (var data in msg.Value)
                        {
                            foreach (var b in data)
                            {
                                fs.WriteByte(b);
                            }
                        }
                    }

                    // Removes message from the list
                    Messages.Remove(Messages.FirstOrDefault(m => m.Key == message.ID));
                }
                else
                {
                    throw new Exception("Unsupported message type");
                }

                return Ok("Data received");
            }
            catch (Exception ex)
            {
                // TODO log/trace error
                return InternalServerError(ex);
            }
        }
    }
}