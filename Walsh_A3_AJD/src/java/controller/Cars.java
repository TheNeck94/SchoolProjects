/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/JSP_Servlet/Servlet.java to edit this template
 */
package controller;

import com.google.gson.Gson;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import db.CarsAccessor;
import entity.Car;
import entity.UpSertModel;
import java.util.List;
import java.util.Scanner;

/**
 *
 * @author brady
 */
@WebServlet(name = "Cars", urlPatterns = {"/Cars", "/Cars/*"})
public class Cars extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        try ( PrintWriter out = response.getWriter()) {
            /* TODO output your page here. You may use following sample code. */
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Servlet Cars</title>");            
            out.println("</head>");
            out.println("<body>");
            out.println("<h1>Servlet Cars at " + request.getContextPath() + "</h1>");
            out.println("</body>");
            out.println("</html>");
        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try{
            PrintWriter out = response.getWriter();
            List<Car> cars = CarsAccessor.getAllCars();
            Gson c = new Gson();
            out.println(c.toJson(cars));
        }catch(Exception e){
            System.out.println(e);
        } 
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        try (PrintWriter out = response.getWriter()) {
            Scanner sc = new Scanner(request.getReader());
            String jsonData = sc.nextLine(); // payload is a single string
            Gson g = new Gson();
            Car item = g.fromJson(jsonData, Car.class);
            boolean success = CarsAccessor.insertItem(item);
            out.println(success);
        }
    }
    
     /**
     * Handles the HTTP <code>DELETE</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doDelete(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.addHeader("Access-Control-Allow-Origin", "*");
        System.out.print("doDelete Called API");
        boolean success;
        PrintWriter out = response.getWriter();
        try{
//            Scanner sc = new Scanner(request.getReader());
//            String jsonData = sc.nextLine(); // payload is a single string
//            Gson g = new Gson();  
//            Integer id = g.fromJson(jsonData, Integer.class);
            int id = Integer.parseInt(request.getPathInfo().substring(1));
            success = CarsAccessor.deleteItem(id);
            out.println(success);
            System.out.print("ID Sent to doDelete: " + id);
        }catch(Exception e){
            
            success = false;
            out.println(success);
            System.out.print("doDelete Catch Caught: ");
            System.out.print(e);
        }

    }
    
    
    /**
     * Handles the HTTP <code>PUT</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPut(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.addHeader("Access-Control-Allow-Origin", "*");
        boolean success = false;
       try (PrintWriter out = response.getWriter()) {
            Scanner sc = new Scanner(request.getReader());
            String jsonData = sc.nextLine();
            JsonObject jsonObject = (new JsonParser()).parse(jsonData).getAsJsonObject();
            JsonObject IDJson = jsonObject.get("ID").getAsJsonObject();
            Integer ID = IDJson.get("ID").getAsInt();
            JsonObject newCarJSON =jsonObject.get("item").getAsJsonObject();
            Integer Year = newCarJSON.get("Year").getAsInt();
            String Make = newCarJSON.get("Make").getAsString();
            String Model = newCarJSON.get("Model").getAsString();
            String Colour = newCarJSON.get("Colour").getAsString();
            Car newCar = new Car(Year,Make,Model,Colour);
            
            
            success = CarsAccessor.updateItem(newCar, ID);
            out.println(success);
        }
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
