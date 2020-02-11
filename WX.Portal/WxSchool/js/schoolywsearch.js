$(function () {

    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();
    var _filter = $("#filter").html();

    //初始化
    function init() {

        //设置录入元素
        $("#divsearch").html("");

        if (_filter != null && _filter != "") {
            $("#kw").val(_filter);
            search(_filter);
        }
    }

    $("#su").on('click', function () {

        var _val = $("#kw").val();
        search(_val);

    });

    function search(data) {

        $.ajax({
            url: "../WxHandlers/WxSchoolService.ashx",
            data: { Type: "查询", OpenID: _openid, NickName: _nickname, Filter: data, Reid: Math.random() },
            async: true,
            success: afterinfo
        });
    }

    function afterinfo(data) {

        //填充
        //alert(data);
        $("#divsearch").html(data);

        $(".mp3-play").on('click', function () {

            var _url = $(".mp3-play").attr("url");
            var audio = document.getElementById('_audio');
            audio.src = _url;
            audio.play();
        });
    }

    init();

});


