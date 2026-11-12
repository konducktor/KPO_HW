namespace HW2.Domain;

public class StudentReview
{
    public Dictionary<CriterionId, Score> Scores { get; }

    public StudentReview()
    {
        Scores = new();
    }

    public void AddScore(Score score)
    {
        Scores.Add(score.CriterionId, score);
    }
}