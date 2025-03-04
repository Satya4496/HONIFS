using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace HONIFS.Leads
{
    public abstract class LeadsAppServiceTests<TStartupModule> : HONIFSApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ILeadsAppService _leadsAppService;
        private readonly IRepository<Lead, Guid> _leadRepository;

        public LeadsAppServiceTests()
        {
            _leadsAppService = GetRequiredService<ILeadsAppService>();
            _leadRepository = GetRequiredService<IRepository<Lead, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _leadsAppService.GetListAsync(new GetLeadsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("a5ae4f74-6247-4e7e-b969-642b544131b0")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("c556d620-4b73-4637-9fa9-fb2109901df5")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _leadsAppService.GetAsync(Guid.Parse("a5ae4f74-6247-4e7e-b969-642b544131b0"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("a5ae4f74-6247-4e7e-b969-642b544131b0"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new LeadCreateDto
            {
                FirstName = "4777e563af1445aba80ccd2a82220e437512d34538864095bded7bed9fd2eb865ff0f698db3f483db16f7a533bf0bc282e",
                LastName = "f86e5a7d87b54a6d8ea501588a864e611f88625a6b81443bbf221f2e516af",
                UserName = "8e9d2c96602b4670a8b253",
                Email = "c95d0c8030c9462c920fc2296164612a350599",
                Contact = "4e5f5da1bba9492c9487938cf99da242c0926cb20c73417dba327f55a1a7b5edb1275731f902455eb9ffcb002060476",
                Address = "f0cfa680cf2140338e51b4a113d27e",
                TenantName = "84d5da964735476ab815a173451f932cd849d7258ddb489296b3e36d972f4bc75d813de66b5042639c623932c54",
                Type = default
            };

            // Act
            var serviceResult = await _leadsAppService.CreateAsync(input);

            // Assert
            var result = await _leadRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.FirstName.ShouldBe("4777e563af1445aba80ccd2a82220e437512d34538864095bded7bed9fd2eb865ff0f698db3f483db16f7a533bf0bc282e");
            result.LastName.ShouldBe("f86e5a7d87b54a6d8ea501588a864e611f88625a6b81443bbf221f2e516af");
            result.UserName.ShouldBe("8e9d2c96602b4670a8b253");
            result.Email.ShouldBe("c95d0c8030c9462c920fc2296164612a350599");
            result.Contact.ShouldBe("4e5f5da1bba9492c9487938cf99da242c0926cb20c73417dba327f55a1a7b5edb1275731f902455eb9ffcb002060476");
            result.Address.ShouldBe("f0cfa680cf2140338e51b4a113d27e");
            result.TenantName.ShouldBe("84d5da964735476ab815a173451f932cd849d7258ddb489296b3e36d972f4bc75d813de66b5042639c623932c54");
            result.Type.ShouldBe(default);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new LeadUpdateDto()
            {
                FirstName = "909b160bf96e4ca3913",
                LastName = "ac3ca8d60b2a4489b18e88e03325704c5d3bc6e4a6194fde9c53e",
                UserName = "fe007414ad7f4551b8588ccf990498f584f8b7e4a8464858a8f75b149",
                Email = "45af1f15c7fa40b0bc68adf41840693b6245f649c5164e0e8870a6901eb6562a98b9166",
                Contact = "66eec697aa674efd971af709",
                Address = "85ace2363b564cec83da08133eceacc0719f1b51d6c64c309a297586d27cf0379bf75df7bf0a48e4ab92ef2858303852d2",
                TenantName = "65c0d4e5d37c4956804e5a38a511d4d06547508eba054968871da0e54f52d9d7c51d1c18380a42e",
                Type = default
            };

            // Act
            var serviceResult = await _leadsAppService.UpdateAsync(Guid.Parse("a5ae4f74-6247-4e7e-b969-642b544131b0"), input);

            // Assert
            var result = await _leadRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.FirstName.ShouldBe("909b160bf96e4ca3913");
            result.LastName.ShouldBe("ac3ca8d60b2a4489b18e88e03325704c5d3bc6e4a6194fde9c53e");
            result.UserName.ShouldBe("fe007414ad7f4551b8588ccf990498f584f8b7e4a8464858a8f75b149");
            result.Email.ShouldBe("45af1f15c7fa40b0bc68adf41840693b6245f649c5164e0e8870a6901eb6562a98b9166");
            result.Contact.ShouldBe("66eec697aa674efd971af709");
            result.Address.ShouldBe("85ace2363b564cec83da08133eceacc0719f1b51d6c64c309a297586d27cf0379bf75df7bf0a48e4ab92ef2858303852d2");
            result.TenantName.ShouldBe("65c0d4e5d37c4956804e5a38a511d4d06547508eba054968871da0e54f52d9d7c51d1c18380a42e");
            result.Type.ShouldBe(default);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _leadsAppService.DeleteAsync(Guid.Parse("a5ae4f74-6247-4e7e-b969-642b544131b0"));

            // Assert
            var result = await _leadRepository.FindAsync(c => c.Id == Guid.Parse("a5ae4f74-6247-4e7e-b969-642b544131b0"));

            result.ShouldBeNull();
        }
    }
}