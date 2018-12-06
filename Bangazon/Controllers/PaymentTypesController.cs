using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bangazon.Data;
using Bangazon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Bangazon.Controllers
{
    [Authorize]
    public class PaymentTypesController : Controller
    {

        /*
         Author : Alejandro Font
         Purpose and Method : Added UserMananger class, placed it in the constructor, and made GetCurrentUserAsync() so I could access the current 
                                user. This allows me to show specified payment types. 

         */

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public PaymentTypesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        /*
            Author : Alejandro Font
            Purpose and Method : After scaffolding, I only added the Where method below, which returns the paymentTypes
                                    that are paired by UserId with the current user.  
         */

        // GET: PaymentTypes
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var applicationDbContext = _context.PaymentType.Include(p => p.User);
            return View(await applicationDbContext.Where(pt => pt.UserId == user.Id).ToListAsync());
        }

        // GET: PaymentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentType = await _context.PaymentType
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PaymentTypeId == id);
            if (paymentType == null)
            {
                return NotFound();
            }

            return View(paymentType);
        }

        // GET: PaymentTypes/Create
        public IActionResult Create()
        {
            //ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: PaymentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentTypeId,DateCreated,Description,AccountNumber,UserId")] PaymentType paymentType)
        {

        //Author : Alejandro Font
        //Purpose and method : User variable retrieves the current user, and by assigning values to Payment Type parameters, the paymentType,
        // once sent to the database, will hold the correct data. This takes away the ability the user had to choose the userId. 


            var user = await GetCurrentUserAsync();
                paymentType.User = user;
                paymentType.UserId = user.Id;

            ModelState.Remove("UserId");
            ModelState.Remove("User");



            if (ModelState.IsValid)
            {
                _context.Add(paymentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", paymentType.UserId);
            return View(paymentType);
        }

        // GET: PaymentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentType = await _context.PaymentType.FindAsync(id);
            if (paymentType == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", paymentType.UserId);
            return View(paymentType);
        }

        // POST: PaymentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentTypeId,DateCreated,Description,AccountNumber,UserId")] PaymentType paymentType)
        {
            if (id != paymentType.PaymentTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentTypeExists(paymentType.PaymentTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", paymentType.UserId);
            return View(paymentType);
        }

        // GET: PaymentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentType = await _context.PaymentType
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PaymentTypeId == id);
            if (paymentType == null)
            {
                return NotFound();
            }

            return View(paymentType);
        }

        // POST: PaymentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentType = await _context.PaymentType.FindAsync(id);
            _context.PaymentType.Remove(paymentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentTypeExists(int id)
        {
            return _context.PaymentType.Any(e => e.PaymentTypeId == id);
        }

        public async Task<IActionResult> SelectPaymentType()
        {
            var user = await GetCurrentUserAsync();

            var applicationDbContext = _context.PaymentType.Include(p => p.User);
            return View(await applicationDbContext.Where(pt => pt.UserId == user.Id).ToListAsync());
        }

        // this takes in the payment type id and updates the database to complete the order
        public async Task<IActionResult> PaymentConfirmation(int? id)
        {
            var user = await GetCurrentUserAsync();

            Order activeOrder = _context.Order
                .Include(o => o.User)
                .Include(o => o.PaymentType)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Where(o => o.UserId == user.Id)
                .Where(o => o.PaymentType == null).ToList().FirstOrDefault();

            if (activeOrder != null)
            {
                activeOrder.PaymentTypeId = id;

                _context.Update(activeOrder);
                await _context.SaveChangesAsync();
            // this foreaches over the products in the cart and subtracts the quantity for the total
            // amount for this product in the database 
             foreach(var op in activeOrder.OrderProducts)
            {
                Product currentProduct = op.Product;
                currentProduct.Quantity = currentProduct.Quantity - 1;

                _context.Update(currentProduct);
                await _context.SaveChangesAsync();
            }
            }

            return View();
        }
    }
}
