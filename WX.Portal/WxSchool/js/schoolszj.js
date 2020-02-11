$(function () {

    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();
    var _coursename = $("#coursename").html();

    //初始化
    function init() {

        //为提高访问速度 直接复制到页中了
        //设置录入元素
        //$("#lbtit").html(_coursename);
        //$('.weui-grids2').html("");
        //loaddata();

        var x = document.getElementById("_audio");
        x.play();
        setTimeout(CurrentAudio, 1000);
    }

    function CurrentAudio() {

        var x = document.getElementById("_audio");
        var _c = x.currentTime;
        if (_c >= 270) {
            x.currentTime = 5;
        }
        setTimeout(CurrentAudio, 1000);
    }

    function loaddata() {

        $.ajax({
            url: "../WxHandlers/WxSchoolService.ashx",
            data: { Type: "三字经", OpenID: _openid, NickName: _nickname },
            async: true,
            success: afterinfo
        });
    }

    function afterinfo(data) {

        //alert(data);
        //$("#lbhcount").html("");
        $('.weui-grids2').html("");
        var items = data.split('|');
        var _count = items.length;

        var _html = "";
        var _index = 1;
        var _cout = 3;
        for (var i = 0; i < _count; i++) {
            var _val = items[i];
            if (_val == "") continue;
            var _vals = _val.split(",");
            if (_index == _cout) {
                _html += "<a class='weui-grid3' href='javascript:;'>";
                _html += "<div class='weui-grid__icon3'>" + _vals[0] + "</div>";
                _html += "<p class='weui-grid__label3'>" + _vals[1] + "</p></a>";
                _cout = 6;
                _index = 0;
            }
            else {
                _html += "<a class='weui-grid2' href='javascript:;'>";
                _html += "<div class='weui-grid__icon2'>" + _vals[0] + "</div>";
                _html += "<p class='weui-grid__label2'>" + _vals[1] + "</p></a>";
            }
            _index++;
        }
        $('.weui-grids2').html(_html);
        //clipboardData.setData("Text", _html);
        //alert("复制成功！");
    }

    init();

});