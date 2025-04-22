import {DownloadJson} from "./DownloadJson.js";

export class Collection
{
    constructor(url){
        this.url = url;
        this.collection = [];
    }

    async genererTableau(monTBody) {
        this.collection = await DownloadJson.downloadJson(this.url);
        this.collection.forEach(pays => {
            const monTr = document.createElement("tr");
            const maRow = monTBody.appendChild(monTr);
            const maTd1 = document.createElement("td");
            const maTd2 = document.createElement("td");
            maTd1.textContent = pays.country_code;
            maTd2.textContent = pays.country_name;
            maRow.appendChild(maTd1);
            maRow.appendChild(maTd2);
        });
    }
}