using System;
using System.Text;

public class Human
{
    private string firstName;
    private const int MinFirstNameLength = 4;
    private string lastName;
    private const int MinLastNameLength = 3;
    private const string NameMissingCapitalLetter = "Expected upper case letter! Argument: {0}";
    private const string InvalidNameLength = "Expected length at least {0} symbols! Argument: {1}";

    public string FirstName
    {
	get { return firstName; }
	protected set
	{
	    if (Char.IsLower(value[0]))
		throw new ArgumentException(String.Format(
		    NameMissingCapitalLetter, nameof(firstName)));
	    if (value.Length < MinFirstNameLength)
		throw new ArgumentException(String.Format(
		    InvalidNameLength, MinFirstNameLength, nameof(firstName)));
	    firstName = value;
	}
    }

    public string LastName
    {
	get { return lastName; }
	protected set
	{
	    if (Char.IsLower(value[0]))
		throw new ArgumentException(String.Format(
		    NameMissingCapitalLetter, nameof(lastName)));
	    if (value.Length < MinLastNameLength)
		throw new ArgumentException(String.Format(
		    InvalidNameLength, MinLastNameLength, nameof(lastName)));
	    lastName = value;
	}
    }

    public Human(string firstName, string lastName)
    {
	FirstName = firstName;
	LastName = lastName;
    }

    public override string ToString()
    {
	StringBuilder humanInfo = new StringBuilder();
	humanInfo.AppendLine($"First Name: {FirstName}");
	humanInfo.AppendLine($"Last Name: {LastName}");
	return humanInfo.ToString().TrimEnd();
    }
}
