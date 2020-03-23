function closeAlert() {
    $('#alertWarning').hide();
}

function validateForm(entity) {
    var err = [];
    if (!entity.MobileNumber)
        err.push("Mobile Number is Required");
    else {
        if (!IsPhoneVerified(entity.MobileNumber))
            err.push("Mobile phone is not valid");
    }
    if (!entity.FirstName)
        err.push("First Name is Required");
    if (!entity.LastName)
        err.push("Last Name is Required");
    if (!entity.Email)
        err.push("Email is Required");
    else {
        if (!IsEmail(entity.Email))
            err.push("Email is not valid");
    }
    return err;
}

function printOutError(err) {
    var divWarning = $('#errList');
    var htmlError = "";
    htmlError = "<ul id='errContent'>";
    for (var i = 0; i < err.length; i++) {
        htmlError += "<li>" + err[i] + "</li>";
    }
    htmlError += "</ul>";
    divWarning.append(htmlError);
    $('#alertWarning').show();
}

function submitForm() {
    var gender;
    if ($('#male').is(":checked")) {gender = 1;}
    if ($('#female').is(":checked")) { gender = 0; }

    var user =
    {
        Email: $('#txtMail').val(),
        MobileNumber: $('#txtCC').val() + $('#txtPhone').val(),
        FirstName: $('#txtFName').val(),
        LastName: $('#txtLName').val(),
        DateOfBirth: $('#txtDOB').val(),
        Gender: gender
    };

    var err = validateForm(user);
    $('#errContent').remove();

    if (err.length > 0) {
        printOutError(err);
    }
    else {
        $('#alertWarning').hide();
        API_Register(user).then(function (result) {
            $("#divParent")
                .fadeTo(500, 0.2)
                .hover(function () {
                    $(this).fadeTo(500, 1);
                }, function (result) {
                    $(this).fadeTo(500, 0.2);
                });
            $("#divParent").css({ 'pointer-events': 'none', 'opacity': '0.4;', 'color': 'grey' });
            $("#divLogin").show();
            verifEmail = result.data;
        },
            function (err) {
                if (err.status == 500) alert("Internal Server Error");
                else if (err.status == 400) alert("Bad Request");
                else if (err.status == 409) printOutError([err.msg]);
            });
    }
}

function login() {
    RedirectPage("User/Login/" + verifEmail);
}