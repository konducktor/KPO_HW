using HW2.Domain;

namespace HW2.Application;

public class GetStudentScores
{
    private readonly IStudentRepository _studentRepository;
    private readonly IRubricatorRepository _rubricatorRepository;

    public GetStudentScores(IStudentRepository studentRepository,
                            IRubricatorRepository rubricatorRepository)
    {
        _studentRepository = studentRepository;
        _rubricatorRepository = rubricatorRepository;
    }

    public IReadOnlyList<ScoreData> Execute(StudentId studentId)
    {
        Student student = _studentRepository.Get().GetStudentBy(studentId);
        Rubricator rubricator = _rubricatorRepository.Get();

        return student.Review.Scores.Values
            .Select(score => MapScore(score, rubricator.Criteria[score.CriterionId]))
            .ToList();
    }

    private static ScoreData MapScore(Score score, Criterion criterion)
    {
        return new ScoreData(
            criterion.Id.Id,
            criterion.Name,
            criterion.MaxScore,
            score.Points.Value,
            score.Date,
            score.Comment
        );
    }
}
