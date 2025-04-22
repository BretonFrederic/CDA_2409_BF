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
                 email: `${employe.employee_name.split(" ")[0].charAt(0).toLowerCase()}.${employe.employee_name.split(" ")[1].toLowerCase()}@email.com`,
                 monthlySal: employe.employee_salary/12,
                 birthDate: `${new Date().getFullYear() - employe.employee_age}`
            }));
        },
        totalEmployes(){
            if(this.listEmployes.length === 0) return;
            return this.dataEmp.length;
        },
        totalSalaries(){
            if(this.listEmployes.length === 0) return;
            const sumSalaries = [...this.dataEmp].reduce((sum, emp) => {
                return sum + emp.monthlySal
            }, 0);
            return sumSalaries;
        }
    }
}

Vue.createApp(appEmployes).mount("#app");