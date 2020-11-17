$(function () {

    var _openid = $("#openid").html();
    var _nickname = $("#nickname").html();
    var _courseid = $("#courseid").html();
    var _coursename = $("#coursename").html();
    var _questype = $("#questype").html();

    $("#aa").on('click', function () {
        var _url = "";
        var _params = "?OpenID=" + _openid + "&NickName=" + _nickname + "&CourseId=" + _courseid + "&CourseName=" + _coursename;
        _url = "SchoolSx.aspx" + _params;
        window.location.href = _url;
    });

});