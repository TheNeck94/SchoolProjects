<?php
$projectRoot = filter_input(INPUT_SERVER, 'DOCUMENT_ROOT') . '/Walsh_A6_PHP';
require_once ($projectRoot . '/db/CarsAccessor.php');
require_once ($projectRoot . '/entity/Car.php');
require_once ($projectRoot . '/ChromePhp.php');

$method = $_SERVER['REQUEST_METHOD'];

if ($method === "GET") {
    doGet();
} else if ($method === "POST") {
    doPost();
} else if ($method === "DELETE") {
    doDelete();
} else if ($method === "PUT") {
    doPut();
}

function doGet() {
    if (isset($_GET['itemid'])) { 
        // Individual gets not implemented.
        ChromePhp::log("Sorry, individual gets not allowed!");
    }
    // collection
    else {
        try {
            $mia = new CarsAccessor();
            $results = $mia->getAllIDs();
            $results = json_encode($results, JSON_NUMERIC_CHECK);
            echo $results;
        } catch (Exception $e) {
            echo "ERROR " . $e->getMessage();
        }
    }
}

function doPost() {
    // reading the HTTP request body
//    $body = file_get_contents('php://input');
//    $contents1 = json_decode($body, true);
    $newIndex = $_GET['newIndex'];
    // update the DB
    try {
        $mia = new CarsAccessor();
        $success = $mia->resetIDcount($newIndex);
        $success = json_encode($success);
        echo $success;
    } catch (Exception $e) {
        echo "ERROR " . $e->getMessage();
    }
}

