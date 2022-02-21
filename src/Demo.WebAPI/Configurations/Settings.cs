using System.Reflection;

namespace Demo.WebAPI.Configurations;

public static class Settings
{
    public const string LOG_PATH_DEFAULT = "/logs/.log";

    public static readonly string SERVICE_NAME = Assembly.GetEntryAssembly()?.GetName()?.Name;
}
