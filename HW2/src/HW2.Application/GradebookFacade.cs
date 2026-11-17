using HW2.Domain;

namespace HW2.Application;

public class GradebookFacade
{
    private readonly AddStudent _addStudent;
    private readonly CreateNewCriterion _createNewCriterion;
    private readonly GradeStudent _gradeStudent;
    private readonly DeleteScore _deleteScore;
    private readonly CalculateFinalScore _calculateFinalScore;
    private readonly ExportFinalScores _exportFinalScores;
    private readonly ListStudents _listStudents;
    private readonly ListCriteria _listCriteria;
    private readonly GetStudentScores _getStudentScores;

    public GradebookFacade(AddStudent addStudent,
                           CreateNewCriterion createNewCriterion,
                           GradeStudent gradeStudent,
                           DeleteScore deleteScore,
                           CalculateFinalScore calculateFinalScore,
                           ExportFinalScores exportFinalScores,
                           ListStudents listStudents,
                           ListCriteria listCriteria,
                           GetStudentScores getStudentScores)
    {
        _addStudent = addStudent;
        _createNewCriterion = createNewCriterion;
        _gradeStudent = gradeStudent;
        _deleteScore = deleteScore;
        _calculateFinalScore = calculateFinalScore;
        _exportFinalScores = exportFinalScores;
        _listStudents = listStudents;
        _listCriteria = listCriteria;
        _getStudentScores = getStudentScores;
    }

    public int AddStudent(string name, string surname)
    {
        return _addStudent.Execute(name, surname).Id;
    }

    public int CreateCriterion(string name, decimal maxScore, decimal weight)
    {
        return _createNewCriterion.Execute(name, maxScore, weight).Id;
    }

    public void GradeStudent(int studentId, int criterionId, decimal points)
    {
        _gradeStudent.Execute(new StudentId(studentId), new CriterionId(criterionId), new Points(points));
    }

    public void DeleteScore(int studentId, int criterionId)
    {
        _deleteScore.Execute(new StudentId(studentId), new CriterionId(criterionId));
    }

    public decimal CalculateFinalScore(int studentId)
    {
        return _calculateFinalScore.Execute(new StudentId(studentId));
    }

    public void ExportFinalScores()
    {
        _exportFinalScores.Execute();
    }

    public IReadOnlyList<StudentData> GetStudents()
    {
        return _listStudents.Execute();
    }

    public IReadOnlyList<CriterionData> GetCriteria()
    {
        return _listCriteria.Execute();
    }

    public IReadOnlyList<ScoreData> GetStudentScores(int studentId)
    {
        return _getStudentScores.Execute(new StudentId(studentId));
    }
}
