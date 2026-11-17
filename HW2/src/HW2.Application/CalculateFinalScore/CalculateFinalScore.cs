using HW2.Domain;

namespace HW2.Application;

public class CalculateFinalScore
{
    private readonly IStudentRepository _studentRepository;
    private readonly IRubricatorRepository _rubricatorRepository;
    private readonly DomainService _domainService;

    public CalculateFinalScore(IStudentRepository studentRepository, 
                                    IRubricatorRepository rubricatorRepository,
                                    DomainService domainService)
    {
        _studentRepository = studentRepository;
        _rubricatorRepository = rubricatorRepository;
        _domainService = domainService;
    }

    public decimal Execute(StudentId studentId)
    {
        AcademicRecord record = _studentRepository.Get();
        Student student = record.GetStudentBy(studentId);
        Rubricator rubricator = _rubricatorRepository.Get();

        return _domainService.CalculateFinalScore(student.Review, rubricator);
    }
}