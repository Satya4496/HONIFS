using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HONIFS.OnBoardings
{
    public class OnBoardingDto
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Contact { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        [Required]
        public string TenantName { get; set; } = string.Empty;
        [Required]
        public TenantTypeForOnBoarding TenantType { get; set; }
    }

    //public enum TenantTypeForOnBoarding
    //{
    //    Building = 1,
    //    Department = 2
    //}
}
