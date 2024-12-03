/* Burger menu */
const itemsMenu = document.querySelectorAll('a.items-menu');
const burgerMenu = document.querySelector('.burger-menu');
const burgerIcon = document.querySelector('.burger-icon');
const menuIcon = document.querySelector('.menu-icon');
const crossIcon = document.querySelector('.cross-icon');

menuIcon.addEventListener('click', ShowHideMenu);
for(let i = 0; i < itemsMenu.length; i++){
    itemsMenu[i].addEventListener('click', HideMenu);
}

/* Burger menu */
function ShowHideMenu(){
    if(burgerMenu.style.top < "0px"){
        burgerMenu.style.top = "0px";
        crossIcon.style.visibility = "visible";
        burgerIcon.style.visibility = "hidden";
    }
    else{
        burgerMenu.style.top = "-1060px";
        crossIcon.style.visibility = "hidden";
        burgerIcon.style.visibility = "visible";
    }
}

function HideMenu(){
    burgerMenu.style.top = "-1060px";
    crossIcon.style.visibility = "hidden";
    burgerIcon.style.visibility = "visible";
}