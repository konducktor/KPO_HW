using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddModel();
services.AddConsole();

using var provider = services.BuildServiceProvider();
provider.GetRequiredService<ConsoleApp>().Run();