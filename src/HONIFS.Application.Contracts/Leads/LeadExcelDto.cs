using HONIFS.Leads;
using System;

namespace HONIFS.Leads
{
    public abstract class LeadExcelDtoBase
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contact { get; set; } = null!;
        public string? Address { get; set; }
        public string TenantName { get; set; } = null!;
        public LeadType Type { get; set; }
    }
}