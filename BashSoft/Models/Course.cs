using System;
using System.Collections.Generic;
using System.Linq;

public class Course
{
    private string name;
    internal const int NumberOfTasksPerExam = 5;
    internal const int MaxScorePerExamTask = 100;
    public Dictionary<string, int[]> ScoresByStudent { get; protected set; }

    public string Name
    {
	get { return name; }
	private set
	{
	    if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
		throw new InvalidValueException($"{GetType().Name} {nameof(name)}", null);
	    name = value;
	}
    }

    internal Course()
    {
	ScoresByStudent = new Dictionary<string, int[]>();
    }

    internal Course(string name) : this()
    {
	Name = name;
    }

    public Course(string name, string studentName, int[] scores) : this(name)
    {
	EnrollStudent(studentName);
	SetScoresForStudent(studentName, scores);
    }

    internal void EnrollStudent(string studentName)
    {
	if (ScoresByStudent.Any(s => s.Key == studentName))
	    throw new StudentAlreadyEnrolledInCourseException(studentName, Name);
	else ScoresByStudent.Add(studentName, new int[NumberOfTasksPerExam]);
    }

    internal void SetScoresForStudent(string studentName, int[] newScores)
    {
	if (!ScoresByStudent.ContainsKey(studentName))
	    throw new StudentNotEnrolledInCourseException(studentName, Name);
	else if (newScores.Length > NumberOfTasksPerExam)
	    throw new InvalidNumberOfScoresException(studentName, Name);
	else
	{
	    int[] oldScores = ScoresByStudent.First(s => s.Key == studentName).Value;
	    for (int s = 0; s < newScores.Length; s++)
	    {
		if (newScores[s] > oldScores[s]) oldScores[s] = newScores[s];
	    }
	}
    }

    internal double CalculateStudentGrade(string studentName)
    {
	int[] scores = ScoresByStudent.First(s => s.Key == studentName).Value;
	double grade = (scores.Average() / 100) * 4 + 2;
	return grade;
    }
}
