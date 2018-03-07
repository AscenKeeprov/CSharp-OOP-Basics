using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class IOManager      /* PROCESSES INPUT AND PRESENTS OUTPUT */
{
    private static string separator = new String('░', 75);

    internal static void DisplayWelcome()
    {
	string[] welcomeText = FSManager.ReadFile("resources/welcome.txt");
	foreach (string line in welcomeText) OutputLine(typeof(String), line);
    }

    internal static string Input()
    {
	return Console.ReadLine();
    }

    internal static void Output(Type outputType = null, string message = null)
    {
	if (!String.IsNullOrEmpty(message))
	{
	    UserInterface.FormatOutput(outputType);
	    Console.Write(message);
	    if (outputType != null) UserInterface.ResetOutputFormat();
	}
	else Console.Write(Environment.NewLine);
    }

    internal static void OutputLine(Type outputType = null, string message = null)
    {
	if (!String.IsNullOrEmpty(message))
	{
	    UserInterface.FormatOutput(outputType);
	    Console.WriteLine(message);
	    if (outputType != null) UserInterface.ResetOutputFormat();
	}
	else Output();
    }

    internal static void DisplayDirectorySubdirectories(
	string[] subdirs, string[] currentDirFiles, Queue<string> dirTree)
    {
	for (int s = 0; s < subdirs.Length; s++)
	{
	    dirTree.Enqueue(subdirs[s]);
	    int subDirLevel = subdirs[s].LastIndexOf('\\');
	    string subDirName = subdirs[s].Substring(subDirLevel);
	    string indentation = $"├{new string('─', subDirLevel)}";
	    if (s == subdirs.Length - 1)
	    {
		if (currentDirFiles.Length > 0)
		    indentation = $"├{new string('─', subDirLevel)}";
		else indentation = $"└{new string('─', subDirLevel)}";
	    }
	    OutputLine(typeof(String), $"{indentation}{subDirName}");
	}
    }

    internal static void DisplayDirectoryFiles(string[] files)
    {
	for (int f = 0; f < files.Length; f++)
	{
	    int fileLevel = files[f].LastIndexOf('\\');
	    string fileName = files[f].Substring(fileLevel + 1);
	    string indentation = $"├{new string('─', fileLevel)}";
	    if (f == files.Length - 1) indentation = $"└{new string('─', fileLevel)}";
	    OutputLine(typeof(String), $"{indentation}{fileName}");
	}
    }

    internal static void DisplayFileContents(string[] fileContents)
    {
	OutputLine(typeof(String), separator);
	foreach (string line in fileContents)
	{
	    OutputLine(typeof(String), $"░ {line}");
	}
	OutputLine(typeof(String), separator);
    }

    internal static string BuildAbsolutePath(string path)
    {
	string currentDir = FSManager.CurrentDirectory;
	string absolutePath = path.Replace('/', '\\').Trim('\\');
	absolutePath = absolutePath.Replace("\\.\\", "\\");
	if (absolutePath.StartsWith(".\\") || absolutePath.EndsWith("\\."))
	    absolutePath = absolutePath.Trim('.').Trim('\\');
	int pathEnd;
	if (!String.IsNullOrEmpty(ExtractFileName(absolutePath)))
	{
	    pathEnd = absolutePath.LastIndexOf('\\');
	    if (pathEnd == -1) absolutePath = currentDir;
	    else absolutePath = absolutePath.Substring(0, pathEnd);
	}
	if (!absolutePath.Contains(':'))
	{
	    if (Regex.IsMatch(absolutePath, @"(?:\.{1,2}\\*)+"))
	    {
		string[] currentPath = currentDir.Split('\\');
		string targetDir = String.Empty;
		if (absolutePath.Contains('\\'))
		{
		    int targetDirIndex = Math.Min(absolutePath.LastIndexOf('.') + 2, absolutePath.Length);
		    targetDir = absolutePath.Substring(targetDirIndex);
		}
		if (!String.IsNullOrEmpty(targetDir)) absolutePath = absolutePath.Replace(targetDir, String.Empty);
		int levelsUp = absolutePath.Split('\\', StringSplitOptions.RemoveEmptyEntries).Length;
		if (absolutePath == ".") levelsUp = 0;
		if (levelsUp < currentPath.Length)
		    absolutePath = $"{String.Join("\\", currentPath.Take(currentPath.Length - levelsUp))}\\{targetDir}";
		else absolutePath = $"{currentPath[0]}\\{targetDir}";
	    }
	    else absolutePath = $"{currentDir}\\{absolutePath}";
	}
	return absolutePath;
    }

    internal static string ExtractFileName(string path)
    {
	string fileNamePattern = @"(?!\s)[^\.\/\\:*?\""<>|]+\.[^\s\/\\:*?\""<>|]+";
	string fileName = String.Empty;
	if (path.Contains('.'))
	{
	    if (path.Contains('\\') || path.Contains('/'))
	    {
		string tail = Regex.Split(path, @".*\\|.*\/").Last();
		if (Regex.IsMatch(tail, fileNamePattern)) fileName = tail;
	    }
	    else
	    {
		if (Regex.IsMatch(path, fileNamePattern)) fileName = path;
	    }
	}
	return fileName;
    }

    internal static void PrintDatabaseReport(Dictionary<string, Dictionary<string, int[]>> report)
    {
	OutputLine(typeof(Feedback), new DatabaseReportingFeedback().ResultMessage);
	OutputLine(typeof(String), separator);
	foreach (var record in report)
	{
	    string course = record.Key;
	    OutputLine(typeof(String), $"░·{course}:");
	    var studentData = record.Value;
	    foreach (var student in studentData)
	    {
		string studentName = student.Key;
		int[] scores = student.Value;
		double averageScore = scores.Average();
		double grade = (averageScore / 100) * 4 + 2;
		OutputLine(typeof(String), $"░  {studentName} ─ {String.Join(",", scores)}" +
		    $" ═> Average Score: {averageScore:F0}, Grade: {grade:F2}");
	    }
	}
	OutputLine(typeof(String), separator);
    }
}
