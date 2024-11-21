let previewSlide = document.querySelector('#preview-slide');
let activeSlide = document.querySelector('#active-slide');
let nextSlide = document.querySelector('#next-slide');
const slides = ['automobile-2377221_1280.jpg', 'automobile-3102299_1280.jpg', 'automobile-3345646_1280.jpg', 
                'car-139529_1280.jpg', 'car-5667103_1280.jpg', 'car-6483723_1280.jpg', 'convertible-1630448_1280.jpg', 
                'ford-1730888_1280.jpg', 'ford-mustang-4510677_1280.jpg', 'ford-mustang-4765055_1280.jpg'];

previewSlide.style.backgroundImage= "url(./images/carrousel/"+slides[0]+")";
activeSlide.style.backgroundImage= "url(./images/carrousel/"+slides[1]+")";
nextSlide.style.backgroundImage= "url(./images/carrousel/"+slides[2]+")";

setInterval("AutoSlide()", 2000);
setInterval("InitSlide()", 4000);

function AutoSlide(){
    previewSlide.style.left="200%";
    activeSlide.style.left="100%";
    nextSlide.style.left="0%";
    console.log(getInterval);
}

function InitSlide(){
    previewSlide.style.left="-100%";
}



