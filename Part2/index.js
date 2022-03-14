window.onload = function main() {
    let xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        
        if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
            buildQuiz(xmlhttp.responseText); // do something when server responds
        }
    };
    xmlhttp.open("GET", "LOTRQuiz.json", true);
    xmlhttp.send();
    document.getElementById("btnSubmit").addEventListener("click", submit);
}
function buildQuiz(content) {
    let QUIZ = JSON.parse(content);
    let title = document.getElementById("title");
    let questionDiv = document.getElementById("questions");
    let tabs = document.getElementById("tabs");
    let count = 0;
    let questions =QUIZ.questions;
    title.innerHTML = "<h3>" + QUIZ.title + "<h3>";
    
    
    for (i=0;i<questions.length; i++) {
        choices = getChoices((questions[i].choices.length), questions[i]);
        key = getAnswer(questions[i]);
            questionDiv.innerHTML += 
            "<div class=\"tabcontent\" id=\"" + (i + 1) +"\">" +
                  "<div class=\"col\">" +
                     "<div class=\"row\" id=\"questionNum\">" +
                         "<h4> Question " + (i +1) + "<h4>" +
                     "</div><div class=\"row questionText\">" + (questions[i].questionText) + "</div>" +
                    "</div><div class=\"row choices\">" + choices + "</div>" +
                    "<div class=\"answer\">" + key + "</div>"
                 "</div>" +
             "</div>";
        }
    for (k=0; k<questions.length; k++) {
        tabs.innerHTML += "<div class=\"tab\"><button class=\"tablinks\"id =\"tab" + (k+1) + "\" onclick=openTab(click," + (k+1) +")>Question" + (k+1) + "</button></div>";
    }
    
         
}
function getAnswer(question){
    let answer = question.answer;
    let choices = question.choices;
    let Ranswer = "";
    Ranswer += choices[answer];
    return Ranswer;
}
let index = 0;
function getChoices(count, question) {
    let options = "";
    index++;
    for (j=0;j<count; j++) {
        options += "<label><input class=\"radbtn\" type=\"radio\" id=\"btn" + j +"\" name=\"fav_language" + index + "\"" + "\" value=\"" + j + "\">" + question.choices[j] + "</label></input>"
    }
    return options;
}
function openTab(evt, questionName) {
  // Declare all variables
  var i, tabcontent, tablinks;

  // Get all elements with class="tabcontent" and hide them
  tabcontent = document.getElementsByClassName("tabcontent");
  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = "none";
  }

  // Get all elements with class="tablinks" and remove the class "active"
  tablinks = document.getElementsByClassName("tablinks");
  for (i = 0; i < tablinks.length; i++) {
    tablinks[i].className = tablinks[i].className.replace(" active", "");
  }

  // Show the current tab, and add an "active" class to the button that opened the tab
  document.getElementById(questionName).style.display = "block";
}

function submit() {
    let valid = validate()
    if (valid ==true){
    let answers = checkAnswer();
    let guessesHold = checkChecked();
    let guesses = guessesHold.split(", ");
    let check = document.getElementsByClassName("answer"); //an array of the correct answers
    let tabs = document.getElementsByClassName("tabcontent");
    let qText = document.getElementsByClassName("row questionText");
    let scoreOutput = document.getElementById("score");
    let count = tabs.length;
    let res = "";
    let score = 0;
    res += "<table id=\"answerSheet\"> <tr> <th>Question #</th> <th>Question Text</th> <th>Correct Answer</th> <th>Your Answer</th> <th>Score</th> </tr>";
    for(i = 0; i < count; i++)
    {
        if (i == answers[i]) {
        res += "<tr class=\"correct\"> <td>Q" + (i+1) + "</td> <td>" + qText[i].textContent + "</td> <td>" + check[i].textContent + "</td> <td>"+ guesses[i] +"</td> <td>"+ 1 +"</td> </tr>";
            score ++;
    }
        else {
            res += "<tr class=\"incorrect\"> <td>Q" + (i+1) + "</td> <td>" + qText[i].textContent + "</td> <td>" + check[i].textContent + "</td> <td>"+ guesses[i] +"</td> <td>"+ 0 +"</td> </tr>";
        }
    }

    res += "</table>";
    document.getElementById("results").innerHTML = res;
    scoreOutput.textContent = "Your Score is: " + score + "/" + count;
}
    else {
        alert("You Must Answer All Questions Before Submitting");
    }
    
    
    
    
    
}
function checkAnswer() {
    let correctAnswerIndex = []; //starts as an empty array, takes index positions of correct questions
    let tabs = document.getElementsByClassName("tabcontent");//all of the questions
    let count = tabs.length; //a count of all of the questions
    let check = document.getElementsByClassName("answer"); //an array of the correct answers
    let choices = document.getElementsByClassName("row choices");//an array of each questions options
    for (i=0; i<count; i++) { //iterate through each question
            for(k=0; k<choices[i].children.length; k++)  { //iterate through the list of choices for each question
                if ((choices[i].children[k]).children[0].checked == true){ //checks to see if the rad button is checked
                    if (check[i].textContent === choices[i].children[k].textContent) { //checks to see if checked button is correct answer
                        correctAnswerIndex += i;//takes the index position of the question, to later label as correct
                        k=0;
                        break;
                    }
                    else {
                        correctAnswerIndex += 0; //not used in output, just a placeholder
                    }
                }
            }
    }
    return correctAnswerIndex;

}

function checkChecked() {//aka mic check
    let tabs = document.getElementsByClassName("tabcontent");
    let count = tabs.length;
    let choices = document.getElementsByClassName("row choices");
    let output = [];

    for(i=0; i<count; i++){
        for(k=0; k<choices[i].children.length; k++){ //iterate through the list of choices for each question
                if ((choices[i].children[k]).children[0].checked == true){ //checks to see if the rad button is checked
                    output += (choices[i].children[k].textContent) + ", ";
                }
            }
        }
        console.log(output);
        return output;
}
function validate() {
    let valid = false;
    let tabs = document.getElementsByClassName("tabcontent");
    let count = tabs.length;
    let choices = document.getElementsByClassName("row choices");
    let x=0;
    for(let i=0; i<count; i++){
        
        for(k=0; k<choices[i].children.length; k++){ //iterate through the list of choices for each question
            
                if ((choices[i].children[k]).children[0].checked == true){ //checks to see if the rad button is checked
                    x++;
                    break;
                }

            }
        }
        if (x == i) {
            valid = true;
        }
        return valid;
}
