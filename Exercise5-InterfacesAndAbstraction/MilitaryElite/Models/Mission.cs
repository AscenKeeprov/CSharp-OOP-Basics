using System;
using System.Linq;

public class Mission : Task, IMission
{
    private string state;
    private string[] validStates = { "inProgress", "Finished" };

    public string State
    {
	get { return state; }
	set
	{
	    if (!validStates.Contains(value))
		throw new ArgumentException("Invalid mission state!");
	    state = value;
	}
    }

    public Mission(string codeName, string state) : base(codeName)
    {
	State = state;
    }

    public override string ToString()
    {
	return $"Code {base.ToString()} State: {State}";
    }
}
