using Coordinating_Batteries_Entities_DatNT.Models;
using Coordinating_Batteries_Repositories_DatNT.Base;
using Coordinating_Batteries_Repositories_DatNT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Coordinating_Batteries_Repositories_DatNT
{
    public class StationDatNtRepository : GenericRepository<StationDatNt>
    {
        public StationDatNtRepository() => _context ??= new PRN212_SE1906_SE190283Context();
        
        public StationDatNtRepository(PRN212_SE1906_SE190283Context context) => _context = context;

    
        public async Task<List<StationDatNt>> SearchStationAsync(string keyword)
        {
            return await _context.StationDatNts.Where(s => s.StationName.Contains(keyword) || s.Address.Contains(keyword)).ToListAsync();
        }


    }
}
