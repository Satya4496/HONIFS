using HONIFS.Leads;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace HONIFS.Leads
{
    public abstract class LeadUpdateDtoBase : IHasConcurrencyStamp
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Contact { get; set; } = null!;
        public string? Address { get; set; }
        [Required]
        public string TenantName { get; set; } = null!;
        public LeadType Type { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}