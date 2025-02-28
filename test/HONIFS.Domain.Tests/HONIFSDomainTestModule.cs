using Volo.Abp.Modularity;

namespace HONIFS;

[DependsOn(
    typeof(HONIFSDomainModule),
    typeof(HONIFSTestBaseModule)
)]
public class HONIFSDomainTestModule : AbpModule
{

}
