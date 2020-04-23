using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudTableConsole
{
    public class TableUtils<T>
        where T : TableEntity
    {
        /// <summary>
        /// Insere uma nova entidade na tabela que está no Azure Table Storage.
        /// </summary>
        public async Task<T> InsertOrMergeEntityAsync(CloudTable table, T entity)
        {
            try
            {
                if (entity != null)
                {
                    TableOperation tableOperation = TableOperation.InsertOrMerge(entity);

                    TableResult result = await table.ExecuteAsync(tableOperation);
                    T insertedEntity = result.Result as T;

                    return insertedEntity;
                }
                else
                {
                    throw new ArgumentNullException("entity");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Insere uma coleção de entidades na tabela no Azure Table Storage.
        /// </summary>
        public async Task<TableBatchResult> BatchInsertOrMergeEntityAsync(CloudTable table, IList<T> entities)
        {
            try
            {
                if (entities != null)
                {
                    TableBatchOperation tableBatchOperation = new TableBatchOperation();

                    foreach (var item in entities)
                    {
                        tableBatchOperation.InsertOrMerge(item);
                    }

                    TableBatchResult tableBachResult = await table.ExecuteBatchAsync(tableBatchOperation);
                    return tableBachResult;
                }
                else
                {
                    throw new ArgumentNullException("entities");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Recupera uma nova entidade a partir de uma partition key e uma row key.
        /// </summary>
        public async Task<T> RetrieveEntityUsingPointQueryAsync(CloudTable table, string partitionKey, string rowKey)
        {
            try
            {
                TableOperation tableOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
                TableResult tableResult = await table.ExecuteAsync(tableOperation);

                T entity = tableResult.Result as T;

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Exclui a entidade do tipo <paramref name="deleteEntity"/> do Azure Table Storage.
        /// </summary>
        public async Task DeleteEntityAsync(CloudTable table, T deleteEntity)
        {
            try
            {
                if (deleteEntity != null)
                {
                    TableOperation tableOperation = TableOperation.Delete(deleteEntity);
                    TableResult result = await table.ExecuteAsync(tableOperation);
                }
                else
                {
                    throw new ArgumentNullException("entity");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
