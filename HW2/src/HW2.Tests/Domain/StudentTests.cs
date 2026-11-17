using HW2.Domain;

namespace HW2.Tests;

public class StudentTests
{
    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void Student_BlankName_Throws(string name)
    {
        Assert.Throws<InvalidDataException>(() => new Student(new StudentId(1), name, "Иванов"));
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void Student_BlankSurname_Throws(string surname)
    {
        Assert.Throws<InvalidDataException>(() => new Student(new StudentId(1), "Иван", surname));
    }

    [Fact]
    public void Student_NewStudent_HasEmptyReview()
    {
        Assert.Empty(TestData.Student().Review.Scores);
    }
}
