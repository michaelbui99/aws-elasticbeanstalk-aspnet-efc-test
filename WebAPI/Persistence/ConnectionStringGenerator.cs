namespace WebAPI.Persistence;

public class ConnectionStringGenerator
{
    public static string GetConnectionStringFromEnvironment()
    {
        return
            $"Data Source= {Environment.GetEnvironmentVariable("RDS_HOSTNAME")},{Environment.GetEnvironmentVariable("RDS_PORT")};" +
            $"Initial Catalog= {Environment.GetEnvironmentVariable("RDS_DB_NAME")};" +
            $"User ID={Environment.GetEnvironmentVariable("RDS_USERNAME")};" +
            $"Password = {Environment.GetEnvironmentVariable("RDS_PASSWORD")}";
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