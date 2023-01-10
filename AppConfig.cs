using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public static class AppConfig{
    static IConfiguration Config {
        get {
            string baseDir = System.AppContext.BaseDirectory.Remove(System.AppContext.BaseDirectory.IndexOf(@"\bin"));
            string[] args = Environment.GetCommandLineArgs();
            switch(Environment.GetCommandLineArgs()[1]){
                case "prod":
                    baseDir += "\\appsettings.prod.json";
                    break;
                case "test":
                    baseDir+="\\appsettings.test.json";
                    break;
                default:
                    baseDir += "\\appsettings.json";
                    break;
            }
            return new ConfigurationBuilder().AddJsonFile(baseDir).Build();

        }
    } 

    public static string EncryptionKey {
        get{
            return Config["EncryptionKey"];
        }
    }

    static string DataSource {
        get{
            return Config.GetSection("DbConnectionConfig")["DataSource"];
        }
    }

    static string InitialCatalog {
        get{
            return Config.GetSection("DbConnectionConfig")["InitialCatalog"];
        }
    }

    static string UserId {
        get{
            return Config.GetSection("DbConnectionConfig")["UserId"];
        }
    }

    static string Password {
        get{
            return Config.GetSection("DbConnectionConfig")["Password"];
        }
    }

    public static string ImportUserId{
        get{
            return Config["ImportUserId"];
        }
    }

    public static string ImportErrorLog{
        get{
            return Location+Config["ImportFileName"];
        }
    }

    public static string Location {
        get{
            return Config["Location"];
        }
    }

    public static List<AccessDatabase> AccessDataSources{
        get{
            IEnumerable<IConfigurationSection> configurationSections=Config.GetSection("AccessDataSources").GetSection("Databases").GetChildren();
            
            List<AccessDatabase> dataSources = new List<AccessDatabase>();
            configurationSections.ToList().ForEach(s =>
            {
                dataSources.Add(new AccessDatabase(s["Name"], s["Location"]));
            });
            return dataSources;
        }
    }

    public static SqlConnection SqlConnection {
        get {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataSource;
            builder.InitialCatalog = InitialCatalog;
            builder.UserID = UserId;
            builder.Password = Password;
            return new SqlConnection(builder.ConnectionString);
        }
    }
}