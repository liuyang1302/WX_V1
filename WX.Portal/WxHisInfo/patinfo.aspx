<%@ Page Language="C#" AutoEventWireup="true" CodeFile="patinfo.aspx.cs" Inherits="WxHisInfo_patinfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>病人信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <link rel="stylesheet" href="../WxAcss/weui.css" />
    <link rel="stylesheet" href="../WxAcss/example.css" />
    <script src="../WxAjs/zepto.min.js"></script>
    <script src="js/patinfo.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div id="cid" runat="server" style="display: none" />
        <div id="cname" runat="server" style="display: none" />

        <div class="weui-form-preview">
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label id="lbnow" runat="server" class="weui-form-preview__label" style="color: cornflowerblue; font-size: 1.4em"></label>
                </div>
            </div>
        </div>
        <div class="weui-tab">
            <div class="weui-tab__panel"></div>
            <div class="weui-tabbar">
                <input id="sdate" class="weui-input" type="date" style="color: chocolate; height: 3em; margin-left: 5px;" value="2017-04-01" />
                <a class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:"></a>
                <input id="edate" class="weui-input" type="date" style="color: chocolate; height: 3em; margin-left: 5px;" value="2017-04-30" />
                <a class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:"></a>
                <select id="setype" class="weui-select" style="color: chocolate;">
                    <option value="不限">不限</option>
                    <option value="男">男</option>
                    <option value="女">女</option>
                </select>
            </div>
        </div>

        <div class="weui-panel weui-panel_access">
            <div class="weui-panel__bd">
                <a class="weui-media-box weui-media-box_appmsg" href="javascript:void(0);">
                    <div class="weui-media-box__hd" style="margin-left: -5px">
                        <img class="weui-media-box__thumb" alt="" src="img/woman.png">
                    </div>
                    <div class="weui-media-box__bd">
                        <div class="weui-media-box__title">
                            <h4 class="weui-media-box__title" style="float: left; color: Highlight">标题二</h4>
                            <h4 class="weui-media-box__title" style="float: right; color: Highlight">13039114451</h4>
                        </div>
                        <p class="weui-media-box__desc">由各种物质组成的巨型球状天体，叫做星球。</p>
                    </div>
                    <span class="weui-cell__ft"></span>
                </a>
                <a class="weui-media-box weui-media-box_appmsg" href="javascript:void(0);">
                    <div class="weui-media-box__hd">
                        <img class="weui-media-box__thumb" alt="" src="img/man.png">
                    </div>
                    <div class="weui-media-box__bd">
                        <div class="weui-media-box__title">
                            <h4 class="weui-media-box__title" style="float: left">标题二</h4>
                            <h4 class="weui-media-box__title" style="float: right">13039114451</h4>
                        </div>
                        <p class="weui-media-box__desc">由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。</p>
                    </div>
                    <span class="weui-cell__ft"></span>
                </a>
                <a class="weui-media-box weui-media-box_appmsg" href="javascript:void(0);">
                    <div class="weui-media-box__hd">
                        <img class="weui-media-box__thumb" alt="" src="img/man.png">
                    </div>
                    <div class="weui-media-box__bd">
                        <div class="weui-media-box__title">
                            <h4 class="weui-media-box__title" style="float: left">标题二</h4>
                            <h4 class="weui-media-box__title" style="float: right">13039114451</h4>

                        </div>
                        <div>
                            <p class="weui-media-box__desc">
                                <h4 class="weui-media-box__title">年龄：18岁     出生日期：2018-05-01    已婚<br />
                                    身份证号：220622193506270039<br />
                                    联系人：王克荣  电话： 13843976557<br />
                                    2018/05/02 十大阿斯蒂芬阿斯顿<br />
                                    2018/05/02 十大阿斯蒂芬阿斯顿<br />
                                    2018/05/02 十大阿斯蒂芬阿斯顿<br />
                                </h4>
                            </p>
                        </div>
                    </div>
                    <span class="weui-cell__ft">
                        <a class="weui-btn weui-btn_mini weui-btn_primary" style="margin-top: -15px; margin-left: 90px" href="javascript:;">标记</a>
                        <a class="weui-btn weui-btn_mini weui-btn_warn" style="margin-top: -15px; margin-left: 15px" href="javascript:;">复制</a>
                    </span>
                </a>

            </div>
            <div class="weui-panel__ft">
                <a class="weui-cell weui-cell_access weui-cell_link" href="javascript:void(0);">
                    <div class="weui-cell__bd">查看更多</div>
                    <span class="weui-cell__ft"></span>
                </a>
            </div>
        </div>

        <div id="loadingToast" style="display: none; opacity: 0;">
            <div class="weui-mask_transparent"></div>
            <div class="weui-toast">
                <i class="weui-loading weui-icon_toast"></i>
                <p class="weui-toast__content">亲爱的,慢慢等</p>
            </div>
        </div>

    </form>
</body>
</html>
