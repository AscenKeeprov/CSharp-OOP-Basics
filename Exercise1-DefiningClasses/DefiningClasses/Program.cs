using System;

class Program
{
    static void Main()
    {
	string figureType = Console.ReadLine();
	if (figureType == "Square")
	{
	    int squareLength = int.Parse(Console.ReadLine());
	    Square square = new Square(squareLength);
	    DrawingTool dt = new DrawingTool(square);
	    dt.Draw();
	}
	else if (figureType == "Rectangle")
	{
	    int rectangleWidth = int.Parse(Console.ReadLine());
	    int rectangleHeight = int.Parse(Console.ReadLine());
	    Rectangle rectangle = new Rectangle(rectangleWidth, rectangleHeight);
	    DrawingTool dt = new DrawingTool(rectangle);
	    dt.Draw();
	}
    }
}
