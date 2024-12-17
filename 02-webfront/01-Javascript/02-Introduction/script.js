const sizeUp = document.querySelector(".font-size-up");
const sizeDown = document.querySelector(".font-size-down");
const inputValue = document.querySelector("#name");
const text = document.querySelector("p");

var size = 16;

sizeUp.addEventListener('click', IncreaseSize);
sizeDown.addEventListener('click', DecreaseSize);
inputValue.addEventListener('input', ChangeValue);

function IncreaseSize(){
    size++;
    if(size > 48){
        size = 16;
    }
    // document.querySelector("#number").innerHTML = size;
    text.style.fontSize = size + "px";
}

function DecreaseSize(){
    size--;
    if(size < 8){
        size = 16;
    }
    // document.querySelector("#number").innerHTML = size;
    text.style.fontSize = size + "px";
}

function ChangeValue(){
    size = inputValue.value;
    if(size > 48){
        size = 16;
    }
    else if(size < 8){
        size = 8;
    }
    text.style.fontSize = size + "px";
}