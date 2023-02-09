using Microsoft.Extensions.Configuration;

namespace PracticalExam3.Utilities
{
    internal static class Configurator
    {
        internal static IConfiguration Configuration { get; }

        static Configurator()
        {
            Configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "Resources", "appsettings.json"))
            .Build();
        }
    }
}
