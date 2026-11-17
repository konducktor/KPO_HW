namespace HW2.Application;

public record ScoreData(
    int CriterionId,
    string CriterionName,
    decimal MaxScore,
    decimal Points,
    DateTime Date,
    string Comment
);
