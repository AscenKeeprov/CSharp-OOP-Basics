using System;

public class HelpCommand : Command
{
    internal override int MaxAllowedParameters => 1;

    public HelpCommand(string[] parameters) : base(parameters) { }

    public override void Execute()
    {
	Validate(Parameters);
	Console.Clear();
	string[] helpText = FSManager.ReadFile("resources/help.txt");
	foreach (string line in helpText)
	{
	    IOManager.OutputLine(typeof(String), line);
	}
    }
}
