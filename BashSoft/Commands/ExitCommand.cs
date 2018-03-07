using System;
using System.Threading;

public class ExitCommand : Command
{
    internal override int MaxAllowedParameters => 1;

    public ExitCommand(string[] parameters) : base(parameters) { }

    public override void Execute()
    {
	Validate(Parameters);
	IOManager.OutputLine(typeof(Feedback), new ProgramExitingFeedback().Message);
	IOManager.OutputLine();
	Thread.Sleep(4000);
	UserInterface.Unload();
	Environment.Exit(0);
    }
}
