const appCourse = {
    data(){
        return{
            listParticipants: [],
            selectedCountries: []
        }
    },
    async created(){
        let response = await fetch("./resultat10000metres.json");
        let jsonParticipants = await response.json();
        this.listParticipants = jsonParticipants;
        console.log(jsonParticipants);
        console.log(this.listParticipants);
    },
    computed:{
        participantsCountries() {
            return this.listParticipants.map(participant => participant.pays);
        }
    },
    methods:{
        
    }
}

Vue.createApp(appCourse).mount("#app");