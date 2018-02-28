using System;
using System.Linq;

public class MyList : AddRemoveCollection, IListable
{
    public string Used => String.Join(" ", Items);

    public override string Remove()
    {
	string item = Items.First();
	Items.RemoveAt(0);
	return item;
    }
}
