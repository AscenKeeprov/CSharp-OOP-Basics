using System;
using System.Collections.Generic;

public class Box
{
    public double Height { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
    private double BaseArea => Length * Width;
    private double Side1Area => Length * Height;
    private double Side2Area => Width * Height;

    public Box(double height, double length, double width)
    {
	if (IsValidParameter(height) && IsValidParameter(length) && IsValidParameter(width))
	{
	    Height = height;
	    Length = length;
	    Width = width;
	}
	else
	{
	    List<string> invalidParameters = new List<string>();
	    if (!IsValidParameter(length)) invalidParameters.Add("Length");
	    if (!IsValidParameter(width)) invalidParameters.Add("Width");
	    if (!IsValidParameter(height)) invalidParameters.Add("Height");
	    foreach (string invalidParameter in invalidParameters)
	    {
		Console.WriteLine($"{invalidParameter} cannot be zero or negative.");
	    }
	    throw new ArgumentOutOfRangeException();
	}
    }

    private bool IsValidParameter(double? parameter)
    {
	return parameter != null && parameter > 0;
    }

    public double CalculateVolume()
    {
	return Height * Length * Width;
    }

    public double CalculateLateralSurfaceArea()
    {
	return (2 * Side1Area) + (2 * Side2Area);
    }

    public double CalculateSurfaceArea()
    {
	return (2 * BaseArea) + CalculateLateralSurfaceArea();
    }
}
