public class Private : Soldier, IPrivate
{
    public double Salary { get; set; }

    public Private(int id, string firstName, string lastName, double salary)
	: base(id, firstName, lastName)
    {
	Salary = salary;
    }

    public override string ToString()
    {
	return $"{base.ToString()} Salary: {Salary:F2}";
    }
}
