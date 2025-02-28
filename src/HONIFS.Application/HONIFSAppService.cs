using HONIFS.Localization;
using Volo.Abp.Application.Services;

namespace HONIFS;

/* Inherit your application services from this class.
 */
public abstract class HONIFSAppService : ApplicationService
{
    protected HONIFSAppService()
    {
        LocalizationResource = typeof(HONIFSResource);
    }
}
