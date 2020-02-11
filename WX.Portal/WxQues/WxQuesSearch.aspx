<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WxQuesSearch.aspx.cs" Inherits="WxQues_WxQuesSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>随时随地，给我想要</title>
    <link rel="stylesheet" href="../WxAcss/weui.css" />
    <link rel="stylesheet" href="../WxAcss/example.css" />
    <script src="../WxAjs/zepto.min.js"></script>
    <script src="../WxAjs/wxquessearch.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div id="questype" runat="server" style="display: none" />
        <div class="weui-form-preview" style="position:fixed; z-index: 500; width: 100%;  margin-top:-100px" >
            <div class="weui-form-preview__hd" style="height: 30px;">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label id="lbtit" class="weui-form-preview__label" style="color: chocolate; font-size: 1.0em; text-align:center;width:100%">定期考核</label>
                </div>
            </div>
            <div class="weui-form-preview__ft" >
                 <input id="inkey" class="weui-input" type="text" placeholder="汉字或简码" style="margin-left: 10px; margin-right: 10px; height:45px; font-size:1.2em" value="" />
            </div>
        </div>

        <div class="weui-panel weui-panel_access" style="margin-top:100px">
            <div class="weui-panel__bd">
                <div class="weui-media-box weui-media-box_text">
                    <p class="weui-media-box__desc" style="margin-top:-5px">由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。</p>
                    <h4 class="weui-media-box__title" style="margin-bottom:-10px; margin-top:5px; font-size:small" >B 正确答案</h4>
                </div>
                <div class="weui-media-box weui-media-box_text">
                    <p class="weui-media-box__desc" style="margin-top:-5px">由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。</p>
                    <h4 class="weui-media-box__title" style="margin-bottom:-10px; margin-top:5px; font-size:small" >B 正确答案</h4>
                </div>
                <div class="weui-media-box weui-media-box_text">
                    <p class="weui-media-box__desc" style="margin-top:-5px">由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。</p>
                    <h4 class="weui-media-box__title" style="margin-bottom:-10px; margin-top:5px; font-size:small" >B 正确答案</h4>
                </div>
                <div class="weui-media-box weui-media-box_text">
                    <p class="weui-media-box__desc" style="margin-top:-5px">由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。</p>
                    <h4 class="weui-media-box__title" style="margin-bottom:-10px; margin-top:5px; font-size:small" >B 正确答案</h4>
                </div>
                <div class="weui-media-box weui-media-box_text">
                    <p class="weui-media-box__desc" style="margin-top:-5px">由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。</p>
                    <h4 class="weui-media-box__title" style="margin-bottom:-10px; margin-top:5px; font-size:small" >B 正确答案</h4>
                </div>
                <div class="weui-media-box weui-media-box_text">
                    <p class="weui-media-box__desc" style="margin-top:-5px">由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。</p>
                    <h4 class="weui-media-box__title" style="margin-bottom:-10px; margin-top:5px; font-size:small" >B 正确答案</h4>
                </div>
                <div class="weui-media-box weui-media-box_text">
                    <p class="weui-media-box__desc" style="margin-top:-5px">由各种物质组成的巨型球状天体，叫做星球。星球有一定的形状，有自己的运行轨道。</p>
                    <h4 class="weui-media-box__title" style="margin-bottom:-10px; margin-top:5px; font-size:small" >B 正确答案</h4>
                </div>
            </div>
        </div>

    </form>

</body>
</html>
