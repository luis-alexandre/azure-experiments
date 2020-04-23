using CloudTableConsole.Model;
using CommandLine;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudTableConsole
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
            Common common = new Common();
            CloudTable table = Task.Run(async () => await common.CreateTableAsync(options))
                                   .GetAwaiter()
                                   .GetResult();

            try
            {
                Task.Run(async () => await ExecuteOperations(table))
                    .Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("************************");
                Console.WriteLine(ex.Message);
                Console.WriteLine("************************");
            }
        }

        private static async Task ExecuteOperations(CloudTable table)
        {
            PersonEntity person = new PersonEntity("Rodrigues", "Luis")
            {
                Email = "luis.rodrigues@contoso.com",
                PhoneNumber = "55 22 9999-0000"
            };

            Console.WriteLine($"Inserindo entidade: {person.PartitionKey}, {person.RowKey} ...");

            TableUtils<PersonEntity> tableUtils = new TableUtils<PersonEntity>();
            person = await tableUtils.InsertOrMergeEntityAsync(table, person);

            Console.WriteLine("Atualizando a entidade...");
            
            person.PhoneNumber = "123-555-0105";
            await tableUtils.InsertOrMergeEntityAsync(table, person);
            
            Console.WriteLine("Inserindo uma coleção de entidades (batch mode)...");

            var people = new List<PersonEntity>();

            person = new PersonEntity("Silva", "Jose")
            {
                Email = "jose.silva@contoso.com",
                PhoneNumber = "55 22 9999-0001"
            };
            people.Add(person);

            person = new PersonEntity("Silva", "Joao")
            {
                Email = "joao.silva@contoso.com",
                PhoneNumber = "55 22 9999-0002"
            };
            people.Add(person);

            await tableUtils.BatchInsertOrMergeEntityAsync(table, people);

            Console.WriteLine("Obtendo entidade...");

            person = await tableUtils.RetrieveEntityUsingPointQueryAsync(table, "Rodrigues", "Luis");

            if (person != null)
            {
                Console.WriteLine("Excluindo entidade recebida... ");
                await tableUtils.DeleteEntityAsync(table, person);
            }

            Console.WriteLine("Done!");
        }
    }
}
