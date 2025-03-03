using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using HONIFS.Leads;

namespace HONIFS.Leads
{
    public class LeadsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ILeadRepository _leadRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public LeadsDataSeedContributor(ILeadRepository leadRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _leadRepository = leadRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _leadRepository.InsertAsync(new Lead
            (
                id: Guid.Parse("a5ae4f74-6247-4e7e-b969-642b544131b0"),
                firstName: "441b8b5290394b07bde5e146c2a915a7e267a5ef7fba4883b06cfd879c0552745925a9a5a55246e8b6c30ff734d4b60f3",
                lastName: "a38991a5610e40368ecf28e72e8d8d7119b7c05860b14dc8ac7fd1d2",
                userName: "1adf5fa0a15147",
                email: "441ed1dc15134753b5a1d186a3",
                contact: "11f70016fe8d4cdc83188f7a01cd5e84607d4e64763545b99f91e05d09333715fb260c37773442aba16763516c51",
                address: "0eba44c5e98b4d3f9173b2366675ec69",
                tenantName: "a78f02623c9945d1bd2b28957a1d60d7d177e56dca9b47f6b08361134",
                type: default
            ));

            await _leadRepository.InsertAsync(new Lead
            (
                id: Guid.Parse("c556d620-4b73-4637-9fa9-fb2109901df5"),
                firstName: "7b54bfaf08e7418a9fc281f606245cd3b538ac6ae9d",
                lastName: "6aac815000c44cd0952fe12211d77a5a76c142a9c1394e9c9fba6913a8c2755764d293d9732d44809",
                userName: "31b48f10e23d4a3b9cd74df8f9fa5589f40c03a512394147b22fe90032",
                email: "b6aac0b91df04093bddad",
                contact: "17ff4b2782a1492e902c15f742f21b6",
                address: "f7e86d74c8d74be4a089415a5346a144e357a45ab6834d16a41c8d",
                tenantName: "c8e159aaf08e46c480867c73e9257f20434cf91977f94d1ebd9bc9ffc533622ec6f6e1bffe564016bfd2e611f8bb4861",
                type: default
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}