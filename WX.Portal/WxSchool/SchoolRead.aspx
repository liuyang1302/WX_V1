<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolRead.aspx.cs" Inherits="WxSchool_SchoolRead" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>书山有路勤为径</title>
    <link rel="stylesheet" href="css/weui.css" />
    <link rel="stylesheet" href="css/example.css" />
    <script src="js/zepto.min.js"></script>
    <script src="js/schoolread.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div id="courseid" runat="server" style="display: none" />
        <div id="coursename" runat="server" style="display: none" />
        <div id="questype" runat="server" style="display: none" />

        <div class="weui-form-preview">
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label id="lbnow" class="weui-form-preview__label" style="color: chocolate; font-size: 1.4em">2017年04月27日    汐汐学习</label>
                    <label id="lbname" class="weui-form-preview__value" style="color: blueviolet; font-size: 1.4em"></label>
                </div>
            </div>
        </div>

        <div class="weui-form-preview__ft">
            <div class="weui-cell__bd">&nbsp;&nbsp;&nbsp;分类阅读</div>
            <a class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:"></a>
            <!--<label id="lberror1" style="color: red; font-size: 1.4em">0</label>
            <label style="font-size: 1.4em">/</label>-->
            <label id="ywhave" style="color: blue; margin-right: 10px;">按目录循环播放</label>
        </div>

        <div class="page home js_show" style="margin-top: 100px">
            <div class="page__bd page__bd_spacing">
                <ul>
                    <li>
                        <div class="weui-flex js_category">
                            <p class="weui-flex__item">分类目录</p>
                            <img src="Img/yy.png" />
                        </div>
                        <div class="page__category js_categoryInner">
                            <div id="分类目录" class="weui-cells page__category-content">
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="weui-flex js_category">
                            <p class="weui-flex__item">学期目录</p>
                            <img src="Img/yy.png" />
                        </div>
                        <div class="page__category js_categoryInner">
                            <div id="学期目录" class="weui-cells page__category-content">
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="weui-flex js_category">
                            <p class="weui-flex__item">自定目录</p>
                            <img src="Img/yy.png" />
                        </div>
                        <div class="page__category js_categoryInner">
                            <div id="自定目录" class="weui-cells page__category-content">
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="page__ft j_bottom">
                <a href="javascript:home()">
                    <%--<img src="Img/speaker.jpg" />--%>
                </a>
            </div>
        </div>



    </form>
</body>
</html>
