# Pierre's Sweet and Savory 

#### C# Independant Project, 08.14.2020

## By Joseph Pearce

## Description

_This application will help Pierre keep track of the Treats and Flavors in the bakery. It will also allow users to register and login for create, update and delete functionality._

## Setup/Installation Requirements

* Clone this repository from GitHub https://github.com/
* Open the downloaded directory in a text editor of your choice. (VSCode, Atom, etc.)
* Install [.Net Core](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* To install the REPL dotnet script, run ```dotnet tool install -g dotnet-script``` in your terminal.
* Run ```dotnet restore``` in terminal to get all dependencies.
* Run the command ```dotnet build```.

#### Additional Setup/Installation Notes:

* You will need to have MySQL installed on your computer to start the database for this project.
* Once you have it installed open your terminal and run ```mysql -uroot -pepicodus```. This will start the mysql server on your computer.
* With mysql running in your terminal copy/paste the code snippet below.
* Run ```dotnet ef migrations add Initial``` and ```dotnet ef database update``` to create the schema and all required tables.
* Then you will have the database correctly set up and you can start the project in a separate terminal that the one running mysql by running ```dotnet run```.


## Specifications

| Spec | Input | Output | 
|:--------- |:--------- |:-------- |
| The program will construct a database of Treats allowing the User to make entries | "TreatName" | "" | 
| The program will construct a database of Flavors allowing the user to make entries | "FlavorName"  | "Tart" |
| The program will allow the user to view lists of Treats | "View Treat List" | "Scone", "Croissant" |
| The program will allow the user to view lists of Flavors |  "View List of Flavors" | "Tart", "Sweet" |
| The Program will allow the user to add Bakers to the database | "Add Baker" | "Jenny Cook" |
| The program will allow the user to edit entries | "Scope" | "Scone" |
| The program will allow the user to delete entries | "Croissant" | " " | 


## Known Bugs

_No known issues. Please contact me if you have any problems._


## Support and contact details

Please feel free to contact me through GitHub (username: pearcy) with any questions, ideas or concerns.  

## Technologies Used

* C#
* .NET Core 2.2
* Visual Studio Code
* Git and Git BASH
* MySQL Workbench
* MySQL Database
* Entity Framework
* Identity


## License
This software is licensed under the MIT license. Copyright (c) 2020 Joseph Pearce.
