public class CompareFilesCommand : Command
{
    internal override int MinRequiredParameters => 3;
    internal override int MaxAllowedParameters => 3;

    public CompareFilesCommand(string[] parameters) : base(parameters) { }

    public override void Execute()
    {
	Validate(Parameters);
	string file1 = Parameters[1];
	string file2 = Parameters[2];
	Tester tester = new Tester();
	tester.CompareFiles(file1, file2);
    }
}
