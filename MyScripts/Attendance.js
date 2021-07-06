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
});