define([], function () {

    return (function (speaker) {
        var self = this;

        self.ID = ko.observable(speaker.ID);
        self.Title = ko.observable(speaker.Title);
        self.Type = ko.observable(speaker.Type);

        return {
            id: self.ID,
            title: self.Title,
            type: self.Type
        }
    });
})
