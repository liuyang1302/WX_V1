<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolYwSearch.aspx.cs" Inherits="WxSchool_SchoolYwSearch" %>
<%@ Register Src="~/WxControl/WxFooter.ascx" TagPrefix="uc" TagName="WxFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0" />
    <title>书山有路勤为径</title>
    <link href="../WxAcss/baidu_main.css" rel="stylesheet" />
    <link href="../WxAcss/baidu_style.css" rel="stylesheet" type="text/css" />
    <script src="../WxAjs/zepto.min.js"></script>
    <script src="js/schoolywsearch.js"></script>
</head>
<body>
    <div id="openid" runat="server" style="display: none" />
    <div id="nickname" runat="server" style="display: none" />
    <div id="filter" runat="server" style="display: none" />
    
    <div class="search-box module" id="search-box">
        <span class="bg s_ipt_wr quickdelete-wrap">
            <input name="wd" class="s_ipt" id="kw" maxlength="40" placeholder="请输入要查询的词语、成语、诗词" autocomplete="off" />
        </span>
        <span class="bg s_btn_wr focus">
            <input class="bg s_btn" id="su" type="submit" value="查询" />
        </span>
        <audio id="_audio" style="display: none" />
    </div>
    <div id="divsearch">
        <div id="body-wrapper">
            <div class="module" id="main">
                <div class="left nav-list module" id="nav-list"></div>
                <div class="content-panel module" id="content-panel">
                    <div id="qa-tip" style="display: none;"></div>
                    <div class="tab-list module" id="word-body" data-prop="">
                        <!-- 头部 -->
                        <div class="header-info" id="word-header">
                            <div id="header-img">
                                <div class="alter-text" style='background-image: url("https://ss2.baidu.com/6ONYsjip0QIZ8tyhnq/it/u=4114940837,1286654062&amp;fm=58");'>
                                    <%--<img class="bishun" id="word_bishun" src="Img/video-stroke.png" data-gif="http://appcdn.fanyi.baidu.com/zhdict/gif/b1b688e17672c4840af205beaa5f4e6db.gif">--%>
                                    <img class="bishun_play" id="word_bishun" src="http://appcdn.fanyi.baidu.com/zhdict/gif/b1b688e17672c4840af205beaa5f4e6db.gif">
                                </div>
                            </div>
                            <div id="header-detail">
                                <ul id="header-list">
                                    <li id="tone_py">
                                        <label>拼 音</label>
                                        <span>
                                            <div class="pronounce" id="pinyin">
                                                <span>
                                                    <b>sǎn</b>
                                                    <a class="mp3-play" url="http://appcdn.fanyi.baidu.com/zhdict/mp3/san3.mp3" herf="#">&nbsp;</a>
                                                </span>
                                            </div>
                                        </span>
                                    </li>
                                    <li id="radical">
                                        <label>部 首</label>
                                        <span>人</span>
                                    </li>
                                    <li id="stroke_count">
                                        <label>笔 画</label>
                                        <span>6</span>
                                    </li>
                                    <li id="wuxing">
                                        <label>五 行</label>
                                        <span>金</span>
                                    </li>
                                    <li id="traditional">
                                        <label>繁 体</label>
                                        <span>傘</span>
                                    </li>
                                    <li id="wubi">
                                        <label>五 笔</label>
                                        <span>WUHJ</span>
                                    </li>
                                </ul>
                            </div>
                            <a title="生词本" id="wordbook" href="javascript:void" data-name="">生词本</a>
                            <script>window.basicInfo = { "name": "\u4f1e", "type": "word", "radical": null, "strokes": "6", "definition": "s\u01cen#san3#1.\u6321\u96e8\u6216\u906e\u592a\u9633\u7684\u7528\u5177\uff0c\u7528\u6cb9\u7eb8\u3001\u5e03\u3001\u5851\u6599\u7b49\u5236\u6210\uff0c\u4e2d\u95f4\u6709\u67c4\uff0c\u53ef\u4ee5\u5f20\u5408\uff1a\u4e00\u628a\uff5e\u3002\u65f1\uff5e\u3002\u96e8\uff5e\u3002\\n2.\u5f62\u72b6\u50cf\u4f1e\u7684\u4e1c\u897f\uff1a\u964d\u843d\uff5e\u3002\u706f\uff5e\u3002\\n3.\u59d3\u3002" };</script>
                        </div>
                        <!-- 解释 -->
                        <!-- 解释 -->
                        <div class="content means imeans" id="basicmean-wrapper" data-group="imeans">
                            <h1>
                                <b class="title active" id="basicmean" data-group="imeans">基本释义</b><span class="seg"></span>
                            </h1>
                            <div class="tab-content">
                                <dl>
                                    <dd>
                                        <p>1.挡雨或遮太阳的用具，用油纸、布、塑料等制成，中间有柄，可以张合<span>：一把～。旱～。雨～。</span></p>
                                        <p>2.形状像伞的东西<span>：降落～。灯～。</span></p>
                                        <p>3.姓。</p>
                                    </dd>
                                </dl>
                            </div>
                            <div class="more-button">
                                <a class="f" href="javascript:void(0);" data-for="basicmean"><b>︾</b>查看更多</a>
                                <a class="e" href="javascript:void(0);"
                                    data-for="basicmean"><b>︽</b>收起更多</a>
                            </div>
                        </div>
                        <!-- 解释 -->
                        <!-- 表格解释 -->
                        <!-- 组词 -->
                        <div class="content link-terms" id="zuci-wrapper">
                            <h1><b class="title" id="related_term">相关组词</b></h1>
                            <div class="tab-content">
                                <a href="https://hanyu.baidu.com/s?wd=雨伞&amp;cf=zuci&amp;ptype=term">雨伞</a>
                                <a href="https://hanyu.baidu.com/s?wd=伞兵&amp;cf=zuci&amp;ptype=term">伞兵</a>
                                <a href="https://hanyu.baidu.com/s?wd=灯伞&amp;cf=zuci&amp;ptype=term">灯伞</a>
                                <a href="https://hanyu.baidu.com/s?wd=跳伞&amp;cf=zuci&amp;ptype=term">跳伞</a>
                                <a href="https://hanyu.baidu.com/s?wd=阳伞&amp;cf=zuci&amp;ptype=term">阳伞</a>
                                <a href="https://hanyu.baidu.com/s?wd=旱伞&amp;cf=zuci&amp;ptype=term">旱伞</a>
                                <a href="https://hanyu.baidu.com/s?wd=撑伞&amp;cf=zuci&amp;ptype=term">撑伞</a>
                                <a href="https://hanyu.baidu.com/s?wd=方伞&amp;cf=zuci&amp;ptype=term">方伞</a>
                                <a href="https://hanyu.baidu.com/s?wd=扇伞&amp;cf=zuci&amp;ptype=term">扇伞</a>
                                <a href="https://hanyu.baidu.com/s?wd=伞头&amp;cf=zuci&amp;ptype=term">伞头</a>
                                <a href="https://hanyu.baidu.com/s?wd=佛伞&amp;cf=zuci&amp;ptype=term">佛伞</a>
                                <a href="https://hanyu.baidu.com/s?wd=伞檐&amp;cf=zuci&amp;ptype=term">伞檐</a>
                                <a href="https://hanyu.baidu.com/s?wd=金伞&amp;cf=zuci&amp;ptype=term">金伞</a>
                                <a href="https://hanyu.baidu.com/s?wd=火伞&amp;cf=zuci&amp;ptype=term">火伞</a>
                                <a href="https://hanyu.baidu.com/s?wd=伞组词&amp;cf=zuci&amp;ptype=term">更多</a>
                            </div>
                        </div>
                        <!-- 近义词部分 -->
                        <!-- 近反义词 -->
                        <!-- 相关谜语部分 -->
                        <!-- 百科解释部分 -->
                        <div class="content" id="baike-wrapper">
                            <div style="position: relative;">
                                <h1><b class="title" id="baike">百科释义</b></h1>
                                <span class="baike-feedback" style="top: 5px; right: 10px; color: rgb(153, 153, 153); position: absolute; cursor: pointer;"
                                    data="伞">报错</span>
                            </div>
                            <div class="tab-content">
                                <p>
                                    伞是一种提供阴凉环境或遮蔽雨、雪的工具。中国是世界上最早发明雨伞的国家，伞是中国劳动人民一个重要的创造。
                                当时被人们称之为“簦”。上至皇帝出行的黄色罗伞，下至百姓的避雨工具，可以说伞与人们的生活息息相关。受中国文化影响，亚洲许多国家很早就有使用伞的传统，而欧洲至16世纪才开始风靡中国伞。伞的制作材料通常包括了具延展性的布料，和其它可用作骨架的材料与缠线。使用时以手将之举起，虽然伞在最初发明时的主要目的，是用来阻挡阳光，但是现在最常被当作雨天挡雨的雨具。用来遮蔽阳光的伞又称作阳伞或遮阳伞，可固定于露台桌等户外家具，或用在海滩上。伞的其它用途包括装饰物、拐杖甚至兵器。从价值角度分为实用伞和工艺伞。...
                                <a href="http://baike.baidu.com/subview/41959/10635303.htm?forcehttps=1?fr=kg_hanyu"
                                    target="baike">查看百科</a>
                                </p>
                            </div>
                            <div class="tab-content"
                                style="color: rgb(208, 208, 208); text-indent: 0px;">
                                注：百科释义来自于百度百科，由网友自行编辑。
                            </div>
                        </div>
                        <!-- 百度翻译部分 -->

                        <div class="mark" id="fanyi_means"></div>
                        <div class="content" id="fanyi-wrapper">
                            <h1><b class="title" id="fanyi">英文翻译</b></h1>
                            <div class="tab-content">
                                <dl>
                                    <dt>umbrella, parasol, parachute</dt>
                                </dl>
                            </div>
                        </div>
                    </div>
                </div>
                <!--content-panel-->
            </div>
        </div>
        <!--body-wapper-->
    </div>
</body>
</html>
