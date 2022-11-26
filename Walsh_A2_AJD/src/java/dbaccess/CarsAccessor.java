package dbaccess;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import entity.Car;
/**
 *
 * @author brady
 */
public class CarsAccessor {
    private static Connection conn = null;
    private static PreparedStatement selectAllStatement = null;
    private static PreparedStatement selectAllIDStatement = null;
    private static PreparedStatement deleteStatement = null;
    private static PreparedStatement insertStatement = null;
    private static PreparedStatement updateStatement = null;

    // constructor is private - no instantiation allowed
    private CarsAccessor() {
    }

    /**
     * Used only by methods in this class to guarantee a database connection.
     *
     * @throws SQLException
     */
    private static void init() throws SQLException {
        if (conn == null) {
            conn = ConnectionManager.getConnection(ConnectionParameters.URL, ConnectionParameters.USERNAME, ConnectionParameters.PASSWORD);
            selectAllStatement = conn.prepareStatement("select * from cars");
            selectAllIDStatement = conn.prepareStatement("select ID from cars");
            deleteStatement = conn.prepareStatement("delete from cars where ITEMID = ?");
            insertStatement = conn.prepareStatement("insert into cars values (?,?,?,?)");
            updateStatement = conn.prepareStatement("update cars set ITEMCATEGORYID = ?, DESCRIPTION = ?, PRICE = ?, VEGETARIAN = ? where ITEMID = ?");
        }
    }

    /**
     * Gets all Cars.
     *
     * @return a List, possibly empty, of Car objects
     */
    public static List<Car> getAllCars() {
        System.out.println("getAllCars Function Called: Cars Accessor");
        List<Car> items = new ArrayList();
        try {
            init();
            ResultSet rs = selectAllStatement.executeQuery();
            while (rs.next()) {
                int year = rs.getInt("Year");
                String make = rs.getString("Make");
                String model = rs.getString("Model");
                String colour = rs.getString("Colour");
                Car item = new Car(year, make, model, colour);
                items.add(item);
            }
        } catch (SQLException ex) {
            items = new ArrayList();
            System.out.print(ex);
        }
        return items;
    }
    
    public static List<Integer> getAllID(){
        List<Integer> IDlist = new ArrayList();
        System.out.println("getAllIDs Function Called: Cars Accessor");
        try{
            init();
            ResultSet rs = selectAllIDStatement.executeQuery();
            while(rs.next()){
                int newID = rs.getInt("ID");
                
                IDlist.add(newID);
            }
        }catch(SQLException ex){
            IDlist = null;
            System.out.print(ex);
        }
        System.out.print(IDlist);
        return IDlist;
    }
    /**
     * Deletes the Car with the same ID as the specified item.
     *
     * @param item the item whose ID should be used to match the item to delete
     * @param ID (Row Number) of the item to be deleted
     * @return <code>true</code> if an item was deleted; <code>false</code>
     * otherwise
     */
    public static boolean deleteItem(Car item, Integer ID) {
        boolean res;

        try {
            init();
            deleteStatement.setInt(1, ID);
            int rowCount = deleteStatement.executeUpdate();
            res = (rowCount == 1);
        } catch (SQLException ex) {
            res = false;
        }
        return res;
    }
    
    public static boolean insertItem(Car item) {
        boolean res;
        
        try {
            init();
            insertStatement.setInt(1, item.getCarYear());
            insertStatement.setString(2, item.getCarMake());
            insertStatement.setString(3, item.getCarModel());
            insertStatement.setString(4, item.getCarColour());
            int rowCount = insertStatement.executeUpdate();
            res = (rowCount == 1);
        }
        catch (SQLException ex) {
            res = false;
        }
        
        return res;
    }

    public static boolean updateItem(Car item, int ID) {
        boolean res;
        
        try {
            init();
            updateStatement.setInt(1, item.getCarYear());
            updateStatement.setString(2, item.getCarMake());
            updateStatement.setString(3, item.getCarModel());
            updateStatement.setString(4, item.getCarColour());
            updateStatement.setInt(5, ID);
            int rowCount = updateStatement.executeUpdate();
            res = (rowCount == 1);
        }
        catch (SQLException ex) {
            res = false;
        }
        
        return res;
    }

} // end MenuItemAccessor

