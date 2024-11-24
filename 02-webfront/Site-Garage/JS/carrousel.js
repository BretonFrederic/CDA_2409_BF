// Récupère les 3 éléments de class slide du carrousel dans un tableau position
let position = document.querySelectorAll('.slide');

// Tableau images
const slides = ['car-01.jpg', 'car-02.jpg', 'car-03.jpg', 'car-04.jpg', 
                'car-05.jpg', 'car-06.jpg', 'car-07.jpg', 'car-08.jpg', 
                'car-09.jpg', 'car-10.jpg', 'car-11.jpg', 'car-12.jpg', 
                'car-13.jpg'];

// Initialisation du backgroundImage des 3 slides
position[0].style.backgroundImage = "url(./images/carrousel/"+slides[0]+")";
position[1].style.backgroundImage = "url(./images/carrousel/"+slides[1]+")";
position[2].style.backgroundImage = "url(./images/carrousel/"+slides[2]+")";

// Tableau de séquences d'animation et réinitialisation des slides
const tab = [["0%", "100%", "200%"], ["0%", "100%", "-100%"], 
             ["100%", "200%", "0%"], ["100%", "-100%", "0%"], 
             ["200%", "0%", "100%"], ["-100%", "0%", "100%"]];

// Index max du tableau images
const maxIndex = slides.length-1;

// Initialisation de l'index de la séquence active
let index = 0;

// Appel de la fonction AutoSlide dans un setInterval
let interval = setInterval(AutoSlide, 1000);

// Initialisation de l'index de l'image suivante
let newIndex = 12;

function AutoSlide(){
    // Quand interval est sup à 3 (donc slide transition = 3s css terminée) on incrémente l'index de la séquence active
    interval += 1;
    if(interval > 3){
        interval = 0;
        index++;
        if(index > 5){
            index = 0;
        }
        // Index impair de la séquence on change l'index de l'image du slide à 200% (plus à droite)
        if(index%2 != 0){
            newIndex--;
            if(newIndex < 0){
                newIndex = 12;
            }
            console.log("newIndex : "+newIndex);
        }
        console.log("Index : "+index);
    }

    // Mise à jour de la séquence en cours
    for(let i = 0; i < 3; i++){
        position[i].style.left = tab[index][i];

        // Quand une slide atteint position 200% zIndex inférieur pour initialisation position à gauche 
        if(position[i].style.left === "200%"){
            position[i].style.zIndex = -99;

            position[i].style.backgroundImage = "url(./images/carrousel/"+slides[newIndex]+")";
        }
        else{
            position[i].style.zIndex = 999;
        }
    }
}





