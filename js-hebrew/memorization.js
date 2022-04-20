﻿
var Interval = document.getElementById('Interval').value;
var cardsFront = document.getElementsByClassName('card-front');
var cardsBack = document.getElementsByClassName('card-back');

if (cardsFront != null && Interval != "false") {
    autoFlip();
}

function flipCard(clicked) {
    var activeCard = 0;
    var elements = document.getElementsByClassName('carousel-li');
    for (var i = 0; i < elements.length; i++) {
        var myClasses = elements[i].className.split(' ');
        for (var j = 0; j < myClasses.length; j++) {
            if (myClasses[j] == "active") {
                activeCard = i;
                break;
            }
        }
    }

    if (clicked == false) {
        for (var i = 0; i < cardsFront.length; i++) {
            cardsFront[i].className = "card-front";
            cardsBack[i].className = "card-back displayNone";
        }
    }
    else if (cardsBack[activeCard].className.includes('displayNone')) {
        cardsBack[activeCard].className = "card-back";
        cardsFront[activeCard].className = "card-front displayNone";
    }
    else {
        cardsBack[activeCard].className = "card-back displayNone";
        cardsFront[activeCard].className = "card-front";
    }
}

function setData() {
    try {
        PageMethods.GetData(4, onSucess, onError);
        function onSucess(results) {
            alert(results.length);
        }
        function onError(xhr, status, error) {
            alert(xhr + ", " + status + ", " + error);
        }
    } catch (e) {
        alert(e);
    }
    return false;
}

var interval = document.getElementById('carouselExampleIndicators');

function autoFlip() {
    for (var i = 0; i < cardsFront.length; i++) {
        cardsFront[i].className = "card-front displayNone";
        cardsBack[i].className = "card-back";
    }
}