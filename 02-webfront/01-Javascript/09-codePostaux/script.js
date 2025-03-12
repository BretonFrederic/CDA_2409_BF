const search = document.querySelector("#zip-code");
const validation = document.querySelector("#validation");
const suggestions = document.querySelector("#suggestions");

function displaySuggestions(){
    const zipCode = document.querySelector("#zip-code").value;
    if(zipCode.length >= 2){
        townsList.forEach(element => {
            if(zipCode == element.codePostal.substring(0,zipCode.length)){
                const option = document.createElement("option");
                option.setAttribute("class", "town");
                option.value = `${element.codePostal} ${element.nomCommune}`;
                suggestions.appendChild(option);
            }
        });
    }
    else{
        const allSuggestions = document.querySelectorAll(".town");
        allSuggestions.forEach(element =>{
            element.remove();
        });
    }
    return zipCode;
}




fetch("https://arfp.github.io/tp/web/javascript/02-zipcodes/zipcodes.json")
.then(response => {
    return response.json();
})
.then((data) => {
    townsList = data;
    search.addEventListener('input', function displayInfo(){
        const selection = displaySuggestions();

        validation.addEventListener('click', function checkInput(){
            console.log(selection.substring(6,));
            // comparer la selection avec la liste
            townsList.forEach(element => {
                if(
                    selection.slice(6).match(element.nomCommune) &&
                    selection.substring(0, 5).match(element.codePostal)                 
                ){
                    const infoTown = document.querySelector("#info-selection");
                    console.log(element);
                    
                    infoTown.innerHTML = `ville : ${element.nomCommune} <br>code commune : ${element.codeCommune} <br>libelle d'acheminement : ${element.libelleAcheminement} <br>code postal ${element.codePostal}`;
                }
            });
        });
    });
});