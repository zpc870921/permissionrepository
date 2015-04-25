(function ($) {
    $.fn.paginate = function (options) {
        var opts = $.extend({}, $.fn.paginate.defaults, options);
        return this.each(function () {
            $this = $(this);
            var o = $.meta ? $.extend({}, opts, $this.data()) : opts;
            var selectedpage = o.start;
            $.fn.draw(o, $this, selectedpage);
        });
    };
    var outsidewidth_tmp = 0;
    var insidewidth = 0;
    var bName = navigator.appName;
    var bVer = navigator.appVersion;
    if (bVer.indexOf('MSIE 7.0') > 0)
        var ver = "ie7";
    $.fn.paginate.defaults = {
        count: 5,
        start: 8,
        display: 5,
        border: true,
        border_color: '#fff',
        text_color: '#8cc59d',
        background_color: 'black',
        border_hover_color: '#fff',
        text_hover_color: '#fff',
        background_hover_color: '#fff',
        rotate: true,
        images: true,
        mouse: 'slide',
        onChange: function () { return false; }
    };
    $.fn.draw = function (o, obj, selectedpage) {

        var currentPage = selectedpage;
        var selobj;
        var _first = $(document.createElement('a')).attr("href", "javascript:void(0)").addClass('pre').html('◀ 上一页');
        var _divwrapleft = $(document.createElement('div')).addClass('jPag-control-back');
        var _ulwrapdiv = $(document.createElement('div'));
        var _ul = $(document.createElement('ul')).addClass('pages fr');
        var _last = $(document.createElement('a')).attr("href", "javascript:void(0)").addClass('next').html('下一页 ▶');
        var _divwrapright = $(document.createElement('div')).addClass('jPag-control-front');

        var appendItem = function (page_id) {
            if (page_id == currentPage) {
                var _obj = $(document.createElement('li')).addClass('lia').html('<a class="current currentPage">' + page_id + '</a>');
                selobj = _obj;
                _ul.append(_obj);
            }
            else {
                var _obj = $(document.createElement('li')).addClass('lia').html('<a href="javascript:void(0)">' + page_id + '</a>').click(function () {
                    currentPage = page_id;
                    $.fn.draw(o, obj, page_id);
                });
                _ul.append(_obj);
            }
        }

        var loading = function () {

            if (o.display > o.count)
                o.display = o.count;
            $this.empty();


            _ul.append($("<li></li>").addClass('lia').append(_first));

            var np = o.count;
            var start = 1;
            var end = np;

            if (np > o.display) {
                var middle = Math.ceil(o.display / 2) - 1;
                var below = currentPage - middle;
                var above = currentPage + middle;

                if (below < 4) {
                    above = o.display;
                    below = 1;
                }
                else if (above > (np - 4)) {
                    above = np;
                    below = (np - o.display);
                }
                start = below;
                end = above;

            }

            if (start > 3) {
                appendItem(1);
                var _obj = $(document.createElement('li')).html('<span>...</span>');
                _ul.append(_obj);
            }
            for (var i = start; i <= end; i++) {
                appendItem(i);
            }
            if (end < (np - 3)) {
                var _obj = $(document.createElement('li')).html('<span>...</span>');
                _ul.append(_obj);
                appendItem(np);
            }

            if (o.rotate) {
                if (o.images) var _rotright = $(document.createElement('span')).addClass(snextclass);
                else var _rotright = $(document.createElement('span')).addClass(snextclass).html('&raquo;');
            }
            _ul.append($("<li></li>").addClass('lia').append(_last));

            _ul.append('<li>共' + o.count + '页</li>');



            _ul.append('<li>跳到<input type="text" class="txt" id="txtPageSelected" />页</li>');


            var _obj = $(document.createElement('li')).addClass('searchPage').html('<a class="btn" href="javascript:void(0)">确定</a>').click(function () {
                page_id = $('#txtPageSelected').val();
                currentPage = page_id;
                $.fn.draw(o, obj, currentPage);
            });
            _ul.append(_obj);

            $this.append(_ul);

            _first.click(function (e) {
                currentPage = parseInt($('.currentPage').html() - 1);
                currentPage = currentPage <= 0 ? 1 : currentPage
                $.fn.draw(o, obj, currentPage);
                o.onChange(currentPage);
            });
            _last.click(function (e) {
                currentPage = parseInt($('.currentPage').html()) + 1;

                currentPage = currentPage >= o.count ? o.count : currentPage
                $.fn.draw(o, obj, currentPage);
                o.onChange(currentPage);

            });

            _ul.find('li').each(function () {
                $(this).click(function () {
                    var currval = $(this).find('a').html();
                    if (currval != null && currval != "确定") {
                        selobj = $(this);

                        o.onChange(parseInt(currval));
                    }
                    else if (currval == "确定") {
                        selobj = $(this);
                        currval = currentPage;
                        o.onChange(parseInt(currval));
                    }

                });
            });
        }
        loading();
    }
})(jQuery);