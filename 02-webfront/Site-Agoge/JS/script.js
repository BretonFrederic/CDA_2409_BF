/* VARIABLES */

const itemsMenu = document.querySelectorAll('a.items-menu');
const burgerMenu = document.querySelector('.burger-menu');
const burgerIcon = document.querySelector('.burger-icon');
const menuIcon = document.querySelector('.menu-icon');
const crossIcon = document.querySelector('.cross-icon');
const arrowDown = document.querySelectorAll('.center-icon svg');

/* FUNCTIONS */

function ShowHideMenu(){
    if(burgerMenu.style.top < "0px"){
        burgerMenu.style.top = "0px";
        crossIcon.style.visibility = "visible";
        burgerIcon.style.visibility = "hidden";
    }
    else{
        burgerMenu.style.top = "-1260px";
        crossIcon.style.visibility = "hidden";
        burgerIcon.style.visibility = "visible";
    }
}

function HideMenu(){
    burgerMenu.style.top = "-1260px";
    crossIcon.style.visibility = "hidden";
    burgerIcon.style.visibility = "visible";
}

function MoveDown(){
    document.querySelector('#inscription').scrollIntoView();
}

/* PROCESSING */

/* Burger menu management */
menuIcon.addEventListener('click', ShowHideMenu);

for(let i = 0; i < itemsMenu.length; i++){
    itemsMenu[i].addEventListener('click', HideMenu);
}

/* ArrowDown management */
for(let i = 0; i < arrowDown.length; i++){
arrowDown[i].addEventListener('click', MoveDown);
}

// window.addEventListener('mousedown', Position);

// function Position(){
//     let arrowPosX = arrowDown.offsetLeft+(arrowDown.offsetWidth/2);
//     let arrowPosY = arrowDown.offsetTop+(arrowDown.offsetHeight/2);
//     let mouseX = 0;
//     let mouseY = 0;
//     /* update mouse position */
//     window.addEventListener('mousemove', (e)=>{
//         mouseX = e.clientX;
//         mouseY = e.clientY;

//     /* Pythagore */
//     let distMouse = Math.sqrt(Math.pow(Math.abs(mouseX-arrowPosX),2)+Math.pow(Math.abs(mouseY-arrowPosY),2));
//     console.log(distMouse);

//     })
// }
