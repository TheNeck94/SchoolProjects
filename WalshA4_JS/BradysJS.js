window.onload=function() {
  document.getElementById("Q1Submit").addEventListener("click", Q1);
  document.getElementById("ex2button").addEventListener("click", ex2Function);
  document.getElementById("Q3Submit").addEventListener("click", Q3);
  document.getElementById("ex4button").addEventListener("click", ex4Function);
  document.getElementById("Q5submit").addEventListener("click", Q5);
  document.getElementById("ex6button").addEventListener("click", ex6Function);
  document.getElementById("Q7Submit").addEventListener("click", Q7);
  document.getElementById("ex8button").addEventListener("click", ex8Function);
  document.getElementById("Q9Submit").addEventListener("click", Q9);
  document.getElementById("ex10button").addEventListener("click", ex10Function);
}

function openQ(evt, Qnum) {
  var i, tabcontent, tablinks;
  tabcontent = document.getElementsByClassName("tabcontent");
  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = "none";
  }
  tablinks = document.getElementsByClassName("tablinks");
  for (i = 0; i < tablinks.length; i++) {
    tablinks[i].className = tablinks[i].className.replace(" active", "");
  }
  document.getElementById(Qnum).style.display = "block";
  evt.currentTarget.className += " active";
}
function Q1() {
    let q1min = document.getElementById('Q1Min').value;
    let q1max = document.getElementById('Q1Max').value;
    let q1result = document.getElementById('Q1result');

    if (q1min < q1max) {
        let i = q1min;
        let j = q1max;
        let result = "Results ---  ";
        for (i; i<=j; i++) {
            result += i + "\n\n";
        }
        q1result.textContent = result;
    }
}

function Q3() {
    let q3num = document.getElementById('Q3num').value;
    let q3key = document.getElementById('Q3key').value;
    let q3result = document.getElementById('Q3result');

    let q3split = q3num.split(/,/);
    let i = 0;
    let j = 0;
    for (i; i < q3split.length; i++) {
        if (parseInt(q3split[i]) == parseInt(q3key)) {
            j+= 1;
        }
    }
    q3result.textContent = j;
}

function Q5(){
    let q5num = document.getElementById('Q5num').value;
    let q5max = document.getElementById('Q5max').value;
    let q5result = document.getElementById('Q5result');
    let test = parseInt(q5max);
    //q5result.textContent = "";
    q5result.innerHTML = "";
    let max=Number(q5num)+1;
    for (i=1; i < max; i++) {
        if (i % test == 0) {
            //q5result.textContent += ("* ");
            q5result.innerHTML += ("*<br>");
        }
        else {
            
            //q5result.textContent += "*";
            q5result.innerHTML += "*";

        }
        console.log(i);
    }
}

function Q7() {
    let items = document.getElementById('Q7num').value;
    let q7base = document.getElementById('Q7base');
    let q7tax = document.getElementById('Q7tax');
    let q7total = document.getElementById('Q7total');

    let cost = 0;

    if (items <= 100) {
        cost = 5;
    }
    else if (items >= 100 && items <= 1000) {
        cost = 4;
    }
    else if (items > 1000) {
        cost = 3;
    }
    let base = items * cost
    let tax = base * 0.15
    q7base.textContent = "Base Cost: " + base;
    q7tax.textContent = "Tax: " + tax;
    q7total.textContent = "Total: " + (tax + base);
}

function Q9() {
    if (validate() == true){
    let q9num = document.getElementById('Q9num').value;
    let q9split = q9num.split('');
    results = document.getElementById('Q9result');
    results.textContent = "";
    console.log(q9split.length);
    j = -1;
    for (i = q9split.length;  i >= 0; i--) {
        
        console.log(i)
        
        if (q9split[i] == 1) {
            results.textContent += "2^" + String(j) + "+";
        }
        j++;
    }
    results.textContent = results.textContent.substr(0, results.textContent.length - 1);
    results.textContent += " = "
    k =-1;
    let h =0;
    for (i = q9split.length;  i >= 0; i--) {
        
        console.log(i)
        
        if (q9split[i] == 1) {
            f = (Math.pow(2, k))
            results.textContent += String(f) + "+";
            h += f;
        }
        k++;
    }
    results.textContent = results.textContent.substr(0, results.textContent.length - 1);

    results.textContent += "  =  " + String(h);
    console.log(h);
    q9num.value = "";    
    }
    else {
        alert("Invalid input detected, please enter a Binary Number")
    }
    
    

}

function validate() {
    let number = document.getElementById('Q9num').value
    let numSplit = number.split("");
    for (i=0; i<number.length; i++) {
        if (numSplit[i] == 1 || numSplit[i] ==0) {
            return true;
        }
        else {
            return false;
        }
    }
}


//AIDANS CODE//
      function ex2Function() {
        window.document.getElementById("ex2output").innerHTML = "";
        // read in values
        let input = window.document.getElementById("ex2text").value.split(", ");
        if (input.length === 1) {
          // if only one input (assuming because no spaces between comma and next number), split again without spaces
          input = window.document.getElementById("ex2text").value.split(",");
        }
        console.log(input);

        // display number of inputs
        //let output = window.document.getElementById("ex2output").innerHTML;
        window.document.getElementById("ex2output").innerHTML += "<ul>";
        window.document.getElementById("ex2output").innerHTML +=
          "<li>Number of Values: " + input.length + "</li>";
        console.log("<li>Number of Values: " + input.length + "</li>");
        // display total
        let total = 0;
        for (let i = 0; i < input.length; i++) {
          total += Number(input[i]);
        }
        window.document.getElementById("ex2output").innerHTML +=
          "<li>Total: " + total + "</li>";
        // display average
        let average = total / input.length;
        window.document.getElementById("ex2output").innerHTML +=
          "<li>Average: " + average + "</li>";
        // display smallest and largest
        input.sort(function (a, b) {
          return a - b;
        });
        window.document.getElementById("ex2output").innerHTML +=
          "<li>Smallest: " + input[0] + "</li>";
        window.document.getElementById("ex2output").innerHTML +=
          "<li>Largest: " + input[input.length - 1] + "</li>";
        window.document.getElementById("ex2output").innerHTML += "</ul>";
      }

      function ex4Function() {
        window.document.getElementById("ex4output").innerHTML = "";
        let numStars = window.document.getElementById("ex4input").value;
        if (numStars >= 1) {
          for (let i = 0; i < numStars; i++) {
            window.document.getElementById("ex4output").innerHTML += "*";
          }
        } else {
          alert("Number of stars must be at least 1");
        }
      }

        function ex6Function() {
        document.getElementById("ex6output").innerHTML = "";
        let input = document.getElementById("ex6input").value;
        let inputArray = input.split("");
        let total = 0;
        vowels = "aeiouyAEIOUY";
        for(let i = 0; i < inputArray.length; i++) {
            if(vowels.includes(inputArray[i])) {
                inputArray[i] = "*";
                total++;
            }
        }
        document.getElementById("ex6output").innerHTML += "<ul><li>Vowels: " + total + "</li>";
        document.getElementById("ex6output").innerHTML += "<li>" + inputArray.join("");
        }

        function ex8Function() {
            document.getElementById("ex8output").innerHTML = "";
            let input = document.getElementById("ex8input").value;
            if(input > 0) {
            let bars = input % 24;
            let boxes = (input - bars) / 24;
            document.getElementById("ex8output").innerHTML += "<ul><li>Number of Boxes: " + boxes + "</li>";
            document.getElementById("ex8output").innerHTML += "<ul><li>Number of Singles: " + bars + "</li>";
            document.getElementById("ex8output").innerHTML += "<ul><li>Cost of Boxes: " + (boxes * 32)  + "</li>";
            document.getElementById("ex8output").innerHTML += "<ul><li>Cost of Singles: " + (bars * 1.75) + "</li>";
            document.getElementById("ex8output").innerHTML += "<ul><li>Total Cost: " + ((boxes * 32) + (bars * 1.75)) + "</li></ul>";
            }
            else {
                alert("Must purchase at least 1 snickers bar")
            }
        }


        function ex10Function() {
            document.getElementById("ex10output").innerHTML = "";
            let angle1 = Number(document.getElementById("ex10input1").value);
            let angle2 = Number(document.getElementById("ex10input2").value);
            let angle3 = Number(document.getElementById("ex10input3").value);
            if (angle1 >= 180 || angle1 <= 0 || angle2 >= 180 || angle2 <= 0 || angle3 >= 180 || angle3 <= 0 || (angle1 + angle2 + angle3) != 180) {
                alert("Error: not valid triangle angles");
            }
            else if (angle1 === 90 || angle2 === 90 || angle3 === 90 ){
                document.getElementById("ex10output").innerHTML = "Right Triangle";
            }
            else if (angle1 > 90 || angle2 > 90 || angle3 > 90){
                document.getElementById("ex10output").innerHTML = "Obtuse Triangle";
            }
            else {
                document.getElementById("ex10output").innerHTML = "Acute Triangle";
            }
        }
