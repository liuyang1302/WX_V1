$(function () {

    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();

    var outsdate;  //支出开始时间
    var outedate;  //支出结束时间
    var insdate;   //收入开始时间
    var inedate;   //收入结束时间

    //初始化
    function init() {
        initdate();
        loaddata();
    }

    //初始化时间
    function initdate() {
        var now = new Date();
        //开始时间
        outsdate = insdate = now.getFullYear() + "-" + fix((now.getMonth() + 1), 2) + "-01";
        $("#sdate").val(outsdate);
        //结束时间
        outedate = inedate = now.getFullYear() + "-" + fix((now.getMonth() + 1), 2) + "-" + (new Date(now.getFullYear(), (fix((now.getMonth() + 1), 2)), 0).getDate());
        $("#edate").val(outedate);
    }

    //补空位
    function fix(num, length) {
        return ('' + num).length < length ? ((new Array(length + 1)).join('0') + num).slice(-length) : '' + num;
    }

    //载入数据
    function loaddata() {

        $('#lbsubtit').html('范围内');
        $('#lbsubsum').html(' ');
        var _type = $('.weui-bar__item_on').html();
        if (_type == '支出明细') {
            $('#panel1').html(' ');
        }
        else {
            $('#panel1').html(' ');
        }

        _type = '报表' + _type;
        var _sdate = $("#sdate").val();
        var _edate = $("#edate").val();

        

        $.ajax({
            url: "../WxHandlers/WxBillService.ashx",
            data: { Type: _type, OpenID: _openid, NickName: _nickname, SDate: _sdate, EDate: _edate },
            async: true,
            success: loadafter
        });
        //$("#_lbsubsum").html(htmlobj.responseText);
    }

    //明细载入
    function loadafter(data) {

        var $panel = null;
        var _type = $('.weui-bar__item_on').html();
        if (_type == '支出明细') { $panel = $('#panel1'); }
        else { $panel = $('#panel2'); }

        //总额
        var _datas = data.split('|');
        var _sums = _datas[0].split('=');
        $('#lbsubtit').html(_sums[0]);
        if (_sums[0] == "范围内无数据") {
            $panel.html(_sums[0]);
            return;
        }
        $('#lbsubsum').html('¥' + _sums[1]);

        var _list = '';
        var _ndate = '';
        //ID=1;ItemName=aa;ItemMoney=10;ItemDate=2010-01-01
        //ID=1;ItemType=aa;ItemMoney=10;ItemDate=2010-01-01
        for (var i = 1; i < _datas.length; i++) {

            var _items = _datas[i].split(';');

            //日期头
            if (_ndate != _items[3].split('=')[1]) {
                _ndate = _items[3].split('=')[1];
                if (_list != '') _list += "</div>";
                _list += "<div class='weui-cells__title'>" + _ndate + "</div><div class='weui-cells'>";
            }

            var _id = _items[0].split('=')[1];
            var _name = _items[1].split('=')[1];
            var _money = _items[2].split('=')[1];
            var _time = _items[4].split('=')[1];
            //_name = _name + "  (" + _time + ")";
            var _key = _type + "_" + _id + "_" + _name + "_" + _money;

            _list += "<div class='weui-cell'>";
            _list += "<div class='weui-cell__bd'>";
            _list += "<p>" + _name + "</p>";
            _list += "</div>";
            _list += "<div class='weui-cell__bd' style='color: DarkOliveGreen'>(" + _time + ")</div>";
            _list += "<div class='weui-cell__ft' style='margin-right: 15px; color: blue; width: 70px'>¥" + _money + "</div>";
            _list += "<div class='weui-cell__ft'>";
            _list += "<a id='" + _key + "' class='weui-btn weui-btn_warn' href='javascript:;'  style='font-size: 14px; border-radius: 3px; padding-right: 8px; padding-left: 8px; margin-right: -3px'>删除</a>";
            _list += "</div>";
            _list += "</div>";
        }
        $panel.html(_list);
        ReLoadWarn();
    }

    //弹出删除框
    function ReLoadWarn() {
        $('.weui-btn_warn').on('click', function () {
            $("#dialog").html(" ");
            var _id = $(this)[0].id;
            var _params = _id.split('_');
            var _dialoghtml = "";
            _dialoghtml += "<div class='js_dialog' id='wxconfirm' style=’display: none;‘>";
            _dialoghtml += " <div class='weui-mask'></div>";
            _dialoghtml += " <div class='weui-dialog'>";
            _dialoghtml += "   <div class='weui-dialog__hd'><strong class='weui-dialog__title'>是否删除？</strong></div>";
            _dialoghtml += "   <div class='weui-dialog__bd' style='color: red'>您确定要删除 “" + _params[2] + " " + _params[3] + "” 项目吗？</div>";
            _dialoghtml += "   <div class='weui-dialog__ft'>";
            _dialoghtml += "     <a id='no' class='weui-dialog__btn weui-dialog__btn_default' href='javascript:;'>取消</a>";
            _dialoghtml += "     <a id='" + _id + "' class='weui-dialog__btn weui-dialog__btn_primary' href='javascript:;'>确定</a>";
            _dialoghtml += "   </div>";
            _dialoghtml += "  </div>";
            _dialoghtml += "</div>";
            $("#dialog").html(" ");
            $("#dialog").html(_dialoghtml);

            $('.weui-dialog__btn').on('click', function () {

                var _id = $(this)[0].id;
                if (_id == 'no') {
                    $('#wxconfirm').fadeOut(200);
                    return;
                }

                var _delparams = _id.split('_');
                var _deltype = '删除' + $('.weui-bar__item_on').html();

                //删除操作
                $.ajax({
                    url: "../WxHandlers/WxBillService.ashx",
                    data: { Type: _deltype, OpenID: _openid, NickName: _nickname, ItemID: _delparams[1] },
                    async: true,
                    success: function (data) {
                        alert(data);
                        loaddata();
                    }
                });

                $('#wxconfirm').fadeOut(200);
            });

            $('#wxconfirm').fadeIn(200);
        });
    }


    //----------------事件-------------------------------
    //Tab切换事件
    $('.weui-navbar__item').on('click', function () {
        $(this).addClass('weui-bar__item_on').siblings('.weui-bar__item_on').removeClass('weui-bar__item_on');

        $("#_timediv").show();
        $("#panel1").hide();
        $("#panel2").hide();
        $("#panel3").hide();

        if ($(this).html() == '支出明细') {
            $('#sdate').val(outsdate);
            $('#edate').val(outedate);
            loaddata();
            $("#panel1").show();
        }
        else if ($(this).html() == '收入明细') {
            $('#sdate').val(insdate);
            $('#edate').val(inedate);
            loaddata();
            $("#panel2").show();
        }
        else {
            $("#_timediv").hide();
            $("#panel3").show();
        }
        
    });

    //时间修改
    $('.weui-input').on('change', function () {
        var _type = $('.weui-bar__item_on').html();
        var _id = $(this)[0].id;
        if (_type == '支出明细') {
            if (_id == "sdate")
                outsdate = $(this).val();
            else
                outedate = $(this).val();
            //alert($(this).val());
        }
        else if (_type == '收入明细') {
            if (_id == "sdate")
                insdate = $(this).val();
            else
                inedate = $(this).val();
        }
        loaddata();
    });

    //载入初始化
    init();

});

