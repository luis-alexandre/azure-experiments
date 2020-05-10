using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlobStorage
{
    public class CloudStorageHelper
    {
        private readonly string _connectionString;

        private CloudStorageAccount cloudStorageAccount;
        private CloudBlobClient cloudBlobClient;

        private CloudBlobContainer container;

        public CloudStorageHelper(string connectionSting)
        {
            this._connectionString = connectionSting;
            Initialiaze();
        }

        private void Initialiaze()
        {
            cloudStorageAccount = CloudStorageAccount.Parse(this._connectionString);
            cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
        }

        private void SetContainerReference(string containerName)
        {
            if(container == null)
            {
                container = cloudBlobClient.GetContainerReference(containerName);
            }
        }

        private void IsContainerReferenceValid()
        {
            if (container == null)
            {
                throw new InvalidOperationException("Container reference does not exist.");
            }
        }

        /// <summary>
        /// Gera um novo container no Azure Blob Storage se ele não existir.
        /// </summary>
        public async Task<bool> CreateContainerAsync(string containerName)
        {
            SetContainerReference(containerName.ToLower());
            return await container.CreateIfNotExistsAsync();
        }

        /// <summary>
        /// Upload um arquivo no Azure Blob Storage.
        /// </summary>
        public async Task UploadFileAsync(string filePath)
        {
            IsContainerReferenceValid();

            if (!File.Exists(filePath))
            {
                throw new ArgumentException("File was not found.");
            }

            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(Path.GetFileName(filePath));
            await cloudBlockBlob.UploadFromFileAsync(filePath);
        }

        /// <summary>
        /// Download o arquivo do Azure Blob Storage.
        /// </summary>
        public async Task DowloadFileAsync(string path, string fileName)
        {
            IsContainerReferenceValid();

            if (!Directory.Exists(path))
            {
                throw new ArgumentException("Path was not found.");
            }

            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(fileName);
            await cloudBlockBlob.DownloadToFileAsync(path, FileMode.Create);
        }

        /// <summary>
        /// Exclui o arquivo do Azure Blob Storage.
        /// </summary>
        public async Task DeleteFileAsync(string fileName)
        {
            IsContainerReferenceValid();

            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(fileName);
            await cloudBlockBlob.DeleteIfExistsAsync();
        }

        /// <summary>
        /// Exclui o container do Azure Blob Storage.
        /// </summary>
        public async Task DeleteContainerAsync()
        {
            IsContainerReferenceValid();
            await container.DeleteIfExistsAsync();
        }
    }
}
