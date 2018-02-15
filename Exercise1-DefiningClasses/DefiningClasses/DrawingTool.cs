public class DrawingTool
{
    private int FigureWidth { get; set; }
    private int FigureHeight { get; set; }

    public DrawingTool(Quadrilateral figure)
    {
	FigureWidth = figure.Width;
	FigureHeight = figure.Height;
    }

    public void Draw()
    {
	for (int row = 1; row <= FigureHeight; row++)
	{
	    if (row == 1 || row == FigureHeight)
		System.Console.WriteLine($"|{new string('-', FigureWidth)}|");
	    else System.Console.WriteLine($"|{new string(' ', FigureWidth)}|");
	}
    }
}
