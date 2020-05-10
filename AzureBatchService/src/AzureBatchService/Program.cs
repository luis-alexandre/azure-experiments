using CommandLine;
using Microsoft.Azure.Batch;
using System;
using System.Collections.Generic;

namespace AzureBatchService
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                          .WithParsed<Options>(opts => RunApplication(opts));
        }


        private static void RunApplication(Options options)
        {
            string poolId = "batchpool";
            string jobId = "batchjob";
            string appId = "MathApplication";
            string appVersion = "1.0";
            string appPath = $"%AZ_BATCH_APP_PACKAGE_{appId}#{appVersion}%";

            using (BatchHelper helper = new BatchHelper(options.BatchAccountName,
                                                        options.BatchAccountKey,
                                                        options.BatchAccountUrl))
            {
                var pool = helper.CreatePool(poolId, appId, appVersion);

                var job = helper.CreateJob(pool, jobId);

                string taskId = $"Task1";
                string taskCommandLine = $"cmd /c {appPath}\\MathApplication.exe 100";
                var taskOne = helper.CreateTask(taskId, appId, appVersion, taskCommandLine);

                taskId = $"Task2";
                taskCommandLine = $"cmd /c {appPath}\\MathApplication.exe 500";
                var taskTwo = helper.CreateTask(taskId, appId, appVersion, taskCommandLine);

                helper.AddTaskToJob(job, new List<CloudTask>
                {
                    taskOne,
                    taskTwo
                });

                var completedTasks = helper.GetCompletedTasks(job, 30);

                foreach (var item in completedTasks)
                {
                    string output = item.GetNodeFile(Constants.StandardOutFileName).ReadAsString();

                    if (!string.IsNullOrEmpty(output))
                    {
                        Console.WriteLine(output);
                    }

                    string outputError = item.GetNodeFile(Constants.StandardErrorFileName).ReadAsString();

                    if (!string.IsNullOrEmpty(outputError))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(output);
                        Console.ResetColor();
                    }
                }

                helper.DeletePool(pool);
                helper.TerminateJob(job);
            }
        }
    }
}
