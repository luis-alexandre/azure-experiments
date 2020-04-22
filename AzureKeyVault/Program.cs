using CommandLine;
using System;

namespace KeyVaultIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(opts => RunApplication(opts));
        }

        private static void RunApplication(Options options)
        {
            Console.WriteLine("Obtendo Key Value a partir do Azure Key Vault");

            Integration integration = new Integration(options);

            string value = integration.ObterKeyValue();
            Console.WriteLine(value);
        }
    }
}
