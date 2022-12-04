<?php

$projectRoot = $_SERVER['DOCUMENT_ROOT'] . '/Walsh_A6_PHP';
require_once ($projectRoot . '/db/CarsAccessor.php');
require_once ($projectRoot . '/entity/Car.php');

// reading the HTTP request body - should contain a single integer
$id = file_get_contents('php://input');
$contents = json_decode($id, true);


// delete from DB
try {
    $mia = new CarsAccessor();
    $success = $mia->deleteItem($contents['ID']);
    $success = json_encode($success);
    echo $success;
} catch (Exception $e) {
    echo "ERROR " . $e->getMessage();
}