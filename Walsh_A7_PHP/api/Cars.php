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
            $CA = new CarsAccessor();
            $results = $CA->getAllItems(); // these are objects
            $results = json_encode($results, JSON_NUMERIC_CHECK);
            echo $results;
            } catch (Exception $e) {
                echo "ERROR " . $e->getMessage();
        }
    }
}

function doDelete() {
    if (isset($_GET['itemid'])) { 
        $id = file_get_contents('php://input');
        $contents = json_decode($id, true);


        // delete from DB
        try {
            $mia = new CarsAccessor();
            $success = $mia->deleteItem($_GET['itemid']);
            $success = json_encode($success);
            echo $success;
        } catch (Exception $e) {
            echo "ERROR " . $e->getMessage();
        }
    }
    // collection
    else {
        ChromePhp::log("Sorry, Group Delete not allowed!");
    }
}

function doPost() {
    if (isset($_GET['itemid'])) { 
        
    } else {
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
    }
}

function doPut() {
    if (isset($_GET['itemid'])) { 
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
    } else {
        // Bulk updates not implemented.
        ChromePhp::log("Sorry, bulk updates not allowed!");
    }
}
