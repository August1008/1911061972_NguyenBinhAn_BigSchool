$(document).ready(function () {
    $(".js-toggle-attendance").click(function (e) {
        var button = $(e.target);
        $.post("/api/attendances", { courseId: button.attr("data-course-id") })
            .done(function () {
            button.removeClass("btn-default")
                .addClass("btn-primary")
                .text("Going");
        })
        .fail(function () {
            alert("Something failed!!");
        });
    });

    $(".js-toggle-following").click(function (e) {
        var button = $(e.target);
        $.post("/api/followings", { followeeId: button.attr("data-user-id") })
            .done(function () {
                button.text("Following");
            })
            .fail(function () {
                alert("Something failed!");
            })
    });
});