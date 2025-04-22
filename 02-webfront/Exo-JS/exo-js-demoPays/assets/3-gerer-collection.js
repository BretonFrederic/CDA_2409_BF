import {Collection} from "./Collection.js";
const monTBody = document.getElementById("mesPays");

const mesPays = new Collection("./data/collectionPays.json");
const table = await mesPays.genererTableau(monTBody);
console.log(mesPays.collection);


