using HW2.Domain;

namespace HW2.Tests;

public class AcademicRecordTests
{
    [Fact]
    public void AddStudent_DuplicateId_Throws()
    {
        var record = new AcademicRecord();
        record.AddStudent(TestData.Student(id: 1));

        Assert.Throws<InvalidOperationException>(
            () => record.AddStudent(TestData.Student(id: 1, name: "Пётр", surname: "Петров"))
        );
    }

    [Fact]
    public void AddStudent_Null_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => new AcademicRecord().AddStudent(null!));
    }

    [Fact]
    public void GetStudentBy_ExistingId_ReturnsStudent()
    {
        var record = new AcademicRecord();
        Student student = TestData.Student(id: 7);
        record.AddStudent(student);

        Assert.Same(student, record.GetStudentBy(new StudentId(7)));
    }

    [Fact]
    public void GetStudentBy_MissingId_Throws()
    {
        Assert.Throws<KeyNotFoundException>(() => new AcademicRecord().GetStudentBy(new StudentId(1)));
    }

    [Fact]
    public void Students_CannotBeModifiedFromOutside()
        => Assert.False(new AcademicRecord().Students is List<Student>);
}
