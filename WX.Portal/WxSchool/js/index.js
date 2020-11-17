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
            $("#lbname").html(_nickname + "刘宸汐");
    }

    //补空位
    function fix(num, length) {
        return ('' + num).length < length ? ((new Array(length + 1)).join('0') + num).slice(-length) : '' + num;
    }

    //载入数据
    function loaddata() {

        var _questype = "分类目录";

        $.ajax({
            url: "../WxHandlers/WxSchoolService.ashx",
            data: { Type: "分类目录", OpenID: _openid, NickName: _nickname, QuesType: _questype },
            async: true,
            success: loadafter
        });
    }

    //载入完成
    function loadafter(data) {

        $("#yw").html("");
        $("#sx").html("");
        if (data.indexOf('|') < 0) {
            $("#lberror").html("");
            $("#ywhave").html("");
            $("#sxhave").html("");
            $("#queslist").html("此类别无科目信息！");
            return;
        }

        var _ywindex = 0;
        var _sxindex = 0;
        var _ywhtml = "";
        var _sxhtml = "";

        _qlist = data.split('|');
        for (var i = 0; i < _qlist.length; i++) {
            var _item = _qlist[i];
            var _val = _item.split(',');
            if (_val[2] == "语文1") {
                _ywindex++;
                _ywhtml += "<a id='" + _val[0] + "' class='weui-cell weui-cell_access' href='javascript:;'>";
                _ywhtml += " <div class='weui-cell__hd'>";
                _ywhtml += "   <img style='width:20px;margin-right:5px;display:block' alt='' src='Img/ywt.jpg'>";
                _ywhtml += " </div>";
                _ywhtml += " <div class='weui-cell__bd weui-cell_primary'>";
                _ywhtml += "  <p>" + _val[1] + "</p>";
                _ywhtml += " </div>";
                _ywhtml += " <span class='weui-cell__ft'></span>";
                _ywhtml += "</a>";
            }
            else {
                _sxindex++;
                _sxhtml += "<a id='" + _val[0] + "' class='weui-cell weui-cell_access' href='javascript:;'>";
                _sxhtml += " <div class='weui-cell__hd'>";
                _sxhtml += "   <img style='width:20px;margin-right:5px;display:block' alt='' src='Img/sxt.png'>";
                _sxhtml += " </div>";
                _sxhtml += " <div class='weui-cell__bd weui-cell_primary'>";
                _sxhtml += "  <p>" + _val[1] + "</p>";
                _sxhtml += " </div>";
                _sxhtml += " <span class='weui-cell__ft'></span>";
                _sxhtml += "</a>";
            }
        }

        $("#yw").html(_ywhtml);
        $("#sx").html(_sxhtml);
        $("#ywhave").html(_ywindex);
        $("#sxhave").html(_sxindex);

        //转向连接 
        retoinfo();
    }

    //列表转向
    function retoinfo() {
        $(".weui-cell_access").on('click', function () {
            var courseid = $(this)[0].id;
            var coursename = "";
            var coursetype = "";
            for (var i = 0; i < _qlist.length; i++) {
                var _val = _qlist[i].split(',');
                if (_val[0] == courseid) {
                    coursename = _val[1];
                    coursetype = _val[2];
                    break;
                }
            }
           
            var _url = "";
            var _params = "?OpenID=" + _openid + "&NickName=" + _nickname + "&CourseId=" + courseid + "&CourseName=" + coursename;

            if (coursename == "拼音表") {
                _url = "SchoolPinyin.aspx" + _params;
            }
            else if (coursename == "查字典") {
                _url = "SchoolYwSearch.aspx" + _params;
            }
            else if (coursename == "三字经") {
                _url = "SchoolSzj.aspx" + _params;
            }
            else if (coursename == "复读机") {
                _url = "SchoolVoice.aspx" + _params;
            }
            else if (coursename == "日常阅读") {
                _url = "SchoolRead.aspx" + _params;
            }
            else if (coursetype == "语文1") {
                _url = "SchoolYw.aspx" + _params;
            }
            else if (coursename == "九九乘法表") {
                _url = "SchoolMult.aspx" + _params;
            }
            else {
                _url = "SchoolSx.aspx" + _params;
            }
            window.location.href = _url;
        });
    }

    init();

});