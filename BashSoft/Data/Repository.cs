using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public static class Repository         /* ENABLES DATA PERSISTENCE AND RETRIEVAL */
{
    internal static List<Course> Courses = new List<Course>();
    internal static List<Student> Students = new List<Student>();
    private static bool IsDatabaseInitialized = false;
    private const string dbRecordPattern = @"^(?<Course>[A-Z]\#?\+{0,2}[a-zA-Z]*_[A-Z][a-z]{2}_201[4-8])\s+(?<Student>(?:[A-Z][a-z]+){2,}\d{2}_\d{2,4})\s+(?<Scores>(?:100\s?|[1-9][0-9]\s?|[0-9]\s?){1,5})$";

    internal static void LoadData(string path)
    {
	var dbInitFeedback = new DatabaseInitializationFeedback();
	if (!IsDatabaseInitialized)
	{
	    string fileName = IOManager.ExtractFileName(path);
	    path = IOManager.BuildAbsolutePath(path);
	    IOManager.OutputLine(typeof(Feedback), dbInitFeedback.BeginMessage);
	    string[] databaseSource = FSManager.ReadFile($"{path}\\{fileName}");
	    if (databaseSource.Length == 0) throw new DatabaseSourceEmptyException();
	    IOManager.OutputLine(typeof(Feedback), dbInitFeedback.ProgressMessage);
	    foreach (string record in databaseSource.Where(r => IsRecordValid(r)))
	    {
		try
		{
		    Match validRecord = Regex.Match(record, dbRecordPattern);
		    Course course = new Course(validRecord.Groups["Course"].Value);
		    Student student = new Student(validRecord.Groups["Student"].Value);
		    int[] scores = validRecord.Groups["Scores"].Value.Split().Select(int.Parse).ToArray();
		    if (!Courses.Any(c => c.Name == course.Name)) Courses.Add(course);
		    else course = Courses.First(c => c.Name == course.Name);
		    if (!Students.Any(s => s.Name == student.Name)) Students.Add(student);
		    else student = Students.First(s => s.Name == student.Name);
		    course.EnrollStudent(student.Name);
		    course.SetScoresForStudent(student.Name, scores);
		    student.EnrollInCourse(course.Name);
		    student.SetScoresForCourse(course.Name, scores);
		}
		catch (Exception exception)
		{
		    if (exception is DirectoryNotFoundException || exception is FileNotFoundException)
			IOManager.OutputLine(typeof(Exception), new InvalidPathException().Message);
		    else if (exception is UnauthorizedAccessException)
			IOManager.OutputLine(typeof(Exception), new InsufficientPrivilegesException().Message);
		}
	    }
	    IOManager.OutputLine(typeof(Feedback), dbInitFeedback.EndMessage);
	    IOManager.OutputLine(typeof(Feedback), String.Format(
		dbInitFeedback.ResultMessage, Students.Count));
	    IsDatabaseInitialized = true;
	}
	else
	{
	    IOManager.Output(typeof(Exception), new DatabaseAlreadyInitializedException().Message);
	    ConsoleKeyInfo choice = Console.ReadKey();
	    IOManager.OutputLine();
	    if (choice.Key == ConsoleKey.Y) DeleteData();
	    else IOManager.OutputLine(typeof(Feedback), dbInitFeedback.AbortMessage);
	}
    }

    private static bool IsRecordValid(string record)
    {
	return !String.IsNullOrEmpty(record) && Regex.IsMatch(record, dbRecordPattern);
    }

    internal static void ReadData(string courseName, string studentName, string filter, string order)
    {
	if (IsDatabaseInitialized)
	{
	    if (IsQueryValid(courseName, studentName, filter, order))
	    {
		Filter sifter = new Filter();
		List<Course> coursesToShow = sifter.FilterCourses(Courses, courseName);
		if (HasZeroRecords(coursesToShow)) return;
		List<Student> studentsToShow = sifter.FilterScores(coursesToShow, filter);
		if (HasZeroRecords(studentsToShow)) return;
		studentsToShow = sifter.FilterStudents(studentsToShow, studentName);
		if (HasZeroRecords(studentsToShow)) return;
		var report = PrepareDatabaseReport(studentsToShow);
		Sorter sorter = new Sorter();
		report = sorter.OrderReport(report, order);
		report = sifter.FilterStudents(report, studentName);
		if (HasZeroRecords(report)) return;
		IOManager.PrintDatabaseReport(report);
	    }
	}
	else throw new DatabaseNotInitializedException();
    }

    private static bool IsQueryValid(string courseName, string studentName, string filter, string order)
    {
	if (!Courses.Any(c => c.Name == courseName) && !courseName.ToUpper().Equals("ANY"))
	    throw new InvalidCommandParameterException("Course criterion");
	if (!Students.Any(s => s.Name == studentName) && !studentName.ToUpper().Equals("ALL") &&
	    !int.TryParse(studentName, out int number))
	    throw new InvalidCommandParameterException("Student criterion");
	if (!Enum.IsDefined(typeof(EFilter), filter))
	    throw new InvalidCommandParameterException("Report filter");
	if (!Enum.IsDefined(typeof(EOrder), order))
	    throw new InvalidCommandParameterException("Report order");
	return true;
    }

    private static bool HasZeroRecords<T>(ICollection<T> collection)
    {
	if (collection.Count > 0) return false;
	IOManager.OutputLine(typeof(Feedback), String.Format(
	    new DatabaseReportingFeedback().ProgressMessage, "No"));
	return true;
    }

    private static bool HasZeroRecords<T, Array>(Dictionary<T, Dictionary<T, Array>> collection)
    {
	if (collection.Values.All(v => v.Count > 0)) return false;
	IOManager.OutputLine(typeof(Feedback), String.Format(
	    new DatabaseReportingFeedback().ProgressMessage, "No"));
	return true;
    }

    private static Dictionary<string, Dictionary<string, int[]>> PrepareDatabaseReport(
	List<Student> studentsToShow)
    {
	IOManager.OutputLine(typeof(Feedback), new DatabaseReportingFeedback().BeginMessage);
	var report = new Dictionary<string, Dictionary<string, int[]>>();
	foreach (Student student in studentsToShow)
	{
	    foreach (var course in student.ScoresByCourse)
	    {
		int[] studentScores = course.Value;
		if (!report.ContainsKey(course.Key))
		    report.Add(course.Key, new Dictionary<string, int[]>());
		if (!report[course.Key].ContainsKey(student.Name))
		    report[course.Key].Add(student.Name, new int[Course.NumberOfTasksPerExam]);
		report[course.Key][student.Name] = studentScores;
	    }
	}
	return report;
    }

    internal static void DeleteData()
    {
	var dbDeletionFeedback = new DatabaseDeletionFeedback();
	IOManager.OutputLine(typeof(Feedback), dbDeletionFeedback.BeginMessage);
	Courses.Clear();
	Students.Clear();
	IsDatabaseInitialized = false;
	IOManager.OutputLine(typeof(Feedback), dbDeletionFeedback.EndMessage);
	IOManager.OutputLine(typeof(Feedback), dbDeletionFeedback.Message);
    }
}
