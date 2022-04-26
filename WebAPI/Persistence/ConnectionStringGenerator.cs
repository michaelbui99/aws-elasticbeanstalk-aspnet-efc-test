namespace WebAPI.Persistence;

public class ConnectionStringGenerator
{
    public static string GetConnectionString()
    {
        return
            $"Data Source= {DotNetEnv.Env.GetString("RDS_HOSTNAME")},{DotNetEnv.Env.GetString("RDS_PORT")};" +
            $"Initial Catalog= {DotNetEnv.Env.GetString("RDS_DB_NAME")};" +
            $"User ID={DotNetEnv.Env.GetString("RDS_USERNAME")};" +
            $"Password = {DotNetEnv.Env.GetString("RDS_PASSWORD")}";
    }
}