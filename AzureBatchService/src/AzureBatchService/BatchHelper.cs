using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Auth;
using Microsoft.Azure.Batch.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureBatchService
{
    public class BatchHelper : IDisposable
    {
        private BatchClient client;

        public BatchHelper(string batchAccountName, string batchAccountKey, string batchAccountUrl)
        {
            BatchSharedKeyCredentials  credentials = new BatchSharedKeyCredentials(batchAccountUrl,
                                                                                   batchAccountName,
                                                                                   batchAccountKey);
            client = CreateClient(credentials);
        }

        private BatchClient CreateClient(BatchSharedKeyCredentials credentials)
        {
            return BatchClient.Open(credentials);
        }


        /// <summary>
        /// Adiciona um novo pool de execução no Batch Account.
        /// </summary>
        /// <param name="poolId">Identificação do novo pool a ser criado.</param>
        /// <param name="appId">Aplicação associada ao pool que será criado.</param>
        /// <param name="appVersion">Versão da aplicação que será associada ao poll.</param>
        /// <returns></returns>
        public CloudPool CreatePool(string poolId, string appId, string appVersion)
        {
            ImageReference imageReference = new ImageReference(publisher: "MicrosoftWindowsServer",
                                                               offer: "WindowsServer",
                                                               sku: "2012-R2-Datacenter-smalldisk",
                                                               version: "latest");

            VirtualMachineConfiguration virtualMachine = new VirtualMachineConfiguration(imageReference: imageReference,
                                                                                         nodeAgentSkuId: "batch.node.windows amd64");

            CloudPool pool = client.PoolOperations.CreatePool(poolId: poolId,
                                                              targetDedicatedComputeNodes: 2,
                                                              virtualMachineSize: "STANDARD_A1",
                                                              virtualMachineConfiguration: virtualMachine);

            pool.ApplicationPackageReferences = new List<ApplicationPackageReference>
            {
                new ApplicationPackageReference
                {
                    ApplicationId = appId,
                    Version = appVersion
                }
            };

            pool.Commit();
            return pool;
        }

        /// <summary>
        /// Cria um novo job associado um pool previamente criado.
        /// </summary>
        public CloudJob CreateJob(CloudPool pool, string jobId)
        {
            CloudJob job = client.JobOperations.CreateJob();

            job.Id = jobId;
            job.PoolInformation = new PoolInformation
            {
                PoolId = pool.Id
            };

            job.Commit();

            return job;
        }

        /// <summary>
        /// Cria uma nova task.
        /// </summary>
        /// <param name="taskId">ID da task a ser criada.</param>
        /// <param name="appId">Aplicação que será excutada pela task.</param>
        /// <param name="appVersion">Versão da aplicação.</param>
        /// <param name="commandLine">Comando a ser executado.</param>
        public CloudTask CreateTask(string taskId, string appId, string appVersion, string commandLine)
        {
            CloudTask cloudTask = new CloudTask(taskId, commandLine)
            {
                ApplicationPackageReferences = new List<ApplicationPackageReference>
                {
                    new ApplicationPackageReference
                    {
                        ApplicationId = appId,
                        Version = appVersion
                    }
                }
            };

            return cloudTask;
        }

        /// <summary>
        /// Adiciona as tasks criadas no job.
        /// </summary>
        public void AddTaskToJob(CloudJob job, List<CloudTask> tasks)
        {
            client.JobOperations.AddTask(job.Id, tasks);
        }


        /// <summary>
        /// Obtém as tasks após a execução delas.
        /// </summary>
        public List<CloudTask> GetCompletedTasks(CloudJob job, int timeoutMinutes)
        {
            TimeSpan timeout = TimeSpan.FromMinutes(timeoutMinutes);

            IEnumerable<CloudTask> addedTasks = client.JobOperations.ListTasks(job.Id);
            
            client.Utilities.CreateTaskStateMonitor()
                            .WaitAll(addedTasks, 
                                     TaskState.Completed, 
                                     timeout);

            List<CloudTask> completedtasks = client.JobOperations.ListTasks(job.Id)
                                                                 .ToList();

            return completedtasks;
        }

        /// <summary>
        /// Remove um pool da batch account.
        /// </summary>
        public void DeletePool(CloudPool pool)
        {
            client.PoolOperations.DeletePool(pool.Id);
        }

        /// <summary>
        /// Finaliza a execução de um job.
        /// </summary>
        /// <param name="job"></param>
        public void TerminateJob(CloudJob job)
        {
            client.JobOperations.TerminateJob(job.Id);
        }

        public void Dispose()
        {
            if(client != null)
            {
                client.Dispose();
                client = null;
            }
        }
    }
}
