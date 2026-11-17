using HW2.ConsoleUI;
using HW2.Host;
using Microsoft.Extensions.DependencyInjection;

StorageKind storageKind;
try
{
    storageKind = StartupArguments.ParseStorageKind(args);
}
catch (ArgumentException exception)
{
    Console.Error.WriteLine(exception.Message);
    return 1;
}

var providerOptions = new ServiceProviderOptions { ValidateOnBuild = true, ValidateScopes = true };

using ServiceProvider serviceProvider = new ServiceCollection()
    .AddDomain()
    .AddApplication()
    .AddStorage(storageKind)
    .AddIdGenerators()
    .AddCsvExporter("final-scores.csv")
    .AddConsoleUi()
    .BuildServiceProvider(providerOptions);

serviceProvider.GetRequiredService<ConsoleApp>().Run();

return 0;
