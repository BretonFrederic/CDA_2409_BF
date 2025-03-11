const search = document.querySelector("#zip-code");
const validation = document.querySelector("#validation");
const dataList = document.querySelector("#data-list");
const suggestions = document.querySelector("#suggestions");

// function displaySuggestions(){
//     const zipCode = document.querySelector("#zip-code").value;
//     if(zipCode.length >= 2){
//         townsList.forEach(element => {
//             if(zipCode == element.codePostal.substring(0,zipCode.length)){
//                 const option = document.createElement("option");
//                 option.setAttribute("class", "town");
//                 option.value = element.codePostal;
//                 suggestions.appendChild(option);
//                 const text = document.createTextNode(element.nomCommune);
//                 option.appendChild(text);
//             }
//         });
//     }
//     else{
//         const allSuggestions = document.querySelectorAll(".town");
//         allSuggestions.forEach(element =>{
//             element.remove();
//         });
//     }
//     return zipCode;
// }

function fillSelect(townslist){
    townslist.forEach(element => {
        const option = document.createElement("option");
        option.setAttribute("class", "town");
        option.value = element.codePostal;
        const cpList = document.querySelector("#cp-list").appendChild(option);
        const text = document.createTextNode(element.nomCommune);
        option.appendChild(text);
        return cpList;
    });
}

function checkZipCode(townslist){
    const zipCode = document.querySelector("#zip-code").value;
    if(zipCode.length >= 2){
        console.log(townslist.filter(element => zipCode == element.codePostal.substring(0,zipCode.length)));
    }
}

document.querySelector("#cp-list").addEventListener('change', ()=>{
    const mySelection = document.querySelector("#cp-list");
    document.querySelector("#info-selection").textContent = mySelection.options[mySelection.selectedIndex].value;
});


fetch("https://arfp.github.io/tp/web/javascript/02-zipcodes/zipcodes.json")
.then(response => {
    return response.json();
})
.then((data) => {
    townsList = data;
    fillSelect(townsList);
    
    document.querySelector("#zip-code").addEventListener('input', ()=>{checkZipCode(townsList)});
});

    // search.addEventListener('input', function displayInfo(){
    //     const selection = displaySuggestions();

    //     validation.addEventListener('click', function checkInput(){
    //             infoTown.innerHTML = `ville : ${element.nomCommune} <br>code commune : ${element.codeCommune} <br>libelle d'acheminement : ${element.libelleAcheminement} <br>code postal ${element.codePostal}`;
    //         });
    //     });
