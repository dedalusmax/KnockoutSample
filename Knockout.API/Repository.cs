using Knockout.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knockout.API
{
    public class Repository
    {
        private static List<SpeakerModel> _speakers;
        private static List<RoomModel> _rooms;
        private static List<SessionModel> _sessions;

        public IEnumerable<SpeakerModel> GetSpeakers()
        {
            if (_speakers == null)
            {
                _speakers = new List<SpeakerModel>();
                _speakers.Add(new SpeakerModel(1, "Predavač 1", EnumSpeakerType.Main));
                _speakers.Add(new SpeakerModel(2, "Predavač 2", EnumSpeakerType.Main));
                _speakers.Add(new SpeakerModel(3, "Predavač 3", EnumSpeakerType.Assistant));
                _speakers.Add(new SpeakerModel(4, "Predavač 4", EnumSpeakerType.External));
                _speakers.Add(new SpeakerModel(5, "Predavač 5", EnumSpeakerType.External));
                _speakers.Add(new SpeakerModel(6, "Predavač 6", EnumSpeakerType.Main));
            }

            return _speakers;
        }

        public IEnumerable<RoomModel> GetRooms()
        {
            if (_rooms == null)
            {
                _rooms = new List<RoomModel>();
                _rooms.Add(new RoomModel(1, "Room 1", "Glavna sala"));
                _rooms.Add(new RoomModel(2, "Room 2", "Konferencijska sala"));
                _rooms.Add(new RoomModel(3, "Room 3", "Pomoćna sala"));
            }

            return _rooms;
        }

        public IEnumerable<SessionModel> GetSessions()
        {
            if (_sessions == null)
            {
                _sessions = new List<SessionModel>();
                _sessions.Add(new SessionModel(1, "Predavanje 1", GetRooms().First(r => r.ID == 1), GetSpeakers().Where(s => (s.ID % 2) == 0).ToList(), 0, "Opis 1", 100, false));
                _sessions.Add(new SessionModel(2, "Predavanje 2", GetRooms().First(r => r.ID == 2), GetSpeakers().Where(s => (s.ID % 2) == 1).ToList(), 1, "Opis 2", 200, true));
                _sessions.Add(new SessionModel(3, "Predavanje 3", GetRooms().First(r => r.ID == 3), GetSpeakers().Where(s => (s.ID % 2) == 0).ToList(), 2, "Opis 3", 300, false));
                _sessions.Add(new SessionModel(4, "Predavanje 4", GetRooms().First(r => r.ID == 1), GetSpeakers().Where(s => (s.ID % 2) == 1).ToList(), 3, "Opis 4", 100, true));
            }

            return _sessions;
        }
    }
}