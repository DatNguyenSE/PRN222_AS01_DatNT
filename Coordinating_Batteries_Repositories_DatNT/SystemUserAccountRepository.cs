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

    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {

        public SystemUserAccountRepository() => _context ??= new PRN212_SE1906_SE190283Context();

        public SystemUserAccountRepository(PRN212_SE1906_SE190283Context context) => _context = context;

        public async Task<SystemUserAccount> GetUserAccount(string userName, string password)
        {
            //return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password && u.IsActive);
            
            return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.Email == userName && u.Password == password && u.IsActive);

        }
    }
}
