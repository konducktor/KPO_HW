using HW2.Domain;

namespace HW2.Application;

public class ExportFinalScores
{
    private readonly IStudentRepository _studentRepository;
    private readonly IRubricatorRepository _rubricatorRepository;
    private readonly DomainService _domainService;
    private readonly IFinalScoreExporter _exporter;

    public ExportFinalScores(IStudentRepository studentRepository, 
                            IRubricatorRepository rubricatorRepository,
                            DomainService domainService,
                            IFinalScoreExporter exporter)
    {
        _studentRepository = studentRepository;
        _rubricatorRepository = rubricatorRepository;
        _domainService = domainService;
        _exporter = exporter;
    }

    public void Execute()
    {
        Rubricator rubricator = _rubricatorRepository.Get();
        List<ExportStudentData> exportStudents = [];

        foreach (Student student in _studentRepository.Get().Students)
        {
            decimal score = _domainService.CalculateFinalScore(student.Review, rubricator);
            exportStudents.Add(new ExportStudentData(student.Name, student.Surname, score));
        }

        _exporter.Export(new ExportData(exportStudents));
    }
}