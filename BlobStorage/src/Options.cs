using CommandLine;

namespace BlobStorage
{
    public class Options
    {
        /// <summary>
        /// Connection string para o Azure Storage.
        /// </summary>
        [Option('c', "connection-string", Required = true, HelpText = "Connection string do Azure Storage Account.")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Nome do container a ser criado no Azure Blob Storage
        /// </summary>
        [Option('n', "container-name", Required = true, HelpText = "Nome do container a ser criado no Azure Blob Storage.")]
        public string ContainerName { get; set; }

        /// <summary>
        /// Arquivo a ser armazenado no Azure Blob Storage.
        /// </summary>
        [Option('f', "file", Required = true, HelpText = "Arquivo a ser armazenado no Azure Blob Storage.")]
        public string FilePath { get; set; }
    }
}
