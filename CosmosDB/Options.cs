using CommandLine;

namespace CosmosDB
{
    public class Options
    {
        /// <summary>
        /// Uri do Azure Cosmo DB.
        /// </summary>
        [Option('e', "endpoint-uri", Required = true, HelpText = "Endereço do key vault na Azure.")]
        public string EndpointUri { get; set; }

        /// <summary>
        /// Chave de acesso do Azure Cosmo DB.
        /// </summary>
        [Option('k', "key-cosmodb", Required = true, HelpText = "Endereço do key vault na Azure.")]
        public string Key { get; set; }

        /// <summary>
        /// Nome da coleção a ser utilizada.
        /// </summary>
        [Option('c', "collection-name", Required = true, HelpText = "Endereço do key vault na Azure.")]
        public string CollectionName { get; set; }

        /// <summary>
        /// Nome do banco de dados no Cosmo DB.
        /// </summary>
        [Option('d', "database-name", Required = true, HelpText = "Endereço do key vault na Azure.")]
        public string DatabaseName { get; set; }
    }
}
