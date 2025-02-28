﻿using Volo.Abp.Reflection;

namespace OldMutual.Scheme.Permissions;

public static class SchemePermissions
{
    public const string GroupName = "SchemePermission";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public static class Inbound_Mimo_Customers
    {
        public const string Default = GroupName + ".Inbound_Mimo_Customer";
        //public const string Delete = Default + ".Delete";
        //public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";

    }
    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SchemePermissions));
    }
}
