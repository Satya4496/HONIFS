using HONIFS.Leads;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace HONIFS.Leads
{
    public abstract class LeadBase : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string FirstName { get; set; }

        [NotNull]
        public virtual string LastName { get; set; }

        [NotNull]
        public virtual string UserName { get; set; }

        [NotNull]
        public virtual string Email { get; set; }

        [NotNull]
        public virtual string Contact { get; set; }

        [CanBeNull]
        public virtual string? Address { get; set; }

        [NotNull]
        public virtual string TenantName { get; set; }

        public virtual LeadType Type { get; set; }

        protected LeadBase()
        {

        }

        public LeadBase(Guid id, string firstName, string lastName, string userName, string email, string contact, string tenantName, LeadType type, string? address = null)
        {

            Id = id;
            Check.NotNull(firstName, nameof(firstName));
            Check.NotNull(lastName, nameof(lastName));
            Check.NotNull(userName, nameof(userName));
            Check.NotNull(email, nameof(email));
            Check.NotNull(contact, nameof(contact));
            Check.NotNull(tenantName, nameof(tenantName));
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Contact = contact;
            TenantName = tenantName;
            Type = type;
            Address = address;
        }

    }
}