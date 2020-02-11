
$(function () {

    var now;
    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();

    //初始化
    function init() {

        initdate();
        loaddata();
    }

    function initdate() {
        now = new Date();
        var str = now.getFullYear() + "-" + fix((now.getMonth() + 1), 2) + "-" + fix(now.getDate(), 2) + "T" + fix(now.getHours(), 2) + ":" + fix(now.getMinutes(), 2);
        $("#lbnow").val(str);
    }

    //载入数据
    function loaddata() {

        $.ajax({
            url: "../WxHandlers/WxBillService.ashx",
            data: { Type: '收入数据载入', OpenID: _openid, NickName: _nickname, Now: now },
            async: true,
            success: function (data) {
                var _val = data.split('|');
                $("#lbssum").html("¥" + _val[0].split('=')[1]);
                $("#lbisum").html("收入：¥" + _val[1].split('=')[1]);
                $("#lbosum").html("支出：¥" + _val[2].split('=')[1]);
            }
        });
    }

    function fix(num, length) {
        return ('' + num).length < length ? ((new Array(length + 1)).join('0') + num).slice(-length) : '' + num;
    }

    //保存
    $(".weui-btn").on('click', function () {
        //时间|类别|金额|备注
        if ($("#money").val() == "") {
            alert("请输入收入金额!");
            return;
        }

        var _params = "Date=" + $("#lbnow").val();
        _params += "|Type=" + $("#setype").val();
        _params += "|Money=" + $("#money").val();
        _params += "|Note=" + $("#textarea").val();

        $.ajax({
            url: "../WxHandlers/WxBillService.ashx",
            data: { Type: '收入数据保存', OpenID: _openid, NickName: _nickname, Params: _params },
            async: true,
            success: function (data) {

                if (data == '收入操作成功！') {
                    $("#money").val("")
                    $("#textarea").val("")
                    initdate();
                    loaddata();
                }
                alert(data);
            }
        });
    });

    init();
})


