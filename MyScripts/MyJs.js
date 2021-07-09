$(document).ready(function () {


    $(".js-toggle-attendance").click(function (e) {
        var button = $(e.target);
        if (button.hasClass("btn-default")) {
            $.post("/api/attendances", { courseId: button.attr("data-course-id") })
                .done(function () {
                    button.removeClass("btn-default")
                        .addClass("btn-primary")
                        .text("Going");
                })
                .fail(function () {
                    alert("Something failed!!");
                });
        } else {
            $.ajax({ url: "/api/attendances/" + button.attr("data-course-id"), method: "DELETE" })
                .done(function () {
                    button
                        .removeClass("btn-info")
                        .addClass("btn-default")
                        .text("Going?");
                })
                .fail(function () {
                    alert("Something failed!");
                });
        }
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


    $(".js-cancel-course").click(function (e) {
        e.preventDefault();
        var link = $(e.target);
        bootbox.confirm("Are you sure to cancel?",
            function () {
                $.ajax({ url: "/api/courses/" + link.attr("data-course-id"),method: "DELETE"})
                    .done(function() {
                        link.parents("li").fadeOut(function () {
                            $(this).remove();
                        });
                    })
                    .fail(function () {
                        alert("Something failed!");
                    });

            });
    });

});