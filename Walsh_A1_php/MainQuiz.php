<!DOCTYPE html>
<!--
Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
Click nbfs://nbhost/SystemFileSystem/Templates/Project/PHP/PHPProject.php to edit this template
-->
<html>
    <head>
        <meta charset="UTF-8">
        <title>Walsh Quiz App php</title>
        <style>
            .container {
                margin: 10%;
            }
            .question {
                padding: 15px;
            }
            .question *{
                margin: 10px;
            }
        </style>
    </head>
    <body>
        <?php
        session_start();
        include 'FileUtils.php';
        include 'ChromePhp.php';
        $fileName = $_POST["Quiz"];
        
        $_SESSION['fileName'] = strval($fileName);
        
        $outputHTML = "";
        $arr = readFileIntoString($fileName);
        $quiz = json_decode($arr, true);
        $numOfQuestions = count($quiz["questions"]);
        ChromePhp::log($fileName);
        
        $quizTopper = "<div class='container'><h3>Quiz Title: " . $quiz["title"] . "</h3> <h4> Number of Questions: " . $numOfQuestions . " </h4>";
        
        $quizQuestions = "<div>";
        for ($i = 0; $i < $numOfQuestions; $i++){
            $quizQuestions .= "<div class='question'><p>" . $quiz["questions"][$i]["questionText"] . "</p><form action='Results.php' method='POST'>";
            for ($j = 0; $j < count($quiz["questions"][$i]["choices"]); $j++){
                $quizQuestions .= "<input type='radio' name='userAnswer".$i."' value='".$j."'>".$quiz["questions"][$i]["choices"][$j]."</input>";                                                     
            }
            $quizQuestions .= "</div>";
        }
        
        $quizQuestions .= "<button type='submit'>Submit</button></form></div></div>";
        
        $outputHTML .= $quizTopper . $quizQuestions;
        
        echo $outputHTML;
        $_SESSION['outputHTML'] = $outputHTML;
        ?>
    </body>
</html>