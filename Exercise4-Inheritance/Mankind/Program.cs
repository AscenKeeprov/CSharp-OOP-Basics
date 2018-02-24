using System;

public class Program
{
    static void Main()
    {
	try
	{
	    string[] studentInfo = Console.ReadLine().Split();
	    string[] workerInfo = Console.ReadLine().Split();
	    string studentFirstName = studentInfo[0];
	    string studentLastName = studentInfo[1];
	    string facultyNumber = studentInfo[2];
	    Student student = new Student(studentFirstName, studentLastName, facultyNumber);
	    string workerFirstName = workerInfo[0];
	    string workerLastName = workerInfo[1];
	    decimal weekSalary = decimal.Parse(workerInfo[2]);
	    double workHoursPerDay = double.Parse(workerInfo[3]);
	    Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, workHoursPerDay);
	    Console.WriteLine(student);
	    Console.Write(Environment.NewLine);
	    Console.WriteLine(worker);
	}
	catch (ArgumentException exception)
	{
	    Console.WriteLine(exception.Message);
	}
    }
}
