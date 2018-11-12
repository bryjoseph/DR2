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
    //public class OrderFormsController : Controller
    //{
    //    private readonly MaintenanceDbContext _context;

    //    public OrderFormsController(MaintenanceDbContext context)
    //    {
    //        _context = context;
    //    }

        // GET: OrderForms
        //public async Task<IActionResult> Index(
        //    string sortOrder,
        //    string currentFilter,
        //    string searchString,
        //    int? page)
        //{
        //    // Pagination (NOT USED)
        //    ViewData["CurrentSort"] = sortOrder;
        //    // sorting for FFA Number
        //    ViewData["OrderNumberSortParm"] = String.IsNullOrEmpty(sortOrder) ? "order_number_desc" : "";
        //    // sorting for TailNumber Number
        //    ViewData["OrderedBySortParm"] = String.IsNullOrEmpty(sortOrder) ? "ordered_by_desc" : "";
        //    // sorting for Date Discovered
        //    ViewData["DateCreatedSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

        //    // (NOT USED)
        //    if (searchString != null)
        //    {
        //        // without a searchString set the page to 1
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    // Filtering by searchString
        //    ViewData["CurrentSearchFilter"] = searchString;

        //    var orderForms = _context.OrderForms
        //        .Include(e => e.Employee)
        //            .ThenInclude(t => t.Title)
        //        .Include(s => s.OrderStatus)
        //        .Include(pc => pc.PartCategory)
        //        .Include(ps => ps.PartSubCategory)
        //        .AsNoTracking();

        //    // searching on different variables
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        orderForms = orderForms.Where(of => of.OrderNumber.Contains(searchString)
        //                                    || of.Employee.FullName.Contains(searchString)
        //                                    || of.PartName.Contains(searchString));
        //    }

        //    switch (sortOrder)
        //    {
        //        case "order_number_desc":
        //            orderForms = orderForms.OrderByDescending(of => of.OrderNumber);
        //            break;
        //        case "ordered_by_desc":
        //            orderForms = orderForms.OrderByDescending(of => of.Employee.FullName);
        //            break;
        //        case "Date":
        //            orderForms = orderForms.OrderBy(of => of.DateOrderCreated);
        //            break;
        //        case "date_desc":
        //            orderForms = orderForms.OrderByDescending(of => of.DateOrderCreated);
        //            break;
        //        default:
        //            orderForms = orderForms.OrderBy(of => of.OrderNumber);
        //            break;
        //    }

        //    return View(await orderForms.ToListAsync());
        //}

        // GET: OrderForms/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderForm = await _context.OrderForms
        //        .Include(o => o.Employee)
        //        .Include(o => o.OrderStatus)
        //        .Include(o => o.PartCategory)
        //        .Include(o => o.PartSubCategory)
        //        .SingleOrDefaultAsync(m => m.ID == id);

        //    if (orderForm == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(orderForm);
        //}

        // GET: OrderForms/Create
        //public IActionResult Create()
        //{
        //    PopulatePartCategoryDropDownList();
        //    return View();

        //    //ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "ID");
        //    //ViewData["OrderStatusID"] = new SelectList(_context.OrderStatuses, "ID", "ID");
        //    //ViewData["PartID"] = new SelectList(_context.Parts, "ID", "PartName");
        //    //ViewData["PartCategoryID"] = new SelectList(_context.PartCategories, "ID", "ID");
        //    //ViewData["PartSubCategoryID"] = new SelectList(_context.PartSubCategories, "ID", "ID");
        //    //return View();
        //}

        // POST: OrderForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(
        //    [Bind(  "ID,OrderNumber,EmployeeID,DateOrderCreated,PartCategoryID," +
        //            "PartSubCategoryID,PartID,Ui,PartQuantity,PartDocumentNumber," +
        //            "TrackingNumber,Edd,OrderStatusID")] OrderForm orderForm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(orderForm);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    //ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "ID", orderForm.EmployeeID);
        //    //ViewData["OrderStatusID"] = new SelectList(_context.OrderStatuses, "ID", "ID", orderForm.OrderStatusID);
        //    //ViewData["PartID"] = new SelectList(_context.Parts, "ID", "PartName", orderForm.PartID);
        //    //ViewData["PartCategoryID"] = new SelectList(_context.PartCategories, "ID", "ID", orderForm.PartCategoryID);
        //    //ViewData["PartSubCategoryID"] = new SelectList(_context.PartSubCategories, "ID", "ID", orderForm.PartSubCategoryID);

        //    PopulatePartCategoryDropDownList(orderForm.PartCategoryID);
        //    return View(orderForm);
        //}

        // GET: OrderForms/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderForm = await _context.OrderForms.SingleOrDefaultAsync(m => m.ID == id);
        //    if (orderForm == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "ID", orderForm.EmployeeID);
        //    ViewData["OrderStatusID"] = new SelectList(_context.OrderStatuses, "ID", "ID", orderForm.OrderStatusID);
        //    ViewData["PartCategoryID"] = new SelectList(_context.PartCategories, "ID", "ID", orderForm.PartCategoryID);
        //    ViewData["PartSubCategoryID"] = new SelectList(_context.PartSubCategories, "ID", "ID", orderForm.PartSubCategoryID);
        //    return View(orderForm);
        //}

        // POST: OrderForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,OrderNumber,EmployeeID,DateOrderCreated,PartCategoryID,PartSubCategoryID,PartID,Ui,PartQuantity,PartDocumentNumber,TrackingNumber,Edd,OrderStatusID")] OrderForm orderForm)
        //{
        //    if (id != orderForm.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(orderForm);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrderFormExists(orderForm.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["EmployeeID"] = new SelectList(_context.Employees, "ID", "ID", orderForm.EmployeeID);
        //    ViewData["OrderStatusID"] = new SelectList(_context.OrderStatuses, "ID", "ID", orderForm.OrderStatusID);
        //    ViewData["PartCategoryID"] = new SelectList(_context.PartCategories, "ID", "ID", orderForm.PartCategoryID);
        //    ViewData["PartSubCategoryID"] = new SelectList(_context.PartSubCategories, "ID", "ID", orderForm.PartSubCategoryID);
        //    return View(orderForm);
        //}

        // GET: OrderForms/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderForm = await _context.OrderForms
        //        .Include(o => o.Employee)
        //        .Include(o => o.OrderStatus)
        //        .Include(o => o.PartCategory)
        //        .Include(o => o.PartSubCategory)
        //        .SingleOrDefaultAsync(m => m.ID == id);
        //    if (orderForm == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(orderForm);
        //}

        // POST: OrderForms/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var orderForm = await _context.OrderForms.SingleOrDefaultAsync(m => m.ID == id);
    //        _context.OrderForms.Remove(orderForm);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool OrderFormExists(int id)
    //    {
    //        return _context.OrderForms.Any(e => e.ID == id);
    //    }

    //    private void PopulatePartCategoryDropDownList(object selectedCategory = null)
    //    {
    //        //// instantiate a blank list
    //        //List<PartCategory> categoryList = new List<PartCategory>();

    //        //// get the data
    //        //categoryList = (from category in _context.PartCategories
    //        //                select category).ToList();

    //        //// insert into the new list from above
    //        //categoryList.Insert(0, new PartCategory { PartSubCategoryID = 0, CategoryName = "Select" });

    //        //// assign the list to a ViewBag to be visible in the View
    //        //ViewBag.ListofPartCategory = categoryList;
    //        var catQuery = from c in _context.PartCategories
    //                       orderby c.CategoryName
    //                       select c;
    //        ViewBag.CategoryTypes = new SelectList(catQuery.AsNoTracking(), "ID", "CategoryName", selectedCategory);
    //    }
    //}
}
