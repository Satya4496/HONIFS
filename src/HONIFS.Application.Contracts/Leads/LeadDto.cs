using HONIFS.Leads;
using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace HONIFS.Leads
{
    public abstract class LeadDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string? Address { get; set; }
        public string TenantName { get; set; } = null!;
        public LeadType Type { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}