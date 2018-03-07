public class Launcher
{
    public static void Main()      /* PROGRAM ACCESS POINT */
    {
	UserInterface.Load();
	IOManager.DisplayWelcome();
	CommandInterpreter.StartProcessingCommands();
    }
}
