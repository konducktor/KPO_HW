using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddModel(this IServiceCollection services)
    {
        services.AddSingleton<IInventoryNumberGenerator, SequentialNumberGenerator>();
        services.AddSingleton<VehicleFactory>();
        services.AddSingleton<ItemFactory>();
        services.AddSingleton<Inventory>();
        
        services.AddSingleton<IInspectionService, ServiceCenter>();
        services.AddSingleton<VehiclePark>();
        
        return services;
    }

    public static IServiceCollection AddConsole(this IServiceCollection services)
    {
        services.AddSingleton<IConsoleIO, BasicConsoleIO>();
        services.AddSingleton<ItemFormatter>();

        services.AddSingleton<IMenuCommand, AddInventoryItem>();
        services.AddSingleton<IMenuCommand, PrintInventory>();
        services.AddSingleton<IMenuCommand, AddVehicleToPark>();
        services.AddSingleton<IMenuCommand, QuantityEnergyReport>();
        services.AddSingleton<IMenuCommand, VehiclesForNovices>();
        services.AddSingleton<IMenuCommand, AddDemonstrative>();
        services.AddSingleton<ConsoleApp>();
        
        return services;
    }
}