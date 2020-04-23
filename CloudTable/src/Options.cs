using CommandLine;

namespace CloudTableConsole
{
    public class Options
    {
        /// <summary>
        /// Connection string do Azure Table Storage.
        /// </summary>
        [Option('c', "connection-string", Required = true, HelpText = "Connection string do Azure Table Storage.")]
        public string StorageConnectionString { get; set; }

        /// <summary>
        /// Nome da tabela a ser manipulada no Cloud Table.
        /// </summary>
        [Option('t', "table-name", Required = true, HelpText = "Nome da tabela a ser manipulada no Azure Table Storage.")]
        public string TableName { get; set; }
    }
}
