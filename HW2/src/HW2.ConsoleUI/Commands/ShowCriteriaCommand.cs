using HW2.Application;

namespace HW2.ConsoleUI;

public class ShowCriteriaCommand(IConsoleIO console, GradebookFacade facade) : IMenuCommand
{
    public string Title { get; } = "Показать критерии";

    public void Run()
    {
        IReadOnlyList<CriterionData> criteria = facade.GetCriteria();
        if (criteria.Count == 0)
        {
            console.Print("Критериев пока нет");
            console.Print("");
            return;
        }

        console.Print("Критерии:");
        foreach (CriterionData criterion in criteria)
            console.Print($"{criterion.Id}: {criterion.Name} (максимум {criterion.MaxScore}, вес {criterion.Weight})");
        console.Print("");
    }
}
