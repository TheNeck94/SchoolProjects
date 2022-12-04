package db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

public class ConnectionManager {
    private static Connection conn = null;

    static Connection getConnection(String url, String user, String password) throws SQLException {
        if (conn == null) {
            try {
                Class.forName("com.mysql.cj.jdbc.Driver");
            } catch (ClassNotFoundException ex) {
                Logger.getLogger(ConnectionManager.class.getName()).log(Level.SEVERE, null, ex);
            }
            conn = DriverManager.getConnection(url, user, password);
        }
        return conn;
    }

} // end class ConnectionManager
