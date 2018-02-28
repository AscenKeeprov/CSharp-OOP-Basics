public class Repair : Task, IRepair
{
    public int HoursWorked { get; set; }

    public Repair(string partName, int hoursWorked) : base(partName)
    {
	HoursWorked = hoursWorked;
    }

    public override string ToString()
    {
	return $"Part {base.ToString()} Hours Worked: {HoursWorked}";
    }
}
