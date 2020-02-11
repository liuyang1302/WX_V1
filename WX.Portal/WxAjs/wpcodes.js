$(function () {

    var date;
    var date1;
    var date2;
    var date3;


    //载入数据
    function loaddata() {

        var _tab = $('.weui-bar__item_on').html();
        $.ajax({
            url: "../WxHandlers/WpCodeService.ashx",
            data: { Type: 'WXGETCODES', Tab: _tab, Date: date },
            async: true,
            success: loadafter
        });
    }

    function loadafter(data) {

        if (data == null || data == "") {
            return;
        }

        var $panel = null;
        var _items = data.split(';');
        var _info = _items[0].split('|');
        var _type = $('.weui-bar__item_on').html();
        if (_type == '可用') { $panel = $('#panel1'); date1 = _info[0]; }
        else if (_type == '有效') { $panel = $('#panel2'); date2 = _info[0]; }
        else { $panel = $('#panel3'); date3 = _info[0]; }

        $('.weui-label').html("共 " + _info[1] + " 条");

        for (var i = 1; i < _items.length; i++) {

            var _item = _items[i].split('|');

            var _code = _item[0];
            var _msgs = _item[1];
            var _ldate = _item[2];
            var _idate = _item[3];

            var _content = "<div class='weui-cell'>";
            if (_type == "可用" || _type == "有效") {
                _content += "<div class='weui-cell__bd'>";
                _content += "<p>" + (_code + "&nbsp;&nbsp;&nbsp;&nbsp;" + _msgs) + "</p>";
                _content += "</div>";
                _content += "<div class='weui-cell__ft' style='margin-right: 15px'>" + _ldate + "</div>";
            }
            else {
                _content += "<div class='weui-cell__bd'>";
                _content += "<p>" + (_code + "&nbsp;&nbsp;&nbsp;&nbsp;" + _msgs) + "</p>";
                _content += "</div>";
                _content += "<div class='weui-cell__ft' style='margin-right: 15px'>" + _idate + "</div>";
            }


            _content += "</div>";

            //$panel.prepend(_content);
            $panel.append(_content);
        }
    }

    //----------------事件-------------------------------
    //Tab切换事件
    $('.weui-navbar__item').on('click', function () {
        $(this).addClass('weui-bar__item_on').siblings('.weui-bar__item_on').removeClass('weui-bar__item_on');

        $("#panel1").hide();
        $("#panel2").hide();
        $("#panel3").hide();

        if ($(this).html() == '可用') {
            date = date1;
            loaddata();
            $("#panel1").show();
        }
        else if ($(this).html() == '有效') {
            date = date2;
            loaddata();
            $("#panel2").show();
        }
        else if ($(this).html() == '全部') {
            date = date3;
            loaddata();
            $("#panel3").show();
        }
    });


    loaddata();

});