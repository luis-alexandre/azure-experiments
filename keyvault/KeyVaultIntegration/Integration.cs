using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;

namespace KeyVaultIntegration
{
    public class Integration
    {
        private Options _options;

        public Integration(Options options)
        {
            this._options = options;
        }

        /// <summary>
        /// Obtém um Key Value a partir de um Key especificado.
        /// </summary>
        /// <returns></returns>
        public string ObterKeyValue()
        {
            var vaultAddress = this._options.KeyVaultAddress;
            var secretName = this._options.SecretName;

            KeyVaultClient client = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetToken));

            var secret = client.GetSecretAsync(vaultAddress, secretName).GetAwaiter().GetResult();
            return secret.Value;
        }

        /// <summary>
        /// Realiza a autenticação da aplicação com o Azure AD.
        /// </summary>
        /// <returns>Token de autenticação</returns>
        private async Task<string> GetToken(string authority, string resource, string scope)
        {
            var clientId = this._options.ClientId;
            var clientSecret = this._options.ClientSecret;

            ClientCredential clientCredential = new ClientCredential(clientId, clientSecret);

            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);

            var result = await context.AcquireTokenAsync(resource, clientCredential);

            return result.AccessToken;
        }
    }
}
