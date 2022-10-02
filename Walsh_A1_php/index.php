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
            .quizForm {
                padding: 10px;
            }
            .quizForm *{
                padding: 5px;
            }
        </style>
    </head>
    <body>
        <h4>Please Select a Quiz and Press 'Done'</h4>
        <div>
            <form class='quizForm' action='MainQuiz.php' method='POST'>
                <select  name="Quiz" id="quizSelect">
                    <option value="NumberSystems.json">Numbers Quiz</option>
                    <option value="WorldGeography.json">Geography Quiz</option>
                </select>
                <button type="submit">Done</button>
            </form>
        </div>
        
    </body>
</html>
