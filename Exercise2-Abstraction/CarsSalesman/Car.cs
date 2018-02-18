using System.Text;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public int Weight { get; set; }
    public string Color { get; set; }

    public Car()
    {
	Model = "Unknown";
	Engine = new Engine();
	Weight = -1;
	Color = "n/a";
    }

    public Car(string model, Engine engine) : this()
    {
	Model = model;
	Engine = engine;
    }

    public Car(string model, Engine engine, int weight) : this(model, engine)
    {
	Weight = weight;
    }

    public Car(string model, Engine engine, string color) : this(model, engine)
    {
	Color = color;
    }

    public Car(string model, Engine engine, int weight, string color) : this(model, engine)
    {
	Weight = weight;
	Color = color;
    }

    public override string ToString()
    {
	StringBuilder carInfo = new StringBuilder();
	carInfo.AppendLine($"{Model}:");
	carInfo.AppendLine($"{Engine}");
	carInfo.AppendLine($"  Weight: {(Weight == -1 ? "n/a" : $"{Weight}")}");
	carInfo.AppendLine($"  Color: {Color}");
	return carInfo.ToString().TrimEnd();
    }
}
