public class ChangeDirectoryCommand : Command
{
    internal override int MinRequiredParameters => 2;
    internal override int MaxAllowedParameters => 2;

    public ChangeDirectoryCommand(string[] parameters) : base(parameters) { }

    public override void Execute()
    {
	Validate(Parameters);
	string destinationPath = Parameters[1];
	FSManager.ChangeDirectory(destinationPath);
    }
}
