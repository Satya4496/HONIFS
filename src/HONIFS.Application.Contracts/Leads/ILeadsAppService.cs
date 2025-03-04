using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using HONIFS.Shared;

namespace HONIFS.Leads
{
    public partial interface ILeadsAppService : IApplicationService
    {

        Task<PagedResultDto<LeadDto>> GetListAsync(GetLeadsInput input);

        Task<LeadDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<LeadDto> CreateAsync(LeadCreateDto input);

        Task<LeadDto> UpdateAsync(Guid id, LeadUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(LeadExcelDownloadDto input);
        Task DeleteByIdsAsync(List<Guid> leadIds);

        Task DeleteAllAsync(GetLeadsInput input);
        Task<HONIFS.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}