define([], function () {

    return (function (room) {
        var self = this;

        self.ID = ko.observable(room.ID);
        self.Title = ko.observable(room.Title);
        self.Description = ko.observable(room.Description);

        return {
            id: self.ID,
            title: self.Title,
            description: self.Description
        }
    })

})
