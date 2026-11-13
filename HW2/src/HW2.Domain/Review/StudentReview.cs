using System.Collections.ObjectModel;

namespace HW2.Domain;

public class StudentReview
{
    private Dictionary<CriterionId, Score> _scores;

    public ReadOnlyDictionary<CriterionId, Score> Scores { get; }

    public StudentReview()
    {
        _scores = new();
        Scores = _scores.AsReadOnly();
    }

    public void AddScore(Rubricator rubricator, CriterionId id, Points points,
                         DateTime date, string comment = "")
    {
        ArgumentNullException.ThrowIfNull(rubricator);

        if (!rubricator.Criteria.TryGetValue(id, out Criterion? criterion))
            throw new InvalidOperationException($"Критерия {id} нет в рубрикаторе");

        _scores[id] = new Score(criterion, points, date, comment);
    }

    // Я тут перенёс логику Dictionary.Remove, может кому-нибудь сверху пригодится
    public bool RemoveScore(CriterionId criterionId)
    {
        return _scores.Remove(criterionId);
    }
}