using HW2.Application;
using HW2.ConsoleUI;
using HW2.Domain;
using HW2.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace HW2.Host;

public static class ServiceCollectionExtensions
{
    private const string JsonDataDirectory = "data";

    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddSingleton<StudentFactory>();
        services.AddSingleton<CriterionFactory>();
        services.AddSingleton<DomainService>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<AddStudent>();
        services.AddTransient<CreateNewCriterion>();
        services.AddTransient<GradeStudent>();
        services.AddTransient<DeleteScore>();
        services.AddTransient<CalculateFinalScore>();
        services.AddTransient<ExportFinalScores>();
        services.AddTransient<ListStudents>();
        services.AddTransient<ListCriteria>();
        services.AddTransient<GetStudentScores>();
        services.AddTransient<GradebookFacade>();

        return services;
    }

    public static IServiceCollection AddStorage(this IServiceCollection services, StorageKind storageKind)
    {
        return storageKind switch
        {
            StorageKind.InMemory => services.AddInMemoryStorage(),
            StorageKind.Json => services.AddJsonStorage(JsonDataDirectory),
            _ => throw new ArgumentOutOfRangeException(nameof(storageKind), storageKind, null)
        };
    }

    public static IServiceCollection AddInMemoryStorage(this IServiceCollection services)
    {
        services.AddSingleton<IStudentRepository, InMemoryStudentRepository>();
        services.AddSingleton<IRubricatorRepository, InMemoryRubricatorRepository>();

        return services;
    }

    public static IServiceCollection AddJsonStorage(this IServiceCollection services, string dataDirectory)
    {
        string rubricatorFilePath = Path.Combine(dataDirectory, "rubricator.json");
        string studentsFilePath = Path.Combine(dataDirectory, "students.json");

        services.AddSingleton<IRubricatorRepository>(_ => new JsonRubricatorRepository(rubricatorFilePath));
        services.AddSingleton<IStudentRepository>(provider => new JsonStudentRepository(
            studentsFilePath,
            provider.GetRequiredService<IRubricatorRepository>()
        ));

        return services;
    }

    public static IServiceCollection AddIdGenerators(this IServiceCollection services)
    {
        services.AddSingleton<IStudentIdGenerator, IncrementalStudentIdGenerator>();
        services.AddSingleton<ICriterionIdGenerator, IncrementalCriterionIdGenerator>();

        return services;
    }

    public static IServiceCollection AddCsvExporter(this IServiceCollection services, string filePath)
    {
        services.AddSingleton<IFinalScoreExporter>(_ => new CsvExporter(filePath));

        return services;
    }

    public static IServiceCollection AddConsoleUi(this IServiceCollection services)
    {
        services.AddSingleton<IConsoleIO, BasicConsoleIO>();

        services.AddSingleton<IMenuCommand, AddStudentCommand>();
        services.AddSingleton<IMenuCommand, CreateCriterionCommand>();
        services.AddSingleton<IMenuCommand, GradeStudentCommand>();
        services.AddSingleton<IMenuCommand, DeleteScoreCommand>();
        services.AddSingleton<IMenuCommand, ShowStudentsCommand>();
        services.AddSingleton<IMenuCommand, ShowCriteriaCommand>();
        services.AddSingleton<IMenuCommand, ShowStudentScoresCommand>();
        services.AddSingleton<IMenuCommand, CalculateFinalScoreCommand>();
        services.AddSingleton<IMenuCommand, ExportFinalScoresCommand>();
        services.AddSingleton<ConsoleApp>();

        return services;
    }
}
