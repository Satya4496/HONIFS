using HONIFS.Leads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace HONIFS.Leads
{
    public abstract class LeadManagerBase : DomainService
    {
        protected ILeadRepository _leadRepository;

        public LeadManagerBase(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public virtual async Task<Lead> CreateAsync(
        string firstName, string lastName, string userName, string email, string contact, string tenantName, LeadType type, string? address = null)
        {
            Check.NotNullOrWhiteSpace(firstName, nameof(firstName));
            Check.NotNullOrWhiteSpace(lastName, nameof(lastName));
            Check.NotNullOrWhiteSpace(userName, nameof(userName));
            Check.NotNullOrWhiteSpace(email, nameof(email));
            Check.NotNullOrWhiteSpace(contact, nameof(contact));
            Check.NotNullOrWhiteSpace(tenantName, nameof(tenantName));
            Check.NotNull(type, nameof(type));

            var lead = new Lead(
             GuidGenerator.Create(),
             firstName, lastName, userName, email, contact, tenantName, type, address
             );

            return await _leadRepository.InsertAsync(lead);
        }

        public virtual async Task<Lead> UpdateAsync(
            Guid id,
            string firstName, string lastName, string userName, string email, string contact, string tenantName, LeadType type, string? address = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(firstName, nameof(firstName));
            Check.NotNullOrWhiteSpace(lastName, nameof(lastName));
            Check.NotNullOrWhiteSpace(userName, nameof(userName));
            Check.NotNullOrWhiteSpace(email, nameof(email));
            Check.NotNullOrWhiteSpace(contact, nameof(contact));
            Check.NotNullOrWhiteSpace(tenantName, nameof(tenantName));
            Check.NotNull(type, nameof(type));

            var lead = await _leadRepository.GetAsync(id);

            lead.FirstName = firstName;
            lead.LastName = lastName;
            lead.UserName = userName;
            lead.Email = email;
            lead.Contact = contact;
            lead.TenantName = tenantName;
            lead.Type = type;
            lead.Address = address;

            lead.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _leadRepository.UpdateAsync(lead);
        }

    }
}