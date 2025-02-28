using System.Threading.Tasks;

namespace HONIFS.Data;

public interface IHONIFSDbSchemaMigrator
{
    Task MigrateAsync();
}
