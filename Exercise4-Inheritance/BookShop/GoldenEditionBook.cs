public class GoldenEditionBook : Book
{
    private const decimal PriceModifier = 1.3M;

    public override decimal Price
    {
	get => base.Price * PriceModifier;
    }

    public GoldenEditionBook(string author, string title, decimal price)
	: base(author, title, price)
    {
    }
}
