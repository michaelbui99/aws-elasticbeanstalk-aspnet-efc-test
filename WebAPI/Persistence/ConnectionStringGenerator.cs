using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace WebAPI.Persistence;

public class ConnectionStringGenerator
{
    public static string? GetConnectionStringFromEnvironment()
    {
        var appConfig = ConfigurationManager.AppSettings;

        var dbName = appConfig["RDS_DB_NAME"];
        if (string.IsNullOrEmpty(dbName))
        {
            return null;
        }
        var username = appConfig["RDS_USERNAME"];
        var password = appConfig["RDS_PASSWORD"];
        var hostname = appConfig["RDS_HOSTNAME"];
        var port = appConfig["RDS_PORT"];

        return
            $"Data Source= {hostname},{port};" +
            $"Initial Catalog= {dbName};" +
            $"User ID={username};" +
            $"Password = {password}";
    }

    public static string GetConnectionStringFromDotEnv()
    {
        return
            $"Data Source= {DotNetEnv.Env.GetString("RDS_HOSTNAME")},{DotNetEnv.Env.GetString("RDS_PORT")};" +
            $"Initial Catalog= {DotNetEnv.Env.GetString("RDS_DB_NAME")};" +
            $"User ID={DotNetEnv.Env.GetString("RDS_USERNAME")};" +
            $"Password = {DotNetEnv.Env.GetString("RDS_PASSWORD")}";
    }
}