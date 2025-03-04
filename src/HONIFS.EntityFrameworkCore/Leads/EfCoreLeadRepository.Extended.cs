using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using HONIFS.EntityFrameworkCore;

namespace HONIFS.Leads
{
    public class EfCoreLeadRepository : EfCoreLeadRepositoryBase, ILeadRepository
    {
        public EfCoreLeadRepository(IDbContextProvider<HONIFSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}