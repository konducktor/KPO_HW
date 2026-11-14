namespace HW2.Application;

public class ImportAcademicRecord
{
    private readonly IStudentRepository _studentRepository;

    public ImportAcademicRecord(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public void Execute()
    {
        
    }
}
