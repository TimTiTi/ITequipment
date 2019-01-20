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
    public class HW_SWController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HW_SWController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HW_SW
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HW_SW.Include(h => h.Hardware).Include(h => h.Software);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HW_SW/Details/5
        public async Task<IActionResult> Details(int? hid, int? sid)
        {
            if (hid == null || sid == null)
            {
                return NotFound();
            }

            var hW_SW = await _context.HW_SW
                .Include(h => h.Hardware)
                .Include(h => h.Software)
                .FirstOrDefaultAsync(m => m.HardwareId == hid && m.SoftwareId == sid);
            if (hW_SW == null)
            {
                return NotFound();
            }

            return View(hW_SW);
        }

        // GET: HW_SW/Create
        public IActionResult Create()
        {
            ViewData["HardwareId"] = new SelectList(_context.Hardwares, "HardwareId", "Name");
            ViewData["SoftwareId"] = new SelectList(_context.Softwares, "SoftwareId", "Name");
            return View();
        }

        // POST: HW_SW/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Version,Comments,Status,HardwareId,SoftwareId")] HW_SW hW_SW)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hW_SW);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HardwareId"] = new SelectList(_context.Hardwares, "HardwareId", "Name", hW_SW.HardwareId);
            ViewData["SoftwareId"] = new SelectList(_context.Softwares, "SoftwareId", "Name", hW_SW.SoftwareId);
            return View(hW_SW);
        }

        // GET: HW_SW/Edit/5
        public async Task<IActionResult> Edit(int? hid, int? sid)
        {
            if (hid == null || sid == null)
            {
                return NotFound();
            }

            var hW_SW = await _context.HW_SW.FindAsync(hid, sid);
            if (hW_SW == null)
            {
                return NotFound();
            }
            ViewData["HardwareId"] = new SelectList(_context.Hardwares, "HardwareId", "Name", hW_SW.HardwareId);
            ViewData["SoftwareId"] = new SelectList(_context.Softwares, "SoftwareId", "Name", hW_SW.SoftwareId);
            return View(hW_SW);
        }

        // POST: HW_SW/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Version,Comments,Status,HardwareId,SoftwareId")] HW_SW hW_SW)
        {
            if (id != hW_SW.HardwareId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hW_SW);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HW_SWExists(hW_SW.HardwareId, hW_SW.SoftwareId))
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
            ViewData["HardwareId"] = new SelectList(_context.Hardwares, "HardwareId", "Name", hW_SW.HardwareId);
            ViewData["SoftwareId"] = new SelectList(_context.Softwares, "SoftwareId", "Name", hW_SW.SoftwareId);
            return View(hW_SW);
        }

        // GET: HW_SW/Delete/5
        public async Task<IActionResult> Delete(int? hid, int? sid)
        {
            if (hid == null || sid == null)
            {
                return NotFound();
            }

            var hW_SW = await _context.HW_SW
                .Include(h => h.Hardware)
                .Include(h => h.Software)
                .FirstOrDefaultAsync(m => m.HardwareId == hid && m.SoftwareId == sid);
            if (hW_SW == null)
            {
                return NotFound();
            }

            return View(hW_SW);
        }

        // POST: HW_SW/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var hW_SW = await _context.HW_SW.FindAsync(id);
            _context.HW_SW.Remove(hW_SW);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HW_SWExists(int? hid, int? sid)
        {
            return _context.HW_SW.Any(e => e.HardwareId == hid && e.SoftwareId == sid);
        }
    }
}
