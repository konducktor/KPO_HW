using HW2.Domain;

namespace HW2.Application;

public class CalculateCumulativeScore
{
    private readonly IStudentRepository _studentRepository;
    private readonly IRubricatorRepository _rubricatorRepository;
    private readonly DomainService _domainService;

    public CalculateCumulativeScore(IStudentRepository studentRepository, 
                                    IRubricatorRepository rubricatorRepository,
                                    DomainService domainService)
    {
        _studentRepository = studentRepository;
        _rubricatorRepository = rubricatorRepository;
        _domainService = domainService;
    }

    public decimal Execute(StudentId studentId)
    {
        Student student = _studentRepository.GetStudentBy(studentId);
        Rubricator rubricator = _rubricatorRepository.Get();

        return _domainService.CalculateCumulativeScore(student.Review, rubricator);
    }
}