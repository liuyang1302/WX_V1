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
        $("#lbname").html(_nickname);
    }

    //补空位
    function fix(num, length) {
        return ('' + num).length < length ? ((new Array(length + 1)).join('0') + num).slice(-length) : '' + num;
    }

    //载入数据
    function loaddata() {

        var _questype = $('#setype').val();

        $.ajax({
            url: "../WxHandlers/WxQuesService.ashx",
            data: { Type: "答题首页", OpenID: _openid, NickName: _nickname, QuesType: _questype },
            async: true,
            success: loadafter
        });
    }

    //载入完成
    function loadafter(data) {

        $("#queslist").html("");
        if (data.indexOf('|') < 0) {
            $("#lberror").html("");
            $("#lbhave").html("");
            $("#queslist").html("此类别无科目信息！");
            return;
        }

        var _qhtml = "";
        _qlist = data.split('|');
        var counts = _qlist[0].split('=');
        $("#lberror").html(counts[0]);
        $("#lbhave").html(counts[1]);

        for (var i = 0; i < _qlist.length; i++) {
            if (i == 0) continue;
            var _item = _qlist[i];
            var _val = _item.split('=');
            _qhtml += "<a id='" + _val[0] + "' class='weui-cell weui-cell_access' href='javascript:;'>";
            _qhtml += " <div class='weui-cell__hd'>";
            _qhtml += "   <img style='width:20px;margin-right:5px;display:block' alt='' src='WxQuesImg/kao1.png'>";
            _qhtml += " </div>";
            _qhtml += " <div class='weui-cell__bd weui-cell_primary'>";
            _qhtml += "  <p>" + _val[1] + "</p>";
            _qhtml += " </div>";
            _qhtml += " <span class='weui-cell__ft'></span>";
            _qhtml += "</a>";
        }
        $("#queslist").html(_qhtml);

        //转向连接
        retoinfo();
    }

    //列表转向
    function retoinfo() {
        $(".weui-cell_access").on('click', function () {
            var courseid = $(this)[0].id;
            var coursename = "";
            for (var i = 0; i < _qlist.length; i++) {
                if (i == 0) continue;
                var _val = _qlist[i].split('=');
                if (_val[0] == courseid) {
                    coursename = _val[1];
                    break;
                }
            }

            var _url = "WxQuesInfo.aspx?OpenID=" + _openid + "&NickName=" + _nickname + "&CourseId=" + courseid + "&CourseName=" + coursename;
            window.location.href = _url;
        });
    }

    $('#setype').change(function (e) {
        loaddata();
    });

    $("#lbhave").on('click', function () {
        reerror();
    });

    $("#lbhave").on('click', function () {
        reerror()
    });

    function reerror() {
        var _questype = $('#setype').val();
        var _url = "WxQuesInfo.aspx?OpenID=" + _openid + "&NickName=" + _nickname + "&QuesType=" + _questype;
        window.location.href = _url;
    }

    //查询
    //$(".weui-form-preview__btn").on("click", function () {
    //    alert("aa");
    //});
    $("#lbsearch").on("click", function () {
        var _questype = $('#setype').val();
        var _url = "WxQuesSearch.aspx?OpenID=" + _openid + "&NickName=" + _nickname + "&QuesType=" + _questype;
        window.location.href = _url;
    });


    init();

});