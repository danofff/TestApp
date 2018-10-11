$(document).ready(function() {
    $("#list").on("change", function () {
        var id = $(this).val();

        $.ajax({
            type: 'POST',
            url: '/Test/GetTestList',
            data: { subjectId: SubjectId },
            success: function (data) {
                console.log(data);
            }
        });
    });
});
