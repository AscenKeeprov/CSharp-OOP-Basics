public class ReadDatabaseCommand : Command
{
    internal override int MinRequiredParameters => 3;
    internal override int MaxAllowedParameters => 5;

    public ReadDatabaseCommand(string[] parameters) : base(parameters) { }

    public override void Execute()
    {
	Validate(Parameters);
	string course = Parameters[1];
	string student = Parameters[2];
	string filter = "OFF";
	string order = "ALPHABETICAL";
	if (Parameters.Length == 4)
	{
	    if (Parameters[3].Length <= 9 && !Parameters[3].ToUpper().Equals("ASCENDING"))
		filter = Parameters[3].ToUpper();
	    else order = Parameters[3].ToUpper();
	}
	if (Parameters.Length == 5)
	{
	    if (Parameters[3].Length <= 9 && !Parameters[3].ToUpper().Equals("ASCENDING"))
	    {
		filter = Parameters[3].ToUpper();
		order = Parameters[4].ToUpper();
	    }
	    else
	    {
		filter = Parameters[4].ToUpper();
		order = Parameters[3].ToUpper();
	    }
	}
	Repository.ReadData(course, student, filter, order);
    }
}
