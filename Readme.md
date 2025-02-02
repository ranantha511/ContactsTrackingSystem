# ContactsTrackingSystem
The Contacts Tracking System displays list of contacts and provides functionality to create and edit contacts

## Introduction:
The Contacts Tracking System is a simple tracking system to track list of contacts. It contains a login page and a contacts page which displays list of contacts

The application is written using .NET 8 framework. The application is designed using MVC pattern.

## Features:
1) Provides Ability to view list of contacts.
2) Provides the ability to create and edit contacts.
3) Internally uses bCrypt technique for storing and comparing passwords.
4) Uses Entity Framework Core to connect to the database and perform database operations
5) Uses repository pattern to abstract the from the concrete implementation
6) Dependency Injection added to the application so that each layer such as controller and services can be tested independently.
7) Sample data is created using JSon.
8) Data is validated using Data annotations.

## Improvements
This application requires improvements to make it more robust.
1) Enhance logging although logging has been added to the application. The application can utilize Serilog or Azure Monitor Log for storing the application logs.
2) Pagination feature can be added to the Contacts list.
3) Improvements can be made to the application such as UI interface, additional features of .NET 8/MVC.

## How to run the application
1) Using Git Clone command or zip download, download the application to the local computer.
2) Open the application using Visual Studio. This application is developed using Visual Studio community edition.
3) Compile the application to make sure there are no compilation errors.
4) Run the database migration from the visual studio > Tools > Nuget Package Manager > Package Manager Console. This creates the tables in the MSSQL local database and loads data into Contacts and UserLogin tables.
5) Migration scripts: a) Add-Migration Initial b) Update-Database
6) Run the application locally. It should open the login page.
7) Click the register link to create the new login or you can login using these credentials :  Username:AdminUser@gmail.com  Password:Test!234!!
8) Once the login is created, it will be redirected to the contacts page.
9) Create the sample contacts which should store the data successfully in the database.
10) A search feature by column type has been provided in the contacts page. To filter the records, select the filter type such as first name, last name etc.
11) Enter the search word and click on the search button. This should retrieve the records based on the filter criteria. If the criteria does not match then it does not retrieve any records
