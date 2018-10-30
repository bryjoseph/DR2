using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Discrepancy_Report_2.Data;
using Discrepancy_Report_2.Models;

namespace Discrepancy_Report_2.Controllers
{
    public class DiscrepancyReportCsController : Controller
    {
        private readonly MaintenanceDbContext _context;

        public DiscrepancyReportCsController(MaintenanceDbContext context)
        {
            _context = context;
        }

        // GET: DiscrepancyReportCs
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page)
        {
            // sorting for Report Record
            ViewData["ReportRecordSortParm"] = String.IsNullOrEmpty(sortOrder) ? "report_record_desc" : "";
            // sorting for Location
            ViewData["LocationSortParm"] = String.IsNullOrEmpty(sortOrder) ? "location_code_desc" : "";
            // sorting for Date Discovered
            ViewData["DateDiscoveredSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            // (NOT USED)
            if (searchString != null)
            {
                // without a searchString set the page to 1
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            // Filtering by searchString
            ViewData["CurrentSearchFilter"] = searchString;

            var discrepancyReports = _context.DiscrepancyReportCs
                .Include(a => a.Aircraft)
                .Include(e => e.Employee)
                .Include(l => l.Location)
                .Include(ata => ata.AtaChapter)
                .Include(s => s.SignificantEvent)
                .Include(mt => mt.MaintenanceType)
                .AsNoTracking();

            // searching on different variables
            if (!String.IsNullOrEmpty(searchString))
            {
                discrepancyReports = discrepancyReports.Where(dr => dr.ReportRecord.Contains(searchString)
                                            || dr.Location.LocationCode.Contains(searchString)
                                            || dr.DiscrepancyDescription.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "report_record_desc":
                    discrepancyReports = discrepancyReports.OrderByDescending(dr => dr.ReportRecord);
                    break;
                case "location_code_desc":
                    discrepancyReports = discrepancyReports.OrderByDescending(dr => dr.Location);
                    break;
                case "Date":
                    discrepancyReports = discrepancyReports.OrderBy(dr => dr.DateDiscovered);
                    break;
                case "date_desc":
                    discrepancyReports = discrepancyReports.OrderByDescending(dr => dr.DateDiscovered);
                    break;
                default:
                    discrepancyReports = discrepancyReports.OrderBy(dr => dr.ReportRecord);
                    break;
            }
            return View(await discrepancyReports.ToListAsync());
        }

        // GET: DiscrepancyReportCs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discrepancyReport = await _context.DiscrepancyReportCs
                .Include(a => a.Aircraft)
                 .Include(e => e.Employee)
                     .ThenInclude(t => t.Title)
                .Include(l => l.Location)
                .Include(ac => ac.AtaChapter)
                .Include(se => se.SignificantEvent)
                .Include(mt => mt.MaintenanceType)
                .AsNoTracking()
                .SingleOrDefaultAsync(d => d.ID == id);

            if (discrepancyReport == null)
            {
                return NotFound();
            }

            return View(discrepancyReport);
        }

        // GET: DiscrepancyReportCs/Create
        public IActionResult Create()
        {
            //ViewData["AircraftID"] = new SelectList(_context.Aircrafts, "ID", "ID");
            //ViewData["AtaChapterID"] = new SelectList(_context.AtaChapters, "ID", "ID");
            //ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "ID");
            //ViewData["LocationID"] = new SelectList(_context.Locations, "ID", "ID");
            //ViewData["MaintenanceTypeID"] = new SelectList(_context.MaintenanceTypes, "ID", "ID");
            //ViewData["SignificantEventID"] = new SelectList(_context.SignificantEvents, "ID", "ID");
            PopulateAircraftsDropDownList();
            PopulateEmployeesDropDownList();
            PopulateLocationsDropDownList();
            PopulateAtaChapterDropDownList();
            PopulateSignificantEventsDropDownList();
            PopulateMaintenanceTypesDropDownList();
            return View();
        }

        // POST: DiscrepancyReportCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ID,ReportRecord,AircraftID,EmployeeID,DateDiscovered," +
                  "LocationID,AtaChapterID,AtaChapterEnd,EngineStart," +
                  "BeforeTakeoff,OnTakeoffRoll,Climb,Cruise,Descent,Approach," +
                  "Landing,Rollout,Postflight,SignificantEventID,MaintenanceTypeID," +
                  "MasterWarning,MasterCaution,WarningMessage1,WarningMessage2," +
                  "AdvisoryMessage1,AdvisoryMessage2,WarningMessageOther," +
                  "DiscrepancyDescription,AoG,Rii,WorkInstructionsPlannedAction," +
                  "CorrectiveActionDescription,OpsCheckRequired,LeakCheck,EmployeeID1," +
                  "MechanicDateSigned,EmployeeID2,QaDateSigned,GovernmentOfficial," +
                  "GovOfficialDateSigned,ReferenceDocument1,ReferenceDocument2," +
                  "CustomerName,CustomerAcceptanceDate")] DiscrepancyReportC discrepancyReportC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discrepancyReportC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //ViewData["AircraftID"] = new SelectList(_context.Aircrafts, "ID", "ID", discrepancyReportC.AircraftID);
            //ViewData["AtaChapterID"] = new SelectList(_context.AtaChapters, "ID", "ID", discrepancyReportC.AtaChapterID);
            //ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "ID", discrepancyReportC.EmployeeID);
            //ViewData["LocationID"] = new SelectList(_context.Locations, "ID", "ID", discrepancyReportC.LocationID);
            //ViewData["MaintenanceTypeID"] = new SelectList(_context.MaintenanceTypes, "ID", "ID", discrepancyReportC.MaintenanceTypeID);
            //ViewData["SignificantEventID"] = new SelectList(_context.SignificantEvents, "ID", "ID", discrepancyReportC.SignificantEventID);
            PopulateAircraftsDropDownList(discrepancyReportC.AircraftID);
            PopulateEmployeesDropDownList(discrepancyReportC.EmployeeID);
            PopulateLocationsDropDownList(discrepancyReportC.LocationID);
            PopulateAtaChapterDropDownList(discrepancyReportC.AtaChapterID);
            PopulateSignificantEventsDropDownList(discrepancyReportC.SignificantEventID);
            PopulateMaintenanceTypesDropDownList(discrepancyReportC.MaintenanceTypeID);
            return View(discrepancyReportC);
        }

        // GET: DiscrepancyReportCs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discrepancyReportC = await _context.DiscrepancyReportCs
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);


            if (discrepancyReportC == null)
            {
                return NotFound();
            }

            //ViewData["AircraftID"] = new SelectList(_context.Aircrafts, "ID", "ID", discrepancyReportC.AircraftID);
            //ViewData["AtaChapterID"] = new SelectList(_context.AtaChapters, "ID", "ID", discrepancyReportC.AtaChapterID);
            //ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "ID", discrepancyReportC.EmployeeID);
            //ViewData["LocationID"] = new SelectList(_context.Locations, "ID", "ID", discrepancyReportC.LocationID);
            //ViewData["MaintenanceTypeID"] = new SelectList(_context.MaintenanceTypes, "ID", "ID", discrepancyReportC.MaintenanceTypeID);
            //ViewData["SignificantEventID"] = new SelectList(_context.SignificantEvents, "ID", "ID", discrepancyReportC.SignificantEventID);
            PopulateAircraftsDropDownList(discrepancyReportC.AircraftID);
            PopulateEmployeesDropDownList(discrepancyReportC.EmployeeID);
            PopulateLocationsDropDownList(discrepancyReportC.LocationID);
            PopulateAtaChapterDropDownList(discrepancyReportC.AtaChapterID);
            PopulateSignificantEventsDropDownList(discrepancyReportC.SignificantEventID);
            PopulateMaintenanceTypesDropDownList(discrepancyReportC.MaintenanceTypeID);

            return View(discrepancyReportC);
        }

        // POST: DiscrepancyReportCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drToUpdate = await _context.DiscrepancyReportCs.SingleOrDefaultAsync(d => d.ID == id);

            if (await TryUpdateModelAsync<DiscrepancyReportC>(
                drToUpdate,
                "",
                d => d.ReportRecord, d => d.AircraftID, d => d.EmployeeID, d => d.DateDiscovered,
                d => d.LocationID, d => d.AtaChapterID, d => d.AtaChapterEnd, d => d.EngineStart,
                d => d.BeforeTakeoff, d => d.OnTakeoffRoll, d => d.Climb, d => d.Cruise, d => d.Descent,
                d => d.Approach, d => d.Landing, d => d.Rollout, d => d.Postflight, d => d.SignificantEventID,
                d => d.MaintenanceTypeID, d => d.MasterWarning, d => d.MasterCaution, d => d.WarningMessage1,
                d => d.WarningMessage2, d => d.AdvisoryMessage1, d => d.AdvisoryMessage2, d => d.WarningMessageOther,
                d => d.DiscrepancyDescription, d => d.AoG, d => d.Rii, d => d.WorkInstructionsPlannedAction,
                d => d.CorrectiveActionDescription, d => d.OpsCheckRequired, d => d.LeakCheck, d => d.TechnicianName,
                d => d.TechnicianDateSigned, d => d.QaName, d => d.QaDateSigned, d => d.GovernmentOfficial,
                d => d.GovOfficialDateSigned, d => d.ReferenceDocument1, d => d.ReferenceDocument2,
                d => d.CustomerName, d => d.CustomerAcceptanceDate))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes " +
                                            "Try again, and if the problem persists " +
                                            "see your system administrator");
                }
                return RedirectToAction(nameof(Index));
            }

            //ViewData["AircraftID"] = new SelectList(_context.Aircrafts, "ID", "ID", discrepancyReportC.AircraftID);
            //ViewData["AtaChapterID"] = new SelectList(_context.AtaChapters, "ID", "ID", discrepancyReportC.AtaChapterID);
            //ViewData["CorrectiveActionID"] = new SelectList(_context.CorrectiveActions, "ID", "ID", discrepancyReportC.CorrectiveActionID);
            //ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "ID", discrepancyReportC.EmployeeID);
            //ViewData["LocationID"] = new SelectList(_context.Locations, "ID", "ID", discrepancyReportC.LocationID);
            //ViewData["MaintenanceTypeID"] = new SelectList(_context.MaintenanceTypes, "ID", "ID", discrepancyReportC.MaintenanceTypeID);
            //ViewData["SignificantEventID"] = new SelectList(_context.SignificantEvents, "ID", "ID", discrepancyReportC.SignificantEventID);
            PopulateAircraftsDropDownList(drToUpdate.AircraftID);
            PopulateEmployeesDropDownList(drToUpdate.EmployeeID);
            PopulateLocationsDropDownList(drToUpdate.LocationID);
            PopulateAtaChapterDropDownList(drToUpdate.AtaChapterID);
            PopulateSignificantEventsDropDownList(drToUpdate.SignificantEventID);
            PopulateMaintenanceTypesDropDownList(drToUpdate.MaintenanceTypeID);

            return View(drToUpdate);
        }

        // GET: DiscrepancyReportCs/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChagesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discrepancyReport = await _context.DiscrepancyReportCs
                .Include(a => a.Aircraft)
                .Include(e => e.Employee)
                    .ThenInclude(t => t.Title)
                .Include(l => l.Location)
                .Include(ac => ac.AtaChapter)
                .Include(se => se.SignificantEvent)
                .Include(mt => mt.MaintenanceType)
                .AsNoTracking()
                .SingleOrDefaultAsync(d => d.ID == id);

            if (discrepancyReport == null)
            {
                return NotFound();
            }

            if (saveChagesError.GetValueOrDefault())
            {
                // creating a custom error message the View for Aircraft can access
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator";
            }

            return View(discrepancyReport);
        }

        // POST: DiscrepancyReportCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discrepancyReport = await _context.DiscrepancyReportCs
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            // if the report is null redirect back to the index page
            if (discrepancyReport == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.DiscrepancyReportCs.Remove(discrepancyReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /*ex*/)
            {
                // to log the error from deletetion uncomment the ex variable
                // set the saveChangesError to true because there is a new error
                // the true is passed to the above Delete method and now the custom error message shows up
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        // Aircraft dropdown list
        private void PopulateAircraftsDropDownList(object selectedAircraft = null)
        {
            var aircraftQuery = from a in _context.Aircrafts
                                     orderby a.FaaNumber
                                     select a;
            ViewBag.Aircrafts = new SelectList(aircraftQuery.AsNoTracking(), "ID", "FaaNumber", selectedAircraft);
        }

        // Employee dropdown list
        private void PopulateEmployeesDropDownList(object selectedEmployee = null)
        {
            var employeeQuery = from e in _context.Employees
                                orderby e.FullName
                                select e;
            ViewBag.Employees = new SelectList(employeeQuery.AsNoTracking(), "ID", "FullName", selectedEmployee);
        }

        // Location dropdown list
        private void PopulateLocationsDropDownList(object selectedLocation = null)
        {
            var locationQuery = from l in _context.Locations
                                orderby l.LocationCode
                                select l;
            ViewBag.Locations = new SelectList(locationQuery.AsNoTracking(), "ID", "LocationCode", selectedLocation);
        }

        // ATA Chapter dropdown list
        private void PopulateAtaChapterDropDownList(object selectedChapter = null)
        {
            var chapterQuery = from c in _context.AtaChapters
                                orderby c.ChapterNumber
                                select c;
            ViewBag.AtaChapters = new SelectList(chapterQuery.AsNoTracking(), "ID", "ChapterNumber", selectedChapter);
        }

        // ATA Chapter dropdown list
        private void PopulateSignificantEventsDropDownList(object selectedEvent = null)
        {
            var eventQuery = from ev in _context.SignificantEvents
                               orderby ev.ID
                               select ev;
            ViewBag.SigEvents = new SelectList(eventQuery.AsNoTracking(), "ID", "SignificantEventDescription", selectedEvent);
        }

        // Maintenance Types dropdown list
        private void PopulateMaintenanceTypesDropDownList(object selectedType = null)
        {
            var typeQuery = from mt in _context.MaintenanceTypes
                               orderby mt.ID
                               select mt;
            ViewBag.MaintTypes = new SelectList(typeQuery.AsNoTracking(), "ID", "MaintenanceTypeDescription", selectedType);
        }
        
        private bool DiscrepancyReportCExists(int id)
        {
            return _context.DiscrepancyReportCs.Any(e => e.ID == id);
        }
    }
}
