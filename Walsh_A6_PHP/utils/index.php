<!DOCTYPE html>
<!--
Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
Click nbfs://nbhost/SystemFileSystem/Templates/Project/PHP/PHPProject.php to edit this template
-->
<html>
    <head>
        <meta charset="UTF-8">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
        <link rel="stylesheet" type="text/css" href="./generalStyles.css">
        <script src="./main.js"></script>
        <title>Cars Database: Home</title>
    </head>
    <body>
        <div id="header">
            <div id="headerText">
                <h2>Cars Database: Create, Update and Delete</h2>
                <h5>A web application developed by: Brady Walsh</h5>
            </div>
        </div>
        <div id="container">
            <div id="buttons">
                <button id="getData" class="btn btn-primary">Load Cars</button>
                <button id="addCar" class="btn btn-primary"data-bs-toggle="collapse" data-bs-target="#addCarFormDiv" aria-expanded="false" aria-controls="addCarFormDiv">Add Car</button>
                <button id="deleteCar" class="btn btn-primary" disabled>Delete Selected Car</button>
                <button id="updateCar" class="btn btn-primary" disabled>Update Selected Car</button>
            </div>
            <div class="collapse" id="addCarFormDiv">
                <div class="card card-body">
                    <form>
                        <div class="inputContainer">
                            <div class="inputLabel">Year:</div>
                            <div class="inputField"><input type="number" name="Year" id="Year"></div>
                        </div>
                        <div class="inputContainer">
                            <div class="inputLabel">Make:</div>
                            <div class="inputField"><input name="Make" id="Make"></div>
                        </div>
                        <div class="inputContainer">
                            <div class="inputLabel">Model:</div>
                            <div class="inputField"><input name="Model" id="Model"></div>
                        </div>
                        <div class="inputContainer">
                            <div class="inputLabel">Colour:</div>
                                    <div class="inputField">
                                        <select name="Colour" id="Colour">
                                                <option value="Red">Red</option>
                                                <option value="Yellow">Yellow</option>
                                                <option value="Blue">Blue</option>
                                                <option value="Black">Black</option>
                                                <option value="Brown">Brown</option>
                                                <option value="White">White</option>
                                                <option value="Orange">Orange</option>
                                                <option value="Purple">Purple</option>
                                        </select>
                                    </div>
                        </div>
                        <div>

                            <button id="addCarDoneBtn" class="btn btn-primary">Done</button>
                        </div>
                    </form>
                </div>
            </div>
            <div id="carTable">
                <table class="table table-striped table-bordered">
                    <thead>
                        <tr>
                            <th>
                                Car ID
                            </th>
                            <th>
                                Year
                            </th>
                            <th>
                                Make
                            </th>
                            <th>
                                Model
                            </th>
                            <th>
                                Colour
                            </th>
                        </tr>
                    </thead>
                    <tbody id="tableBody">
                        
                    </tbody>
                </table>
            </div>
        </div>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    </body>
</html>
