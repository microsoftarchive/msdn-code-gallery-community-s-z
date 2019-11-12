/*

 @Author：Learninghard
 @Date: 2016-04-04
 @Blog: http://www.cnblogs.com/zhili/
 
 */

; !function (win, undefined) {
    var config = {
        msgurl: 'Message',
        chatlogurl: '聊天记录url前缀',
        aniTime: 200,
        right: -232,
        api: {
            friend: 'friend.json', //好友列表接口
            group: 'group.json', //群组列表接口 
            chatlog: 'chatlog.json', //聊天记录接口
            groups: 'groups.json', //群组成员接口
            sendurl: '' //发送消息接口
        },
        user: { //当前用户信息
            name: username,
            face: "/Content/Images/001.jpg"
        },

        //自动回复内置文案，也可动态读取数据库配置
        autoReplay: [
            '您好，我现在有事不在，一会再和您联系。',
            '你没发错吧？',
            '洗澡中，请勿打扰',
            '你好，我是主人的美女秘书，有什么事就跟我说吧，等他回来我会转告他的。',
            '我正在拉磨，没法招呼您，因为我们家毛驴去动物保护协会把我告了，说我剥夺它休产假的权利。',
            '<（@￣︶￣@）>',
            '你要和我说话？你真的要和我说话？你确定自己想说吗？你一定非说不可吗？那你说吧，这是自动回复。',
            '主人正在开机自检，键盘鼠标看好机会出去凉快去了，我是他的电冰箱，我打字比较慢，你慢慢说，别急……',
            '(*^__^*) 嘻嘻，是美女吗？'
        ],
        chating: {},
        hosts: (function () {
            var dk = location.href.match(/\:\d+/);
            dk = dk ? dk[0] : '';
            return 'http://' + document.domain + dk + '/';
        })(),
        json: function (url, data, callback, error) {
            return $.ajax({
                type: 'POST',
                url: url,
                data: data,
                dataType: 'json',
                success: callback,
                error: error
            });
        },
        stopMP: function (e) {
            e ? e.stopPropagation() : e.cancelBubble = true;
        }
    },
    dom = [$(window), $(document), $('html'), $('body')],
    chatCore = {},
    systemHub = $.connection.chatHub,
    onlinenum = 0;//在线人数

    //主界面tab
    chatCore.tabs = function (index) {
        var node = chatCore.node;
        node.tabs.eq(index).addClass('ChatCore_tabnow').siblings().removeClass('ChatCore_tabnow');
        node.list.eq(index).show().siblings('.ChatCore_list').hide();
        if (node.list.eq(index).find('li').length === 0) {
            chatCore.getDates(index);
        }
    };

    //节点
    chatCore.renode = function () {
        var node = chatCore.node = {
            tabs: $('#ChatCore_tabs>span'),
            list: $('.ChatCore_list'),
            online: $('.ChatCore_online'),
            setonline: $('.ChatCore_setonline'),
            onlinetex: $('#ChatCore_onlinetex'),
            ChatCoreon: $('#ChatCore_on'),
            ChatCoreFooter: $('#ChatCore_bottom'),
            ChatCoreHide: $('#ChatCore_hide'),
            ChatCoreSearch: $('#ChatCore_searchkey'),
            searchMian: $('#ChatCore_searchmain'),
            closeSearch: $('#ChatCore_closesearch'),
            ChatCoreMin: $('#ChatCore_min')
        };
    };

    //主界面缩放
    chatCore.expend = function () {
        var node = chatCore.node;
        if (chatCore.ChatCoreNode.attr('state') !== '1') {
            chatCore.ChatCoreNode.stop().animate({ right: config.right }, config.aniTime, function () {
                node.ChatCoreon.addClass('ChatCore_off');
                try {
                    localStorage.ChatCoreState = 1;
                } catch (e) { }
                chatCore.ChatCoreNode.attr({ state: 1 });
                node.ChatCoreFooter.addClass('ChatCore_expend').stop().animate({ marginLeft: config.right }, config.aniTime / 2);
                node.ChatCoreHide.addClass('ChatCore_show');
            });
        } else {
            chatCore.ChatCoreNode.stop().animate({ right: 1 }, config.aniTime, function () {
                node.ChatCoreon.removeClass('ChatCore_off');
                try {
                    localStorage.ChatCoreState = 2;
                } catch (e) { }
                chatCore.ChatCoreNode.removeAttr('state');
                node.ChatCoreFooter.removeClass('ChatCore_expend');
                node.ChatCoreHide.removeClass('ChatCore_show');
            });
            node.ChatCoreFooter.stop().animate({ marginLeft: 0 }, config.aniTime);
        }
    };

    //初始化窗口格局
    chatCore.FangsiInit = function () {
        var node = chatCore.node;

        //主界面
        try {
            /*
            if(!localStorage.ChatCoreState){       
                config.aniTime = 0;
                localStorage.ChatCoreState = 1;
            }
            */
            if (localStorage.ChatCoreState === '1') {
                chatCore.ChatCoreNode.attr({ state: 1 }).css({ right: config.right });
                node.ChatCoreon.addClass('ChatCore_off');
                node.ChatCoreFooter.addClass('ChatCore_expend').css({ marginLeft: config.right });
                node.ChatCoreHide.addClass('ChatCore_show');
            }
        } catch (e) {
            //layer.msg(e.message, 5, -1);
        }
    };

    //聊天窗口
    chatCore.popchat = function (param) {
        var node = chatCore.node, log = {};

        log.success = function (layero) {
            layer.setMove();

            chatCore.chatbox = layero.find('#ChatCore_chatbox');
            log.chatlist = chatCore.chatbox.find('.ChatCore_chatmore>ul');

            log.chatlist.html('<li data-id="' + param.id + '" type="' + param.type + '"  id="ChatCore_user' + param.type + param.id + '"><span>' + param.name + '</span><em>×</em></li>')
            chatCore.tabchat(param, chatCore.chatbox);

            //最小化聊天窗
            chatCore.chatbox.find('.layer_setmin').on('click', function () {
                var indexs = layero.attr('times');
                layero.hide();
                node.ChatCoreMin.text(chatCore.nowchat.name).show();
            });

            //关闭窗口
            chatCore.chatbox.find('.ChatCore_close').on('click', function () {
                var indexs = layero.attr('times');
                layer.close(indexs);
                chatCore.chatbox = null;
                config.chating = {};
                config.chatings = 0;
            });

            //关闭某个聊天
            log.chatlist.on('mouseenter', 'li', function () {
                $(this).find('em').show();
            }).on('mouseleave', 'li', function () {
                $(this).find('em').hide();
            });
            log.chatlist.on('click', 'li em', function (e) {
                var parents = $(this).parent(), dataType = parents.attr('type');
                var dataId = parents.attr('data-id'), index = parents.index();
                var chatlist = log.chatlist.find('li'), indexs;

                config.stopMP(e);

                delete config.chating[dataType + dataId];
                config.chatings--;

                parents.remove();
                $('#ChatCore_area' + dataType + dataId).remove();
                if (dataType === 'group') {
                    $('#ChatCore_group' + dataType + dataId).remove();
                }

                if (parents.hasClass('ChatCore_chatnow')) {
                    if (index === config.chatings) {
                        indexs = index - 1;
                    } else {
                        indexs = index + 1;
                    }
                    chatCore.tabchat(config.chating[chatlist.eq(indexs).attr('type') + chatlist.eq(indexs).attr('data-id')]);
                }

                if (log.chatlist.find('li').length === 1) {
                    log.chatlist.parent().hide();
                }
            });

            //聊天选项卡
            log.chatlist.on('click', 'li', function () {
                var othis = $(this), dataType = othis.attr('type'), dataId = othis.attr('data-id');
                chatCore.tabchat(config.chating[dataType + dataId]);
            });

            //发送热键切换
            log.sendType = $('#ChatCore_sendtype'), log.sendTypes = log.sendType.find('span');
            $('#ChatCore_enter').on('click', function (e) {
                config.stopMP(e);
                log.sendType.show();
            });
            log.sendTypes.on('click', function () {
                log.sendTypes.find('i').text('')
                $(this).find('i').text('√');
            });

            chatCore.transmit();
        };

        log.html = '<div class="ChatCore_chatbox" id="ChatCore_chatbox">'
                + '<h6>'
                + '<span class="ChatCore_move"></span>'
                + '    <a href="' + param.url + '" class="ChatCore_face" target="_blank"><img src="' + param.face + '" ></a>'
                + '    <a href="' + param.url + '" class="ChatCore_names" target="_blank">' + param.name + '</a>'
                + '    <span class="ChatCore_rightbtn">'
                + '        <i class="layer_setmin"></i>'
                + '        <i class="ChatCore_close"></i>'
                + '    </span>'
                + '</h6>'
                + '<div class="ChatCore_chatmore" id="ChatCore_chatmore">'
                + '    <ul class="ChatCore_chatlist"></ul>'
                + '</div>'
                + '<div class="ChatCore_groups" id="ChatCore_groups"></div>'
                + '<div class="ChatCore_chat">'
                + '    <div class="ChatCore_chatarea" id="ChatCore_chatarea">'
                + '        <ul class="ChatCore_chatview ChatCore_chatthis"  id="ChatCore_area' + param.type + param.id + '"></ul>'
                + '    </div>'
                + '    <div class="ChatCore_tool" style="color:#666;">注：Web聊天中请勿发送过长的文本.</div>'//增加内容
                + '    <div class="ChatCore_tool" style="display:none;">'
                + '        <i class="ChatCore_addface" title="发送表情"></i>'
                + '        <a href="javascript:;"><i class="ChatCore_addimage" title="上传图片"></i></a>'
                + '        <a href="javascript:;"><i class="ChatCore_addfile" title="上传附件"></i></a>'
                + '        <a href="" target="_blank" class="ChatCore_seechatlog"><i></i>聊天记录</a>'
                + '    </div>'
                + '    <textarea class="ChatCore_write" id="ChatCore_write"></textarea>'
                + '    <div class="ChatCore_send">'
                + '        <div class="ChatCore_sendbtn" id="ChatCore_sendbtn">发送<span class="ChatCore_enter" id="ChatCore_enter"><em class="ChatCore_zero"></em></span></div>'
                + '        <div class="ChatCore_sendtype" id="ChatCore_sendtype">'
                + '            <span><i>√</i>按Enter键发送</span>'
                + '            <span><i></i>按Ctrl+Enter键发送</span>'
                + '        </div>'
                + '    </div>'
                + '</div>'
                + '</div>';

        if (config.chatings < 1) {
            $.layer({
                type: 1,
                border: [0],
                title: false,
                shade: [0],
                area: ['620px', '493px'],
                move: '.ChatCore_chatbox .ChatCore_move',
                moveType: 1,
                closeBtn: false,
                offset: [(($(window).height() - 493) / 2) + 'px', ''],
                page: {
                    html: log.html
                }, success: function (layero) {
                    log.success(layero);
                }
            })
        } else {
            log.chatmore = chatCore.chatbox.find('#ChatCore_chatmore');
            log.chatarea = chatCore.chatbox.find('#ChatCore_chatarea');

            log.chatmore.show();

            log.chatmore.find('ul>li').removeClass('ChatCore_chatnow');
            log.chatmore.find('ul').append('<li data-id="' + param.id + '" type="' + param.type + '" id="ChatCore_user' + param.type + param.id + '" class="ChatCore_chatnow"><span>' + param.name + '</span><em>×</em></li>');

            log.chatarea.find('.ChatCore_chatview').removeClass('ChatCore_chatthis');
            log.chatarea.append('<ul class="ChatCore_chatview ChatCore_chatthis" id="ChatCore_area' + param.type + param.id + '"></ul>');

            chatCore.tabchat(param);
        }

        //群组
        log.chatgroup = chatCore.chatbox.find('#ChatCore_groups');
        if (param.type === 'group') {
            log.chatgroup.find('ul').removeClass('ChatCore_groupthis');
            log.chatgroup.append('<ul class="ChatCore_groupthis" id="ChatCore_group' + param.type + param.id + '"></ul>');
            chatCore.getGroups(param);
        }
        //点击群员切换聊天窗
        log.chatgroup.on('click', 'ul>li', function () {
            chatCore.popchatbox($(this));
        });
    };

    //定位到某个聊天队列
    chatCore.tabchat = function (param) {
        var node = chatCore.node, log = {}, keys = param.type + param.id;
        chatCore.nowchat = param;

        chatCore.chatbox.find('#ChatCore_user' + keys).addClass('ChatCore_chatnow').siblings().removeClass('ChatCore_chatnow');
        chatCore.chatbox.find('#ChatCore_area' + keys).addClass('ChatCore_chatthis').siblings().removeClass('ChatCore_chatthis');
        chatCore.chatbox.find('#ChatCore_group' + keys).addClass('ChatCore_groupthis').siblings().removeClass('ChatCore_groupthis');

        chatCore.chatbox.find('.ChatCore_face>img').attr('src', param.face);
        chatCore.chatbox.find('.ChatCore_face, .ChatCore_names').attr('href', param.href);
        chatCore.chatbox.find('.ChatCore_names').text(param.name);

        chatCore.chatbox.find('.ChatCore_seechatlog').attr('href', config.chatlogurl + param.id);

        log.groups = chatCore.chatbox.find('.ChatCore_groups');
        if (param.type === 'group') {
            log.groups.show();
        } else {
            log.groups.hide();
        }

        $('#ChatCore_write').focus();

    };

    // 弹出聊天窗
    chatCore.popchatbox = function (othis) {
        var node = chatCore.node, userId = othis.attr('id'), dataId = othis.attr('data-id'), param = {
            id: dataId, //用户ID
            userid: userId,
            type: othis.attr('type'),
            name: othis.find('.ChatCore_onename').text(),  //用户名
            face: othis.find('.ChatCore_oneface').attr('src'),  //用户头像
            href: 'http://www.cnblogs.com/zhili/'//config.hosts + 'user/' + dataId //用户主页
        }, key = param.type + dataId;
        if (!config.chating[key]) {
            chatCore.popchat(param);
            config.chatings++;
        } else {
            chatCore.tabchat(param);
        }
        config.chating[key] = param;

        var chatbox = $('#ChatCore_chatbox');
        if (chatbox[0]) {
            node.ChatCoreMin.hide();
            chatbox.parents('.xubox_layer').show();
        }
    };

    //请求群员
    chatCore.getGroups = function (param) {
        var keys = param.type + param.id, str = '',
        groupss = chatCore.chatbox.find('#ChatCore_group' + keys);
        groupss.addClass('loading');
        config.json(config.api.groups, {}, function (datas) {
            if (datas.status === 1) {
                var ii = 0, lens = datas.data.length;
                if (lens > 0) {
                    for (; ii < lens; ii++) {
                        str += '<li data-id="' + datas.data[ii].id + '" type="one"><img src="' + datas.data[ii].face + '" class="ChatCore_oneface"><span class="ChatCore_onename">' + datas.data[ii].name + '</span></li>';
                    }
                } else {
                    str = '<li class="ChatCore_errors">没有群员</li>';
                }

            } else {
                str = '<li class="ChatCore_errors">' + datas.msg + '</li>';
            }
            groupss.removeClass('loading');
            groupss.html(str);
        }, function () {
            groupss.removeClass('loading');
            groupss.html('<li class="ChatCore_errors">请求异常</li>');
        });
    };

    //消息传输
    chatCore.transmit = function () {
        var node = chatCore.node, log = {};
        node.sendbtn = $('#ChatCore_sendbtn');
        node.imwrite = $('#ChatCore_write');

        //发送
        log.send = function () {
            var data = {
                content: node.imwrite.val(),
                id: chatCore.nowchat.id,
                sign_key: '', //密匙
                _: +new Date
            };

            if (data.content.replace(/\s/g, '') === '') {
                layer.tips('说点啥呗！', '#ChatCore_write', 2);
                node.imwrite.focus();
            } else {
                //此处皆为模拟
                var keys = chatCore.nowchat.type + chatCore.nowchat.id;

                //聊天模版
                log.html = function (param, type) {
                    return '<li class="' + (type === 'me' ? 'ChatCore_chateme' : '') + '">'
                        + '<div class="ChatCore_chatuser">'
                            + function () {
                                if (type === 'me') {
                                    return '<span class="ChatCore_chattime">' + param.time + '</span>'
                                           + '<span class="ChatCore_chatname">' + param.name + '</span>'
                                           + '<img src="' + param.face + '" >';
                                } else {
                                    return '<img src="' + param.face + '" >'
                                           + '<span class="ChatCore_chatname">' + param.name + '</span>'
                                           + '<span class="ChatCore_chattime">' + param.time + '</span>';
                                }
                            }()
                        + '</div>'
                        + '<div class="ChatCore_chatsay">' + param.content + '<em class="ChatCore_zero"></em></div>'
                    + '</li>';
                };

                log.imarea = chatCore.chatbox.find('#ChatCore_area' + keys);

                log.imarea.append(log.html({
                    time: new Date().toLocaleString(),
                    name: config.user.name,
                    face: config.user.face,
                    content: data.content
                }, 'me'));
                node.imwrite.val('').focus();
                log.imarea.scrollTop(log.imarea[0].scrollHeight);

                // 调用服务端sendPrivateMessage方法来转发消息
                systemHub.server.sendPrivateMessage(chatCore.nowchat.id, data.content);
            }

        };
        node.sendbtn.on('click', log.send);

        node.imwrite.keyup(function (e) {
            if (e.keyCode === 13) {
                log.send();
            }
        });
    };

    //事件
    chatCore.event = function () {
        var node = chatCore.node;

        //主界面tab
        node.tabs.eq(0).addClass('ChatCore_tabnow');
        node.tabs.on('click', function () {
            var othis = $(this), index = othis.index();
            chatCore.tabs(index);
        });

        //列表展收
        node.list.on('click', 'h5', function () {
            var othis = $(this), chat = othis.siblings('.ChatCore_chatlist'), parentss = othis.parent();
            if (parentss.hasClass('ChatCore_liston')) {
                chat.hide();
                parentss.removeClass('ChatCore_liston');
            } else {
                chat.show();
                parentss.addClass('ChatCore_liston');
            }
        });

        //设置在线隐身
        node.online.on('click', function (e) {
            config.stopMP(e);
            node.setonline.show();
        });
        node.setonline.find('span').on('click', function (e) {
            var index = $(this).index();
            config.stopMP(e);
            if (index === 0) {
                node.onlinetex.html('在线');
                node.online.removeClass('ChatCore_offline');
            } else if (index === 1) {
                node.onlinetex.html('隐身');
                node.online.addClass('ChatCore_offline');
            }
            node.setonline.hide();
        });

        node.ChatCoreon.on('click', chatCore.expend);
        node.ChatCoreHide.on('click', chatCore.expend);

        //搜索
        node.ChatCoreSearch.keyup(function () {
            var val = $(this).val().replace(/\s/g, '');
            if (val !== '') {
                node.searchMian.show();
                node.closeSearch.show();
                //此处的搜索ajax参考ChatCore.getDates
                node.list.eq(3).html('<li class="ChatCore_errormsg">没有符合条件的结果</li>');
            } else {
                node.searchMian.hide();
                node.closeSearch.hide();
            }
        });
        node.closeSearch.on('click', function () {
            $(this).hide();
            node.searchMian.hide();
            node.ChatCoreSearch.val('').focus();
        });

        //弹出聊天窗
        config.chatings = 0;
        node.list.on('click', '.ChatCore_childnode', function () {
            var othis = $(this);
            chatCore.popchatbox(othis);
        });

        //点击最小化栏
        node.ChatCoreMin.on('click', function () {
            $(this).hide();
            $('#ChatCore_chatbox').parents('.xubox_layer').show();
        });

        //document事件
        dom[1].on('click', function () {
            node.setonline.hide();
            $('#ChatCore_sendtype').hide();
        });

        // 连接IM服务器成功
        // 主要是更新在线用户
        systemHub.client.onConnected = function (id, userName, allUsers) {
            var node = chatCore.node, myf = node.list.eq(0), str = '', i = 0;
            myf.addClass('loading');
            onlinenum = allUsers.length;
            if (onlinenum > 0) {
                str += '<li class="ChatCore_parentnode  ChatCore_liston">'
                     + '<h5><i></i><span class="ChatCore_parentname">在线用户</span><em class="ChatCore_nums">（' + onlinenum + '）</em></h5>'
                     + '<ul id="ChatCore_friend_list" class="ChatCore_chatlist">';
                for (; i < onlinenum; i++) {
                    str += '<li id="userid-' + allUsers[i].UserID + '" data-id="' + allUsers[i].ConnectionId + '" class="ChatCore_childnode" type="one"><img src="/Content/Images/001.jpg?' + allUsers[i].UserID + '"  class="ChatCore_oneface"><span  class="ChatCore_onename">' + allUsers[i].UserName + '(' + ')</span><em class="ChatCore_time">' + allUsers[i].LoginTime + '</em></li>';
                }
                str += '</ul></li>';
                myf.html(str);
            } else {
                myf.html('<li class="ChatCore_errormsg">没有任何数据</li>');
            }
            myf.removeClass('loading');
        };

        //新用户上线
        systemHub.client.onNewUserConnected = function (id, userId, userName, loginTime) {
            onlinenum = onlinenum + 1;
            $(".ChatCore_nums").html("（" + onlinenum + "）");
            var myf = $('#ChatCore_friend_list'), str = '';
            str += '<li id="userid-' + userId + '" data-id="' + id + '" class="ChatCore_childnode" type="one"><img src="/Content/Images/001.jpg?' + userId + '"  class="ChatCore_oneface"><span  class="ChatCore_onename">' + userName + '(' + ')</span><em class="ChatCore_time">' + loginTime + '</em></li>';
            myf.append(str);
        };

        //用户离线
        systemHub.client.onUserDisconnected = function (id, userName) {
            onlinenum = onlinenum - 1;
            $(".ChatCore_nums").html("（" + onlinenum + "）");
            $("#ChatCore_friend_list li[data-id=" + id + "]").remove();
        };

        //发送消息时，对方已不在线
        systemHub.client.absentSubscriber = function () {
            $.gritter.add({
                title: "系统提醒",
                text: "对方已不在线，请采用其它方式沟通！",
                class_name: "gritter-info gritter-center"
            });
        };

        //接收消息
        systemHub.client.receivePrivateMessage = function (fromUserId, userName, message) {

            var node = chatCore.node, log = {}, othis = $("#ChatCore_friend_list li[data-id=" + fromUserId + "]");
            //聊天模版
            log.html = function (param, type) {
                return '<li class="' + (type === 'me' ? 'ChatCore_chateme' : '') + '">'
                    + '<div class="ChatCore_chatuser">'
                        + function () {
                            if (type === 'me') {
                                return '<span class="ChatCore_chattime">' + param.time + '</span>'
                                       + '<span class="ChatCore_chatname">' + param.name + '</span>'
                                       + '<img src="' + param.face + '" >';
                            } else {
                                return '<img src="' + param.face + '" >'
                                       + '<span class="ChatCore_chatname">' + param.name + '</span>'
                                       + '<span class="ChatCore_chattime">' + param.time + '</span>';
                            }
                        }()
                    + '</div>'
                    + '<div class="ChatCore_chatsay">' + param.content + '<em class="ChatCore_zero"></em></div>'
                + '</li>';
            };
            chatCore.popchatbox(othis);

            var keys = chatCore.nowchat.type + chatCore.nowchat.id;
            log.imarea = chatCore.chatbox.find('#ChatCore_area' + keys);

            log.imarea.append(log.html({
                time: new Date().toLocaleString(),
                name: othis.find('.ChatCore_onename').text(),
                face: othis.find('.ChatCore_oneface').attr('src'),
                content: message
            }));
            log.imarea.scrollTop(log.imarea[0].scrollHeight);
        };
    };

    //请求列表数据
    chatCore.getDates = function (index) {
        var api = [config.api.friend, config.api.group, config.api.chatlog],
            node = chatCore.node, myf = node.list.eq(index);
        myf.addClass('loading');
        config.json(api[index], {}, function (datas) {
            if (datas.status === 1) {
                var i = 0, myflen = datas.data.length, str = '', item;
                if (myflen > 1) {
                    if (index !== 2) {
                        for (; i < myflen; i++) {
                            str += '<li data-id="' + datas.data[i].id + '" class="ChatCore_parentnode">'
                                + '<h5><i></i><span class="ChatCore_parentname">' + datas.data[i].name + '</span><em class="ChatCore_nums">（' + datas.data[i].nums + '）</em></h5>'
                                + '<ul class="ChatCore_chatlist">';
                            item = datas.data[i].item;
                            for (var j = 0; j < item.length; j++) {
                                str += '<li data-id="' + item[j].id + '" class="ChatCore_childnode" type="' + (index === 0 ? 'one' : 'group') + '"><img src="' + item[j].face + '" class="ChatCore_oneface"><span class="ChatCore_onename">' + item[j].name + '</span></li>';
                            }
                            str += '</ul></li>';
                        }
                    } else {
                        str += '<li class="ChatCore_liston">'
                            + '<ul class="ChatCore_chatlist">';
                        for (; i < myflen; i++) {
                            str += '<li data-id="' + datas.data[i].id + '" class="ChatCore_childnode" type="one"><img src="' + datas.data[i].face + '"  class="ChatCore_oneface"><span  class="ChatCore_onename">' + datas.data[i].name + '</span><em class="ChatCore_time">' + datas.data[i].time + '</em></li>';
                        }
                        str += '</ul></li>';
                    }
                    myf.html(str);
                } else {
                    myf.html('<li class="ChatCore_errormsg">没有任何数据</li>');
                }
                myf.removeClass('loading');
            } else {
                myf.html('<li class="ChatCore_errormsg">' + datas.msg + '</li>');
            }
        }, function () {
            myf.html('<li class="ChatCore_errormsg">请求失败</li>');
            myf.removeClass('loading');
        });
    };

    //渲染骨架
    chatCore.view = (function () {
        var ChatCoreNode = chatCore.ChatCoreNode = $('<div id="ChatCoremm" class="ChatCore_main">'
                + '<div class="ChatCore_top" id="ChatCore_top">'
                + '  <div class="ChatCore_search"><i></i><input id="ChatCore_searchkey" /><span id="ChatCore_closesearch">×</span></div>'
                + '  <div class="ChatCore_tabs" id="ChatCore_tabs"><span class="ChatCore_tabfriend" title="好友"><i></i></span><span class="ChatCore_tabgroup" title="群组" style="display:none;"><i></i></span><span class="ChatCore_latechat"  title="最近聊天" style="display:none;"><i></i></span></div>'
                + '  <ul class="ChatCore_list" style="display:block"></ul>'
                + '  <ul class="ChatCore_list"></ul>'
                + '  <ul class="ChatCore_list"></ul>'
                + '  <ul class="ChatCore_list ChatCore_searchmain" id="ChatCore_searchmain"></ul>'
                + '</div>'
                + '<ul class="ChatCore_bottom" id="ChatCore_bottom">'
                + '<li class="ChatCore_online" id="ChatCore_online">'
                    + '<i class="ChatCore_nowstate"></i><span id="ChatCore_onlinetex">在线</span>'
                    + '<div class="ChatCore_setonline">'
                        + '<span><i></i>在线</span>'
                        + '<span class="ChatCore_setoffline"><i></i>隐身</span>'
                    + '</div>'
                + '</li>'
                + '<li class="ChatCore_mymsg" id="ChatCore_mymsg" title="聊天室"><i></i><a href="' + config.msgurl + '" target="rightFrame"></a></li>'
                + '<li class="ChatCore_seter" id="ChatCore_seter" title="设置">'
                    + '<i></i>'
                    + '<div class="">'

                    + '</div>'
                + '</li>'
                + '<li class="ChatCore_hide" id="ChatCore_hide"><i></i></li>'
                + '<li id="ChatCore_on" class="ChatCore_icon ChatCore_on"></li>'
                + '<div class="ChatCore_min" id="ChatCore_min"></div>'
            + '</ul>'
        + '</div>');
        
        dom[3].append(ChatCoreNode);
        chatCore.renode();
        chatCore.event();

        // 启动连接
        $.connection.hub.start().done(function () {
            systemHub.server.connect(userid, username); // 调用服务端connect方法
        });

        chatCore.FangsiInit();
    }());

}(window);