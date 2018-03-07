public class DownloadFileCommand : Command
{
    internal override int MinRequiredParameters => 2;
    internal override int MaxAllowedParameters => 2;

    public DownloadFileCommand(string[] parameters) : base(parameters) { }

    public override void Execute()
    {
	Validate(Parameters);
	string sourcePath = Parameters[1];
	FSManager.DownloadFile(sourcePath);
    }
}
