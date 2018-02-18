using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Bag
{
    public long Capacity { get; set; }
    public long FreeSpace => Capacity - (Gold + GemsTotal + CashTotal);
    public long Gold { get; set; }
    public List<Gem> Gems { get; set; }
    public long GemsTotal => Gems.Select(g => g.Amount).Sum();
    public List<Currency> Cash { get; set; }
    public long CashTotal => Cash.Select(c => c.Amount).Sum();

    public Bag(long capacity)
    {
	Capacity = capacity;
	Gold = 0;
	Gems = new List<Gem>();
	Cash = new List<Currency>();
    }

    public override string ToString()
    {
	StringBuilder bagContents = new StringBuilder();
	if (Gold > 0)
	{
	    bagContents.AppendLine($"<Gold> ${Gold}");
	    bagContents.AppendLine($"##Gold - {Gold}");
	}
	if (GemsTotal > 0)
	{
	    bagContents.AppendLine($"<Gem> ${GemsTotal}");
	    foreach (Gem gem in Gems
		.OrderByDescending(g => g.Type).ThenBy(g => g.Amount))
		bagContents.AppendLine(gem.ToString());
	}
	if (CashTotal > 0)
	{
	    bagContents.AppendLine($"<Cash> ${CashTotal}");
	    foreach (Currency currency in Cash
		.OrderByDescending(c => c.Type).ThenBy(c => c.Amount))
		bagContents.AppendLine(currency.ToString());
	}
	return bagContents.ToString().TrimEnd();
    }
}
