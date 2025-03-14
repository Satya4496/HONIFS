using HONIFS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace HONIFS.Permissions;

public class HONIFSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HONIFSPermissions.GroupName);

        myGroup.AddPermission(HONIFSPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        myGroup.AddPermission(HONIFSPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(HONIFSPermissions.MyPermission1, L("Permission:MyPermission1"));

        var leadPermission = myGroup.AddPermission(HONIFSPermissions.Leads.Default, L("Permission:Leads"));
        leadPermission.AddChild(HONIFSPermissions.Leads.Create, L("Permission:Create"));
        leadPermission.AddChild(HONIFSPermissions.Leads.Edit, L("Permission:Edit"));
        leadPermission.AddChild(HONIFSPermissions.Leads.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HONIFSResource>(name);
    }
}