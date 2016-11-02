$(document).ready(function () {

    var urlPath = window.location.pathname;
    var EditUserVM = {
        Firstname: ko.observable(),
        Surname: ko.observable(),
        Username: ko.observable(),
        Email: ko.observable(),
        Password: ko.observable(),
        PasswordConfirm: ko.observable(),
        Active: ko.observable(),
        btnEditUser: function () {

            if (!$('#userForm').valid()) {
                return false;
            }

            $.ajax({
                url: '/User/Edit',
                type: 'post',
                dataType: 'json',
                data: ko.toJSON(this),
                contentType: 'application/json',
                success: function (result) {
                    var msg = '';
                    if (result == 'success') {
                        showAlert("The details were saved successfully.", "", "alert-info");
                    }
                    else {
                        showAlert("Unable to save the details.", "", "alert-danger");
                    }
                },
                error: function (err) {
                    alert(err.responseText);
                },
                complete: function () {
                }
            });
        }
    }; 

    ko.applyBindings(EditUserVM);

});
