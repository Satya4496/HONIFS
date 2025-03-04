using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using HONIFS.Leads;

namespace HONIFS.Controllers.Leads
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Lead")]
    [Route("api/app/leads")]

    public class LeadController : LeadControllerBase, ILeadsAppService
    {
        public LeadController(ILeadsAppService leadsAppService) : base(leadsAppService)
        {
        }
    }
}