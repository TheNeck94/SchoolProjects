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
            .correct {
                padding: 15px;
                background-color: green;
                margin: 25px;
            }
            .incorrect {
                padding: 15px;
                background-color: red;
                margin: 25px;
            }
        </style>
    </head>
    <body>
        <h2>Results: </h2>
        <?php
        session_start();
        include 'FileUtils.php';
        include 'ChromePhp.php';
        
        //var_dump($_SESSION);
        $fileName = $_SESSION['fileName'];
        $arr = readFileIntoString($fileName);
        $quiz = json_decode($arr, true);
        $userAnswerArr = array();
        $outputHTML = "";
        $correctAnswers = 0;
        //Get User Answers from Form
        foreach($_POST as $key => $value){
            if(substr($key, 0, 10) == "userAnswer"){
                $temp = substr($key,0, 11);
                array_push($userAnswerArr, $_POST[$temp]);
            }
        }
        if(count($userAnswerArr) != count($quiz['questions'])){
            header("Location: http://localhost/Brady/Walsh_A1_php/error.php");
        }
        for ($i = 0; $i < count($quiz['questions']); $i++){
            if($quiz['questions'][$i]['answer'] == $userAnswerArr[$i]){
                $outputHTML .= "<div class='correct'>" . $quiz['questions'][$i]['questionText'];
                $correctAnswers ++;
            }
            else {
                $outputHTML .= "<div class='incorrect'>" . $quiz['questions'][$i]['questionText'];
            }
            $outputHTML .= "<ul>";
            for ($j = 0; $j < count($quiz["questions"][$i]["choices"]); $j++){
                $outputHTML .= "<li>".$quiz["questions"][$i]["choices"][$j]."</li>";                                                     
            }
            $outputHTML .= "</ul></div>";
        }$outputHTML .= "<h3>You got " . $correctAnswers . " questions correct. Good Job!</h3>";
        echo $outputHTML;
        // echo implode($userAnswerArr);
        echo "<br>";
        
        
        ?>
    </body>
</html>