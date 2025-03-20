export class DownloadJson{
    static async downloadJson(url) {
        const reponse = await fetch(url);
        const data = await reponse.json();
        return data;
    }
}