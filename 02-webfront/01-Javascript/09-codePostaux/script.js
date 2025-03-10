const validation = document.querySelector("#validation");



fetch("https://arfp.github.io/tp/web/javascript/02-zipcodes/zipcodes.json")
.then(response => response.json())
.then(data => {data.forEach(element => {
        const inputCode = document.querySelector("#zip-code").value;
        // substring()
        if("59" === element.codePostal.substring(0,2)){
            const listTowns = document.querySelector("#list-towns");
            const option = document.createElement("option");
            option.value = element.nomCommune;
            listTowns.appendChild(option);
            console.log(element);
        }
    })
});