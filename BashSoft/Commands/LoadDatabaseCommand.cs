public class LoadDatabaseCommand : Command
{
    internal override int MinRequiredParameters => 2;
    internal override int MaxAllowedParameters => 2;

    public LoadDatabaseCommand(string[] parameters) : base(parameters) { }

    public override void Execute()
    {
	Validate(Parameters);
	string path = Parameters[1];
	Repository.LoadData(path);
    }
}
