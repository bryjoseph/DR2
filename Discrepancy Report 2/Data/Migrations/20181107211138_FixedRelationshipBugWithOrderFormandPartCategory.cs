using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Discrepancy_Report_2.Data.Migrations
{
    public partial class FixedRelationshipBugWithOrderFormandPartCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Removal_Installation_Form_Employee_EmployeeID",
                table: "Removal_Installation_Form");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Part_Subcategory",
                newName: "PartCategoryID");

            migrationBuilder.RenameColumn(
                name: "SubCategoryID",
                table: "Part",
                newName: "PartSubCategoryID");

            migrationBuilder.AddColumn<int>(
                name: "OrderFormID",
                table: "Part_Category",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Part_Subcategory_PartCategoryID",
                table: "Part_Subcategory",
                column: "PartCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Part_PartSubCategoryID",
                table: "Part",
                column: "PartSubCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Part_Subcategory_PartSubCategoryID",
                table: "Part",
                column: "PartSubCategoryID",
                principalTable: "Part_Subcategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Subcategory_Part_Category_PartCategoryID",
                table: "Part_Subcategory",
                column: "PartCategoryID",
                principalTable: "Part_Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Part_Part_Subcategory_PartSubCategoryID",
                table: "Part");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_Subcategory_Part_Category_PartCategoryID",
                table: "Part_Subcategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Removal_Installation_Form_Employee_EmployeeID",
                table: "Removal_Installation_Form");

            migrationBuilder.DropIndex(
                name: "IX_Part_Subcategory_PartCategoryID",
                table: "Part_Subcategory");

            migrationBuilder.DropIndex(
                name: "IX_Part_PartSubCategoryID",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "OrderFormID",
                table: "Part_Category");

            migrationBuilder.RenameColumn(
                name: "PartCategoryID",
                table: "Part_Subcategory",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "PartSubCategoryID",
                table: "Part",
                newName: "SubCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Removal_Installation_Form_Employee_EmployeeID",
                table: "Removal_Installation_Form",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
