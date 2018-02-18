using System;
using System.Linq;

namespace JediGalaxy
{
    class Program
    {
	static void Main()
	{
	    int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
	    int x = dimensions[0];
	    int y = dimensions[1];
	    int[,] matrix = new int[x, y];
	    int value = 0;
	    for (int i = 0; i < x; i++)
	    {
		for (int j = 0; j < y; j++)
		{
		    matrix[i, j] = value++;
		}
	    }
	    long sum = 0;
	    string command;
	    while ((command = Console.ReadLine()) != "Let the Force be with you")
	    {
		int[] ivoS = command.Split().Select(int.Parse).ToArray();
		int[] evil = Console.ReadLine().Split().Select(int.Parse).ToArray();
		int xE = evil[0];
		int yE = evil[1];
		while (xE >= 0 && yE >= 0)
		{
		    if (xE >= 0 && xE < matrix.GetLength(0) &&
			yE >= 0 && yE < matrix.GetLength(1)) matrix[xE, yE] = 0;
		    xE--;
		    yE--;
		}
		int xI = ivoS[0];
		int yI = ivoS[1];
		while (xI >= 0 && yI < matrix.GetLength(1))
		{
		    if (xI >= 0 && xI < matrix.GetLength(0) &&
			yI >= 0 && yI < matrix.GetLength(1)) sum += matrix[xI, yI];
		    yI++;
		    xI--;
		}
	    }
	    Console.WriteLine(sum);
	}
    }
}
