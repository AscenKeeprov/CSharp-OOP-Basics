public class Rectangle : Quadrilateral
{
    public override int Width { get; set; }
    public override int Height { get; set; }

    public Rectangle(int width, int height)
    {
	Width = width;
	Height = height;
    }
}
