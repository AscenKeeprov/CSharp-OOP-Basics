public class CreateDirectoryCommand : Command
{
    internal override int MinRequiredParameters => 2;
    internal override int MaxAllowedParameters => 2;

    public CreateDirectoryCommand(string[] parameters) : base(parameters) { }

    public override void Execute()
    {
	Validate(Parameters);
	string path = Parameters[1];
	FSManager.CreateDirectory(path);
    }
}
