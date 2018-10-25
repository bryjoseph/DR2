using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Discrepancy_Report_2.Data.Migrations
{
    public partial class Changed1st2ndEmpColumnsDataTypeToStrings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employee1ID",
                table: "Discrepancy_Report");

            migrationBuilder.DropColumn(
                name: "Employee2ID",
                table: "Discrepancy_Report");

            migrationBuilder.RenameColumn(
                name: "MechanicDateSigned",
                table: "Discrepancy_Report",
                newName: "TechnicianDateSigned");

            migrationBuilder.AddColumn<string>(
                name: "QaName",
                table: "Discrepancy_Report",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicianName",
                table: "Discrepancy_Report",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QaName",
                table: "Discrepancy_Report");

            migrationBuilder.DropColumn(
                name: "TechnicianName",
                table: "Discrepancy_Report");

            migrationBuilder.RenameColumn(
                name: "TechnicianDateSigned",
                table: "Discrepancy_Report",
                newName: "MechanicDateSigned");

            migrationBuilder.AddColumn<int>(
                name: "Employee1ID",
                table: "Discrepancy_Report",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Employee2ID",
                table: "Discrepancy_Report",
                nullable: false,
                defaultValue: 0);
        }
    }
}
