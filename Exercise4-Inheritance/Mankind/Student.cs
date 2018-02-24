using System;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private string facultyNumber;
    private const string FacultyNumberPattern = @"^[a-zA-Z0-9]{5,10}$";
    private const string InvalidFacultyNumber = "Invalid faculty number!";

    public string FacultyNumber
    {
	get { return facultyNumber; }
	protected set
	{
	    if (!Regex.IsMatch(value, FacultyNumberPattern))
		throw new ArgumentException(InvalidFacultyNumber);
	    facultyNumber = value;
	}
    }

    public Student(string firstName, string lastName, string facultyNumber)
	: base(firstName, lastName)
    {
	FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
	StringBuilder studentInfo = new StringBuilder();
	studentInfo.AppendLine(base.ToString());
	studentInfo.AppendLine($"Faculty number: {FacultyNumber}");
	return studentInfo.ToString().TrimEnd();
    }
}
