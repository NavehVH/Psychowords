
window.onload = startSessionAuto();

//handle timer
var sec = 0;
function pad(val) { return val > 9 ? val : "0" + val; }

var fullData = [];

var questionsAnswered = 0;
var anwerCorrect = 0;
var answerErrors = 0;
var answeredSpan = document.getElementById('answeredSpan');
var questionsAmountSpan = document.getElementById('questionsAmountSpan');
var percentSpan = document.getElementById('percentSpan');

var optionsCount = 0;
var answerIndex = 0; //Always the first value
var madeAnError = false;

var questionElement = document.getElementById('questionText');
var questionDiv = document.getElementById('questionDiv');

var optionsButtonsDiv = document.getElementsByClassName('optionsButtonsDiv');
var optionsButtonElements = document.getElementsByClassName('optionsButtons');

var memorySession = document.getElementsByClassName('MemorySessionClass')[0];
var options = document.getElementsByClassName('DropDownListClass')[0];

function startSessionAuto() {
    memorySession = document.getElementsByClassName('MemorySessionClass')[0];
    questionDiv = document.getElementById('questionDiv');
    if (memorySession.value == "true") {
        setQuestionAjax();
        questionDiv.className = "";
        document.getElementById('sessionButton').style.display = "none";

        setInterval(function () {
            document.getElementById("seconds").innerHTML = pad(++sec % 60);
            document.getElementById("minutes").innerHTML = pad(parseInt(sec / 60, 10));
        }, 1000);
    }
}

function startSession() {
    setQuestionAjax();

    setInterval(function () {
        document.getElementById("seconds").innerHTML = pad(++sec % 60);
        document.getElementById("minutes").innerHTML = pad(parseInt(sec / 60, 10));
    }, 1000);
}

function setQuestionAjax() {
    options = document.getElementsByClassName('DropDownListClass')[0];
    var categoryType = document.getElementsByClassName('CategoryDropDownListClass')[0];
    try {
        PageMethods.GetData(options.value, categoryType.value, onSucess, onError);
        function onSucess(results) {
            if (results.length < 2) {
                alert('אין לך מספיק מילים בקטגוריה זו, צריך מינימום של ' + options.value + ' מילים.');
                return false;
            }
            else {
                setQuestion(results, false);
                questionDiv.className = "";
                document.getElementById('sessionButton').style.display = "none";
            }
        }
        function onError(xhr, status, error) {
            alert(xhr + ", " + status + ", " + error);
        }
    } catch (e) {
        alert(e);
    }
    return false;
}

//suffle an array
function shuffle(a) {
    var j, x, i;
    for (i = a.length - 1; i > 0; i--) {
        j = Math.floor(Math.random() * (i + 1));
        x = a[i];
        a[i] = a[j];
        a[j] = x;
    }
    return a;
}

function setQuestion(data, session) {

    var wordsArray = data[1].slice();
    wordsArray = shuffle(wordsArray);
    if (data == null)
        return;

    fullData = data;
    resetButtonsStyle();
    madeAnError = false;

    options = document.getElementsByClassName('DropDownListClass')[0].value;
    optionsCount = data[0].length;
    answerIndex = Math.floor(Math.random() * optionsCount);

    var rightAnswer = data[1][answerIndex];
    questionElement.innerHTML = data[2][answerIndex];

    var answerChoosenIndex = Math.floor(Math.random() * 4);
    var addedAnswer = false;

    for (var i = 0; i < optionsCount; i++) {
        if (i < options) {
            optionsButtonsDiv[i].className = 'col-md-4 col-xl-3 text-center optionsButtonsDiv';
            optionsButtonElements[i].innerHTML = wordsArray[i];

            if (wordsArray[i] == rightAnswer) {
                answerIndex = i;
                addedAnswer = true;
            }
        }
        else {
            if (addedAnswer == true)
                break;
            else {
                if (wordsArray[i] == rightAnswer) {
                    optionsButtonsDiv[answerChoosenIndex].className = 'col-md-4 col-xl-3 text-center optionsButtonsDiv';
                    optionsButtonElements[answerChoosenIndex].innerHTML = wordsArray[i];
                    answerIndex = answerChoosenIndex;
                    addedAnswer = true;
                }
            }
        }
    }
}

function tryToAnswer(id, index) {
    var element = document.getElementById(id);
    if (answerIndex == index) { //Answered Correct
        if (madeAnError == false && optionsButtonElements[index].className == "btn btn-primary py-2 py-md-3 optionsButtons")
            questionsAnswered++;
        optionsButtonElements[index].className = "btn btn-success py-2 py-md-3 optionsButtons";
        optionsButtonElements[index].blur();
        answeredSpan.innerHTML = questionsAnswered;
        questionsAmountSpan.innerHTML = (questionsAnswered + answerErrors);
        percentSpan.innerHTML = getPercentSuccess();
        setTimeout(function () { //Create delay
            if (memorySession.value == "true") {
                setQuestion(fullData, true);
            }
            else {
                setQuestionAjax();
            }
        }, 1000);
    }
    else {
        if (madeAnError == false) {
            answerErrors++;
            madeAnError = true;
        }
        optionsButtonElements[index].className = "btn btn-danger py-2 py-md-3 optionsButtons";
        percentSpan.innerHTML = getPercentSuccess();
    }
    return false;
}

function resetButtonsStyle() {
    for (var i = 0; i < optionsButtonElements.length; i++) {
        optionsButtonElements[i].className = "btn btn-primary py-2 py-md-3 optionsButtons";
    }
}

function getPercentSuccess() {
    return Math.floor((100 * questionsAnswered) / (questionsAnswered + answerErrors)); //#TODO stop being stupid
}