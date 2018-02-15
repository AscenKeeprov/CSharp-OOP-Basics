public class Car
{
    public string Model { get; set; }
    public int Speed { get; set; }

    public override string ToString()
    {
	return $"{Model} {Speed}";
    }
}
