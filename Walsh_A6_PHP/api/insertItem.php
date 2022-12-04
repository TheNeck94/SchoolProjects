<?php

$projectRoot = $_SERVER['DOCUMENT_ROOT'] . '/Walsh_A6_PHP';
require_once ($projectRoot . '/db/CarsAccessor.php');
require_once ($projectRoot . '/entity/Car.php');

// reading the HTTP request body
$body = file_get_contents('php://input');
$contents1 = json_decode($body, true);

// create a Car object
$CarObj = new Car($contents1['Year'], $contents1['Make'], $contents1['Model'], $contents1['Colour']);


//// add the object to DB
try {
    $mia = new CarsAccessor();
    $success = $mia->insertItem($CarObj);
    $success = json_encode($success);
    echo $success;
} catch (Exception $e) {
    echo "ERROR " . $e->getMessage();
}
