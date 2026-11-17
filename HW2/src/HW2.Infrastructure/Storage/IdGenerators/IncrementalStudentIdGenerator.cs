using HW2.Application;
using HW2.Domain;

namespace HW2.Infrastructure;

public class IncrementalStudentIdGenerator : IStudentIdGenerator
{
    private readonly LazyIncrementalCounter _counter;

    public IncrementalStudentIdGenerator(IStudentRepository studentRepository)
    {
        _counter = new LazyIncrementalCounter(() => FindMaxStudentId(studentRepository));
    }

    public StudentId Next()
    {
        return new StudentId(_counter.Next());
    }

    private static int FindMaxStudentId(IStudentRepository studentRepository)
    {
        return studentRepository.Get().Students
            .Select(student => student.Id.Id)
            .DefaultIfEmpty(0)
            .Max();
    }
}
