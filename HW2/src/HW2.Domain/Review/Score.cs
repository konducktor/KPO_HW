namespace HW2.Domain;

public class Score
{
    public CriterionId CriterionId { get; }
    public Points Points { get; private set; }
    public DateTime Date { get; }
    public string Comment { get; }

    public Score(Criterion criterion, Points points, DateTime date, string comment = "")
    {
        CriterionId = criterion.Id;

        criterion.EnsureAccept(points);   
        Points = points;
        
        Date = date;
        Comment = comment;
    }
}