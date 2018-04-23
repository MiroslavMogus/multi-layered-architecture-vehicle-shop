using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VehicleShopApp.DAL.Migrations
{
    public partial class NewModelIncrease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // VehicleMakes
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[VehicleMakes] ON");
            migrationBuilder.Sql("INSERT INTO[dbo].[VehicleMakes] ([Id], [Name]) VALUES(1, N'Mercedes')");
            migrationBuilder.Sql("INSERT INTO[dbo].[VehicleMakes] ([Id], [Name]) VALUES(2, N'Peugeot')");
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[VehicleMakes] OFF");

            // VehicleModels
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[VehicleModels] ON");
            migrationBuilder.Sql("INSERT INTO[dbo].[VehicleModels] ([Id], [Name], [VehicleMakeId]) VALUES(2, N'E-Class', 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[VehicleModels] ([Id], [Name], [VehicleMakeId]) VALUES(3, N'C-Class', 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[VehicleModels] ([Id], [Name], [VehicleMakeId]) VALUES(4, N'508', 2)");
            migrationBuilder.Sql("INSERT INTO[dbo].[VehicleModels] ([Id], [Name], [VehicleMakeId]) VALUES(5, N'308', 2)");
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[VehicleModels] OFF");

            // Vehicles
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[Vehicles] ON");
            migrationBuilder.Sql("INSERT INTO[dbo].[Vehicles] ([Id], [OwnerEmail], [VehicleModelId], [VehicleMakeId]) VALUES(69, N'eddd', 3, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Vehicles] ([Id], [OwnerEmail], [VehicleModelId], [VehicleMakeId]) VALUES(71, N'err', 2, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Vehicles] ([Id], [OwnerEmail], [VehicleModelId], [VehicleMakeId]) VALUES(88, N'uhahahaha', 2, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Vehicles] ([Id], [OwnerEmail], [VehicleModelId], [VehicleMakeId]) VALUES(89, N'llccccss', 5, 2)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Vehicles] ([Id], [OwnerEmail], [VehicleModelId], [VehicleMakeId]) VALUES(61, N'eddd', 3, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Vehicles] ([Id], [OwnerEmail], [VehicleModelId], [VehicleMakeId]) VALUES(72, N'err', 2, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Vehicles] ([Id], [OwnerEmail], [VehicleModelId], [VehicleMakeId]) VALUES(83, N'uhahahaha', 2, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Vehicles] ([Id], [OwnerEmail], [VehicleModelId], [VehicleMakeId]) VALUES(84, N'llccccss', 5, 2)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Vehicles] ([Id], [OwnerEmail], [VehicleModelId], [VehicleMakeId]) VALUES(65, N'eddd', 3, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Vehicles] ([Id], [OwnerEmail], [VehicleModelId], [VehicleMakeId]) VALUES(76, N'err', 2, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Vehicles] ([Id], [OwnerEmail], [VehicleModelId], [VehicleMakeId]) VALUES(81, N'uhahahaha', 2, 1)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Vehicles] ([Id], [OwnerEmail], [VehicleModelId], [VehicleMakeId]) VALUES(82, N'llccccss', 5, 2)");
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[Vehicles] OFF");

    }

    protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("");
        }
    }
}
