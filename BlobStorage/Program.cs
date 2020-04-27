using CommandLine;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlobStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                          .WithParsed<Options>(opts => RunApplication(opts).Wait());
        }

        private static async Task RunApplication(Options options)
        {
            CloudStorageHelper cloudStorageHelper = new CloudStorageHelper(options.ConnectionString);
            await cloudStorageHelper.CreateContainerAsync(options.ContainerName);

            Console.WriteLine($"Realizando o upload de arquivo: {options.FilePath}");
            await cloudStorageHelper.UploadFileAsync(options.FilePath);

            Console.WriteLine($"Realizando o download do arquivo: {options.FilePath}");
            var path = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            await cloudStorageHelper.DowloadFileAsync(path, Path.GetFileName(options.FilePath));

            Console.WriteLine($"Excluindo arquivo do blob storage: {options.FilePath}");
            await cloudStorageHelper.DeleteFileAsync(Path.GetFileName(options.FilePath));

            Console.WriteLine($"Excluindo container do azure blob storage: {options.ContainerName}");
            await cloudStorageHelper.DeleteContainerAsync();

            Console.WriteLine("Done!");
        }
    }
}
