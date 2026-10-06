using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coordinating_Batteries_Entities_DatNT.Models;
using Coordinating_Batteries_Repositories_DatNT.Models;
using Coordinating_Batteries_Services_DatNT;

namespace Coordinating_Batteries_MVCWebApp_DatNT.Controllers
{
    public class BatteryTransferDatNtsController : Controller
    {
        //private readonly PRN212_SE1906_SE190283Context _context;

        private readonly IBatteryTransferDatNtService _batteryTransferService;

        private readonly IStationDatNtService _stationService;


        public BatteryTransferDatNtsController(IBatteryTransferDatNtService batteryTransferService, IStationDatNtService stationService)
        {
            _batteryTransferService = batteryTransferService;
            _stationService = stationService;
        }

        // GET: BatteryTransferDatNts
        public async Task<IActionResult> Index()
        {
            //var pRN212_SE1906_SE190283Context = _context.BatteryTransferDatNts.Include(b => b.FromStationDatNt).Include(b => b.ToStationDatNt);
            //return View(await pRN212_SE1906_SE190283Context.ToListAsync());

            var items = await _batteryTransferService.GetAllAsync();
            return View(items);
        }

        // GET: BatteryTransferDatNts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batteryTransferDatNt = await _batteryTransferService.GetByIdAsync(id.Value);
                
            if (batteryTransferDatNt == null)
            {
                return NotFound();
            }

            return View(batteryTransferDatNt);
        }

        //        // GET: BatteryTransferDatNts/Create
        public async Task<IActionResult> Create()
        {
            var Stations = await _stationService.GetAllAsync();


            ViewData["FromStationDatNtid"] = new SelectList(Stations, "StationDatNtid", "StationName");
            ViewData["ToStationDatNtid"] = new SelectList(Stations, "StationDatNtid", "StationName");
            var item = new BatteryTransferDatNt()
            {
                BatteryCode = "",
                FromStationDatNtid = 0,
                ToStationDatNtid = 0,
                Quantity = 0,
                SoHpercent = 0,
                TransportCost = 0,
                RequestDate = DateTime.Now,
                //CompletedDate = DateTime.Now,
                Status = 0,
                Note = "",
                IsActive = true,

            };
            return View(item);
        }

        // POST: BatteryTransferDatNts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BatteryTransferDatNtid,BatteryCode,FromStationDatNtid,ToStationDatNtid,Quantity,SoHpercent,TransportCost,RequestDate,CompletedDate,Status,Note,IsActive")] BatteryTransferDatNt batteryTransferDatNt)
        {
            if (ModelState.IsValid)
            {
                await _batteryTransferService.AddAsync(batteryTransferDatNt);
             
                return RedirectToAction(nameof(Index));
            }
            var Stations = await _stationService.GetAllAsync();
            ViewData["FromStationDatNtid"] = new SelectList(Stations, "StationDatNtid", "StationName", batteryTransferDatNt.FromStationDatNtid);
            ViewData["ToStationDatNtid"] = new SelectList(Stations, "StationDatNtid", "StationName", batteryTransferDatNt.ToStationDatNtid);
            return View(batteryTransferDatNt);
        }

        //        // GET: BatteryTransferDatNts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batteryTransferDatNt = await _batteryTransferService.GetByIdAsync(id.Value);
            if (batteryTransferDatNt == null)
            {
                return NotFound();
            }
            var stations = await _stationService.GetAllAsync();
            ViewData["FromStationDatNtid"] = new SelectList(stations, "StationDatNtid", "StationName", batteryTransferDatNt.FromStationDatNtid);
            ViewData["ToStationDatNtid"] = new SelectList(stations, "StationDatNtid", "StationName", batteryTransferDatNt.ToStationDatNtid);
            return View(batteryTransferDatNt);
        }

        //        // POST: BatteryTransferDatNts/Edit/5
        //        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BatteryTransferDatNtid,BatteryCode,FromStationDatNtid,ToStationDatNtid,Quantity,SoHpercent,TransportCost,RequestDate,CompletedDate,Status,Note,IsActive")] BatteryTransferDatNt batteryTransferDatNt)
        {
            if (id != batteryTransferDatNt.BatteryTransferDatNtid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _batteryTransferService.UpdateAsync(batteryTransferDatNt);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var stationlist = await _batteryTransferService.GetAllAsync();
                    bool exits = stationlist.Any(s => s.BatteryTransferDatNtid == batteryTransferDatNt.BatteryTransferDatNtid);
                    if (!exits)
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
            var stations = await _stationService.GetAllAsync();
            ViewData["FromStationDatNtid"] = new SelectList(stations, "StationDatNtid", "StationName", batteryTransferDatNt.FromStationDatNtid);
            ViewData["ToStationDatNtid"] = new SelectList(stations, "StationDatNtid", "StationName", batteryTransferDatNt.ToStationDatNtid);
            return View(batteryTransferDatNt);
        }

        //        // GET: BatteryTransferDatNts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batteryTransferDatNt = await _batteryTransferService.GetByIdAsync(id.Value);
                
            if (batteryTransferDatNt == null)
            {
                return NotFound();
            }

            return View(batteryTransferDatNt);
        }

        // POST: BatteryTransferDatNts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batteryTransferDatNt = await _batteryTransferService.GetByIdAsync(id);
            if (batteryTransferDatNt != null)
            {
                await _batteryTransferService.RemoveAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
