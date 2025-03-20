import {PuissanceQuatre} from "./PuissanceQuatre.js";
const maGrille = document.getElementById("grille");

const monPuissanceQuatre = new PuissanceQuatre(maGrille, 6, 7);

monPuissanceQuatre.genererGrille();

monPuissanceQuatre.ajouterPion();
