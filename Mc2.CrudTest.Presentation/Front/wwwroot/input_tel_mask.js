/**
       * charCode [48,57] 	Numbers 0 to 9
       * keyCode 46  			"delete"
       * keyCode 9  			"tab"
       * keyCode 13  			"enter"
       * keyCode 116 			"F5"
       * keyCode 8  			"backscape"
       * keyCode 37,38,39,40	Arrows
       * keyCode 10			(LF)
       */
function validate_int(myEvento) {
    if (
        (myEvento.charCode >= 48 && myEvento.charCode <= 57) ||
        myEvento.keyCode == 9 ||
        myEvento.keyCode == 10 ||
        myEvento.keyCode == 13 ||
        myEvento.keyCode == 8 ||
        myEvento.keyCode == 116 ||
        myEvento.keyCode == 46 ||
        (myEvento.keyCode <= 40 && myEvento.keyCode >= 37)
    ) {
        dato = true;
    } else {
        dato = false;
    }
    return dato;
}

function phone_number_mask() {
    var myMask = "+__ ___ ___ ____";
    var myCaja = document.getElementById("phone");
    var myText = "";
    var myNumbers = [];
    var myOutPut = "";
    var theLastPos = 1;
    myText = myCaja.value;
    //get numbers
    for (var i = 0; i < myText.length; i++) {
        if (!isNaN(myText.charAt(i)) && myText.charAt(i) != " ") {
            myNumbers.push(myText.charAt(i));
        }
    }
    //write over mask
    for (var j = 0; j < myMask.length; j++) {
        if (myMask.charAt(j) == "_") {
            //replace "_" by a number
            if (myNumbers.length == 0) myOutPut = myOutPut + myMask.charAt(j);
            else {
                myOutPut = myOutPut + myNumbers.shift();
                theLastPos = j + 1; //set caret position
            }
        } else {
            myOutPut = myOutPut + myMask.charAt(j);
        }
    }
    document.getElementById("phone").value = myOutPut;
    document
        .getElementById("phone")
        .setSelectionRange(theLastPos, theLastPos);
}

document.getElementById("phone").onkeypress = validate_int;
document.getElementById("phone").onkeyup = phone_number_mask;