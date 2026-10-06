using Coordinating_Batteries_Entities_DatNT.Models;
using Coordinating_Batteries_Repositories_DatNT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinating_Batteries_Services_DatNT
{
    public class StationDatNtService : IStationDatNtService
    {
        private readonly StationDatNtRepository _repo;
        public StationDatNtService()
        {
            _repo = new StationDatNtRepository();
        }
        public async Task<List<StationDatNt>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
    }
}
