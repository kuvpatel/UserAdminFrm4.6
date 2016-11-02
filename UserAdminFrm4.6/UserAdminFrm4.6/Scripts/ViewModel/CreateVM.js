$(document).ready(function () {

    var urlPath = window.location.pathname;
    var CreateUserVM = {
        Firstname: ko.observable(),
        Surname: ko.observable(),
        Username: ko.observable(),
        Email: ko.observable(),
        Password: ko.observable(),
        PasswordConfirm: ko.observable(),
        Active: ko.observable(),
        btnCreateUser: function () {

            if (!$('#UserLineItemForm').valid()) {
                return false;
            }

            $.ajax({
                url: '/User/Create',
                type: 'post',
                dataType: 'json',
                data: ko.toJSON(this),
                contentType: 'application/json',
                success: function (data) {
                    var msg = '';
                    ShowLineItemAlert(data);
                    //if (data.Result == 'success') {
                        // showAlert("The details were saved successfully.", "", "alert-info");

                        
                    //}
                    //else {
                        // showAlert("Unable to save the details.", "", "alert-danger");
                      //  ShowLineItemAlert(result);
                    //}
                },
                error: function (err) {
                    alert(err.responseText);
                },
                complete: function () {
                }
            });
        }
    };

    ko.applyBindings(CreateUserVM);

});
