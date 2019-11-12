(function () {
    'use strict'
    app.controller("chatController", function ($scope, $rootScope, signalR,Flash) {
    $scope.$parent.UserName = "";
    $scope.rooms = [];// RoomFactory.Rooms;
    $scope.$parent.UserName = $("h4#userNick").text();;  // prompt("Enter unique name :");
    signalR.startHub();  
    $scope.activeRoom = '';
    $scope.chatHistory = [];
    $scope.Users = []
    $scope.RoomsLoggedId = [];     
    $scope.typemsgdisable = true;  
    signalR.UserEntered(function (room, user,cid) {
         if ($scope.activeRoom == room&&user!='') {          
            var result = $.grep($scope.users, function (e) { return e.name == user; })
            console.log("----------");           
            console.log(result);
            if (result != undefined || result != null) {
                $scope.users.push({ name: user, ConnectionId: cid });
                $scope.$apply();
            }
        }
    });
    signalR.UserLoggedOut(function (room, user) {
        if ($scope.activeRoom == room && user != '') {          
            $scope.users = $scope.users.filter(function (themObjects) {
                return themObjects.name != user;
            });          
               $scope.$apply();
            }        
    });

  //  Flash.add('success', message, 'custom-class')
    signalR.Login($scope.$parent.UserName);
    ///////////////// server
    
   
    $scope.UsersCount = 0;
    $scope.bubblesCount = [];
    $scope.maxBubbles = 10;
            
        $scope.ClosePrivateWindow = function ()
        {
            $scope.ShowPrivateWindow = false;
        }
   
        $scope.UserInPrivateChat = null;
        $scope.ShowPrivateWindow = false;
        $scope.PrivateMessages = [];
        $scope.currentprivatemessages = {};
        $scope.pvtmessage = '';
      $scope.OpenPrivatewindow = function (index) {
        
        var user = $scope.users[index];
      //  var conId = '#' + user.ConnectionId;
        $scope.ShowPrivateWindow = true;
        $scope.UserInPrivateChat = user;
        $scope.$apply();
       // $scope.createPrivateChatWindow($scope.$parent.UserName, conId, user.name)
      }
  
        $scope.SendPrivateMessage = function ()
        {            
           // debugger;
            signalR.SendPrivateMessage($scope.UserInPrivateChat.ConnectionId, $scope.pvtmessage);
            $scope.pvtmessage = '';
        }
        $scope.OnlineUsers = [];
        signalR.GetOnlineUsers(function (onlineUsers) {
            $scope.OnlineUsers = $.parseJSON(onlineUsers);
            console.log($scope.OnlineUsers);
            $scope.$apply();
        });
        $scope.ChangeStatus = function (status) {
            signalR.UpdateStatus(status);
        }
        signalR.NewOnlineUser(function (user) {
            $scope.OnlineUsers.push(user);
            $scope.$apply();
            var message = '<strong> !!</strong>' + user.name + ' in online';
            Flash.create('success', message, 'custom-class');
        });            
        signalR.NewOfflineUser(function (user) {
            $.each($scope.OnlineUsers, function (i) {
                if ($scope.OnlineUsers[i].name === user.name && $scope.OnlineUsers[i].ConnectionId==user.ConnectionId) 
                    {
                    $scope.OnlineUsers.splice(i, 1);
                    var message = '<strong> !! ' + user.name + '</strong> left the chat ';
                debugger;
                Flash.create('danger', message); 
                }
            });
           // $scope.OnlineUsers.push(user);
            $scope.$apply();
        });        
        $scope.SkeyPress =function(e) {
            if (e.which == 13)
            {
                $scope.SendPrivateMessage();
                $scope.usertyping = ''
            }
            else if (e.which == 46 || e.which == 8) {
                signalR.UserTyping($scope.UserInPrivateChat.ConnectionId, 'Deleting..');
                window.setTimeout(function () {
                    $scope.usertyping = '';
                }, 500);
            }
            else {              
                signalR.UserTyping($scope.UserInPrivateChat.ConnectionId, 'Typing..');
                window.setTimeout(function () {
                    $scope.usertyping = '';
                }, 500);
            }
        }
       // PrivateMessage($index)
        $scope.PrivateMessage = function (index) {
            debugger;
            var user = $scope.OnlineUsers[index];
            $scope.ShowPrivateWindow = true;
            $scope.UserInPrivateChat = user;
            console.log($scope.OnlineUsers);    
            $scope.$apply();
        };
        $scope.usertyping = '';
        signalR.IsTyping(function (connectionid, msg) {            
            if ($scope.UserInPrivateChat.ConnectionId == connectionid)
                $scope.usertyping = msg;
            else
                $scope.usertyping = '';
            $scope.$apply();
            window.setTimeout(function () {
                $scope.usertyping = '';
                $scope.$apply();
            }, 500);
        });
        signalR.StatusChanged(function (connectionId, status)
        {
            $.each($scope.OnlineUsers, function (i) {
                if ($scope.OnlineUsers[i].ConnectionId === connectionId) {
                    $scope.OnlineUsers[i].status = status;                    
                }
            });
            // $scope.OnlineUsers.push(user);
            $scope.$apply();

        });
        signalR.RecievingPrivateMessage(function (toname,fromname, msg) {
           if ($scope.ShowPrivateWindow == false) {
                $scope.ShowPrivateWindow = true;
            }
           // var msgBdy = { room: r, msgx: { message: msg.message, sender: msg.sender, css: msg.css } };
            //$scope.chatHistory.push(msgBdy);
            $scope.PrivateMessages.push({ to: toname, from: fromname, message: msg });

            if ($scope.$parent.UserName != fromname) // otheruser's pm
            {
                if ($scope.UserInPrivateChat == null)
                {
                    $scope.UserInPrivateChat = { name: fromname, ConnectionId: toname }
                }
            }
            /// To Scroll the message window.
            if ($("#PrivateChatArea div.panel-body").length == 1) {
            var    $container = $("#PrivateChatArea div.panel-body");
                $container[0].scrollTop = $container[0].scrollHeight;
                $container.animate({ scrollTop: $container[0].scrollHeight }, "fast");
            }
            $scope.$evalAsync();
           // $scope.AddMessageToRoom(msgBdy);
        });
});

//////////////////////////////////////////////

function OpenPrivateChatWindow(chatHub, id, userName) {
    var ctrId = 'private_' + id;
    if ($('#' + ctrId).length > 0) return;
    createPrivateChatWindow(chatHub, id, ctrId, userName);

}
})();