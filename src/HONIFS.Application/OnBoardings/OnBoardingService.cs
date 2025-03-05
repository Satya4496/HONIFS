using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.OpenIddict.Applications;

namespace HONIFS.OnBoardings
{
    public class OnBoardingService : ApplicationService, IOnBoardingService
    {
        private readonly IRepository<OnBoarding, Guid> _onBoardingRepository;
        public OnBoardingService(IRepository<OnBoarding, Guid> onBoardingRepository)
        {
            _onBoardingRepository = onBoardingRepository;
        }

        public async Task<List<OnBoardingDto>> GetListAsync()
        {
            var items = await _onBoardingRepository.GetListAsync();
            return items
                .Select(item => new OnBoardingDto
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    UserName = item.UserName,
                    Email = item.Email,
                    Contact = item.Contact,
                    Address = item.Address,
                    TenantName = item.TenantName,
                    TenantType = item.TenantType
                }).ToList();
        }

        public async Task<OnBoardingDto> CreateAsync(OnBoardingDto onBoardingDto)
        {
            var onBoarding = await _onBoardingRepository.InsertAsync(
                new OnBoarding
                {
                    FirstName = onBoardingDto.FirstName,
                    LastName = onBoardingDto.LastName,
                    UserName = onBoardingDto.UserName,
                    Email = onBoardingDto.Email,
                    Contact = onBoardingDto.Contact,
                    Address = onBoardingDto.Address,
                    TenantName = onBoardingDto.TenantName,
                    TenantType = onBoardingDto.TenantType
                }
            );

            return new OnBoardingDto
            {
                Id = onBoarding.Id,
                FirstName = onBoarding.FirstName,
                LastName = onBoarding.LastName,
                UserName = onBoarding.UserName,
                Email = onBoarding.Email,
                Contact = onBoarding.Contact,
                Address = onBoarding.Address,
                TenantName = onBoarding.TenantName,
                TenantType = onBoarding.TenantType
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            await _onBoardingRepository.DeleteAsync(id);
        }

    }
}
