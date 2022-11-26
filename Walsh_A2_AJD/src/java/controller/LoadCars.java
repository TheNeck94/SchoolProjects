package controller;

import dbaccess.CarsAccessor;
import dbaccess.ConnectionParameters;
import entity.Car;
import java.io.*;
import static java.lang.Double.parseDouble;
import static java.lang.Integer.parseInt;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import javax.servlet.*;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.*;

/**
 *
 * @author brady
 */
@WebServlet(name = "LoadCars", urlPatterns = {"/AllCars"})
public class LoadCars extends HttpServlet {
    //List of Car Objects
    List<Car> cars;
    List<Integer> IDs;
    
    //Initialize Car Objects
    @Override
    public void init(){
        getCars();
        getIDs();
    }
    
    //Get Cars data from LoadCars Service
    public void getCars(){
         cars = CarsAccessor.getAllCars();
    }
    
    //Get current IDs (Primary Keys) from the DataBase
    public void getIDs(){
        IDs = CarsAccessor.getAllID();
    }
    
    //Handle GET method response and request 
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        
        // Set response content type
        response.setContentType("text/html");
        
        // Get session
        HttpSession session = request.getSession();
        
        //Set Session Attributes
        session.setAttribute("cars", cars);
        session.setAttribute("IDs", IDs);
        
        System.out.print("Cars: ");
        System.out.print(cars);
        System.out.print("IDs: ");
        System.out.print(IDs);
        
        
        //Redirect to front end 
        String path = "/showCars.jsp";
        RequestDispatcher rd = request.getRequestDispatcher(path);
        rd.forward(request, response);
    }
}
