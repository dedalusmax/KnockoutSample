var mainViewModel = (function () {
    var self = this;

    self.authenticated = ko.observable(false);
    self.isLoading = ko.observable(true);

    self.sessions = ko.observableArray([]);
    self.speakers = ko.observableArray([]);
    self.rooms = ko.observableArray([]);
    self.login = ko.observable(new loginViewModel());

    self.selectedOption = ko.observable('sessions');

    self.logout = function () {
        self.authenticated(false);
    }

    self.displayOption = function (option) {

        self.isLoading(true);

        if (option == 'sessions') {
            var sessions = service.getSessions().done(function (data) {
                self.sessions(data);
                self.isLoading(false);
            });
            
        } else if (option == 'speakers') {
            var speakers = service.getSpeakers().done(function (data) {
                self.speakers(data);
                self.isLoading(false);
            });
        } else if (option == 'rooms') {
            var rooms = service.getRooms().done(function (data) {
                self.rooms(data);
                self.isLoading(false);
            });
        }

        self.selectedOption(option);
    }

    self.displayOption(self.selectedOption());

    return {
        authenticated: self.authenticated,
        isLoading : self.isLoading,
        sessions: self.sessions,
        speakers: self.speakers,
        rooms: self.rooms,
        login: self.login,
        selectedOption: self.selectedOption,
        logout: self.logout,
        displayOption : self.displayOption
    }
});
