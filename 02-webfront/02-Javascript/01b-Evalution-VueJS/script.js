const appEvaluation = {
    data(){
        return{
           listStudents: []
        }
    },
    async created(){
        let response = await fetch("./eval.json");
        let jsonStudents = await response.json();
        this.listStudents = jsonStudents.sort((a, b)=> b.grade - a.grade);
    }
}

Vue.createApp(appEvaluation).mount("#app");