using HONIFS.Leads;
using Volo.Abp.Application.Dtos;
using System;

namespace HONIFS.Leads
{
    public abstract class GetLeadsInputBase : PagedAndSortedResultRequestDto
    {

        public string? FilterText { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        public string? Address { get; set; }
        public string? TenantName { get; set; }
        public LeadType? Type { get; set; }

        public GetLeadsInputBase()
        {

        }
    }
}