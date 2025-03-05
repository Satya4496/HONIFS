using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.OpenIddict.Applications;

namespace HONIFS.OnBoardings
{
    public interface IOnBoardingService : IApplicationService
    {
        Task<List<OnBoardingDto>> GetListAsync();
        Task<OnBoardingDto> CreateAsync(OnBoardingDto onBoardingDto);
        Task DeleteAsync(Guid id);
    }
}
