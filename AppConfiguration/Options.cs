using CommandLine;

namespace AppConfiguration
{
    public class Options
    {
        [Option('c', "connection-string", Required = true, HelpText = "Connection string do Azure App Configuration.")]
        public string ConnectionString { get; set; }
    }
}
