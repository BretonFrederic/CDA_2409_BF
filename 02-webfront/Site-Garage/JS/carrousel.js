let slide1 = document.querySelector('#slide-1');
let slide2 = document.querySelector('#slide-2');
let slide3 = document.querySelector('#slide-3');
const slides = ['automobile-2377221_1280.jpg', 'automobile-3102299_1280.jpg', 'automobile-3345646_1280.jpg', 
                'car-139529_1280.jpg', 'car-5667103_1280.jpg', 'car-6483723_1280.jpg', 'convertible-1630448_1280.jpg', 
                'ford-1730888_1280.jpg', 'ford-mustang-4510677_1280.jpg', 'ford-mustang-4765055_1280.jpg'];

slide1.style.backgroundImage= "url(./images/carrousel/"+slides[0]+")";
slide2.style.backgroundImage= "url(./images/carrousel/"+slides[1]+")";
slide3.style.backgroundImage= "url(./images/carrousel/"+slides[2]+")";

let move = setInterval("AutoSlide()", 2000);

function AutoSlide(){
    slide1.style.left="0%";
    slide2.style.left="100%";
    slide3.style.left="200%";
    console.log(move);
    move++;
    if(move >= 5){
        slide3.style.left="-100%";
        clearInterval("move");    
    }
}


