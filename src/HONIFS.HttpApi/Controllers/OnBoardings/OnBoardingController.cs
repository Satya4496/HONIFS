using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using HONIFS.Leads;
using Volo.Abp.Content;
using HONIFS.Shared;
using HONIFS.OnBoardings;

namespace HONIFS.Controllers.OnBoardings
{
    [RemoteService]
    [Area("app")]
    [ControllerName("OnBoarding")]
    [Route("api/app/onBoardings")]

    public abstract class OnBoardingControllerBase : AbpController
    {
        protected IOnBoardingService _onBoardingAppService;

        public OnBoardingControllerBase(IOnBoardingService onBoardingAppService)
        {
            _onBoardingAppService = onBoardingAppService;
        }

        [HttpGet]
        public virtual Task<List<OnBoardingDto>> GetListAsync()
        {
            return _onBoardingAppService.GetListAsync();
        }

        //[HttpGet]
        //[Route("{id}")]
        //public virtual Task<LeadDto> GetAsync(Guid id)
        //{
        //    return _leadsAppService.GetAsync(id);
        //}

        [HttpPost]
        public virtual Task<OnBoardingDto> CreateAsync(OnBoardingDto input)
        {
            return _onBoardingAppService.CreateAsync(input);
        }

        //[HttpPut]
        //[Route("{id}")]
        //public virtual Task<LeadDto> UpdateAsync(Guid id, LeadUpdateDto input)
        //{
        //    return _leadsAppService.UpdateAsync(id, input);
        //}

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _onBoardingAppService.DeleteAsync(id);
        }

        //[HttpGet]
        //[Route("as-excel-file")]
        //public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(LeadExcelDownloadDto input)
        //{
        //    return _leadsAppService.GetListAsExcelFileAsync(input);
        //}

        //[HttpGet]
        //[Route("download-token")]
        //public virtual Task<HONIFS.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        //{
        //    return _leadsAppService.GetDownloadTokenAsync();
        //}

        //[HttpDelete]
        //[Route("")]
        //public virtual Task DeleteByIdsAsync(List<Guid> leadIds)
        //{
        //    return _leadsAppService.DeleteByIdsAsync(leadIds);
        //}

        //[HttpDelete]
        //[Route("all")]
        //public virtual Task DeleteAllAsync(GetLeadsInput input)
        //{
        //    return _leadsAppService.DeleteAllAsync(input);
        //}
    }
}