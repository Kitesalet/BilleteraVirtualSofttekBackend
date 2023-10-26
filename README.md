# Trabajo Integrador Softtek Virtual Wallet 🌠


![Chazawallet](https://github.com/Kitesalet/BilleteraVirtualSofttekBackend/assets/104630744/3c533a45-37bd-4b18-aeab-bc3fdfffe103)

Chazzima Wallet

## Description

This is the byproduct of the Softtek evaluation in regarding to the .Net academy, in which we learnt about how to create a backend API based in .Net Core, with some basic and not so basic functionalities, such as JWT Authentication and Authorization, Unit Testing ( at least the basics of it ) with MS Testing, Login features with implementation of the named JWT Token, swagger documentation as well as POSTMAN Documentation, how to create and consume API endpoints as well as their HTTP status codes.

Everything was made taking in consideration the good practices we learnt by reading the UMSA-SOFTTEK PDF documents and throughout the academy.


The UML Diagram and ERD

![image](https://github.com/Kitesalet/BilleteraVirtualSofttekBackend/assets/104630744/745a8b55-0aec-44f6-a655-8e3b3b4e878c)

![image](https://github.com/Kitesalet/BilleteraVirtualSofttekBackend/assets/104630744/2064c6e9-2b82-4499-8d54-60126b6175e3)



## **Arquitecture Specifications**
​
### **Controller Layer**
This is the entry point for the API. We have four controllers in the application, one for each entity (Accounts, Login, Client, Transaction). The login Controller... It provides a token that acts as a user session, allowing access to the endpoints in the other controllers.

![image](https://github.com/Kitesalet/BilleteraVirtualSofttekBackend/assets/104630744/ecca1871-ad7e-48c7-ae21-eea56830512f)
​
### **DataAccess Layer**
This is the layer where we establish the connection between our application and the database. It involves creating a class called AppDbContext, which inherits from DbContext, and using its methods to achieve this connection. Multiple repositories are used, one for each entity mentioned earlier. We also implement the Generic Repository design pattern and the Unit of Work design pattern to centralize methods and manage all repositories with the same context. Additionally, in this layer, we handle data seeding, which occurs in each cycle of migrations/updates to the database defined in the appsettings.json file.

![image](https://github.com/Kitesalet/BilleteraVirtualSofttekBackend/assets/104630744/0dd6e963-6738-4c1d-8496-c54ecfde1714)

​
### **Model Layer**
In this layer of the architecture, we define all the database entities, as well as all the interfaces and common classes used throughout the application. This layer also includes a list of DTOs used by each entity or endpoint in the controllers and services, enumerations, and classes associated with the Helpers layer.

![image](https://github.com/Kitesalet/BilleteraVirtualSofttekBackend/assets/104630744/ae65e041-745e-4fa6-bb17-c60bea4bda6e)
​

### **Service Layer**
This level is responsible for the application's business logic. In this part of the application, the connection between the controller layer and the data layer (DAL) is established. Additionally, it involves mapping entities to DTOs and mapping DTOs to entities using the NuGet library called AutoMapper. There is one service for each entity or controller to achieve this, as shown below:

![image](https://github.com/Kitesalet/BilleteraVirtualSofttekBackend/assets/104630744/c83ae4d0-6d81-4761-bcf0-a7b3b95999ac)


## Other Details

### Dependencies And Installed Nuget packages

![image](https://github.com/Kitesalet/BilleteraVirtualSofttekBackend/assets/104630744/c3c63bad-f290-4728-bd76-8dc0455b30f5)


### Executing program


To perform the migration and create a database on your server with seeded data, you should execute the following commands in the NuGet Package Manager Console:

add-migration migration_name (if needed)
update-database
These commands will apply any pending migrations to the database and ensure that it is up to date with the latest changes in your application.

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/3687c165-a8a8-4753-b87b-de9d10abd3ce)

To test each endpoint, you'll need to obtain the token from the request at the Login endpoint using the user credentials provided , using the only endpoint in the 
login controller, with these credentials, once you have seeded the database:

email:1@1.com
password:random



## Help

If you encounter any problem, please, contact me at : kitesalett@gmail.com

## Authors

Imanol Echazarreta

## Version History
      
* 0.1
    * Initial Release


## Acknowledgments

* Al equipo de SoftTek por la oportunidad de participar en la academia de .Net 2023
  
______________________________________________
