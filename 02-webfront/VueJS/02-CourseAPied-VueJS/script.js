const appCourse = {
    data(){
        return{
            listParticipants: [],
            selectedCountries: []
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
            console.log(jsonParticipants);
            console.log(this.participantsRanking());
        } catch (error) {
            console.log(error.message);
            
        }
    },
    computed:{
        participantsCountries() {
            return this.listParticipants.map(participant => participant.pays);
        }
    },
    methods:{
        participantsRanking(){
            return [...this.listParticipants].sort((a, b) => a.temps - b.temps); // spread -> nouveau tableau
        }
    }
}

Vue.createApp(appCourse).mount("#app");