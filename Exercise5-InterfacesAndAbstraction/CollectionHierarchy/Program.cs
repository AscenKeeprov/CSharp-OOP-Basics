using System;

public class Program
{
    static void Main()
    {
	AddCollection addCollection = new AddCollection();
	AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
	MyList myList = new MyList();
	string[] itemsToAdd = Console.ReadLine().Split();
	int[,] addResults = new int[3, itemsToAdd.Length];
	for (int i = 0; i < itemsToAdd.Length; i++)
	{
	    int indexOfAdded = addCollection.Add(itemsToAdd[i]);
	    addResults[0, i] = indexOfAdded;
	    indexOfAdded = addRemoveCollection.Add(itemsToAdd[i]);
	    addResults[1, i] = indexOfAdded;
	    indexOfAdded = myList.Add(itemsToAdd[i]);
	    addResults[2, i] = indexOfAdded;
	}
	int removeCount = int.Parse(Console.ReadLine());
	string[,] removeResults = new string[2, removeCount];
	for (int i = 0; i < removeCount; i++)
	{
	    string removed = addRemoveCollection.Remove();
	    removeResults[0, i] = removed;
	    removed = myList.Remove();
	    removeResults[1, i] = removed;
	}
	for (int r = 0; r < addResults.GetLength(0); r++)
	{
	    for (int c = 0; c < addResults.GetLength(1); c++)
	    {
		Console.Write($"{addResults[r,c]} ");
	    }
	    Console.Write(Environment.NewLine);
	}
	for (int r = 0; r < removeResults.GetLength(0); r++)
	{
	    for (int c = 0; c < removeResults.GetLength(1); c++)
	    {
		Console.Write($"{removeResults[r, c]} ");
	    }
	    Console.Write(Environment.NewLine);
	}
    }
}
