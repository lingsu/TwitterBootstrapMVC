using System.ComponentModel;

namespace TwitterBootstrap3
{
    public enum ButtonStyle
    {
        [Description("btn-default")]
        Default,
        [Description("btn-primary")]
        Primary,
        [Description("btn-info")]
        Info,
        [Description("btn-success")]
        Success,
        [Description("btn-warning")]
        Warning,
        [Description("btn-danger")]
        Danger,
        [Description("btn-link")]
        Link,
        [Description("")]
        None
    }
}