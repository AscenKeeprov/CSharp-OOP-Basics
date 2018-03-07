using System;

public class CommandFactory	/* CREATES NEW COMMAND INSTANCES*/
{
    internal IExecutable Produce(string[] parameters)
    {
	if (parameters.Length == 0) throw new MissingCommandException();
	string commandType = parameters[0];
	if(!Enum.TryParse(typeof(ECommand), commandType.ToUpper(), out object validCommand))
	    throw new InvalidCommandException(commandType);
	switch (commandType.ToUpper())
	{
	    case "COMPARE":
		commandType = "CompareFilesCommand";
		break;
	    case "DOWNLOAD":
		commandType = "DownloadFileCommand";
		break;
	    case "DROPDB":
		commandType = "DropDatabaseCommand";
		break;
	    case "EXIT":
		commandType = "ExitCommand";
		break;
	    case "GOTODIR":
		commandType = "ChangeDirectoryCommand";
		break;
	    case "HELP":
		commandType = "HelpCommand";
		break;
	    case "LISTDIR":
		commandType = "TraverseDirectoryCommand";
		break;
	    case "LOADDB":
		commandType = "LoadDatabaseCommand";
		break;
	    case "MAKEDIR":
		commandType = "CreateDirectoryCommand";
		break;
	    case "OPEN":
		commandType = "OpenFileCommand";
		break;
	    case "READDB":
		commandType = "ReadDatabaseCommand";
		break;
	    case "WIPE":
		commandType = "ClearScreenCommand";
		break;
	}
	Type typeOfCommand = Type.GetType(commandType);
	IExecutable command = (IExecutable)Activator
	    .CreateInstance(typeOfCommand, new object[] { parameters });
	return command;
    }
}
