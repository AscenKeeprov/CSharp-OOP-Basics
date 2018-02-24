using System;
using System.Text;

public class Worker : Human
{
    private decimal weekSalary;
    private const int MinWeekSalary = 10;
    private double workHoursPerDay;
    private const int MinWorkHoursPerDay = 1;
    private const int MaxWorkHoursPerDay = 12;
    private const string InvalidValue = "Expected value mismatch! Argument: {0}";
    private const int WorkDaysPerWeek = 5;
    public decimal EarningsPerHour => WeekSalary / (decimal)(WorkDaysPerWeek * WorkHoursPerDay);

    public decimal WeekSalary
    {
	get { return weekSalary; }
	protected set
	{
	    if (value <= MinWeekSalary) throw new ArgumentException(
		String.Format(InvalidValue, nameof(weekSalary)));
	    weekSalary = value;
	}
    }

    public double WorkHoursPerDay
    {
	get { return workHoursPerDay; }
	protected set
	{
	    if (value < MinWorkHoursPerDay || value > MaxWorkHoursPerDay)
		throw new ArgumentException(String.Format(InvalidValue, nameof(workHoursPerDay)));
	    workHoursPerDay = value;
	}
    }

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
	: base(firstName, lastName)
    {
	WeekSalary = weekSalary;
	WorkHoursPerDay = workHoursPerDay;
    }

    public override string ToString()
    {
	StringBuilder workerInfo = new StringBuilder();
	workerInfo.AppendLine(base.ToString());
	workerInfo.AppendLine($"Week Salary: {WeekSalary:F2}");
	workerInfo.AppendLine($"Hours per day: {WorkHoursPerDay:F2}");
	workerInfo.AppendLine($"Salary per hour: {EarningsPerHour:F2}");
	return workerInfo.ToString().TrimEnd();
    }
}
