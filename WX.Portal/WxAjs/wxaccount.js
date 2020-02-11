$(function () {

    var now;
    var _valcount;
    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();

    //初始化
    function init() {

        //设置录入元素
        var _wh = document.body.clientHeight;        //屏幕可见高
        var _hh = $(".weui-form-preview")[0].offsetHeight; //花销高
        var _sh = $("#datediv")[0].offsetHeight;     //时间高
        var _bh = $("#divbz")[0].offsetHeight;       //备注高
        var _qh = $(".weui-btn-area")[0].offsetHeight;       //确定高
        var _vh = _wh - _hh - _sh - _bh - _qh;

        var _vg = 20;       //间隔高
        var _zh = 44;       //录值高
        var _ph = _vg + _zh;
        _valcount = parseInt(_vh / _ph);

        var _valhtml = "";
        for (var i = 0; i < _valcount; i++) {
            _valhtml += "<div class='weui-cell'></div>"; //间隔
            _valhtml += "<div class='weui-cell weui-cell_select weui-cell_select-before'>";
            _valhtml += "<div class='weui-cell__hd weui-select'>";
            _valhtml += "<input id='name" + i + "' class='weui-input' type='text' placeholder='名称'>";
            _valhtml += "</div>";
            _valhtml += "<div class='weui-cell__bd'>";
            _valhtml += "<input id='money" + i + "' class='weui-input weui-input-number' type='number' step='0.01' placeholder='￥请输入金额' pattern='[0-9]*' />";
            _valhtml += "</div>";
            _valhtml += "</div>";
        }

        var _olisthtml = $(".weui-cells_form").html();
        var _nlisthtml = _olisthtml.replace("<div id=\"divval\"></div>", _valhtml);
        $(".weui-cells_form").html(_nlisthtml);
        //$("#divval").html(_valhtml);

        //载入数据
        initdate();
        loaddata();
        savedata();
    }

    function initdate() {
        now = new Date();
        var str = now.getFullYear() + "-" + fix((now.getMonth() + 1), 2) + "-" + fix(now.getDate(), 2) + "T" + fix(now.getHours(), 2) + ":" + fix(now.getMinutes(), 2);
        $("#_lbnow").val(str);
    }

    //载入数据
    function loaddata() {

        $.ajax({
            url: "../WxHandlers/WxBillService.ashx",
            data: { Type: '支出数据载入', OpenID: _openid, NickName: _nickname, Now: now },
            async: true,
            success: function (data) {
                $("#money").html("¥" + data);
            }
        });
    }

    function fix(num, length) {
        return ('' + num).length < length ? ((new Array(length + 1)).join('0') + num).slice(-length) : '' + num;
    }

    //保存
    function savedata() {

        $(".weui-btn").on('click', function () {
            var _params = "Date=" + $("#_lbnow").val();
            _params += "|Note=" + $("#_textarea").val();
            var _items = "";
            for (var i = 0; i < _valcount; i++) {
                var _name = $("#name" + i).val();
                var _money = $("#money" + i).val();
                if (_name != null && _name != "" && _money != null && _money != '') {
                    _items += "|Name=" + _name + ";Money=" + _money;
                }
            }

            if (_items == "") {
                alert("未填写任何指出!");
                return;
            }
            _params += _items;

            $.ajax({
                url: "../WxHandlers/WxBillService.ashx",
                data: { Type: '支出数据保存', OpenID: _openid, NickName: _nickname, Params: _params },
                async: true,
                success: function (data) {

                    if (data == '记账操作成功！') {
                        for (var i = 0; i < _valcount; i++) {
                            $("#name" + i).val("");
                            $("#money" + i).val("");
                        }
                        initdate();
                        loaddata();
                    }
                    alert(data);
                }
            });
        });
    }

    init();

});