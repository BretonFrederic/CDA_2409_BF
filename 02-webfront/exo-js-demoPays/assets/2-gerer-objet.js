// Utiliser un objet littéral existant
const laFrance = {
    "country_code": "FR",
    "country_name": "France"
}

console.log(laFrance);

const monPrincipal = document.getElementById("principal");
const monArticle = document.createElement("article");
monPrincipal.appendChild(monArticle);
const monTextArticle = document.createElement("p");
monTextArticle.textContent = `Pays 1 : ${laFrance.country_name} (${laFrance.country_code})`;
monArticle.appendChild(monTextArticle);

async function downloadJson(monUrl){
    try {
        const reponse = await fetch(monUrl);
        if (!reponse.ok) {
            throw new Error(`Erreur chargement du json : ${monUrl}`);
        }
        const paysJson = await reponse.json();
        return paysJson;
        
    } catch (error) {
        console.log(error.message);
    }
}

function afficherPays(monPays){
    const monPrincipal = document.getElementById("principal");
    const monArticle = document.createElement("article");
    monPrincipal.appendChild(monArticle);
    const monTextArticle = document.createElement("p");
    monTextArticle.textContent = `Pays 2 : ${monPays.country_name} (${monPays.country_code})`;
    monArticle.appendChild(monTextArticle);
}

const laBelgique = await downloadJson("./data/belgique.json");
afficherPays(laBelgique);