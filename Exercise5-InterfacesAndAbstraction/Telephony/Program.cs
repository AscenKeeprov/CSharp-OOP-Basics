using System;

public class Program
{
    static void Main()
    {
	SmartPhone smartPhone = new SmartPhone();
	string[] phoneNumbersToCall = Console.ReadLine().Split();
	foreach (string phoneNumber in phoneNumbersToCall)
	{
	    try
	    {
		smartPhone.Call(phoneNumber);
	    }
	    catch (ArgumentException exception)
	    {
		Console.WriteLine(exception.Message);
	    }
	}
	string[] webSitesToBrowse = Console.ReadLine().Split();
	foreach (string webSite in webSitesToBrowse)
	{
	    try
	    {
		smartPhone.Browse(webSite);
	    }
	    catch (ArgumentException exception)
	    {
		Console.WriteLine(exception.Message);
	    }
	}
    }
}
