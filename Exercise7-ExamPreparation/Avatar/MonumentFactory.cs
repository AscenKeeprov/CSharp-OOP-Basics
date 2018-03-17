using System;
using System.Collections.Generic;
using System.Globalization;
using Avatar.Models.Monuments;

namespace Avatar
{
    public static class MonumentFactory
    {
	private static TextInfo textInfo = new CultureInfo("", true).TextInfo;

	internal static Monument CreateMonument(List<string> monumentInfo)
	{
	    string monumentType = textInfo.ToTitleCase(monumentInfo[1]);
	    string name = monumentInfo[2];
	    int affinity = int.Parse(monumentInfo[3]);
	    switch (monumentType.ToUpper())
	    {
		case "AIR":
		    return new AirMonument(name, affinity);
		case "WATER":
		    return new WaterMonument(name, affinity);
		case "FIRE":
		    return new FireMonument(name, affinity);
		case "EARTH":
		    return new EarthMonument(name, affinity);
		default:
		    throw new ArgumentException("Invalid monument!");
	    }
	}
    }
}
