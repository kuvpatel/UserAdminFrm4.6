

function showAlert(message, title, alerttype) {

    var html = '<div id="divalert" class="alert ' + alerttype + ' flash fade-in alert-dismissable"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>';

    if (typeof title !== 'undefined' && title !== '') {
        html += '<h4>' + title + '</h4>';
    }

    html += '<span>' + message + '</span></div>';
    $('#divResult').html(html)

    // close the alert and remove this if the users doesnt close it in 5 secs
    setTimeout(function () {
        $(".flash").fadeTo(500, 0).slideUp(500, function () {
            $("#divalert").remove();
        });
    }, 5000);
}
