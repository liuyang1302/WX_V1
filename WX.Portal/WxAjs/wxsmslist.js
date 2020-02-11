$(function () {

    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();

    var sdate;  //支出开始时间
    var edate;  //支出结束时间

    //初始化
    function init() {
        initdate();
        loaddata();
    }

    //初始化时间
    function initdate() {
        var snow = new Date();
        var enow = new Date();
        snow.setDate(enow.getDate() - 7);

        //开始时间
        sdate = snow.getFullYear() + "-" + fix((snow.getMonth() + 1), 2) + "-" + fix(snow.getDate(), 2);
        $("#sdate").val(sdate);
        //结束时间
        edate = enow.getFullYear() + "-" + fix((enow.getMonth() + 1), 2) + "-" + fix(enow.getDate(), 2);;
        $("#edate").val(edate);
    }

    //补空位
    function fix(num, length) {
        return ('' + num).length < length ? ((new Array(length + 1)).join('0') + num).slice(-length) : '' + num;
    }

    //载入数据
    function loaddata() {

        var _type = $('.weui-bar__item_on').html();

        var _sdate = $("#sdate").val();
        var _edate = $("#edate").val();

        $.ajax({
            url: "../WxHandlers/WxSmsService.ashx",
            data: { Type: '短信列表', CType: _type, OpenID: _openid, NickName: _nickname, SDate: _sdate, EDate: _edate },
            async: true,
            success: loadafter
        });
    }

    function loadafter(data) {

        var $panel = null;
        var _type = $('.weui-bar__item_on').html();
        if (_type == '全部') { $panel = $('#panel1'); }
        else if (_type == '验证码') { $panel = $('#panel2'); }
        else { $panel = $('#panel3'); }

        if (data == "无数据") {
            $panel.html(data);
            return;
        }

        var _list = '';
        var _items = data.split('|');
        for (var i = 0; i < _items.length; i++) {

            var _item = _items[i].split(';');

            var PHONE = _item[0].split('=')[1];
            var COMEFROM = _item[1].split('=')[1];
            var TYPE = _item[2].split('=')[1];
            var SMSDATE = _item[3].split('=')[1];
            var CONTENT = _item[4].split('=')[1];


            if (_list != '') _list += "</div>";
            _list += "<div class='weui-cells__title'>" + (COMEFROM + "-->" + PHONE + "-->" + TYPE + "-->" + SMSDATE) + "</div><div class='weui-cells'>";


            _list += "<div class='weui-cell'>";
            _list += "<div class='weui-cell__bd'>"; //
            _list += "<p>" + (CONTENT) + "</p>";
            _list += "</div>";
            //_list += "<div class='weui-cell__ft' style='margin-right: 15px'>" + CONTENT + "</div>";
            _list += "</div>";
        }

        $panel.html(_list);
    }


    function loadwp() {

        $.ajax({
            url: "../WxHandlers/WpCodeService.ashx",
            data: { Type: 'WXGETCODES' },
            async: true,
            success: loaafdwp
        });

    }

    function loaafdwp(data) {

        var _items = data.split(';');
        var _list = '';

        for (var i = 0; i < _items.length; i++) {
            var _item = _items[i].split('|');
            var code = _item[0];
            var msg = _item[1];
            var date = _item[2];

            //if (_list != '') _list += "</div>";
            _list += "<div class='weui-cells__title'>" + code + "</div><div class='weui-cells'>";
            _list += "<div class='weui-cell'>";
            _list += "<div class='weui-cell__bd'>"; //
            _list += "<p>" + (code + "&nbsp;&nbsp;&nbsp;" + msg) + "</p>";
            _list += "</div>";
            _list += "<div class='weui-cell__ft' style='margin-right: 15px'>" + date + "</div>";
            _list += "</div>";
            _list += "</div>";
        }
        $('#panel4').html(_list);
    }


    //----------------事件-------------------------------
    //Tab切换事件
    $('.weui-navbar__item').on('click', function () {
        $(this).addClass('weui-bar__item_on').siblings('.weui-bar__item_on').removeClass('weui-bar__item_on');

        $("#panel1").hide();
        $("#panel2").hide();
        $("#panel3").hide();
        $("#panel4").hide();

        if ($(this).html() == '全部') {
            loaddata();
            $("#panel1").show();
        }
        else if ($(this).html() == '验证码') {
            loaddata();
            $("#panel2").show();
        }
        else if ($(this).html() == '帐户收支') {
            loaddata();
            $("#panel3").show();
        }
        //else if ($(this).html() == '电子码') {
        //    loadwp();
        //    $("#panel4").show();
        //}
    });


    init();


});