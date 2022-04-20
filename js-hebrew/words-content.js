
var wordIdGlobal = 0;

var idShown = 0;
var knownShown = 0;
var downLoading = 0; //Check every type of content is loaded before showing

setFirstWordDefault();

function setFirstWordDefault() {
    var words = document.getElementsByClassName('wordsList');
    if (words.length > 0) {
        words[0].click();
        words[0].className += " active";
    }
    else {
        window.location.href = "../hebrew/self-dictionary.aspx";
        alert("יש לך 0 מילים.");
    }
}

function setWord(id) {

    downLoading = 0;
    var mainCardLoading = document.getElementById('mainCardLoading');
    var mainCardContent = document.getElementById('mainCardContent');

    var tables = document.getElementById('tablesDiv');
    tables.className = "card-body displayNone";

    setWordCall(id, function () {
        mainCardLoading.style.display = "none";
        mainCardContent.style.display = "initial";
    });
    return false;
}

function refreshSettings() {
    var editSettings = document.getElementById('editSettings');
    var categoryIndex = document.getElementsByClassName('CategoryDropListClass')[0];
    var savedSpan = document.getElementById('savedSpan');
    var deleteCheckBox = document.getElementById('deleteCheckBox');
    savedSpan.className = "displayNone";
    editSettings.className = "btn btn-primary";
    deleteCheckBox.checked = false; 
}

function setWordCall(id, callback) {
    var mainCardLoading = document.getElementById('mainCardLoading');
    var mainCardContent = document.getElementById('mainCardContent');

    mainCardContent.style.display = "none";
    mainCardLoading.style.display = "block";

    var editWordHref = document.getElementById('editWordHref');
    editWordHref.href = "../hebrew/edit-word.aspx?Id=" + id.substring(11);

    idShown = id;
    var wordContent = document.getElementById('wordContent');
    var elementsDiv = document.getElementsByClassName('wordCard');

    var clicked = document.getElementById(id).innerHTML;

    document.getElementsByClassName('wordNameClass')[0].textContent = clicked;
    wordIdGlobal = id.substring(11);
    GetKnownAjax(id.substring(11));

    getWordDataByType(id, 1, "definitions", callback);
    getWordDataByType(id, 2, "examples", callback);
    getWordDataByType(id, 3, "associations", callback);
    wordContent.style.display = 'block';
}

function getWordDataByType(id, dataType, table, callback) {
    id = id.substring(11);

    try {
        PageMethods.GetWordInfo(id, table, onSucess, onError);
        function onSucess(results) {
            var box = document.getElementById('wordBox' + dataType);
            var elements = box.getElementsByClassName('wordElement');
            var elementsDiv = box.getElementsByClassName('wordCard');

            var display = false;
            for (var i = 0; i < elements.length; i++) {
                if (results[i] != null) {
                    elements[i].innerHTML = results[i];
                    elementsDiv[i].style.display = "block";
                    display = true;
                }
                else {
                    elementsDiv[i].style.display = "none";
                }
            }

            if (display == false) {
                elements[0].innerHTML = "לא נמצא תוכן";
                elementsDiv[0].style.display = "block";
            }

            downLoading++;
            if (downLoading == 3) {
                callback();
            }
        }
        function onError(result) {
            results = new String[8];
        }
    } catch (e) {
        results = null;
    }
}

function setKnown(type) {
    var words = document.getElementById("wordsOptions");
    var actives = words.getElementsByClassName('active');
    var wordKnowSet = document.getElementById('knowShow');

    if (actives.length > 0) {
        if (type == 1) {
            actives[0].className = "list-group-item list-group-item-danger wordsList active";
            wordKnowSet.className = "badge bg-danger";
            wordKnowSet.innerHTML = '<i class="fas fa-times"></i>';
        }
        if (type == 2) {
            actives[0].className = "list-group-item list-group-item-warning wordsList active";
            wordKnowSet.className = "badge bg-warning";
            wordKnowSet.innerHTML = '<i class="fas fa-check"></i>';
        }
        if (type == 3) {
            actives[0].className = "list-group-item list-group-item-success wordsList active";
            wordKnowSet.className = "badge bg-success";
            wordKnowSet.innerHTML = '<i class="fas fa-check-double"></i>';
        }
    }
    SetKnownAjax(type); //Insert known
}


function SetKnownAjax(type) {

    try {
        PageMethods.SetKnown(type, onSucess, onError);
        function onSucess(result) {
            //alert("Done... ");
        }
        function onError(result) {
            //Nothing
        }
    } catch (e) {
        //Nothing
    }
    return false;
}

function GetKnownAjax(id) {
    var wordKnowSet = document.getElementById('knowShow');
    try {
        PageMethods.GetKnown(id, onSucess, onError);
        function onSucess(result) {
            //Setting the known view
            if (result[0] == 3) {
                wordKnowSet.className = "badge bg-success";
                wordKnowSet.innerHTML = '<i class="fas fa-check-double"></i>';
            }
            if (result[0] == 2) {
                wordKnowSet.className = "badge bg-warning";
                wordKnowSet.innerHTML = '<i class="fas fa-check"></i>';
            }
            if (result[0] == 1) {
                wordKnowSet.className = "badge bg-danger";
                wordKnowSet.innerHTML = '<i class="fas fa-times"></i>';
            }
            if (result[0] == 0) {
                wordKnowSet.className = "badge bg-primary";
                wordKnowSet.innerHTML = '<i class="fas fa-question"></i>';
            }

            var categoryIndex = document.getElementsByClassName('CategoryDropListClass')[0];
            categoryIndex.value = result[1]; //Add category info from known ajax (lazy)
        }
        function onError(result) {
            //Nothing
        }
    } catch (e) {
        //Nothing
    }
    return false;
}

//suggestion table stuff ~.~

var lastLike = 0;
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
    var id = idElement.substring(8);
    lastLike = id;
    lastWordIdLike = wordId;
    lastType = type;
    //Get word info
    getWordInfo(wordId, type, false, function (newHtml) {
        html = newHtml;
    });

    LikeHandleAjax(id, false, lastWordIdLike, function () {
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
    LikeHandleAjax(lastLike, true, lastWordIdLike, function () {
        wordModalSpan.innerHTML = "";
        modalSpan.innerHTML = "הוכנס בהצלחה. רק לאחר רענון הדף יהיה אפשר לראות את מה שהוכנס.";
        modalSaveButton.style.display = "none";
    });
}

function LikeHandleAjax(id, enterData, wordId, callback) {

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

function saveEdit() {
    var categoryIndex = document.getElementsByClassName('CategoryDropListClass')[0];
    var deleteCheckBox = document.getElementById('deleteCheckBox');
    var savedSpan = document.getElementById('savedSpan');
    var wordShown = document.getElementById(idShown);
    var editSettings = document.getElementById('editSettings');
    var editSettingsClose = document.getElementById('editSettingsClose');

    editSettings.className = "displayNone";

    saveEditSettingsAjax(wordIdGlobal, categoryIndex.value, deleteCheckBox.checked, function () {
        if (deleteCheckBox.checked) {
            wordShown.className = "displayNone";
            editSettingsClose.click();
            setFirstWordDefault();
        }
        else {
            savedSpan.className = "";
        }
    });
}

function saveEditSettingsAjax(wordId, categoryId, deleteBool, callback) {

    try {
        PageMethods.SaveEditSettingsAjax(wordId, categoryId, deleteBool, onSucess, onError);
        function onSucess(results) {
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