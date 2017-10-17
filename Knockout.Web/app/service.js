define(['sessions', 'speakers', 'rooms'], function (sessions, speakers, rooms) {

    return (function () {
        var self = this;
        var apiUrl = 'http://localhost:49316/';

        self.doLogin = function (username, password) {
            if (username == 'user' && password == 'pass') {
                return true;
            }
            else {
                return false;
            }
        }

        self.getSessions = function () {
            var sessionsData = getData('api/sessions').done(function (data) {
                return $.map(sessionsData, function (data) {
                    return new sessions(data);
                });
            });

            return sessionsData;
        }

        self.getRooms = function () {
            var roomsData = getData('api/rooms').done(function (data) {
                return $.map(roomsData, function (data) {
                    return new rooms(data);
                });
            });

            return roomsData;
        }

        self.getSpeakers = function () {
            var speakersData = getData('api/speakers').done(function (data) {
                return $.map(speakersData, function (data) {
                    return new speakers(data);
                });
            });

            return speakersData;
        }

        function getData(url) {
            return $.getJSON(apiUrl + url,
                function (data) {
                    return data;
                })
                .fail(function (jqXHR, textStatus, errorThrown) {
                    console.log('Request failed! ' + ko.toJSON(jqXHR) + ' Error: ' + ko.toJSON(errorThrown) + ' ' + ko.toJSON(textStatus));
                });
        }

        return {
            doLogin: self.doLogin,
            getSessions: self.getSessions,
            getRooms: self.getRooms,
            getSpeakers: self.getSpeakers
        }
    })();

})
