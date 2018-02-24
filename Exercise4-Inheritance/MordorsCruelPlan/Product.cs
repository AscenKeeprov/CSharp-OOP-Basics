public class Product
{
    public string Type { get; protected set; }

    public Product() { }

    public Product(string type)
    {
	Type = type;
    }
}
