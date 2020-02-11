$(function () {

    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();
    var _qlist;

    //初始化
    function init() {

        initdate();
        loaddata();
    }

    //初始化时间
    function initdate() {

        var now = new Date();
        $("#lbnow").html(now.getFullYear() + "年" + fix((now.getMonth() + 1), 2) + "月" + fix(now.getDate(), 2) + "日");
        if (_nickname == null)
            $("#lbname").html("刘宸汐");
        else
            $("#lbname").html(_nickname);
    }

    //补空位
    function fix(num, length) {
        return ('' + num).length < length ? ((new Array(length + 1)).join('0') + num).slice(-length) : '' + num;
    }

    //载入数据
    function loaddata() {

        $.ajax({
            url: "../WxHandlers/WxHisInfoService.ashx",
            data: { type: "客户信息", OpenID: _openid, NickName: _nickname },
            async: true,
            success: loadafter
        });
    }

    //载入完成
    function loadafter(data) {

        $("#yw").html("");
        $("#sx").html("");
        if (data.indexOf('$') < 0) {
            $("#lberror").html("");
            $("#ywhave").html("");
            $("#sxhave").html("");
            $("#queslist").html("无客户列表！");
            return;
        }

        var _index = 0;
        var _html = "";

        _qlist = data.split('$');
        for (var i = 0; i < _qlist.length; i++) {
            var _item = _qlist[i];
            if (_item == "") continue;
            var _val = _item.split('|');
            _index++;
            _html += "<a id='" + _val[0] + "' class='weui-cell weui-cell_access' href='javascript:;'>";
            _html += " <div class='weui-cell__hd'>";
            _html += "   <img style='width:20px;margin-right:5px;display:block' alt='' src='img/yy.jpg'>";
            _html += " </div>";
            _html += " <div class='weui-cell__bd weui-cell_primary'>";
            _html += "  <p>" + _val[1] + "</p>";
            _html += " </div>";
            _html += " <span class='weui-cell__ft'></span>";
            _html += "</a>";
        }

        $("#yw").html(_html);
        $("#ywhave").html(_index);

        //转向连接
        retoinfo();
    }

    //列表转向
    function retoinfo() {
        $(".weui-cell_access").on('click', function () {
            var cid = $(this)[0].id;
            var cname = "";
            for (var i = 0; i < _qlist.length; i++) {
                var _val = _qlist[i].split('|');
                if (_val[0] == cid) {
                    cname = _val[1];
                    break;
                }
            }

            var _url = "";
            var _params = "?OpenID=" + _openid + "&NickName=" + _nickname + "&cid=" + cid + "&cname=" + cname;
            _url = "patinfo.aspx" + _params;
            window.location.href = _url;
        });
    }

    init();

});