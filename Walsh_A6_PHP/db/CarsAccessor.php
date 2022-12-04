<?php
$projectRoot = $_SERVER['DOCUMENT_ROOT'] . '/Walsh_A6_PHP';
require_once 'ConnectionManager.php';
require_once ($projectRoot . '/entity/Car.php');
/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Scripting/PHPClass.php to edit this template
 */

/**
 * Description of CarsAccessor
 *
 * @author brady
 */
class CarsAccessor {
    
    private $getByIDStatementString = "select * from cars where itemID = :itemID";
    private $deleteStatementString = "delete from cars where ID = :itemID";
    private $insertStatementString = "insert INTO cars(Year, Make, Model, Colour) values (:Year, :Make, :Model, :Colour)";
    private $updateStatementString = "update cars SET Year = :year, Make = :make, Model = :model, Colour = :colour WHERE ID = :ID";
    private $conn = NULL;
    private $getByIDStatement = NULL;
    private $deleteStatement = NULL;
    private $insertStatement = NULL;
    private $updateStatement = NULL;
    
    public function __construct() {
        $cm = new ConnectionManager();
        
        $this->conn = $cm->connect_db();
        if (is_null($this->conn)) {
            throw new Exception("no connection");
        }
        $this->getByIDStatement = $this->conn->prepare($this->getByIDStatementString);
        if (is_null($this->getByIDStatement)) {
            throw new Exception("bad statement: '" . $this->getAllStatementString . "'");
        }

        $this->deleteStatement = $this->conn->prepare($this->deleteStatementString);
        if (is_null($this->deleteStatement)) {
            throw new Exception("bad statement: '" . $this->deleteStatementString . "'");
        }

        $this->insertStatement = $this->conn->prepare($this->insertStatementString);
        if (is_null($this->insertStatement)) {
            throw new Exception("bad statement: '" . $this->getAllStatementString . "'");
        }

        $this->updateStatement = $this->conn->prepare($this->updateStatementString);
        if (is_null($this->updateStatement)) {
            throw new Exception("bad statement: '" . $this->updateStatementString . "'");
        }
    }
    /**
     * Gets Cars by executing a SQL "select" statement. An empty array
     * is returned if there are no results, or if the query contains an error.
     * 
     * @param String $inputString a valid SQL "select" statement
     * @return array Car objects
     */
    public function getItemsByQuery($inputString){
        $result = [];
        try {
            $stmt = $this->conn->prepare($inputString);
            $stmt->execute();
            $databaseResp = $stmt->fetchAll(PDO::FETCH_ASSOC);

            foreach ($databaseResp as $r) {
                $Year = $r['Year'];
                $Make = $r['Make'];
                $Model = $r['Model'];
                $Colour = $r['Colour'];
                $obj = new Car($Year,$Make,$Model,$Colour);
                array_push($result, $obj);
            }
        }
        catch (Exception $e) {
            $result = [];
        }
        finally {
            if (!is_null($stmt)) {
                $stmt->closeCursor();
            }
        }
        return $result;
    }
    /**
     * Gets current ID's within the Database by executing a SQL "select" statement. An empty array
     * is returned if there are no results, or if the query contains an error.
     * 
     * @param String $inputString a valid SQL "select" statement
     * @return array Car objects
     */
    public function getObjectIds($inputString){
        $result = [];
        try {
            $stmt = $this->conn->prepare($inputString);
            $stmt->execute();
            $databaseResp = $stmt->fetchAll(PDO::FETCH_ASSOC);

            foreach ($databaseResp as $r) {
                $ID = $r['ID'];
                array_push($result, $ID);
            }}
        catch (Exception $e) 
        {$result = [];}
        finally {
            if (!is_null($stmt)) {
                $stmt->closeCursor();
            }
        }
        return $result;
    }
    /**
     * Gets all Cars.
     * 
     * @return array Car objects, possibly empty
     */
    public function getAllItems() {
        return $this->getItemsByQuery("select * from cars");
    }
    /**
     * Resets the DB auto-increment value to user input int.
     * 
     * @return boolean based on success of the operation
     */
    public function resetIDcount($newIndex) {
        $success = false;
        $inputString = "ALTER TABLE cars AUTO_INCREMENT=$newIndex";
        try{
        $stmt = $this->conn->prepare($inputString);
        $success = $stmt->execute();
        }catch(Exception $e){
            $success = $e;
        }finally {
            if (!is_null($stmt)) {
                $stmt->closeCursor();
            }
        }
    }
    /**
     * Gets all Cars.
     * 
     * @return array Car objects, possibly empty
     */
    public function getAllIDs() {
        return $this->getObjectIds("select ID from cars");
    }
    /**
     * Gets the Car with the specified ID.
     * 
     * @param Integer $id the ID of the item to retrieve 
     * @return the Car object with the specified ID, or NULL if not found
     */
    private function getItemByID($id) {
        $result = NULL;

        try {
            $this->getByIDStatement->bindParam(":ID", $id);
            $this->getByIDStatement->execute();
            $dbresults = $this->getByIDStatement->fetch(PDO::FETCH_ASSOC); // not fetchAll

            if ($dbresults) {
                $ID = $r['ID'];
                $Year = $r['Year'];
                $Make = $r['Make'];
                $Model = $r['Model'];
                $Colour = $r['Colour'];
                $result = new Car($ID,$Year,$Make,$Model,$Colour);
            }
        }
        catch (Exception $e) {
            $result = NULL;
        }
        finally {
            if (!is_null($this->getByIDStatement)) {
                $this->getByIDStatement->closeCursor();
            }
        }

        return $result;
    }
    /**
     * Deletes a Car.
     * @param (Car) $item an object whose ID is EQUAL TO the ID of the item to delete
     * @return boolean indicates whether the item was deleted
     */
    public function deleteItem($itemID) {
        $success = false;
        try {
            $this->deleteStatement->bindParam(":itemID", $itemID);
            $success = $this->deleteStatement->execute(); // this doesn't mean what you think it means
            $rc = $this->deleteStatement->rowCount();
        }
        catch (PDOException $e) {
            $success = false;
        }
        finally {
            if (!is_null($this->deleteStatement)) {
                $this->deleteStatement->closeCursor();
            }
        }return $success;
    }
    /**
     * Inserts a Car into the database.
     * 
     * @param Car $item an object of type Car
     * @return boolean indicates if the item was inserted
     */
    public function insertItem($car) {
        $success = false;
        $carYear = $car->getCarYear();
        $carMake = $car->getCarMake();
        $carModel = $car->getCarModel();
        $carColour = $car->getCarColour();
        

        try {
            $this->insertStatement->bindParam(":Year", $carYear);
            $this->insertStatement->bindParam(":Make", $carMake);
            $this->insertStatement->bindParam(":Model", $carModel);
            $this->insertStatement->bindParam(":Colour", $carColour);            
            $success = $this->insertStatement->execute();
        }
        catch (PDOException $e) {
            $success = false;
        }
        finally {
            if (!is_null($this->insertStatement)) {
                $this->insertStatement->closeCursor();
            }
            return $success;
        }
    }
    /**
     * Updates a Car in the database.
     * 
     * @param (Car) $item an object of type Car, the new values to replace the database's current values
     * @return boolean indicates if the item was updated
     */
    public function updateItem($item, $ID) {
        $success = false;
        
        $carID = $ID;
        $carYear = $item->getCarYear();
        $carMake = $item->getCarMake();
        $carModel = $item->getCarModel();
        $carColour = $item->getCarColour();

        try {
            $this->updateStatement->bindParam(":ID", $carID);
            $this->updateStatement->bindParam(":year", $carYear);
            $this->updateStatement->bindParam(":make", $carMake);
            $this->updateStatement->bindParam(":model", $carModel);
            $this->updateStatement->bindParam(":colour", $carColour);
            $success= $this->updateStatement->execute();
        }
        catch (PDOException $e) {
            $success = $e;
        }
        finally {
            if (!is_null($this->updateStatement)) {
                $this->updateStatement->closeCursor();
            }
            return $success;
        }
    }
}
