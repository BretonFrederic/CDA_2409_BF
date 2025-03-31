const appEvaluation = {
    data(){
        return{
           listStudents: [],
           failinGrade: 12,
           newFullname: "",
           newGrade: ""
        }
    },
    async created(){
        let response = await fetch("./eval.json");
        let jsonStudents = await response.json();
        console.log(jsonStudents);
        // this.listStudents = jsonStudents.push({fullname:"test name", grade:16});
        
        this.listStudents = jsonStudents.sort((a, b)=> b.grade - a.grade).map(student => ({
            ...student,
            lastname: student.fullname.split(" ")[0] || "",
            firstname: student.fullname.split(" ")[1] || "",
            success: this.examSuccess(student)
         }));

        // this.listStudents.forEach(student => {
        //    student["lastname"] = student.fullname.split(" ")[0];
        //    student["firstname"] = student.fullname.split(" ")[1];
        // }); 
    },
    computed:{
        countStudents(){
            return this.listStudents.length;
        },
        calculateGradeAvg(){
            const sumGrades = this.listStudents.reduce((sum, student) => sum + student.grade, 0);
            const gradeAverage = parseFloat((sumGrades/this.listStudents.length).toFixed(2));
            return gradeAverage;
        },
        calculateAboveAvgGrades(){
            const numberStudents = this.listStudents.filter(student => student.grade > this.calculateGradeAvg).length;
            return numberStudents;
        }
    },
    methods:{
        examSuccess(currentStudent){
            if(currentStudent.grade < this.failinGrade){
                return "Non";
            }
            else{
                return "Oui";
            }
        },
        addStudent(){
            // Vérifier que le formulaire est complété
            const regexName = /^[a-zàâäéèêëïîôöùûüÿç]{2,20}\s[a-zàâäéèêëïîôöùûüÿç]{2,20}$/i;
            if(regexName.test(this.newFullname) && this.newGrade >= 0 && this.newGrade <= 20){

                // split du fullname pour obtenir lastname et firstname
                const lName = this.newFullname.split(" ")[0].charAt(0).toUpperCase()+this.newFullname.split(" ")[0].substring(1).toLowerCase();
                const fName = this.newFullname.split(" ")[1].charAt(0).toUpperCase()+this.newFullname.split(" ")[1].substring(1).toLowerCase();

                const myGrade = parseFloat(this.newGrade);
                console.log(myGrade);
                
                // Création d'un nouvel objet étudiant
                const newStudent = {
                    fullname: this.newFullname,
                    grade: myGrade,
                    lastname: lName,
                    firstname: fName,
                    success: myGrade < this.failinGrade ?"Non":"Oui"
                }
                this.listStudents.push(newStudent);

                // Trier par notes
                this.listStudents.sort((a,b) => b.grade - a.grade);
            }
            else{
                console.log("champ incomplet");
                return;
            }
        }
    }
}

Vue.createApp(appEvaluation).mount("#app");