# ContactsTrackingSystem
The Contacts Tracking System displays list of contacts and provides functionality to create and edit contacts

## Introduction:
The Contacts Tracking System is a simple tracking system to track list of contacts. It contains a login page and a contacts page which displays list of contacts

The application is written using .NET 8 framework. The application is designed using MVC pattern.

## Features:
1) Provides the ability to create contacts
2) Provides the ability to edit contacts
3) Internally uses bCrypt technique for storing and comparing passwords
4) Uses Entity Framework Core to connect to the database and perform database operations
5) Uses repository pattern to abstract the from the concrete implementation
6) Dependency Injection added to the application so that each layer such as controller and services can be tested independently.

## Improvements
This application requires improvements to make it more robust.
1) Enhance logging although logging has been added to the application. The application can utilize Serilog or Azure Monitor Log for storing the application logs.
2) Improvements can be made to the application such as UI interface, additional features of .NET 8/MVC.
3) Currently there is no link between the login and the contacts. A new feature can be added to view contacts based on the user who created it.

## How to run the application
1) Using Git Clone command or zip download, download the application to the local computer
2) Open the application using Visual Studio. This application is developed using Visual Studio community edition.
3) Run the database migration from the visual studio terminal. This creates the tables in the MSSQL local database
4) Compile the application to make sure there are no compilation errors
5) Run the application locally. It should provide with the login page
6) Click the register link to create the new login
7) Once login is created, it will be redirected to the contacts page
8) Create the sample contacts which should store the data successfully in the database.
9) A search feature has been provided in the contacts page. To filter the records, select the filter type such as first name, last name etc.
10) Enter the search word and click on the search button. This should retrieve the records based on the filter criteria. If the criteria does not match then it does not retrieve any records
