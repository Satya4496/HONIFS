using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HONIFS.Data;

/* This is used if database provider does't define
 * IHONIFSDbSchemaMigrator implementation.
 */
public class NullHONIFSDbSchemaMigrator : IHONIFSDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
