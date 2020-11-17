$(function () {
    var winH = $(window).height();
    var categorySpace = 10;

    //载入数据
    function loaddata() {

        $.ajax({
            url: "../WxHandlers/WxSchoolService.ashx",
            data: { Type: "read", ltype: "分类目录", Reid: Math.random() },
            async: true,
            success: afterinfo
        });
    }
    function afterinfo(data) {

        $("#分类目录").html("");
        $("#学期目录").html("");
        $("#自定目录").html("");

        var _分类 = "";
        var _学期 = "";
        var _自定 = "";

        //|id,大类,小类|
        var items = data.split('|');
        for (var i = 0; i < items.length; i++) {
            var _item = items[i];
            var _val = _item.split(','); //id,大类,小类|

            var _html = "";
            _html += "<a class='weui-cell weui-cell_active weui-cell_access js_item' href='javascript:' data-id='" + _item + "'>";
            _html += "  <div class='weui-cell__bd'>";
            _html += "   <p>" + _val[2] + "</p>";
            _html += "  </div>";
            _html += " <span class='weui-cell__ft'></span>";
            _html += "</a>";

            if (_val[1] == "分类目录")
                _分类 += _html;
            else if (_val[1] == "学期目录")
                _学期 += _html;
            else
                _自定 += _html;
        }

        $("#分类目录").html(_分类);
        $("#学期目录").html(_学期);
        $("#自定目录").html(_自定);
        addclick2();
        addclick();
    }

    function addclick() {
        $('.js_item').on('click', function () {
            var id = $(this).data('id');
            window.location.href = "SchoolShiWen.aspx?id=" + id;
        });
    }

    function addclick2() {
        $('.js_category').on('click', function () {
            var $this = $(this),
                $inner = $this.next('.js_categoryInner'),
                $page = $this.parents('.page'),
                $parent = $(this).parent('li');
            var innerH = $inner.data('height');


            if (!innerH) {
                $inner.css('height', 'auto');
                innerH = $inner.height();
                $inner.removeAttr('style');
                $inner.data('height', innerH);
            }

            if ($parent.hasClass('js_show')) {
                $parent.removeClass('js_show');
            } else {
                $parent.siblings().removeClass('js_show');

                $parent.addClass('js_show');

                if (this.offsetTop + this.offsetHeight + innerH > $page.scrollTop() + winH) {

                    var scrollTop = this.offsetTop + this.offsetHeight + innerH - winH + categorySpace;

                    if (scrollTop > this.offsetTop) {
                        scrollTop = this.offsetTop - categorySpace;
                    }

                    $page.scrollTop(scrollTop);
                }
            }

            var winH = $(window).height();
            var $foot = $('body').find('.page__ft');
            if ($foot.length < 1) return;

            if ($foot.position().top + $foot.height() < winH) {
                $foot.addClass('j_bottom');
            } else {
                $foot.removeClass('j_bottom');
            }
        });
    }

    loaddata();
});