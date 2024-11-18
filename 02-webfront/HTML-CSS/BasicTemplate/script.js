
var navbar = document.getElementById("navigation");
var burgerBtn = document.getElementById("open-btn");
var crossBtn = document.getElementById("close-btn");

burgerBtn.onclick = function OpenClose(){
    navbar.style.left = "0px";
};

crossBtn.onclick = function OpenClose(){
    navbar.style.left = "-380px";
};

addEventListener('resize', BurgerMenuOff);

function BurgerMenuOff(){
    let screenWidth = window.innerWidth;
    if(screenWidth >= 1280){
        navbar.style.left = "-380px";
        console.log("resize");
    }
}



