using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UrbanTransport.Models;

namespace UrbanTransport.Controllers
{
    public class ControlRecordsController : Controller
    {
        private readonly UrbanTransportContext _context;

        public ControlRecordsController(UrbanTransportContext context)
        {
            _context = context;
        }

        // GET: ControlRecords
        public async Task<IActionResult> Index()
        {
            var urbanTransportContext = _context.ControlRecord.Include(c => c.Bus).Include(c => c.CheckPoint).Include(c => c.User);
            return View(await urbanTransportContext.ToListAsync());
        }

        // GET: ControlRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlRecord = await _context.ControlRecord
                .Include(c => c.Bus)
                .Include(c => c.CheckPoint)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controlRecord == null)
            {
                return NotFound();
            }

            return View(controlRecord);
        }

        // GET: ControlRecords/Create
        public IActionResult Create()
        {
            ViewData["BusId"] = new SelectList(_context.Bus, "Id", "LicencePlate");
            ViewData["CheckPointId"] = new SelectList(_context.CheckPoint, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FirstName");
            return View();
        }

        // POST: ControlRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CheckPointId,BusId,UserId,RecorDate")] ControlRecord controlRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controlRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusId"] = new SelectList(_context.Bus, "Id", "LicencePlate", controlRecord.BusId);
            ViewData["CheckPointId"] = new SelectList(_context.CheckPoint, "Id", "Name", controlRecord.CheckPointId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FirstName", controlRecord.UserId);
            return View(controlRecord);
        }

        // GET: ControlRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlRecord = await _context.ControlRecord.FindAsync(id);
            if (controlRecord == null)
            {
                return NotFound();
            }
            ViewData["BusId"] = new SelectList(_context.Bus, "Id", "LicencePlate", controlRecord.BusId);
            ViewData["CheckPointId"] = new SelectList(_context.CheckPoint, "Id", "Name", controlRecord.CheckPointId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FirstName", controlRecord.UserId);
            return View(controlRecord);
        }

        // POST: ControlRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CheckPointId,BusId,UserId,RecorDate")] ControlRecord controlRecord)
        {
            if (id != controlRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controlRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControlRecordExists(controlRecord.Id))
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
            ViewData["BusId"] = new SelectList(_context.Bus, "Id", "LicencePlate", controlRecord.BusId);
            ViewData["CheckPointId"] = new SelectList(_context.CheckPoint, "Id", "Name", controlRecord.CheckPointId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "FirstName", controlRecord.UserId);
            return View(controlRecord);
        }

        // GET: ControlRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlRecord = await _context.ControlRecord
                .Include(c => c.Bus)
                .Include(c => c.CheckPoint)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controlRecord == null)
            {
                return NotFound();
            }

            return View(controlRecord);
        }

        // POST: ControlRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controlRecord = await _context.ControlRecord.FindAsync(id);
            _context.ControlRecord.Remove(controlRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControlRecordExists(int id)
        {
            return _context.ControlRecord.Any(e => e.Id == id);
        }
    }
}
