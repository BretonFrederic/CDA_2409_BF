
const questions = document.querySelectorAll('.common-questions');
const answers = document.querySelectorAll('.answers');
const questionsP =  document.querySelectorAll('.common-questions p');

for(let i = 0; i < questions.length; i++){
    questions[i].addEventListener('click', ()=>{
        answers.forEach(element => {
            console.log(element.index);
            element.style.display="none";
            questionsP.forEach(p => {
                p.innerHTML="+";
            });
        });
        answers[i].style.display="block";
        document.querySelectorAll('.common-questions p')[i].innerHTML="--";
    });
}
