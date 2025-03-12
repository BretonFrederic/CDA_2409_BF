const validation = document.querySelector("#validation");

function fillSelect(townslist){
    townslist.forEach(element => {
        const option = document.createElement("option");
        option.setAttribute("class", "town");
        option.value = element.codePostal;
        document.querySelector("#cp-list").appendChild(option);
        const text = document.createTextNode(element.nomCommune);
        option.appendChild(text);
    });
}

function checkZipCode(townslist){
    const zipCode = document.querySelector("#zip-code").value;
    if(zipCode.length >= 2){
        const newlist = townslist.filter(element => zipCode == element.codePostal.substring(0,zipCode.length));
        const allSuggestions = document.querySelectorAll(".town");
        allSuggestions.forEach(element =>{
            element.remove();
        });
        fillSelect(newlist);
    }
}

document.querySelector("#cp-list").addEventListener('change', ()=>{
    const mySelection = document.querySelector("#cp-list");
    document.querySelector("#info-selection").innerHTML = `Code postal de la ville : ${mySelection.options[mySelection.selectedIndex].value} <br><br>Cliquer sur valider`;
});

console.log(document.querySelector("#info-selection").value);

fetch("https://arfp.github.io/tp/web/javascript/02-zipcodes/zipcodes.json")
.then(response => {
    return response.json();
})
.then((data) => {
    townsList = data;
    fillSelect(townsList);
    document.querySelector("#zip-code").addEventListener('input', ()=>{
        checkZipCode(townsList);
        validation.addEventListener('click', function displayInfo(){
            const selected = document.querySelector("#cp-list");
            const myTown = townsList.find(element => element.nomCommune == selected.options[selected.selectedIndex].text);
            if(myTown !== undefined){
                document.querySelector("#info-town").innerHTML = `ville : ${myTown.nomCommune} <br>code commune : ${myTown.codeCommune} <br>libelle d'acheminement : ${myTown.libelleAcheminement} <br>code postal ${myTown.codePostal}`;
            }
        });
    });
});
