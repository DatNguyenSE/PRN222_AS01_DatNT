using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coordinating_Batteries_Entities_DatNT.Models;
using Coordinating_Batteries_Repositories_DatNT.Models;

namespace Coordinating_Batteries_MVCWebApp_DatNT.Controllers
{
    public class StationDatNtsController : Controller
    {
        private readonly PRN212_SE1906_SE190283Context _context;

        public StationDatNtsController(PRN212_SE1906_SE190283Context context)
        {
            _context = context;
        }

        // GET: StationDatNts
        public async Task<IActionResult> Index()
        {
            return View(await _context.StationDatNts.ToListAsync());
        }

        // GET: StationDatNts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationDatNt = await _context.StationDatNts
                .FirstOrDefaultAsync(m => m.StationDatNtid == id.Value);
            if (stationDatNt == null)
            {
                return NotFound();
            }

            return View(stationDatNt);
        }

        // GET: StationDatNts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StationDatNts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StationDatNtid,StationName,Address,Capacity,Status,PublishDate")] StationDatNt stationDatNt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stationDatNt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stationDatNt);
        }

        // GET: StationDatNts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationDatNt = await _context.StationDatNts.FindAsync(id.Value);
            if (stationDatNt == null)
            {
                return NotFound();
            }
            return View(stationDatNt);
        }

        // POST: StationDatNts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StationDatNtid,StationName,Address,Capacity,Status,PublishDate")] StationDatNt stationDatNt)
        {
            if (id != stationDatNt.StationDatNtid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stationDatNt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StationDatNtExists(stationDatNt.StationDatNtid))
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
            return View(stationDatNt);
        }

        // GET: StationDatNts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stationDatNt = await _context.StationDatNts
                .FirstOrDefaultAsync(m => m.StationDatNtid == id.Value);
            if (stationDatNt == null)
            {
                return NotFound();
            }

            return View(stationDatNt);
        }

        // POST: StationDatNts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stationDatNt = await _context.StationDatNts.FindAsync(id);
            if (stationDatNt != null)
            {
                _context.StationDatNts.Remove(stationDatNt);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StationDatNtExists(int id)
        {
            return _context.StationDatNts.Any(e => e.StationDatNtid == id);
        }
    }
}
