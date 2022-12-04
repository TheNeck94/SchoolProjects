<?php
/**
 * Description of Car
 * Car is a PHP class that defines the key fields for storing and creating a Car Obj
 * @author Brady Walsh
 * @param $ID - The ID number for the car, also the PK for the Database     DataType: String
 * @param $year - The Year the car was made                                 DataType: Integer <---- only one Integer
 * @param $make - The Manufacturer of the Car (ie. Ford, Tesla, etc)        DataType: String
 * @param $model - The Model, or "Type" of car.                             DataType: String
 * @param $colour - The Colour of the car.                                  DataType: String 
 */
class Car implements JsonSerializable{
    private $year;
    private $make;
    private $model;
    private $colour;
    
    //Public Constructor for Car Objects
    public function __construct( $inYear, $inMake, $inModel, $inColour) {
        $this->year = $inYear;
        $this->make = $inMake;
        $this->model = $inModel;
        $this->colour = $inColour;
    }
    
    //Getters
    
    
    public function getCarYear(){
        return $this->year;
    }
    public function getCarMake(){
        return $this->make;
    }
    public function getCarModel(){
        return $this->model;
    }
    public function getCarColour() {
        return $this->colour;
    }
    
    //Setters
    
    public function setCarID($newID){
        $this->ID = $newID;
    }
    public function setCarYear($newYear){
        $this->year = $newYear;
    }
    public function setCarMake($newMake) {
        $this->make = $newMake;
    }
    public function setCarModel($newModel){
        $this->model = $newModel;
    }
    public function setCarColour($newColour){
        $this->colour = $newColour;
    }
    
    //Methods
    
    public function isItAClassic(){
        $check = false;
        if($this->year < 1992)
        {$check = true;}
        return $check;
    }
    
    public function isItAnAntique(){
        $check = false;
        if($this->year < 1972)
        {$check = true;}
        return $check;
    }
    
    public function jsonSerialize() {
        return get_object_vars($this);
    }

}
