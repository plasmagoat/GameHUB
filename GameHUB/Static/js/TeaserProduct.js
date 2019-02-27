$(".varient-selector a").click(function () {
    $(this).parent().siblings().first().text($(this).text());
});