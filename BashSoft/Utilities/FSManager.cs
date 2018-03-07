using System;
using System.Collections.Generic;
using System.IO;

public static class FSManager      /* CARRIES OUT FILE SYSTEM OPERATIONS */
{
    internal static string CurrentDirectory => Directory.GetCurrentDirectory();

    internal static void TraverseDirectory(int depth)
    {
	string startDir = CurrentDirectory;
	int startDirLevel = startDir.Split('\\').Length;
	Queue<string> dirTree = new Queue<string>();
	dirTree.Enqueue(startDir);
	while (dirTree.Count != 0)
	{
	    string currentDir = dirTree.Dequeue();
	    int currentDirLevel = currentDir.Split('\\').Length;
	    if (currentDirLevel - startDirLevel == depth + 1) break;
	    try
	    {
		string[] currentDirSubdirs = Directory.GetDirectories(currentDir);
		string[] currentDirFiles = Directory.GetFiles(currentDir);
		if (currentDirSubdirs.Length == 0 && currentDirFiles.Length == 0)
		    IOManager.OutputLine(typeof(String),
			$"{new string(' ', currentDirLevel - startDirLevel)}{currentDir}");
		else
		{
		    IOManager.OutputLine(typeof(String),
			$"┌{new string('─', currentDirLevel - startDirLevel)}{currentDir}");
		    IOManager.DisplayDirectorySubdirectories(currentDirSubdirs, currentDirFiles, dirTree);
		    IOManager.DisplayDirectoryFiles(currentDirFiles);
		}
	    }
	    catch (Exception exception)
	    {
		if (exception is UnauthorizedAccessException)
		    IOManager.OutputLine(typeof(Exception), new InsufficientPrivilegesException().Message);
	    }
	}
    }

    internal static void CreateDirectory(string path)
    {
	path = IOManager.BuildAbsolutePath(path);
	string existingPath = String.Empty;
	string[] pathToCreate = path.Split('\\', StringSplitOptions.RemoveEmptyEntries);
	try
	{
	    for (int l = 0; l < pathToCreate.Length; l++)
	    {
		string currentPath = existingPath + pathToCreate[l];
		if (!Directory.Exists(currentPath))
		{
		    Directory.CreateDirectory(currentPath);
		    IOManager.OutputLine(typeof(Feedback), String.Format(
			new DirectoryCreationFeedback().ResultMessage, pathToCreate[l], existingPath));
		}
		existingPath = $"{currentPath}\\";
	    }
	}
	catch (Exception exception)
	{
	    if (exception is ArgumentException || exception is NotSupportedException)
		throw new InvalidNameException("Directory");
	    else if (exception is UnauthorizedAccessException)
		throw new InsufficientPrivilegesException();
	}
    }

    internal static void ChangeDirectory(string destinationPath)
    {
	destinationPath = IOManager.BuildAbsolutePath(destinationPath);
	try
	{
	    Directory.SetCurrentDirectory(destinationPath);
	}
	catch (Exception exception)
	{
	    if (exception is DirectoryNotFoundException)
		throw new InvalidPathException();
	    else if (exception is ArgumentOutOfRangeException)
		throw new InvalidCommandParameterException("Directory path");
	    else if (exception is UnauthorizedAccessException)
		throw new InsufficientPrivilegesException();
	}
    }

    internal static void CreateFile(string path, string[] contents)
    {
	try
	{
	    File.WriteAllLines(path, contents);
	}
	catch (Exception exception)
	{
	    if (exception is DirectoryNotFoundException)
		throw new InvalidPathException();
	    else if (exception is UnauthorizedAccessException)
		throw new InsufficientPrivilegesException();
	}
    }

    internal static string[] ReadFile(string path)
    {
	string fileName = IOManager.ExtractFileName(path);
	if (String.IsNullOrEmpty(fileName))
	    throw new FileNotSpecifiedException();
	path = IOManager.BuildAbsolutePath(path);
	string filePath = $"{path}\\{fileName}";
	try
	{
	    string[] fileContents = File.ReadAllLines(filePath);
	    return fileContents;
	}
	catch (Exception exception)
	{
	    if (exception is DirectoryNotFoundException || exception is FileNotFoundException)
		throw new InvalidPathException();
	    else if (exception is UnauthorizedAccessException)
		throw new InsufficientPrivilegesException();
	    return null;
	}
    }

    internal static void DownloadFile(string sourcePath)
    {
	string fileName = IOManager.ExtractFileName(sourcePath);
	if (String.IsNullOrEmpty(fileName)) throw new FileNotSpecifiedException();
	else
	{
	    sourcePath = IOManager.BuildAbsolutePath(sourcePath);
	    string sourceFilePath = $"{sourcePath}\\{fileName}";
	    string destinationFilePath = $"{CurrentDirectory}\\{fileName}";
	    var fileDownloadFeedback = new FileDownloadingFeedback();
	    try
	    {
		File.Copy(sourceFilePath, destinationFilePath);
		IOManager.OutputLine(typeof(Feedback), String.Format(
		    fileDownloadFeedback.ResultMessage, fileName));
	    }
	    catch (Exception exception)
	    {
		if (exception is DirectoryNotFoundException || exception is FileNotFoundException)
		    throw new InvalidPathException();
		else if (exception is UnauthorizedAccessException)
		    throw new InsufficientPrivilegesException();
		else if (exception is IOException)
		{
		    if (File.Exists(destinationFilePath))
		    {
			IOManager.Output(typeof(Exception), new FileAlreadyDownloadedException().Message);
			ConsoleKeyInfo choice = Console.ReadKey();
			IOManager.OutputLine();
			if (choice.Key == ConsoleKey.Y)
			{
			    File.Copy(sourceFilePath, destinationFilePath, true);
			    IOManager.OutputLine(typeof(Feedback), String.Format(
				fileDownloadFeedback.EndMessage, fileName));
			}
			else IOManager.OutputLine(typeof(Feedback), fileDownloadFeedback.AbortMessage);
		    }
		    else throw exception;
		}
	    }
	}
    }
}
