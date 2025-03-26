const inputValidate = document.getElementById('validate');
const inputCarName = document.getElementById('carName');
const result = document.getElementById('result');

async function downloadJson(){
    try {
        const url = "./data/cars.json";
        const response = await fetch(url);
        if(!response.ok){
            throw new Error('Erreur chargement de données');
        }
    const myJson = await response.json();

    // Trouver par nom de voiture
    inputValidate.addEventListener('click', async (event)=> {
        event.preventDefault();
        const dataList = await findSelectedCars(myJson);
        await displayCars(dataList, result);        
    });

    } catch (error) {
        console.log(error.message);
    } 
}

async function findSelectedCars(dataJson){
    let suggestion = [];
    for (let index = 0; index < dataJson.length; index++) {

        if(dataJson[index].car_name.includes(inputCarName.value.trim())) {
            suggestion.push(dataJson[index]);
        }
        
        /*if(dataJson[index].car_name.substring(0, inputCarName.value.length) === inputCarName.value){
            suggestion.push(dataJson[index]);
        }*/
    }
     return suggestion;   
}

async function displayCars(myDataList, myDiv){
    myDiv.innerHTML = "";
    myDataList.forEach(currentCar => {
        const carProperties = document.createElement('ul');
        myDiv.appendChild(carProperties);
        const carTitle = document.createElement('h3');
        carTitle.textContent = currentCar.car_name;
        carProperties.appendChild(carTitle);
        addPropList(carProperties, `Numéro identifiant : ${currentCar['car_id']}`);
        addPropList(carProperties, `Modèle : ${currentCar['car_model']}`);
        addPropList(carProperties, `Cylindrée : ${currentCar['car_cylinders']}`);
        addPropList(carProperties, `Puissance(chevaux) : ${currentCar['car_horsepower']}`);
        addPropList(carProperties, `poids en kg : ${currentCar['car_weight']}`);
        addPropList(carProperties, `Pays : ${currentCar['car_origin']}`);
    });
}

function addPropList(myUl, texte){
    const carValue = document.createElement('li');
    carValue.textContent = texte;
    myUl.appendChild(carValue);
}

downloadJson();