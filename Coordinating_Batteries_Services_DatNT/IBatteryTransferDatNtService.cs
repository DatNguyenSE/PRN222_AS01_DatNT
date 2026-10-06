using Coordinating_Batteries_Entities_DatNT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinating_Batteries_Services_DatNT
{
    public interface IBatteryTransferDatNtService
    {
        Task<List<BatteryTransferDatNt>> GetAllAsync();

        Task<BatteryTransferDatNt> GetByIdAsync(int id);

        Task<List<BatteryTransferDatNt>> SearchAsyncByFromStation(string BatteryCode, int quantity, int fromStationId);

        Task<bool> RemoveAsync(int batteryTransferDatNtId);

        Task<int> AddAsync(BatteryTransferDatNt batteryTransferDatNt);

        Task<int> UpdateAsync(BatteryTransferDatNt batteryTransferDatNt);



    }

}
