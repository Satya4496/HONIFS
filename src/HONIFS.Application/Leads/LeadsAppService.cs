using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using HONIFS.Permissions;
using HONIFS.Leads;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using HONIFS.Shared;

namespace HONIFS.Leads
{
    [RemoteService(IsEnabled = false)]
    [Authorize(HONIFSPermissions.Leads.Default)]
    public abstract class LeadsAppServiceBase : HONIFSAppService
    {
        protected IDistributedCache<LeadDownloadTokenCacheItem, string> _downloadTokenCache;
        protected ILeadRepository _leadRepository;
        protected LeadManager _leadManager;

        public LeadsAppServiceBase(ILeadRepository leadRepository, LeadManager leadManager, IDistributedCache<LeadDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _leadRepository = leadRepository;
            _leadManager = leadManager;

        }

        public virtual async Task<PagedResultDto<LeadDto>> GetListAsync(GetLeadsInput input)
        {
            var totalCount = await _leadRepository.GetCountAsync(input.FilterText, input.FirstName, input.LastName, input.UserName, input.Email, input.Contact, input.Address, input.TenantName, input.Type);
            var items = await _leadRepository.GetListAsync(input.FilterText, input.FirstName, input.LastName, input.UserName, input.Email, input.Contact, input.Address, input.TenantName, input.Type, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<LeadDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Lead>, List<LeadDto>>(items)
            };
        }

        public virtual async Task<LeadDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Lead, LeadDto>(await _leadRepository.GetAsync(id));
        }

        [Authorize(HONIFSPermissions.Leads.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _leadRepository.DeleteAsync(id);
        }

        [Authorize(HONIFSPermissions.Leads.Create)]
        public virtual async Task<LeadDto> CreateAsync(LeadCreateDto input)
        {

            var lead = await _leadManager.CreateAsync(
            input.FirstName, input.LastName, input.UserName, input.Email, input.Contact, input.TenantName, input.Type, input.Address
            );

            return ObjectMapper.Map<Lead, LeadDto>(lead);
        }

        [Authorize(HONIFSPermissions.Leads.Edit)]
        public virtual async Task<LeadDto> UpdateAsync(Guid id, LeadUpdateDto input)
        {

            var lead = await _leadManager.UpdateAsync(
            id,
            input.FirstName, input.LastName, input.UserName, input.Email, input.Contact, input.TenantName, input.Type, input.Address, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Lead, LeadDto>(lead);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(LeadExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _leadRepository.GetListAsync(input.FilterText, input.FirstName, input.LastName, input.UserName, input.Email, input.Contact, input.Address, input.TenantName, input.Type);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Lead>, List<LeadExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Leads.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(HONIFSPermissions.Leads.Delete)]
        public virtual async Task DeleteByIdsAsync(List<Guid> leadIds)
        {
            await _leadRepository.DeleteManyAsync(leadIds);
        }

        [Authorize(HONIFSPermissions.Leads.Delete)]
        public virtual async Task DeleteAllAsync(GetLeadsInput input)
        {
            await _leadRepository.DeleteAllAsync(input.FilterText, input.FirstName, input.LastName, input.UserName, input.Email, input.Contact, input.Address, input.TenantName, input.Type);
        }
        public virtual async Task<HONIFS.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new LeadDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new HONIFS.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}