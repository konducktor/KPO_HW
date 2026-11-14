using HW2.Domain;

namespace HW2.Application;

public class DeleteScore
{
    private readonly IStudentRepository _studentRepository;

    public DeleteScore(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public void Execute(StudentId studentId, CriterionId criterionId)
    {
        Student student = _studentRepository.GetStudentBy(studentId);
        
        student.Review.RemoveScore(criterionId);

        _studentRepository.Save(student);
    }
}