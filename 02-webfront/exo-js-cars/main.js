
const inputValidate = document.getElementById('validate');
const inputCarName = document.getElementById('carName');

async function downloadJson(){
    try {
        const url = "./data/cars.json";
        const response = await fetch(url);
        if(!response.ok){
            throw new Error('Erreur chargement de données');
        }
    const myJson = await response.json();

    // Trouver par nom de voiture
    inputValidate.addEventListener('click', () => {
        const mySelection = findCars(myJson);
        console.log(mySelection);
        const selection = myJson.filter(car => car.car_name === inputCarName.value);
        console.log(selection);
    });

    } catch (error) {
        console.log(error.message);
    } 
}

// Fonction selection cars
async function findCars(myJsonFile){
    //const inputCarName = document.getElementById('carName');
    const selection = [];
    if(myJsonFile.car_id === inputCarName.value){
        selection = myJsonFile.filter(car => car.car_id === inputCarName.value);
    }
    else if(myJsonFile.car_name === inputCarName.value){
        selection = myJsonFile.filter(car => car.car_name === inputCarName.value);
        console.log(selection);
    }
    else if(myJsonFile.car_model === inputCarName.value){
        selection = myJsonFile.filter(car => car.car_model === inputCarName.value);
    }
    else if(myJsonFile.car_cylinders === inputCarName.value){
        selection = myJsonFile.filter(car => car.car_cylinders === inputCarName.value);
    }
    else if(myJsonFile.car_horsepower === inputCarName.value){
        selection = myJsonFile.filter(car => car.car_horsepower === inputCarName.value);
    }
    else if(myJsonFile.car_weight === inputCarName.value){
        selection = myJsonFile.filter(car => car.car_weight === inputCarName.value);
    }
    else if(myJsonFile.car_origin === inputCarName.value){
        selection = myJsonFile.filter(car => car.car_origin === inputCarName.value);
    }
    console.log(selection);
    
    return selection; 
}

downloadJson();