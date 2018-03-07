using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private string name;
    public Dictionary<string, int[]> ScoresByCourse { get; protected set; }

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

    internal Student()
    {
	ScoresByCourse = new Dictionary<string, int[]>();
    }

    internal Student(string name) : this()
    {
	Name = name;
    }

    internal Student(string name, string courseName, int[] scores) : this(name)
    {
	EnrollInCourse(courseName);
	SetScoresForCourse(courseName, scores);
    }

    internal void EnrollInCourse(string courseName)
    {
	if (ScoresByCourse.ContainsKey(courseName))
	    throw new StudentAlreadyEnrolledInCourseException(Name, courseName);
	else ScoresByCourse.Add(courseName, new int[Course.NumberOfTasksPerExam]);
    }

    internal void SetScoresForCourse(string courseName, int[] newScores)
    {
	if (!ScoresByCourse.ContainsKey(courseName))
	    throw new StudentNotEnrolledInCourseException(Name, courseName);
	else if (newScores.Length > Course.NumberOfTasksPerExam)
	    throw new InvalidNumberOfScoresException(Name, courseName);
	else
	{
	    int[] oldScores = ScoresByCourse.First(c => c.Key == courseName).Value;
	    for (int s = 0; s < newScores.Length; s++)
	    {
		if (newScores[s] > oldScores[s]) oldScores[s] = newScores[s];
	    }
	}
    }

    internal double CalculateGrade(string courseName)
    {
	int[] scores = ScoresByCourse.First(c => c.Key == courseName).Value;
	double grade = (scores.Average() / 100) * 4 + 2;
	return grade;
    }
}
