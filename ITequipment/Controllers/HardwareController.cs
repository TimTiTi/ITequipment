﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITequipment.Data;
using ITequipment.Models;
using Microsoft.AspNetCore.Authorization;

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
            var applicationDbContext = _context.Hardwares.Include(h => h.Brand).Include(h => h.Owner).Include(h => h.Room);
            return View(await applicationDbContext
                .OrderBy(h => h.Name).ThenBy(h => h.Room).ToListAsync());
        }

        // GET: Hardware/Details/5
        [Authorize(Roles = "Admin, PowerUser, User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardware = await _context.Hardwares
                .Include(h => h.Brand)
                .Include(h => h.Owner)
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.HardwareId == id);
            if (hardware == null)
            {
                return NotFound();
            }

            return View(hardware);
        }

        // GET: Hardware/Create
        [Authorize(Roles = "Admin, PowerUser")]
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name");
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "FullName");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name");
            return View();
        }

        // POST: Hardware/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HardwareId,Serial,Name,Purpose,Specs,AdditionalInfo,AcquiredDate,Condition,BrandId,RoomId,OwnerId")] Hardware hardware)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hardware);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name", hardware.BrandId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "FullName", hardware.OwnerId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", hardware.RoomId);
            return View(hardware);
        }

        // GET: Hardware/Edit/5
        [Authorize(Roles = "Admin, PowerUser")]
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name", hardware.BrandId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "FullName", hardware.OwnerId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", hardware.RoomId);
            return View(hardware);
        }

        // POST: Hardware/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HardwareId,Serial,Name,Purpose,Specs,AdditionalInfo,AcquiredDate,Condition,BrandId,RoomId,OwnerId")] Hardware hardware)
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandId", "Name", hardware.BrandId);
            ViewData["OwnerId"] = new SelectList(_context.Owners, "OwnerId", "FullName", hardware.OwnerId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "RoomId", "Name", hardware.RoomId);
            return View(hardware);
        }

        // GET: Hardware/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardware = await _context.Hardwares
                .Include(h => h.Brand)
                .Include(h => h.Owner)
                .Include(h => h.Room)
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
