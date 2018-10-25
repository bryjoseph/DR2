using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discrepancy_Report_2.Models;

namespace Discrepancy_Report_2.Data
{
    public class DbInitializer
    {
        public static void Initialize(MaintenanceDbContext context)
        {
            context.Database.EnsureCreated();

            //Look for any aircraft values to see if the DB successfully seeded
            if (context.Aircrafts.Any())
            {
                return; // returning means DB successfully seeded
            }

            var aircraftModels = new AircraftModel[]
            {
                //new AircraftModel{ModelType="A-29", Manufacturer="Embraer", AircraftID=1},
                //new AircraftModel{ModelType="C-146", Manufacturer="Fairchild Dornier", AircraftID=2},
                //new AircraftModel{ModelType="C-146", Manufacturer="Fairchild Dornier", AircraftID=3},
                //new AircraftModel{ModelType="A-29", Manufacturer="Embraer", AircraftID=4},
                //new AircraftModel{ModelType="A-29", Manufacturer="Embraer", AircraftID=5}
                new AircraftModel{ModelType="A-29", Manufacturer="Embraer"},
                new AircraftModel{ModelType="C-146", Manufacturer="Fairchild Dornier"}
            };
            foreach (AircraftModel am in aircraftModels)
            {
                context.AircraftModels.Add(am);
            }
            context.SaveChanges();

            var aircrafts = new Aircraft[]
            {
                 new Aircraft{FaaNumber="0011001",EasaNumber=null,TailNumber="1234567", AircraftModelID=1},
                 new Aircraft{FaaNumber="0011002",EasaNumber=null,TailNumber="1234568", AircraftModelID=1},
                 new Aircraft{FaaNumber="0011003",EasaNumber=null,TailNumber="1234569", AircraftModelID=1},
                 new Aircraft{FaaNumber="0011004",EasaNumber=null,TailNumber="1234560", AircraftModelID=2},
                 new Aircraft{FaaNumber="0011005",EasaNumber=null,TailNumber="1234561", AircraftModelID=2}
                //new Aircraft{FaaNumber="0011001",EasaNumber=null,TailNumber="1234567"},
                //new Aircraft{FaaNumber="0011002",EasaNumber=null,TailNumber="1234568"},
                //new Aircraft{FaaNumber="0011003",EasaNumber=null,TailNumber="1234569"},
                //new Aircraft{FaaNumber="0011004",EasaNumber=null,TailNumber="1234560"},
                //new Aircraft{FaaNumber="0011005",EasaNumber=null,TailNumber="1234561"}
            };
            foreach (Aircraft a in aircrafts)
            {
                context.Aircrafts.Add(a);
            }
            context.SaveChanges();

            var locations = new Location[]
            {
                new Location{RegionCode="DENV", RegionName="West", LocationCode="WWRM"},
                new Location{RegionCode="CALI", RegionName="Pacific", LocationCode="WWPO"},
                new Location{RegionCode="BOST", RegionName="East", LocationCode="ECCA"},
                new Location{RegionCode="FLAA", RegionName="South East", LocationCode="SESC"},
                new Location{RegionCode="TENN", RegionName="Central", LocationCode="CCAM"}
            };
            foreach (Location l in locations)
            {
                context.Locations.Add(l);
            }
            context.SaveChanges();

            var locationAssignments = new AircraftLocationAssignment[]
            {
                new AircraftLocationAssignment{LocationID=1, AircraftID=1, Planned=true, Unplanned=false},
                new AircraftLocationAssignment{LocationID=1, AircraftID=2, Planned=true, Unplanned=false},
                new AircraftLocationAssignment{LocationID=2, AircraftID=3, Planned=true, Unplanned=false},
                new AircraftLocationAssignment{LocationID=3, AircraftID=4, Planned=true, Unplanned=false},
                new AircraftLocationAssignment{LocationID=4, AircraftID=5, Planned=false, Unplanned=true}
            };
            foreach (AircraftLocationAssignment ala in locationAssignments)
            {
                context.AircraftLocationAssignments.Add(ala);
            }
            context.SaveChanges();

            var titles = new Title[]
            {
                //new Title{EmployeeID=1, TitleName="Technician"},
                //new Title{EmployeeID=2, TitleName="Quality Assure"},
                //new Title{EmployeeID=3, TitleName="Technician"},
                //new Title{EmployeeID=4, TitleName="Government Official"},
                //new Title{EmployeeID=5, TitleName="Supervisor"}
                new Title{TitleName="Technician"},
                new Title{TitleName="Quality Assure"},
                new Title{TitleName="Technician"},
                new Title{TitleName="Government Official"},
                new Title{TitleName="Supervisor"}
            };
            foreach (Title t in titles)
            {
                context.Titles.Add(t);
            }
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee{FirstName="Bob", LastName="Haskins", HireDate=DateTime.Parse("2018-10-01"), TitleID=1},
                new Employee{FirstName="Claire", LastName="Little", HireDate=DateTime.Parse("2010-06-05"), TitleID=2},
                new Employee{FirstName="Tom", LastName="Law", HireDate=DateTime.Parse("2015-12-11"), TitleID=1},
                new Employee{FirstName="Jason", LastName="Day", HireDate=DateTime.Parse("2011-03-25"), TitleID=4},
                new Employee{FirstName="Kelly", LastName="Wynn", HireDate=DateTime.Parse("2009-05-16"), TitleID=5}
            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            // adding ATA Chapters
            var chapters = new AtaChapter[]
            {
                new AtaChapter{ChapterNumber=01, ChapterSummary="Introduction / Aircraft General"},
                new AtaChapter{ChapterNumber=02, ChapterSummary="Operations Information"},
                new AtaChapter{ChapterNumber=03, ChapterSummary="Periodic Inspections"},
                new AtaChapter{ChapterNumber=04, ChapterSummary="Dimensions and Areas"},
                new AtaChapter{ChapterNumber=05, ChapterSummary="Lifting and Shoring"},
                new AtaChapter{ChapterNumber=06, ChapterSummary="Leveling and Weighing"},
                new AtaChapter{ChapterNumber=07, ChapterSummary="Towing and Taxiing"},
                new AtaChapter{ChapterNumber=08, ChapterSummary="Parking, Mooring, Storage and Return to Service"},
                new AtaChapter{ChapterNumber=09, ChapterSummary="Placards and Markings"},
                new AtaChapter{ChapterNumber=10, ChapterSummary="Servicing Routine Maintenance"},
                new AtaChapter{ChapterNumber=11, ChapterSummary="Vibration and Noise Analysis (Helicopters)"}
            };
            foreach (AtaChapter ata in chapters)
            {
                context.AtaChapters.Add(ata);
            }
            context.SaveChanges();

            // adding Significant Event
            var events = new SignificantEvent[]
            {
                new SignificantEvent{SignificantEventDescription="Bird Strike"},
                new SignificantEvent{SignificantEventDescription="Hard Landing"},
                new SignificantEvent{SignificantEventDescription="Flap Over Speed"},
                new SignificantEvent{SignificantEventDescription="Gear Over Speed"},
                new SignificantEvent{SignificantEventDescription="Lightning Strike"}
            };
            foreach (SignificantEvent se in events)
            {
                context.SignificantEvents.Add(se);
            }
            context.SaveChanges();

            // adding Maintenance Type
            var types = new MaintenanceType[]
            {
                new MaintenanceType{MaintenanceTypeDescription="Scheduled"},
                new MaintenanceType{MaintenanceTypeDescription="Unscheduled"},
                new MaintenanceType{MaintenanceTypeDescription="Major Mod or C-Check"},
                new MaintenanceType{MaintenanceTypeDescription="Pilot Writeup"},
                new MaintenanceType{MaintenanceTypeDescription="Customer Defered"},
                new MaintenanceType{MaintenanceTypeDescription="Grounding Writeup"}
            };
            foreach(MaintenanceType mt in types)
            {
                context.MaintenanceTypes.Add(mt);
            }
            context.SaveChanges();

            // adding Reference Group Data
            //var references = new ReferenceGroup[]
            //{
            //    new ReferenceGroup{ReferenceDocument1="0001-90235", ReferenceDocument2="0001-90236"},
            //    new ReferenceGroup{ReferenceDocument1="0001-90199", ReferenceDocument2="0001-90200"},
            //    new ReferenceGroup{ReferenceDocument1="0001-80236", ReferenceDocument2="0001-80005"},
            //    new ReferenceGroup{ReferenceDocument1="0021-70067", ReferenceDocument2="0021-70068"},
            //    new ReferenceGroup{ReferenceDocument1="0004-90250", ReferenceDocument2="0004-90250"},
            //};

            //foreach(ReferenceGroup rg in references)
            //{
            //    context.ReferenceGroups.Add(rg);
            //}
            //context.SaveChanges();

            // adding Corrective Actions
            //var actions = new CorrectiveAction[]
            //{
            //    new CorrectiveAction{CorrectiveActionDescription="Weapon mount inspected and deemed operable",
            //                        OpsCheckRequired=false, LeakCheck=false, EmployeeID=1, MechanicDateSigned=DateTime.Parse("2018-07-20"),
            //                        EmployeeID1=2, QaDateSigned=DateTime.Parse("2018-07-20"), GovernmentOfficial="Tim Gates",
            //                        GovOfficialDateSigned=DateTime.Parse("2018-07-21"), ReferenceGroupID=1},
            //    new CorrectiveAction{CorrectiveActionDescription="The gear was deemed operable and cleared for flight",
            //                        OpsCheckRequired=true, LeakCheck=false, EmployeeID=3, MechanicDateSigned=DateTime.Parse("2018-08-15"),
            //                        EmployeeID1=2, QaDateSigned=DateTime.Parse("2018-08-15"), GovernmentOfficial="Tim Gates",
            //                        GovOfficialDateSigned=DateTime.Parse("2018-08-16"), ReferenceGroupID=2},
            //    new CorrectiveAction{CorrectiveActionDescription="Airframe was inspected and cleared because no damage was present",
            //                        OpsCheckRequired=false, LeakCheck=true, EmployeeID=1, MechanicDateSigned=DateTime.Parse("2018-03-11"),
            //                        EmployeeID1=2, QaDateSigned=DateTime.Parse("2018-03-11"), GovernmentOfficial="Sarah Bates",
            //                        GovOfficialDateSigned=DateTime.Parse("2018-03-12"), ReferenceGroupID=3},
            //    new CorrectiveAction{CorrectiveActionDescription="Oil changed and engine checked to see if operable",
            //                        OpsCheckRequired=true, LeakCheck=true, EmployeeID=3, MechanicDateSigned=DateTime.Parse("2018-07-21"),
            //                        EmployeeID1=2, QaDateSigned=DateTime.Parse("2018-07-21"), GovernmentOfficial="Lindsey Southgate",
            //                        GovOfficialDateSigned=DateTime.Parse("2018-07-22"), ReferenceGroupID=4},
            //    new CorrectiveAction{CorrectiveActionDescription="Placards fixed and secured for safety",
            //                        OpsCheckRequired=false, LeakCheck=false, EmployeeID=1, MechanicDateSigned=DateTime.Parse("2018-12-15"),
            //                        EmployeeID1=2, QaDateSigned=DateTime.Parse("2018-12-15"), GovernmentOfficial=null,
            //                        ReferenceGroupID=5},
            //};
            //foreach (CorrectiveAction ca in actions)
            //{
            //    context.CorrectiveActions.Add(ca);
            //}
            //context.SaveChanges();

            var reports = new DiscrepancyReportC[]
            {
                new DiscrepancyReportC{ReportRecord="ABVD-0000001", AircraftID=1, EmployeeID=1, DateDiscovered=DateTime.Parse("2018-12-01"),
                                        LocationID=1, AtaChapterID=1, AtaChapterEnd="000_010", EngineStart=false, BeforeTakeoff=false,
                                        OnTakeoffRoll=false, Climb=true, Cruise=true, Descent=true, Approach=false, Landing=false, Rollout=false,
                                        Postflight=false, SignificantEventID=1, MaintenanceTypeID=2, MasterWarning=false, MasterCaution=true,
                                        WarningMessage1=null, WarningMessage2=null, AdvisoryMessage1=null, AdvisoryMessage2=null, WarningMessageOther=null,
                                        DiscrepancyDescription="Bird struck the aircraft while in flight and changed the flight characteristics Aircraft must be grounded until fixed.",
                                        AoG=true, Rii=false, WorkInstructionsPlannedAction="Check the are where the bird struck the plane.",
                                        CorrectiveActionDescription="Found dent in a winglet from bird strike. New winglet installed and plane flight characteristics checked after fix",
                                        OpsCheckRequired=false, LeakCheck=true, TechnicianName="Bob Haskins", TechnicianDateSigned=DateTime.Parse("2018-12-01"),
                                        QaName="Claire Little", QaDateSigned=DateTime.Parse("2018-12-01"), GovernmentOfficial="Steve Harmon",
                                        GovOfficialDateSigned =DateTime.Parse("2018-12-01"), ReferenceDocument1="100_1", ReferenceDocument2="100_2",
                                        CustomerName="Jeff Ways", CustomerAcceptanceDate=DateTime.Parse("2018-12-03")},

                new DiscrepancyReportC{ReportRecord="ABVD-0000002", AircraftID=2, EmployeeID=3, DateDiscovered=DateTime.Parse("2018-12-03"),
                                        LocationID=2, AtaChapterID=2, AtaChapterEnd="-01-115", EngineStart=true, BeforeTakeoff=true,
                                        OnTakeoffRoll=false, Climb=false, Cruise=false, Descent=false, Approach=false, Landing=false, Rollout=false,
                                        Postflight=false, SignificantEventID=2, MaintenanceTypeID=2, MasterCaution=false, MasterWarning=false,
                                        WarningMessage1 ="GEAR OVER SPEED", WarningMessage2="", AdvisoryMessage1="", AdvisoryMessage2="", WarningMessageOther="",
                                        DiscrepancyDescription="On landing the gear was over stressed by the pilots speed so the gear assembly" +
                                        "has to be looked at.", AoG=true, Rii=false, WorkInstructionsPlannedAction="Check to see if anything has changed" +
                                        "during the landing and the gear over speed", CorrectiveActionDescription="The gear was deemed opperable" +
                                        "and was cleared for flight", OpsCheckRequired=true, LeakCheck=false, TechnicianName="Tom Law", TechnicianDateSigned=DateTime.Parse("2018-12-03"),
                                        QaName="Claire Little", QaDateSigned=DateTime.Parse("2018-12-03"), GovernmentOfficial=null,
                                        ReferenceDocument1=null, ReferenceDocument2=null, CustomerName="Jeff Ways", CustomerAcceptanceDate=DateTime.Parse("2018-12-06")},

                new DiscrepancyReportC{ReportRecord="ABVD-0000003", AircraftID=3, EmployeeID=1, DateDiscovered=DateTime.Parse("2018-12-05"),
                                        LocationID=3, AtaChapterID=3, AtaChapterEnd="-00-012", EngineStart=false, BeforeTakeoff=false,
                                        OnTakeoffRoll=false, Climb=false, Cruise=false, Descent=false, Approach=false, Landing=false, Rollout=false,
                                        Postflight=false, SignificantEventID=3, MaintenanceTypeID=1, MasterCaution=false, MasterWarning=false,
                                        WarningMessage1="", WarningMessage2="", AdvisoryMessage1="", AdvisoryMessage2="", WarningMessageOther="",
                                        DiscrepancyDescription="Routine oil change on the aircraft", AoG=true, Rii=false,
                                        WorkInstructionsPlannedAction ="The oil on the plane needed to be changed after 10,000 flight hours",
                                        CorrectiveActionDescription ="Change oil and check engine for proper function", OpsCheckRequired=false,
                                        LeakCheck =true, TechnicianName="Bob Haskins", TechnicianDateSigned=DateTime.Parse("2018-12-05"),
                                        QaName="Claire Little", QaDateSigned=DateTime.Parse("2018-12-05"), GovernmentOfficial=null, ReferenceDocument1="11-0005",
                                        ReferenceDocument2=null, CustomerName="Jeff Ways", CustomerAcceptanceDate=DateTime.Parse("2018-12-08")},

                new DiscrepancyReportC{ReportRecord="ABVD-0000004", AircraftID=4, EmployeeID=3, DateDiscovered=DateTime.Parse("2018-12-08"),
                                        LocationID=4, AtaChapterID=5, AtaChapterEnd="-00-300", EngineStart=false, BeforeTakeoff=false,
                                        OnTakeoffRoll=false, Climb=false, Cruise=false, Descent=false, Approach=false, Landing=false, Rollout=false,
                                        Postflight=false, SignificantEventID=3, MaintenanceTypeID=1, MasterCaution=false, MasterWarning=false,
                                        WarningMessage1="", WarningMessage2="", AdvisoryMessage1="", AdvisoryMessage2="", WarningMessageOther="",
                                        DiscrepancyDescription="Placards are falling off must be replaced", AoG=true, Rii=false,
                                        WorkInstructionsPlannedAction ="Fix the placards and make sure connection is tight",
                                        CorrectiveActionDescription ="Placards fixed and secured tightly", OpsCheckRequired=false,
                                        LeakCheck =true, TechnicianName="Tom Law", TechnicianDateSigned=DateTime.Parse("2018-12-08"),
                                        QaName="Claire Little", QaDateSigned=DateTime.Parse("2018-12-08"), GovernmentOfficial=null, ReferenceDocument1=null,
                                        ReferenceDocument2=null, CustomerName="Jeff Ways", CustomerAcceptanceDate=DateTime.Parse("2018-12-08")},

                new DiscrepancyReportC{ReportRecord="ABVD-0000005", AircraftID=5, EmployeeID=1, DateDiscovered=DateTime.Parse("2018-12-09"),
                                        LocationID=5, AtaChapterID=7, AtaChapterEnd="-00-301", EngineStart=false, BeforeTakeoff=false,
                                        OnTakeoffRoll=false, Climb=false, Cruise=false, Descent=false, Approach=false, Landing=false, Rollout=false,
                                        Postflight=false, SignificantEventID=5, MaintenanceTypeID=1, MasterCaution=false, MasterWarning=false,
                                        WarningMessage1="", WarningMessage2="", AdvisoryMessage1="", AdvisoryMessage2="", WarningMessageOther="",
                                        DiscrepancyDescription="Aircraft is undergoing a full inspection. This is a scheduled event.", AoG=true, Rii=false,
                                        WorkInstructionsPlannedAction ="The aircraft and it's system will undergo full system inspection",
                                        CorrectiveActionDescription ="Aircraft inspected and deemed flight worthy. Everything operational",
                                        OpsCheckRequired=true, LeakCheck=true, TechnicianName="Bob Haskins", TechnicianDateSigned=DateTime.Parse("2018-12-09"),
                                        QaName="Claire Little", QaDateSigned=DateTime.Parse("2018-12-09"), GovernmentOfficial=null, ReferenceDocument1=null,
                                        ReferenceDocument2=null, CustomerName="Jeff Ways", CustomerAcceptanceDate=DateTime.Parse("2018-12-11")}
            };
            foreach(DiscrepancyReportC dr in reports)
            {
                context.DiscrepancyReportCs.Add(dr);
            }
            context.SaveChanges();
        }
    }
}
