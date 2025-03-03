using System;
using HONIFS.Shared;
using Volo.Abp.AutoMapper;
using HONIFS.Leads;
using AutoMapper;

namespace HONIFS;

public class HONIFSApplicationAutoMapperProfile : Profile
{
    public HONIFSApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Lead, LeadDto>();
        CreateMap<Lead, LeadExcelDto>();
    }
}