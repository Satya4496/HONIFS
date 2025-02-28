using HONIFS.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace HONIFS.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HONIFSEntityFrameworkCoreModule),
    typeof(HONIFSApplicationContractsModule)
)]
public class HONIFSDbMigratorModule : AbpModule
{
}
