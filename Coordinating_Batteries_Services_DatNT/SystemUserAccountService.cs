using Coordinating_Batteries_Entities_DatNT.Models;
using Coordinating_Batteries_Repositories_DatNT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinating_Batteries_Services_DatNT
{
    public class SystemUserAccountService : ISystemUserAccountService
    {
        private readonly SystemUserAccountRepository _systemUserAccountRepository;
        public SystemUserAccountService() => _systemUserAccountRepository ??= new SystemUserAccountRepository();

       
        public Task<SystemUserAccount> GetUserAccount(string userName, string password)
        {
            try
            {
                return _systemUserAccountRepository.GetUserAccount(userName, password);
            }
            catch (Exception ex) {
            
                throw new Exception($"Error in GetUserAccount: {ex.Message}", ex);
            }
        }
    }
}
