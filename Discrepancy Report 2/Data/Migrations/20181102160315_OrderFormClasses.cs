using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Discrepancy_Report_2.Data.Migrations
{
    public partial class OrderFormClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order_Status",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Status", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Part_Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Part_Subcategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    SubCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part_Subcategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tag_Color",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColorDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag_Color", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PartName = table.Column<string>(nullable: false),
                    PartNumber = table.Column<int>(nullable: false),
                    PartSerialNumber = table.Column<int>(nullable: false),
                    SubCategoryID = table.Column<int>(nullable: false),
                    TagColorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Part_Tag_Color_TagColorID",
                        column: x => x.TagColorID,
                        principalTable: "Tag_Color",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Form",
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
                    PartID = table.Column<int>(nullable: true),
                    PartQuantity = table.Column<int>(nullable: true),
                    PartSubCategoryID = table.Column<int>(nullable: true),
                    TrackingNumber = table.Column<string>(nullable: true),
                    Ui = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Form", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_Form_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Form_Order_Status_OrderStatusID",
                        column: x => x.OrderStatusID,
                        principalTable: "Order_Status",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Form_Part_Category_PartCategoryID",
                        column: x => x.PartCategoryID,
                        principalTable: "Part_Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Form_Part_PartID",
                        column: x => x.PartID,
                        principalTable: "Part",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Form_Part_Subcategory_PartSubCategoryID",
                        column: x => x.PartSubCategoryID,
                        principalTable: "Part_Subcategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Order_Form_PartID",
                table: "Order_Form",
                column: "PartID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Form_PartSubCategoryID",
                table: "Order_Form",
                column: "PartSubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Part_TagColorID",
                table: "Part",
                column: "TagColorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Form");

            migrationBuilder.DropTable(
                name: "Order_Status");

            migrationBuilder.DropTable(
                name: "Part_Category");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "Part_Subcategory");

            migrationBuilder.DropTable(
                name: "Tag_Color");
        }
    }
}
