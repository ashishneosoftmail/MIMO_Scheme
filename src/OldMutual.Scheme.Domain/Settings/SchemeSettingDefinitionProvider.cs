using Volo.Abp.Settings;

namespace OldMutual.Scheme.Settings;

public class SchemeSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SchemeSettings.MySetting1));
    }
}
