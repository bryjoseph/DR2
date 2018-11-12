using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Discrepancy_Report_2.Data.Migrations
{
    public partial class RemovedNullablePartCatandPartSubcat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderForm_Part_Category_PartCategoryID",
                table: "OrderForm");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderForm_Part_Subcategory_PartSubCategoryID",
                table: "OrderForm");

            migrationBuilder.AlterColumn<int>(
                name: "PartSubCategoryID",
                table: "OrderForm",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PartCategoryID",
                table: "OrderForm",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderForm_Part_Category_PartCategoryID",
                table: "OrderForm",
                column: "PartCategoryID",
                principalTable: "Part_Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderForm_Part_Subcategory_PartSubCategoryID",
                table: "OrderForm",
                column: "PartSubCategoryID",
                principalTable: "Part_Subcategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderForm_Part_Category_PartCategoryID",
                table: "OrderForm");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderForm_Part_Subcategory_PartSubCategoryID",
                table: "OrderForm");

            migrationBuilder.AlterColumn<int>(
                name: "PartSubCategoryID",
                table: "OrderForm",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PartCategoryID",
                table: "OrderForm",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_OrderForm_Part_Category_PartCategoryID",
                table: "OrderForm",
                column: "PartCategoryID",
                principalTable: "Part_Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderForm_Part_Subcategory_PartSubCategoryID",
                table: "OrderForm",
                column: "PartSubCategoryID",
                principalTable: "Part_Subcategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
