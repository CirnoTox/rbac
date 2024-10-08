using System;
using System.ComponentModel;

namespace rbac.Modals.Enum;
[Description("系统菜单枚举")]
public enum MenuTypeEnum
{
    /// <summary>
    /// 目录
    /// </summary>
    [Description("目录")]
    Dir=1,

    /// <summary>
    /// 菜单
    /// </summary>
    [Description("菜单")]
    Menu=2,

    /// <summary>
    /// 按钮
    /// </summary>
    [Description("按钮")]
    Btn=3
}
