$(document).on('click', '.jsAddToCart', function (e) {
    e.preventDefault();

    var form = $(this).closest("form");
    var formContainer = $("#" + form.data("container"));
    var skuCode = $("#code", form).val();

    $.ajax({
        type: "POST",
        url: form[0].action,
        data: { code: skuCode },
        success: function(result) {
            formContainer.html($(result));
            $("#cartItems").text($("#itemCount", formContainer).text());
            formContainer.change();
            formContainer.dropdown('show');
        },
        error: function(xhr, status, error) {

        }
    });
});

$(document).on('change', '.jsUpdateItemCart', function (e) {
    e.preventDefault();

    var form = $(this).closest("form");
    var formContainer = $("#" + form.data("container"));

    var quantity = $("#quantity", form);
    var skuCode = quantity.attr("name");
    console.log("update");
    $.ajax({
        type: "POST",
        url: form[0].action,
        data: { code: skuCode, quantity: quantity.val() },
        success: function (result) {
            formContainer.html($(result));
            $("#cartItems").text($("#itemCount", formContainer).text());
            formContainer.change();
            formContainer.dropdown('show');

        },
        error: function (xhr, status, error) {

        }
    });
});


//$(document).on('shown.bs.dropdown', '.keep-open', function() { $(this).attr('closable', false); });
//$(document).on('hide.bs.dropdown', '.keep-open', function() { return $(this).attr('closable') == 'true'; });


$('.keep-open').on({
    "shown.bs.dropdown": function () { $(this).attr('closable', false); },
    "hide.bs.dropdown": function () { return $(this).attr('closable') == 'true'; }
});


//$(document).on('click', '.dropdown-toggle', function() {
//    console.log("here");
//    $(this).parent().attr('closable', true);
//});

$('.keep-open').children().first().on({
    "click": function () {
        $(this).parent().attr('closable', true);
    }
});
