using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Discrepancy_Report_2.Data.Migrations
{
    public partial class changingEmpColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorrectiveAction");

            migrationBuilder.DropIndex(
                name: "IX_Discrepancy_Report_EmployeeID",
                table: "Discrepancy_Report");

            migrationBuilder.RenameColumn(
                name: "EmployeeID2",
                table: "Discrepancy_Report",
                newName: "Employee2ID");

            migrationBuilder.RenameColumn(
                name: "EmployeeID1",
                table: "Discrepancy_Report",
                newName: "Employee1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Discrepancy_Report_EmployeeID",
                table: "Discrepancy_Report",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Discrepancy_Report_EmployeeID",
                table: "Discrepancy_Report");

            migrationBuilder.RenameColumn(
                name: "Employee2ID",
                table: "Discrepancy_Report",
                newName: "EmployeeID2");

            migrationBuilder.RenameColumn(
                name: "Employee1ID",
                table: "Discrepancy_Report",
                newName: "EmployeeID1");

            migrationBuilder.CreateTable(
                name: "CorrectiveAction",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CorrectiveActionDescription = table.Column<string>(nullable: true),
                    DiscrepancyReportCID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    EmployeeID1 = table.Column<int>(nullable: false),
                    GovOfficialDateSigned = table.Column<DateTime>(nullable: false),
                    GovernmentOfficial = table.Column<string>(nullable: true),
                    LeakCheck = table.Column<bool>(nullable: false),
                    MechanicDateSigned = table.Column<DateTime>(nullable: false),
                    OpsCheckRequired = table.Column<bool>(nullable: false),
                    QaDateSigned = table.Column<DateTime>(nullable: false),
                    ReferenceGroupID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveAction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CorrectiveAction_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discrepancy_Report_EmployeeID",
                table: "Discrepancy_Report",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveAction_EmployeeID",
                table: "CorrectiveAction",
                column: "EmployeeID");
        }
    }
}
