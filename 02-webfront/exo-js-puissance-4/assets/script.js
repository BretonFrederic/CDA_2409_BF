import {GrillePuissanceQuatre} from "./Grille.js";
const maGrille = document.getElementById("grille");

const monJeu = new GrillePuissanceQuatre(6, 7);
monJeu.genererGrille(maGrille);
