using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HONIFS.Tenants
{
    public class CreateTenantDto
    {
        [Required]
        public string Name { get; set; }

        public Guid? EditionId { get; set; }

        public int ActivationState { get; set; }

        public DateTime? ActivationEndDate { get; set; }

        public DateTime? EditionEndDateUtc { get; set; }

        [Required]
        public string AdminEmailAddress { get; set; }

        [Required]
        public string AdminPassword { get; set; }

        [Required] // Ensure it's required
        public TenantType TenantType { get; set; }
    }

}
