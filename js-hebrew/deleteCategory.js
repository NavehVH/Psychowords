
//deleting category from the database
function deleteButton(fullId) {
    if (confirm('האם אתה בטוח שתרצה למחוק קטגוריה זו? כל המילים בקטגוריה לא יהיו שייכים לקטגוריה הזו יותר.')) {
        deleteButtonAjax(fullId, function () {
            alert("נמחק בהצלחה.");
        });
    } else {
        // Do nothing
    }
}

//delete category method
function deleteButtonAjax(fullId, callback) {
    var id = fullId.substring(12);

    try {
        PageMethods.DeleteButton(id, onSucess, onError);
        function onSucess(result) {
            document.getElementById("card" + id).style.display = 'none';
            callback();
        }
        function onError(result) {
            //Nothing
        }
    } catch (e) {
        //Nothing
    }
    return false;
}

var error = false;

//check a validation if correct
function ValidationCheck(bool, textBoxElement, validationElement, validationText) {
    if (error == false) {
        if (bool) {
            ValidationError(textBoxElement, validationElement, validationText);
            error = true;
        }
        else {
            ValidationSuccess(textBoxElement, validationElement);
        }
    }
}

//show error on element
function ValidationError(textBoxElement, validationElement, validationText) {
    validationElement.style.display = "inherit";
    validationElement.className = " text-danger";
    textBoxElement.className = "form-control CategoryTextBoxClass is-invalid";
    validationElement.innerHTML = validationText;

}

//show success on element
function ValidationSuccess(textBoxElement, validationElement) {
    validationElement.style.display = "none";
    textBoxElement.className += "form-control CategoryTextBoxClass is-valid";
}


//check if added name of category
function categoryValidation() {
    error = false;

    var CategoryTextBox = document.getElementsByClassName('CategoryTextBoxClass')[0];
    var CategoryhValidation = document.getElementById('categorySpan');

    ValidationCheck(!CategoryTextBox.value.match(/\S/), CategoryTextBox, CategoryhValidation, "לא הכנסת שם של קטגוריה.");

    return !error;
}