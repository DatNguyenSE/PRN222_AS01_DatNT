using Coordinating_Batteries_Entities_DatNT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinating_Batteries_Services_DatNT
{
    public interface IStationDatNtService

    {
        Task<List<StationDatNt>> GetAllAsync();
    }
}
