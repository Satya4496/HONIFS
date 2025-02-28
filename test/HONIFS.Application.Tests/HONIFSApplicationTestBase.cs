using Volo.Abp.Modularity;

namespace HONIFS;

public abstract class HONIFSApplicationTestBase<TStartupModule> : HONIFSTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
