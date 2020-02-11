$(function () {

    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();
    var _courseid = $("#courseid").html();
    var _coursename = $("#coursename").html();
    var _questype = $("#questype").html();
    var _infoid = "";
    var _conanswer = "";
    var _answer = "";
    var _tindex = "";

    //初始化
    function init() {

        //设置录入元素
        var _wh = document.body.clientHeight;        //屏幕可见高
        var _hh = $("#divtm")[0].offsetHeight;        //上高
        var _vh = _wh - _hh - 40;
        $("#divcontent").height(_vh);

        $("#lbtit").html(_coursename);
        loaddata();
    }

    //载入数据
    function loaddata() {

        $.ajax({
            url: "../WxHandlers/WxSchoolService.ashx",
            data: { Type: "下一题", OpenID: _openid, NickName: _nickname, CourseId: _courseid, QuesType: _questype, TypeId: _courseid, TIndex: _tindex, Reid: Math.random() },
            async: true,
            success: afterinfo
        });
    }

    function afterinfo(data) {

        $("#lbqtit").html("")
        $("#couses").html("");
        $("#lbqcontent").html("");

        if (data == "此类无题") {
            $("#lbqcontent").html(data);
            return;
        }

        //题目总数|已做|id,题目,答案
        var items = data.split('|');
        $("#lbhcount").html("本科目共 " + items[0] + " 题");
        $("#lbhecount").html("已做 " + items[1] + " 题");
        var infos = items[2].split(",");
        _infoid = infos[0];  //题目ID
        _tindex = infos[0];  //题目ID
        $("#lbqcontent").html(infos[1]); //题目内容
        _conanswer = infos[2]; //题目答案
      
        if (infos[1] == null || infos[1] == "")
        {
            loaddata();
        }
    }

    $("#next").on('click', function () {
        submitda();
    });

    $("#tda").keydown(function (event) {
        if (event.keyCode == 13) {
            if ($("#imgok")[0].style.display == "inline") {
                $("#next").html("下一题");
            }
            else {
                $("#next").html("提交");
            }
            submitda();
        }
    });

    function submitda() {

        var _val = $("#tda").val();
        var _next = $("#next").html();
        if (_val == null || _val == "") {
            alert("请输入答案!");
            return;
        }

        if (_next == "提交") {

            $("#imgok")[0].style.display = "none";
            $("#imger")[0].style.display = "none";

            if (_conanswer == _val) {
                $("#imgok")[0].style.display = "inline";
                $("#next").html("下一题");
            }
            else {
                $("#imger")[0].style.display = "inline";
            }
            $("#tda").val(_val);
        }
        else {

            $("#imgok")[0].style.display = "none";
            $("#imger")[0].style.display = "none";
            $("#next").html("提交");
            $("#tda").val("");
            loaddata();
        }
    }

    //初始化
    init();

});