using Microsoft.Extensions.Configuration;

namespace MonkeyFinder.Api.Config
{
    public class AppConfig : IAppConfig
    {
        private string _connectionString;
        public static AppConfig Instance;

        public static IConfiguration Configuration { get; set; }

        private AppConfig()
        {

        }

        static AppConfig()
        {
            Instance = new AppConfig();
        }

        public string ConnectionString => _connectionString ??= Configuration.GetConnectionString("MonkeyFinderConnection");
    }
}
