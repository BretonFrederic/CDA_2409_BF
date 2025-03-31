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
            console.log(this.newFullname+" "+this.newGrade);
            this.listStudents = jsonStudents.push({fullname:"test name", grade:16});
        }
    }
}

Vue.createApp(appEvaluation).mount("#app");