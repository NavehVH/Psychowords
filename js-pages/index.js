
var error = false;

function ValidationCheck(bool, textBoxElement, validationElement, validationText) {

    var hasError = false;

    var newClass = "";
    var classes = textBoxElement.className.split(' ');
    for (var i = 0; i < classes.length; i++) {
        if (classes[i] == "is-invalid")
            hasError = true; //Already has an error

        if (classes[i] != "is-valid" && classes[i] != "is-invalid") {
            newClass += " " + classes[i];
        }
    }

    if (bool) {
        if (hasError == false) {
            ValidationError(textBoxElement, validationElement, validationText, newClass);
        }
        error = true;
    }
    else {
        if (!hasError)
            ValidationSuccess(textBoxElement, validationElement, newClass);
    }
}

function ValidationError(textBoxElement, validationElement, validationText, classString) {
    validationElement.style.display = "inherit";
    validationElement.className = " text-danger";
    validationElement.innerHTML = validationText;

    classString += " is-invalid";
    textBoxElement.className = classString;

}

function ValidationSuccess(textBoxElement, validationElement, classString) {
    validationElement.style.display = "none";

    classString += " is-valid";
    textBoxElement.className = classString;
}

function ValidationNoTextCheck(input) {
    ValidationCheck(!input.value.match(/\S/), input, document.getElementById(input.id + "V"), "לא הכנסת את המידע.");
}

function validateEmail(email) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

function isEmailUsedAjax(email, callback) {
    try {
        PageMethods.IsEmailUsed(email, onSucess, onError);
        function onSucess(result) {
            callback(result);
        }
        function onError(result) {
            alert(result);
        }
    } catch (e) {
        alert(e);
    }
    return false;
}

function isUsernameUsedAjax(username, callback) {
    try {
        PageMethods.IsUsernameUsed(username, onSucess, onError);
        function onSucess(result) {
            callback(result);
        }
        function onError(result) {
            alert(result);
        }
    } catch (e) {
        alert(e);
    }
    return false;
}

function registerAccountAjax(username, password, email, firstName, lastName, callback) {
    try {
        PageMethods.RegisterAccountAjax(username, password, email, firstName, lastName, onSucess, onError);
        function onSucess(result) {
            callback(result);
        }
        function onError(result) {
            alert(result);
        }
    } catch (e) {
        alert(e);
    }
    return false;
}

//Textboxes
var registrationInputs = document.getElementsByClassName('registrationInputs');

var firstName = document.getElementById("firstName");
var lastName = document.getElementById("lastName");
var username = document.getElementById("username");
var password = document.getElementById("password");
var passwrodRepeat = document.getElementById("passwordRepeat");
var email = document.getElementById("email");
var emailRepeat = document.getElementById("emailRepeat");

var accountAddedSpan = document.getElementById('accountAddedSpan');

function validateRegistration() {
    error = false;
    for (var i = 0; i < registrationInputs.length; i++)
        registrationInputs[i].classList = "form-control registrationInputs";


    for (var i = 0; i < registrationInputs.length; i++) {
        ValidationNoTextCheck(registrationInputs[i]);
    }

    ValidationCheck(!(/^[A-Za-z0-9]+$/).test(username.value), username, document.getElementById(username.id + "V"), "שם משתמש יכול להיות רק באנגלית ועם מספרים");
    ValidationCheck(username.value.length < 5, username, document.getElementById(username.id + "V"), "השם המשתמש צריך להיות מינימום 5 תווים.");

    ValidationCheck(!validateEmail(email.value), email, document.getElementById(email.id + "V"), "האיימיל שהכנסת לא רשום בצורה הנכונה.");
    ValidationCheck(!validateEmail(emailRepeat.value), emailRepeat, document.getElementById(emailRepeat.id + "V"), "האיימיל שהכנסת לא רשום בצורה הנכונה.");
    ValidationCheck(email.value != emailRepeat.value, emailRepeat, document.getElementById(emailRepeat.id + "V"), "האימייל שהכנסת והאימייל הזה לא זהים.");

    ValidationCheck(password.value.length < 8, password, document.getElementById(password.id + "V"), "הסיסמה צריכה להיות מינימום 8 תווים.");
    ValidationCheck(password.value != passwrodRepeat.value, passwrodRepeat, document.getElementById(passwrodRepeat.id + "V"), "סיסמה זאת אינה תואמת לסיסמה שהכנסת.");

    isUsernameUsedAjax(username.value, function (result) {
        ValidationCheck(result, username, document.getElementById(username.id + "V"), "שם המשתמש הזה כבר בשימוש.");
        isEmailUsedAjax(email.value, function (result) {
            ValidationCheck(result, email, document.getElementById(email.id + "V"), "האימייל הזה כבר בשימוש.");

            if (error == false) {
                registerAccountAjax(username.value, password.value, email.value, firstName.value, lastName.value, function (result) {
                    if (result == true) {
                        accountAddedSpan.innerHTML = "המשתמש נוסף בהצלחה, אימייל נשלח אלייך לצורך אימות.";
                        alert("המשתמש נוסף בהצלחה, אימייל נשלח אלייך לצורך אימות.");
                    }
                    else {
                        alert("או שקיימת בעיה במערכת או שיצרת משתמש כבר ב-5 דקות האחורונות. נסה שוב מאוחר יותר.");
                    }
                });
            }
        });
    });
} 