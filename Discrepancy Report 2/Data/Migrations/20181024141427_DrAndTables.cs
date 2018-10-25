using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Discrepancy_Report_2.Data.Migrations
{
    public partial class DrAndTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "Aircraft_Model",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Manufacturer = table.Column<string>(nullable: true),
                    ModelType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft_Model", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ATA_Chapter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChapterNumber = table.Column<int>(nullable: false),
                    ChapterSummary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATA_Chapter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationCode = table.Column<string>(nullable: true),
                    RegionCode = table.Column<string>(nullable: true),
                    RegionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance_Type",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaintenanceTypeDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance_Type", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Significant_Event",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SignificantEventDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Significant_Event", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TitleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AircraftModelID = table.Column<int>(nullable: false),
                    EasaNumber = table.Column<string>(nullable: true),
                    FaaNumber = table.Column<string>(nullable: true),
                    TailNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Aircraft_Aircraft_Model_AircraftModelID",
                        column: x => x.AircraftModelID,
                        principalTable: "Aircraft_Model",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    HireDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    TitleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_Title_TitleID",
                        column: x => x.TitleID,
                        principalTable: "Title",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aircraft_Location_Assignment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AircraftID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    Planned = table.Column<bool>(nullable: true),
                    Unplanned = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft_Location_Assignment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Aircraft_Location_Assignment_Aircraft_AircraftID",
                        column: x => x.AircraftID,
                        principalTable: "Aircraft",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aircraft_Location_Assignment_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Discrepancy_Report",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdvisoryMessage1 = table.Column<string>(nullable: true),
                    AdvisoryMessage2 = table.Column<string>(nullable: true),
                    AircraftID = table.Column<int>(nullable: false),
                    AoG = table.Column<bool>(nullable: false),
                    Approach = table.Column<bool>(nullable: false),
                    AtaChapterEnd = table.Column<string>(nullable: true),
                    AtaChapterID = table.Column<int>(nullable: false),
                    BeforeTakeoff = table.Column<bool>(nullable: false),
                    Climb = table.Column<bool>(nullable: false),
                    CorrectiveActionDescription = table.Column<string>(nullable: true),
                    Cruise = table.Column<bool>(nullable: false),
                    CustomerAcceptanceDate = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    DateDiscovered = table.Column<DateTime>(nullable: false),
                    Descent = table.Column<bool>(nullable: false),
                    DiscrepancyDescription = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: false),
                    EmployeeID1 = table.Column<int>(nullable: false),
                    EmployeeID2 = table.Column<int>(nullable: false),
                    EngineStart = table.Column<bool>(nullable: false),
                    GovOfficialDateSigned = table.Column<DateTime>(nullable: false),
                    GovernmentOfficial = table.Column<string>(nullable: true),
                    Landing = table.Column<bool>(nullable: false),
                    LeakCheck = table.Column<bool>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    MaintenanceTypeID = table.Column<int>(nullable: false),
                    MasterCaution = table.Column<bool>(nullable: false),
                    MasterWarning = table.Column<bool>(nullable: false),
                    MechanicDateSigned = table.Column<DateTime>(nullable: false),
                    OnTakeoffRoll = table.Column<bool>(nullable: false),
                    OpsCheckRequired = table.Column<bool>(nullable: false),
                    Postflight = table.Column<bool>(nullable: false),
                    QaDateSigned = table.Column<DateTime>(nullable: false),
                    ReferenceDocument1 = table.Column<string>(nullable: true),
                    ReferenceDocument2 = table.Column<string>(nullable: true),
                    ReportRecord = table.Column<string>(nullable: true),
                    Rii = table.Column<bool>(nullable: false),
                    Rollout = table.Column<bool>(nullable: false),
                    SignificantEventID = table.Column<int>(nullable: false),
                    WarningMessage1 = table.Column<string>(nullable: true),
                    WarningMessage2 = table.Column<string>(nullable: true),
                    WarningMessageOther = table.Column<string>(nullable: true),
                    WorkInstructionsPlannedAction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discrepancy_Report", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Discrepancy_Report_Aircraft_AircraftID",
                        column: x => x.AircraftID,
                        principalTable: "Aircraft",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discrepancy_Report_ATA_Chapter_AtaChapterID",
                        column: x => x.AtaChapterID,
                        principalTable: "ATA_Chapter",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discrepancy_Report_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discrepancy_Report_Location_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discrepancy_Report_Maintenance_Type_MaintenanceTypeID",
                        column: x => x.MaintenanceTypeID,
                        principalTable: "Maintenance_Type",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discrepancy_Report_Significant_Event_SignificantEventID",
                        column: x => x.SignificantEventID,
                        principalTable: "Significant_Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_AircraftModelID",
                table: "Aircraft",
                column: "AircraftModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_Location_Assignment_AircraftID",
                table: "Aircraft_Location_Assignment",
                column: "AircraftID");

            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_Location_Assignment_LocationID",
                table: "Aircraft_Location_Assignment",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveAction_EmployeeID",
                table: "CorrectiveAction",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Discrepancy_Report_AircraftID",
                table: "Discrepancy_Report",
                column: "AircraftID");

            migrationBuilder.CreateIndex(
                name: "IX_Discrepancy_Report_AtaChapterID",
                table: "Discrepancy_Report",
                column: "AtaChapterID");

            migrationBuilder.CreateIndex(
                name: "IX_Discrepancy_Report_EmployeeID",
                table: "Discrepancy_Report",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discrepancy_Report_LocationID",
                table: "Discrepancy_Report",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Discrepancy_Report_MaintenanceTypeID",
                table: "Discrepancy_Report",
                column: "MaintenanceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Discrepancy_Report_SignificantEventID",
                table: "Discrepancy_Report",
                column: "SignificantEventID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TitleID",
                table: "Employee",
                column: "TitleID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Aircraft_Location_Assignment");

            migrationBuilder.DropTable(
                name: "CorrectiveAction");

            migrationBuilder.DropTable(
                name: "Discrepancy_Report");

            migrationBuilder.DropTable(
                name: "Aircraft");

            migrationBuilder.DropTable(
                name: "ATA_Chapter");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Maintenance_Type");

            migrationBuilder.DropTable(
                name: "Significant_Event");

            migrationBuilder.DropTable(
                name: "Aircraft_Model");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
