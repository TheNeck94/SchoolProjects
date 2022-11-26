<%@page import="java.util.List"%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Show Cars</title>
    </head>
    <body>
        <h1>Cars</h1>
        <table>
        <thead>
            <tr>
                <th>ID</th> <th>Year</th> <th>Make</th> <th>Model</th> <th>Colour</th> <th>Delete</th> <th>Update</th>
            </tr>
        </thead>
        <tbody>
        <% 
            
            List<Integer> IDs = (List<Integer>)session.getAttribute("IDs");
            Integer currentCar = 0; 
            System.out.print("List of IDs: ");
            System.out.print(IDs);
        
        %>
        <c:forEach var='car' items='${cars}'>
            <tr>
                <td><%= IDs.get(currentCar) %></td>
                <td>${String.valueOf(car.getCarYear())}</td>
                <td>${car.getCarMake()}</td>
                <td>${car.getCarModel()}</td>
                <td>${car.getCarColour()}</td>
                <td><form>
                        <input type='hidden' name='delete' valaue=''>
                </form></td>
            </tr>
            <% currentCar++; %>
        </c:forEach>
        </tbody>
        
        </table>
    </body>
</html>
