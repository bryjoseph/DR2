using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Discrepancy_Report_2.Data.Migrations
{
    public partial class CreatedInstallRemovalFormClassControllerView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Removal_Installation_Form",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CorrectedBy = table.Column<string>(nullable: false),
                    DateCorrected = table.Column<DateTime>(nullable: false),
                    DateFiled = table.Column<DateTime>(nullable: true),
                    DateFormCreated = table.Column<DateTime>(nullable: false),
                    DateInspected = table.Column<DateTime>(nullable: true),
                    DiscrepancyReportCID = table.Column<int>(nullable: false),
                    FiledBy = table.Column<string>(nullable: true),
                    InspectedBy = table.Column<string>(nullable: true),
                    InstalledPartNumber1 = table.Column<string>(nullable: true),
                    InstalledPartNumber2 = table.Column<string>(nullable: true),
                    InstalledPartNumber3 = table.Column<string>(nullable: true),
                    InstalledPartNumber4 = table.Column<string>(nullable: true),
                    InstalledPartSerialNumber1 = table.Column<string>(nullable: true),
                    InstalledPartSerialNumber2 = table.Column<string>(nullable: true),
                    InstalledPartSerialNumber3 = table.Column<string>(nullable: true),
                    InstalledPartSerialNumber4 = table.Column<string>(nullable: true),
                    NomenclaturePart1 = table.Column<string>(nullable: true),
                    NomenclaturePart2 = table.Column<string>(nullable: true),
                    NomenclaturePart3 = table.Column<string>(nullable: true),
                    NomenclaturePart4 = table.Column<string>(nullable: true),
                    RemovedPartNumber1 = table.Column<string>(nullable: true),
                    RemovedPartNumber2 = table.Column<string>(nullable: true),
                    RemovedPartNumber3 = table.Column<string>(nullable: true),
                    RemovedPartNumber4 = table.Column<string>(nullable: true),
                    RemovedPartSerialNumber1 = table.Column<string>(nullable: true),
                    RemovedPartSerialNumber2 = table.Column<string>(nullable: true),
                    RemovedPartSerialNumber3 = table.Column<string>(nullable: true),
                    RemovedPartSerialNumber4 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Removal_Installation_Form", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Removal_Installation_Form_Discrepancy_Report_DiscrepancyReportCID",
                        column: x => x.DiscrepancyReportCID,
                        principalTable: "Discrepancy_Report",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Removal_Installation_Form_DiscrepancyReportCID",
                table: "Removal_Installation_Form",
                column: "DiscrepancyReportCID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Removal_Installation_Form");
        }
    }
}
