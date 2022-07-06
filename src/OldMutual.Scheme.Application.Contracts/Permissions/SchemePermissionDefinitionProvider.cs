using OldMutual.Scheme.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace OldMutual.Scheme.Permissions;

public class SchemePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var productManagementGroup = context.AddGroup(SchemePermissions.GroupName, L("Permission:Scheme"));
        var products = productManagementGroup.AddPermission(SchemePermissions.Inbound_Mimo_Customers.Default, L("Permission:Inbound_Mimo_Customer"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SchemePermissions.MyPermission1, L("Permission:MyPermission1"));
        products.AddChild(SchemePermissions.Inbound_Mimo_Customers.Create, L("Permission:Create"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SchemeResource>(name);
    }
}
