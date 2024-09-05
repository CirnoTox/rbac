using System;
using SqlSugar;

namespace rbac.Modals.Models;

[SugarTable("sys_role_model")]
public class RoleModel : ModelBaseId
{
    /// <summary>
    /// 角色Id
    /// </summary>
    public string? RoleId { get; set; }

    /// <summary>
    /// 菜单Id
    /// </summary>
    public string? MenuId { get; set; }
}
