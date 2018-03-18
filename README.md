
# VehicleShopApp

**_VehicleShopApp_** is an ASP.NET CORE MVC case study to create Multy-layered architecture with Vehicle Shop example application.

This project shows how to structure a multi-project solution for a simple web application using Entity Framework and the Model-View-ViewModel (MVVM) design pattern along with the repository pattern, unitofwork, dependency injection and inversion of control.

![alt text](https://raw.githubusercontent.com/MiroslavMogus/different-images/master/angular-part.jpg)

Frontend

![alt text](https://raw.githubusercontent.com/MiroslavMogus/different-images/master/api-part.jpg)

Backend

*Notice: Author(s) disclaim any liability for errors or omissions in this code. See the [Disclaimer of Warranties and Limitation of Liability](#disclaimer-of-warranties-and-limitation-of-liability) for complete information.*

## Solution Projects

| Project | Application Layer |
| :--- | :--- |
| VehicleShopApp.Model.Common	 | Utility Classes |
| VehicleShopApp.DAL | Data Context |
| VehicleShopApp.Repository | Repositories (placeholder) |
| VehicleShopApp.Repository.Common | Repository interfaces |
| VehicleShopApp.Model	 | Domain models (placeholder) |
| VehicleShopApp.WebAPI	 | User Interface (views) and Business Logic (controllers) |
| VehicleShopApp.Resources | Resources classes |
		
	
	
		
	
		


## Technologies

| Dependency | Version*
| :--- | ---:
| .NET Core | 2.0.5
| Angular 	| 5.2.0
| Bootstrap | 3.3.7
| C# | 6
| Entity Framework | 6.1.3


&ast; As of the latest commit.

## Getting Started

1. Download or clone this repository.
1. Open the solution in Visual Studio 2017 or higher.


Create the database, apply Entity Framework migrations, and run the `Seed` method to populate the database with values for the db tables.

## Configuration

* Two projects contain configuration strings which may require modification for the developer's specific environment:

    | Project | File
    | :--- | :---
    | VehicleShopApp.WebAPI | appsettings.json

* The configuration in appsettings.json specify the instance of SQL Server Express installed with Visual Studio 2017 as the target database server: `Server=(localdb)\\mssqllocaldb;Database=vehicleshop-2;Trusted_Connection=True;MultipleActiveResultSets=true`. Developers using a different target database will have to change the connection strings in both projects.

## License

This project is licensed under the terms of the MIT license.

## Contributing

See the accompanying instructions on [How to contribute](CONTRIBUTING.md).

## Disclaimer of Warranties and Limitation of Liability

The contents of this repository are offered on an as-is and as-available basis and the authors make no representations or warranties of any kind concerning the contents, whether express, implied, statutory, or other. This includes, without limitation, warranties of title, merchantability, fitness for a particular purpose, non-infringement, absence of latent or other defects, accuracy, or the presence or absence of errors, whether or not known or discoverable.

To the extent possible, in no event will the authors be liable on any legal theory (including, without limitation, negligence) or otherwise for any direct, special, indirect, incidental, consequential, punitive, exemplary, or other losses, costs, expenses, or damages arising out of the use of the contents, even if the the authors have been advised of the possibility of such losses, costs, expenses, or damages.

The disclaimer of warranties and limitation of liability provided above shall be interpreted in a manner that, to the extent possible, most closely approximates an absolute disclaimer and waiver of all liability.
