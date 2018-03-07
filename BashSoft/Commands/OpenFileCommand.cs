public class OpenFileCommand : Command
{
    internal override int MinRequiredParameters => 2;
    internal override int MaxAllowedParameters => 2;

    public OpenFileCommand(string[] parameters) : base (parameters) { }

    public override void Execute()
    {
	Validate(Parameters);
	string path = Parameters[1];
	var fileReadingFeedback = new FileReadingFeedback();
	IOManager.OutputLine(typeof(Feedback), fileReadingFeedback.BeginMessage);
	string[] fileContents = FSManager.ReadFile(path);
	if (fileContents != null)
	    IOManager.OutputLine(typeof(Feedback), fileReadingFeedback.ProgressMessage);
	if (fileContents.Length > 0)
	{
	    IOManager.OutputLine(typeof(Feedback), fileReadingFeedback.ResultMessage);
	    IOManager.DisplayFileContents(fileContents);
	}
	else IOManager.OutputLine(typeof(Feedback), fileReadingFeedback.EndMessage);
    }
}
