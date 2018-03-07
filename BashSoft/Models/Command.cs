public abstract class Command : IExecutable
{
    private string[] parameters;
    internal virtual int MinRequiredParameters => 1;
    internal virtual int MaxAllowedParameters => 5;

    protected string[] Parameters
    {
	get { return parameters; }
	private set
	{
	    if (value == null || value.Length == 0)
		throw new MissingCommandParameterException();
	    parameters = value;
	}
    }

    public Command(string[] parameters)
    {
	Parameters = parameters;
    }

    internal void Validate(string[] parameters)
    {
	if (parameters.Length < MinRequiredParameters)
	    throw new MissingCommandParameterException();
	else if (parameters.Length > MaxAllowedParameters)
	    throw new RedundantCommandParameterException(parameters[0]);
    }

    public abstract void Execute();
}
