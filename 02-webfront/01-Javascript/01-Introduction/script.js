const incrementation = document.querySelector(".incrementation");
const initialisation = document.querySelector(".initialisation");
var count = 0;

incrementation.addEventListener('click', Incrementer);
initialisation.addEventListener('click', Initialiser);

function Incrementer(){
    count++;
    document.querySelector("#compteur").innerHTML = count;
}

function Initialiser(){
    count = 0;
    document.querySelector("#compteur").innerHTML = count;
}