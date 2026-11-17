using HW2.Domain;

namespace HW2.Infrastructure;

internal static class DtoToDomainMapper
{
    public static Rubricator MapRubricator(RubricatorDto rubricatorDto)
    {
        var rubricator = new Rubricator();

        foreach (CriterionDto criterionDto in rubricatorDto.Criteria)
            rubricator.Add(MapCriterion(criterionDto));

        return rubricator;
    }

    public static AcademicRecord MapAcademicRecord(AcademicRecordDto academicRecordDto, Rubricator rubricator)
    {
        var academicRecord = new AcademicRecord();

        foreach (StudentDto studentDto in academicRecordDto.Students)
            academicRecord.AddStudent(MapStudent(studentDto, rubricator));

        return academicRecord;
    }

    private static Criterion MapCriterion(CriterionDto criterionDto)
    {
        return new Criterion(
            new CriterionId(criterionDto.Id),
            criterionDto.Name,
            criterionDto.MaxScore,
            criterionDto.Weight
        );
    }

    private static Student MapStudent(StudentDto studentDto, Rubricator rubricator)
    {
        var student = new Student(new StudentId(studentDto.Id), studentDto.Name, studentDto.Surname);

        foreach (ScoreDto scoreDto in studentDto.Scores)
        {
            student.Review.AddScore(
                rubricator,
                new CriterionId(scoreDto.CriterionId),
                new Points(scoreDto.Points),
                scoreDto.Date,
                scoreDto.Comment
            );
        }

        return student;
    }
}
