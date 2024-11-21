let position = document.querySelectorAll('.slide');

const slides = ['automobile-2377221_1280.jpg', 'automobile-3102299_1280.jpg', 'automobile-3345646_1280.jpg', 
                'car-139529_1280.jpg', 'car-5667103_1280.jpg', 'car-6483723_1280.jpg', 'convertible-1630448_1280.jpg', 
                'ford-1730888_1280.jpg', 'ford-mustang-4510677_1280.jpg', 'ford-mustang-4765055_1280.jpg'];

position[0].style.backgroundImage = "url(./images/carrousel/"+slides[0]+")";
position[1].style.backgroundImage = "url(./images/carrousel/"+slides[1]+")";
position[2].style.backgroundImage = "url(./images/carrousel/"+slides[2]+")";

const tab = [["0%", "100%", "200%"], ["0%", "100%", "-100%"], ["100%", "200%", "0%"], ["100%", "-100%", "0%"], ["200%", "0%", "100%"], ["-100%", "0%", "100%"]];

let index = 0;
let moveNext = setInterval(AutoSlide, 1000);

function AutoSlide(){
    moveNext = moveNext + 1;
    if(moveNext > 3){
        moveNext = 0;
        index++;
        if(index > 5){
            index = 0;
        }
    }
    for(let i = 0; i < 3; i++){
        position[i].style.left = tab[index][i];
        if(position[i].style.left === "200%"){
            position[i].style.zIndex = -99;
        }
        else{
            position[i].style.zIndex = 99999;
        }
    }
}





