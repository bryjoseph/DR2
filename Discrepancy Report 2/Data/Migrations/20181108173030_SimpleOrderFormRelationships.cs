using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Discrepancy_Report_2.Data.Migrations
{
    public partial class SimpleOrderFormRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Form_Part_PartID",
                table: "Order_Form");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_Part_Subcategory_PartSubCategoryID",
                table: "Part");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_Subcategory_Part_Category_PartCategoryID",
                table: "Part_Subcategory");

            migrationBuilder.DropIndex(
                name: "IX_Part_Subcategory_PartCategoryID",
                table: "Part_Subcategory");

            migrationBuilder.DropIndex(
                name: "IX_Part_PartSubCategoryID",
                table: "Part");

            migrationBuilder.DropIndex(
                name: "IX_Order_Form_PartID",
                table: "Order_Form");

            migrationBuilder.DropColumn(
                name: "PartCategoryID",
                table: "Part_Subcategory");

            migrationBuilder.DropColumn(
                name: "OrderFormID",
                table: "Part_Category");

            migrationBuilder.DropColumn(
                name: "PartSubCategoryID",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "PartID",
                table: "Order_Form");

            migrationBuilder.RenameColumn(
                name: "ColorDescription",
                table: "Tag_Color",
                newName: "ColorOfTag");

            migrationBuilder.AddColumn<string>(
                name: "PartName",
                table: "Order_Form",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartName",
                table: "Order_Form");

            migrationBuilder.RenameColumn(
                name: "ColorOfTag",
                table: "Tag_Color",
                newName: "ColorDescription");

            migrationBuilder.AddColumn<int>(
                name: "PartCategoryID",
                table: "Part_Subcategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderFormID",
                table: "Part_Category",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartSubCategoryID",
                table: "Part",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PartID",
                table: "Order_Form",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Part_Subcategory_PartCategoryID",
                table: "Part_Subcategory",
                column: "PartCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Part_PartSubCategoryID",
                table: "Part",
                column: "PartSubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Form_PartID",
                table: "Order_Form",
                column: "PartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Form_Part_PartID",
                table: "Order_Form",
                column: "PartID",
                principalTable: "Part",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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
        }
    }
}
