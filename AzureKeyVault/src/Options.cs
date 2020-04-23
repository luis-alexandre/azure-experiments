using CommandLine;

namespace KeyVaultIntegration
{
    public class Options
    {
        /// <summary>
        /// Endereço do key vault na Azure.
        /// </summary>
        [Option('k', "key-vault-address", Required = true, HelpText = "Endereço do key vault na Azure.")]
        public string KeyVaultAddress { get; set; }

        /// <summary>
        /// Nome do secret que deseja recuperar do key vault.
        /// </summary>
        [Option('s', "secret-name", Required = true, HelpText = "Nome do secret que deseja recuperar do key vault.")]
        public string SecretName { get; set; }

        /// <summary>
        /// Client Id da aplicação registrada no Azure AD.
        /// </summary>
        [Option('c', "client-id", Required = true, HelpText = "Client Id da aplicação registrada no Azure AD.")]
        public string ClientId { get; set; }

        /// <summary>
        /// Client Secret da aplicação registrada no Azure AD.
        /// </summary>
        [Option('p', "client-secret", Required = true, HelpText = "Client secret da aplicação registrada no Azure AD.")]
        public string ClientSecret { get; set; }
    }
}
