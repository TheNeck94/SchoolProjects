package entity;


/**
 *
 * @author brady
 */
public class UpSertModel {
    private Integer ID;
    private Car item;
    
    public UpSertModel(Integer inID, Car inCar){
        this.ID = inID;
        this.item = inCar;
    }
    
    public Integer getID(){
        return this.ID;
    }
    public Car getCar(){
        return this.item;
    }
    
    public void setID(Integer ID){
        this.ID = ID;
    }
    public void setCar(Car item){
        this.item = item;
    }
}
