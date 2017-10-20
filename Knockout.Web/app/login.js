define(['service'], function (service) {

    return (function () {
        var self = this;

        self.username = ko.observable("user");
        self.password = ko.observable("pass");
        self.isInvalidLogin = ko.observable(false);
        self.authenticated = ko.observable(true);

        self.doLogin = function (data) {
            self.isInvalidLogin(false);

            if (service.doLogin(self.username(), self.password())) {
                self.authenticated(true);
            } else {
                self.isInvalidLogin(true);
            }

            return false;
        };

        return {
            username: self.username,
            password: self.password,
            authenticated: self.authenticated,
            isInvalidLogin: self.isInvalidLogin,
            doLogin: self.doLogin
        }
    }());

});
