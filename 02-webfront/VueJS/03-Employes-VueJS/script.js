const appEmployes = {
    data(){
        return {
            listEmployes: []
        }
    },
    async created() {
        try {
            let response = await fetch("https://arfp.github.io/tp/web/javascript2/03-employees/employees.json");
            if(!response.ok) {
                throw new Error(`Reponse status : ${response.status}`);
            }
            let jsonEmployes = await response.json();
            this.listEmployes = jsonEmployes.data;
        }
        catch(error){
            console.log(error.message);
        }
    },
    computed:{
        dataEmp(){
            if(this.listEmployes.length === 0) return;
            return [...this.listEmployes].map(employe =>({
                 ...employe,
                 email: employe.employee_name.split(" ")[0].charAt(0).toLowerCase()
            }));
        }
    }
}

Vue.createApp(appEmployes).mount("#app");