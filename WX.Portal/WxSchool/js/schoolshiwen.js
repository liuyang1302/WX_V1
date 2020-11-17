$(function () {

    var _params = $("#id").html();
    var _id;
    var _type;
    var _ltype;
    var _audio;
    var _conaudio;
    var items;

    var eventTester = function (e) {
        _audio.addEventListener(e, function () {
            afteraudio();
        });
    }

    //初始化
    function init() {

        var _val = _params.split(',');
        _id = _val[0];
        _type = _val[1];
        _ltype = _val[2];

        _audio = document.getElementById("_audio");
        _audio.onended = function () {
            //alert("The video has ended");
            nextitem();
        };

        loaddata();
    }

    //载入数据
    function loaddata() {
       
        $.ajax({
            url: "../WxHandlers/WxSchoolService.ashx",
            data: { Type: "read", ltype: "项目列表", typeid: _id, Reid: Math.random() },
            async: true,
            success: afterinfo
        });
    }

    function afterinfo(data) {

        $("#lbtit").html("");
        $("#content").html("");
        $("#list").html("");
        var _html = "";

        //ID|类别|类型|朝代|作者|名称|内容|朗读
        items = data.split('$');
        for (var i = 0; i < items.length; i++) {
            var _item = items[i];
            var _val = _item.split('|');
            _html += "<a id='" + _item + "' class='weui-cell weui-cell_access' href='javascript:;'>";
            _html += " <div class='weui-cell__hd'>";
            _html += "   <img style='width:20px;margin-right:5px;display:block' alt='' src='Img/ywt.jpg'>";
            _html += " </div>";
            _html += " <div class='weui-cell__bd weui-cell_primary'>";
            _html += "  <p>" + _val[5] + " (" + _val[3] + "  " + _val[4] + ")</p>";
            _html += " </div>";
            _html += " <span class='weui-cell__ft'></span>";
            _html += "</a>";

            if (i == 0) {
                _conaudio = _item;
            }
        }
        $("#list").html(_html);
        conaudio();
        retoinfo();
    }

    function conaudio() {

        //ID|类别|类型|朝代|作者|名称|内容|朗读
        var _val = _conaudio.split('|');
        var _tit = _val[5] + " <span style='font-size: 14px; color: blue;'>(" + _val[3] + "：" + _val[4] + ")</span>";
        var _info = "（" + _val[1] + " ：" + _val[2] + "）";   //（朗读：陈琅）
        var _content = _val[6].replace("\n","<br/>");

        $("#lbtit").html(_tit);
        $("#_info").html(_info);
        $("#content").html(_content);

        if (_val[7] != "") {
            _audio.src = _val[7];
            _audio.play();
        }
    }

    //播放完毕
    function afteraudio() {
        nextitem();
    }

    function nextitem() {
        for (var i = 0; i < items.length; i++) {
            var _item = items[i];
            if (_item == _conaudio) {
                var j = i + 1;
                if (j >= items.length)
                    j = 0;
                _conaudio = items[j];
                var _val = _conaudio.split('|');
                if (_val[7] == "") //无音频
                    continue;
                conaudio();
                return;
            }
        }
    }

    function retoinfo() {
        $(".weui-cell_access").on('click', function () {
            _conaudio = $(this)[0].id;
            conaudio();
        });
    }


    init();


});