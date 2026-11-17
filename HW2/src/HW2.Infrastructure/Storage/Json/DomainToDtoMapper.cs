using HW2.Domain;

namespace HW2.Infrastructure;

internal static class DomainToDtoMapper
{
    public static AcademicRecordDto MapAcademicRecord(AcademicRecord academicRecord)
    {
        List<StudentDto> students = academicRecord.Students.Select(MapStudent).ToList();

        return new AcademicRecordDto(students);
    }

    public static RubricatorDto MapRubricator(Rubricator rubricator)
    {
        List<CriterionDto> criteria = rubricator.Criteria.Values.Select(MapCriterion).ToList();

        return new RubricatorDto(criteria);
    }

    private static StudentDto MapStudent(Student student)
    {
        List<ScoreDto> scores = student.Review.Scores.Values.Select(MapScore).ToList();

        return new StudentDto(student.Id.Id, student.Name, student.Surname, scores);
    }

    private static ScoreDto MapScore(Score score)
    {
        return new ScoreDto(score.CriterionId.Id, score.Points.Value, score.Date, score.Comment);
    }

    private static CriterionDto MapCriterion(Criterion criterion)
    {
        return new CriterionDto(criterion.Id.Id, criterion.Name, criterion.MaxScore, criterion.Weight);
    }
}
