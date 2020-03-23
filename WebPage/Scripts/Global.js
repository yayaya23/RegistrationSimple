var baseURL = "http://localhost:60107/";
var verifEmail = "";

function ValidateNumberOnly(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        evt.preventDefault();
    }
}

function API_Register(object) {
    return $.post(baseURL + "api/User/RegisterUser", object);
        //function (data, status) {
        //    alert("Data: " + data + "\nStatus: " + status);
        //});
}

function RedirectPage(param) {
    window.location.href = baseURL + param;
}

function IsEmail(email) {
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
        return false;
    } else {
        return true;
    }
}

function IsPhoneVerified(phone) {
    var regex = /^(^\+62\s?|^0)(\d{3,4}-?){2}\d{3,4}$/g;
    if (!regex.test(phone)) {
        return false;
    } else {
        return true;
    }
}