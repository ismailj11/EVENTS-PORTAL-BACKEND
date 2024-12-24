using System;
using System.Collections.Generic;

namespace EP_DAL.Models;

public partial class Permission
{
    public int PermissionId { get; set; }

    public int FkRoleId { get; set; }

    public string PermissionName { get; set; } = null!;

    public virtual Role FkRole { get; set; } = null!;
}
