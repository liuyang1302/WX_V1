
$(function () {

    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();
    var _coursename = $("#coursename").html();

    //初始化
    function init() {

        //设置录入元素
        //var _wh = document.body.clientHeight;        //屏幕可见高
        //var _hh = $("#divtm")[0].offsetHeight;        //上高
        //var _vh = _wh - _hh - 40;
        //$("#divcontent").height(_vh);
        $("#lbtit").html(_coursename);
        //$('.weui-grids1').html("");
        //loaddata();
    }

    function loaddata() {

        $.ajax({
            url: "../WxHandlers/WxSchoolService.ashx",
            data: { Type: "生字表", OpenID: _openid, NickName: _nickname },
            async: true,
            success: afterinfo
        });
    }

    function afterinfo(data) {

        //alert(data);
        $("#lbhcount").html("");
        $('.weui-grids1').html("");
        var items = data.split('|');
        var _count = items.length;
        $("#lbhcount").html("总共 " + _count + " 个生字");

        var _html = "";
        for (var i = 0; i < _count; i++) {
            var _val = items[i];
            var _vals = _val.split(",");
            var _url = "SchoolYwSearch.aspx?OpenID=" + _openid + "&NickName=" + _nickname + "&Filter=" + _vals[0];
            _html += "<a class='weui-grid1' href='" + _url + "'>";
            _html += "<div class='weui-grid__icon1'>" + _vals[1] + "</div>";
            _html += "<p class='weui-grid__label1'>" + _vals[0] + "</p></a>";
        }
        $('.weui-grids1').html(_html);
        clipboardData.setData("Text", _html);
        alert("复制成功！");
    }

    $("#lbstart").on('click', function () {

        //学习生字
        var _url = "SChoolYwSz.aspx";
        window.location.href = _url;

    });

    init();

});