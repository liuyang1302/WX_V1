$(function () {

    var _now;
    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();

    //初始化
    function init() {

        _now = new Date();
        $("#lbname").html(_nickname);
        $("#lbnow").html(_now.getFullYear() + "年" + fix((_now.getMonth() + 1), 2) + "月" + fix(_now.getDate(), 2) + "日");
        var _nowstr = _now.getFullYear() + "-" + fix((_now.getMonth() + 1), 2) + "-" + fix(_now.getDate(), 2)

        $.ajax({
            url: "../WxHandlers/WxBillService.ashx",
            data: { Type: "记账首页", OpenID: _openid, NickName: _nickname, Now: getNowFormatDate() },
            async: true,
            success: loadafter
        });
    }

    //数据返回
    function loadafter(data) {
   
        var items = data.split('|');

        //总金额
        var zsum = items[0].split(';');
        $("#lbinsum").html("¥" + zsum[0].split('=')[1]);
        $("#lboutsum").html("¥" + zsum[1].split('=')[1]);
        $("#lbsubsum").html("¥" + zsum[2].split('=')[1]);

        //年金额
        var ysum = items[1].split(';');
        $("#lbyear").html(ysum[0]);
        $("#iysum").html("$" + ysum[1].split('=')[1]);
        $("#oysum").html("$" + ysum[2].split('=')[1]);

        //月金额
        var msum = items[2].split(';');
        $("#lbmonth").html(msum[0]);
        $("#imsum").html("$" + msum[1].split('=')[1]);
        $("#omsum").html("$" + msum[2].split('=')[1]);

        //周金额
        var wsum = items[3].split(';');
        $("#lbweek").html(wsum[0]);
        $("#iwsum").html("$" + wsum[1].split('=')[1]);
        $("#owsum").html("$" + wsum[2].split('=')[1]);

        //日金额
        var dsum = items[4].split(';');
        $("#lbday").html(dsum[0]);
        $("#idsum").html("$" + dsum[1].split('=')[1]);
        $("#odsum").html("$" + dsum[2].split('=')[1]);
    }

    //补空位
    function fix(num, length) {
        return ('' + num).length < length ? ((new Array(length + 1)).join('0') + num).slice(-length) : '' + num;
    }

    //当前时间
    function getNowFormatDate() {
        _now = new Date();
        var seperator1 = "-";
        var seperator2 = ":";
        var month = _now.getMonth() + 1;
        var strDate = _now.getDate();
        if (month >= 1 && month <= 9) {
            month = "0" + month;
        }
        if (strDate >= 0 && strDate <= 9) {
            strDate = "0" + strDate;
        }
        var currentdate = _now.getFullYear() + seperator1 + month + seperator1 + strDate
        + " " + _now.getHours() + seperator2 + _now.getMinutes()
        + seperator2 + _now.getSeconds();
        return currentdate;
    }

    //按钮处理
    $('.weui-btn').on('click', function () {
        var _id = $(this)[0].id;
        var _url = '';

        if (_id == 'butacc') {
            _url = "WxAccount.aspx";
        }
        else if (_id == 'butinc') {
            _url = "WxIncome.aspx";
        }
        else if (_id == 'butrep') {
            _url = "WxReport.aspx";
        }
        _url += "?OpenID=" + _openid + "&NickName=" + _nickname;
        window.location.href = _url;
    });


    //载入初始化
    init();

});