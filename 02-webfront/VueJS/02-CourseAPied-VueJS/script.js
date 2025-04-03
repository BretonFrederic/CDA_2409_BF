const appCourse = {
    data(){
        return {
            listParticipants: [],
            selectedCountries: [],
            bTime: ""
        }
    },
    async created(){
        try {
            let response = await fetch("./resultat10000metres.json");
            if (!response.ok) {
                throw new Error(`Reponse status : ${response.status}`);
            }
            let jsonParticipants = await response.json();
            this.listParticipants = jsonParticipants;
            this.bTime = this.bestTime();
        } catch (error) {
            console.log(error.message);
        }
    },
    computed: {
        participantsCountries() {
            return this.listParticipants.map(participant => participant.pays);
        }
    },
    methods: {
        participantsRanking(){
            return [...this.listParticipants].sort((a, b) => a.temps - b.temps).map(participant => ({
                ...participant, 
                lastname: participant.nom.split(" ")[0],
                firstname: participant.nom.split(" ")[1],
                finalTime: this.finalTime(participant.temps),
                gapTime: this.gapTime(this.bTime, participant.temps)
            })); // spread -> nouveau tableau
        },
        finalTime(timeInSec){
            let fTimeMin = Math.floor(timeInSec/60);
            let fTimeSec = timeInSec%60;
            const fTime = fTimeMin.toString().padStart(2, '0')+"min"+fTimeSec.toString().padStart(2, '0')+"s";
            return fTime;
        },
        bestTime(){
            return this.listParticipants.reduce((min, participant) => { return participant.temps > min.temps ? min : participant }).temps;
        },
        gapTime(theBestTime, participantTime){
            return `+${participantTime-theBestTime}s`;
        },
        selectedParticipants(){
            if(this.selectedCountries.length > 0){
                return [...this.participantsRanking()].filter(participant => this.selectedCountries.includes(participant.pays));
            }
            else{
                return this.participantsRanking();
            }
            
        },
        nbParticipants(){
            return this.participantsRanking().length;
        },
        winner(){
            return this.listParticipants.reduce((min, participant) => { return participant.temps > min.temps ? min : participant }).nom;
        },
        avgTime(){
            if (this.listParticipants.length === 0) return;
            const avgInSec = this.listParticipants.reduce((avg, participant) => avg + participant.temps,0)/this.listParticipants.length;
            let avgTimeMin = Math.floor(avgInSec/60);
            let avgTimeSec = Math.floor(avgInSec%60);
            const avgTime = avgTimeMin.toString().padStart(2, '0')+" minutes et "+avgTimeSec.toString().padStart(2, '0')+" secondes";
            return avgTime;
        }
    }
}

Vue.createApp(appCourse).mount("#app");