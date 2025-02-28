using Volo.Abp.Settings;

namespace HONIFS.Settings;

public class HONIFSSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(HONIFSSettings.MySetting1));
    }
}
