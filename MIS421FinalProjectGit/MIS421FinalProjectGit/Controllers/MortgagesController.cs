using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MIS421FinalProjectGit.Data;
using MIS421FinalProjectGit.Models;

namespace MIS421FinalProjectGit.Controllers
{
    public class MortgagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MortgagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mortgages
        public async Task<IActionResult> Index()
        {
            return _context.Mortgage != null ?
                        View(await _context.Mortgage.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Mortgage'  is null.");
        }

        // GET: Mortgages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Mortgage == null)
            {
                return NotFound();
            }

            var mortgage = await _context.Mortgage
                .FirstOrDefaultAsync(m => m.ApplicationUserID == id);
            if (mortgage == null)
            {
                return NotFound();
            }

            return View(mortgage);
        }

        // GET: Mortgages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mortgages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HomePrice,DownPayment,LoanAmount,InterestRate,LoanTerm,AnnualInsurance,PropertyTaxes,MonthlyHOA,ExtraPayment,ApplicationUserID")] Mortgage mortgage)
        {
            if (ModelState.IsValid)
            {
                mortgage.ApplicationUserID = Guid.NewGuid();
                _context.Add(mortgage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mortgage);
        }

        // GET: Mortgages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Mortgage == null)
            {
                return NotFound();
            }

            var mortgage = await _context.Mortgage.FindAsync(id);
            if (mortgage == null)
            {
                return NotFound();
            }
            return View(mortgage);
        }

        // POST: Mortgages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("HomePrice,DownPayment,LoanAmount,InterestRate,LoanTerm,AnnualInsurance,PropertyTaxes,MonthlyHOA,ExtraPayment,ApplicationUserID")] Mortgage mortgage)
        {
            if (id != mortgage.ApplicationUserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mortgage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MortgageExists(mortgage.ApplicationUserID))
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
            return View(mortgage);
        }

        // GET: Mortgages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Mortgage == null)
            {
                return NotFound();
            }

            var mortgage = await _context.Mortgage
                .FirstOrDefaultAsync(m => m.ApplicationUserID == id);
            if (mortgage == null)
            {
                return NotFound();
            }

            return View(mortgage);
        }

        // POST: Mortgages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Mortgage == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Mortgage'  is null.");
            }
            var mortgage = await _context.Mortgage.FindAsync(id);
            if (mortgage != null)
            {
                _context.Mortgage.Remove(mortgage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MortgageExists(Guid id)
        {
            return (_context.Mortgage?.Any(e => e.ApplicationUserID == id)).GetValueOrDefault();
        }
    }
}
