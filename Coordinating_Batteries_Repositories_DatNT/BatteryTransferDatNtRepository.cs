using Coordinating_Batteries_Entities_DatNT.Models;
using Coordinating_Batteries_Repositories_DatNT.Base;
using Coordinating_Batteries_Repositories_DatNT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinating_Batteries_Repositories_DatNT
{
    public class BatteryTransferDatNtRepository : GenericRepository<BatteryTransferDatNt>
    {
        public BatteryTransferDatNtRepository() => _context ??= new PRN212_SE1906_SE190283Context();

        public BatteryTransferDatNtRepository(PRN212_SE1906_SE190283Context context) => _context = context;

        public async Task<List<BatteryTransferDatNt>> GetAllByFromStationAsync()
        {
            return await _context.BatteryTransferDatNts.Include(b => b.FromStationDatNt).ToListAsync();
        }

        public async Task<BatteryTransferDatNt> GetAllByFromStationidAsync(int fromStationId)
        {
            return await _context.BatteryTransferDatNts.Include(b => b.FromStationDatNt).FirstOrDefaultAsync(b => b.FromStationDatNtid == fromStationId);
        }
        public async Task<List<BatteryTransferDatNt>> GetAllByToStationByAsync()
        {
            return await _context.BatteryTransferDatNts.Include(b => b.ToStationDatNt).ToListAsync();
        }

        public async Task<BatteryTransferDatNt> GetAllByToStationidAsync(int toStationId)
        {
            return await _context.BatteryTransferDatNts.Include(b => b.ToStationDatNt).FirstOrDefaultAsync(b => b.ToStationDatNtid == toStationId);
        }

        // tìm kiếm mã pin và số lượng pin trong kho của trạm xuất đi

        public async Task<List<BatteryTransferDatNt>> SearchAsyncByFromStation(string BatteryCode, int quantity, int fromStationId)
        {
            return await _context.BatteryTransferDatNts.Include(b => b.FromStationDatNt).
                Where(s => s.FromStationDatNtid == fromStationId && s.BatteryCode.Contains(BatteryCode) && s.Quantity <= quantity ).ToListAsync();
        }

        public async Task<int> GetQuantityOfBatteriesCodeAsync(string batteryCode)
        {
            return await _context.BatteryTransferDatNts
                .Where(b => b.BatteryCode.Contains(batteryCode)).SumAsync(b => b.Quantity);

        }

        public async Task<int> GetQuantityOfExportedBatteriesCodeAsync(string batteryCode, int FromStationId)
        {
            return await _context.BatteryTransferDatNts
                .Where(b => b.FromStationDatNtid == FromStationId && b.BatteryCode.Contains(batteryCode)).SumAsync(b => b.Quantity);

        }


    }
}
