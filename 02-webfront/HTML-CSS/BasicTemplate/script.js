
var navbar = document.getElementById("navigation");
var burgerBtn = document.getElementById("open-btn");
var crossBtn = document.getElementById("close-btn");

burgerBtn.onclick = function OpenClose(){
    navbar.style.left = "0px";
};

crossBtn.onclick = function OpenClose(){
    navbar.style.left = "-240px";
};



