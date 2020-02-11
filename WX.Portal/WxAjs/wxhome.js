$(function () {

    var openid = "";
    var nickname = "";

    function init() {

        var _openid = getCookie("OpenId");
        if (_openid == null) {
            $("#divreg").show();
            $("#divhome").hide();
        }
        else {
            $("#divreg").hide();
            $("#divhome").show();
            openid = _openid;
            nickname = _openid;
            $("#lbqtit").html("欢迎 " + _openid + " 来到宸汐之家");
        }

        
        if (_openid == "刘洋") {
            $.ajax({
                url: "WxHandlers/WxBillService.ashx",
                data: { Type: '外网IP' },
                async: true,
                success: function (data) {
                    $("#lbqtit").html(_openid + "  " + data);
                }
            });
        }
    }

    //写cookies
    function setCookie(name, value) {
        var Days = 30;
        var exp = new Date();
        exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
        document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString();
    }

    //读取cookies 
    function getCookie(name) {
        var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");

        if (arr = document.cookie.match(reg))

            return unescape(arr[2]);
        else
            return null;
    }
    //删除cookies 
    function delCookie(name) {
        var exp = new Date();
        exp.setTime(exp.getTime() - 1);
        var cval = getCookie(name);
        if (cval != null)
            document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString();
    }

    //注册/登陆
    $("#submit").on('click', function () {

        var _user = $("#user").val();
        var _pswd = $("#pswd").val();

        if (_user == "") {
            alert("请填写用户名！");
            return;
        }
        if (_pswd == "") {
            alert("请填写密码！");
            return;
        }

        $.ajax({
            url: "WxHandlers/WxBillService.ashx",
            data: { Type: '用户注册', OpenID: _user, NickName: _user, Password: _pswd },
            async: true,
            success: function (data) {

                if (data == "成功" || data == "登录成功" || data == "注册成功") {

                    setCookie("OpenId", _user);
                    setCookie("user", _user);
                    setCookie("pwd", _pswd);
                    openid = _user;
                    nickname = _user;
                    $("#lbqtit").html("欢迎 " + openid + " 来到宸汐之家");

                    $("#divreg").hide();
                    $("#divhome").show();
                }
                else {
                    alert(data);
                }
            }
        });

    });

    $("#bill").on('click', function () {
        var _url = "WxBill/WxAccBill.aspx?OpenId=" + openid + "&NickName=" + nickname;
        window.location.href = _url;
    });

    $("#ques").on('click', function () {
        var _url = "WxQues/WxQuesHome.aspx?OpenId=" + openid + "&NickName=" + nickname;
        window.location.href = _url;
    });

    $("#reus").on('click', function () {

        delCookie("OpenId");
        $("#divreg").show();
        $("#divhome").hide();
        openid = ""; nickname = "";

    });


    init();
});