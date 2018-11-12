using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Discrepancy_Report_2.Data.Migrations
{
    public partial class NewOrderForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Form_Employee_EmployeeID",
                table: "Order_Form");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Form_Order_Status_OrderStatusID",
                table: "Order_Form");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Form_Part_Category_PartCategoryID",
                table: "Order_Form");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Form_Part_Subcategory_PartSubCategoryID",
                table: "Order_Form");

            migrationBuilder.DropIndex(
                name: "IX_Order_Form_EmployeeID",
                table: "Order_Form");

            migrationBuilder.DropIndex(
                name: "IX_Order_Form_OrderStatusID",
                table: "Order_Form");

            migrationBuilder.DropIndex(
                name: "IX_Order_Form_PartCategoryID",
                table: "Order_Form");

            migrationBuilder.DropIndex(
                name: "IX_Order_Form_PartSubCategoryID",
                table: "Order_Form");

            migrationBuilder.CreateTable(
                name: "OrderForm",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOrderCreated = table.Column<DateTime>(nullable: false),
                    Edd = table.Column<DateTime>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: false),
                    OrderNumber = table.Column<string>(nullable: false),
                    OrderStatusID = table.Column<int>(nullable: false),
                    PartCategoryID = table.Column<int>(nullable: true),
                    PartDocumentNumber = table.Column<string>(nullable: true),
                    PartName = table.Column<string>(nullable: true),
                    PartQuantity = table.Column<int>(nullable: true),
                    PartSubCategoryID = table.Column<int>(nullable: true),
                    TrackingNumber = table.Column<string>(nullable: true),
                    Ui = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderForm", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderForm_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderForm_Order_Status_OrderStatusID",
                        column: x => x.OrderStatusID,
                        principalTable: "Order_Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderForm_Part_Category_PartCategoryID",
                        column: x => x.PartCategoryID,
                        principalTable: "Part_Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderForm_Part_Subcategory_PartSubCategoryID",
                        column: x => x.PartSubCategoryID,
                        principalTable: "Part_Subcategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderForm_EmployeeID",
                table: "OrderForm",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderForm_OrderStatusID",
                table: "OrderForm",
                column: "OrderStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderForm_PartCategoryID",
                table: "OrderForm",
                column: "PartCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderForm_PartSubCategoryID",
                table: "OrderForm",
                column: "PartSubCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderForm");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Form_EmployeeID",
                table: "Order_Form",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Form_OrderStatusID",
                table: "Order_Form",
                column: "OrderStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Form_PartCategoryID",
                table: "Order_Form",
                column: "PartCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Form_PartSubCategoryID",
                table: "Order_Form",
                column: "PartSubCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Form_Employee_EmployeeID",
                table: "Order_Form",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Form_Order_Status_OrderStatusID",
                table: "Order_Form",
                column: "OrderStatusID",
                principalTable: "Order_Status",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Form_Part_Category_PartCategoryID",
                table: "Order_Form",
                column: "PartCategoryID",
                principalTable: "Part_Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Form_Part_Subcategory_PartSubCategoryID",
                table: "Order_Form",
                column: "PartSubCategoryID",
                principalTable: "Part_Subcategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
