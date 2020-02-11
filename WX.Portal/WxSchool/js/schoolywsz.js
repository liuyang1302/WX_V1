$(function () {

    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();
    var _coursename = $("#coursename").html();
    var items;

    //初始化
    function init() {

        //设置录入元素
        var _wh = document.body.clientHeight;        //屏幕可见高
        var _hh = $("#divtm")[0].offsetHeight;        //上高
        var _vh = _wh - _hh - 40;
        $("#divcontent").height(_vh);
        loaddata();
    }

    function loaddata() {

        $.ajax({
            url: "../WxHandlers/WxSchoolService.ashx",
            data: { Type: "生字", OpenID: _openid, NickName: _nickname, Reid: Math.random() },
            async: true,
            success: afterinfo
        });
    }

    function afterinfo(data) {

        //alert(data);
        $("#apy").html("");
        $("#azi").html("");

        items = data.split('|');
        $("#lbcount").html("第 " + items[0] + " 个生字");
        $("#azi").html(items[1]);
    }

    $("#azi").on('click', function () {

        if ($("#apy").html() == "") {
            if (items == null) return;
            $("#apy").html(items[2]);
        }
        else {
            loaddata();
        }
    });

    $("#lbnext").on('click', function () {

        loaddata();
    });

    $("#lbcount").on('click', function () {

        $.ajax({
            url: "../WxHandlers/WxSchoolService.ashx",
            data: { Type: "生字", OpenID: _openid, NickName: _nickname, Clean: 1, Reid: Math.random() },
            async: true,
            success: afterinfo
        });
    });

    init();

});