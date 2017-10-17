define([], function () {

    return (function (session) {
        var self = this;

        self.ID = ko.observable(session.ID);
        self.Title = ko.observable(session.Title);
        self.Description = ko.observable(session.Description);
        self.Level = ko.observable(session.Level);
        self.Interactive = ko.observable(session.Interactive);
        self.Room = ko.observable(session.Room);
        self.Slot = ko.observable(session.Slot);
        self.DateStart = ko.observable(session.DateStart);
        self.DateEnd = ko.observable(session.DateEnd);
        self.Speakers = ko.observable(session.Speakers);

        return {
            id: self.ID,
            title: self.Title,
            description: self.Description,
            level: self.Level,
            interactive: self.Interactive,
            room: self.Room,
            slot: self.Slot,
            dateStart: self.DateStart,
            dateEnd: self.DateEnd,
            speakers: self.Speakers
        }
    });

})

