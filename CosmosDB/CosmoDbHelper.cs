using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDB
{
    /// <summary>
    /// Auxilia nas operações no Cosmo DB.
    /// </summary>
    public class CosmoDbHelper
    {
        private readonly DocumentClient documentClient;

        public CosmoDbHelper(string key, string endpointUri)
        {
            this.documentClient = new DocumentClient(new Uri(endpointUri), key);
        }

        /// <summary>
        /// Cria uma nova base de dados.
        /// </summary>
        public async Task CreateDatabaseAsync(string databaseName)
        {
            await this.documentClient.CreateDatabaseIfNotExistsAsync(new Database
            {
                Id = databaseName
            });
        }

        /// <summary>
        /// Exclui uma base de dados.
        /// </summary>
        public async Task DeleteDatabaseAsync(string databaseName)
        {
            Uri databaseUri = UriFactory.CreateDatabaseUri(databaseName);
            await this.documentClient.DeleteDatabaseAsync(databaseUri);
        }

        /// <summary>
        /// Cria uma nova coleção de documentos.
        /// </summary>
        public async Task CreateDocumentCollectionAsync(string collectionName, string databaseName)
        {
            DocumentCollection documentCollection = new DocumentCollection
            {
                Id = collectionName
            };

            Uri databaseUri = UriFactory.CreateDatabaseUri(databaseName);

            await this.documentClient.CreateDocumentCollectionIfNotExistsAsync(databaseUri, documentCollection);
        }

        /// <summary>
        /// Cria um novo documento em uma coleção específica.
        /// </summary>
        public async Task CreateDocumentAsync<Entity>(string databaseName, string collectionName, Entity document)
            where Entity : Model.EntityBase
        {
            try
            {
                Uri documentUri = UriFactory.CreateDocumentUri(databaseName, collectionName, document.Id);
                await this.documentClient.ReadDocumentAsync(documentUri);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    Uri collectionUri = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);
                    await this.documentClient.CreateDocumentAsync(collectionUri, document);
                }
            }
        }

        /// <summary>
        /// Obtém um conjunto de documentos a partir de uma condição informada.
        /// </summary>
        public IList<Entity> GetDocuments<Entity>(string databaseName, 
                                                  string collectionName,
                                                  Expression<Func<Entity, bool>> predicate,
                                                  int maxItemCount = -1)
            where Entity : Model.EntityBase
        {
            FeedOptions queryOptions = new FeedOptions
            {
                MaxItemCount = maxItemCount
            };

            Uri documentCollectionUri = UriFactory.CreateDocumentCollectionUri(databaseName, collectionName);

            IQueryable<Entity> documentQuery = this.documentClient
                                                   .CreateDocumentQuery<Entity>(documentCollectionUri, queryOptions)
                                                   .Where(predicate);

            return documentQuery.ToList();
        }

        /// <summary>
        /// Atualiza um documento.
        /// </summary>
        public async Task UpdateDocumentAsync<Entity>(string databaseName,
                                                      string collectionName,
                                                      Entity document)
            where Entity : Model.EntityBase
        {
            Uri documentUri = UriFactory.CreateDocumentUri(databaseName, collectionName, document.Id);
            await this.documentClient.ReplaceDocumentAsync(documentUri, document);
        }

        /// <summary>
        /// Exclui um documento da coleção.
        /// </summary>
        public async Task DeleteDocumentAsync<Entity>(string databaseName, string collectionName, Entity document)
            where Entity : Model.EntityBase
        {
            Uri documentUri = UriFactory.CreateDocumentUri(databaseName, collectionName, document.Id);
            await this.documentClient.DeleteDocumentAsync(documentUri);
        }
    }
}
