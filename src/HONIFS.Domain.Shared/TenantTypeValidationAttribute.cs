using HONIFS;
using System;
using System.ComponentModel.DataAnnotations;

public class TenantTypeValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is TenantType tenantType &&
            (tenantType == TenantType.Building || tenantType == TenantType.Department))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Invalid Tenant Type. Allowed values: Building, Department.");
    }
}

