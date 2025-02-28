using Volo.Abp.Modularity;

namespace HONIFS;

/* Inherit from this class for your domain layer tests. */
public abstract class HONIFSDomainTestBase<TStartupModule> : HONIFSTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
