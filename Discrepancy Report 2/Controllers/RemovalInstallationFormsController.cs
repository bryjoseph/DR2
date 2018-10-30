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
    public class RemovalInstallationFormsController : Controller
    {
        private readonly MaintenanceDbContext _context;

        public RemovalInstallationFormsController(MaintenanceDbContext context)
        {
            _context = context;
        }

        // GET: RemovalInstallationForms
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page)
        {
            // sorting for Report Record
            ViewData["ReportRecordSortParm"] = String.IsNullOrEmpty(sortOrder) ? "report_record_desc" : "";
            // sorting for Date Discovered
            ViewData["DateCreatedSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            // sorting for Record Creator
            ViewData["CreatedBySortParm"] = String.IsNullOrEmpty(sortOrder) ? "created_by_desc" : "";

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

            // var aircraftSort = from a in _context.Aircrafts select a;
            var forms = _context.RemovalInstallationForms
                .Include(dr => dr.DiscrepancyReportC)
                    .ThenInclude(a => a.Aircraft)
                .Include(e => e.Employee)
                .AsNoTracking();

            // searching on different variables
            if (!String.IsNullOrEmpty(searchString))
            {
                forms = forms.Where(f => f.DiscrepancyReportC.ReportRecord.Contains(searchString)
                                    || f.DiscrepancyReportC.Aircraft.FaaNumber.Contains(searchString)
                                    || f.Employee.FullName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "report_record_desc":
                    forms = forms.OrderByDescending(f=> f.DiscrepancyReportC.ReportRecord);
                    break;
                case "Date":
                    forms = forms.OrderBy(f => f.DateFormCreated);
                    break;
                case "date_desc":
                    forms = forms.OrderByDescending(f => f.DateFormCreated);
                    break;
                case "created_by_desc":
                    forms = forms.OrderByDescending(f => f.Employee.FullName);
                    break;
                default:
                    forms = forms.OrderBy(f => f.DiscrepancyReportC.ReportRecord);
                    break;
            }

            return View(await forms.ToListAsync());
        }

        // GET: RemovalInstallationForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var removalInstallationForm = await _context.RemovalInstallationForms
                .Include(dr => dr.DiscrepancyReportC)
                    .ThenInclude(a => a.Aircraft)
                        .ThenInclude(am => am.AircraftModel)
                .Include(e => e.Employee)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (removalInstallationForm == null)
            {
                return NotFound();
            }

            return View(removalInstallationForm);
        }

        // GET: RemovalInstallationForms/Create
        public IActionResult Create()
        {
            PopulateDrDropdownList();
            PopulateEmployeeDropdownList();
            return View();
        }

        // POST: RemovalInstallationForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ID,DiscrepancyReportCID,DateFormCreated,EmployeeID," +
                    "RemovedPartNumber1,RemovedPartSerialNumber1,NomenclaturePart1," +
                    "RemovedPartNumber2,RemovedPartSerialNumber2,NomenclaturePart2," +
                    "RemovedPartNumber3,RemovedPartSerialNumber3,NomenclaturePart3," +
                    "RemovedPartNumber4,RemovedPartSerialNumber4,NomenclaturePart4," +
                    "InstalledPartNumber1,InstalledPartSerialNumber1,InstalledPartNumber2," +
                    "InstalledPartSerialNumber2,InstalledPartNumber3,InstalledPartSerialNumber3," +
                    "InstalledPartNumber4,InstalledPartSerialNumber4," +
                    "CorrectedBy,DateCorrected,InspectedBy,DateInspected,FiledBy,DateFiled")] RemovalInstallationForm removalInstallationForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(removalInstallationForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDrDropdownList(removalInstallationForm.DiscrepancyReportCID);
            PopulateEmployeeDropdownList(removalInstallationForm.EmployeeID);
            return View(removalInstallationForm);
        }

        // GET: RemovalInstallationForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var removalInstallationForm = await _context.RemovalInstallationForms
                .AsNoTracking()
                .SingleOrDefaultAsync(f => f.ID == id);

            if (removalInstallationForm == null)
            {
                return NotFound();
            }

            PopulateDrDropdownList(removalInstallationForm.DiscrepancyReportCID);
            PopulateEmployeeDropdownList(removalInstallationForm.EmployeeID);
            return View(removalInstallationForm);
        }

        // POST: RemovalInstallationForms/Edit/5
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

            var formToUpdate = await _context.RemovalInstallationForms.SingleOrDefaultAsync(f => f.ID == id);

            if (await TryUpdateModelAsync<RemovalInstallationForm>(
                formToUpdate,
                "",
                f => f.DiscrepancyReportCID, f => f.DateFormCreated, f => f.EmployeeID,
                f => f.RemovedPartNumber1, f => f.RemovedPartSerialNumber1, f => f.NomenclaturePart1,
                f => f.RemovedPartNumber2, f => f.RemovedPartSerialNumber2, f => f.NomenclaturePart2,
                f => f.RemovedPartNumber3, f => f.RemovedPartSerialNumber3, f => f.NomenclaturePart3,
                f => f.RemovedPartNumber4, f => f.RemovedPartSerialNumber4, f => f.NomenclaturePart4, 
                f => f.InstalledPartNumber1, f => f.InstalledPartSerialNumber1, f => f.InstalledPartNumber2, f => f.InstalledPartSerialNumber2,
                f => f.InstalledPartNumber3, f => f.InstalledPartSerialNumber3, f => f.InstalledPartNumber4, f => f.InstalledPartSerialNumber4,
                f => f.CorrectedBy, f => f.DateCorrected, f => f.InspectedBy, f => f.DateInspected,
                f => f.FiledBy, f => f.DateFiled))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException /*ex*/)
                {
                    ModelState.AddModelError("", "Unable to save changes " +
                                            "Try again, and if the problem persists " +
                                            "see your system administrator");
                }
                return RedirectToAction(nameof(Index));
            }

            PopulateDrDropdownList(formToUpdate.DiscrepancyReportCID);
            PopulateEmployeeDropdownList(formToUpdate.EmployeeID);
            return View(formToUpdate);
        }

        // GET: RemovalInstallationForms/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChagesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var removalInstallationForm = await _context.RemovalInstallationForms
                .Include(dr => dr.DiscrepancyReportC)
                    .ThenInclude(a => a.Aircraft)
                        .ThenInclude(am => am.AircraftModel)
                .Include(e => e.Employee)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (removalInstallationForm == null)
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

            return View(removalInstallationForm);
        }

        // POST: RemovalInstallationForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var removalInstallationForm = await _context.RemovalInstallationForms
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (removalInstallationForm == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.RemovalInstallationForms.Remove(removalInstallationForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /*ex*/)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private void PopulateDrDropdownList(object selectedReport = null)
        {
            var drReportQuery = from d in _context.DiscrepancyReportCs
                                     orderby d.ReportRecord
                                     select d;
            ViewBag.Reports = new SelectList(drReportQuery.AsNoTracking(), "ID", "ReportRecord", selectedReport);
        }

        private void PopulateEmployeeDropdownList(object selectedEmp = null)
        {
            var employeeQuery = from e in _context.Employees
                                orderby e.FullName
                                select e;
            ViewBag.Employees = new SelectList(employeeQuery.AsNoTracking(), "ID", "FullName", selectedEmp);
        }

        private bool RemovalInstallationFormExists(int id)
        {
            return _context.RemovalInstallationForms.Any(e => e.ID == id);
        }
    }
}
