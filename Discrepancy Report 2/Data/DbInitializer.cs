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

            // seeding the removal installation form data
            var forms = new RemovalInstallationForm[]
            {
                new RemovalInstallationForm{DiscrepancyReportCID=1, DateFormCreated=DateTime.Parse("2018-12-01"), EmployeeID=1, RemovedPartNumber1="PN1234", RemovedPartSerialNumber1="SN1234", NomenclaturePart1="Nom1",
                                            RemovedPartNumber2="PN1235", RemovedPartSerialNumber2="SN1235", NomenclaturePart2="Nom2", RemovedPartNumber3=null, RemovedPartSerialNumber3=null, NomenclaturePart3=null,
                                            RemovedPartNumber4=null, RemovedPartSerialNumber4=null, NomenclaturePart4=null, InstalledPartNumber1="PN0987", InstalledPartSerialNumber1="SN0987",
                                            InstalledPartNumber2="SN0986", InstalledPartSerialNumber2="SN0986", InstalledPartNumber3=null, InstalledPartSerialNumber3=null,
                                            InstalledPartNumber4=null, InstalledPartSerialNumber4=null, CorrectedBy="Bob Haskins", DateCorrected=DateTime.Parse("2018-12-01"), InspectedBy=null, DateInspected=null,
                                            FiledBy=null, DateFiled=null},
                new RemovalInstallationForm{DiscrepancyReportCID=2, DateFormCreated=DateTime.Parse("2018-12-03"), EmployeeID=3, RemovedPartNumber1="PN1123", RemovedPartSerialNumber1="SN1123", NomenclaturePart1="Nom1",
                                            RemovedPartNumber2="PN1135", RemovedPartSerialNumber2="SN1135", NomenclaturePart2="Nom2", RemovedPartNumber3="PN1126", RemovedPartSerialNumber3="SN1126", NomenclaturePart3="Nom3",
                                            RemovedPartNumber4=null, RemovedPartSerialNumber4=null, NomenclaturePart4=null, InstalledPartNumber1="PN1987", InstalledPartSerialNumber1="SN1987",
                                            InstalledPartNumber2=null, InstalledPartSerialNumber2=null, InstalledPartNumber3=null, InstalledPartSerialNumber3=null,
                                            InstalledPartNumber4=null, InstalledPartSerialNumber4=null, CorrectedBy="Tom Law", DateCorrected=DateTime.Parse("2018-12-03"), InspectedBy="Claire Little", DateInspected=DateTime.Parse("2018-12-03"),
                                            FiledBy=null, DateFiled=null},
                new RemovalInstallationForm{DiscrepancyReportCID=3, DateFormCreated=DateTime.Parse("2018-12-05"), EmployeeID=1, RemovedPartNumber1="PN1114", RemovedPartSerialNumber1="SN1114", NomenclaturePart1="Nom1",
                                            RemovedPartNumber2="PN1115", RemovedPartSerialNumber2="SN1115", NomenclaturePart2="Nom2", RemovedPartNumber3=null, RemovedPartSerialNumber3=null, NomenclaturePart3=null,
                                            RemovedPartNumber4=null, RemovedPartSerialNumber4=null, NomenclaturePart4=null, InstalledPartNumber1="PN0987", InstalledPartSerialNumber1="SN0987",
                                            InstalledPartNumber2="SN2986", InstalledPartSerialNumber2="SN2986", InstalledPartNumber3="PN2987", InstalledPartSerialNumber3="SN2987",
                                            InstalledPartNumber4="PN2988", InstalledPartSerialNumber4="SN2988", CorrectedBy="Bob Haskins", DateCorrected=DateTime.Parse("2018-12-05"), InspectedBy="Claire Little", DateInspected=DateTime.Parse("2018-12-05"),
                                            FiledBy="Sarah Homes", DateFiled=DateTime.Parse("2018-12-05")},
                new RemovalInstallationForm{DiscrepancyReportCID=4, DateFormCreated=DateTime.Parse("2018-12-08"), EmployeeID=3, RemovedPartNumber1="PN1111", RemovedPartSerialNumber1="SN1111", NomenclaturePart1="Nom1",
                                            RemovedPartNumber2="PN1112", RemovedPartSerialNumber2="SN1112", NomenclaturePart2="Nom2", RemovedPartNumber3=null, RemovedPartSerialNumber3=null, NomenclaturePart3=null,
                                            RemovedPartNumber4=null, RemovedPartSerialNumber4=null, NomenclaturePart4=null, InstalledPartNumber1="PN0984", InstalledPartSerialNumber1="SN0984",
                                            InstalledPartNumber2="SN0983", InstalledPartSerialNumber2="SN0983", InstalledPartNumber3=null, InstalledPartSerialNumber3=null,
                                            InstalledPartNumber4=null, InstalledPartSerialNumber4=null, CorrectedBy="Tom Law", DateCorrected=DateTime.Parse("2018-12-08"), InspectedBy=null, DateInspected=null,
                                            FiledBy=null, DateFiled=null},
                new RemovalInstallationForm{DiscrepancyReportCID=1, DateFormCreated=DateTime.Parse("2018-12-09"), EmployeeID=1, RemovedPartNumber1="PN1234", RemovedPartSerialNumber1="SN1234", NomenclaturePart1="Nom1",
                                            RemovedPartNumber2="PN1222", RemovedPartSerialNumber2="SN1222", NomenclaturePart2="Nom2", RemovedPartNumber3=null, RemovedPartSerialNumber3=null, NomenclaturePart3=null,
                                            RemovedPartNumber4=null, RemovedPartSerialNumber4=null, NomenclaturePart4=null, InstalledPartNumber1="PN0087", InstalledPartSerialNumber1="SN0087",
                                            InstalledPartNumber2="SN0086", InstalledPartSerialNumber2="SN0086", InstalledPartNumber3=null, InstalledPartSerialNumber3=null,
                                            InstalledPartNumber4=null, InstalledPartSerialNumber4=null, CorrectedBy="Bob Haskins", DateCorrected=DateTime.Parse("2018-12-09"), InspectedBy=null, DateInspected=null,
                                            FiledBy=null, DateFiled=null}
            };
            foreach(RemovalInstallationForm rif in forms)
            {
                context.RemovalInstallationForms.Add(rif);
            }
            context.SaveChanges();

            // seeding the order status data
            var statuses = new OrderStatus[]
            {
                new OrderStatus{StatusDescription="New"},
                new OrderStatus{StatusDescription="Processing"},
                new OrderStatus{StatusDescription="Closed/Shipped"},
                new OrderStatus{StatusDescription="Dead"},
                new OrderStatus{StatusDescription="Drop Shipped"}
            };
            foreach (OrderStatus os in statuses)
            {
                context.OrderStatuses.Add(os);
            }
            context.SaveChangesAsync();

            // seeding tag color data
            var colors = new TagColor[]
            {
                new TagColor{ColorDescription="Green"},
                new TagColor{ColorDescription="Red"},
                new TagColor{ColorDescription="Yellow"},
                new TagColor{ColorDescription="Blue"},
                new TagColor{ColorDescription="Orange"}
            };
            foreach(TagColor tg in colors)
            {
                context.TagColors.Add(tg);
            }
            context.SaveChangesAsync();

            // seeding Category data
            var categories = new PartCategory[]
            {
                new PartCategory{CategoryName="Wings"},
                new PartCategory{CategoryName="Engines"},
                new PartCategory{CategoryName="Landing Gear"},
                new PartCategory{CategoryName="Fuselage"},
                new PartCategory{CategoryName="Cargo Bay"}
            };
            foreach(PartCategory pc in categories)
            {
                context.PartCategories.Add(pc);
            }
            context.SaveChangesAsync();

            // seeding Subcategory data
            var subcategories = new PartSubCategory[]
            {
                new PartSubCategory{SubCategoryName="Boeing", CategoryID=1},
                new PartSubCategory{SubCategoryName="GE", CategoryID=2},
                new PartSubCategory{SubCategoryName="AeroShell", CategoryID=4},
                new PartSubCategory{SubCategoryName="Dunlop Aviation", CategoryID=1},
                new PartSubCategory{SubCategoryName="HB Fuller", CategoryID=5},
                new PartSubCategory{SubCategoryName="L3", CategoryID=4},
                new PartSubCategory{SubCategoryName="Rieker Instruments", CategoryID=3},
                new PartSubCategory{SubCategoryName="UTC Aerospace Systems", CategoryID=1}
            };
            foreach(PartSubCategory psc in subcategories)
            {
                context.PartSubCategories.Add(psc);
            }
            context.SaveChangesAsync();

            // seeding Part data
            var parts = new Part[]
            {
                new Part{PartName="Winglet", PartNumber=12345, PartSerialNumber=09876, TagColorID=1, SubCategoryID=1},
                new Part{PartName="Roll Altitude", PartNumber=12332, PartSerialNumber=09879, TagColorID=1, SubCategoryID=1},
                new Part{PartName="Radome Boots", PartNumber=11234, PartSerialNumber=09877, TagColorID=1, SubCategoryID=2},
                new Part{PartName="Oil Filter", PartNumber=22222, PartSerialNumber=000003, TagColorID=3, SubCategoryID=2},
                new Part{PartName="ORing", PartNumber=12344, PartSerialNumber=09875, TagColorID=2, SubCategoryID=3},
                new Part{PartName="Roll Altitude", PartNumber=12332, PartSerialNumber=09879, TagColorID=1, SubCategoryID=3},
                new Part{PartName="Pneumatic Filter", PartNumber=11110, PartSerialNumber=000001, TagColorID=1, SubCategoryID=4},
                new Part{PartName="Bushing", PartNumber=33333, PartSerialNumber=000003, TagColorID=1, SubCategoryID=4},
                new Part{PartName="Piston Rod", PartNumber=44444, PartSerialNumber=000004, TagColorID=4, SubCategoryID=5},
                new Part{PartName="Cargo Container", PartNumber=66666, PartSerialNumber=00005, TagColorID=1, SubCategoryID=5},
                new Part{PartName="Baffle", PartNumber=55555, PartSerialNumber=000006, TagColorID=1, SubCategoryID=6},
                new Part{PartName="Lens Replacement", PartNumber=77777, PartSerialNumber=000007, TagColorID=1, SubCategoryID=6},
                new Part{PartName="Brake Pads", PartNumber=88888, PartSerialNumber=000007, TagColorID=1, SubCategoryID=7},
                new Part{PartName="Tires", PartNumber=99999, PartSerialNumber=000008, TagColorID=2, SubCategoryID=7},
                new Part{PartName=" Wing Stiffner", PartNumber=00011, PartSerialNumber=00009, TagColorID=1, SubCategoryID=8},
                new Part{PartName="Wing Straps", PartNumber=00022, PartSerialNumber=000011, TagColorID=1, SubCategoryID=8}
            };
            foreach(Part p in parts)
            {
                context.Parts.Add(p);
            }
            context.SaveChangesAsync();

            // seeding the Order Form Data
            var oForms = new OrderForm[]
            {
                new OrderForm{OrderNumber="XVY-1234", EmployeeID=1, DateOrderCreated=DateTime.Parse("2018-12-01"),
                                PartCategoryID=1, PartSubCategoryID=1, PartID=1, Ui="Nom", PartQuantity=1,
                                PartDocumentNumber ="AV-0101", TrackingNumber="AB1452-HJB0098", Edd=DateTime.Parse("2018-12-15"),
                                OrderStatusID=1},
                new OrderForm{OrderNumber="HFJ-6574", EmployeeID=3, DateOrderCreated=DateTime.Parse("2018-12-03"),
                                PartCategoryID=2, PartSubCategoryID=2, PartID=4, Ui="Oil", PartQuantity=10,
                                PartDocumentNumber ="OL-0022", TrackingNumber="TS3245-KJGL9967", Edd=DateTime.Parse("2018-12-21"),
                                OrderStatusID=2},
                new OrderForm{OrderNumber="TTQ-9976", EmployeeID=1, DateOrderCreated=DateTime.Parse("2018-12-05"),
                                PartCategoryID=3, PartSubCategoryID=7, PartID=13, Ui="BRK", PartQuantity=6,
                                PartDocumentNumber ="BK-0113", TrackingNumber="BK2234-PIL1155", Edd=DateTime.Parse("2018-12-19"),
                                OrderStatusID=3}
            };
            foreach(OrderForm of in oForms)
            {
                context.OrderForms.Add(of);
            }
            context.SaveChangesAsync();
        }
    }
}
