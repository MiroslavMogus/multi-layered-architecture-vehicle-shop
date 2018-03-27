using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VehicleShopApp.DAL.Migrations
{
    public partial class NewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleModels_VehicleModelId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleModelId",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleMakeId",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleMakeId",
                table: "Vehicles",
                column: "VehicleMakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleMakes_VehicleMakeId",
                table: "Vehicles",
                column: "VehicleMakeId",
                principalTable: "VehicleMakes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleModels_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId",
                principalTable: "VehicleModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleMakes_VehicleMakeId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleModels_VehicleModelId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleMakeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleMakeId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleModelId",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleModels_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId",
                principalTable: "VehicleModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
