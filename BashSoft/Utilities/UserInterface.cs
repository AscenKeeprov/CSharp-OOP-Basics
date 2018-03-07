using System;

public static class UserInterface	/* MAINTAINS PROGRAM APPEARANCE */
{
    private static int defaultWindowWidth;
    private const int applicationWindowWidth = 103;
    private static int defaultWindowHeight;
    private const int applicationWindowHeight = 39;
    private static string defaultTitle;
    private const string applicationTitle = "BASHSOFT";
    private static int defaultBufferWidth;
    private static int defaultBufferHeight;
    private const int applicationBufferMultiplier = 10;
    private static ConsoleColor defaultBackgroundColor;
    private const ConsoleColor applicationBackgroundColor = ConsoleColor.Black;
    private static ConsoleColor defaultForegroundColor;
    private const ConsoleColor applicationFeedbackColor = ConsoleColor.Cyan;
    private const ConsoleColor applicationForegroundColor = ConsoleColor.Green;
    private const ConsoleColor applicationExceptionColor = ConsoleColor.Red;

    internal static void Load()
    {
	BackupDefaultSettings();
	ApplyCustomSettings();
    }

    private static void BackupDefaultSettings()
    {
	defaultWindowWidth = Console.WindowWidth;
	defaultWindowHeight = Console.WindowHeight;
	defaultTitle = Console.Title;
	defaultBufferWidth = Console.BufferWidth;
	defaultBufferHeight = Console.BufferHeight;
	defaultBackgroundColor = Console.BackgroundColor;
	defaultForegroundColor = Console.ForegroundColor;
    }

    private static void ApplyCustomSettings()
    {
	Console.SetWindowSize(applicationWindowWidth, applicationWindowHeight);
	Console.Title = applicationTitle;
	Console.BufferWidth = applicationWindowWidth;
	Console.BufferHeight = applicationWindowHeight * applicationBufferMultiplier;
	Console.BackgroundColor = applicationBackgroundColor;
	Console.ForegroundColor = applicationForegroundColor;
    }

    internal static void FormatOutput(Type outputType)
    {
	switch (outputType.Name.ToUpper())
	{
	    case "EXCEPTION":
		Console.ForegroundColor = applicationExceptionColor;
		break;
	    case "FEEDBACK":
		Console.ForegroundColor = applicationFeedbackColor;
		break;
	}
    }

    internal static void ResetOutputFormat()
    {
	Console.BackgroundColor = applicationBackgroundColor;
	Console.ForegroundColor = applicationForegroundColor;
    }

    internal static void Unload()
    {
	RestoreDefaultSettings();
    }

    private static void RestoreDefaultSettings()
    {
	Console.SetWindowSize(defaultWindowWidth, defaultWindowHeight);
	Console.Title = defaultTitle;
	Console.BufferWidth = defaultBufferWidth;
	Console.BufferHeight = defaultBufferHeight;
	Console.BackgroundColor = defaultBackgroundColor;
	Console.ForegroundColor = defaultForegroundColor;
    }
}
