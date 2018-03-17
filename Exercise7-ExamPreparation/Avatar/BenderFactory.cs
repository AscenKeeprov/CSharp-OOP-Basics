using System;
using System.Collections.Generic;
using System.Globalization;
using Avatar.Models.Benders;

namespace Avatar
{
    public static class BenderFactory
    {
	private static TextInfo textInfo = new CultureInfo("", true).TextInfo;

	internal static Bender CreateBender(List<string> benderInfo)
	{
	    string benderType = textInfo.ToTitleCase(benderInfo[1]);
	    string name = benderInfo[2];
	    int power = int.Parse(benderInfo[3]);
	    double primaryAttribute = double.Parse(benderInfo[4]);
	    switch (benderType.ToUpper())
	    {
		case "AIR":
		    return new AirBender(name, power, primaryAttribute);
		case "WATER":
		    return new WaterBender(name, power, primaryAttribute);
		case "FIRE":
		    return new FireBender(name, power, primaryAttribute);
		case "EARTH":
		    return new EarthBender(name, power, primaryAttribute);
		default:
		    throw new ArgumentException("Invalid bender!");
	    }
	}
    }
}
