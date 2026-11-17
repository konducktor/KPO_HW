using HW2.Application;

namespace HW2.ConsoleUI;

public class ShowStudentScoresCommand(IConsoleIO console, GradebookFacade facade) : IMenuCommand
{
    public string Title { get; } = "Показать оценки студента";

    public void Run()
    {
        int studentId = console.ReadInt("Введите id студента", InputLimits.MinId, InputLimits.MaxId);

        IReadOnlyList<ScoreData> scores = facade.GetStudentScores(studentId);
        if (scores.Count == 0)
        {
            console.Print("У студента пока нет оценок");
            console.Print("");
            return;
        }
        
        console.Print("Оценки:");
        foreach (ScoreData score in scores)
            console.Print(FormatScore(score));
        console.Print("");
    }

    private static string FormatScore(ScoreData score)
    {
        string line = $"{score.CriterionName}: {score.Points} из {score.MaxScore} ({score.Date:dd.MM.yyyy HH:mm})";

        return string.IsNullOrWhiteSpace(score.Comment) ? line : $"{line}, комментарий: {score.Comment}";
    }
}
