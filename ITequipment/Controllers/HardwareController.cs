using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITequipment.Data;
using ITequipment.Models;

namespace ITequipment.Controllers
{
    public class HardwareController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HardwareController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hardware
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hardwares.ToListAsync());
        }

        // GET: Hardware/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardware = await _context.Hardwares
                .FirstOrDefaultAsync(m => m.HardwareId == id);
            if (hardware == null)
            {
                return NotFound();
            }

            return View(hardware);
        }

        // GET: Hardware/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hardware/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HardwareId,Serial,Name,Purpose,Specs,AdditionalInfo,AcquiredDate,Condition")] Hardware hardware)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hardware);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hardware);
        }

        // GET: Hardware/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardware = await _context.Hardwares.FindAsync(id);
            if (hardware == null)
            {
                return NotFound();
            }
            return View(hardware);
        }

        // POST: Hardware/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HardwareId,Serial,Name,Purpose,Specs,AdditionalInfo,AcquiredDate,Condition")] Hardware hardware)
        {
            if (id != hardware.HardwareId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hardware);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HardwareExists(hardware.HardwareId))
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
            return View(hardware);
        }

        // GET: Hardware/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardware = await _context.Hardwares
                .FirstOrDefaultAsync(m => m.HardwareId == id);
            if (hardware == null)
            {
                return NotFound();
            }

            return View(hardware);
        }

        // POST: Hardware/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hardware = await _context.Hardwares.FindAsync(id);
            _context.Hardwares.Remove(hardware);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HardwareExists(int id)
        {
            return _context.Hardwares.Any(e => e.HardwareId == id);
        }
    }
}
