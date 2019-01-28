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
    public class BusRoutesController : Controller
    {
        private readonly UrbanTransportContext _context;

        public BusRoutesController(UrbanTransportContext context)
        {
            _context = context;
        }

        // GET: BusRoutes
        public async Task<IActionResult> Index()
        {
            var urbanTransportContext = _context.BusRoute.Include(b => b.Bus).Include(b => b.Route);
            return View(await urbanTransportContext.ToListAsync());
        }

        // GET: BusRoutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busRoute = await _context.BusRoute
                .Include(b => b.Bus)
                .Include(b => b.Route)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (busRoute == null)
            {
                return NotFound();
            }

            return View(busRoute);
        }

        // GET: BusRoutes/Create
        public IActionResult Create()
        {
            ViewData["BusId"] = new SelectList(_context.Bus, "Id", "LicencePlate");
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Name");
            return View();
        }

        // POST: BusRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BusId,RouteId")] BusRoute busRoute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(busRoute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusId"] = new SelectList(_context.Bus, "Id", "LicencePlate", busRoute.BusId);
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Name", busRoute.RouteId);
            return View(busRoute);
        }

        // GET: BusRoutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busRoute = await _context.BusRoute.FindAsync(id);
            if (busRoute == null)
            {
                return NotFound();
            }
            ViewData["BusId"] = new SelectList(_context.Bus, "Id", "LicencePlate", busRoute.BusId);
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Name", busRoute.RouteId);
            return View(busRoute);
        }

        // POST: BusRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BusId,RouteId")] BusRoute busRoute)
        {
            if (id != busRoute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusRouteExists(busRoute.Id))
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
            ViewData["BusId"] = new SelectList(_context.Bus, "Id", "LicencePlate", busRoute.BusId);
            ViewData["RouteId"] = new SelectList(_context.Route, "Id", "Name", busRoute.RouteId);
            return View(busRoute);
        }

        // GET: BusRoutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busRoute = await _context.BusRoute
                .Include(b => b.Bus)
                .Include(b => b.Route)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (busRoute == null)
            {
                return NotFound();
            }

            return View(busRoute);
        }

        // POST: BusRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var busRoute = await _context.BusRoute.FindAsync(id);
            _context.BusRoute.Remove(busRoute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusRouteExists(int id)
        {
            return _context.BusRoute.Any(e => e.Id == id);
        }
    }
}
