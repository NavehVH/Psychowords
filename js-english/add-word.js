
var error = false;

function hideTextBoxes() {
    for (var i = 1; i <= 3; i++) {
        var elements = document.getElementsByClassName('textbox-defs' + i);
        for (var j = 0; j < elements.length; j++) {
            if (elements[j].value == null) {
                elements[j].style.display = "none";
            }
        }
    }
}

function removeLikes() {
    for (var i = 1; i <= 3; i++) {
        var elements = document.getElementsByClassName('textbox-defs' + i);
        for (var j = 0; j < elements.length; j++) {
            if (elements[j].readOnly == true) {
                elements[j].value = "";
                elements[j].style.display = "none";
            }
        }
    }
}


function addDefinitionTextBox(textBoxType) {
    var elements = document.getElementsByClassName('textbox-defs' + textBoxType);
    for (var i = 0; i < elements.length; i++) {
        if (window.getComputedStyle(elements[i]).display == "none") {
            elements[i].style.display = "block";
            return;
        }
    }
}

function likeOption(textBoxType, contentValue) {
    contentValue = contentValue.substring(6); //Only fast way to get ID i could think of to get ID number
    var heart = document.getElementById("heart" + textBoxType + contentValue);
    var td = document.getElementById("tdHeart" + textBoxType + contentValue); //full ID of td

    var emptyHeart = '<i class="far fa-heart"></i>';
    var fullHeart = '<i class="fas fa-heart"></i>';

    var elements = document.getElementsByClassName('textbox-defs' + textBoxType);
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].value == "" && heart.innerHTML == emptyHeart) {
            elements[i].readOnly = true;
            elements[i].style.display = "block";

            heart.innerHTML = fullHeart;

            elements[i].value = "" + td.innerHTML;
            return;
        }
        else if (heart.innerHTML == fullHeart) {
            if (elements[i].value == td.innerHTML) {
                elements[i].readOnly = false;
                elements[i].style.display = "none";
                elements[i].value = "";
                heart.innerHTML = emptyHeart;
                return;
            }
        }
    }
}

function addLikes() {
    var id;
    var type; //what data type it is
    var fullHeart = '<i class="fas fa-heart"></i>';
    var elements = document.getElementsByClassName("likeHearts");
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].innerHTML == fullHeart) {
            type = elements[i].id.substring(5, 6);
            id = elements[i].id.substring(6);
            AddLikeAjax(id, type);
        }
    }
    return true;
}

function AddLikeAjax(id, type) {

    try {
        PageMethods.AddAllLikes(id, type, onSucess, onError);
        function onSucess(result) {
            //alert("Done adding likes." + type + " " + id);
        }
        function onError(result) {
            //Nothing
        }
    } catch (e) {
        //Nothing
    }
    return false;
}

function addWord() {

    var wordValue = document.getElementsByClassName('WordTextClass')[0].value; //People who wrote getElementById are dumb

    var definitionsValues = new Array();
    var examplesValues = new Array();
    var associationsValues = new Array();

    var defBoxes = document.getElementsByClassName('textbox-defs1');
    var exaBoxes = document.getElementsByClassName('textbox-defs2');
    var assBoxes = document.getElementsByClassName('textbox-defs3');

    for (var i = 0; i < defBoxes.length; i++)
        if (defBoxes[i].value != "" && defBoxes[i].readOnly == false)
            definitionsValues.push(defBoxes[i].value);

    for (var i = 0; i < exaBoxes.length; i++)
        if (exaBoxes[i].value != "" && exaBoxes[i].readOnly == false)
            examplesValues.push(exaBoxes[i].value);

    for (var i = 0; i < assBoxes.length; i++)
        if (assBoxes[i].value != "" && assBoxes[i].readOnly == false)
            associationsValues.push(assBoxes[i].value);

    var categoryIndex = document.getElementsByClassName('CategoryDropListClass')[0];
    addWordAjax(wordValue, categoryIndex.value, definitionsValues, examplesValues, associationsValues); //SQL
}

function addWordAjax(word, categoryIndex, def, exa, ass) {

    try {
        PageMethods.AddWord(word, categoryIndex, def, exa, ass, onSucess, onError);
        function onSucess(result) {
            //alert("Done adding word.");
        }
        function onError(result) {
            //alert(result);
        }
    } catch (e) {
        //alert(e);
    }
    return false;
}

function WordValidationAndData() {
    error = false;

    var editWordSpan = document.getElementById('editWordSpan');
    editWordSpan.className = "text-danger displayNone";

    var wordValue = document.getElementsByClassName('WordTextClass')[0];
    var wordValidation = document.getElementById('wordValidation');

    ValidationCheck(!wordValue.value.match(/\S/), wordValue, wordValidation, "לא הכנסת מילה."); //Checking if empty
    ValidationCheck(!(/^[A-Za-z ]+$/).test(wordValue.value), wordValue, wordValidation, "יש אותיות שלא באנגלית במילה."); //Checking if in hebrew and space

    var defValidation = document.getElementById('definitionsValidation');
    var elements = document.getElementsByClassName('textbox-defs1');
    var allEmpty = true;
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].value.match(/\S/)) {
            allEmpty = false;
            break;
        }
    }

    ValidationCheck(allEmpty, elements[0], defValidation, "לא הכנסת הגדרה.");

        GetWordIdByNameAjax(wordValue.value, function (result) {
            if (result == 0) {
                if (error == false) {
                    addWord();
                    addLikes();
                    //alert("Word has been added.");
                    window.location.href = "../english/add-word.aspx";
                } else {
                    return false;
                }
            }
            else {
                ValidationCheck(result != 0, wordValue, wordValidation, "כבר הכנסת מילה עם השם הזה.");

                var editWordHref = document.getElementById('editWordHref');
                var editWordSpan = document.getElementById('editWordSpan');

                editWordHref.href = "../hebrew/edit-word.aspx?Id=" + result;
                editWordSpan.className = "text-danger";

                return false;
            }
        });
}

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
            error = true;
        }
    }
    else {
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

function GetWordIdByNameAjax(word, callback) {

    try {
        PageMethods.GetWordIdByNameAjax(word, onSucess, onError);
        function onSucess(result) {
            callback(result);
        }
        function onError(result) {
            alert(result);
        }
    } catch (e) {
        alert(error);
    }
    return false;
}