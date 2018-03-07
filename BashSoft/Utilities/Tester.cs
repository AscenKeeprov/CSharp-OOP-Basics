using System;
using System.IO;

public class Tester         /* JUDGE SIMULATOR */
{
    internal void CompareFiles(string userOutputPath, string expectedOutputPath)
    {
	string userOutputFile = IOManager.ExtractFileName(userOutputPath);
	userOutputPath = IOManager.BuildAbsolutePath(userOutputPath);
	string userOutputFilePath = $"{userOutputPath}\\{userOutputFile}";
	string expectedOutputFile = IOManager.ExtractFileName(expectedOutputPath);
	expectedOutputPath = IOManager.BuildAbsolutePath(expectedOutputPath);
	string expectedOutputFilePath = $"{expectedOutputPath}\\{expectedOutputFile}";
	var fileReadingFeedback = new FileReadingFeedback();
	IOManager.OutputLine(typeof(Feedback), fileReadingFeedback.BeginMessage);
	try
	{
	    var fileComparisonFeedback = new FileComparisonFeedback();
	    string[] actualOutput = File.ReadAllLines(userOutputFilePath);
	    string[] expectedOutput = File.ReadAllLines(expectedOutputFilePath);
	    IOManager.OutputLine(typeof(Feedback), fileReadingFeedback.ProgressMessage);
	    bool hasMismatch;
	    string[] comparisonResults = Compare(actualOutput, expectedOutput, out hasMismatch);
	    if (hasMismatch)
	    {
		string mismatchesFilePath = $"{expectedOutputPath}\\mismatches.txt";
		FSManager.CreateFile(mismatchesFilePath, comparisonResults);
		string[] mismatches = FSManager.ReadFile(mismatchesFilePath);
		IOManager.OutputLine(typeof(Feedback), fileComparisonFeedback.ProgressMessage);
		IOManager.DisplayFileContents(mismatches);
		IOManager.OutputLine(typeof(Feedback), String.Format(
		    fileComparisonFeedback.ResultMessage, mismatchesFilePath));
	    }
	    else if (comparisonResults != null)
		IOManager.OutputLine(typeof(Feedback), fileComparisonFeedback.EndMessage);
	}
	catch (Exception exception)
	{
	    if (exception is DirectoryNotFoundException || exception is FileNotFoundException)
		throw new InvalidPathException();
	    else if (exception is UnauthorizedAccessException)
		throw new InsufficientPrivilegesException();
	}
    }

    private string[] Compare(string[] actualOutput, string[] expectedOutput, out bool hasMismatch)
    {
	var fileComparisonFeedback = new FileComparisonFeedback();
	hasMismatch = false;
	string output = String.Empty;
	IOManager.OutputLine(typeof(Feedback), fileComparisonFeedback.BeginMessage);
	int minOutputLength = actualOutput.Length;
	bool isComparisonCancelled = false;
	if (actualOutput.Length != expectedOutput.Length)
	{
	    IOManager.Output(typeof(Exception), new FileMismatchInevitableException().Message);
	    ConsoleKeyInfo choice = Console.ReadKey();
	    IOManager.OutputLine();
	    if (choice.Key == ConsoleKey.Y)
	    {
		hasMismatch = true; ;
		minOutputLength = Math.Min(actualOutput.Length, expectedOutput.Length);
	    }
	    else
	    {
		isComparisonCancelled = true;
		IOManager.OutputLine(typeof(Feedback), fileComparisonFeedback.AbortMessage);
	    }
	}
	if (!isComparisonCancelled)
	{
	    string[] mismatches = new string[minOutputLength];
	    for (int line = 0; line < minOutputLength; line++)
	    {
		string actualLine = actualOutput[line];
		string expectedLine = expectedOutput[line];
		if (!actualLine.Equals(expectedLine))
		{
		    string mismatchLine = String.Format(
			fileComparisonFeedback.Message, line + 1, expectedLine, actualLine);
		    output = $"{mismatchLine}";
		    hasMismatch = true;
		}
		else output = actualLine;
		mismatches[line] = output;
	    }
	    return mismatches;
	}
	else return null;
    }
}
