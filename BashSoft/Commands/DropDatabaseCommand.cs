public class DropDatabaseCommand : Command
{
    internal override int MaxAllowedParameters => 1;

    public DropDatabaseCommand(string[] parameters) : base(parameters) { }

    public override void Execute()
    {
	Validate(Parameters);
	Repository.DeleteData();
    }
}
