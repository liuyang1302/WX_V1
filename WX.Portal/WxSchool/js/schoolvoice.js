$(function () {

    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();
    var _coursename = $("#coursename").html();
    var _dic = new Array();
    var _items;

    //初始化
    function init() {

        RongIMLib.RongIMVoice.init();
        $("#lbtit").html("");
        loaddata();
    }

    function loaddata() {

        $.ajax({
            url: "../WxHandlers/WxSchoolService.ashx",
            data: { Type: "语音列表", OpenID: _openid, NickName: _nickname },
            async: true,
            success: afterinfo
        });
    }

    function afterinfo(data) {

        $("#voices").html("");
        if (data == null || data == "")
            return;

        _items = data.split('|');
        var _count = _items.length;
        var _html = "";

        for (var i = 0; i < _items.length; i++) {
            var _item = _items[i];
            var _val = _item.split('=');
            _html += "<a id='" + _val[1] + "' class='weui-cell weui-cell_access' href='javascript:;'>";
            _html += " <div class='weui-cell__hd'>";
            _html += "   <img style='width:20px;margin-right:5px;display:block' alt='' src='Img/yy.png'>";
            _html += " </div>";
            _html += " <div class='weui-cell__bd weui-cell_primary'>";
            _html += "  <p>" + _val[0] + "</p>";
            _html += " </div>";
            _html += " <span class='weui-cell__ft'></span>";
            _html += "</a>";
        }

        $("#voices").html(_html);
        retoinfo();
    }

    //列表转向
    function retoinfo() {
        $(".weui-cell_access").on('click', function () {

            //先停止
            if ($("#state").html() == "play")
            {
                $("#state").html("stop");
                RongIMLib.RongIMVoice.stop();
            }

            var name = $(this)[0].id;
            for (var i = 0; i < _items.length; i++) {
                var _val = _items[i].split('=');
                if (_val[1] == name) {
                    $("#name").html(_val[0]);
                    $("#lbtit").html("正在载入:" + _val[0]);
                    break;
                }
            }

            for (var key in _dic) {
                if ($("#name").html() == key)
                {
                    aftervoice(_dic[key]);
                    return;
                }
            }

            loadvoid(name);
        });
    }

    //语音播放
    function loadvoid(name) {

        $.ajax({
            url: "../WxHandlers/WxSchoolService.ashx",
            data: { Type: "语音文件", OpenID: _openid, NickName: _nickname, FileName: name },
            async: true,
            success: aftervoice
        });
    }

    //语音载入
    function aftervoice(data) {
        if (data == null || data == "") {
            $("#lbtit").html("载入失败" + name);
            return;
        }

        _dic[$("#name").html()] = data;

        var _tit = $("#lbtit").html();
        _tit = _tit.replace("正在载入:", "正在播放:");
        $("#lbtit").html(_tit);

        $("#state").html("play");
        $("#cntent").html(data);
        CurrentAudio();
    }

    //循环播放
    function CurrentAudio() {

        if ($("#state").html() == "stop") //停止
            return;

        RongIMLib.RongIMVoice.play($("#cntent").html());
        setTimeout(CurrentAudio, 500);
    }

    //播放当前
    $("#lbplay").on('click', function () {

        if ($("#state").html() == "play")
            return;

        if ($("#cntent").html() == null || $("#cntent").html() == "")
            return;

        var _tit = $("#lbtit").html();
        _tit = _tit.replace("停止播放:", "正在播放:");
        $("#lbtit").html(_tit);

        $("#state").html("play");
        CurrentAudio();
    });

    //停止当前
    $("#lbstop").on('click', function () {

        if ($("#state").html() == "stop")
            return;

        var _tit = $("#lbtit").html();
        _tit = _tit.replace("正在播放:", "停止播放:");
        $("#lbtit").html(_tit);
        $("#state").html("stop");
        RongIMLib.RongIMVoice.stop();
    });

    init();

});