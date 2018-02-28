using System;
using System.Linq;

public class SmartPhone : ISmartPhone
{
    public void Call(string phoneNumber)
    {
	if (phoneNumber.Any(c => !Char.IsDigit(c)))
	    throw new ArgumentException("Invalid number!");
	Console.WriteLine($"Calling... {phoneNumber}");
    }

    public void Browse(string webAddress)
    {
	if (webAddress.Any(c => Char.IsDigit(c)))
	    throw new ArgumentException("Invalid URL!");
	Console.WriteLine($"Browsing: {webAddress}!");
    }
}
