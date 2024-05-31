# Staff_Application
This application describes the CRUD operations of a staff. 

# software requirements
.Net 8
Docker Desktop

# Probelm Statment

Create a simple C# .NET 8 restful API to manage personal details of staff menmber. It should run as a container with in the Docker and persent a swagger interface.
Container should allow the retrival of teh personal details of a staff member by specifying their UserId through a GET method and a scond GET method to retrieve all records.
It should allow a new staff member to be added through a POST method.

The staff details that area stored will include the following itemsL

  UserId
  FirstName
  SurName
  DateOfBirth
  Array of address
    StartDate
    EndDate
    HouseNumber
    PostCode

The details can be held in-memory - there is no need for integrating to a database.
