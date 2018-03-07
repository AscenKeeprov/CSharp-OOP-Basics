using System;
using System.Collections.Generic;
using System.Linq;

public class Filter    /* APPLIES FILTERING TO DATABASE REPORTS */
{
    internal List<Course> FilterCourses(List<Course> Courses, string courseName)
    {
	List<Course> coursesToShow;
	if (!courseName.ToUpper().Equals("ANY"))
	    coursesToShow = Courses.Where(c => c.Name == courseName).ToList();
	else coursesToShow = Courses.ToList();
	return coursesToShow;
    }

    internal List<Student> FilterScores(List<Course> coursesToShow, string filter)
    {
	List<Student> studentsToShow = new List<Student>();
	if (!filter.Equals("OFF"))
	{
	    double minGrade = 2.00;
	    double maxGrade = 6.01;
	    if (filter.Equals("EXCELLENT")) minGrade = 5.00;
	    else if (filter.Equals("AVERAGE"))
	    {
		minGrade = 3.50;
		maxGrade = 5.00;
	    }
	    else if (filter.Equals("POOR")) maxGrade = 3.50;
	    foreach (Course course in coursesToShow)
	    {
		foreach (var studentScores in course.ScoresByStudent)
		{
		    string studentName = studentScores.Key;
		    double studentGrade = course.CalculateStudentGrade(studentName);
		    if (studentGrade >= minGrade && studentGrade < maxGrade)
		    {
			Student student = new Student(studentName);
			if (!studentsToShow.Any(s => s.Name == studentName))
			    studentsToShow.Add(student);
			else student = studentsToShow.First(s => s.Name == studentName);
			student.ScoresByCourse.Add(course.Name, studentScores.Value);
		    }
		}
	    }
	}
	else
	{
	    foreach (Course course in coursesToShow)
	    {
		foreach (var studentScores in course.ScoresByStudent)
		{
		    string studentName = studentScores.Key;
		    Student student = new Student(studentName);
		    if (!studentsToShow.Any(s => s.Name == studentName))
			studentsToShow.Add(student);
		    else student = studentsToShow.First(s => s.Name == studentName);
		    student.ScoresByCourse.Add(course.Name, studentScores.Value);
		}
	    }
	}
	return studentsToShow;
    }

    internal List<Student> FilterStudents(List<Student> studentsToShow, string studentName)
    {
	if (!studentName.ToUpper().Equals("ALL") && !int.TryParse(studentName, out int number))
	    studentsToShow = studentsToShow.Where(s => s.Name == studentName).ToList();
	return studentsToShow;
    }

    internal Dictionary<string, Dictionary<string, int[]>> FilterStudents(
	Dictionary<string, Dictionary<string, int[]>> report, string studentName)
    {
	if (!studentName.ToUpper().Equals("ALL"))
	{
	    var filteredReport = new Dictionary<string, Dictionary<string, int[]>>();
	    if (int.TryParse(studentName, out int studentsToTake))
	    {
		foreach (var course in report)
		{
		    var scoresByStudent = course.Value;
		    int numberOfStudents = Math.Min(scoresByStudent.Count, studentsToTake);
		    scoresByStudent = scoresByStudent.Take(numberOfStudents)
			.ToDictionary(student => student.Key, scores => scores.Value);
		    filteredReport.Add(course.Key, scoresByStudent);
		}
	    }
	    else
	    {
		foreach (var course in report)
		{
		    var scoresByStudent = course.Value;
		    scoresByStudent = scoresByStudent.Where(student => student.Key == studentName)
			.ToDictionary(student => student.Key, scores => scores.Value);
		    if (scoresByStudent.Keys.Count > 0)
			filteredReport.Add(course.Key, scoresByStudent);
		}
	    }
	    return filteredReport;
	}
	return report;
    }
}
