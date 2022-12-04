package db;

/**
 * It's better practice to store this information in a configuration file.
 */
public class ConnectionParameters {
    
    public static final String URL = "jdbc:mysql://localhost:3306/Cars?zeroDateTimeBehavior=CONVERT_TO_NULL&autoReconnect=true&useSSL=false";
    public static final String USERNAME = "Brady";
    public static final String PASSWORD = "Password";
    
    // no instantiation allowed
    private ConnectionParameters() {}
    
} // end class ConnectionParameters
