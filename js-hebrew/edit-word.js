
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
    var elements = document.getElementsByClassName('textbox-defsBox' + textBoxType);
    var elementsTextBox = document.getElementsByClassName('textbox-defs' + textBoxType);
    var checkBoxes = document.getElementsByClassName('checkBoxes' + textBoxType);
    for (var i = 0; i < elements.length; i++) {
        if (window.getComputedStyle(elements[i]).display == "none") {
            elements[i].style.display = "flex";
            elementsTextBox[i].style.display = "block";
            checkBoxes[i].disabled = true;
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

    var elementsBox = document.getElementsByClassName('textbox-defsBox' + textBoxType);
    var elements = document.getElementsByClassName('textbox-defs' + textBoxType);
    var checkBoxes = document.getElementsByClassName('checkBoxes' + textBoxType);
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].value == "" && heart.innerHTML == emptyHeart && elements[i].readOnly == false) {
            elements[i].readOnly = true;
            elementsBox[i].className = "mb-3 row textbox-defsBox" + textBoxType;
            checkBoxes[i].disabled = true;
            heart.innerHTML = fullHeart;
            elements[i].value = "" + td.innerHTML;
            return;
        }
        else if (heart.innerHTML == fullHeart && checkBoxes[i].disabled == true) {
            if (elements[i].value == td.innerHTML) {
                elements[i].readOnly = false;
                elementsBox[i].className = "mb-3 row textbox-defsBox" + textBoxType + " textbox-hide";
                elements[i].value = "";
                checkBoxes[i].disabled = true;
                heart.innerHTML = emptyHeart;
                return;
            }
        }
    }
}

function addLikes(callback) {
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
    callback();
    return true;
}

function AddLikeAjax(id, type) {

    try {
        PageMethods.AddAllLikes(id, type, onSucess, onError);
        function onSucess(result) {
            //
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
        if (exaBoxes[i].value != "" && defBoxes[i].readOnly == false)
            examplesValues.push(exaBoxes[i].value);

    for (var i = 0; i < assBoxes.length; i++)
        if (assBoxes[i].value != "" && defBoxes[i].readOnly == false)
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

    var wordValue = document.getElementsByClassName('WordTextClass')[0];
    var wordValidation = document.getElementById('wordValidation');

    ValidationCheck(!wordValue.value.match(/\S/), wordValue, wordValidation, "לא הכנסת מילה."); //Checking if empty
    ValidationCheck(!(/^[\u0590-\u05FF ]+$/).test(wordValue.value), wordValue, wordValidation, "יש אותיות שלא בעברית במילה."); //Checking if in hebrew and space

    var defValidation = document.getElementById('definitionsValidation');
    var elements = document.getElementsByClassName('textbox-defs1');
    var checkBoxes1 = document.getElementsByClassName('checkBoxes1');
    var allEmpty = true;
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].value.match(/\S/) && checkBoxes1[i].checked != true) {
            allEmpty = false;
            break;
        }
    }

    ValidationCheck(allEmpty, elements[0], defValidation, "לא הכנסת הגדרה.");

    var wordNameLabelClass = document.getElementsByClassName('WordNameLabelClass')[0];

    GetWordIdByNameAjax(wordValue.value, function (result) {
        if (wordValue.value == wordNameLabelClass.innerHTML || result == 0) {
            if (error == false) {
                editWord();
                //alert("Word has been added.");
                //window.location.href = "../pages/add-word.aspx";
            } else {
                return false;
            }
        }
        else {
            ValidationCheck(result != 0, wordValue, wordValidation, "כבר הכנסת מילה עם השם הזה.");
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

function editWord() {
    var wordValue = document.getElementsByClassName('WordTextClass')[0].value; //People who wrote getElementById are dumb
    var categoryIndex = document.getElementsByClassName('CategoryDropListClass')[0];

    var defDeleteIndex = new Array();
    var exaDeleteIndex = new Array();
    var assDeleteIndex = new Array();


    var definitionsValues = new Array();
    var examplesValues = new Array();
    var associationsValues = new Array();

    var defBoxes = document.getElementsByClassName('textbox-defs1');
    var exaBoxes = document.getElementsByClassName('textbox-defs2');
    var assBoxes = document.getElementsByClassName('textbox-defs3');
    var checkBoxes1 = document.getElementsByClassName('checkBoxes1');
    var checkBoxes2 = document.getElementsByClassName('checkBoxes2');
    var checkBoxes3 = document.getElementsByClassName('checkBoxes3');

    for (var i = 0; i < defBoxes.length; i++) {
        //get new definitions
        if (defBoxes[i].value != "" && defBoxes[i].readOnly == false && checkBoxes1[i].disabled == true)
            definitionsValues.push(defBoxes[i].value);

        //check which one he wants to delete by index
        if (defBoxes[i].value != "" && defBoxes[i].readOnly == true && checkBoxes1[i].disabled == false) {
            if (checkBoxes1[i].checked == true)
                defDeleteIndex.push(i);
        }
    }

    for (var i = 0; i < exaBoxes.length; i++) {
        //get new definitions
        if (exaBoxes[i].value != "" && exaBoxes[i].readOnly == false && checkBoxes2[i].disabled == true)
            examplesValues.push(exaBoxes[i].value);

        //check which one he wants to delete by index
        if (exaBoxes[i].value != "" && exaBoxes[i].readOnly == true && checkBoxes2[i].disabled == false) {
            if (checkBoxes2[i].checked == true)
                exaDeleteIndex.push(i);
        }
    }

    for (var i = 0; i < assBoxes.length; i++) {
        //get new definitions
        if (assBoxes[i].value != "" && assBoxes[i].readOnly == false && checkBoxes3[i].disabled == true)
            associationsValues.push(assBoxes[i].value);

        //check which one he wants to delete by index
        if (assBoxes[i].value != "" && assBoxes[i].readOnly == true && checkBoxes3[i].disabled == false) {
            if (checkBoxes3[i].checked == true)
                assDeleteIndex.push(i);
        }
    }

    editWordAjax(wordValue, categoryIndex.value, definitionsValues, examplesValues, associationsValues, defDeleteIndex, exaDeleteIndex, assDeleteIndex, function () {
        window.location.href = "../hebrew/self-dictionary.aspx";
    });
}

function editWordAjax(wordTextBox, lastCategoryIndex, definitions, examples, associations, defDeleteIndex, exaDeleteIndex, assDeleteIndex, callback) {
    try {
        PageMethods.EditWordAjax(wordTextBox, lastCategoryIndex, definitions, examples, associations, defDeleteIndex, exaDeleteIndex, assDeleteIndex, onSucess, onError);
        function onSucess(result) {
            addLikes(callback); //handle likes
        }
        function onError(result) {
            alert(result);
        }
    } catch (e) {
        //Nothing
    }
    return false;
}