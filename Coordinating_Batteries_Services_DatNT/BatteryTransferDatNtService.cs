using Coordinating_Batteries_Entities_DatNT.Models;
using Coordinating_Batteries_Repositories_DatNT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinating_Batteries_Services_DatNT
{
    public class BatteryTransferDatNtService : IBatteryTransferDatNtService
    {
        private readonly BatteryTransferDatNtRepository _repo;
        public BatteryTransferDatNtService() => _repo ??= new BatteryTransferDatNtRepository();

        public async Task<int> AddAsync(BatteryTransferDatNt batteryTransferDatNt)
        {
            try
            {
                return await Task.Run(() => _repo.CreateAsync(batteryTransferDatNt)); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> RemoveAsync(int batteryTransferDatNtId)

        {
            
            try
            {
                var item = _repo.GetById(batteryTransferDatNtId);
                if (item == null)
                {
                    throw new Exception("Not Found item with "+ batteryTransferDatNtId);
                }
                return Task.Run(() => _repo.RemoveAsync(item));
            }
            catch (Exception)
            {

                throw new ApplicationException($"Error in RemoveAsync: Not Found item with {batteryTransferDatNtId}");
            }
        }

        public async Task<List<BatteryTransferDatNt>> GetAllAsync()
        {
            try 
            {
                return await Task.Run(() => _repo.GetAllAsync());
            } catch (Exception ex) {
                throw new Exception($"Error in GetAllAsync: {ex.Message}", ex);
            }
        }

        public async Task<BatteryTransferDatNt> GetByIdAsync(int id)
        {
            try
            {
                return await Task.Run(() => _repo.GetByIdAsync(id));
            }
            catch (Exception ex)
            {

                throw new Exception($"Error in GetByIdAsync: {ex.Message}", ex);
            }
        }

        public async Task<List<BatteryTransferDatNt>> SearchAsyncByFromStation(string BatteryCode, int quantity, int fromStationId)
        {
            try
            {
               return await  Task.Run(() => _repo.SearchAsyncByFromStation(BatteryCode, quantity, fromStationId));
            }
            catch (Exception ex)
            {

                throw new Exception($"Error in SearchAsyncByFromStation: {ex.Message}", ex);
            }
        }

        public async Task<int> UpdateAsync(BatteryTransferDatNt batteryTransferDatNt)
        {
            try
            {
                return await Task.Run(() => _repo.UpdateAsync(batteryTransferDatNt));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
