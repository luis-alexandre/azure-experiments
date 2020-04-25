using CommandLine;
using CosmosDB.Model;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CosmosDB
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
            Program demo = new Program();
            demo.StartDemo(options).Wait();
        }

        private async Task StartDemo(Options options)
        {
            CosmoDbHelper helper = new CosmoDbHelper(options.Key, options.EndpointUri);

            Console.WriteLine($"Criando database {options.DatabaseName}");
            await helper.CreateDatabaseAsync(options.DatabaseName);

            Console.WriteLine($"Criando a coleção de documentos {options.CollectionName}");
            await helper.CreateDocumentCollectionAsync(options.CollectionName, options.DatabaseName);

            Console.WriteLine("Gerando e inserindo um novo documento na collection.");

            Person personOne = GenerateEntitySample("Person.1", "Paul", "Smith");
            await helper.CreateDocumentAsync<Person>(options.DatabaseName, options.CollectionName, personOne);

            Person personTwo = GenerateEntitySample("Person.2", "Carlos", "Santiago");
            await helper.CreateDocumentAsync<Person>(options.DatabaseName, options.CollectionName, personTwo);

            Console.WriteLine("Localizando documento dentro da coleção");
            var result = helper.GetDocuments<Person>(options.DatabaseName,
                                                     options.CollectionName,
                                                     x => x.FirstName.Equals("Paul"));

            Console.WriteLine(JsonConvert.SerializeObject(result));

            Console.WriteLine("Excluindo os documentos da coleção");
            await helper.DeleteDocumentAsync<Person>(options.DatabaseName,
                                                     options.CollectionName,
                                                     personTwo);

            await helper.DeleteDocumentAsync<Person>(options.DatabaseName,
                                                     options.CollectionName,
                                                     personOne);

            Console.WriteLine("Excluindo a base de dados");
            await helper.DeleteDatabaseAsync(options.DatabaseName);

            Console.WriteLine("Done!");
        }

        private static Person GenerateEntitySample(string id, string firstName, string lastName)
        {
            Person person = new Person
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Devices = new Device[]
                {
                    new Device { OperatingSystem = "iOS", CameraMegaPixels = 12, Ram = 32, Usage = "Work"},
                    new Device { OperatingSystem = "Windows", CameraMegaPixels = 12, Ram = 64, Usage = "Personal"}
                },
                Address = new Address
                {
                    City = "Laguna Beach",
                    Country = "United States",
                    PostalCode = "12345",
                    Street = "Main",
                    State = "CA"
                },
                IsRegistered = true
            };

            return person;
        }
    }
}
