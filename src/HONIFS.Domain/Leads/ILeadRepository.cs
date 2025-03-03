using HONIFS.Leads;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace HONIFS.Leads
{
    public partial interface ILeadRepository : IRepository<Lead, Guid>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            string? userName = null,
            string? email = null,
            string? contact = null,
            string? address = null,
            string? tenantName = null,
            LeadType? type = null,
            CancellationToken cancellationToken = default);
        Task<List<Lead>> GetListAsync(
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
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? firstName = null,
            string? lastName = null,
            string? userName = null,
            string? email = null,
            string? contact = null,
            string? address = null,
            string? tenantName = null,
            LeadType? type = null,
            CancellationToken cancellationToken = default);
    }
}