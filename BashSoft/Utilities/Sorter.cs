using System.Collections.Generic;
using System.Linq;

public class Sorter      /* APPLIES SORTING TO DATABASE REPORTS */
{
    internal Dictionary<string, Dictionary<string, int[]>> OrderReport(
	Dictionary<string, Dictionary<string, int[]>> report, string order)
    {
	var orderedReport = new Dictionary<string, Dictionary<string, int[]>>();
	foreach (var course in report.OrderBy(course => course.Key))
	{
	    var scoresByStudent = OrderStudents(course.Value, order);
	    orderedReport.Add(course.Key, scoresByStudent);
	}
	return orderedReport;
    }

    internal Dictionary<string, int[]> OrderStudents(
	Dictionary<string, int[]> scoresByStudent, string order)
    {
	if (order.Equals("ALPHABETICAL"))
	{
	    scoresByStudent = scoresByStudent.OrderBy(student => student.Key)
		.ToDictionary(student => student.Key, scores => scores.Value);
	}
	else if (order.Equals("ASCENDING"))
	{
	    scoresByStudent = scoresByStudent.OrderBy(scores => scores.Value.Sum())
		.ToDictionary(student => student.Key, scores => scores.Value);
	}
	else if (order.Equals("DESCENDING"))
	{
	    scoresByStudent = scoresByStudent.OrderByDescending(scores => scores.Value.Sum())
		.ToDictionary(student => student.Key, scores => scores.Value);
	}
	return scoresByStudent;
    }
}
