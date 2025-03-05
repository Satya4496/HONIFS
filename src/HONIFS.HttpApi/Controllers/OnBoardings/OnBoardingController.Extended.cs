using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using HONIFS.Leads;
using HONIFS.OnBoardings;

namespace HONIFS.Controllers.OnBoardings
{
    [RemoteService]
    [Area("app")]
    [ControllerName("OnBoarding")]
    [Route("api/app/onBoardings")]

    public class LeadController : OnBoardingControllerBase, IOnBoardingService
    {
        public LeadController(IOnBoardingService onBoardingAppService) : base(onBoardingAppService)
        {
        }
    }
}