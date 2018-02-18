public class Gem
{
    public string Type { get; set; }
    public long Amount { get; set; }

    public Gem(string type, long amount)
    {
	Type = type;
	Amount = amount;
    }

    public override string ToString()
    {
	return $"##{Type} - {Amount}";
    }
}
