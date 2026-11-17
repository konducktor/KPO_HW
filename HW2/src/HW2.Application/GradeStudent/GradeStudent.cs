using HW2.Domain;

namespace HW2.Application;

public class GradeStudent
{
    private readonly IStudentRepository _studentRepository;
    private readonly IRubricatorRepository _rubricatorRepository;

    public GradeStudent(IStudentRepository studentRepository, 
                        IRubricatorRepository rubricatorRepository)
    {
        _studentRepository = studentRepository;
        _rubricatorRepository = rubricatorRepository;
    }

    public void Execute(StudentId studentId, CriterionId criterionId, Points points)
    {
        Rubricator rubricator = _rubricatorRepository.Get();
        AcademicRecord record = _studentRepository.Get();
        Student student = record.GetStudentBy(studentId);
        
        student.Review.AddScore(rubricator, criterionId, points, DateTime.Now);
        _studentRepository.Save(record);
    }
}
