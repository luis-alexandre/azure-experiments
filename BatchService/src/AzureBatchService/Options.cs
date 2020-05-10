using CommandLine;

namespace AzureBatchService
{
    public class Options
    {
        [Option('c', "account-name", Required = true, HelpText = "Batch Account Name.")]
        public string BatchAccountName { get; set; }

        [Option('k', "account-key", Required = true, HelpText = "Batch Account Key.")]
        public string BatchAccountKey { get; set; }

        [Option('u', "account-url", Required = true, HelpText = "Batch Account Url.")]
        public string BatchAccountUrl { get; set; }
    }
}
