using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VehicleShopApp.DAL.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO VehicleMakes (Name) VALUES ('Mercedes-Benz')");
            migrationBuilder.Sql("INSERT INTO VehicleMakes (Name) VALUES ('Peugeot')");
            migrationBuilder.Sql("INSERT INTO VehicleModels (Name, VehicleMakeId) VALUES ('A-Class', (SELECT ID FROM VehicleMakes WHERE Name ='Mercedes-Benz'))");
            migrationBuilder.Sql("INSERT INTO VehicleModels (Name, VehicleMakeId) VALUES ('E-Class', (SELECT ID FROM VehicleMakes WHERE Name ='Mercedes-Benz'))");
            migrationBuilder.Sql("INSERT INTO VehicleModels (Name, VehicleMakeId) VALUES ('308', (SELECT ID FROM VehicleMakes WHERE Name ='Peugeot'))");
            migrationBuilder.Sql("INSERT INTO VehicleModels (Name, VehicleMakeId) VALUES ('508', (SELECT ID FROM VehicleMakes WHERE Name ='Peugeot'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM VehicleMakes WHERE Name='Mercedes-Benz'");
            migrationBuilder.Sql("DELETE FROM VehicleMakes WHERE Name='Peugeot'");
            migrationBuilder.Sql("DELETE FROM VehicleModels WHERE Name='A-Class'");
            migrationBuilder.Sql("DELETE FROM VehicleModels WHERE Name='E-Class'");
            migrationBuilder.Sql("DELETE FROM VehicleModels WHERE Name='308'");
            migrationBuilder.Sql("DELETE FROM VehicleModels WHERE Name='508'");
        }
    }
}
