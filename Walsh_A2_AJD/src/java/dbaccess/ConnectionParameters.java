package dbaccess;

/**
 * It's better practice to store this information in a configuration file.
 */
public class ConnectionParameters {
    
    public static final String URL = "jdbc:mysql://localhost:3306/cars";
    public static final String USERNAME = "root";
    public static final String PASSWORD = "password";
    
    // no instantiation allowed
    private ConnectionParameters() {}
    
} // end class ConnectionParameters
