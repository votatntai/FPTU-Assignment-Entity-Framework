/*Image Preview*/
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#image').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
$("#upload").change(function () {
    readURL(this);
});

/*Search*/
$(document).ready(function () {
    $("#search").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#idols div.col-lg-3").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});

/*Ajax Create Comment*/
$(function () {
    let form = $("#create-comment-form");
    form.on('submit', function (e) {
        e.preventDefault();
        let url = form.attr("action");
        let data = form.serialize();
        $.ajax({
            type: "POST",
            url: url,
            data: data,
            success: function (res) {
                if (res === "success") {
                    location.reload();
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown + textStatus);
            }
        });
    });
});

/*Ajax Timing
$(function () {
    setInterval(function () {
        $.ajax({
            url: "/Home/ServerTime",
            success: function (res) {
                $(".clock .timing").html(res);
            }
        })
    }, 1000)
});*/
