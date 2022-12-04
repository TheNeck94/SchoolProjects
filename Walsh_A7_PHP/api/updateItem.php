<?php

$projectRoot = $_SERVER['DOCUMENT_ROOT'] . '/Walsh_A6_PHP';
require_once ($projectRoot . '/db/CarsAccessor.php');
require_once ($projectRoot . '/entity/Car.php');

// reading the HTTP request body
$body = file_get_contents('php://input');
$contents1 = json_decode($body, true);
$ID = $contents1['ID']['ID'];
$Data = $contents1['Data'];

// create a Car object
$carObj = new Car($Data['Year'], $Data['Make'], $Data['Model'], $Data['Colour']);

// update the DB
try {
    $mia = new CarsAccessor();
    $success = $mia->updateItem($carObj, $ID);
    $success = json_encode($success);
    echo $success;
} catch (Exception $e) {
    echo "ERROR " . $e->getMessage();
}
