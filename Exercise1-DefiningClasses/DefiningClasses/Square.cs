public class Square : Quadrilateral
{
    public override int Width { get; set; }
    public override int Height => Width;

    public Square(int length)
    {
	Width = length;
    }
}
