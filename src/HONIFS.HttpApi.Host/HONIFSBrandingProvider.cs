using Microsoft.Extensions.Localization;
using HONIFS.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace HONIFS;

[Dependency(ReplaceServices = true)]
public class HONIFSBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<HONIFSResource> _localizer;

    public HONIFSBrandingProvider(IStringLocalizer<HONIFSResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
