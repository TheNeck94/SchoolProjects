<?php
$projectRoot = filter_input(INPUT_SERVER, 'DOCUMENT_ROOT') . '/Walsh_A6_PHP';
require_once ($projectRoot . '/db/CarsAccessor.php');
try {
    $mia = new CarsAccessor();
    $results = $mia->getAllIDs();
    $results = json_encode($results, JSON_NUMERIC_CHECK);
    echo $results;
} catch (Exception $e) {
    echo "ERROR " . $e->getMessage();
}