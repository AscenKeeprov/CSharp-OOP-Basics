using System;

public class Rectangle
{
    public string Id { get; set; }
    public double Width { get; set; }
    public double Heigth { get; set; }
    public Tuple<double, double> TopLeftCorner { get; set; }
    public Tuple<double, double> TopRightCorner
    {
	get
	{
	    return Tuple.Create(TopLeftCorner.Item1 + Width, TopLeftCorner.Item2);
	}
    }
    public Tuple<double, double> BottomLeftCorner
    {
	get
	{
	    return Tuple.Create(TopLeftCorner.Item1, TopLeftCorner.Item2 - Heigth);
	}
    }
    public Tuple<double, double> BottomRightCorner
    {
	get
	{
	    return Tuple.Create(TopLeftCorner.Item1 + Width, TopLeftCorner.Item2 - Heigth);
	}
    }

    public Rectangle(string id, double width, double heigth, Tuple<double, double> origin)
    {
	Id = id;
	Width = width;
	Heigth = heigth;
	TopLeftCorner = Tuple.Create(origin.Item1, origin.Item2);
    }

    public bool IntersectsWith(Rectangle rectangle2)
    {
	if (TopLeftCorner.Item1 > rectangle2.BottomRightCorner.Item1 ||
	    BottomRightCorner.Item1 < rectangle2.TopLeftCorner.Item1 ||
	    TopLeftCorner.Item2 < rectangle2.BottomRightCorner.Item2 ||
	    BottomRightCorner.Item2 > rectangle2.TopLeftCorner.Item2)
	    return false;
	return true;
    }
}
