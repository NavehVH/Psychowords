
var isFlipped = false;

//var card = document.querySelector('.card-flip');
//.addEventListener('click', function () {
//    CardVisibleChange();
//    //card.classList.toggle('is-flipped');
//});

function CardVisibleChange() {

    if (isFlipped == false) {
        document.getElementById('card-back').style.display = 'initial';
        document.getElementById('card-front').style.display = 'none';
        isFlipped = true;
    }
    else {
        document.getElementById('card-front').style.display = 'initial';
        document.getElementById('card-back').style.display = 'none';
        isFlipped = false;
    }
}