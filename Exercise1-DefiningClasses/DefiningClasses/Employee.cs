public class Employee
{
    private string name;

    public string Name
    {
	get { return name; }
	set { name = value; }
    }

    private int age;

    public int Age
    {
	get { return age; }
	set { age = value; }
    }

    private string position;

    public string Position
    {
	get { return position; }
	set { position = value; }
    }

    private decimal salary;

    public decimal Salary
    {
	get { return salary; }
	set { salary = value; }
    }

    private string email;

    public string Email
    {
	get { return email; }
	set { email = value; }
    }

    public Employee()
    {
	Age = -1;
	Email = "n/a";
    }
    public Employee(string name, string position, decimal salary) : this()
    {
	Name = name;
	Position = position;
	Salary = salary;
    }
}
