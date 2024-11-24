/* VARIABLES */

/* Burger menu */
const itemsMenu = document.querySelectorAll('a.items-menu');
const burgerMenu = document.querySelector('.burger-menu');
const burgerIcon = document.querySelector('.burger-icon');
const menuIcon = document.querySelector('.menu-icon');
const crossIcon = document.querySelector('.cross-icon');

/* Buttons scroll down */
const arrowDown = document.querySelectorAll('.center-icon svg');

/* Slide */
const toggleBtns = document.querySelectorAll('.t-btn');
const slide = ['./img/musculation.png', './img/cardio_training.png' ,'./img/natation.png', './img/boxing.png', './img/nutrition.png', './img/yoga.png', './img/zumba.png', './img/sauna.png'];
const textSlide = document.querySelectorAll('.text-slide');
let currentSlide = 0;
let timer = 6000;
let isAutoSlide = false;

/* FUNCTIONS */

/* Burger menu */
function ShowHideMenu(){
    if(burgerMenu.style.top < "0px"){
        burgerMenu.style.top = "0px";
        crossIcon.style.visibility = "visible";
        burgerIcon.style.visibility = "hidden";
        // document.querySelector('nav').style.top="0px";
        menuIcon.style.position="fixed";
        burgerMenu.style.position="fixed";
    }
    else{
        burgerMenu.style.top = "-1260px";
        crossIcon.style.visibility = "hidden";
        burgerIcon.style.visibility = "visible";
        menuIcon.style.position="absolute";
        burgerMenu.style.position="absolute";
    }
}

function HideMenu(){
    burgerMenu.style.top = "-1260px";
    crossIcon.style.visibility = "hidden";
    burgerIcon.style.visibility = "visible";
    menuIcon.style.position="static";
    // document.querySelector('body').style.position="static";
    document.querySelector('body').style.overflow="visible";
}

/* Buttons scroll down */
function MoveToConcept(){
    document.querySelector('#concept').scrollIntoView();
}
function MoveToPrograms(){
    document.querySelector('#programs').scrollIntoView();
}

/* Slide */
function SelectSlide(_slideNumber){
    console.log(timer);
    document.querySelector('#slide').style.backgroundImage="url("+slide[_slideNumber]+")";
    for(let i = 0; i < textSlide.length; i++){
        textSlide[i].style.display="none";
    }
    textSlide[_slideNumber].style.display="block";
    for(let i = 0; i < toggleBtns.length; i++){
        toggleBtns[i].style.backgroundColor="white";
    }
    toggleBtns[_slideNumber].style.backgroundColor="#26C1DC";
    currentSlide = _slideNumber;
    isAutoSlide = false;
}

function AutoSlide(){
    currentSlide+=1;
    if(currentSlide>=8){
        currentSlide=0;
    }
    SelectSlide(currentSlide);
    isAutoSlide = true;
}

function ResetTimer(){
    timer = 0;
}

/* PROCESSING */

/* Burger menu management */
menuIcon.addEventListener('click', ShowHideMenu);

for(let i = 0; i < itemsMenu.length; i++){
    itemsMenu[i].addEventListener('click', HideMenu);
}

/* ArrowDown management */
arrowDown[0].addEventListener('click', MoveToConcept);
arrowDown[1].addEventListener('click', MoveToPrograms);

/* Slider management */
if (!isAutoSlide) {
    timer = 6000;
}

setInterval("AutoSlide()", timer);

addEventListener('resize', (ev)=>{
    let screenWidth = window.innerWidth;
    if(screenWidth > "980px");
})





// window.addEventListener('mousedown', Position);
// const Position = () => { ou bien :
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
