public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Department { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    public Employee()
    {
	Age = -1;
	Email = "n/a";
    }

    public Employee(string name, double salary, string position, string department) : this()
    {
	Name = name;
	Department = department;
	Position = position;
	Salary = salary;
    }
 }
