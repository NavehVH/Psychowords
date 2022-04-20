

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

function validateEmail(email) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

var emailInputs = document.getElementsByClassName('emailInputs');
var inputEmailCurrent = document.getElementById('inputEmailCurrent');
var inputEmailNew = document.getElementById('inputEmailNew');
var inputEmailNew2 = document.getElementById('inputEmailNew2');
var emailButtonV = document.getElementById('emailButtonV');

function validEmailCheck() {
    var waitingAjax = 0;

    error = false;
    for (var i = 0; i < emailInputs.length; i++)
        emailInputs[i].classList = "form-control emailInputs";

    ValidationCheck(!inputEmailCurrent.value.match(/\S/), inputEmailCurrent, document.getElementById(inputEmailCurrent.id + "V"), "לא הכנסת את המידע.");
    ValidationCheck(!inputEmailNew.value.match(/\S/), inputEmailNew, document.getElementById(inputEmailNew.id + "V"), "לא הכנסת את המידע.");
    ValidationCheck(!inputEmailNew2.value.match(/\S/), inputEmailNew2, document.getElementById(inputEmailNew2.id + "V"), "לא הכנסת את המידע.");

    ValidationCheck(!validateEmail(inputEmailCurrent.value), inputEmailCurrent, document.getElementById(inputEmailCurrent.id + "V"), "האיימיל שהכנסת לא רשום בצורה הנכונה.");
    ValidationCheck(!validateEmail(inputEmailNew.value), inputEmailNew, document.getElementById(inputEmailNew.id + "V"), "האיימיל שהכנסת לא רשום בצורה הנכונה.");
    ValidationCheck(!validateEmail(inputEmailNew2.value), inputEmailNew2, document.getElementById(inputEmailNew2.id + "V"), "האיימיל שהכנסת לא רשום בצורה הנכונה.");

    ValidationCheck(inputEmailCurrent.value == inputEmailNew.value, inputEmailNew, document.getElementById(inputEmailNew.id + "V"), "האימייל החדש שהכנסת זהה לישן.");
    ValidationCheck(inputEmailNew.value != inputEmailNew2.value, inputEmailNew2, document.getElementById(inputEmailNew2.id + "V"), "האימייל החדש שהכנסת והאימייל הזה לא זהים.");

    getCurrentEmailAjax(function (result) {
        ValidationCheck(inputEmailCurrent.value != result, inputEmailCurrent, document.getElementById(inputEmailCurrent.id + "V"), "האימייל שהכנסת אינו נכון.");

        isEmailUsedAjax(inputEmailNew.value, function (result) {
            ValidationCheck(result, inputEmailNew, document.getElementById(inputEmailNew.id + "V"), "האימייל הזה כבר בשימוש.");

            if (error == false) {
                updateEmailAjax(inputEmailNew.value, function () {
                    emailButtonV.innerHTML = "האימייל השתנה בהצלחה.";
                    emailButtonV.classList = "text-success";
                });
            }
        });
    });

    return false;
}

function getCurrentEmailAjax(callback) {

    try {
        PageMethods.GetCurrentEmail(onSucess, onError);
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

function getCurrentPasswordAjax(pass, callback) {

    try {
        PageMethods.GetCurrentPassword(pass, onSucess, onError);
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

function updateEmailAjax(newEmail, callback) {

    try {
        PageMethods.UpdateEmail(newEmail, onSucess, onError);
        function onSucess(result) {
            callback();
        }
        function onError(result) {
            alert(result);
        }
    } catch (e) {
        alert(e);
    }
    return false;
}

function updatePasswordAjax(newPassword, callback) {

    try {
        PageMethods.UpdatePassword(newPassword, onSucess, onError);
        function onSucess(result) {
            callback();
        }
        function onError(result) {
            alert(result);
        }
    } catch (e) {
        alert(e);
    }
    return false;
}

var passwordInputs = document.getElementsByClassName('passwordInputs');
var inputPasswordCurrent = document.getElementById('inputPasswordCurrent');
var inputPasswordNew = document.getElementById('inputPasswordNew');
var inputPasswordNew2 = document.getElementById('inputPasswordNew2');
var passwordButtonV = document.getElementById('passwordButtonV');

function validPasswordCheck() {

    var waitingAjax = 0;

    error = false;
    for (var i = 0; i < passwordInputs.length; i++)
        passwordInputs[i].classList = "form-control passwordInputs";

    ValidationCheck(!inputPasswordCurrent.value.match(/\S/), inputPasswordCurrent, document.getElementById(inputPasswordCurrent.id + "V"), "לא הכנסת את המידע.");
    ValidationCheck(!inputPasswordNew.value.match(/\S/), inputPasswordNew, document.getElementById(inputPasswordNew.id + "V"), "לא הכנסת את המידע.");
    ValidationCheck(!inputPasswordNew2.value.match(/\S/), inputPasswordNew2, document.getElementById(inputPasswordNew2.id + "V"), "לא הכנסת את המידע.");

    ValidationCheck(inputPasswordNew.value.length < 8, inputPasswordNew, document.getElementById(inputPasswordNew.id + "V"), "הסיסמה החדשה צריכה להיות מינימום 8 תווים.");

    ValidationCheck(inputPasswordNew.value != inputPasswordNew2.value, inputPasswordNew2, document.getElementById(inputPasswordNew2.id + "V"), "סיסמה זאת אינה תואמת לסיסמה החדשה שהכנסת.");

    getCurrentPasswordAjax(inputPasswordCurrent.value, function (result) {
        ValidationCheck(!result, inputPasswordCurrent, document.getElementById(inputPasswordCurrent.id + "V"), "הסיסמה שהכנסת אינה נכונה.");

        if (error == false) {
            updatePasswordAjax(inputPasswordNew.value, function () {
                passwordButtonV.innerHTML = "הסיסמה השתנתה בהצלחה.";
                passwordButtonV.classList = "text-success";
            });
        }
    });

    return false;
}

function sendEmailQuestion() {

    var username = prompt("הכנס את שם המשתמש שלך", "");
    var email = prompt("הכנס את כתובת האימייל של המשתמש שלך", "");

    if (email == null || email == "" || username == null || username == "") {
        txt = "לא הכנסת מידע.";
        alert(txt);
    } else {
        forgotPass_ServerClickAjax(username, email, function (result) {
            if (result == true) {
                alert("אימייל נשלח בהצלחה עם סיסמה חדשה למשתמש.");
            }
            else {
                alert("משהו השתבש, או שהנתונים שהכנסת אינם נכונים למשתמש, או שהמערכת כבר שלחה לך אימייל ב5 דקות האחרונות או שהתחברת למשתמש ב5 דקות האחרונות. בדיקה זו מונעת ספאם, חכה 5 דקות ונסה שוב.")
            }
        });
    }
}

function forgotPass_ServerClickAjax(username, email, callback) {

    try {
        PageMethods.ForgotPass_ServerClick(username, email, onSucess, onError);
        function onSucess(result) {
            callback(result);
        }
        function onError(result) {
            //Nothing
        }
    } catch (e) {
        //Nothing
    }
    return false;
}