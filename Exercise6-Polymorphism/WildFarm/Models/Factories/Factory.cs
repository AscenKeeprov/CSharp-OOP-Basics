using System;
using System.Globalization;

public abstract class Factory
{
    protected TextInfo TextInfo { get; set; }

    public Factory()
    {
	TextInfo = new CultureInfo("", true).TextInfo;
    }

    internal Type ToProperType(string type)
    {
	type = TextInfo.ToTitleCase(type);
	Type typeOfProduct = Type.GetType(type);
	return typeOfProduct;
    }
}
