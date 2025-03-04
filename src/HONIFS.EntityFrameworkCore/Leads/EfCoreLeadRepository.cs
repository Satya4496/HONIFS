using HONIFS.Leads;
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
    public abstract class EfCoreLeadRepositoryBase : EfCoreRepository<HONIFSDbContext, Lead, Guid>
    {
        public EfCoreLeadRepositoryBase(IDbContextProvider<HONIFSDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? firstName = null,
            string? lastName = null,
            string? userName = null,
            string? email = null,
            string? contact = null,
            string? address = null,
            string? tenantName = null,
            LeadType? type = null,
            CancellationToken cancellationToken = default)
        {

            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, firstName, lastName, userName, email, contact, address, tenantName, type);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Lead>> GetListAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            string? userName = null,
            string? email = null,
            string? contact = null,
            string? address = null,
            string? tenantName = null,
            LeadType? type = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, firstName, lastName, userName, email, contact, address, tenantName, type);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? LeadConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            string? userName = null,
            string? email = null,
            string? contact = null,
            string? address = null,
            string? tenantName = null,
            LeadType? type = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, firstName, lastName, userName, email, contact, address, tenantName, type);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Lead> ApplyFilter(
            IQueryable<Lead> query,
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            string? userName = null,
            string? email = null,
            string? contact = null,
            string? address = null,
            string? tenantName = null,
            LeadType? type = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.FirstName!.Contains(filterText!) || e.LastName!.Contains(filterText!) || e.UserName!.Contains(filterText!) || e.Email!.Contains(filterText!) || e.Contact!.Contains(filterText!) || e.Address!.Contains(filterText!) || e.TenantName!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(firstName), e => e.FirstName.Contains(firstName))
                    .WhereIf(!string.IsNullOrWhiteSpace(lastName), e => e.LastName.Contains(lastName))
                    .WhereIf(!string.IsNullOrWhiteSpace(userName), e => e.UserName.Contains(userName))
                    .WhereIf(!string.IsNullOrWhiteSpace(email), e => e.Email.Contains(email))
                    .WhereIf(!string.IsNullOrWhiteSpace(contact), e => e.Contact.Contains(contact))
                    .WhereIf(!string.IsNullOrWhiteSpace(address), e => e.Address.Contains(address))
                    .WhereIf(!string.IsNullOrWhiteSpace(tenantName), e => e.TenantName.Contains(tenantName))
                    .WhereIf(type.HasValue, e => e.Type == type);
        }
    }
}