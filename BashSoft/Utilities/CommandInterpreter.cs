using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class CommandInterpreter  /* PROCESSES CONSOLE COMMANDS */
{
    private static List<string> commandCache = new List<string>();
    private const int CommandCacheSize = 10;

    internal static void StartProcessingCommands()
    {
	CommandFactory commandFactory = new CommandFactory();
	IOManager.Output(typeof(String), $" {FSManager.CurrentDirectory}> ");
	string input;
	while (!(input = IOManager.Input().Trim()).Equals("BASH"))
	{
	    IOManager.OutputLine();
	    string[] commandParameters = ParseInput(input);
	    try
	    {
		IExecutable command = commandFactory.Produce(commandParameters);
		command.Execute();
	    }
	    catch (Exception exception)
	    {
		IOManager.OutputLine(typeof(Exception), exception.Message);
	    }
	    IOManager.OutputLine();
	    IOManager.Output(typeof(String), $" {FSManager.CurrentDirectory}> ");
	}
    }

    private static string[] ParseInput(string input)
    {
	string[] commandParameters = null;
	if (input.Contains('"'))
	{
	    string[] elements = null;
	    elements = Regex.Split(input.Trim('"'), @"\""?\s+\""|\""\s+\""?");
	    if (elements[0].Contains(' '))
	    {
		commandParameters = new string[elements.Length + 1];
		commandParameters[0] = elements[0].Split()[0];
		commandParameters[1] = elements[0].Split()[1];
		for (int e = 1; e < elements.Length; e++)
		    commandParameters[e + 1] = elements[e];
	    }
	    else commandParameters = elements;
	}
	else commandParameters = input.Trim()
	    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
	return commandParameters;
    }
}
