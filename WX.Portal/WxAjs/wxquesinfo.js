$(function () {

    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();
    var _courseid = $("#courseid").html();
    var _coursename = $("#coursename").html();
    var _questype = $("#questype").html();
    var _infoid = "";
    var _conanswer = "";
    var _answer = "";
    var _choses;
    var _iserror = false;

    //初始化
    function init() {

        if (_questype != "") { //做错题
            $("#lbtit").html(_questype);
            _iserror = true;
            $("#lbhecount")[0].style.color = "red";
            $("#lbhecount").html("做错题");
        }
        else { //顺序做题
            $("#lbtit").html(_coursename);
            $("#lbhecount")[0].style.color = "blue";
        }

        loaddata(_infoid, _answer);
    }

    //载入数据
    function loaddata(infoid, answer) {

        $.ajax({
            url: "../WxHandlers/WxQuesService.ashx",
            data: { Type: "题目信息", OpenID: _openid, NickName: _nickname, CourseId: _courseid, QuesType: _questype, IsError: _iserror, InfoId: infoid, Answer: answer },
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

        //题目总数|已做|做错|题目ID#$&题目编号#$&题目内容#$&题目答案|选项编号1#$%选项内容1#$&选项编号2#$%选项内容2
        var items = data.split('|');
        $("#lbhcount").html("本科目共 " + items[0] + " 题");
        if (!_iserror)
            $("#lbhecount").html("已做 " + items[1] + " 题 | 做错 " + items[2] + " 题");

        //处理题目信息
        var infos = items[3].split("#$&");
        _infoid = infos[0];  //题目ID
        $("#lbqtit").html("第 " + infos[1] + " 题"); //题目编号
        $("#lbqcontent").html(infos[2]); //题目内容
        _conanswer = infos[3]; //题目答案

        //处理选项信息
        var _chhtml = "";
        _choses = items[4].split("#$&");
        for (var i = 0; i < _choses.length ; i++) {
            if (_choses[i] == "") continue;
            var _chval = _choses[i].split('#$%');
            _chhtml += "<a id='" + _chval[0] + "' class='weui-btn weui-btn_plain-default' href='javascript:;' style='margin: 10px 15px;'>" + _chval[0] + " " + _chval[1] + "</a>";
        }
        $("#couses").html(_chhtml);
        submit();
    }

    function fix(num, length) {
        var str = ('' + num).length < length ? ((new Array(length + 1)).join('虋') + num).slice(-length) : '' + num;
        var str1 = str.replace(num, "");
        for (var i = 0; i < length; i++) {
            str1 = str1.replace("虋", "&nbsp;");
        }
        return num + str1;
    }

    //提交答案
    function submit() {

        $('.weui-btn').on('click', function () {

            //选择的答案
            _answer = $(this)[0].id;
            var _seuss = "";
            var _color = "";
            var _content = "";
            //回答正确
            if (_answer == _conanswer) {
                _color = "green";
                _seuss = "回答正确！";
                _content = $(this).html();
            }
            else {
                _color = "red";
                _seuss = "回答错误！";

                //取得正确答案
                for (var i = 0; i < _choses.length ; i++) {
                    if (_choses[i] == "") continue;
                    var _chval = _choses[i].split('#$%');
                    if (_chval[0] == _conanswer) {
                        _content = _chval[0] + " " + _chval[1];
                    }
                }

                //记录做错的题
                $.ajax({
                    url: "../WxHandlers/WxQuesService.ashx",
                    data: { Type: "错题记录", OpenID: _openid, NickName: _nickname, CourseId: _courseid, InfoId: _infoid, Answer: _answer }
                });
            }

            var _dialoghtml = "";
            _dialoghtml += "<div class='js_dialog' id='wxconfirm' style=’display: none;‘>";
            _dialoghtml += " <div class='weui-mask'></div>";
            _dialoghtml += " <div class='weui-dialog'>";
            _dialoghtml += "   <div class='weui-dialog__hd' style='color: " + _color + "'><strong class='weui-dialog__title'>" + _seuss + "</strong></div>";
            _dialoghtml += "   <div class='weui-dialog__bd'>" + _content + "</div>";
            _dialoghtml += "   <div class='weui-dialog__ft'>";
            _dialoghtml += "     <a id='no' class='weui-dialog__btn weui-dialog__btn_default' href='javascript:;'>重新做</a>";
            _dialoghtml += "     <a id='ok' class='weui-dialog__btn weui-dialog__btn_primary' href='javascript:;'>下一题</a>";
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

                //下一题
                loaddata(_infoid, _answer);
                $('#wxconfirm').fadeOut(200);

            });
            $('#wxconfirm').fadeIn(200);
        });
    }

    //切换错题
    $("#lbhecount").on('click', function () {
        if (_questype != "") //大类不可切换
            return;

        if (_iserror) {
            _iserror = false;
            $("#lbhecount")[0].style.color = "blue";
        }
        else {
            _iserror = true;
            $("#lbhecount")[0].style.color = "red";
            $("#lbhecount").html("做错题");
        }
        _infoid = 0;
        loaddata();
    });

    //初始化
    init();

});