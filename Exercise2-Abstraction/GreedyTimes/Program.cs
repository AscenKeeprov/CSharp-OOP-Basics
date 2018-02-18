using System;
using System.Linq;
using System.Text.RegularExpressions;

public class GreedyTimes
{
    static void Main(string[] args)
    {
	long bagCapacity = long.Parse(Console.ReadLine());
	Bag bag = new Bag(bagCapacity);
	string[] safeContents = Console.ReadLine().Split();
	for (int i = 0; i < safeContents.Length; i += 2)
	{
	    string itemName = safeContents[i];
	    string itemType = Examine(itemName);
	    if (!IsUsefulItem(itemType)) continue;
	    long itemAmount = long.Parse(safeContents[i + 1]);
	    if (!CanTakeItem(itemAmount, itemType, bag)) continue;
	    else TakeItem(itemType, itemName, itemAmount, bag);
	}
	Console.WriteLine(bag);
    }

    private static string Examine(string itemName)
    {
	string itemType = String.Empty;
	if (Regex.IsMatch(itemName, @"\b[A-Za-z]{3}\b")) itemType = "Cash";
	else if (itemName.Length >= 4 && itemName.ToUpper().EndsWith("GEM")) itemType = "Gem";
	else if (itemName.ToUpper() == "GOLD") itemType = "Gold";
	return itemType;
    }

    private static bool IsUsefulItem(string itemType)
    {
	return itemType == "Gold" || itemType == "Gem" || itemType == "Cash";
    }

    private static bool CanTakeItem(long itemAmount, string itemType, Bag bag)
    {
	if (bag.FreeSpace < itemAmount) return false;
	if (itemType == "Gem" && itemAmount + bag.GemsTotal > bag.Gold) return false;
	if (itemType == "Cash" && itemAmount + bag.CashTotal > bag.GemsTotal) return false;
	return true;
    }

    private static void TakeItem(string itemType, string itemName, long itemAmount, Bag bag)
    {
	if (itemType == "Gold") bag.Gold += itemAmount;
	else if (itemType == "Gem")
	{
	    Gem gem = new Gem(itemName, itemAmount);
	    if (bag.Gems.Any(g => g.Type == itemName))
	    {
		gem = bag.Gems.First(g => g.Type == itemName);
		gem.Amount += itemAmount;
	    }
	    else bag.Gems.Add(gem);
	}
	else if (itemType == "Cash")
	{
	    Currency currency = new Currency(itemName, itemAmount);
	    if (bag.Cash.Any(c => c.Type == itemName))
	    {
		currency = bag.Cash.First(c => c.Type == itemName);
		currency.Amount += itemAmount;
	    }
	    else bag.Cash.Add(currency);
	}
    }
}
