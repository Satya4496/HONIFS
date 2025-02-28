using Volo.Abp.Modularity;

namespace HONIFS;

[DependsOn(
    typeof(HONIFSApplicationModule),
    typeof(HONIFSDomainTestModule)
)]
public class HONIFSApplicationTestModule : AbpModule
{

}
