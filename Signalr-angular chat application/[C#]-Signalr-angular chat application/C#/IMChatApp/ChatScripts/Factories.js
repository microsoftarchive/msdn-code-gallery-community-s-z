app.factory("signalR", function ($rootScope) {
    var $hub = $.connection.chat;
    var connection = null;
    var signalR = {
        startHub: function () {
            console.log("started");
            connection=$.connection.hub.start();
        },
        //////////////////// SERVER METHODS/////////////////
        Login: function (username) {         
            connection.done(function () {
                $hub.server.login(username);
            });
        },       
        SendPrivateMessage: function (touser,message) {
            connection.done(function () {
                $hub.server.sendPrivateMessage(touser, message);
            });
        },
        UpdateStatus: function (status) {
            connection.done(function () {
                $hub.server.updateStatus(status);
            });
        },
        UserTyping: function (connectionid, msg) {
            connection.done(function () {
                $hub.server.userTyping(connectionid, msg);
            });
        },
        ////////////////////// CLIENT METHODS////////////////////            
        joinroom: function (callback) {
            $hub.client.joinroom = callback;
        },       
        UserEntered: function (callback) {
            $hub.client.userEntered = callback;
        },
        UserLoggedOut:function (callback) {
            $hub.client.userLoggedOut = callback;    
        },
        RecievingPrivateMessage:function (callback) {
            $hub.client.sendPrivateMessage = callback; 
        },
        GetOnlineUsers: function (callback) {
            $hub.client.getOnlineUsers = callback;
        },
        NewOnlineUser: function (callback) {
            $hub.client.newOnlineUser = callback;
        },
        NewOfflineUser: function (callback) {
            $hub.client.newOfflineUser = callback;
        },
        StatusChanged: function (callback) {
            $hub.client.statusChanged = callback;
        },
        IsTyping: function (callback) {
            $hub.client.isTyping = callback;
        }

        
    }
    return signalR;
});