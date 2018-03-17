using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VehicleShop.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO VehicleFeatures (Name) VALUES ('Night vision')");
            migrationBuilder.Sql("INSERT INTO VehicleFeatures (Name) VALUES ('Active suspension')");
            migrationBuilder.Sql("INSERT INTO VehicleFeatures (Name) VALUES ('USB Socket')");
            migrationBuilder.Sql("INSERT INTO VehicleFeatures (Name) VALUES ('LED front indicators')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM VehicleFeatures WHERE Name IN ('Night vision', 'Active suspension', 'USB Socket', 'LED front indicators')");
        }
    }
}
