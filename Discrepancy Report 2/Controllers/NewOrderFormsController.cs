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
    public class NewOrderFormsController : Controller
    {
        private readonly MaintenanceDbContext _context;

        public NewOrderFormsController(MaintenanceDbContext context)
        {
            _context = context;
        }

        // GET: NewOrderForms
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page)
        {
            // Pagination (NOT USED)
            ViewData["CurrentSort"] = sortOrder;
            // sorting for Order Number
            ViewData["OrderNumberSortParm"] = String.IsNullOrEmpty(sortOrder) ? "order_number_desc" : "";
            // sorting for Date Created
            ViewData["DateCreatedSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            // sorting for Record Creator
            ViewData["CreatedBySortParm"] = String.IsNullOrEmpty(sortOrder) ? "created_by_desc" : "";
            // sorting for Order Status
            ViewData["OrderStatusSortParm"] = String.IsNullOrEmpty(sortOrder) ? "order_status_desc" : "";

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
            var orders = _context.NewOrderForms
                .Include(e => e.Employee)
                .Include(pc => pc.PartCategory)
                .Include(psc => psc.PartSubCategory)
                .Include(os => os.OrderStatus)
                .AsNoTracking();

            // searching on different variables
            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.OrderNumber.Contains(searchString)
                                            || o.PartCategory.CategoryName.Contains(searchString)
                                            || o.PartSubCategory.SubCategoryName.Contains(searchString)
                                            || o.Employee.FullName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "order_number_desc":
                    orders = orders.OrderByDescending(o => o.OrderNumber);
                    break;
                case "Date":
                    orders = orders.OrderBy(o => o.DateOrderCreated);
                    break;
                case "date_desc":
                    orders = orders.OrderByDescending(o => o.DateOrderCreated);
                    break;
                case "created_by_desc":
                    orders = orders.OrderByDescending(o => o.Employee.FullName);
                    break;
                case "order_status_desc":
                    orders = orders.OrderByDescending(o => o.OrderStatus.StatusDescription);
                    break;
                default:
                    orders = orders.OrderBy(o => o.OrderNumber);
                    break;
            }
            return View(await orders.ToListAsync());
        }

        // GET: NewOrderForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newOrderForm = await _context.NewOrderForms
                .Include(n => n.Employee)
                .Include(n => n.OrderStatus)
                .Include(n => n.PartCategory)
                .Include(n => n.PartSubCategory)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (newOrderForm == null)
            {
                return NotFound();
            }

            return View(newOrderForm);
        }

        // GET: NewOrderForms/Create
        public IActionResult Create()
        {
            PopulateEmployeeDropdownList();
            PopulatePartCategoryDropdownList();
            PopulatePartSubcategoryDropdownList();
            PopulateOrderStatusDropdownList();
            return View();
        }

        // POST: NewOrderForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ID,OrderNumber,EmployeeID,DateOrderCreated,PartCategoryID," +
            "PartSubCategoryID,PartName,Ui,PartQuantity,PartDocumentNumber,TrackingNumber," +
            "Edd,OrderStatusID")] NewOrderForm newOrderForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(newOrderForm);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /*ex*/)
            {
                ModelState.AddModelError("", "Unable to save changes." +
                    "Try again, and if problem persists see system administrator.");
            }
            
            PopulateEmployeeDropdownList(newOrderForm.EmployeeID);
            PopulatePartCategoryDropdownList(newOrderForm.PartCategoryID);
            PopulatePartSubcategoryDropdownList(newOrderForm.PartSubCategoryID);
            PopulateOrderStatusDropdownList(newOrderForm.OrderStatusID);
            return View(newOrderForm);
        }

        // GET: NewOrderForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newOrderForm = await _context.NewOrderForms.SingleOrDefaultAsync(m => m.ID == id);
            if (newOrderForm == null)
            {
                return NotFound();
            }

            // populate dropdowns
            PopulateEmployeeDropdownList(newOrderForm.EmployeeID);
            PopulatePartCategoryDropdownList(newOrderForm.PartCategoryID);
            PopulatePartSubcategoryDropdownList(newOrderForm.PartSubCategoryID);
            PopulateOrderStatusDropdownList(newOrderForm.OrderStatusID);

            return View(newOrderForm);
        }

        // POST: NewOrderForms/Edit/5
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

            var orderToUpdate = await _context.NewOrderForms
                .SingleOrDefaultAsync(o => o.ID == id);

            if (await TryUpdateModelAsync<NewOrderForm>(orderToUpdate,
                "",
                o => o.OrderNumber, o => o.DateOrderCreated, o => o.EmployeeID, o => o.PartCategoryID,
                o => o.PartSubCategoryID, o => o.PartName, o => o.PartQuantity,  o => o.Ui,
                o => o.PartDocumentNumber, o => o.TrackingNumber, o => o.Edd, o => o.OrderStatusID))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /*ex*/)
                {
                    ModelState.AddModelError("", "Unable to save changes." +
                    "Try again, and if problem persists see system administrator.");
                }
                return RedirectToAction(nameof(Index));
            }

            PopulateEmployeeDropdownList(orderToUpdate.EmployeeID);
            PopulatePartCategoryDropdownList(orderToUpdate.PartCategoryID);
            PopulatePartSubcategoryDropdownList(orderToUpdate.PartSubCategoryID);
            PopulateOrderStatusDropdownList(orderToUpdate.OrderStatusID);
            return View(orderToUpdate);
        }

        // GET: NewOrderForms/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChagesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newOrderForm = await _context.NewOrderForms
                .Include(n => n.Employee)
                .Include(n => n.OrderStatus)
                .Include(n => n.PartCategory)
                .Include(n => n.PartSubCategory)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (newOrderForm == null)
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

            return View(newOrderForm);
        }

        // POST: NewOrderForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newOrderForm = await _context.NewOrderForms.SingleOrDefaultAsync(m => m.ID == id);
            _context.NewOrderForms.Remove(newOrderForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Populate the employee dropdown list
        private void PopulateEmployeeDropdownList(object selectedEmp = null)
        {
            var employeeQuery = from e in _context.Employees
                                orderby e.FullName
                                select e;
            ViewBag.Employees = new SelectList(employeeQuery.AsNoTracking(), "ID", "FullName", selectedEmp);
        }

        // Populate the Part Category dropdown list
        private void PopulatePartCategoryDropdownList(object selectedCat = null)
        {
            var categoryQuery = from c in _context.PartCategories
                                orderby c.CategoryName
                                select c;
            ViewBag.Categories = new SelectList(categoryQuery.AsNoTracking(), "ID", "CategoryName", selectedCat);
        }

        // Populate the Subcategory dropdown list
        private void PopulatePartSubcategoryDropdownList(object selectedSub = null)
        {
            var subcategoryQuery = from s in _context.PartSubCategories
                                orderby s.SubCategoryName
                                select s;
            ViewBag.Subcategories = new SelectList(subcategoryQuery.AsNoTracking(), "ID", "SubCategoryName", selectedSub);
        }

        // Populate the Order status dropdown list
        private void PopulateOrderStatusDropdownList(object selectedStatus = null)
        {
            var statusQuery = from s in _context.OrderStatuses
                                   orderby s.StatusDescription
                                   select s;
            ViewBag.Statuses = new SelectList(statusQuery.AsNoTracking(), "ID", "StatusDescription", selectedStatus);
        }

        private bool NewOrderFormExists(int id)
        {
            return _context.NewOrderForms.Any(e => e.ID == id);
        }
    }
}
