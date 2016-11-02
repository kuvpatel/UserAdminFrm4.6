//validate signup form on keyup and submit
var validator = $("#userForm").validate({
    rules: {
        Username: "required",
        Password: {
            required: true,
            minlength: 5
        },
        PasswordConfirm: {
            required: true,
            minlength: 5,
            equalTo: "#Password"
        },
        Email: true
    },
    highlight: function (element) {
        $(element).closest('.form-group').addClass('has-error');
    },
    unhighlight: function (element) {
        $(element).closest('.form-group').removeClass('has-error');
    },
    errorElement: "span",
    errorClass: 'label label-danger',
    errorPlacement: function (error, element) {
        if (element.parent('.form-group').length) {
            error.insertAfter(element.parent());
        } else {
            error.insertAfter(element);
        }
    },
    messages: {
        Firstname: "Firstname is required",
        Surname: "Surname is required",
        Username: "Username is required",
        Password: {
            required: "Password is required",
            minlength: "Password must be at least 5 characters long"
        },
        PasswordConfirm: {
            required: "Password is required",
            minlength: "Password must be at least 5 characters long",
            equalTo: "Please enter the same password as above"
        },
        Email: "Please enter a valid email address"
    }
    //,
    // success: function (element) {
    //     //$(element).text('OK!').addClass('label label-info')
    //     //    .closest('.form-group').removeClass('has-error').addClass('label label-info');
    // }
});

$('#btCancel').click(function () {
    validator.resetForm();
    $('.form-group').removeClass('has-error');
});
