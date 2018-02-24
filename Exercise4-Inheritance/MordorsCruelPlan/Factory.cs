public abstract class Factory
{
    internal virtual Product Produce(string productType)
    {
	return new Product();
    }

    internal virtual Product Produce(int productId)
    {
	return new Product();
    }
}
