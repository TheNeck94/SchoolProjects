package entity;

/**
 *
 * @author brady
 */
public class Car {
    private int Year;
    private String Make;
    private String Model;
    private String Colour;
    
    public Car(int inYear, String inMake, String inModel, String inColour){
        this.Year = inYear;
        this.Make = inMake;
        this.Model = inModel;
        this.Colour = inColour;
        
    }
        //Getters
    
    
    public int getCarYear(){
        return Year;
    }
    public String getCarMake(){
        return Make;
    }
    public String getCarModel(){
        return Model;
    }
    public String getCarColour() {
        return Colour;
    }
    
    //Setters
    
    public void setCarYear(int newYear){
        this.Year = newYear;
    }
    public void setCarMake(String newMake) {
        this.Make = newMake;
    }
    public void setCarModel(String newModel){
        this.Model = newModel;
    }
    public void setCarColour(String newColour){
        this.Colour = newColour;
    }
    
}
