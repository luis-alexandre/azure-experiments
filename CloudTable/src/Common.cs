using Microsoft.Azure.Cosmos.Table;
using System;
using System.Threading.Tasks;

namespace CloudTableConsole
{
    public class Common
    {
        /// <summary>
        /// Gera um novo storage account a partir de uma connection string.
        /// </summary>
        /// <returns></returns>
        public CloudStorageAccount CreateStorageAccount(string connectionString)
        {
            CloudStorageAccount cloudStorageAccount;

            try
            {
                cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            }
            catch (Exception)
            {

                throw;
            }

            return cloudStorageAccount;
        }

        /// <summary>
        /// Gera uma nova tabela para ser utilizada na Cloud Table.
        /// </summary>
        public async Task<CloudTable> CreateTableAsync(Options options)
        {
            CloudStorageAccount storageAccount = CreateStorageAccount(options.StorageConnectionString);

            CloudTableClient cloudTableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            CloudTable cloudTable = cloudTableClient.GetTableReference(options.TableName);

            if (await cloudTable.CreateIfNotExistsAsync())
            {
                Console.WriteLine($"Table {options.TableName} created.");
            }
            else
            {
                Console.WriteLine($"Table {options.TableName} already exists.");
            }

            return cloudTable;
        }
    }
}
