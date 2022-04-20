﻿
var error = false;

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

function ValidationError(textBoxElement, validationElement, validationText) {
    validationElement.style.display = "inherit";
    validationElement.className = " text-danger";
    validationElement.innerHTML = validationText;

}

function ValidationSuccess(textBoxElement, validationElement) {
    validationElement.style.display = "none";
}

function searchValidation() {
    error = false;

    alert("x");
    return !error;
}

var lastLike = 0;
var lastIdElementName = "";
var lastWordIdLike = 0;
var lastType = 0;
var hasWordId = 0;

var modalSpan = document.getElementById('modalSpan');
var wordModalSpan = document.getElementById('wordModalSpan');
var modalSaveButton = document.getElementById('saveSettings');
var wordDefArray = [];

function likeWord(idElement, type, wordId) {
    modalSaveButton.style.display = "none";
    wordModalSpan.innerHTML = "";
    hasWordId = 0;

    var html = "";
    lastIdElementName = idElement;
    var id = idElement.substring(8);
    lastLike = id;
    lastWordIdLike = wordId;
    lastType = type;
    //Get word info
    getWordInfo(wordId, type, false, function (newHtml) {
        html = newHtml;

        LikeHandleAjax(id, false, lastWordIdLike, lastIdElementName, function () {
            if (type == 1) {
                if (hasWordId != 0) {
                    wordModalSpan.innerHTML = html;
                    modalSpan.innerHTML = "לא תוכל להכניס את המילה כי היא כבר קיימת במאגר שלך.";
                    modalSaveButton.style.display = "none";
                }
                else {
                    wordModalSpan.innerHTML = html;
                    modalSaveButton.style.display = "initial";
                    modalSpan.innerHTML = "האם אתה בטוח שברצונך לעשות לייק למילה הזאת?";
                }
            }
            else if (type == 2) {
                if (hasWordId != 0) {
                    getWordInfo(hasWordId, type, true, function (newHtml) {
                        html = newHtml;
                        wordModalSpan.innerHTML = html;
                    });
                    var rowData = document.getElementById('rowData2' + id);
                    modalSpan.innerHTML = "<span>*</span> <strong>" + rowData.innerHTML + "</strong><br/>";
                    modalSpan.innerHTML += "המילה קיימת כבר במאגר שלך, האם אתה בטוח שתרצה להוסיף פירוש זה?";
                    modalSaveButton.style.display = "initial";
                }
                else {
                    var wordNameSpan = document.getElementById('wordName' + type + lastWordIdLike);
                    html = `<span>מילה:</span> <strong>${wordNameSpan.innerHTML}</strong><br/><br/>`;
                    wordModalSpan.innerHTML = html;
                    modalSaveButton.style.display = "initial";

                    var rowData = document.getElementById('rowData2' + id);
                    modalSpan.innerHTML = "<span>*</span> <strong>" + rowData.innerHTML + "</strong><br/>";
                    modalSpan.innerHTML += "המילה לא קיימת במאגר שלך, האם תרצה להוסיף אותה עם הפירוש הזה?";
                    modalSaveButton.style.display = "initial";
                }
            }
            else if (type == 3) {
                if (hasWordId == 0) {
                    modalSpan.innerHTML = "המילה לא קיימת במאגר שלך, לכן לא תוכל להכניס את האסוציאציה.";
                }
                else {
                    getWordInfo(hasWordId, type, true, function (newHtml) {
                        html = newHtml;
                        wordModalSpan.innerHTML = html;
                    });
                    var rowData = document.getElementById('rowData3' + id);
                    modalSpan.innerHTML = "<span>*</span> <strong>" + rowData.innerHTML + "</strong><br/>";
                    modalSpan.innerHTML += "המילה קיימת במאגר שלך, האם אתה בטוח שתרצה להוסיף את האסוציאציה?";
                    modalSaveButton.style.display = "initial";
                }
            }
            else if (type == 4) {
                if (hasWordId == 0) {
                    modalSpan.innerHTML = "המילה לא קיימת במאגר שלך, לכן לא תוכל להכניס את הדוגמה.";
                }
                else {
                    getWordInfo(hasWordId, type, true, function (newHtml) {
                        html = newHtml;
                        wordModalSpan.innerHTML = html;
                    });
                    var rowData = document.getElementById('rowData4' + id);
                    modalSpan.innerHTML = "<span>*</span> <strong>" + rowData.innerHTML + "</strong><br/>";
                    modalSpan.innerHTML += "המילה קיימת במאגר שלך, האם אתה בטוח שתרצה להוסיף את הדוגמה?";
                    modalSaveButton.style.display = "initial";
                }
            }
        });
    });

}

function getWordInfo(wordId, type, myWord, callback) {
    //Get word info
    var html = "";
    WordInfoAjax(wordId, "definitions", function () {
        var wordNameSpan = document.getElementById('wordName' + type + lastWordIdLike);
        if (myWord == true) {
            html = `<span>המילה מהמילון שלך:</span> <strong>${wordNameSpan.innerHTML}</strong><br/><br/>`;
        }
        else {
            html = `<span>מילה:</span> <strong>${wordNameSpan.innerHTML}</strong><br/><br/>`;
        }

        for (var i = 0; i < wordDefArray.length; i++) {
            html += "<strong>+</strong> <span>" + wordDefArray[i] + "</span><br/>";
        }

        html += "<br/>";
        callback(html);
    });
}

function saveButton() {
    LikeHandleAjax(lastLike, true, lastWordIdLike, lastIdElementName, function () {
        wordModalSpan.innerHTML = "";
        modalSpan.innerHTML = "הוכנס בהצלחה.";
        modalSaveButton.style.display = "none";
    });
}

function LikeHandleAjax(id, enterData, wordId, lastIdElementName, callback) {

    var fullHeart = '<i class="fas fa-heart"></i>';

    try {
        if (enterData) {
            if (lastType == 1) {
                PageMethods.LikeWordAjax(wordId, onSucess, onError);
            }
            if (lastType == 2) {
                if (hasWordId != 0) {
                    PageMethods.LikeDefinitionAjax(wordId, id, false, onSucess, onError);
                } else {
                    PageMethods.LikeDefinitionAjax(wordId, id, true, onSucess, onError);
                }
            }
            if (lastType == 3) {
                PageMethods.LikeAssAjax(wordId, id, onSucess, onError);
            }
            if (lastType == 4) {
                PageMethods.LikeExaAjax(wordId, id, onSucess, onError);
            }
        }
        else
            PageMethods.GetWordIdByNameAjax(wordId, onSucess, onError);
        function onSucess(result) {
            if (!enterData) {
                hasWordId = result;
            }
            else {
                document.getElementById(lastIdElementName).innerHTML = fullHeart;
            }
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

function WordInfoAjax(wordId, table, callback) {

    try {
        PageMethods.GetInfoByWordAjax(wordId, table, onSucess, onError);
        function onSucess(results) {
            wordDefArray = results;
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