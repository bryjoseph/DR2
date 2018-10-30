using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Discrepancy_Report_2.Data.Migrations
{
    public partial class AddedEmployeeIDToRemovalFormTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Removal_Installation_Form",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Removal_Installation_Form_EmployeeID",
                table: "Removal_Installation_Form",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Removal_Installation_Form_Employee_EmployeeID",
                table: "Removal_Installation_Form",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Removal_Installation_Form_Employee_EmployeeID",
                table: "Removal_Installation_Form");

            migrationBuilder.DropIndex(
                name: "IX_Removal_Installation_Form_EmployeeID",
                table: "Removal_Installation_Form");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Removal_Installation_Form");
        }
    }
}
