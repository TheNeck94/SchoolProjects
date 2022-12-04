<?php
class ConnectionManager{
function connect_db() {
    $db = new PDO("mysql:host=localhost;dbname=cars", "Brady", "Password");
    $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION); // throw exceptions
    return $db; 
}
}
