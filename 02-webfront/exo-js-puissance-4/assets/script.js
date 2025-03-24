import {PuissanceQuatre} from "./PuissanceQuatre.js";
const monTBody = document.getElementById("monTbody");

const monPuissanceQuatre = new PuissanceQuatre(monTBody, 6, 7);

monPuissanceQuatre.genererGrille();

monPuissanceQuatre.ajouterPion();

