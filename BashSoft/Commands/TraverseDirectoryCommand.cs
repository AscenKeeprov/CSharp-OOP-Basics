public class TraverseDirectoryCommand : Command
{
    internal override int MaxAllowedParameters => 2;

    public TraverseDirectoryCommand(string[] parameters) : base(parameters) { }

    public override void Execute()
    {
	Validate(Parameters);
	if (Parameters.Length == 2)
	{
	    if (int.TryParse(Parameters[1], out int depth))
		FSManager.TraverseDirectory(depth);
	    else throw new InvalidCommandParameterException("Directory traversal depth");
	}
	else FSManager.TraverseDirectory(0);
    }
}
