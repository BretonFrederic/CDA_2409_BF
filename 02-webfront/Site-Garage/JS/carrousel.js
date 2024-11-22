let position = document.querySelectorAll('.slide');

const slides = ['car-01.jpg', 'car-02.jpg', 'car-03.jpg', 
                'car-04.jpg', 'car-05.jpg', 'car-06.jpg', 'car-07.jpg', 
                'car-08.jpg', 'car-09.jpg', 'car-10.jpg', 'car-11.jpg', 'car-12.jpg', 'car-13.jpg'];

position[0].style.backgroundImage = "url(./images/carrousel/"+slides[0]+")";
position[1].style.backgroundImage = "url(./images/carrousel/"+slides[1]+")";
position[2].style.backgroundImage = "url(./images/carrousel/"+slides[2]+")";

const tab = [["0%", "100%", "200%"], ["0%", "100%", "-100%"], ["100%", "200%", "0%"], ["100%", "-100%", "0%"], ["200%", "0%", "100%"], ["-100%", "0%", "100%"]];

let index = 0;
let newIndex = 0;
let imgNum = 0;
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
            imgNum = slides.length-newIndex;
            position[i].style.backgroundImage = "url(./images/carrousel/"+slides[imgNum]+")";
            newIndex++;
            if(newIndex > 12){
                newIndex = 0;
            }
        }
        else{
            position[i].style.zIndex = 99999;
        }
    }
}





