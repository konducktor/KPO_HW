using HW2.Application;
using System.Globalization;
using System.Text;

namespace HW2.Infrastructure;

public class CsvExporter : FileWriteExporter
{
    public CsvExporter(string filePath) : base(filePath) {}

    protected override string Convert(ExportData data)
    {
        var output = new StringBuilder();
        output.AppendLine("Name,Surname,FinalScore");

        foreach (ExportStudentData student in data.ExportStudents)
        {
            string finalScore = student.FinalScore.ToString(CultureInfo.InvariantCulture);
            output.AppendLine($"{student.Name},{student.Surname},{finalScore}");
        }

        return output.ToString();
    }
}
