<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolYw.aspx.cs" Inherits="WxSchool_SchoolYw" %>

<%@ Register Src="~/WxControl/WxFooter.ascx" TagPrefix="uc" TagName="WxFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>书山有路勤为径</title>
    <link rel="stylesheet" href="../WxAcss/myweui.css" />
    <link rel="stylesheet" href="../WxAcss/example.css" />
    <script src="../WxAjs/zepto.min.js"></script>
    <script src="js/schoolyw.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="openid" runat="server" style="display: none" />
        <div id="nickname" runat="server" style="display: none" />
        <div id="courseid" runat="server" style="display: none" />
        <div id="coursename" runat="server" style="display: none" />
        <div id="questype" runat="server" style="display: none" />

        <div id="divtm" class="weui-form-preview">
            <div class="weui-form-preview__hd" style="height: 30px">
                <div class="weui-form-preview__item" style="margin-top: -5px">
                    <label id="lbtit" class="weui-form-preview__label" style="color: chocolate; font-size: 1.4em"></label>
                </div>
            </div>
            <div class="weui-form-preview__ft">
                <a id="lbhcount" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:" style="color: green">本科目共 0 题</a>
                <a id="lbstart" class="weui-form-preview__btn weui-form-preview__btn_default" href="javascript:" style="color: red">开始学习</a>
            </div>
        </div>

        <div id="divcontent" class="weui-form-preview" style="background-image: url(Img/ywtd2.jpg);">
            <div class="weui-grids1">
                <a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=天'>
                    <div class='weui-grid__icon1'>tiān</div>
                    <p class='weui-grid__label1'>天</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=地'>
                    <div class='weui-grid__icon1'>dì</div>
                    <p class='weui-grid__label1'>地</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=人'>
                    <div class='weui-grid__icon1'>rén</div>
                    <p class='weui-grid__label1'>人</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=你'>
                    <div class='weui-grid__icon1'>nǐ</div>
                    <p class='weui-grid__label1'>你</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=我'>
                    <div class='weui-grid__icon1'>wǒ</div>
                    <p class='weui-grid__label1'>我</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=他'>
                    <div class='weui-grid__icon1'>tā</div>
                    <p class='weui-grid__label1'>他</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=一'>
                    <div class='weui-grid__icon1'>yì</div>
                    <p class='weui-grid__label1'>一</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=二'>
                    <div class='weui-grid__icon1'>èr</div>
                    <p class='weui-grid__label1'>二</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=三'>
                    <div class='weui-grid__icon1'>sān</div>
                    <p class='weui-grid__label1'>三</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=四'>
                    <div class='weui-grid__icon1'>sì</div>
                    <p class='weui-grid__label1'>四</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=五'>
                    <div class='weui-grid__icon1'>wǔ</div>
                    <p class='weui-grid__label1'>五</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=上'>
                    <div class='weui-grid__icon1'>shànɡ</div>
                    <p class='weui-grid__label1'>上</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=下'>
                    <div class='weui-grid__icon1'>xià</div>
                    <p class='weui-grid__label1'>下</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=口'>
                    <div class='weui-grid__icon1'>kǒu</div>
                    <p class='weui-grid__label1'>口</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=耳'>
                    <div class='weui-grid__icon1'>ěr</div>
                    <p class='weui-grid__label1'>耳</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=目'>
                    <div class='weui-grid__icon1'>mù</div>
                    <p class='weui-grid__label1'>目</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=手'>
                    <div class='weui-grid__icon1'>shǒu</div>
                    <p class='weui-grid__label1'>手</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=足'>
                    <div class='weui-grid__icon1'>zú</div>
                    <p class='weui-grid__label1'>足</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=站'>
                    <div class='weui-grid__icon1'>zhàn</div>
                    <p class='weui-grid__label1'>站</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=坐'>
                    <div class='weui-grid__icon1'>zuò</div>
                    <p class='weui-grid__label1'>坐</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=日'>
                    <div class='weui-grid__icon1'>rì</div>
                    <p class='weui-grid__label1'>日</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=月'>
                    <div class='weui-grid__icon1'>yuè</div>
                    <p class='weui-grid__label1'>月</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=水'>
                    <div class='weui-grid__icon1'>shuǐ</div>
                    <p class='weui-grid__label1'>水</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=火'>
                    <div class='weui-grid__icon1'>huǒ</div>
                    <p class='weui-grid__label1'>火</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=山'>
                    <div class='weui-grid__icon1'>shān</div>
                    <p class='weui-grid__label1'>山</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=石'>
                    <div class='weui-grid__icon1'>shí</div>
                    <p class='weui-grid__label1'>石</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=田'>
                    <div class='weui-grid__icon1'>tián</div>
                    <p class='weui-grid__label1'>田</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=禾'>
                    <div class='weui-grid__icon1'>hé</div>
                    <p class='weui-grid__label1'>禾</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=对'>
                    <div class='weui-grid__icon1'>duì</div>
                    <p class='weui-grid__label1'>对</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=云'>
                    <div class='weui-grid__icon1'>yún</div>
                    <p class='weui-grid__label1'>云</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=雨'>
                    <div class='weui-grid__icon1'>yǔ</div>
                    <p class='weui-grid__label1'>雨</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=风'>
                    <div class='weui-grid__icon1'>fēnɡ</div>
                    <p class='weui-grid__label1'>风</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=花'>
                    <div class='weui-grid__icon1'>huā</div>
                    <p class='weui-grid__label1'>花</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=鸟'>
                    <div class='weui-grid__icon1'>niǎo</div>
                    <p class='weui-grid__label1'>鸟</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=虫'>
                    <div class='weui-grid__icon1'>chónɡ</div>
                    <p class='weui-grid__label1'>虫</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=六'>
                    <div class='weui-grid__icon1'>liù</div>
                    <p class='weui-grid__label1'>六</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=七'>
                    <div class='weui-grid__icon1'>qī</div>
                    <p class='weui-grid__label1'>七</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=八'>
                    <div class='weui-grid__icon1'>bā</div>
                    <p class='weui-grid__label1'>八</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=九'>
                    <div class='weui-grid__icon1'>jiǔ</div>
                    <p class='weui-grid__label1'>九</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=十'>
                    <div class='weui-grid__icon1'>shí</div>
                    <p class='weui-grid__label1'>十</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=爸'>
                    <div class='weui-grid__icon1'>bà</div>
                    <p class='weui-grid__label1'>爸</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=妈'>
                    <div class='weui-grid__icon1'>mā</div>
                    <p class='weui-grid__label1'>妈</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=棋'>
                    <div class='weui-grid__icon1'>qí</div>
                    <p class='weui-grid__label1'>棋</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=鸡'>
                    <div class='weui-grid__icon1'>jī</div>
                    <p class='weui-grid__label1'>鸡</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=马'>
                    <div class='weui-grid__icon1'>mǎ</div>
                    <p class='weui-grid__label1'>马</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=土'>
                    <div class='weui-grid__icon1'>tǔ</div>
                    <p class='weui-grid__label1'>土</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=不'>
                    <div class='weui-grid__icon1'>bù</div>
                    <p class='weui-grid__label1'>不</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=字'>
                    <div class='weui-grid__icon1'>zì</div>
                    <p class='weui-grid__label1'>字</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=词'>
                    <div class='weui-grid__icon1'>cí</div>
                    <p class='weui-grid__label1'>词</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=语'>
                    <div class='weui-grid__icon1'>yǔ</div>
                    <p class='weui-grid__label1'>语</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=句'>
                    <div class='weui-grid__icon1'>jù</div>
                    <p class='weui-grid__label1'>句</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=子'>
                    <div class='weui-grid__icon1'>zǐ</div>
                    <p class='weui-grid__label1'>子</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=画'>
                    <div class='weui-grid__icon1'>huà</div>
                    <p class='weui-grid__label1'>画</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=打'>
                    <div class='weui-grid__icon1'>dǎ</div>
                    <p class='weui-grid__label1'>打</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=桌'>
                    <div class='weui-grid__icon1'>zhuō</div>
                    <p class='weui-grid__label1'>桌</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=纸'>
                    <div class='weui-grid__icon1'>zhǐ</div>
                    <p class='weui-grid__label1'>纸</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=文'>
                    <div class='weui-grid__icon1'>wén</div>
                    <p class='weui-grid__label1'>文</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=数'>
                    <div class='weui-grid__icon1'>shù</div>
                    <p class='weui-grid__label1'>数</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=学'>
                    <div class='weui-grid__icon1'>xué</div>
                    <p class='weui-grid__label1'>学</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=音'>
                    <div class='weui-grid__icon1'>yīn</div>
                    <p class='weui-grid__label1'>音</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=乐'>
                    <div class='weui-grid__icon1'>yuè</div>
                    <p class='weui-grid__label1'>乐</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=妹'>
                    <div class='weui-grid__icon1'>mèi</div>
                    <p class='weui-grid__label1'>妹</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=奶'>
                    <div class='weui-grid__icon1'>nǎi</div>
                    <p class='weui-grid__label1'>奶</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=白'>
                    <div class='weui-grid__icon1'>bái</div>
                    <p class='weui-grid__label1'>白</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=皮'>
                    <div class='weui-grid__icon1'>pí</div>
                    <p class='weui-grid__label1'>皮</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=草'>
                    <div class='weui-grid__icon1'>cǎo</div>
                    <p class='weui-grid__label1'>草</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=家'>
                    <div class='weui-grid__icon1'>jiā</div>
                    <p class='weui-grid__label1'>家</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=是'>
                    <div class='weui-grid__icon1'>shì</div>
                    <p class='weui-grid__label1'>是</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=小'>
                    <div class='weui-grid__icon1'>xiǎo</div>
                    <p class='weui-grid__label1'>小</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=桥'>
                    <div class='weui-grid__icon1'>qiáo</div>
                    <p class='weui-grid__label1'>桥</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=台'>
                    <div class='weui-grid__icon1'>tái</div>
                    <p class='weui-grid__label1'>台</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=车'>
                    <div class='weui-grid__icon1'>chē</div>
                    <p class='weui-grid__label1'>车</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=羊'>
                    <div class='weui-grid__icon1'>yánɡ</div>
                    <p class='weui-grid__label1'>羊</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=走'>
                    <div class='weui-grid__icon1'>zǒu</div>
                    <p class='weui-grid__label1'>走</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=也'>
                    <div class='weui-grid__icon1'>yě</div>
                    <p class='weui-grid__label1'>也</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=雪'>
                    <div class='weui-grid__icon1'>xuě</div>
                    <p class='weui-grid__label1'>雪</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=儿'>
                    <div class='weui-grid__icon1'>ér</div>
                    <p class='weui-grid__label1'>儿</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=秋'>
                    <div class='weui-grid__icon1'>qiū</div>
                    <p class='weui-grid__label1'>秋</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=气'>
                    <div class='weui-grid__icon1'>qì</div>
                    <p class='weui-grid__label1'>气</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=了'>
                    <div class='weui-grid__icon1'>le</div>
                    <p class='weui-grid__label1'>了</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=树'>
                    <div class='weui-grid__icon1'>shù</div>
                    <p class='weui-grid__label1'>树</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=叶'>
                    <div class='weui-grid__icon1'>yè</div>
                    <p class='weui-grid__label1'>叶</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=片'>
                    <div class='weui-grid__icon1'>piàn</div>
                    <p class='weui-grid__label1'>片</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=大'>
                    <div class='weui-grid__icon1'>dà</div>
                    <p class='weui-grid__label1'>大</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=飞'>
                    <div class='weui-grid__icon1'>fēi</div>
                    <p class='weui-grid__label1'>飞</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=会'>
                    <div class='weui-grid__icon1'>huì</div>
                    <p class='weui-grid__label1'>会</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=个'>
                    <div class='weui-grid__icon1'>ɡè</div>
                    <p class='weui-grid__label1'>个</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=的'>
                    <div class='weui-grid__icon1'>de</div>
                    <p class='weui-grid__label1'>的</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=船'>
                    <div class='weui-grid__icon1'>chuán</div>
                    <p class='weui-grid__label1'>船</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=两'>
                    <div class='weui-grid__icon1'>liǎnɡ</div>
                    <p class='weui-grid__label1'>两</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=头'>
                    <div class='weui-grid__icon1'>tóu</div>
                    <p class='weui-grid__label1'>头</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=在'>
                    <div class='weui-grid__icon1'>zài</div>
                    <p class='weui-grid__label1'>在</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=里'>
                    <div class='weui-grid__icon1'>lǐ</div>
                    <p class='weui-grid__label1'>里</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=看'>
                    <div class='weui-grid__icon1'>kàn</div>
                    <p class='weui-grid__label1'>看</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=见'>
                    <div class='weui-grid__icon1'>jiàn</div>
                    <p class='weui-grid__label1'>见</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=闪'>
                    <div class='weui-grid__icon1'>shǎn</div>
                    <p class='weui-grid__label1'>闪</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=星'>
                    <div class='weui-grid__icon1'>xīnɡ</div>
                    <p class='weui-grid__label1'>星</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=江'>
                    <div class='weui-grid__icon1'>jiānɡ</div>
                    <p class='weui-grid__label1'>江</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=南'>
                    <div class='weui-grid__icon1'>nán</div>
                    <p class='weui-grid__label1'>南</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=可'>
                    <div class='weui-grid__icon1'>kě</div>
                    <p class='weui-grid__label1'>可</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=采'>
                    <div class='weui-grid__icon1'>cǎi</div>
                    <p class='weui-grid__label1'>采</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=莲'>
                    <div class='weui-grid__icon1'>lián</div>
                    <p class='weui-grid__label1'>莲</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=鱼'>
                    <div class='weui-grid__icon1'>yú</div>
                    <p class='weui-grid__label1'>鱼</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=东'>
                    <div class='weui-grid__icon1'>dōnɡ</div>
                    <p class='weui-grid__label1'>东</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=西'>
                    <div class='weui-grid__icon1'>xī</div>
                    <p class='weui-grid__label1'>西</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=北'>
                    <div class='weui-grid__icon1'>běi</div>
                    <p class='weui-grid__label1'>北</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=尖'>
                    <div class='weui-grid__icon1'>jiān</div>
                    <p class='weui-grid__label1'>尖</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=说'>
                    <div class='weui-grid__icon1'>shuō</div>
                    <p class='weui-grid__label1'>说</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=春'>
                    <div class='weui-grid__icon1'>chūn</div>
                    <p class='weui-grid__label1'>春</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=青'>
                    <div class='weui-grid__icon1'>qīnɡ</div>
                    <p class='weui-grid__label1'>青</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=蛙'>
                    <div class='weui-grid__icon1'>wā</div>
                    <p class='weui-grid__label1'>蛙</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=夏'>
                    <div class='weui-grid__icon1'>xià</div>
                    <p class='weui-grid__label1'>夏</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=弯'>
                    <div class='weui-grid__icon1'>wān</div>
                    <p class='weui-grid__label1'>弯</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=就'>
                    <div class='weui-grid__icon1'>jiù</div>
                    <p class='weui-grid__label1'>就</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=冬'>
                    <div class='weui-grid__icon1'>dōnɡ</div>
                    <p class='weui-grid__label1'>冬</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=男'>
                    <div class='weui-grid__icon1'>nán</div>
                    <p class='weui-grid__label1'>男</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=女'>
                    <div class='weui-grid__icon1'>nǚ</div>
                    <p class='weui-grid__label1'>女</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=开'>
                    <div class='weui-grid__icon1'>kāi</div>
                    <p class='weui-grid__label1'>开</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=关'>
                    <div class='weui-grid__icon1'>ɡuān</div>
                    <p class='weui-grid__label1'>关</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=正'>
                    <div class='weui-grid__icon1'>zhènɡ</div>
                    <p class='weui-grid__label1'>正</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=反'>
                    <div class='weui-grid__icon1'>fǎn</div>
                    <p class='weui-grid__label1'>反</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=远'>
                    <div class='weui-grid__icon1'>yuǎn</div>
                    <p class='weui-grid__label1'>远</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=有'>
                    <div class='weui-grid__icon1'>yǒu</div>
                    <p class='weui-grid__label1'>有</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=色'>
                    <div class='weui-grid__icon1'>sè</div>
                    <p class='weui-grid__label1'>色</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=近'>
                    <div class='weui-grid__icon1'>jìn</div>
                    <p class='weui-grid__label1'>近</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=听'>
                    <div class='weui-grid__icon1'>tīnɡ</div>
                    <p class='weui-grid__label1'>听</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=无'>
                    <div class='weui-grid__icon1'>wú</div>
                    <p class='weui-grid__label1'>无</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=声'>
                    <div class='weui-grid__icon1'>shēnɡ</div>
                    <p class='weui-grid__label1'>声</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=去'>
                    <div class='weui-grid__icon1'>qù</div>
                    <p class='weui-grid__label1'>去</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=还'>
                    <div class='weui-grid__icon1'>hái</div>
                    <p class='weui-grid__label1'>还</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=来'>
                    <div class='weui-grid__icon1'>lái</div>
                    <p class='weui-grid__label1'>来</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=多'>
                    <div class='weui-grid__icon1'>duō</div>
                    <p class='weui-grid__label1'>多</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=少'>
                    <div class='weui-grid__icon1'>shǎo</div>
                    <p class='weui-grid__label1'>少</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=黄'>
                    <div class='weui-grid__icon1'>huánɡ</div>
                    <p class='weui-grid__label1'>黄</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=牛'>
                    <div class='weui-grid__icon1'>niú</div>
                    <p class='weui-grid__label1'>牛</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=只'>
                    <div class='weui-grid__icon1'>zhǐ</div>
                    <p class='weui-grid__label1'>只</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=猫'>
                    <div class='weui-grid__icon1'>māo</div>
                    <p class='weui-grid__label1'>猫</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=边'>
                    <div class='weui-grid__icon1'>biān</div>
                    <p class='weui-grid__label1'>边</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=鸭'>
                    <div class='weui-grid__icon1'>yā</div>
                    <p class='weui-grid__label1'>鸭</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=苹'>
                    <div class='weui-grid__icon1'>pínɡ</div>
                    <p class='weui-grid__label1'>苹</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=果'>
                    <div class='weui-grid__icon1'>ɡuǒ</div>
                    <p class='weui-grid__label1'>果</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=杏'>
                    <div class='weui-grid__icon1'>xìnɡ</div>
                    <p class='weui-grid__label1'>杏</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=桃'>
                    <div class='weui-grid__icon1'>táo</div>
                    <p class='weui-grid__label1'>桃</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=书'>
                    <div class='weui-grid__icon1'>shū</div>
                    <p class='weui-grid__label1'>书</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=包'>
                    <div class='weui-grid__icon1'>bāo</div>
                    <p class='weui-grid__label1'>包</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=尺'>
                    <div class='weui-grid__icon1'>chǐ</div>
                    <p class='weui-grid__label1'>尺</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=作'>
                    <div class='weui-grid__icon1'>zuò</div>
                    <p class='weui-grid__label1'>作</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=业'>
                    <div class='weui-grid__icon1'>yè</div>
                    <p class='weui-grid__label1'>业</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=本'>
                    <div class='weui-grid__icon1'>běn</div>
                    <p class='weui-grid__label1'>本</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=笔'>
                    <div class='weui-grid__icon1'>bǐ</div>
                    <p class='weui-grid__label1'>笔</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=刀'>
                    <div class='weui-grid__icon1'>dāo</div>
                    <p class='weui-grid__label1'>刀</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=课'>
                    <div class='weui-grid__icon1'>kè</div>
                    <p class='weui-grid__label1'>课</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=早'>
                    <div class='weui-grid__icon1'>zǎo</div>
                    <p class='weui-grid__label1'>早</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=校'>
                    <div class='weui-grid__icon1'>xiào</div>
                    <p class='weui-grid__label1'>校</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=明'>
                    <div class='weui-grid__icon1'>mínɡ</div>
                    <p class='weui-grid__label1'>明</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=力'>
                    <div class='weui-grid__icon1'>lì</div>
                    <p class='weui-grid__label1'>力</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=尘'>
                    <div class='weui-grid__icon1'>chén</div>
                    <p class='weui-grid__label1'>尘</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=从'>
                    <div class='weui-grid__icon1'>cónɡ</div>
                    <p class='weui-grid__label1'>从</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=众'>
                    <div class='weui-grid__icon1'>zhònɡ</div>
                    <p class='weui-grid__label1'>众</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=双'>
                    <div class='weui-grid__icon1'>shuānɡ</div>
                    <p class='weui-grid__label1'>双</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=木'>
                    <div class='weui-grid__icon1'>mù</div>
                    <p class='weui-grid__label1'>木</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=林'>
                    <div class='weui-grid__icon1'>lín</div>
                    <p class='weui-grid__label1'>林</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=森'>
                    <div class='weui-grid__icon1'>sēn</div>
                    <p class='weui-grid__label1'>森</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=条'>
                    <div class='weui-grid__icon1'>tiáo</div>
                    <p class='weui-grid__label1'>条</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=心'>
                    <div class='weui-grid__icon1'>xīn</div>
                    <p class='weui-grid__label1'>心</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=升'>
                    <div class='weui-grid__icon1'>shēnɡ</div>
                    <p class='weui-grid__label1'>升</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=国'>
                    <div class='weui-grid__icon1'>ɡuó</div>
                    <p class='weui-grid__label1'>国</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=旗'>
                    <div class='weui-grid__icon1'>qí</div>
                    <p class='weui-grid__label1'>旗</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=中'>
                    <div class='weui-grid__icon1'>zhōnɡ</div>
                    <p class='weui-grid__label1'>中</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=红'>
                    <div class='weui-grid__icon1'>hónɡ</div>
                    <p class='weui-grid__label1'>红</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=歌'>
                    <div class='weui-grid__icon1'>ɡē</div>
                    <p class='weui-grid__label1'>歌</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=起'>
                    <div class='weui-grid__icon1'>qǐ</div>
                    <p class='weui-grid__label1'>起</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=么'>
                    <div class='weui-grid__icon1'>me</div>
                    <p class='weui-grid__label1'>么</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=美'>
                    <div class='weui-grid__icon1'>měi</div>
                    <p class='weui-grid__label1'>美</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=丽'>
                    <div class='weui-grid__icon1'>lì</div>
                    <p class='weui-grid__label1'>丽</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=立'>
                    <div class='weui-grid__icon1'>lì</div>
                    <p class='weui-grid__label1'>立</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=午'>
                    <div class='weui-grid__icon1'>wǔ</div>
                    <p class='weui-grid__label1'>午</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=晚'>
                    <div class='weui-grid__icon1'>wǎn</div>
                    <p class='weui-grid__label1'>晚</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=昨'>
                    <div class='weui-grid__icon1'>zuó</div>
                    <p class='weui-grid__label1'>昨</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=今'>
                    <div class='weui-grid__icon1'>jīn</div>
                    <p class='weui-grid__label1'>今</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=年'>
                    <div class='weui-grid__icon1'>nián</div>
                    <p class='weui-grid__label1'>年</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=影'>
                    <div class='weui-grid__icon1'>yǐnɡ</div>
                    <p class='weui-grid__label1'>影</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=前'>
                    <div class='weui-grid__icon1'>qián</div>
                    <p class='weui-grid__label1'>前</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=后'>
                    <div class='weui-grid__icon1'>hòu</div>
                    <p class='weui-grid__label1'>后</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=黑'>
                    <div class='weui-grid__icon1'>hēi</div>
                    <p class='weui-grid__label1'>黑</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=狗'>
                    <div class='weui-grid__icon1'>ɡǒu</div>
                    <p class='weui-grid__label1'>狗</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=左'>
                    <div class='weui-grid__icon1'>zuǒ</div>
                    <p class='weui-grid__label1'>左</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=右'>
                    <div class='weui-grid__icon1'>yòu</div>
                    <p class='weui-grid__label1'>右</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=它'>
                    <div class='weui-grid__icon1'>tā</div>
                    <p class='weui-grid__label1'>它</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=好'>
                    <div class='weui-grid__icon1'>hǎo</div>
                    <p class='weui-grid__label1'>好</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=朋'>
                    <div class='weui-grid__icon1'>pénɡ</div>
                    <p class='weui-grid__label1'>朋</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=友'>
                    <div class='weui-grid__icon1'>yǒu</div>
                    <p class='weui-grid__label1'>友</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=比'>
                    <div class='weui-grid__icon1'>bǐ</div>
                    <p class='weui-grid__label1'>比</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=尾'>
                    <div class='weui-grid__icon1'>wěi</div>
                    <p class='weui-grid__label1'>尾</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=巴'>
                    <div class='weui-grid__icon1'>bā</div>
                    <p class='weui-grid__label1'>巴</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=谁'>
                    <div class='weui-grid__icon1'>shuí</div>
                    <p class='weui-grid__label1'>谁</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=长'>
                    <div class='weui-grid__icon1'>chánɡ</div>
                    <p class='weui-grid__label1'>长</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=短'>
                    <div class='weui-grid__icon1'>duǎn</div>
                    <p class='weui-grid__label1'>短</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=伞'>
                    <div class='weui-grid__icon1'>sǎn</div>
                    <p class='weui-grid__label1'>伞</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=兔'>
                    <div class='weui-grid__icon1'>tù</div>
                    <p class='weui-grid__label1'>兔</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=最'>
                    <div class='weui-grid__icon1'>zuì</div>
                    <p class='weui-grid__label1'>最</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=公'>
                    <div class='weui-grid__icon1'>ɡōnɡ</div>
                    <p class='weui-grid__label1'>公</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=写'>
                    <div class='weui-grid__icon1'>xiě</div>
                    <p class='weui-grid__label1'>写</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=诗'>
                    <div class='weui-grid__icon1'>shī</div>
                    <p class='weui-grid__label1'>诗</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=点'>
                    <div class='weui-grid__icon1'>diǎn</div>
                    <p class='weui-grid__label1'>点</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=要'>
                    <div class='weui-grid__icon1'>yào</div>
                    <p class='weui-grid__label1'>要</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=过'>
                    <div class='weui-grid__icon1'>ɡuò</div>
                    <p class='weui-grid__label1'>过</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=给'>
                    <div class='weui-grid__icon1'>ɡěi</div>
                    <p class='weui-grid__label1'>给</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=当'>
                    <div class='weui-grid__icon1'>dānɡ</div>
                    <p class='weui-grid__label1'>当</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=串'>
                    <div class='weui-grid__icon1'>chuàn</div>
                    <p class='weui-grid__label1'>串</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=们'>
                    <div class='weui-grid__icon1'>men</div>
                    <p class='weui-grid__label1'>们</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=以'>
                    <div class='weui-grid__icon1'>yǐ</div>
                    <p class='weui-grid__label1'>以</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=成'>
                    <div class='weui-grid__icon1'>chénɡ</div>
                    <p class='weui-grid__label1'>成</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=彩'>
                    <div class='weui-grid__icon1'>cǎi</div>
                    <p class='weui-grid__label1'>彩</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=半'>
                    <div class='weui-grid__icon1'>bàn</div>
                    <p class='weui-grid__label1'>半</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=空'>
                    <div class='weui-grid__icon1'>kōnɡ</div>
                    <p class='weui-grid__label1'>空</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=问'>
                    <div class='weui-grid__icon1'>wèn</div>
                    <p class='weui-grid__label1'>问</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=到'>
                    <div class='weui-grid__icon1'>dào</div>
                    <p class='weui-grid__label1'>到</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=方'>
                    <div class='weui-grid__icon1'>fānɡ</div>
                    <p class='weui-grid__label1'>方</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=没'>
                    <div class='weui-grid__icon1'>méi</div>
                    <p class='weui-grid__label1'>没</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=更'>
                    <div class='weui-grid__icon1'>ɡènɡ</div>
                    <p class='weui-grid__label1'>更</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=绿'>
                    <div class='weui-grid__icon1'>lǜ</div>
                    <p class='weui-grid__label1'>绿</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=出'>
                    <div class='weui-grid__icon1'>chū</div>
                    <p class='weui-grid__label1'>出</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=睡'>
                    <div class='weui-grid__icon1'>shuì</div>
                    <p class='weui-grid__label1'>睡</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=那'>
                    <div class='weui-grid__icon1'>nà</div>
                    <p class='weui-grid__label1'>那</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=海'>
                    <div class='weui-grid__icon1'>hǎi</div>
                    <p class='weui-grid__label1'>海</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=真'>
                    <div class='weui-grid__icon1'>zhēn</div>
                    <p class='weui-grid__label1'>真</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=老'>
                    <div class='weui-grid__icon1'>lǎo</div>
                    <p class='weui-grid__label1'>老</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=师'>
                    <div class='weui-grid__icon1'>shī</div>
                    <p class='weui-grid__label1'>师</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=吗'>
                    <div class='weui-grid__icon1'>mɑ</div>
                    <p class='weui-grid__label1'>吗</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=同'>
                    <div class='weui-grid__icon1'>tónɡ</div>
                    <p class='weui-grid__label1'>同</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=什'>
                    <div class='weui-grid__icon1'>shén</div>
                    <p class='weui-grid__label1'>什</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=才'>
                    <div class='weui-grid__icon1'>cái</div>
                    <p class='weui-grid__label1'>才</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=亮'>
                    <div class='weui-grid__icon1'>liànɡ</div>
                    <p class='weui-grid__label1'>亮</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=时'>
                    <div class='weui-grid__icon1'>shí</div>
                    <p class='weui-grid__label1'>时</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=候'>
                    <div class='weui-grid__icon1'>hòu</div>
                    <p class='weui-grid__label1'>候</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=觉'>
                    <div class='weui-grid__icon1'>jué</div>
                    <p class='weui-grid__label1'>觉</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=得'>
                    <div class='weui-grid__icon1'>de</div>
                    <p class='weui-grid__label1'>得</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=自'>
                    <div class='weui-grid__icon1'>zì</div>
                    <p class='weui-grid__label1'>自</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=己'>
                    <div class='weui-grid__icon1'>jǐ</div>
                    <p class='weui-grid__label1'>己</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=很'>
                    <div class='weui-grid__icon1'>hěn</div>
                    <p class='weui-grid__label1'>很</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=穿'>
                    <div class='weui-grid__icon1'>chuān</div>
                    <p class='weui-grid__label1'>穿</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=衣'>
                    <div class='weui-grid__icon1'>yī</div>
                    <p class='weui-grid__label1'>衣</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=服'>
                    <div class='weui-grid__icon1'>fú</div>
                    <p class='weui-grid__label1'>服</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=快'>
                    <div class='weui-grid__icon1'>kuài</div>
                    <p class='weui-grid__label1'>快</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=蓝'>
                    <div class='weui-grid__icon1'>lán</div>
                    <p class='weui-grid__label1'>蓝</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=又'>
                    <div class='weui-grid__icon1'>yòu</div>
                    <p class='weui-grid__label1'>又</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=笑'>
                    <div class='weui-grid__icon1'>xiào</div>
                    <p class='weui-grid__label1'>笑</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=着'>
                    <div class='weui-grid__icon1'>zhe</div>
                    <p class='weui-grid__label1'>着</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=向'>
                    <div class='weui-grid__icon1'>xiànɡ</div>
                    <p class='weui-grid__label1'>向</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=和'>
                    <div class='weui-grid__icon1'>hé</div>
                    <p class='weui-grid__label1'>和</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=贝'>
                    <div class='weui-grid__icon1'>bèi</div>
                    <p class='weui-grid__label1'>贝</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=娃'>
                    <div class='weui-grid__icon1'>wá</div>
                    <p class='weui-grid__label1'>娃</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=挂'>
                    <div class='weui-grid__icon1'>ɡuà</div>
                    <p class='weui-grid__label1'>挂</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=活'>
                    <div class='weui-grid__icon1'>huó</div>
                    <p class='weui-grid__label1'>活</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=金'>
                    <div class='weui-grid__icon1'>jīn</div>
                    <p class='weui-grid__label1'>金</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=哥'>
                    <div class='weui-grid__icon1'>ɡē</div>
                    <p class='weui-grid__label1'>哥</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=姐'>
                    <div class='weui-grid__icon1'>jiě</div>
                    <p class='weui-grid__label1'>姐</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=弟'>
                    <div class='weui-grid__icon1'>dì</div>
                    <p class='weui-grid__label1'>弟</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=叔'>
                    <div class='weui-grid__icon1'>shū</div>
                    <p class='weui-grid__label1'>叔</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=爷'>
                    <div class='weui-grid__icon1'>yé</div>
                    <p class='weui-grid__label1'>爷</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=群'>
                    <div class='weui-grid__icon1'>qún</div>
                    <p class='weui-grid__label1'>群</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=竹'>
                    <div class='weui-grid__icon1'>zhú</div>
                    <p class='weui-grid__label1'>竹</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=牙'>
                    <div class='weui-grid__icon1'>yá</div>
                    <p class='weui-grid__label1'>牙</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=用'>
                    <div class='weui-grid__icon1'>yònɡ</div>
                    <p class='weui-grid__label1'>用</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=几'>
                    <div class='weui-grid__icon1'>jǐ</div>
                    <p class='weui-grid__label1'>几</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=步'>
                    <div class='weui-grid__icon1'>bù</div>
                    <p class='weui-grid__label1'>步</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=为'>
                    <div class='weui-grid__icon1'>wéi</div>
                    <p class='weui-grid__label1'>为</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=参'>
                    <div class='weui-grid__icon1'>cān</div>
                    <p class='weui-grid__label1'>参</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=加'>
                    <div class='weui-grid__icon1'>jiā</div>
                    <p class='weui-grid__label1'>加</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=洞'>
                    <div class='weui-grid__icon1'>dònɡ</div>
                    <p class='weui-grid__label1'>洞</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=乌'>
                    <div class='weui-grid__icon1'>wū</div>
                    <p class='weui-grid__label1'>乌</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=鸦'>
                    <div class='weui-grid__icon1'>yā</div>
                    <p class='weui-grid__label1'>鸦</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=处'>
                    <div class='weui-grid__icon1'>chù</div>
                    <p class='weui-grid__label1'>处</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=找'>
                    <div class='weui-grid__icon1'>zhǎo</div>
                    <p class='weui-grid__label1'>找</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=办'>
                    <div class='weui-grid__icon1'>bàn</div>
                    <p class='weui-grid__label1'>办</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=旁'>
                    <div class='weui-grid__icon1'>pánɡ</div>
                    <p class='weui-grid__label1'>旁</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=许'>
                    <div class='weui-grid__icon1'>xǔ</div>
                    <p class='weui-grid__label1'>许</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=法'>
                    <div class='weui-grid__icon1'>fǎ</div>
                    <p class='weui-grid__label1'>法</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=放'>
                    <div class='weui-grid__icon1'>fànɡ</div>
                    <p class='weui-grid__label1'>放</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=进'>
                    <div class='weui-grid__icon1'>jìn</div>
                    <p class='weui-grid__label1'>进</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=高'>
                    <div class='weui-grid__icon1'>ɡāo</div>
                    <p class='weui-grid__label1'>高</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=住'>
                    <div class='weui-grid__icon1'>zhù</div>
                    <p class='weui-grid__label1'>住</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=孩'>
                    <div class='weui-grid__icon1'>hái</div>
                    <p class='weui-grid__label1'>孩</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=玩'>
                    <div class='weui-grid__icon1'>wán</div>
                    <p class='weui-grid__label1'>玩</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=吧'>
                    <div class='weui-grid__icon1'>bɑ</div>
                    <p class='weui-grid__label1'>吧</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=发'>
                    <div class='weui-grid__icon1'>fā</div>
                    <p class='weui-grid__label1'>发</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=芽'>
                    <div class='weui-grid__icon1'>yá</div>
                    <p class='weui-grid__label1'>芽</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=爬'>
                    <div class='weui-grid__icon1'>pá</div>
                    <p class='weui-grid__label1'>爬</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=呀'>
                    <div class='weui-grid__icon1'>yɑ</div>
                    <p class='weui-grid__label1'>呀</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=久'>
                    <div class='weui-grid__icon1'>jiǔ</div>
                    <p class='weui-grid__label1'>久</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=回'>
                    <div class='weui-grid__icon1'>huí</div>
                    <p class='weui-grid__label1'>回</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=全'>
                    <div class='weui-grid__icon1'>quán</div>
                    <p class='weui-grid__label1'>全</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=变'>
                    <div class='weui-grid__icon1'>biàn</div>
                    <p class='weui-grid__label1'>变</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=工'>
                    <div class='weui-grid__icon1'>ɡōnɡ</div>
                    <p class='weui-grid__label1'>工</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=厂'>
                    <div class='weui-grid__icon1'>chǎnɡ</div>
                    <p class='weui-grid__label1'>厂</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=医'>
                    <div class='weui-grid__icon1'>yī</div>
                    <p class='weui-grid__label1'>医</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=院'>
                    <div class='weui-grid__icon1'>yuàn</div>
                    <p class='weui-grid__label1'>院</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=生'>
                    <div class='weui-grid__icon1'>shēnɡ</div>
                    <p class='weui-grid__label1'>生</p>
                </a><a class='weui-grid1' href='SchoolYwSearch.aspx?OpenID=null&NickName=null&Filter=把'>
                    <div class='weui-grid__icon1'>bǎ</div>
                    <p class='weui-grid__label1'>把</p>
                </a>
            </div>
        </div>

        <uc:WxFooter runat="server" />
    </form>
</body>
</html>
