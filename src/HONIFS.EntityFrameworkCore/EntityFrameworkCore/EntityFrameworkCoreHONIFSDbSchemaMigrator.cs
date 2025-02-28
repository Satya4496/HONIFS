using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HONIFS.Data;
using Volo.Abp.DependencyInjection;

namespace HONIFS.EntityFrameworkCore;

public class EntityFrameworkCoreHONIFSDbSchemaMigrator
    : IHONIFSDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreHONIFSDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the HONIFSDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<HONIFSDbContext>()
            .Database
            .MigrateAsync();
    }
}
