using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HONIFS.OnBoardings
{
    public class OnBoarding : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public string FirstName { get; set; } = string.Empty;
        [NotNull]
        public string LastName { get; set; } = string.Empty;
        [NotNull]
        public string UserName { get; set; } = string.Empty;
        [NotNull]
        public string Email { get; set; } = string.Empty;
        [NotNull]
        public string Contact { get; set; } = string.Empty;
        [CanBeNull]
        public string? Address { get; set; } = string.Empty;
        [NotNull]
        public string TenantName { get; set; } = string.Empty;
        public TenantTypeForOnBoarding TenantType { get; set; }
    }

    //public enum TenantTypeForOnBoarding
    //{
    //    Building = 1,
    //    Department = 2
    //}
}
