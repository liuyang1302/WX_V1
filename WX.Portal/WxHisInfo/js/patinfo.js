$(function () {

    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();
    var _cid = $("#cid").html();
    var _cname = $("#cname").html();
    var $loadingToast = $('#loadingToast');
    var _mindt;
    var _infos;
    var _row;

    //初始化
    function init() {
        _mindt = new Date().toLocaleDateString();
        _infos = new Array;
        initdate();
        loaddata();
    }

    //初始化时间
    function initdate() {

        var now = new Date();
        var day1 = new Date();
        day1.setTime(day1.getTime()-24*60*60*1000);
        var _sd = day1.getFullYear() + "-" + fix((day1.getMonth() + 1), 2) + "-" + fix(day1.getDate(), 2);
        $("#sdate").val(_sd);
        var _ed = now.getFullYear() + "-" + fix((now.getMonth() + 1), 2) + "-" + fix(now.getDate(), 2);
        $("#edate").val(_ed);
        $(".weui-panel__bd").html("");
    }

    //补空位
    function fix(num, length) {
        return ('' + num).length < length ? ((new Array(length + 1)).join('0') + num).slice(-length) : '' + num;
    }

    function fix2(num, length) {
        if (('' + num).length < length) {
            var _l = length - ('' + num).length;
            for (var i = 0; i <= _l; i++) {
                num += "&nbsp;"
            }
        }
        return num;
    }

    //载入数据
    function loaddata() {

        if ($loadingToast.css('display') == 'none') {
            $loadingToast.fadeIn(100);
        }

        var _sdt = $("#sdate").val() + " 00:00:00";
        var _edt = $("#edate").val() + " 23:59:59";
        var _minid = "0";
        for (var i = 0; i < _infos.length; i++) {
            var _item = _infos[i];
            var _val = _item.split('|');
            _minid += "," + _val[0];
        }

        $.ajax({
            url: "../WxHandlers/WxHisInfoService.ashx",
            data: { type: "病人信息", cid: _cid, sdt: _sdt, edt: _edt, mindt: _mindt, minid: _minid, rid: Math.random() },
            async: true,
            success: loadafter
        });
    }

    //载入完成
    function loadafter(data) {

        var _hh = $(".weui-panel__bd").html();
        if (_hh == "" && data.indexOf('$') < 0) {
            $(".weui-panel__bd").html("无患者列表！");
            $loadingToast.fadeOut(100);
            return;
        }
        if (data.indexOf('$') < 0) {
            $loadingToast.fadeOut(100);
            return;
        }

        var _html = "";

        var _ids = new Array;
        var _qlist = data.split('$');
        for (var i = 0; i < _qlist.length; i++) {

            var _item = _qlist[i];
            if (_item == "") continue;
            if (_infos.indexOf(_item) > -1) continue;
            _infos.push(_item);

            var _val = _item.split('|');
            var id = _val[0];
            var 类型 = _val[1];
            var 病人ID = _val[2];
            var 姓名 = _val[3];
            var 性别 = _val[4];
            var 年龄 = _val[5];
            var 出生日期 = _val[6];
            var 身份证号 = _val[7];
            var 婚姻状况 = _val[8];
            var 联系电话 = _val[9];
            var 联系人姓名 = _val[10];
            var 联系人电话 = _val[11];
            var 诊断ID = _val[12];
            var 诊断描述 = _val[13];
            var 记录日期 = _val[14];
            var img = "man.png";
            if (性别 == "女") {
                img = "woman.png";
            }
            var 电话 = 联系电话;
            if (电话 == "") {
                电话 = "联" + 联系人电话;
            }
            if (年龄.indexOf("岁") == -1) {
                年龄 = 年龄 + "岁";
            }

            _html += "<a id='" + id + "' class='weui-media-box weui-media-box_appmsg' href='javascript:;'>";
            _html += " <div class='weui-media-box__hd' style='margin-left:-10px'>";
            _html += "   <img id='" + id + "_img' class='weui-media-box__thumb' alt='' src='img/" + img + "'>";
            _html += " </div>";
            _html += " <div class='weui-media-box__bd' style='margin-left:-15px'>";
            _html += "    <div class='weui-media-box__title'>";
            _html += "       <h4 class='weui-media-box__title' style='float: left;'>" + fix2(姓名, 4) + 年龄 + "</h4>";
            _html += "       <h4 class='weui-media-box__title' style='float: right;'>" + 电话 + "</h4>";
            _html += "    </div>";
            _html += "    <p id='" + id + "_zd' class='weui-media-box__desc'>" + 记录日期 + "&nbsp;&nbsp;&nbsp;" + 诊断描述 + "</p>";
            _html += " </div>";
            //_html += " <span id='" + id + "_ft' ></span>";
            _html += "</a>";

            if (记录日期 < _mindt) {
                _mindt = 记录日期;
            }

            _ids.push(id);
        }

        if (_html == "") {
            return;
        }

        $(".weui-panel__bd").append(_html);

        //事件
        for (var i = 0; i < _ids.length; i++) {
            retoinfo(_ids[i]);
        }

        $loadingToast.fadeOut(100);
    }

    $(".weui-cell_link").on('click', function () {
        loaddata();
    });

    //时间修改
    $('.weui-input').on('change', function () {
        $(".weui-panel__bd").html("");
        _mindt = new Date().toLocaleDateString();
        _infos = new Array;
        loaddata();
    });

    //性别修改
    $('.weui-select').on('change', function () {
        $(".weui-panel__bd").html("");
        _mindt = new Date().toLocaleDateString();
        _infos = new Array;
        loaddata();
    });

    //列表转向
    function retoinfo(pid) {
        $("#" + pid).on('click', function () {
            var _id = $(this)[0].id;
            var _html = $("#" + _id + "_zd").html();
            var _phone;
            for (var i = 0; i < _infos.length; i++) {
                var _item = _infos[i];
                var _val = _item.split('|');
                if (_val[0] == _id) {
                    _row = _item;
                    _phone = _val[9] != "" ? _val[9] : _val[11];
                    break;
                }
            }

            if (_html.indexOf("出生日期") == -1) {  //诊断
                var 病人ID = _val[2];
                $.ajax({
                    url: "../WxHandlers/WxHisInfoService.ashx",
                    data: { type: "诊断信息", ctype: _cid, patid: 病人ID, rid: Math.random() },
                    async: true,
                    success: loadzd
                });
            }
            else {  //明细
                var 诊断描述 = _val[13];
                var 记录日期 = _val[14];
                $("#" + _id + "_zd").html(记录日期 + "&nbsp;&nbsp;&nbsp;" + 诊断描述);
            }

            clipboardData.setData("Text", _phone);
        });

        $("#" + pid + "_img").on('click', function () {
            var _id = $(this)[0].id;
            _id = _id.replace("_img", "");
            var _phone;
            for (var i = 0; i < _infos.length; i++) {
                var _item = _infos[i];
                var _val = _item.split('|');
                if (_val[0] == _id) {
                    _phone = _val[9] != "" ? _val[9] : _val[11];
                    break;
                }
            }
            clipboardData.setData("Text", _phone);
        });

    }

    function loadzd(data) {

        if (_row == null) {
            return;
        }

        var _val = _row.split('|');
        var id = _val[0];
        var 类型 = _val[1];
        var 病人ID = _val[2];
        var 姓名 = _val[3];
        var 性别 = _val[4];
        var 年龄 = _val[5];
        var 出生日期 = _val[6];
        var 身份证号 = _val[7];
        var 婚姻状况 = _val[8];
        var 联系电话 = _val[9];
        var 联系人姓名 = _val[10];
        var 联系人电话 = _val[11];
        var 诊断ID = _val[12];
        var 诊断描述 = _val[13];
        var 记录日期 = _val[14];
        var 电话 = 联系电话;
        if (电话 == "") {
            电话 = "联" + 联系人电话;
        }
        if (年龄.indexOf("岁") == -1) {
            年龄 = 年龄 + "岁";
        }

        var _html = "<h4 class='weui-media-box__title'>";
        _html += "出生日期：" + 出生日期 + "    " + 婚姻状况 + "<br />";
        _html += "身份证号：" + 身份证号 + " <br />";
        _html += "联系人姓名：" + 联系人姓名 + "<br />";
        _html += "联系人电话：" + 联系人电话 + "<br />";

        if (data.indexOf('$') > 0) {
            var _qlist = data.split('$');
            for (var i = 0; i < _qlist.length; i++) {
                var _item = _qlist[i];
                if (_item == "") continue;
                var _zdval = _item.split('|');
                if (_zdval[1] == "") continue;
                _html += _zdval[0] + " " + _zdval[1] + "<br />";
            }
        }
        else {
            _html += 记录日期 + " " + 诊断描述 + "<br />";
        }
        _html += "</h4>";

        $("#" + id + "_zd").html(_html);
    }


    init();

});