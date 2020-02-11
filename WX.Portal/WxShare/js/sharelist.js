$(function () {

    var _fist;
    var _code;
    var _name;

    //初始化
    function init() {
        _fist = "sh";
    }

    function loadshare() {
        
        alert("a");
        _code = "sh000001";
       
        $.ajax({
            url: "http://hq.sinajs.cn/list=sh000001",
            data: { list: _code },
            async: true,
            success: shareafter
        });
    }

    function shareafter(data) {

        alert(data);
    }


    //载入数据
    function loaddata() {

        var _questype = "股票列表_增加";

        $.ajax({
            url: "../WxHandlers/WxShareService.ashx",
            data: { Type: "股票列表_增加", code: _code, name: _name, Reid: Math.random() },
            async: true,
            success: loadafter
        });
    }

    function loadafter(data) {

        if (data == "")
        {
            //data = "6000"
            alert(data);
        }
        
    }


    $("#addlist").on('click', function () {

        loaddata();
        //loadshare();


    });

    init();

});